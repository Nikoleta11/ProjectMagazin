using Magazin.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 for console,2 for worm ");
            string start= Console.ReadLine();
            if (start =="2")
            {
               Form1 form1= new Form1();
                Application.Run(form1);
            }
            else
            {
                Display d = new Display();
                d.ShowMenu();
            }

        }
    }
}
