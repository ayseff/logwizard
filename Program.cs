using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace LogWizard
{
    static class Program
    {
        public static readonly settings_file sett = new settings_file("logwizard.txt");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log4net.Config.XmlConfigurator.Configure( new FileInfo("LogWizard.exe.config"));
            Application.Run(new Dummy());
        }
    }
}
