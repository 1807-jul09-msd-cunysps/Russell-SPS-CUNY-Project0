using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palindrome;
using System.Data.SqlClient;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection nect = new SqlConnection())
            {
                nect.ConnectionString = "Server = tcp:revaturetraining.database.windows.net,1433; Initial Catalog = RevDB; Persist Security Info = False; User ID = {adminn}; Password ={Password123!}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
                nect.Open();

                SqlCommand createProducts = new SqlCommand("CREATE TABLE Products(ID,Name,Price)VALUES(int,varchar(255),int)");
                SqlCommand createOrders = new SqlCommand("CREATE TABLE Orders(ID,ProductID,CustomerID)VALUES(int,int,int)");
                SqlCommand createCustomers = new SqlCommand("CREATE TABLE Customers(ID,FirstName,LastName,CardNumber)VALUES(int,varchar(255),varchar(255),int)");

                nect.Close();
            }
           
           /* Palindromic pal = new Palindromic();
            Console.WriteLine(pal.PalindromicChecker());
            Console.Read();*/

        }
    }
}
