using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService2Test.ConvertMyTemp;


namespace WcfService2Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertTemperatureClient client = new ConvertTemperatureClient();
            Console.WriteLine($" 45.0 degree celcius = {client.CtoF(45.0M)} Fahrenheit");
            Console.ReadLine();
        }
    }
}
