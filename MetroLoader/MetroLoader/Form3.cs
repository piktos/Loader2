using ManualMapInjection.Injection;
using MetroFramework.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MetroLoader
{
    public partial class Form2 : MetroForm
    {

        bool csgof;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Starting injection";
            Thread.Sleep(200);

            var name = "csgo";
            var target = Process.GetProcessesByName(name).FirstOrDefault();

            if (target == null)
            {
                csgof = false;
            }
            else if (target != null)
            {
                //MessageBox.Show("Error: CS:GO is open!");
                //Application.Restart();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (csgof == false)
            {
                label1.Text = "Waiting for CSGO.exe";

                var name = "csgo";
                var target = Process.GetProcessesByName(name).FirstOrDefault();

                if (target != null)
                {
                    var path = "C:\\Temp\\cheat.dll";
                    var file = File.ReadAllBytes(path);

                    if (!File.Exists(path))
                    {
                        label1.Text = "DLL not found";
                        return;
                    }

                    //Thread.Sleep(10000);
                    var injector = new ManualMapInjector(target) { AsyncInjection = true };
                    label1.Text = $"hmodule = 0x{injector.Inject(file).ToInt64():x8}";
                    label1.Text = "Successfully injected";
                    timer1.Stop();
                    timer2.Start();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            File.Delete("C:\\Temp\\cheat.dll");
            Application.Exit();
            timer2.Stop();
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
