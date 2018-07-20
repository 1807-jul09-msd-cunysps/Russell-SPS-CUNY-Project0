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
            string ser = JsonConvert.SerializeObject(ContactList, Formatting.Indented);// Being Serialized
            string path = "ContactList.text";
            #region Creates File
            if (!File.Exists(path))//Path Created
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(ser);
                }
            }
            // Open the file to read from.
            /*using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }*/
            #endregion
            Console.WriteLine("Type a number 1-5");
            int reply = Convert.ToInt32(Console.ReadLine());

            switch (reply)
            {
                #region READ
                case 1://Read
                    string json = "";
                    List<Person> values = JsonConvert.DeserializeObject<List<Person>>(json);
                    Person pa = values[1];
                    Console.WriteLine(pa.firstName);
                    break;
                #endregion
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
