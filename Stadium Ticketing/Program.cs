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
        static void Main() 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmTicketing()); 
            //Application.Run(new UserReturnForm());
            //Application.Run(new AdminReturnForm1());            
        }
    }
}
