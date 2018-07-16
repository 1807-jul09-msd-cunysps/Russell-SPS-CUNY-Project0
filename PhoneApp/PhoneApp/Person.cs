using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PhoneApp
{
    //Person 
    public class Person
    {
        string firstName;
        string lastName;

        public Person(string firstName, string lastName)
            {
            this.firstName = firstName;
            this.lastName = lastName;
            }
    }
    //Phone
    public class Phone
    {
        string number; 
    }

}