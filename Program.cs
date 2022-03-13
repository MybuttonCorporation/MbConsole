using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codebutton
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            bool skip = false;
            bool dev = false;
            string argall = "";
            //bool config = true; //I'll work on this later

            foreach (string arg in args)
            {
                if (arg == "-skip") skip = true;
                if (arg == "-devCmd") dev = true;
                if (arg == "--dev") dev = true;
                argall = argall + " " + arg;
            }
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(dev, skip, argall));










        }
    }
}
