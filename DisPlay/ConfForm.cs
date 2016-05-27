using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisPlay
{
    public partial class ConfForm : Form
    {
        //delcare all objects/ variables
        private string connectionString;
        private DataViewManager dataViewManager;
        private DataSet dataSet;
        private SqlConnection connection;
        //private variables
        private string manufacture;

        public ConfForm()
        {
            InitializeComponent();

            //database connection
            /**************************************************************************/
            try
            {
                //sign the connection string value
                connectionString = "Data Source=ESDB-TST;Initial Catalog=EasyReportDB;Integrated Security=True";
                //create a new sql connection and put he connection string on it
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            /**************************************************************************/

            lblStatus.Text = "Please wait several minutes while click Ok button.";
            //get Manufacture data
            getManufactureData();
            
        }

        //cancel btn to return the main form
        private void btnConfCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //ok btn to get into the main form
        private void btnConfOk_Click(object sender, EventArgs e)
        {
            
            //assign values
            string mm = (string)cmboxManufacture.SelectedValue;
            if (mm != "" || mm != null)
            {
                manufacture = mm;
                //lblStatus.Text = "Status: Manufacture " + manufacture + "selected, application is loadding data.\nplease wait several minutes.";
                mainForm mainForm = new mainForm(manufacture);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("NO data selected!");
            }
        }
        //get manufacture info
        private void getManufactureData()
        {
            try
            {
                //create the DataSet
                dataSet = new DataSet("priDev");
                string cmd = @"select Manufacturer from tblManufacturer";
                //Fill the dataset with tblRepair, map the default table "Table" to "tblRepair"
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd, connection);
                dataAdapter1.SelectCommand.CommandTimeout = 0;
                //map
                dataAdapter1.TableMappings.Add("Table", "tblRepair");

                //fill the dataAdapter
                dataAdapter1.Fill(dataSet);

                //asign the detault view manage from dataset to dsView
                dataViewManager = dataSet.DefaultViewManager;

                //combobox
                cmboxManufacture.DataSource = dataViewManager;
                cmboxManufacture.DisplayMember = "tblRepair.Manufacturer";
                cmboxManufacture.ValueMember = "tblRepair.Manufacturer";

                //close the connection
                connection.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            
        }
        
    }
}
