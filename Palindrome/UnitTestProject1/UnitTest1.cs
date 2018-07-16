using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Console.WriteLine("Write a word or number");
            //string word = Console.ReadLine();// User Input
            string word = "A nut for a jar of tuna";
            string expected = "anutforajaroftuna";
            word = word.Replace(" ", String.Empty);
            word = word.ToLower();

            char[] array = word.ToCharArray();//Creating Array for word or number
            Array.Reverse(array);
            string reverse = new string(array);

            Assert.AreEqual(expected, reverse);

            /*if (word.Equals(reverse))
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }
    }
}
