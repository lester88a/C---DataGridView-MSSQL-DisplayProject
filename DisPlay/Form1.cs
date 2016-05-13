using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DisPlay
{
    public partial class mainForm : Form
    {
        //delcare all objects/ variables
        private string connectionString;
        private DataViewManager dataViewManager;
        private DataSet dataSet;
        private SqlConnection connection;

        private int pgSize = 20;
        private int totalPage = 0;
        private int rowCount = 0;
        private int rowCountForNext = 0;

        private Timer MyTimer;

        public mainForm()
        {
            InitializeComponent();
            //auto full screen
            WindowState = FormWindowState.Maximized;

            //change the header font colors
            lblHeader.ForeColor = Color.FromArgb(200, 180, 26);
            //change the label color
            lblTotalRecords.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalPages.ForeColor = Color.FromArgb(200, 180, 26);
            //change the font of gridview content
            this.grdRepair.DefaultCellStyle.Font = new Font("Tahoma", 24);
            this.grdRepair.DefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdRepair.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //change the font of gridview header
            this.grdRepair.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 20, FontStyle.Bold);
            this.grdRepair.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdRepair.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            this.grdRepair.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdRepair.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //center the header data of gridview
            this.grdRepair.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //center the content data of gridview
            this.grdRepair.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            

            //get first 20 data when app starts
            getData(20);

            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_40); //get the next 20 data
            MyTimer.Start();
            
        }

        //calculate total pages
        private void CalculateTotalPages()
        {
            rowCount = dataSet.Tables["tblRepair"].Rows.Count;
            totalPage = rowCount / pgSize;
            // if any row left after calculated pages, add one more page 
            if (rowCount % pgSize > 0)
            {
                totalPage += 1;
            }
                
        }
        
        //connection to db, get all data, assign the data to the datagridview
        private void getData(int total)
        {
            //set total rows
            lblTotalRows.Text = "Total Records: " + TotalRows().ToString();

            //sign the connection string value
            connectionString = "Data Source=ESDB;Initial Catalog=EasyDB;Integrated Security=True";

            try
            {
                /*************************************************************************************
                ************************************************************************************/
                //create a new sql connection and put he connection string on it
                connection = new SqlConnection(connectionString);
                connection.Open();

                //create the DataSet
                dataSet = new DataSet("priDev");
                
                //Fill the dataset with tblRepair, map the default table "Table" to "tblRepair"
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter("select TOP " + total + "RefNumber as Ref#, convert(date,DateIn) as DateIn,FuturetelLocation, DATEDIFF(day, DateIn, convert(date, GETDATE())) as Aging, LastTechnician from tblRepair where DateIn between '20160310' and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' AND (SVP != 'KCC' AND SVP != 'TCC') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'I') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by DateIn, FuturetelLocation, Aging DESC", connection);
                
                //map
                dataAdapter1.TableMappings.Add("Table", "tblRepair");

                //fill the dataAdapter
                dataAdapter1.Fill(dataSet);

                //asign the detault view manage from dataset to dsView
                dataViewManager = dataSet.DefaultViewManager;

                //grid data binding
                grdRepair.DataSource = dataViewManager;
                grdRepair.DataMember = "tblRepair";

                /**************scrooling********************************************/
                //scrool down to buttom
                grdRepair.FirstDisplayedScrollingRowIndex = grdRepair.RowCount - 1;

                
                /**************pagenation********************************************/
                CalculateTotalPages();
                lblTotalPages.Text = "Page: "+totalPage.ToString();
                lblTotalRecords.Text = "On: "+rowCount.ToString() + " Records.";

                //close the connection
                connection.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
        //get the total rows
        public int TotalRows()
        {
            string stmt = "select COUNT(*) from tblRepair where DateIn between '20160310' and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' AND (SVP != 'KCC' AND SVP != 'TCC') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'I')";
            int count = 0;

            using (SqlConnection thisConnection = new SqlConnection("Data Source=ESDB;Initial Catalog=EasyDB;Integrated Security=True"))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }

        //MyTimer_Tick_Get_Top_20
        private void MyTimer_Tick_Get_Top_20(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(20);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_40);
            MyTimer.Start();
        }

        //MyTimer_Tick_Get_Top_40
        private void MyTimer_Tick_Get_Top_40(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(40);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_60);
            MyTimer.Start();
        }

        //MyTimer_Tick_Get_Top_60
        private void MyTimer_Tick_Get_Top_60(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(60);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_80);
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_80
        private void MyTimer_Tick_Get_Top_80(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(80);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_100);
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_100
        private void MyTimer_Tick_Get_Top_100(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(100);
            //rowCount = dataSet.Tables["tblRepair"].Rows.Count;
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 100)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_120);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_120(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(120);
            
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 120)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_140);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_140(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(140);
            
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 140)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_160);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_160(object sender, EventArgs e)
        {
            
            MyTimer.Stop();
            getData(160);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 160)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_180);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_180(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(180);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 180)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_200);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_200(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(200);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 200)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_220);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_220(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(220);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 220)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_240);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_240(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(240);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 240)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_260);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_260(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(260);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 260)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_280);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_280(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(280);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 280)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_300);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_300(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(300);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 300)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_320);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_320(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(320);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 320)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_340);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_340(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(340);
            
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 340)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_360);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_360(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(360);
            
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 360)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_380);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_380(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(380);
            
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 380)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_400);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_400(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(400);
            
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 400)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_420);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_120
        private void MyTimer_Tick_Get_Top_420(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(420);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            MyTimer.Start();
        }

    }
}
