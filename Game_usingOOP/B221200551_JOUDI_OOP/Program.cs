// Student Name : Joudi Tafran
// Student Number : B221200551
// Major : Information System Engineering
// Group : B

using System;
using System.Windows.Forms;

namespace B221200551_JOUDI_OOP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPage());
        }
    }
}
