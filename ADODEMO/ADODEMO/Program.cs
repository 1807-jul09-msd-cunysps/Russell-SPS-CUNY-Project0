using System;
using System.Data;
using System.Data.SqlClient;

namespace ADODEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = null;
            string command = "select * from Persons";
            string con1 = "Data Source=sabrina-cuny-sps-rev.database.windows.net;User ID=sabrinaf;Password=Shona2018!";


            try
            {
                con = new SqlConnection(con1);
                con.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.close();
            }
        }
    }
}
