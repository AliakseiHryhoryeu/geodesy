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
    class Program
    {
        public static void Main(string[] args)
        {
            var arifm = new Arifm();
            Form1 fm1 = new Form1();
            fm1.ShowDialog();
        }
    }
}
