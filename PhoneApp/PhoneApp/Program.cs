using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Person p = new Person();
            p.Adder("Kyle", "Chong");
            p.Read();
            Console.ReadLine();
        }
    }
}
