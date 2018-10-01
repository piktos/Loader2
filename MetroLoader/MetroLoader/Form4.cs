using MetroFramework.Forms;
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

// 284, 261

namespace MetroLoader
{
    public partial class Form4 : MetroForm
    {
        bool admin;
        bool premium;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://localhost/group.php?username=" + Properties.Settings.Default.Username);
            metroButton1.Enabled = false;
            metroRadioButton2.Visible = false;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.DocumentText.Contains("4"))
            {
                admin = true;
                metroButton1.Enabled = true;
                metroLabel1.Text = "User status: Admin";
                metroRadioButton2.Visible = true;
            }
            else if (webBrowser1.DocumentText.Contains("8"))
            {
                premium = true;
                metroButton1.Enabled = true;
                metroLabel1.Text = "User status: Premium";
            }

            Thread.Sleep(1000);
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (admin == true)
            {
                metroRadioButton2.Visible = true;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true) // Premium
            {
                WebClient wb = new WebClient();
                wb.Headers.Add("User-Agent", "CustomStringHere");
                System.IO.Directory.CreateDirectory("C:\\Temp\\");
                wb.DownloadFile("http://localhost/dlls/premium.dll", "C:\\Temp\\cheat.dll");
            }

            if (metroRadioButton2.Checked == true) // Developer
            {
                WebClient wb = new WebClient();
                wb.Headers.Add("User-Agent", "CustomStringHere");
                System.IO.Directory.CreateDirectory("C:\\Temp\\");
                wb.DownloadFile("http://localhost/dlls/admin.dll", "C:\\Temp\\cheat.dll");
            }

            this.Hide();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}

//-----------------------------------------------------
// Coded by /id/Thaisen! Free loader source
// https://github.com/ThaisenPM/Cheat-Loader-CSGO-2.0
// Note to the person using this, removing this
// text is in violation of the license you agreed
// to by downloading. Only you can see this so what
// does it matter anyways.
// Copyright © ThaisenPM 2017
// Licensed under a MIT license
// Read the terms of the license here
// https://github.com/ThaisenPM/Cheat-Loader-CSGO-2.0/blob/master/LICENSE
//-----------------------------------------------------
