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
        //public variables
        public string manufacture;
        public int pgSizePD;
        public int pgSizeBKS;
        public int pgSizeTech;

        public ConfForm()
        {
            InitializeComponent();

            //database connection
            /**************************************************************************/
            try
            {
                //sign the connection string value
                connectionString = "Data Source=ESDB;Initial Catalog=EasyDB;Integrated Security=True";
                //create a new sql connection and put he connection string on it
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            /**************************************************************************/

            //get Manufacture data
            getManufactureData();
        }

        //cancel btn to return the main form
        private void btnConfCancel_Click(object sender, EventArgs e)
        {
            var frm = new mainForm();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }

        //get manufacture info
        private void getManufactureData()
        {
            cmboxPriorityDevices.SelectedIndex = 5;
            cmboxBKS.SelectedIndex = 1;
            cmboxTech.SelectedIndex = 0;
            try
            {
                //create the DataSet
                dataSet = new DataSet("priDev");
                string cmd = @"select Manufacturer from tblRepair group by Manufacturer having count(distinct(Manufacturer)) >=1 and Manufacturer !=''";
                //Fill the dataset with tblRepair, map the default table "Table" to "tblRepair"
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd, connection);

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

        private string setManufacture()
        {
            //assign values
            var manufactures = cmboxPriorityDevices.SelectedValue.ToString();
            foreach (var item in manufactures)
            {
                manufacture = item.ToString();
            }
            return manufacture;
        }
    }
}
