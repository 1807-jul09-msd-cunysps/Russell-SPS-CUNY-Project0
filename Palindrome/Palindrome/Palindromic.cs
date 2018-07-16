using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Palindromic
    {
        public bool PalindromicChecker()
        {
            Console.WriteLine("Write a word or number");
            string word = Console.ReadLine();// User Input
            word = word.Replace(" ", String.Empty);
            word = word.ToLower();

            char[] array = word.ToCharArray();//Creating Array for word or number
            Array.Reverse(array);
            string reverse = new string(array);

            if (word.Equals(reverse))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
