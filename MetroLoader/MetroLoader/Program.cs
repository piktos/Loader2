using System;
using System.Net;
using System.Windows.Forms;

namespace MetroLoader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // NOTE: on some servers with disabled TLS 1.0, connection attempt will throw an exception
            // The following line forces user to use either TLS 1.1 or TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
