using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace PhoneApp
{
    class Program
    {
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
            List<Person> ContactList = new List<Person>(); //Contact List
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
                #region READ
                case 1://Read
                    List<Person> values = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(path));
                    foreach (Person i in values)
                    {
                        Console.WriteLine(i.lastName);
                    }

                    break;
                #endregion
                #region Add
                case 2://Adds another person to the file 
                    Console.WriteLine("You want to add a person");
                    string name = Console.ReadLine();
                    Person newAddition = new Person(name);
                    ContactList.Add(newAddition);
                    string ser1 = JsonConvert.SerializeObject(ContactList, Formatting.Indented);
                    string path1 = "ContactList.text";
                    using (StreamWriter ting = File.AppendText(path1))
                    {
                        ting.Write(ser1);
                    }
                    break;
                #endregion
                #region Delete 
                case 3://Delete
                    Console.WriteLine("You want to delete a person");
                    string name2 = Console.ReadLine();
                    var deletion = (from i in ContactList
                                    where i.firstName == name2
                                    select i).ToList();
                    Person person = deletion[0];
                    ContactList.Remove(person);
                    break;
                #endregion
                case 4: //Update
                    Console.WriteLine("Update A Contact");
                    break;
                #region Search
                case 5: //Search
                    Console.WriteLine("Search Contact: name, address,phone");
                    string search = Console.ReadLine();
                    switch (search)
                    {
                        case "name":
                            Console.WriteLine("What name?");
                            string nameer = Console.ReadLine();
                            var searchable = (from i in ContactList
                                              where i.firstName == nameer
                                              select i).ToList();
                            Person person1 = searchable[0];
                            Console.WriteLine(person1.address.city);
                            break;
                        #region Address Search
                        /* case "address":
                             Console.WriteLine("What address?");
                             string addressing = Console.ReadLine();
                             var searchable2 = (from i in ContactList
                                               where i.firstName == addressing
                                               select i).ToList();
                             Person person2 = searchable2[0];
                             Console.WriteLine(person2.firstName);
                             break;*/
                        #endregion
                        case "phone":
                            Console.WriteLine("What phone number?");
                            string phone = Console.ReadLine();
                            var searchable3 = (from i in ContactList
                                               where i.firstName == phone
                                               select i).ToList();
                            Person person3 = searchable3[0];
                            Console.WriteLine(person3.firstName);
                            break;
                    }
                    break;
                    #endregion
            }
        }
    }
}
