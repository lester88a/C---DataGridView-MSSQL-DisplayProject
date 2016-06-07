using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisPlay
{
    public partial class ConfForm : Form
    {
        //private variables
        private string manufacture;
        private string serverName;
        private string databaseName;

        public ConfForm()
        {
            InitializeComponent();
            
            lblStatus.Text = "Please wait several minutes \nwhile click Start button.";
           
        }
        
        //ok btn to get into the main form
        private void btnConfOk_Click(object sender, EventArgs e)
        {
            serverName = txtBoxServerName.Text;
            databaseName = txtBoxDBName.Text;
            manufacture = txtBoxManufacturer.Text;

            if (serverName != "" && databaseName != "" && manufacture !="")
            {
                mainForm mainForm = new mainForm(manufacture, serverName, databaseName);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("No data entered!");
            }
        }
        
        //X btn to exit the application
        private void btnConfCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
