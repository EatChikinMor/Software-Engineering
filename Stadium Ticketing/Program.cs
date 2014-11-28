using System;
using System.Windows.Forms;

namespace Stadium_Ticketing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() //Some edit here.
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmTicketing());            
        }
    }
}
