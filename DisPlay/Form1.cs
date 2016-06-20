using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisPlay
{
    public partial class mainForm : Form
    {
        //private variables
        private string manufacture;
        private string serverName;
        private string databaseName;

        //delcare all objects/ variables
        private string connectionString;
        private DataViewManager dataViewManager;
        private DataViewManager dataViewManager2;
        private DataSet dataSet;
        private DataSet dataSet2;
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

        public mainForm(string manuf, string serverNa, string databaseNa)
        {
            InitializeComponent();
            this.Text = manuf;
            //get manufacture, serverName and databaseName from user input
            this.manufacture = manuf;
            this.serverName = serverNa;
            this.databaseName = databaseNa;
            //call get manufacturer logo method
            GetManufacturerLogo();
            //auto full screen
            WindowState = FormWindowState.Maximized;
            //hide title bar
            this.FormBorderStyle = FormBorderStyle.None;
            //hide the last blank row
            this.grdRepair.AllowUserToAddRows = false;
            this.grdBKSum.AllowUserToAddRows = false;
            this.grdTechOutput.AllowUserToAddRows = false;
            this.grdTechOutput2.AllowUserToAddRows = false;
            //hide the row header
            this.grdRepair.RowHeadersVisible = false;
            this.grdBKSum.RowHeadersVisible = false;
            this.grdTechOutput.RowHeadersVisible = false;
            this.grdTechOutput2.RowHeadersVisible = false;

            //change the label color
            lblOverAllAgingTotal.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalRecords.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalPages.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalRows.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalRecordsBKS.ForeColor = Color.FromArgb(200, 180, 26);
            lblTotalPagesBKS.ForeColor = Color.FromArgb(200, 180, 26);
            lblBKSTotalRows.ForeColor = Color.FromArgb(200, 180, 26);
            lblTechOutTotalRows.ForeColor = Color.FromArgb(200, 180, 26);
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

            //change the font of grdTechOutput
            this.grdTechOutput2.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            this.grdTechOutput2.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdTechOutput2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //change the font of gridview content
            this.grdTechOutput2.DefaultCellStyle.Font = new Font("Tahoma", 18);
            this.grdTechOutput2.DefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
            this.grdTechOutput2.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            //center the header data of grdTechOutput gridview
            this.grdTechOutput2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //center the content data of gridview
            this.grdTechOutput2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //unselect data at the beginning
            grdRepair.DefaultCellStyle.SelectionBackColor = grdRepair.DefaultCellStyle.BackColor;
            grdRepair.DefaultCellStyle.SelectionForeColor = grdRepair.DefaultCellStyle.ForeColor;

            grdBKSum.DefaultCellStyle.SelectionBackColor = grdBKSum.DefaultCellStyle.BackColor;
            grdBKSum.DefaultCellStyle.SelectionForeColor = grdBKSum.DefaultCellStyle.ForeColor;

            grdTechOutput.DefaultCellStyle.SelectionBackColor = grdTechOutput.DefaultCellStyle.BackColor;
            grdTechOutput.DefaultCellStyle.SelectionForeColor = grdTechOutput.DefaultCellStyle.ForeColor;

            grdTechOutput2.DefaultCellStyle.SelectionBackColor = grdTechOutput.DefaultCellStyle.BackColor;
            grdTechOutput2.DefaultCellStyle.SelectionForeColor = grdTechOutput.DefaultCellStyle.ForeColor;

            //set up current date format
            currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            
            //sign the connection string value
            connectionString = "Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";Integrated Security=True";
            bool exists = IsTabelExists();
            if (exists == true)
            {
                //get priority devices info
                GetPriorityDevicesData();
                //get back order summary info
                GetBackOrderSumData();
                //get tech repair output info
                GetTechRepairOutputData();


            }

        }

        private void GetManufacturerLogo()
        {
            //set the manufacture logo
            if (manufacture.ToUpper().Contains("SAMSUNG"))
            {
                pictureBox.Image = Properties.Resources.samsung;
            }
            else if (manufacture.ToUpper() == "LG")
            {
                pictureBox.Image = Properties.Resources.lg;
            }
            else if (manufacture.ToUpper() == "MOTOROLA")
            {
                pictureBox.Image = Properties.Resources.motorola;
            }
            else if (manufacture.ToUpper() == "HUAWEI")
            {
                pictureBox.Image = Properties.Resources.huawei;
            }
            else if (manufacture.ToUpper() == "HTC")
            {
                pictureBox.Image = Properties.Resources.htc;
            }
            else if (manufacture.ToUpper() == "BLACKBERRY")
            {
                pictureBox.Image = Properties.Resources.blackberry;
            }
            else
            {
                lblManufacture.Text = manufacture.ToUpper();
            }
        }

        //form load
        //setup digital clock
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
            bool exists = IsTabelExists();
            if (exists == true)
            {
                getAllTechOutput();
                MyTimerTech = new Timer();
                MyTimerTech.Interval = (5 * 60 * 1000); // 5 minutes
                MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_2); //get the next 15 data
                MyTimerTech.Start();
            }
        }

        private void GetBackOrderSumData()
        {
            bool exists = IsTabelExists();
            if (exists == true)
            {
                getBackOrderSum(0,pgSizeBKS);
                MyTimerBKS = new Timer();
                MyTimerBKS.Interval = (1 * 5 * 1000); // 5 seconds
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_2s); //get the next 15 data
                MyTimerBKS.Start();
            }
        }
        //MyTimer_Tick_Get_BKS_Top_2s----------------------BKS
        private async void MyTimer_Tick_Get_BKS_Top_2s(object sender, EventArgs e)
        {
            MyTimerBKS.Stop();

            for (int i = 0; i <= (TotalRowsBKS() / pgSizeBKS); i++)
            {
                MyTimerBKS.Stop();
                getBackOrderSum(i * pgSizeBKS, pgSizeBKS);
                await Task.Delay(10000);

                MyTimerBKS = new Timer();
                MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
                MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_2s);
                MyTimerBKS.Start(); 
            }
            

        }

       
        private void GetPriorityDevicesData()
        {
            bool exists = IsTabelExists();
            if (exists == true)
            {
                //get first 20 data when app starts
                getData(0,this.pgSize * 1);
                MyTimer = new Timer();
                MyTimer.Interval = (1 * 10 * 1000); // 5 seconds
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_40s); //get the next 20 data
                MyTimer.Start();
            }
        }
        //MyTimer_Tick_Get_Top_40s
        private async void MyTimer_Tick_Get_Top_40s(object sender, EventArgs e)
        {
            MyTimer.Stop();
            for (int i = 0; i <= (TotalRows() / pgSize); i++)
            {
                MyTimer.Stop();
                getData(pgSize * i, pgSize);
                await Task.Delay(10000);
                MyTimer = new Timer();
                MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
                MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_40s);
                MyTimer.Start();
            }
        }


        //method for verify the table exists
        private bool IsTabelExists()
        {
            bool exists;

            try
            {
                int count;
                using (SqlConnection thisConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmdCount = new SqlCommand("select case when exists((select * from "+databaseName+".information_schema.tables where table_name = 'tblRepair')) then 1 else 0 end", thisConnection))
                    {
                        thisConnection.Open();
                        cmdCount.CommandTimeout = 0;
                        count = (int)cmdCount.ExecuteScalar();
                    }
                }
                
                if (count == 1)
                {
                    exists = true;
                }
                else
                {
                    exists = false;
                }
            }
            catch
            {
                exists = false;
            }

            return exists;
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
                //MessageBox.Show(er.ToString());
            }
        }

        //cell formatting - change the font color when the aging is grater than 1 
        private void grdTechOutput_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdTechOutput.Rows)
                {
                    if ((int)row.Cells["Total"].Value <= 5)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        
                    }
                    else if ((int)row.Cells["Total"].Value >= 10)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Lime;
                    }
                    else
                    {
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(200, 180, 26);
                    }
                }
                foreach (DataGridViewRow row in grdTechOutput2.Rows)
                {
                    if ((int)row.Cells["Total"].Value <= 5)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;

                    }
                    else if ((int)row.Cells["Total"].Value >= 10)
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

                //MessageBox.Show(er.ToString());
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
        private void getAllTechOutput()
        {
            currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            bool exists = IsTabelExists();
            if (exists == true)
            {
                try
                {
                    /*************************************************************************************
                    ************************************************************************************/
                    //create a new sql connection and put he connection string on it
                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    //create the DataSet
                    dataSet = new DataSet("priDev");
                    dataSet2 = new DataSet("priDev2");
                    string cmd = @"
                            SELECT LastTechnician as Technician,count(LastTechnician) as Total
                            FROM tblRepair  
                            where (DateFinish >= '" + currentDate + @" 07:00:00' AND DateFinish < '" + currentDate + @" 22:00:00')  
                             and Manufacturer = '" + manufacture + @"' and Warranty = 1 
                            AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') 
                            and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '7595') 
                            and (Status != 'X') 
                            GROUP BY LastTechnician ORDER BY Total DESC, LastTechnician
                            OFFSET 0 ROWS
                            FETCH NEXT 10 ROWS ONLY";
                    string cmd2 = @"
                            SELECT LastTechnician as Technician,count(LastTechnician) as Total
                            FROM tblRepair  
                            where (DateFinish >= '" + currentDate + @" 07:00:00' AND DateFinish < '" + currentDate + @" 22:00:00')  
                             and Manufacturer = '" + manufacture + @"' and Warranty = 1 
                            AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') 
                            and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '7595') 
                            and (Status != 'X') 
                            GROUP BY LastTechnician ORDER BY Total DESC, LastTechnician
                            OFFSET 10 ROWS
                            FETCH NEXT 10 ROWS ONLY";

                    //Fill the dataset with tblRepair, map the default table "Table" to "tblRepair"
                    SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd, connection);
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter(cmd2, connection);
                    //set CommandTimeout to 0 in order to solve the SqlException: Timeout expired issues
                    dataAdapter1.SelectCommand.CommandTimeout = 0;
                    dataAdapter2.SelectCommand.CommandTimeout = 0;
                    //map
                    dataAdapter1.TableMappings.Add("Table", "tblRepair");
                    dataAdapter2.TableMappings.Add("Table", "tblRepair");

                    //fill the dataAdapter
                    dataAdapter1.Fill(dataSet);
                    dataAdapter2.Fill(dataSet2);

                    //asign the detault view manage from dataset to dsView
                    dataViewManager = dataSet.DefaultViewManager;
                    dataViewManager2 = dataSet2.DefaultViewManager;

                    //grid data binding
                    grdTechOutput.DataSource = dataViewManager;
                    grdTechOutput.DataMember = "tblRepair";

                    grdTechOutput2.DataSource = dataViewManager2;
                    grdTechOutput2.DataMember = "tblRepair";

                    /**************pagenation********************************************/

                    lblTechOutTotalRows.Text = "Total Output: " + TotalRowsTech().ToString();

                    /**************scrooling********************************************/
                    //scrool down to buttom
                    //grdTechOutput.FirstDisplayedScrollingRowIndex = grdTechOutput.RowCount - 1;

                    //close the connection
                    connection.Close();

                    //refresh the winform
                    this.Refresh();
                }
                catch (Exception er)
                {
                    //MessageBox.Show(er.ToString());
                }
            }
        }
        
        //getBackOrderSum
        private void getBackOrderSum(int offsetRows, int fetchNextRows)
        {
            bool exists = IsTabelExists();
            if (exists == true)
            {
                try
                {
                    //totalrows variable
                    int totalRows = TotalRowsBKS();
                    //set total rows
                    lblBKSTotalRows.Text = "Total Rds: " + totalRows.ToString();
                    /*************************************************************************************
                    ************************************************************************************/
                    //create a new sql connection and put he connection string on it
                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    //create the DataSet
                    dataSet = new DataSet("priDev");
                    string cmd = @"select RefNumber as Ref#, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, 
                             LastTechnician as Technician from tblRepair 
                             where DateIn between convert(date,DATEADD(day,-60,GETDATE())) 
                             and convert(date, GETDATE())  and Manufacturer = 'LG' and Warranty = 1
                            AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') 
							and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' 
							and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '7595') 
                            and (Status = 'B') group by RefNumber, DateIn, LastTechnician  order by RefNumber ASC,  AGING DESC
                            OFFSET "+offsetRows+@" ROWS
							FETCH NEXT "+fetchNextRows+@" ROWS ONLY";
                    //Fill the dataset with tblRepair, map the default table "Table" to "tblRepair"
                    SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd, connection);
                    //set CommandTimeout to 0
                    dataAdapter1.SelectCommand.CommandTimeout = 0;
                    //map
                    dataAdapter1.TableMappings.Add("Table", "tblRepair");

                    //fill the dataAdapter
                    dataAdapter1.Fill(dataSet);

                    //asign the detault view manage from dataset to dsView
                    dataViewManager = dataSet.DefaultViewManager;

                    //grid data binding

                    grdBKSum.DataSource = dataViewManager;
                    grdBKSum.DataMember = "tblRepair";

                    ///**************scrooling********************************************/
                    ////scrool down to buttom
                    //if (totalRows > 10)
                    //{
                    //    grdBKSum.FirstDisplayedScrollingRowIndex = grdBKSum.RowCount - 1;
                    //}

                    /**************pagenation********************************************/
                    //CalculateTotalPagesBKS();
                    lblTotalPagesBKS.Text = "Page: " + (offsetRows / pgSizeBKS +1);
                    lblTotalRecordsBKS.Text = "On: " + (offsetRows + fetchNextRows) + " Records.";
                    getAllAGING();

                    //close the connection
                    connection.Close();

                    //refresh the winform
                    this.Refresh();
                }
                catch (Exception er)
                {
                    //MessageBox.Show(er.ToString());
                }
            }
        }
        
        //connection to db, get all data, assign the data to the datagridview
        private void getData(int offsetRows, int fetchNextRows)
        {
            bool exists = IsTabelExists();
            if (exists == true)
            {
                try
                {
                    //totalrows variable
                    int totalRows = TotalRows();
                    //set total rows
                    lblTotalRows.Text = "Total Records: " + totalRows.ToString();

                    /*************************************************************************************
                    ************************************************************************************/
                    //create a new sql connection and put he connection string on it
                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    //create the DataSet
                    dataSet = new DataSet("priDev");
                    string cmd = @"select RefNumber as Ref#, 
                    convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, 
                    DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair 
                    where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE())  
                    and Manufacturer = '" + manufacture + @"' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') 
                    and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' 
                    and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' 
                    and DealerID != '7595') and (Status != 'X' and Status != 'C'and Status != 'E' 
                    and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, 
                    FuturetelLocation order by LastTechnician ASC, RefNumber ASC, AGING DESC, DateIn 
                    OFFSET " + offsetRows + @" ROWS
					FETCH NEXT " + fetchNextRows + @" ROWS ONLY";
                    //Fill the dataset with tblRepair, map the default table "Table" to "tblRepair"
                    SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd, connection);
                    //set CommandTimeout to 0
                    dataAdapter1.SelectCommand.CommandTimeout = 0;
                    //map
                    dataAdapter1.TableMappings.Add("Table", "tblRepair");

                    //fill the dataAdapter
                    dataAdapter1.Fill(dataSet);

                    //asign the detault view manage from dataset to dsView
                    dataViewManager = dataSet.DefaultViewManager;

                    //grid data binding
                    grdRepair.DataSource = dataViewManager;
                    grdRepair.DataMember = "tblRepair";

                    ///**************scrooling********************************************/
                    ////scrool down to buttom
                    //if (totalRows > 10)
                    //{
                    //    grdRepair.FirstDisplayedScrollingRowIndex = grdRepair.RowCount - 1;
                    //}

                    /**************pagenation********************************************/
                    CalculateTotalPages();
                    lblTotalPages.Text = "Page: " + (offsetRows / pgSize +1);
                    lblTotalRecords.Text = "On: " + (offsetRows + fetchNextRows) + " Records.";

                    //close the connection
                    connection.Close();

                    //refresh the winform
                    this.Refresh();
                    
                }
                catch (Exception er)
                {
                    //MessageBox.Show(er.ToString());
                }
            }
        }
        //get the total rows for priority devices
        public int TotalRows()
        {
            try
            {
                bool exists = IsTabelExists();
                if (exists == true)
                {
                    string stmt = @"SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
                            BEGIN TRANSACTION;
                            select COUNT(*) from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) 
                            and convert(date, GETDATE())  and Manufacturer = '" + manufacture + @"' and Warranty = 1 
                            AND (SVP != 'KCC' AND SVP != 'TCC') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' 
                            and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' 
                            and DealerID != '7551') and (Status != 'X' 
                            and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B')";
                    int count = 0;

                    using (SqlConnection thisConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                        {
                            thisConnection.Open();
                            cmdCount.CommandTimeout = 0;
                            count = (int)cmdCount.ExecuteScalar();
                        }
                    }
                    return count;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        //get the total rows for back order summary
        public int TotalRowsBKS()
        {
            try
            {
                bool exists = IsTabelExists();
                if (exists == true)
                {
                    string stmt = @"SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
                            BEGIN TRANSACTION;
                            select COUNT(*) from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) 
                            and convert(date, GETDATE())  and Manufacturer = 'LG' and Warranty = 1 
							AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') 
                            and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' 
                            and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '7595') 
							and (Status = 'B')";
                    int count = 0;

                    using (SqlConnection thisConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                        {
                            thisConnection.Open();
                            cmdCount.CommandTimeout = 0;
                            count = (int)cmdCount.ExecuteScalar();
                        }
                    }
                    return count;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
        //get the total rows for tech output
        public int TotalRowsTech()
        {
            currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                bool exists = IsTabelExists();
                if (exists == true)
                {
                    string stmt = @"SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
                            BEGIN TRANSACTION;
                            SELECT count (*) FROM tblRepair  
                            where (DateFinish >= '" + currentDate + @" 07:00:00' AND DateFinish < '" + currentDate + @" 22:00:00')  
                             and Manufacturer = '" + manufacture + @"' and Warranty = 1 
                            AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') 
                            and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '7595') 
                            and (Status != 'X')";
                    int count = 0;

                    using (SqlConnection thisConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                        {
                            thisConnection.Open();
                            cmdCount.CommandTimeout = 0;
                            count = (int)cmdCount.ExecuteScalar();
                        }
                    }
                    return count;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
        //get string of AGING
        public void getAllAGING()
        {
            try
            {
                bool exists = IsTabelExists();
                if (exists == true)
                {
                    string stmt = @"select ZeroSet.Day0, FirstSet.Day1, SecondSet.Day2, ThirdSet.Day3, Four.Day4, Five.Day5, Six.Day6, Seven.Day7 from 
	                        (select COUNT(Day1.AGING) as Day1 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, 
                                DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) 
                                 and Manufacturer = '" + manufacture + @"' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551') 
		                        and (Status != 'X' and Status != 'C') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day1 
		                        where Day1.AGING =1) as FirstSet 
                        inner join 
	                        (select COUNT(Day2.AGING) as Day2 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, 
                                DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) 
                                 and Manufacturer = '" + manufacture + @"' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551') 
		                        and (Status != 'X' and Status != 'C') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day2 
		                        where Day2.AGING =2) as SecondSet on FirstSet.Day1 >= SecondSet.Day2 or FirstSet.Day1 <= SecondSet.Day2
                        inner join 
	                        (select COUNT(Day3.AGING) as Day3 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, 
                                DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) 
                                 and Manufacturer = '" + manufacture + @"' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551') 
		                        and (Status != 'X' and Status != 'C') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day3 
		                        where Day3.AGING =3) as ThirdSet on FirstSet.Day1 >= SecondSet.Day2 or FirstSet.Day1 <= SecondSet.Day2
                        inner join 
	                        (select COUNT(Day4.AGING) as Day4 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, 
                                DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) 
                                 and Manufacturer = '" + manufacture + @"' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551') 
		                        and (Status != 'X' and Status != 'C') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day4 
		                        where Day4.AGING =4) as Four on FirstSet.Day1 >= SecondSet.Day2 or FirstSet.Day1 <= SecondSet.Day2
                        inner join 
	                        (select COUNT(Day5.AGING) as Day5 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, 
                                DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) 
                                 and Manufacturer = '" + manufacture + @"' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551') 
		                        and (Status != 'X' and Status != 'C') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day5 
		                        where Day5.AGING =5) as Five on FirstSet.Day1 >= SecondSet.Day2 or FirstSet.Day1 <= SecondSet.Day2
                        inner join 
	                        (select COUNT(Day6.AGING) as Day6 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, 
                                DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) 
                                 and Manufacturer = '" + manufacture + @"' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551') 
		                        and (Status != 'X' and Status != 'C') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day6 
		                        where Day6.AGING =6) as Six on FirstSet.Day1 >= SecondSet.Day2 or FirstSet.Day1 <= SecondSet.Day2
                        inner join 
	                        (select COUNT(Day7.AGING) as Day7 from 
		                        (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, 
                                DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician 
		                        from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) 
                                 and Manufacturer = '" + manufacture + @"' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551') 
		                        and (Status != 'X' and Status != 'C') 
		                        group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn ) Day7 
		                        where Day7.AGING >=7) as Seven on FirstSet.Day1 >= SecondSet.Day2 or FirstSet.Day1 <= SecondSet.Day2
						inner join
						(select  count(*) as Day0 from tblRepair 
								where  DateIn >= convert(varchar(10),GETDATE(),120) and Manufacturer = '" + manufacture + @"' and Warranty = 1 
		                        AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551') 
		                        and (Status != 'X' and Status != 'C')) as ZeroSet on ZeroSet.Day0 >= ZeroSet.Day0";

                    using (SqlConnection thisConnection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                        {
                            thisConnection.Open();
                            cmdCount.CommandTimeout = 0;
                            SqlDataReader reader = cmdCount.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    label0.Text = reader[0].ToString();
                                    lblAg1.Text = reader[1].ToString();
                                    lblAg2.Text = reader[2].ToString();
                                    lblAg3.Text = reader[3].ToString();
                                    lblAg4.Text = reader[4].ToString();
                                    lblAg5.Text = reader[5].ToString();
                                    lblAg6.Text = reader[6].ToString();
                                    lblAg7.Text = reader[7].ToString();
                                    lblOverAllAgingTotal.Text = "Total: "+(Int32.Parse(label0.Text)
                                        + Int32.Parse(lblAg1.Text)
                                        + Int32.Parse(lblAg2.Text)
                                        + Int32.Parse(lblAg3.Text)
                                        + Int32.Parse(lblAg4.Text)
                                        + Int32.Parse(lblAg5.Text)
                                        + Int32.Parse(lblAg6.Text)
                                        + Int32.Parse(lblAg7.Text)).ToString();
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
            
        }
        //MyTimer_Tick_Get_Tech_Top_1----------------------Tech
        private void MyTimer_Tick_Get_Tech_Top_1(object sender, EventArgs e)
        {
            MyTimerTech.Stop();
            getAllTechOutput();
            MyTimerTech = new Timer();
            MyTimerTech.Interval = (5 * 60 * 1000); // 5 minutes
            MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_2);
            MyTimerTech.Start();
        }
        //MyTimer_Tick_Get_Tech_Top_2----------------------Tech
        private void MyTimer_Tick_Get_Tech_Top_2(object sender, EventArgs e)
        {
            MyTimerTech.Stop();
            getAllTechOutput();
            MyTimerTech = new Timer();
            MyTimerTech.Interval = (5 * 60 * 1000); // 5 minutes
            if (TotalRowsBKS() > this.pgSizeTech * 2)
            {
                MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_1);
            }
            else
            {
                MyTimerTech.Tick += new EventHandler(MyTimer_Tick_Get_Tech_Top_1);
            }
            MyTimerTech.Start();
        }
       
        ////MyTimer_Tick_Get_BKS_Top_1----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_1(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(pgSizeBKS*0,pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 1)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_2);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_2----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_2(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(pgSizeBKS*1,pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 2)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_3);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_3----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_3(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 2,this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 3)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_4);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_4----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_4(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 3,this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 4)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_5);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_5----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_5(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 4,this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 5)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_6);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_6----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_6(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 5,this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 6)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_7);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_7----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_7(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 6,this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 7)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_8);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_8----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_8(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 7,this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 8)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_9);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_9----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_9(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 8,this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 9)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_10);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_10----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_10(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 9,this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 10)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_11);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_11----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_11(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 10, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 11)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_12);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_12----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_12(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 11, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 12)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_13);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_13----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_13(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 12, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 13)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_14);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_14----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_14(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 13, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 14)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_15);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_15----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_15(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 14, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 15)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_16);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_16----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_16(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 15, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 16)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_17);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_17----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_17(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 16, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 17)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_18);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_18----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_18(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 17, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 18)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_19);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_19----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_19(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 18, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 19)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_20);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_BKS_Top_20----------------------BKS
        //private void MyTimer_Tick_Get_BKS_Top_20(object sender, EventArgs e)
        //{
        //    MyTimerBKS.Stop();
        //    getBackOrderSum(this.pgSizeBKS * 19, this.pgSizeBKS);
        //    MyTimerBKS = new Timer();
        //    MyTimerBKS.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRowsBKS() > this.pgSizeBKS * 20)
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    else
        //    {
        //        MyTimerBKS.Tick += new EventHandler(MyTimer_Tick_Get_BKS_Top_1);
        //    }
        //    MyTimerBKS.Start();
        //}
        ////MyTimer_Tick_Get_Top_20
        //private void MyTimer_Tick_Get_Top_20(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*0, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 20)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_40);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}

        ////MyTimer_Tick_Get_Top_40
        //private void MyTimer_Tick_Get_Top_40(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*1, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 40)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_60);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}

        ////MyTimer_Tick_Get_Top_60
        //private void MyTimer_Tick_Get_Top_60(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*2, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 60)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_80);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_80
        //private void MyTimer_Tick_Get_Top_80(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*3, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 80)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_100);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_100
        //private void MyTimer_Tick_Get_Top_100(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*4, pgSize);
        //    //rowCount = dataSet.Tables["tblRepair"].Rows.Count;
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 100)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_120);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_120(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*5, pgSize);
            
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 120)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_140);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_140(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*6, pgSize);
            
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 140)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_160);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_160(object sender, EventArgs e)
        //{
            
        //    MyTimer.Stop();
        //    getData(pgSize*7, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 160)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_180);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_180(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*8, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 180)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_200);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_200(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*9, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 200)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_220);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_220(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*10, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 220)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_240);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_240(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*11, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 240)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_260);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_260(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*13, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 260)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_280);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_280(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*13, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 280)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_300);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_300(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*14, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 300)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_320);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_320(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*15, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 320)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_340);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_340(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*16, pgSize);
            
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 340)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_360);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_360(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*17, pgSize);
            
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 360)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_380);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_380(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*18, pgSize);
            
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 380)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_400);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_400(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*19, pgSize);
            
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 400)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_420);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_420(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*20, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 420)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_440);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_440(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*21, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 440)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_460);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_460(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*22, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 460)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_480);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_480(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*23, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 480)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_500);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_500(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*24, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 500)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_520);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}
        ////MyTimer_Tick_Get_Top_120
        //private void MyTimer_Tick_Get_Top_520(object sender, EventArgs e)
        //{
        //    MyTimer.Stop();
        //    getData(pgSize*25, pgSize);
        //    MyTimer = new Timer();
        //    MyTimer.Interval = (1 * 10 * 1000); // 10 seconds
        //    if (TotalRows() > 520)
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    else
        //    {
        //        MyTimer.Tick += new EventHandler(MyTimer_Tick_Get_Top_20);
        //    }
        //    MyTimer.Start();
        //}

    }
}
