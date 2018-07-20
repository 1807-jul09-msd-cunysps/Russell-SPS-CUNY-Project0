using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
namespace PhoneApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> ContactList = new List<Person>(); //Contact List
            Address a1 = new Address() { Pid = 1, street = "1", city = "NY", Country = Country.US, State = State.NY, houseNum = "123", zipcode = "11017" };
            Phone ph1 = new Phone() { areaCode = "123", countrycode = Country.US, ext = "14", number = "789", Pid = 1 };
            Person p1 = new Person() { Pid = 1, firstName = "Raam", lastName = "trne", address = a1, phone = ph1 };
            ContactList.Add(p1);
            string serializing = JsonConvert.SerializeObject(ContactList);// Being Serialized
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

            Console.WriteLine("Type a number 1-5");
            int reply = Convert.ToInt32(Console.ReadLine());

            switch (reply)
            {
                #region READ
                case 1://Read
                    string json = @"[{'Pid':1,'firstName':'Raam','lastName':'trne','address':{'Pid':1,'houseNum':'123','street':'1','city':'NY','State':0,'Country':1,'zipcode':'11017'},'phone':{'Pid':1,'countrycode':1,'areaCode':'123','number':'789','ext':'14'}}]";
                    List<Person> values = JsonConvert.DeserializeObject<List<Person>>(json);
                    Person pa = new Person();
                    Console.WriteLine(pa);
                    break;
                #endregion
                case 2://Adds another person to the file 
                    Console.WriteLine("You want to add a person");
                    string name = Console.ReadLine();
                    Person newAddition = new Person();
                    ContactList.Add(newAddition);
                    string ser1 = JsonConvert.SerializeObject(ContactList, Formatting.Indented);
                    string path1 = "ContactList.text";
                    using (StreamWriter ting = File.AppendText(path1))
                    {
                        ting.Write(ser1);
                    }
                    break;
                case 3://Delete
                    Console.WriteLine("You want to delete a person");
                    /* string name2 = Console.ReadLine();
                     var deletion = from i in ContactList
                                    where i.firstName == name2
                                    select i;*/

                    break;
                case 4: //Update
                    Console.WriteLine("Update A Person");

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
