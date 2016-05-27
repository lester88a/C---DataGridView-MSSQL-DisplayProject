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
        //delcare all objects/ variables
        private string connectionString;
        private DataViewManager dataViewManager;
        private DataSet dataSet;
        private SqlConnection connection;
        //private variables
        private string manufacture;
        private string serverName;
        private string databaseName;

        public ConfForm()
        {
            InitializeComponent();

            //database connection
            /**************************************************************************/
            try
            {
                //get all server name on network
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
                for (int i = 0; i < servers.Rows.Count; i++)
                {
                    if ((servers.Rows[i]["InstanceName"] as string) != null)
                    {
                        cboxSerName.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                    }
                    else
                    {
                        cboxSerName.Items.Add(servers.Rows[i]["ServerName"]);
                    } 
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            /**************************************************************************/
            lblStatus.Text = "Please wait several minutes while click Start button.";
           
        }
        
        //get all database from server
        private void btnSetServerName_Click(object sender, EventArgs e)
        {
            //assign server name
            serverName = (string)cboxSerName.SelectedItem;
            try
            {
                using (var con = new SqlConnection("Data Source=" + serverName + "; Integrated Security=True;"))
                {
                    con.Open();
                    DataTable databases = con.GetSchema("Databases");
                    foreach (DataRow database in databases.Rows)
                    {
                        string databaseName = database.Field<String>("database_name");
                        cboxDatabaseName.Items.Add(databaseName);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        //get all manufacture button
        private void btnSetDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                databaseName = (string)cboxDatabaseName.SelectedItem;

                //sign the connection string value
                connectionString = "Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";Integrated Security=True";
                //create a new sql connection and put he connection string on it
                connection = new SqlConnection(connectionString);
                connection.Open();
                //get Manufacture data
                getManufactureData();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.ToString());
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

        //ok btn to get into the main form
        private void btnConfOk_Click(object sender, EventArgs e)
        {

            //assign manufacture
            string mm = (string)cmboxManufacture.SelectedValue;

            if ((mm != "" || mm != null) && (serverName != "" || databaseName != null))
            {
                manufacture = mm;
                mainForm mainForm = new mainForm(manufacture, serverName, databaseName);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("NO data selected!");
            }
        }
        
        //X btn to exit the application
        private void btnConfCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
