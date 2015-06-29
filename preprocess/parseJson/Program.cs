using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parseJson
{
    static class Program
    {

        private static MainForm _form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _form = new MainForm();
            Application.Run(_form);
            Application.ApplicationExit += Application_ApplicationExit;
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            _form.IsAppClosing = true;
        }
    }
}
