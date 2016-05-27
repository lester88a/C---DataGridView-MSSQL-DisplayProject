using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DisPlay
{
    public partial class SplashForm : Form
    {
        //Delegate for cross thread call to close
        private delegate void CloseDelegate();
        //The type of form to be displayed as the splash screen.
        private static SplashForm splashForm;

        public SplashForm()
        {
            InitializeComponent();

        }

        static public void ShowSplashScreen()
        {
            // Make sure it is only launched once.

            if (splashForm != null)
                return;
            Thread thread = new Thread(new ThreadStart(SplashForm.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            splashForm = new SplashForm();
            Application.Run(splashForm);
        }

        static public void CloseForm()
        {
            try
            {
                splashForm.Invoke(new CloseDelegate(SplashForm.CloseFormInternal));
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        static private void CloseFormInternal()
        {
            splashForm.Close();
        }

        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        
    }
}
