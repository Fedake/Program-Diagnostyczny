using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Diag
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {

                MessageBox.Show("An exception occured. Program may not work properly.\nException content will be saved to file: log.txt");
                System.IO.File.WriteAllText(".\\log.txt", ex.ToString() + "\n" + ex.Message.ToString());
            }
        }
    }
}
