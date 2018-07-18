using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace PhoneApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> ContactList = new List<Person> //Contact List
            {
                new Person("Russell"),
                new Person("Cindy")

            };

            Stream stream = File.Open("ContactList.text",FileMode.Create);    //Streaming 
            BinaryFormatter binary = new BinaryFormatter();

            binary.Serialize(stream,ContactList);
            ContactList = null;

            stream = File.Open("ContactList.text", FileMode.Open);

            binary = new BinaryFormatter();

            



            Console.ReadLine();
        }
    }
}
