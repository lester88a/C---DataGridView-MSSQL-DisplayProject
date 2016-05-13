using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DisplayProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //delcare all objects/ variables
        private string connectionString;
        private DataViewManager dataViewManager;
        private DataSet dataSet;

        public MainWindow()
        {
            InitializeComponent();

            //sign the connection string value
            //connectionString = "Data Source=ESDB;Initial Catalog=EasyDB;Integrated Security=Ture";
            connectionString = "Data Source=ESDB;Initial Catalog=EasyDB;Integrated Security=True";
            try
            {
                //create a new sql connection and put he connection string on it
                SqlConnection connection = new SqlConnection("Data Source=ESDB;Initial Catalog=EasyDB;Integrated Security=True");
                connection.Open();
                
                //create the DataSet
                dataSet = new DataSet("priDev");

                /*************************************************tblRepair*******************************************/
                //Fill the dataset with tblRepair, map the default table "Table" to "tblRepair"
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter("select RefNumber, convert(date, DateIn) as DateIn, Manufacturer, FuturetelLocation, DATEDIFF(day, DateIn, convert(date, GETDATE())) as Aging, LastTechnician from tblRepair where DateIn between '20160510' and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG'  group by RefNumber, DateIn, LastTechnician, Manufacturer, FuturetelLocation order by DateIn, FuturetelLocation, Aging DESC", connection);

                //map
                dataAdapter1.TableMappings.Add("Table", "tblRepair");

                //fill the dataAdapter
                dataAdapter1.Fill(dataSet);

                //asign the detault view manage from dataset to dsView
                dataViewManager = dataSet.DefaultViewManager;

                //grid data binding
                grdRepair.DataContext = dataViewManager;
                grdRepair.ItemsSource = "tblRepair";
            }
            catch (Exception er)
            {

                MessageBox.Show(er.ToString());
            }
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
