using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
namespace Rest
{
    class Program
    {
        static async Task<string> get()
           {
            HttpClient client = new HttpClient();
           // client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users");
            var response = await client.GetAsync("https:://jsonplaceholder.typicode.com/users");
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
        static void Main(string[] args)
        {
            var data = get();
            Console.Write(data);
            Console.ReadLine();
        }   
      
    }
}
