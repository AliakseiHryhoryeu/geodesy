using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace ConsoleApp2
{
    public class Arifm
    {

        public static double MyRadian(double x)
        {
            double MyRadian = ((x / 180D) * Math.PI);
            return MyRadian;
        }

        public double abs_v2(double x)
        {
            x = x - 2 * x;
            return x;
        }
        public double Sum(double gr1,double min1,double gr2,double min2,out double gradusi,out double minuti)
        {
            if(((gr1+min1/60)-(gr2+min2/60))<0)
            {
                if((min1-min2)<0)
                {
                    gradusi = gr1 + 360 - gr2;
                    gradusi = gradusi - 1;
                    minuti = min1 + 60 - min2;
                }
                else
                {
                    gradusi = gr1 + 360 - gr2;
                    minuti = min1- min2;
                }
            }
            else
            {
                if ((min1 - min2) < 0)
                {
                    gradusi = gr1- gr2;
                    gradusi = gradusi - 1;
                    minuti = min1 + 60 - min2;
                }
                else
                {
                    gradusi = gr1- gr2;
                    minuti = min1 - min2;
                }
            }
            minuti = Math.Round(minuti, 1);
            return gradusi;
        }
        public double IzvlechMinut(double a,out double x,out double f)
        {                
                int full =(int)a;
                double drop = a - full;
                f = drop*60;
                x = full;
            return f;
        }
        public double SrednZh(double gr1, double min1, double gr2, double min2,out double gradusi,out double minuti)
        {
            gradusi = (gr1 + gr2) / 2;
            minuti = ((min1) + (min2))/2;
            if (minuti>60)
            {
                minuti = minuti - 60;
                gradusi = gradusi + 1;
            }
            minuti = Math.Round(minuti, 1);
            return gradusi;
        }
        public double Sumir(double gr1, double min1, double gr2, double min2, out double gradusi, out double minuti)
        {
            gradusi = gr1 + gr2;
            if (min1 + min2 >= 60)
            {
                minuti = min1 + min2 + 60;
                gradusi = gradusi + 1;
            }
            else
            {
                minuti = min1 + min2;
            }
            return gradusi;
        }
        public double Rumb(double gr,out double rumb, out string direction)  // direction это направление 
            {                                                               // если шо
            if (gr>0 && gr<90)
            {
                rumb = gr;
                direction = "СВ:";
            }
            else if (gr>90&& gr <180)
            {
                rumb = 180 - gr;
                direction = "ЮВ:";
            }
            else if (gr>180&& gr<270)
            {
                rumb = gr-180;
                direction = "ЮЗ:";
            }
            else if (gr>270 && gr<360)
            {
                rumb = 360-gr;
                direction = "СЗ:";
            }
            else
            {
                rumb = 0.00;
                direction = "Ошибка сам делай";
            }
            return rumb;
        }
        
        public double Dirik(double gr1,double min1,double gr2,double min2,out double gradusi,out double minuti)
        {
            if (((gr1 + min1 / 60) + 180 - (gr2 + min2 / 60)) <= 0) 
            {
                if(min1<min2)
                {
                    min1 = min1 + 60;
                    gr1 = gr1 - 1;
                    gradusi =gr1+360+180-gr2;
                    minuti = min1 - min2;
                }
                else
                {
                    gradusi = gr1 + 360 + 180 - gr2;
                    minuti = min1 - min2;
                }
            }
            else if (((gr1 + min1 / 60) + 180 - (gr2 + min2 / 60)) >= 360)
            {
                if (min1 < min2)
                {
                    min1 = min1 + 60;
                    gr1 = gr1 - 1;
                    gradusi = gr1 +180-360 - gr2;
                    minuti = min1 - min2;
                }
                else
                {
                    gradusi = gr1 + 180-360 - gr2;
                    minuti = min1 - min2;
                }
            }
            else
            {
                if (min1 < min2)
                {
                    min1 = min1 + 60;
                    gr1 = gr1 - 1;
                    gradusi = gr1 + 180 - gr2;
                    minuti = min1 - min2;
                }
                else
                {
                    gradusi = gr1 + 180 - gr2;
                    minuti = min1 - min2;
                }
            }
            minuti = Math.Round(minuti, 1);
            return gradusi;

        }

        public double XYpp19(double Gr_a0,double Min_a0, out double Xpp19,out double Ypp19)
        {
            if ((Gr_a0 + (Min_a0 / 60)) < (9 + (59.2 / 60)))
            {
                double Gr_a0_2 = Gr_a0 + 360;
                Ypp19 = Math.Round((627.98 + 239.14 * Math.Sin((Math.PI / 180) * (((Gr_a0_2 + (Min_a0 / 60) + 360) - (9 + (59.2 / 60)))))), 2);
                Xpp19 = Math.Round((-14.02 + 239.14 * Math.Cos((Math.PI / 180) * (((Gr_a0_2 + (Min_a0 / 60) + 360) - (9 + (59.2 / 60)))))), 2);
                return Xpp19;

            }
            else
            {
                Ypp19 = Math.Round((627.98 + 239.14 * Math.Sin(((Math.PI / 180) * ((Gr_a0 + Min_a0 / 60) - (9 + (59.2 / 60)))))), 2);
                Xpp19 = Math.Round((-14.02 + 239.14 * Math.Cos(((Math.PI / 180) * ((Gr_a0 + Min_a0 / 60) - (9 + (59.2 / 60)))))), 2);
                string Min_a0_txt = Convert.ToString(Min_a0);
                return Xpp19;
            }
        }

        public double Discrepancy(double Sm_x,double sum_theor,out double nd1, out double nd2, out double nd3, out double nd4)
        {
            double f = Sm_x - sum_theor;
       //     Console.WriteLine("Sm_x = "+Sm_x);
       //     Console.WriteLine("Sum_theor = " + sum_theor);

            f = Math.Round(f,2);
            nd1 = 0;
            nd2 = 0;
            nd3 = 0;
            nd4 = 0;
            if (f>0)
            {
          //      Console.WriteLine("f > 0");
                double sm_nd = 0;
                double f1 = Math.Round(f, 2);
             //   Console.WriteLine("f = " + f);
             //   Console.WriteLine("f1 = " + f1);
              //  Console.WriteLine("sm_nd = " + sm_nd);
             //   Console.WriteLine("f1 = " + f1);
                while (f1 >= sm_nd)
                {
                    if (nd1<=nd3)
                    {
                        nd1 = nd1 + 0.01;
                    }
                    else if(nd3<=nd2)
                    {
                        nd3 = nd3 + 0.01;
                    }
                    else if (nd2<=nd4)
                    {
                        nd2 = nd2 + 0.01;
                    }
                    else
                    {
                        nd4 = nd4 + 0.01;
                    }
                    sm_nd = sm_nd + 0.01;
                }
                Arifm arifm = new Arifm();
                nd1 = arifm.abs_v2(nd1);
                nd2 = arifm.abs_v2(nd2);
                nd3 = arifm.abs_v2(nd3);
                nd4 = arifm.abs_v2(nd4);



                //  nd1 = Math.Abs(nd1);
                //  nd2 = Math.Abs(nd2);
                // nd3 = Math.Abs(nd3);
                // nd4 = Math.Abs(nd4);
            }
            else if (f<0)
            {
                double sm_nd = 0;
              //  Console.WriteLine("f < 0");
                double f1 = Math.Round(f, 2);
               // Console.WriteLine("f = " + f);
               // Console.WriteLine("f1 = " + f1);
                //Console.WriteLine("sm_nd = " + sm_nd);
               // Console.WriteLine("f1 = " + f1);
                while (f1 <= sm_nd)
                {
                    sm_nd = sm_nd - 0.01;
                    if (nd1 >= nd3)
                    {
                        nd1 = nd1 - 0.01;
                    }
                    else if (nd3 >= nd2)
                    {
                        nd3 = nd3 - 0.01;
                    }
                    else if (nd2 >= nd4)
                    {
                        nd2 = nd2 - 0.01;
                    }
                    else
                    {
                        nd4 = nd4 - 0.01;
                    }
                }
                nd1 = Math.Abs(nd1);
                nd2 = Math.Abs(nd2);
                nd3 = Math.Abs(nd3);
                nd4 = Math.Abs(nd4);
            }
            //Console.WriteLine("nd1 = " + nd1);
            //Console.WriteLine("nd2 = " + nd2);
            //Console.WriteLine("nd3 = " + nd3);
            //Console.WriteLine("nd4 = " + nd4);

            return f;
        }
        public string nd_preobrazov(double nd)
        {
            if (nd > 0)
            {
                nd = nd * 100;
                string result = "+" + nd;
                return result;
            }
            else
            {
                nd = nd * 100;
                string result = Convert.ToString(nd);
                return result;
            }
        }
        public string nd_preobrazov22222(double nd)
        {
            if (nd > 0)
            {
                string result = "+" + nd;
                return result;
            }
            else
            {
                string result = Convert.ToString(nd);
                return result;
            }
        }

        public string nd_preobrazov2(double nd)
        {
            bool Minus;
            if (nd<0)
            {
               Minus = true;
            }
            else
            {
                Minus = false;
            }


            nd = Math.Abs(nd);

            string x = Convert.ToString(nd);
            string lastDingit_str;
            string lastDingit_str2;
            int Nzero;
            int whole = (int)nd;
            double fractional = nd - whole;

            int fractional_int = Convert.ToInt32(fractional * 100);
            int lastDigit = (int)(fractional_int % 10);
            lastDingit_str= Convert.ToString(lastDigit);

            int fractional_int2 = (int)(fractional * 10);
            int lastDigit2 = (fractional_int2 % 10);
            lastDingit_str2 = Convert.ToString(lastDigit2);

            double mfract = Math.Round(fractional, 5);
            if (mfract==0.1) 
            {
                lastDigit = 0;
                lastDigit2 = 1;
                Nzero = 1;
            }


            if (lastDigit == 0 && lastDigit2 == 0) 
            {
                Nzero = 2;
            }
            else if(lastDigit==0)
            {
                Nzero = 1;
            }
            else
            {
                Nzero = 0;
            }


            if (Nzero==2)
            {
                x =x+",00";
            }
            else if (Nzero==1)
            {
                x = x + "0";
            }
            else
            {
                x = Convert.ToString(nd);
            }


            if (Minus==true)
            {
                x = "-" + x;
            }
            else if(Minus == false)
            {
                x = "+" + x;
            }
            return x;
        }
    }
}




