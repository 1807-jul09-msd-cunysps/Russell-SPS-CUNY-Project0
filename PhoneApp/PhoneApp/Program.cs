using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using ContactLibrary;

namespace ContactPerson
{
    class Program
    {

        static ContactLibrary.Directory dir = null;
        static void Main(string[] args)
        {
            #region SQL STUFF
            SqlConnection  connec = null;
            string connectString = "Server = tcp:revaturetraining.database.windows.net,1433; Initial Catalog = RevDB; Persist Security Info = False; User ID = {adminn}; Password ={ Password123!}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";

            try
            {
                connec = new SqlConnection(connectString);
                connec.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connec.Close();
            }
            #endregion
            #region Default People
            /*
            Address a1 = new Address() { Pid = 1, street = "1", city = "NY", Country = Country.US, State = State.NY, houseNum = "123", zipcode = "11017" };
            Phone ph1 = new Phone() { areaCode = "123", countrycode = Country.US, ext = "14", number = "789", Pid = 1 };
            Person p1 = new Person() { Pid = 1, firstName = "Raam", lastName = "kun", address = a1, phone = ph1 };
            Address a2 = new Address() { Pid = 1, street = "1", city = "NY", Country = Country.US, State = State.NY, houseNum = "123", zipcode = "11017" };
            Phone ph2 = new Phone() { areaCode = "123", countrycode = Country.US, ext = "14", number = "789", Pid = 1 };
            Person p2 = new Person() { Pid = 1, firstName = "Ring", lastName = "chin", address = a1, phone = ph1 };
            ContactList.Add(p1);
            ContactList.Add(p2);*/
            #endregion
            string serializing = JsonConvert.SerializeObject(ContactList,Formatting.Indented);// Being Serialized
            string path = "ContactList.text";
            TypeWriter();
            #region Creates File
            if (!File.Exists(path))//Path Created
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(serializing);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(serializing);
                }
            }

            #endregion

            Console.WriteLine("List:");
            foreach (Person p in ContactList)
            {
                Console.WriteLine(p.firstName);
            }
            Console.ReadKey();
        }
        static void TypeWriter() {
            #region Console Stuff
            Console.WriteLine("Phone Directory App");
            Console.WriteLine("Type Any Number 1-5:\n(1):Reads The File...\n(2):Adds To the Contact List...\n" +
                "(3):Deletes a Contact...\n(4):Update a Contact...\n(5):Search a Specific Contact");
            int reply = Convert.ToInt32(Console.ReadLine());
            #endregion
            switch (reply)
            {
                case 1:
                    break;
                case 2:
                    Console.WriteLine("Adding A Person:");
                    Person perp = new Person();
                    Console.WriteLine("First Name:");
                    perp.firstName = Console.ReadLine();
                    Console.WriteLine("Last Name:");
                    perp.lastName = Console.ReadLine();
                    Console.WriteLine("House Number:");
                    perp.address.houseNum = Console.ReadLine();
                    Console.WriteLine("Street:");
                    perp.address.street = Console.ReadLine();
                    Console.WriteLine("City:");
                    perp.address.city = Console.ReadLine();
                    Console.WriteLine("Zipcode:");
                    perp.address.zipcode = Console.ReadLine();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;


            }
        }
    }
}
