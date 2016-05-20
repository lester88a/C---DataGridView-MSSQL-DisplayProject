using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
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
        private int pgSizeBKS = 11;
        private int pgSizeTech = 10;
        private int totalPage = 0;
        private int rowCount = 0;

        private Timer MyTimer;
        private Timer MyTimerBKS;
        private Timer MyTimerTech;

        private string currentDate;
        //digital clock variable
        private Timer _Timer = new Timer();

        public mainForm()
        {
            InitializeComponent();
            //auto full screen
            WindowState = FormWindowState.Maximized;
            //hide title bar
            this.FormBorderStyle = FormBorderStyle.None;
            //hide the last blank row
            this.grdRepair.AllowUserToAddRows = false;
            this.grdBKSum.AllowUserToAddRows = false;
            this.grdTechOutput.AllowUserToAddRows = false;
            //hide the row header
            this.grdRepair.RowHeadersVisible = false;
            this.grdBKSum.RowHeadersVisible = false;
            this.grdTechOutput.RowHeadersVisible = false;
            
            //change the label color
            lblTotalRecords.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalPages.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalRows.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalRecordsBKS.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalPagesBKS.ForeColor = Color.FromArgb(200, 180, 26);
            lblBKSTotalRows.ForeColor = Color.FromArgb(200, 180, 26);
            //change the font of gridview content
            this.grdRepair.DefaultCellStyle.Font = new Font("Tahoma", 27);
            this.grdRepair.DefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdRepair.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //change the font of gridview header
            this.grdRepair.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 24, FontStyle.Bold);
            this.grdRepair.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdRepair.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            this.grdRepair.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdRepair.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //center the header data of gridview
            this.grdRepair.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //center the content data of gridview
            this.grdRepair.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //change the font of grdBKS
            this.grdBKSum.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);
            this.grdBKSum.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdBKSum.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //change the font of gridview content
            this.grdBKSum.DefaultCellStyle.Font = new Font("Tahoma", 22);
            this.grdBKSum.DefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdBKSum.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //center the header data of grdBKSum gridview
            this.grdBKSum.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //center the content data of gridview
            this.grdBKSum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //change the font of grdTechOutput
            this.grdTechOutput.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            this.grdTechOutput.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdTechOutput.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //change the font of gridview content
            this.grdTechOutput.DefaultCellStyle.Font = new Font("Tahoma", 18);
            this.grdTechOutput.DefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdTechOutput.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //center the header data of grdTechOutput gridview
            this.grdTechOutput.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //center the content data of gridview
            this.grdTechOutput.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //unselect data at the beginning
            grdRepair.DefaultCellStyle.SelectionBackColor = grdRepair.DefaultCellStyle.BackColor;
            grdRepair.DefaultCellStyle.SelectionForeColor = grdRepair.DefaultCellStyle.ForeColor;

            grdBKSum.DefaultCellStyle.SelectionBackColor = grdBKSum.DefaultCellStyle.BackColor;
            grdBKSum.DefaultCellStyle.SelectionForeColor = grdBKSum.DefaultCellStyle.ForeColor;

            grdTechOutput.DefaultCellStyle.SelectionBackColor = grdTechOutput.DefaultCellStyle.BackColor;
            grdTechOutput.DefaultCellStyle.SelectionForeColor = grdTechOutput.DefaultCellStyle.ForeColor;

            //set up current date format
            currentDate = DateTime.Now.ToString("MM/dd/yyy");

            //get priority devices info
            GetPriorityDevicesData();
            //get back order summary info
            GetBackOrderSumData();
            //get tech repair output info
            GetTechRepairOutputData();

        }

        //form load

        private void mainForm_Load(object sender, EventArgs e)
        {
            _Timer.Interval = 1000;
            _Timer.Tick += new EventHandler(_Timer_Tick);
            _Timer.Start();
        }
        void _Timer_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm");
        }

        private void GetTechRepairOutputData()
        {
            getAllTechOutput(this.pgSizeTech * 1);
            MyTimerTech = new Timer();
            MyTimerTech.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_2); //get the next 15 data
            MyTimerTech.Start();
        }

        private void GetBackOrderSumData()
        {
            getBackOrderSum(this.pgSizeBKS * 1);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_2); //get the next 15 data
            MyTimerBKS.Start();
        }

        private void GetPriorityDevicesData()
        {
            //get first 20 data when app starts
            getData(this.pgSize * 1);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_40); //get the next 20 data
            MyTimer.Start();
        }

        //quit the application
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //cell formatting - change the font color when the aging is grater than 1 
        private void grdRepair_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdRepair.Rows)
                {
                    if ((int)row.Cells["AGING"].Value <= 1)
                    {
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
                    }
                    else
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.ToString());
            }
        }

        //cell formatting - change the font color when the aging is grater than 1 
        private void grdTechOutput_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdTechOutput.Rows)
                {
                    if ((int)row.Cells["Total"].Value <= 1)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        
                    }
                    else if ((int)row.Cells["Total"].Value >= 5)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Lime;
                    }
                    else
                    {
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
                    }
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.ToString());
            }
        }
        //calculate total pages for priority devices
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
        //calculate total pages for back order summ
        private void CalculateTotalPagesBKS()
        {
            rowCount = dataSet.Tables["tblRepair"].Rows.Count;
            totalPage = rowCount / pgSizeBKS;
            // if any row left after calculated pages, add one more page 
            if (rowCount % pgSizeBKS > 0)
            {
                totalPage += 1;
            }

        }

        //getAllTechOutput
        private void getAllTechOutput(int total)
        {
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
                string cmd = @"SELECT TOP " + total + @" FirstName+' '+LastName as Technician,count(FirstName + LastName) as Total
                            FROM tblRepair JOIN tblUser ON LastTechnician = UserName 
                            where (DateFinish >= '05/20/2016 07:00:00' AND DateFinish < '05/20/2016 20:00:00')  
                            and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 
                            AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') 
                            and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868' and DealerID != '7595') 
                            and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') 
                            GROUP BY FirstName, LastName ORDER BY Total DESC, LastName";

                //Fill the dataset with tblRepair, map the default table "Table" to "tblRepair"
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd, connection);

                //map
                dataAdapter1.TableMappings.Add("Table", "tblRepair");

                //fill the dataAdapter
                dataAdapter1.Fill(dataSet);

                //asign the detault view manage from dataset to dsView
                dataViewManager = dataSet.DefaultViewManager;

                //grid data binding
                grdTechOutput.DataSource = dataViewManager;
                grdTechOutput.DataMember = "tblRepair";

                /**************scrooling********************************************/
                //scrool down to buttom
                grdTechOutput.FirstDisplayedScrollingRowIndex = grdTechOutput.RowCount - 1;

                //close the connection
                connection.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        //getBackOrderSum
        private void getBackOrderSum(int total)
        {
            //totalrows variable
            int totalRows = TotalRowsBKS();
            //set total rows
            lblBKSTotalRows.Text = "Total Rds: " + totalRows.ToString();
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
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter("select TOP " + total + "RefNumber as Ref#, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868' and DealerID != '7595') and (Status = 'B') group by RefNumber, DateIn, LastTechnician order by AGING DESC", connection);

                //map
                dataAdapter1.TableMappings.Add("Table", "tblRepair");

                //fill the dataAdapter
                dataAdapter1.Fill(dataSet);

                //asign the detault view manage from dataset to dsView
                dataViewManager = dataSet.DefaultViewManager;

                //grid data binding
                
                grdBKSum.DataSource = dataViewManager;
                grdBKSum.DataMember = "tblRepair";

                /**************scrooling********************************************/
                //scrool down to buttom
                grdBKSum.FirstDisplayedScrollingRowIndex = grdBKSum.RowCount - 1;


                /**************pagenation********************************************/
                CalculateTotalPagesBKS();
                lblTotalPagesBKS.Text = "Page: " + totalPage.ToString();
                lblTotalRecordsBKS.Text = "On: " + rowCount.ToString() + " Rds.";
                lblAllAging.Text = getAllAGING();
                /**************Hide time output****************************************/
                //lblRepOutput.Text = GetAllTechs2PMorMore();
                //blbRepOut07.Text = GetAllTechs07To10AM();
                /*********************************************************************/
               
                //close the connection
                connection.Close();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
        
        //connection to db, get all data, assign the data to the datagridview
        private void getData(int total)
        {
            //totalrows variable
            int totalRows = TotalRows();
            //set total rows
            lblTotalRows.Text = "Total Records: " + totalRows.ToString();

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
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter("select TOP " + total + "RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868' and DealerID != '7595') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ", connection);
                
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
        //get the total rows for priority devices
        public int TotalRows()
        {
            string stmt = @"SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
                            BEGIN TRANSACTION;
                            select COUNT(*) from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B')";
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

        //get the total rows for back order summary
        public int TotalRowsBKS()
        {
            string stmt = @"SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
                            BEGIN TRANSACTION;
                            select COUNT(*) from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' AND (SVP != 'KCC' AND SVP != 'TCC') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status = 'B')";
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
        public string GetAllTechs07To10AM()
        {
            string stmt = @"SELECT +FirstName+' '+LastName,count(FirstName + LastName) as Total
                            FROM tblRepair JOIN tblUser ON LastTechnician = UserName 
                            where (DateFinish >= '" + currentDate + " 07:00:00' AND DateFinish < '" + currentDate + " 10:00:00')  and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868' and DealerID != '7595') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') GROUP BY FirstName, LastName ORDER BY Total DESC, LastName";

            string resultAging = "07:00AM - 10:00AM\n";
            using (SqlConnection thisConnection = new SqlConnection("Data Source=ESDB;Initial Catalog=EasyDB;Integrated Security=True"))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    SqlDataReader reader = cmdCount.ExecuteReader();
                    while (reader.Read())
                    {
                        resultAging += "" + reader[0].ToString() + "     \t\t\t\t";
                        resultAging += reader[1].ToString() + "     \n";
                    }
                }
            }
            return resultAging;
        }
        public string GetAllTechs2PMorMore()
        {
            string stmt = @"SELECT +FirstName+' '+LastName,count(FirstName + LastName) as Total
                            FROM tblRepair JOIN tblUser ON LastTechnician = UserName 
                            where (DateFinish >= '" + currentDate + " 14:00:00' AND DateFinish < '" + currentDate + " 20:00:00')  and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868' and DealerID != '7595') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') GROUP BY FirstName, LastName ORDER BY Total DESC, LastName";
            
            string resultAging = "14:00PM - 20:00PM\n";
            using (SqlConnection thisConnection = new SqlConnection("Data Source=ESDB;Initial Catalog=EasyDB;Integrated Security=True"))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    SqlDataReader reader = cmdCount.ExecuteReader();
                    while (reader.Read())
                    {
                        resultAging += "" + reader[0].ToString() + "     \t\t\t\t";
                        resultAging += reader[1].ToString() + "     \n";
                    }
                }
            }
            return resultAging;
        }

        //get string of AGING
        public string getAllAGING()
        {
            string stmt = @"select FirstSet.Day1, SecondSet.Day2, ThirdSet.Day3, Four.Day4, Five.Day5, Six.Day6, Seven.Day7 from 
	                        (select COUNT(Day1.AGING) as Day1 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') 
		                        and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day1 
		                        where Day1.AGING =1) as FirstSet 
                        inner join 
	                        (select COUNT(Day2.AGING) as Day2 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') 
		                        and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day2 
		                        where Day2.AGING =2) as SecondSet on FirstSet.Day1 != SecondSet.Day2
                        inner join 
	                        (select COUNT(Day3.AGING) as Day3 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') 
		                        and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day3 
		                        where Day3.AGING =3) as ThirdSet on FirstSet.Day1 != SecondSet.Day2
                        inner join 
	                        (select COUNT(Day4.AGING) as Day4 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') 
		                        and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day4 
		                        where Day4.AGING =4) as Four on FirstSet.Day1 != SecondSet.Day2
                        inner join 
	                        (select COUNT(Day5.AGING) as Day5 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') 
		                        and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day5 
		                        where Day5.AGING =5) as Five on FirstSet.Day1 != SecondSet.Day2
                        inner join 
	                        (select COUNT(Day6.AGING) as Day6 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') 
		                        and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day6 
		                        where Day6.AGING =6) as Six on FirstSet.Day1 != SecondSet.Day2
                        inner join 
	                        (select COUNT(Day7.AGING) as Day7 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') 
		                        and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day7 
		                        where Day7.AGING >=7) as Seven on FirstSet.Day1 != SecondSet.Day2";
            string resultAging = "";
            using (SqlConnection thisConnection = new SqlConnection("Data Source=ESDB;Initial Catalog=EasyDB;Integrated Security=True"))
            {
                using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                {
                    thisConnection.Open();
                    SqlDataReader reader = cmdCount.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            resultAging += "Days:     1      2     3     4     5     6     7" + "+" + "\n";
                            resultAging += "QTY:    " + reader[0].ToString() + "     ";
                            resultAging += reader[1].ToString() + "     ";
                            resultAging += reader[2].ToString() + "     ";
                            resultAging += reader[3].ToString() + "     ";
                            resultAging += reader[4].ToString() + "     ";
                            resultAging += reader[5].ToString() + "     ";
                            resultAging += reader[6].ToString() + "     ";
                        }
                    }
                    else
                    {
                        resultAging += "Days:     1      2     3     4     5     6     7" + "+" + "\n";
                        resultAging += "QTY:    No Data Found.";
                    }
                }
            }
            return resultAging;
        }
        //MyTimer_Tick_Get_Tech_Top_1----------------------Tech
        private void MyTimer_Tick_Get_Tech_Top_1(object sender, EventArgs e)
        {
            MyTimerTech.Stop();
            getAllTechOutput(this.pgSizeTech*1);
            MyTimerTech = new Timer();
            MyTimerTech.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_2);
            MyTimerTech.Start();
        }
        //MyTimer_Tick_Get_Tech_Top_2----------------------Tech
        private void MyTimer_Tick_Get_Tech_Top_2(object sender, EventArgs e)
        {
            MyTimerTech.Stop();
            getAllTechOutput(this.pgSizeTech * 2);
            MyTimerTech = new Timer();
            MyTimerTech.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeTech * 2)
            {
                MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_3);
            }
            else
            {
                MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_1);
            }
            MyTimerTech.Start();
        }
        //MyTimer_Tick_Get_Tech_Top_3----------------------Tech
        private void MyTimer_Tick_Get_Tech_Top_3(object sender, EventArgs e)
        {
            MyTimerTech.Stop();
            getAllTechOutput(this.pgSizeTech * 3);
            MyTimerTech = new Timer();
            MyTimerTech.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeTech * 3)
            {
                MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_1);
            }
            else
            {
                MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_1);
            }
            MyTimerTech.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_1----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_1(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_2);
            MyTimerBKS.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_2----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_2(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS*2);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeBKS * 2)
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_3);
            }
            else
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            MyTimerBKS.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_3----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_3(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS * 3);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeBKS * 3)
            {
                //MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_60);
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_4);
            }
            else
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            MyTimerBKS.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_4----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_4(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS * 4);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeBKS * 4)
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_5);
            }
            else
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            MyTimerBKS.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_5----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_5(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS * 5);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeBKS * 5)
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_6);
            }
            else
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            MyTimerBKS.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_6----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_6(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS * 6);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeBKS * 6)
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            else
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            MyTimerBKS.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_7----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_7(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS * 7);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeBKS * 7)
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_8);
            }
            else
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            MyTimerBKS.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_8----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_8(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS * 8);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeBKS * 8)
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_9);
            }
            else
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            MyTimerBKS.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_8----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_9(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS * 9);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeBKS * 9)
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_10);
            }
            else
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            MyTimerBKS.Start();
        }
        //MyTimer_Tick_Get_BKS_Top_8----------------------BKS
        private void MyTimer_Tick_Get_BKS_Top_10(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();
            getBackOrderSum(this.pgSizeBKS * 10);
            MyTimerBKS = new Timer();
            MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRowsBKS() > this.pgSizeBKS * 10)
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            else
            {
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
            }
            MyTimerBKS.Start();
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
            if (TotalRows() > 40)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_60);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }

        //MyTimer_Tick_Get_Top_60
        private void MyTimer_Tick_Get_Top_60(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(60);
            getBackOrderSum(60);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 60)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_80);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
            MyTimer.Start();
        }
        //MyTimer_Tick_Get_Top_80
        private void MyTimer_Tick_Get_Top_80(object sender, EventArgs e)
        {
            MyTimer.Stop();
            getData(80);
            MyTimer = new Timer();
            MyTimer.Interval = (1 * 5 * 1000); // 5 seconds
            if (TotalRows() > 80)
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_100);
            }
            else
            {
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
            }
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
