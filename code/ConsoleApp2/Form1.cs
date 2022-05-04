using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace ConsoleApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly string TemplateFileName = Environment.CurrentDirectory+ @"\Шаблоны\shablon1.docx";
        private readonly string TemplateShablon2 = Environment.CurrentDirectory + @"\Шаблоны\shablon2.doc";
        private readonly string TemplateShablon3 = Environment.CurrentDirectory + @"\Шаблоны\shablon3.doc";
        private readonly string TemplateShablon7 = Environment.CurrentDirectory + @"\Шаблоны\shablon7.docx";


        
        public void Button1_Click(object sender, EventArgs e)
        {
            Arifm arifm = new Arifm();
            //Console.WriteLine("Введите номер зачетки");
            //Console.WriteLine("Нажмите Enter....");
            // int zachetka=Convert.ToInt32(Console.ReadLine());
            var group = BoxGroup.Text;
            Directory.CreateDirectory(Environment.CurrentDirectory+ @"\1 расчетка геодезия");

            try
            {
                //Это лист 1
                var name = BoxFUO.Text;
                var year = BoxYear.Text;
                //string MestoZapuska = Environment.CurrentDirectory;
                string file_doc1 = Environment.CurrentDirectory;
                file_doc1 = file_doc1 + @"\Шаблоны\shablon1.docx";

                string file_doc2 = Environment.CurrentDirectory;
                file_doc2 = file_doc1 + @"\Шаблоны\shablon2.docx";

                string file_doc3 = Environment.CurrentDirectory;
                file_doc3 = file_doc1 + @"\Шаблоны\shablon3.docx";

                string file_doc7 = Environment.CurrentDirectory;
                file_doc7 = file_doc1 + @"\Шаблоны\shablon7.docx";


                var wordApp = new Word.Application();
                wordApp.Visible = false;
                var wordDocument1 = wordApp.Documents.Open(TemplateFileName);
                ReplaceWordStub("{name}", name, ref wordDocument1);
                ReplaceWordStub("{group}", group, ref wordDocument1);
                ReplaceWordStub("{year}", year, ref wordDocument1);
                wordDocument1.SaveAs2(Environment.CurrentDirectory+@"\1 расчетка геодезия\1й Лист.docx");
                wordApp.Visible = true;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }

            // Лист 2
            var wordApp2 = new Word.Application();
            wordApp2.Visible = false;
            var wordDocument2 = wordApp2.Documents.Open(TemplateShablon2);
            string zachetka_txt = BoxNumZachetki.Text;

            string NumJurnal = BoxNumJurnal.Text;
            int zachetka = Convert.ToInt32(BoxNumZachetki.Text);
            int KC = zachetka;
            int KCz = 0;
            while ((KC / 10) >= 1 || (KC % 10) >= 1)
            {
                KC = KC / 10;
                KCz++;
            }
            int[] ChislaZachetki = new int[KCz];
            for (int i = 0; i < KCz; i++)
            {
                ChislaZachetki[i] = zachetka % 10;
                zachetka = zachetka / 10;
            }
            double LastNubmers = ChislaZachetki[0] + ChislaZachetki[1] * 10;
            double Gr_a0 = LastNubmers;                               // Начальный дирекционный угол
            double Min_a0 = 30.2 + Convert.ToInt32(NumJurnal);
            string a0_txt = Gr_a0 + "°" + Min_a0 + "'";

            double an_gr =Gr_a0+10;
            double an_min = Min_a0 + 32.8;
            string an_txt = an_gr + "° " + an_min + "'";
            ReplaceWordStub2("{an_txt}", an_txt, ref wordDocument2);

            string Xpp8 = "-14,02";
            string Ypp8 = "+627,98";
            ReplaceWordStub2("{Xpp8}", Xpp8, ref wordDocument2);
            ReplaceWordStub2("{Ypp8}", Ypp8, ref wordDocument2);

            if ((Gr_a0 + (Min_a0 / 60)) < (9 + (59.2 / 60)))
            {
                double Gr_a0_2 = Gr_a0 + 360;
                double Xpp19 = Math.Round((-14.02 + 239.14 * Math.Cos((Math.PI / 180) * (((Gr_a0_2 + Min_a0 / 60 + 360) - (9 + (59.2 / 60)))))), 2);
                double Ypp19 = Math.Round((627.98 + 239.14 * Math.Sin((Math.PI / 180) * (((Gr_a0_2 + Min_a0 / 60 + 360) - (9 + (59.2 / 60)))))), 2);
                ReplaceWordStub2("{Xpp19}", Convert.ToString(Xpp19), ref wordDocument2);
                ReplaceWordStub2("{Ypp19}", Convert.ToString(Ypp19), ref wordDocument2);
                string Xpp19_txt = "+627.98 + 239.14 * cos(" + Gr_a0 + "° + 360°" + Min_a0 + "'-(9° 59.2')";
                string Ypp19_txt = "+627.98 + 239.14 * sin(" + Gr_a0 + "° + 360°" + Min_a0 + "'-(9° 59.2')";
                ReplaceWordStub2("{Xpp19_txt}", Convert.ToString(Xpp19_txt), ref wordDocument2);
                ReplaceWordStub2("{Ypp19_txt}", Convert.ToString(Ypp19_txt), ref wordDocument2);
                wordDocument2.SaveAs2(Environment.CurrentDirectory + @"\1 расчетка геодезия\2й Лист.doc");
               
            }
            else
            {
                double Ypp19 = Math.Round((627.98 + 239.14 * Math.Sin(((Math.PI / 180) * ((Gr_a0 + Min_a0 / 60) - (9 + (59.2 / 60)))))), 2);
                double Xpp19 = Math.Round((-14.02 + 239.14 * Math.Cos((((Math.PI / 180) * ((Gr_a0 + Min_a0 / 60) - (9 + (59.2 / 60))))))), 2);
                ReplaceWordStub2("{Xpp19}", Convert.ToString(Xpp19), ref wordDocument2);
                ReplaceWordStub2("{Ypp19}", Convert.ToString(Ypp19), ref wordDocument2);
                string Min_a0_txt = Convert.ToString(Min_a0);
                string Xpp19_txt = "-14.02 + 239.14 * cos(" + Gr_a0 + "°" + +Min_a0 + "' - 9° 59.2')";
                string Ypp19_txt = "-14.02 + 239.14 * sin(" + Gr_a0 + "°" + +Min_a0 + "' - 9° 59.2')";
                ReplaceWordStub2("{Xpp19_txt}", Convert.ToString(Xpp19_txt), ref wordDocument2);
                ReplaceWordStub2("{Ypp19_txt}", Convert.ToString(Ypp19_txt), ref wordDocument2);
            }

            ReplaceWordStub2("{zachetka_txt}", zachetka_txt, ref wordDocument2);
            ReplaceWordStub2("{NumJurnal}", NumJurnal, ref wordDocument2);
            ReplaceWordStub2("{a0_txt}", a0_txt, ref wordDocument2);
            ReplaceWordStub2("{a0_txt}", a0_txt, ref wordDocument2);
            ReplaceWordStub2("{group}", group, ref wordDocument2);
            ReplaceWordStub2("{group}", group, ref wordDocument2);

            wordDocument2.SaveAs2(Environment.CurrentDirectory + @"\1 расчетка геодезия\2й Лист.doc");
            wordApp2.Visible = true;


            //               а вот это лист 3
            // журнал измерения углов и длин линий теодолитного хода
            var wordApp3 = new Word.Application();
            wordApp3.Visible = false;
            var wordDocument3 = wordApp3.Documents.Open(TemplateShablon3);

            double pp8_kl_pp7_gr = 10;
            double pp8_kl_pp7_min = 15;
            string pp8_kl_pp7_txt = pp8_kl_pp7_gr + "° " + pp8_kl_pp7_min + "'";
            ReplaceWordStub3("{pp8_kl_pp7_txt}", pp8_kl_pp7_txt, ref wordDocument3);
            
            double pp8_kl_1_gr = 39;
            double pp8_kl_1_min = 16;
            string pp8_kl_1_txt = pp8_kl_1_gr + "° " + pp8_kl_1_min + "'";
            ReplaceWordStub3("{pp8_kl_1_txt}", pp8_kl_1_txt, ref wordDocument3);

            double pp8_kl_sred_gr = arifm.Sum(pp8_kl_pp7_gr, pp8_kl_pp7_min, pp8_kl_1_gr, pp8_kl_1_min, out pp8_kl_sred_gr, out double pp8_kl_sred_min);
            string pp8_kl_sred_txt = pp8_kl_sred_gr + "° " + pp8_kl_sred_min + "'";
            ReplaceWordStub3("{pp8_kl_sred_txt}", pp8_kl_sred_txt, ref wordDocument3);
            //Console.WriteLine("pp8_kl_sred = "+ pp8_kl_sred_txt);

            double pp8_kp_pp7_gr = 193;
            double pp8_kp_pp7_min = 43;
            string pp8_kp_pp7_txt = pp8_kp_pp7_gr + "° " + pp8_kp_pp7_min + "'";
            ReplaceWordStub3("{pp8_kp_pp7_txt}", pp8_kp_pp7_txt, ref wordDocument3);
            
            double pp8_kp_1_gr = 222;
            double pp8_kp_1_min = 43.5;
            string pp8_kp_1_txt = pp8_kp_1_gr + "° " + pp8_kp_1_min + "'";
            ReplaceWordStub3("{pp8_kp_1_txt}", pp8_kp_1_txt, ref wordDocument3);

            double pp8_kp_sred_gr = arifm.Sum(pp8_kp_pp7_gr, pp8_kp_pp7_min, pp8_kp_1_gr, pp8_kp_1_min, out pp8_kp_sred_gr, out double pp8_kp_sred_min);
            string pp8_kp_sred_txt = pp8_kp_sred_gr +"° " + pp8_kp_sred_min +"'";
            ReplaceWordStub3("{pp8_kp_sred_txt}", pp8_kp_sred_txt, ref wordDocument3);
            //Console.WriteLine("pp8_kp_sred ="+ pp8_kp_sred_txt);
            double pp8_Zh_gr = arifm.SrednZh(pp8_kl_sred_gr, pp8_kl_sred_min, pp8_kp_sred_gr, pp8_kp_sred_min, out pp8_Zh_gr, out double pp8_Zh_min);
            string pp8_Zh_txt = pp8_Zh_gr +"° " + pp8_Zh_min +"'";
            ReplaceWordStub3("{pp8_Zh_txt}", pp8_Zh_txt, ref wordDocument3);
            //Console.WriteLine("pp8_Zh= "+ pp8_Zh_txt);
            //
            double p1_kl_pp8_gr = 112;
            double p1_kl_pp8_min = 11;
            string p1_kl_pp8_txt = p1_kl_pp8_gr + "° " + p1_kl_pp8_min + "'";
            ReplaceWordStub3("{p1_kl_pp8_txt}", p1_kl_pp8_txt, ref wordDocument3);

            double p1_kl_2_gr = 61;
            double p1_kl_2_min = 13;
            string p1_kl_2_txt = p1_kl_2_gr + "° " + p1_kl_2_min + "'";
            ReplaceWordStub3("{p1_kl_2_txt}", p1_kl_2_txt, ref wordDocument3);
            double p1_kl_sred_gr = arifm.Sum(p1_kl_pp8_gr, p1_kl_pp8_min, p1_kl_2_gr, p1_kl_2_min, out p1_kl_sred_gr, out double p1_kl_sred_min);
            string p1_kl_sred_txt = p1_kl_sred_gr + "° " + p1_kl_sred_min + "'";
            ReplaceWordStub3("{p1_kl_sred_txt}", p1_kl_sred_txt, ref wordDocument3);
            //Console.WriteLine("p1_kl_sred ="+ p1_kl_sred_txt);

            double p1_kp_pp8_gr = 289;
            double p1_kp_pp8_min = 37;
            string p1_kp_pp8_txt = p1_kp_pp8_gr + "° " + p1_kp_pp8_min + "'";
            ReplaceWordStub3("{p1_kp_pp8_txt}", p1_kp_pp8_txt, ref wordDocument3);
            
            double p1_kp_2_gr = 238;
            double p1_kp_2_min = 38;
            string p1_kp_2_txt = p1_kp_2_gr + "° " + p1_kp_2_min + "'";
            ReplaceWordStub3("{p1_kp_2_txt}", p1_kp_2_txt, ref wordDocument3);

            double p1_kp_sred_gr = arifm.Sum(p1_kp_pp8_gr, p1_kp_pp8_min, p1_kp_2_gr, p1_kp_2_min, out p1_kp_sred_gr, out double p1_kp_sred_min);
            string p1_kp_sred_txt = p1_kp_sred_gr + "° " + p1_kp_sred_min + "'";
            ReplaceWordStub3("{p1_kp_sred_txt}", p1_kp_sred_txt, ref wordDocument3);
            //Console.WriteLine("p1_kp_sred ="+ p1_kp_sred_txt);
            double p1_Zh_gr = arifm.SrednZh(p1_kl_sred_gr, p1_kl_sred_min, p1_kp_sred_gr, p1_kp_sred_min, out p1_Zh_gr, out double p1_Zh_min);
            string p1_Zh_txt = p1_Zh_gr + "° " + p1_Zh_min + "'";
            ReplaceWordStub3("{p1_Zh_txt}", p1_Zh_txt, ref wordDocument3);
            //Console.WriteLine("p1_Zh ="+ p1_Zh_txt);
            //
            double p2_kl_1_gr = 215;
            double p2_kl_1_min = 54;
            string p2_kl_1_txt = p2_kl_1_gr + "° " + p2_kl_1_min + "'";
            ReplaceWordStub3("{p2_kl_1_txt}", p2_kl_1_txt, ref wordDocument3);
            
            double p2_kl_3_gr = 54;
            double p2_kl_3_min = 34.5;
            string p2_kl_3_txt = p2_kl_3_gr + "° " + p2_kl_3_min + "'";
            ReplaceWordStub3("{p2_kl_3_txt}", p2_kl_3_txt, ref wordDocument3);
            double p2_kl_sred_gr = arifm.Sum(p2_kl_1_gr, p2_kl_1_min, p2_kl_3_gr, p2_kl_3_min, out p2_kl_sred_gr, out double p2_kl_sred_min);
            string p2_kl_sred_txt = p2_kl_sred_gr + "° " + p2_kl_sred_min + "'";
            ReplaceWordStub3("{p2_kl_sred_txt}", p2_kl_sred_txt, ref wordDocument3);
            //Console.WriteLine("p2_kl_sred = "+p2_kl_sred_txt);

            double p2_kp_1_gr = 37;
            double p2_kp_1_min = 48;
            string p2_kp_1_txt = p2_kp_1_gr + "° " + p2_kp_1_min + "'";
            ReplaceWordStub3("{p2_kp_1_txt}", p2_kp_1_txt, ref wordDocument3);

            double p2_kp_3_gr = 236;
            double p2_kp_3_min = 27.5;
            string p2_kp_3_txt = p2_kp_3_gr + "° " + p2_kp_3_min + "'";
            ReplaceWordStub3("{p2_kp_3_txt}", p2_kp_3_txt, ref wordDocument3);
            double p2_kp_sred_gr = arifm.Sum(p2_kp_1_gr, p2_kp_1_min, p2_kp_3_gr, p2_kp_3_min, out p2_kp_sred_gr, out double p2_kp_sred_min);
            string p2_kp_sred_txt = p2_kp_sred_gr + "° " + p2_kp_sred_min + "'";
            ReplaceWordStub3("{p2_kp_sred_txt}", p2_kp_sred_txt, ref wordDocument3);
            //Console.WriteLine("p2_kp_sred = "+p2_kp_sred_txt);
            double p2_Zh_gr = arifm.SrednZh(p2_kl_sred_gr, p2_kl_sred_min, p2_kp_sred_gr, p2_kp_sred_min, out p2_Zh_gr, out double p2_Zh_min);
            string p2_Zh_txt = p2_Zh_gr + "° " + p2_Zh_min + "'";
            ReplaceWordStub3("{p2_Zh_txt}", p2_Zh_txt, ref wordDocument3);
            //Console.WriteLine("p2_Zh = "+ p2_Zh_txt);
            //
            double p3_kl_2_gr = 181;
            double p3_kl_2_min = 28;
            string p3_kl_2_txt = p3_kl_2_gr + "° " + p3_kl_2_min + "'";
            ReplaceWordStub3("{p3_kl_2_txt}", p3_kl_2_txt, ref wordDocument3);

            double p3_kl_pp19_gr = 102;
            double p3_kl_pp19_min = 25.5;
            string p3_kl_pp19_txt = p3_kl_pp19_gr + "° " + p3_kl_pp19_min + "'";
            ReplaceWordStub3("{p3_kl_pp19_txt}", p3_kl_pp19_txt, ref wordDocument3);
            double p3_kl_sred_gr = arifm.Sum(p3_kl_2_gr, p3_kl_2_min, p3_kl_pp19_gr, p3_kl_pp19_min, out p3_kl_sred_gr, out double p3_kl_sred_min);
            string p3_kl_sred_txt = p3_kl_sred_gr + "° " + p3_kl_sred_min + "'";
            ReplaceWordStub3("{p3_kl_sred_txt}", p3_kl_sred_txt, ref wordDocument3);
            //Console.WriteLine("p3_kl_sred = "+p3_kl_sred_txt);

            double p3_kp_2_gr = 3;
            double p3_kp_2_min = 21;
            string p3_kp_2_txt = p3_kp_2_gr + "° " + p3_kp_2_min + "'";
            ReplaceWordStub3("{p3_kp_2_txt}", p3_kp_2_txt, ref wordDocument3);

            double p3_kp_pp19_gr = 284;
            double p3_kp_pp19_min = 18;
            string p3_kp_pp19_txt = p3_kp_pp19_gr + "° " + p3_kp_pp19_min + "'";
            ReplaceWordStub3("{p3_kp_pp19_txt}", p3_kp_pp19_txt, ref wordDocument3);
            double p3_kp_sred_gr = arifm.Sum(p3_kp_2_gr, p3_kp_2_min, p3_kp_pp19_gr, p3_kp_pp19_min, out p3_kp_sred_gr, out double p3_kp_sred_min);
            string p3_kp_sred_txt = p3_kp_sred_gr + "° " + p3_kp_sred_min + "'";
            ReplaceWordStub3("{p3_kp_sred_txt}", p3_kp_sred_txt, ref wordDocument3);
            //Console.WriteLine("p3_kp_sred = "+ p3_kp_sred_txt);
            double p3_Zh_gr = arifm.SrednZh(p3_kl_sred_gr, p3_kl_sred_min, p3_kp_sred_gr, p3_kp_sred_min, out p3_Zh_gr, out double p3_Zh_min);
            string p3_Zh_txt = p3_Zh_gr + "° " + p3_Zh_min + "'";
            ReplaceWordStub3("{p3_Zh_txt}", p3_Zh_txt, ref wordDocument3);
            //Console.WriteLine("p3_Zh = "+ p3_Zh_txt);
            //
            double pp19_kl_3_gr = 321;
            double pp19_kl_3_min = 10.5;
            string pp19_kl_3_txt = pp19_kl_3_gr + "° " + pp19_kl_3_min + "'";
            ReplaceWordStub3("{pp19_kl_3_txt}", pp19_kl_3_txt, ref wordDocument3);

            double pp19_kl_pp20_gr = 54;
            double pp19_kl_pp20_min = 2;
            string pp19_kl_pp20_txt = pp19_kl_pp20_gr + "° " + pp19_kl_pp20_min + "'";
            ReplaceWordStub3("{pp19_kl_pp20_txt}", pp19_kl_pp20_txt, ref wordDocument3);
            double pp19_kl_sred_gr = arifm.Sum(pp19_kl_3_gr, pp19_kl_3_min, pp19_kl_pp20_gr, pp19_kl_pp20_min, out pp19_kl_sred_gr, out double pp19_kl_sred_min);
            string pp19_kl_sred_txt = pp19_kl_sred_gr + "° " + pp19_kl_sred_min + "'";
            ReplaceWordStub3("{pp19_kl_sred_txt}", pp19_kl_sred_txt, ref wordDocument3);
            //Console.WriteLine("pp_19_kl_sred = "+ pp19_kl_sred_txt);

            double pp19_kp_3_gr = 144;
            double pp19_kp_3_min = 19;
            string pp19_kp_3_txt = pp19_kp_3_gr + "° " + pp19_kp_3_min + "'";
            ReplaceWordStub3("{pp19_kp_3_txt}", pp19_kp_3_txt, ref wordDocument3);

            double pp19_kp_pp20_gr = 237;
            double pp19_kp_pp20_min = 11;
            string pp19_kp_pp20_txt = pp19_kp_pp20_gr + "° " + pp19_kp_pp20_min + "'";
            ReplaceWordStub3("{pp19_kp_pp20_txt}", pp19_kp_pp20_txt, ref wordDocument3);

            double pp19_kp_sred_gr = arifm.Sum(pp19_kp_3_gr, pp19_kp_3_min, pp19_kp_pp20_gr, pp19_kp_pp20_min, out pp19_kp_sred_gr, out double pp19_kp_sred_min);
            string pp19_kp_sred_txt = pp19_kp_sred_gr + "° " + pp19_kp_sred_min + "'";
            ReplaceWordStub3("{pp19_kp_sred_txt}", pp19_kp_sred_txt, ref wordDocument3);
            //Console.WriteLine("pp_19_kp_sred = "+ pp19_kp_sred_txt);
            double pp19_Zh_gr = arifm.SrednZh(pp19_kl_sred_gr, pp19_kl_sred_min, pp19_kp_sred_gr, pp19_kp_sred_min, out pp19_Zh_gr, out double pp19_Zh_min);
            string pp19_Zh_txt = pp19_Zh_gr + "° " + pp19_Zh_min + "'";
            ReplaceWordStub3("{pp19_Zh_txt}", pp19_Zh_txt, ref wordDocument3);
            wordDocument3.SaveAs2(Environment.CurrentDirectory + @"\1 расчетка геодезия\3й Лист.doc");
            wordApp3.Visible = true;
            //Console.WriteLine("pp19_Zh = "+ pp19_Zh_txt);
            //

            // Лист 7
            var wordApp7 = new Word.Application();
            var wordDocument7 = wordApp7.Documents.Open(TemplateShablon7);
            wordApp7.Visible = false;

            ReplaceWordStub7("{Xpp8}", Xpp8, ref wordDocument7);
            ReplaceWordStub7("{Ypp8}", Ypp8, ref wordDocument7);


            // c - correctred - исправленный
            double c_pp8_Zh_min = pp8_Zh_min - 0.3;
            double c_p1_Zh_min =p1_Zh_min-0.3;
            double c_p2_Zh_min = p2_Zh_min-0.3;
            double c_p3_Zh_min = p3_Zh_min - 0.3;
            double c_pp19_Zh_min = pp19_Zh_min - 0.3;
            // для расширения функционала в будущем оставлю заранее заготовку под изменения градусов
            // дабы потом не хуярить код 100500 раз
            double c_pp8_Zh_gr = pp8_Zh_gr;
            double c_p1_Zh_gr = p1_Zh_gr;
            double c_p2_Zh_gr = p2_Zh_gr;
            double c_p3_Zh_gr = p3_Zh_gr;
            double c_pp19_Zh_gr = pp19_Zh_gr;

            ReplaceWordStub7("{a0_txt}", a0_txt, ref wordDocument7);
            double a_pp8_gr =arifm.Dirik(Gr_a0,Min_a0,c_pp8_Zh_gr,c_pp8_Zh_min,out a_pp8_gr,out double a_pp8_min);
            string a_pp8_txt = a_pp8_gr + "° " + a_pp8_min + "'";
            ReplaceWordStub7("{a_pp8_txt}", a_pp8_txt, ref wordDocument7);

            double a_p1_gr =arifm.Dirik(a_pp8_gr,a_pp8_min,c_p1_Zh_gr,c_p1_Zh_min,out a_p1_gr,out double a_p1_min);
            string a_p1_txt = a_p1_gr + "° " + a_p1_min + "'";
            ReplaceWordStub7("{a_p1_txt}", a_p1_txt, ref wordDocument7);

            double a_p2_gr = arifm.Dirik(a_p1_gr, a_p1_min, c_p2_Zh_gr, c_p2_Zh_min, out a_p2_gr, out double a_p2_min);
            string a_p2_txt = a_p2_gr + "° " + a_p2_min + "'";
            ReplaceWordStub7("{a_p2_txt}", a_p2_txt, ref wordDocument7);

            double a_p3_gr = arifm.Dirik(a_p2_gr, a_p2_min, c_p3_Zh_gr, c_p3_Zh_min, out a_p3_gr, out double a_p3_min);
            string a_p3_txt = a_p3_gr + "° " + a_p3_min + "'";
            ReplaceWordStub7("{a_p3_txt}", a_p3_txt, ref wordDocument7);

            double a_pp19_gr = arifm.Dirik(a_p3_gr, a_p3_min, c_pp19_Zh_gr, c_pp19_Zh_min, out a_pp19_gr, out double a_pp19_min);
            string a_pp19_txt = a_pp19_gr + "° " + a_pp19_min + "'";
            ReplaceWordStub7("{a_pp19_txt}", a_pp19_txt, ref wordDocument7);

            double r_pp8_gr = arifm.Rumb(a_pp8_gr,out r_pp8_gr,out string d_pp8);
            string r8txt = r_pp8_gr + "°" + a_pp8_min + "'";
            ReplaceWordStub7("{d_pp8}", d_pp8, ref wordDocument7);
            ReplaceWordStub7("{r8txt}", r8txt, ref wordDocument7);

            double r_p1_gr = arifm.Rumb(a_p1_gr, out r_p1_gr, out string d_p1);
            string r1txt = r_p1_gr + "°" + a_p1_min + "'";
            ReplaceWordStub7("{d_p1}", d_p1, ref wordDocument7);
            ReplaceWordStub7("{r1txt}", r1txt, ref wordDocument7);

            double r_p2_gr = arifm.Rumb(a_p2_gr, out r_p2_gr, out string d_p2);
            string r2txt = r_p2_gr + "°" + a_p2_min + "'";
            ReplaceWordStub7("{d_p2}", d_p2, ref wordDocument7);
            ReplaceWordStub7("{r2txt}", r2txt, ref wordDocument7);

            double r_p3_gr = arifm.Rumb(a_p1_gr, out r_p3_gr, out string d_p3);
            string r3txt = r_p3_gr + "°" + a_p3_min + "'";
            ReplaceWordStub7("{d_p3}", d_p3, ref wordDocument7);
            ReplaceWordStub7("{r3txt}", r3txt, ref wordDocument7);

            double l_pp8 = 263.02;
            double l_p1 = 239.21;
            double l_p2 = 269.80;
            double l_p3 = 192.98;

            double x_pp8 =Math.Round((l_pp8*Math.Cos((Math.PI / 180)*(a_pp8_gr+a_pp8_min/60))),2) ;
            ReplaceWordStub7("{x_pp8}", Convert.ToString(arifm.nd_preobrazov2(x_pp8)), ref wordDocument7);
            double x_p1 = Math.Round((l_p1 * Math.Cos((Math.PI / 180) * (a_p1_gr + a_p1_min / 60))), 2);
            ReplaceWordStub7("{x_p1}", Convert.ToString(arifm.nd_preobrazov2(x_p1)), ref wordDocument7);
            double x_p2 = Math.Round((l_p2 * Math.Cos((Math.PI / 180) * (a_p2_gr + a_p2_min / 60))), 2);
            ReplaceWordStub7("{x_p2}", Convert.ToString(arifm.nd_preobrazov2(x_p2)), ref wordDocument7);
            double x_p3 = Math.Round((l_p3 * Math.Cos((Math.PI / 180) * (a_p3_gr + a_p3_min / 60))), 2);
            ReplaceWordStub7("{x_p3}", Convert.ToString(arifm.nd_preobrazov2(x_p3)), ref wordDocument7);

            double y_pp8 = Math.Round((l_pp8 * Math.Sin((Math.PI / 180) * (a_pp8_gr + a_pp8_min / 60))), 2);
            ReplaceWordStub7("{y_pp8}", Convert.ToString(arifm.nd_preobrazov2(y_pp8)), ref wordDocument7);
            double y_p1 = Math.Round((l_p1 * Math.Sin((Math.PI / 180) * (a_p1_gr + a_p1_min / 60))), 2);
            ReplaceWordStub7("{y_p1}", Convert.ToString(arifm.nd_preobrazov2(y_p1)), ref wordDocument7);
            double y_p2 = Math.Round((l_p2 * Math.Sin((Math.PI / 180) * (a_p2_gr + a_p2_min / 60))), 2);
            ReplaceWordStub7("{y_p2}", Convert.ToString(arifm.nd_preobrazov2(y_p2)), ref wordDocument7);
            double y_p3 = Math.Round((l_p3 * Math.Sin((Math.PI / 180) * (a_p3_gr + a_p3_min / 60))), 2);
            ReplaceWordStub7("{y_p3}", Convert.ToString(arifm.nd_preobrazov2(y_p3)), ref wordDocument7);

            double Sm_y = y_pp8 + y_p1 + y_p2 + y_p3;
            ReplaceWordStub7("{Sm_y}", Convert.ToString(Sm_y), ref wordDocument7);
            double Sm_x = x_pp8 + x_p1 + x_p2 + x_p3;
            ReplaceWordStub7("{Sm_x}", Convert.ToString(Sm_x), ref wordDocument7);
            double test228 =arifm.XYpp19(Gr_a0,Min_a0,out double Xp19,out double Yp19);
            double Xp8 = Convert.ToDouble(Xpp8);
            //Console.WriteLine("Warning Ypp19 = " + Yp19);
            //Console.WriteLine("Warning Xp19 = " + Xp19);

            double Nt_x = Xp19 - Xp8 ;
            ReplaceWordStub7("{Nt_x}", Convert.ToString(Nt_x), ref wordDocument7);

            double Yp8 = Convert.ToDouble(Ypp8);
            //Console.WriteLine("Warning Yp8 = " + Yp8);
            double Nt_y = Yp19 - Yp8;
            ReplaceWordStub7("{Nt_y}", Convert.ToString(Nt_y), ref wordDocument7);

            double f_x =Math.Round(Sm_x-Nt_x,2);
            double f_y =Math.Round(Sm_y - Nt_y,2);
            ReplaceWordStub7("{f_x}", Convert.ToString(f_x), ref wordDocument7);
            ReplaceWordStub7("{f_y}", Convert.ToString(f_y), ref wordDocument7);

            //Console.WriteLine("Xxxxxxxxxxxxxxxx");
            double all_fx = arifm.Discrepancy(Sm_x, Nt_x, out double xd1, out double xd2, out double xd3, out double xd4);
            ReplaceWordStub7("{xd1}", Convert.ToString(arifm.nd_preobrazov(xd1)), ref wordDocument7);
            ReplaceWordStub7("{xd2}", Convert.ToString(arifm.nd_preobrazov(xd2)), ref wordDocument7);
            ReplaceWordStub7("{xd3}", Convert.ToString(arifm.nd_preobrazov(xd3)), ref wordDocument7);
            ReplaceWordStub7("{xd4}", Convert.ToString(arifm.nd_preobrazov(xd4)), ref wordDocument7);

            //Console.WriteLine("YYyyyyyyyyyyyyyyyyyyyyyyy");
            double all_fy = arifm.Discrepancy(Sm_y,Nt_y, out double yd1, out double yd2, out double yd3, out double yd4);
            ReplaceWordStub7("{yd1}", Convert.ToString(arifm.nd_preobrazov(yd1)), ref wordDocument7);
            ReplaceWordStub7("{yd2}", Convert.ToString(arifm.nd_preobrazov(yd2)), ref wordDocument7);
            ReplaceWordStub7("{yd3}", Convert.ToString(arifm.nd_preobrazov(yd3)), ref wordDocument7);
            ReplaceWordStub7("{yd4}", Convert.ToString(arifm.nd_preobrazov(yd4)), ref wordDocument7);


            double c_xp8 = x_pp8 + xd1;
            ReplaceWordStub7("{c_xp8}", Convert.ToString(arifm.nd_preobrazov2(c_xp8)), ref wordDocument7);
            double c_xp1 = x_p1 + xd2;
            ReplaceWordStub7("{c_xp1}", Convert.ToString(arifm.nd_preobrazov2(c_xp1)), ref wordDocument7);
            double c_xp2 = x_p2 + xd3;
            ReplaceWordStub7("{c_xp2}", Convert.ToString(arifm.nd_preobrazov2(c_xp2)), ref wordDocument7);
            double c_xp3 =x_p3 + xd4;
            ReplaceWordStub7("{c_xp3}", Convert.ToString(arifm.nd_preobrazov2(c_xp3)), ref wordDocument7);

            double c_yp8 = y_pp8 + yd1;
            ReplaceWordStub7("{c_yp8}", Convert.ToString(arifm.nd_preobrazov2(c_yp8)), ref wordDocument7);
            double c_yp1 = y_p1 + yd2;
            ReplaceWordStub7("{c_yp1}", Convert.ToString(arifm.nd_preobrazov2(c_yp1)), ref wordDocument7);
            double c_yp2 = y_p2 + yd3;
            ReplaceWordStub7("{c_yp2}", Convert.ToString(arifm.nd_preobrazov2(c_yp2)), ref wordDocument7);
            double c_yp3 = y_p3 + yd4;
            ReplaceWordStub7("{c_yp3}", Convert.ToString(arifm.nd_preobrazov2(c_yp3)), ref wordDocument7);

            //coordinates points
            double px_p1 = Xp8 + c_xp8;
            ReplaceWordStub7("{px_p1}", Convert.ToString(arifm.nd_preobrazov2(px_p1)), ref wordDocument7);
            double px_p2 = px_p1 + c_xp1;
            ReplaceWordStub7("{px_p2}", Convert.ToString(arifm.nd_preobrazov2(px_p2)), ref wordDocument7);
            double px_p3 = px_p2 + c_xp2;
            ReplaceWordStub7("{px_p3}", Convert.ToString(arifm.nd_preobrazov2(px_p3)), ref wordDocument7);
            double px_p19 = px_p3 + c_xp3;
            ReplaceWordStub7("{px_p19}", Convert.ToString(arifm.nd_preobrazov2(px_p19)), ref wordDocument7);

            double py_p1 = Yp8 + c_yp8;
            ReplaceWordStub7("{py_p1}", Convert.ToString(arifm.nd_preobrazov2(py_p1)), ref wordDocument7);
            double py_p2 = py_p1 + c_yp1;
            ReplaceWordStub7("{py_p2}", Convert.ToString(arifm.nd_preobrazov2(py_p2)), ref wordDocument7);
            double py_p3 = py_p2 + c_yp2;
            ReplaceWordStub7("{py_p3}", Convert.ToString(arifm.nd_preobrazov2(py_p3)), ref wordDocument7);
            double py_p19 = py_p3 + c_yp3;
            ReplaceWordStub7("{py_p19}", Convert.ToString(arifm.nd_preobrazov2(py_p19)), ref wordDocument7);


            wordDocument7.SaveAs2(Environment.CurrentDirectory + @"\1 расчетка геодезия\7й Лист.docx");
            wordApp7.Visible = true;

        }
        private void ReplaceWordStub(string stubToReplace, string text, ref Word.Document wordDocument1)
        {
            var range = wordDocument1.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void ReplaceWordStub2(string stubToReplace, string text, ref Word.Document wordDocument2)
        {
            var range = wordDocument2.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void ReplaceWordStub3(string stubToReplace, string text, ref Word.Document wordDocument3)
        {
            var range = wordDocument3.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void ReplaceWordStub7(string stubToReplace, string text, ref Word.Document wordDocument7)
        {
            var range = wordDocument7.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }


        public void BoxNumZachetki_TextChanged(object sender, EventArgs e)
        {

        }

        public void BoxNumJurnal_TextChanged(object sender, EventArgs e)
        {

        }

        public void BoxGroop_TextChanged(object sender, EventArgs e)
        {

        }

        public void BoxFUO_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.SynchronizationContext.Current.Post(delegate { System.Windows.Forms.Application.Exit(); }, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BoxYear_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
