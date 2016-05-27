﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisPlay
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
            //Application.Run(new mainForm());

            //first run conf form
            SplashForm.ShowSplashScreen();
            ConfForm confForm = new ConfForm(); //this takes ages
            SplashForm.CloseForm();
            Application.Run(confForm);

            ////second run mian form
            //SplashForm.ShowSplashScreen();
            //mainForm mainForm = new mainForm(); //this takes ages
            //SplashForm.CloseForm();
            //Application.Run(mainForm);
        }
    }
}
