using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palindrome;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Palindromic pal = new Palindromic();
            Console.WriteLine(pal.PalindromicChecker());
            Console.Read();
        }
    }
}
