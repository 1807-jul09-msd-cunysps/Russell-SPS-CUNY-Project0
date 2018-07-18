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
              new Person()
              
                
            };
            using (Stream stream = new FileStream(@"ContactList.text", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serial = new XmlSerializer(typeof(List<Person>));
                serial.Serialize(stream, ContactList);
            }
            ContactList = null;
            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Person>));

            using (FileStream fs2 = File.OpenRead(@"ContactList.text"))
            {
                ContactList = (List<Person>)serializer3.Deserialize(fs2);
            }



            Person test = new Person();
            test.firstName = "Harry";
            ContactList.Add(test);

            Console.ReadLine();
        }
    }
}
