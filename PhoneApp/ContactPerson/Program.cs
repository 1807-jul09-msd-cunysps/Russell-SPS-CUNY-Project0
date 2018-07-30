using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
namespace PhoneApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connec = new SqlConnection()) //Creating SQL COnnection
            {
                connec.ConnectionString = "Server = tcp:revaturetraining.database.windows.net,1433; Initial Catalog = RevDB; Persist Security Info = False; User ID = { adminn }; Password ={ Password123!}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
            }

            List<Person> ContactList = new List<Person>(); //Contact List
            #region Default People
            Address a1 = new Address() { Pid = 1, street = "1", city = "NY", Country = Country.US, State = State.NY, houseNum = "123", zipcode = "11017" };
            Phone ph1 = new Phone() { areaCode = "123", countrycode = Country.US, ext = "14", number = "789", Pid = 1 };
            Person p1 = new Person() { Pid = 1, firstName = "Raam", lastName = "kun", address = a1, phone = ph1 };
            Address a2 = new Address() { Pid = 1, street = "1", city = "NY", Country = Country.US, State = State.NY, houseNum = "123", zipcode = "11017" };
            Phone ph2 = new Phone() { areaCode = "123", countrycode = Country.US, ext = "14", number = "789", Pid = 1 };
            Person p2 = new Person() { Pid = 1, firstName = "Ring", lastName = "chin", address = a1, phone = ph1 };
            #endregion
            ContactList.Add(p1);
            ContactList.Add(p2);
            string serializing = JsonConvert.SerializeObject(ContactList, Formatting.Indented);// Being Serialized
            string path = "ContactList.text";
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

            Console.WriteLine("Phone Directory App");
            Console.WriteLine("Type Any Number 1-5:");
            Console.WriteLine("(1):Reads The File...");
            Console.WriteLine("(2):Adds To the Contact List...");
            Console.WriteLine("(3):Deletes a Contact...");
            Console.WriteLine("(4):Update a Contact...");
            Console.WriteLine("(5):Search a Specific Contact");


            int reply = Convert.ToInt32(Console.ReadLine());

            switch (reply)
            {
                #region READ
                case 1://Read
                    List<Person> values = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(path));
                    foreach (Person i in values)
                    {
                        Console.WriteLine(i.firstName);
                    }

                    break;
                #endregion
                #region ADD
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
                    Console.WriteLine("Update A Person");

                    break;
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
                            Console.WriteLine(person1.address.ToString());
                            break;
                    }


                    break;
            }
            Console.WriteLine("List:");
            foreach (Person p in ContactList)
            {
                Console.WriteLine(p.firstName);
            }
            Console.ReadKey();
        }
    }
}