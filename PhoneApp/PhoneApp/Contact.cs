using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp
{
    class Contact
    {
        string firstName;
        string lastName;
        string phoneNumber;
        string city;
        string zipCode;

            public Contact(string firstName, string lastName, string phoneNumber, string city,string zipCode)
            {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.city = city;
            this.zipCode = zipCode;
            }
    }
}
