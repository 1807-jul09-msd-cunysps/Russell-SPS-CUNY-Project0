using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp
{
    /*public enum State
    {
        NY, FL, VA, MD, SF, OH
    }
    public enum Country
    {
        FR = 0, US = 1, UK = 44, India = 91, Pakistan = 92, Australia = 61
    }*/
    public class Person
    {
        public Person()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            address = new Address();
            phone = new Phone();
        }
    
        public int Pid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public Phone phone { get; set; }
    }

    public class Address
    {
        public int Pid { get; set; }
        public string houseNum { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string zipcode { get; set; }

        public override string ToString()
        {
            return houseNum +" " + street + " " + city + " " + zipcode;
        }
    }

    public class Phone
    {
        public int Pid { get; set; }
        public string countrycode { get; set; }
        public string areaCode { get; set; }
        public string number { get; set; }
        public string ext { get; set; }
        public override string ToString()
        {
            return areaCode + " " + number + " " + ext;
        }
    }
}
