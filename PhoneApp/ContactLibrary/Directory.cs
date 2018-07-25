using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ContactLibrary
{
    public enum State
    {
        NY, FL, VA, MD, SF, OH
    }
    public enum Country
    {
        FR = 0, US = 1, UK = 44, India = 91, Pakistan = 92, Australia = 61
    }
    public class Directory
    {
        public List<Person> ContactList { get; set; }
        public Directory()
            {
            ContactList = new List<Person>();
            }
        #region Add Function
        public void Add(Person Perp)
        {
            ContactList.Add(Perp);
        }
        #endregion
        #region Delete Function
        public void Delete(string name)
        {
            var search = (from Perp in ContactList
                                  where Perp.firstName.Equals(name)
                                  select Perp).ToList();
            Person searched = search[0];
            ContactList.Remove(searched);
        }
        #endregion
        #region Search Function 
        public void Search(string name)
        {
            var search = (from Perp in ContactList
                         where Perp.firstName.Equals(name)
                         select Perp).ToList();
            Person Searched = search[0];
            Console.WriteLine(Searched.address.ToString() + " " + Searched.phone.ToString());
        }
        #endregion
    }

    #region Person Constructor
    public class Person
    {
        public Person()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            address = new Address();
            phone = new Phone();
        }
        public long Pid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public Phone phone { get; set; }

        public override string ToString()
        {
            return firstName + " " + lastName + " " + address.ToString() + " " + phone.ToString();
        }
    }
    #endregion
    #region Address Constructor
    public class Address
    {
        public long Pid { get; set; }
        public string houseNum { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public string zipcode { get; set; }

        public override string ToString()
        {
            return houseNum + " " + street + " "+ city + " " + State + " " + Country;
        }
    }
    #endregion
    #region Phone Constructor
    public class Phone
    {
        public long Pid { get; set; }
        public Country countrycode { get; set; }
        public string areaCode { get; set; }
        public string number { get; set; }
        public string ext { get; set; }

        public override string ToString()
        {
            return countrycode + " " + number;
    }
    }
    #endregion
}

