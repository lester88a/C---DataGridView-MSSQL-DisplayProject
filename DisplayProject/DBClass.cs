using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayProject
{
    class DBClass
    {
        //variables
        public string []id;
        public string []refNum;
        public string esn;
        public string gspn;
        public string act;
        public string dateCrt;

        //constructor
        public DBClass()
        {

        }
        //connection
        public void Connect()
        {
            // 1. Instantiate the connection
            SqlConnection conn = new SqlConnection("Data Source=DEVPC001\\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=Ture");

            SqlDataReader rdr = null;

            try
            {
                // 2. Open the connection
                conn.Open();

                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from table1", conn);

                //
                // 4. Use the connection
                //

                // get query results
                rdr = cmd.ExecuteReader();

                // print the CustomerID of each record
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                    
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
