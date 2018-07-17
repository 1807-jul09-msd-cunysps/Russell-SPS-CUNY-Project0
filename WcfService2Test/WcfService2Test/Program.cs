using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService2Test.ConvertMyTemp;
using WcfService2Test.Calc;



namespace WcfService2Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConvertTemperatureClient client = new ConvertTemperatureClient();
            //Console.WriteLine($" 45.0 degree celcius = {client.CtoF(45.0M)} Fahrenheit");


            CalculatorSoapClient clienter = new CalculatorSoapClient();
            Console.WriteLine(clienter.Add(5,3));

            Console.ReadLine();
        }
    }
}
