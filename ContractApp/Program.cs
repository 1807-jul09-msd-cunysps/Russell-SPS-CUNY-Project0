using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using NLog;

namespace PhoneApp
{
    class Program
    {
        static void Main(string[] args)
        {        
            
            SqlConnection connec = null;
            string ConnectionString = "Data Source = revaturetraining.database.windows.net; " +
            "Initial Catalog = PhoneAppDB; Persist Security Info = False; User ID =adminn; Password =Password123!; " +
            "MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
            connec = new SqlConnection(ConnectionString);
            #region Default People
            List<Person> ContactList = new List<Person>(); //Contact List
            /*Address a1 = new Address() { Pid = 1, street = "1", city = "NY", Country = "US", State = "NY", houseNum = "123", zipcode = "11017" };
            Phone ph1 = new Phone() { areaCode = "123", countrycode = "US", ext = "14", number = "789", Pid = 1 };
            Person p1 = new Person() { Pid = 1, firstName = "Raam", lastName = "kun", address = a1, phone = ph1 };
            Address a2 = new Address() { Pid = 1, street = "1", city = "NY", Country = "US", State = "NY", houseNum = "123", zipcode = "11017" };
            Phone ph2 = new Phone() { areaCode = "123", countrycode = "US", ext = "14", number = "789", Pid = 1 };
            Person p2 = new Person() { Pid = 1, firstName = "Ring", lastName = "chin", address = a1, phone = ph1 };
            ContactList.Add(p1);
            ContactList.Add(p2);*/
            #endregion
            #region Creates File
            string serializing = JsonConvert.SerializeObject(ContactList, Formatting.Indented);// Being Serialized
            string path = "ContactList.text";
            if (!File.Exists(path))//Path Created
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(serializing);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(serializing);
                }
            }
            #endregion
    
            Console.WriteLine("Phone Directory App");
            Console.WriteLine("Type Any Number 1-5:\n(1):Read The Database...\n" +
                "(2):Add To the Database...\n(3):Deletes a Contact...\n" +
                "(4):Update a Contact...\n(5):Search a Specific Contact\n(6):Exit");
            while (true)
            {
                string reply =Console.ReadLine();
                switch (reply)
                {
                    #region SERIALIZATION
                    #region READ
                    case "8"://Read
                        if (ContactList.Count() > 0)
                        {
                            foreach (Person i in ContactList)
                            {
                                Console.WriteLine(i.firstName + i.lastName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Contact List Currently Empty");
                        }
                        break;
                    #endregion
                    #region ADD
                    case "9"://Adds another person to the file 
                        Console.WriteLine("You want to add a person");
                        Person newAddition = new Person();
                        Console.WriteLine("First Name:");
                        newAddition.firstName = Console.ReadLine();
                        Console.WriteLine("Last Name:");
                        newAddition.lastName = Console.ReadLine();
                        Console.WriteLine("House Number:");
                        newAddition.address.houseNum = Console.ReadLine();
                        Console.WriteLine("Zipcode:");
                        newAddition.address.zipcode = Console.ReadLine();
                        Console.WriteLine("City:");
                        newAddition.address.city = Console.ReadLine();
                        Console.WriteLine("State:");
                        newAddition.address.State = Console.ReadLine();
                        Console.WriteLine("Country:");
                        newAddition.address.Country = Console.ReadLine();
                        Console.WriteLine("Phone Areacode:");
                        newAddition.phone.areaCode = Console.ReadLine();
                        Console.WriteLine("Phone Number:");
                        newAddition.phone.number = Console.ReadLine();
                        Console.WriteLine("Phone Extension:");
                        newAddition.phone.ext = Console.ReadLine();
                        ContactList.Add(newAddition);
                        Console.WriteLine("Successfully Added");
                        
                        break;
                    #endregion
                    #region DELETE
                    case "10"://Delete
                        try
                        {
                            Console.WriteLine("Please Provide The Contacts First Name To Delete:");
                            string name2 = Console.ReadLine();
                            var deletion = (from i in ContactList
                                            where i.firstName == name2
                                            select i).ToList();
                            Person person = deletion[0];
                            ContactList.Remove(person);
                            Console.WriteLine("Successfully Deleted Contact");
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    #endregion
                    #region UPDATE
                    case "11": //Update
                            Console.WriteLine("Update A Person");
                            try
                            {
                                Console.WriteLine("What is the name of the person you want to update?");
                                string name1 = Console.ReadLine();
                                var searchable1 = (from i in ContactList
                                                   where i.firstName == name1
                                                   select i).ToList();
                                Person personToUpdate = searchable1[0];
                                Console.WriteLine("What would you like to update? [(1)Name, (2)Address, (3) Phone Number]");
                                    string updater = Console.ReadLine();
                                    switch (updater)
                                    {
                                        case "1":// Update Name
                                            Console.WriteLine("First Name:");
                                            personToUpdate.firstName = Console.ReadLine();
                                            Console.WriteLine("Last Name:");
                                            personToUpdate.lastName = Console.ReadLine();
                                            break;
                                        case "2":// Update Address
                                            Console.WriteLine("House Number:");
                                            personToUpdate.address.houseNum = Console.ReadLine();
                                            Console.WriteLine("Zipcode:");
                                            personToUpdate.address.zipcode = Console.ReadLine();
                                            Console.WriteLine("City:");
                                           
                                            Console.WriteLine("Country:");
                                            personToUpdate.address.Country = Console.ReadLine();
                                            Console.WriteLine("State:");
                                            personToUpdate.address.State = Console.ReadLine();
                                    break;
                                        case "3":// Update Phone Number
                                            Console.WriteLine("Phone Areacode:");
                                            personToUpdate.phone.areaCode = Console.ReadLine();
                                            Console.WriteLine("Phone Number");
                                            personToUpdate.phone.number = Console.ReadLine();
                                            Console.WriteLine("Phone Extension");
                                            personToUpdate.phone.ext = Console.ReadLine();
                                            break;
                                    }
                                Console.WriteLine("Successfully Updated");

                            }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                        break;
                    #endregion
                    #region SEARCH
                    case "12": //Search
                        Console.WriteLine("Search Contact By Name:");
                        Console.WriteLine("What is the name of the person you want to search?");
                            string nameTosearch = Console.ReadLine();
                        try
                        {
                            var searchable = (from i in ContactList
                                              where i.firstName == nameTosearch
                                              select i).ToList();
                            Person person2 = searchable[0];
                            Console.WriteLine(person2.address.ToString());
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    #endregion
                    #endregion
                   
                    #region DATABASE FUNCTIONS
                    #region DEFAULT
                    default:
                        Console.WriteLine("Invalid Response! Please Enter A Number Between 1-6");
                        break;
                    #endregion
                    #region READ_DATA
                    case "1":
                        try
                        {
                            string command1 = "SELECT Person.Pid,firstName,lastName,countryCode,areaCode,number,extension,houseNumber,Street,City,States,Country,zipCode FROM Person INNER JOIN Phone ON Phone.Pid = Person.Pid INNER JOIN Address ON Address.Pid = Person.Pid; ";
                            connec.Open();
                            SqlCommand cmd = new SqlCommand(command1, connec);
                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                Console.WriteLine("\nID:" + reader[0] + "\nFirstName:" + reader[1] + " " + "\nLastName:" + reader[2] + " " + "\nCountryCode:" + reader[3] + " " + "\nAreaCode:" + reader[4] + " " + "\nNumber:" + reader[5] + " " + "\nExt:" + reader[6] + " " + "\nHouseNumber:" + reader[7] + " " +
                                    "\nStreet:" + reader[8] + " " + "\nCity:" + reader[9] + " " + "\nState:" + reader[10] + " " + "\nCountry:" + reader[11] + " " + "\nZipCode:" + reader[12]);
                            }
                            connec.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    #endregion
                    #region ADD_DATA
                    case "2":
                        Console.WriteLine("Add A Person: \n What is the first name?");
                        Console.WriteLine("You want to add a person");
                        Person newAddition1 = new Person();
                        Console.WriteLine("ID Number:");
                        newAddition1.Pid = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("First Name:");
                        newAddition1.firstName = Console.ReadLine();
                        Console.WriteLine("Last Name:");
                        newAddition1.lastName = Console.ReadLine();
                        Console.WriteLine("House Number:");
                        newAddition1.address.houseNum = Console.ReadLine();
                        Console.WriteLine("Street:");
                        newAddition1.address.street = Console.ReadLine();
                        Console.WriteLine("Zipcode:");
                        newAddition1.address.zipcode = Console.ReadLine();
                        Console.WriteLine("City:");
                        newAddition1.address.city = Console.ReadLine();
                        Console.WriteLine("State:");
                        newAddition1.address.State = Console.ReadLine();
                        Console.WriteLine("Country:");
                        newAddition1.address.Country = Console.ReadLine();
                        Console.WriteLine("Phone Areacode:");
                        newAddition1.phone.areaCode = Console.ReadLine();
                        Console.WriteLine("Phone Countrycode:");
                        newAddition1.phone.countrycode = Console.ReadLine();
                        Console.WriteLine("Phone Number:");
                        newAddition1.phone.number = Console.ReadLine();
                        Console.WriteLine("Phone Extension:");
                        newAddition1.phone.ext = Console.ReadLine();
                        ContactList.Add(newAddition1);
                        string ser1 = JsonConvert.SerializeObject(ContactList, Formatting.Indented);
                        string path1 = "ContactList.text";
                        using (StreamWriter thing = File.AppendText(path1))
                        {
                            thing.Write(ser1);
                        }
                        string command2 = $"insert into Person (Pid, firstName, lastName) VALUES ({newAddition1.Pid}, '{newAddition1.firstName}', '{newAddition1.lastName}') " +
                $"insert into Address (Pid,houseNumber, Street, City, States, Country, zipCode) VALUES " +
                $"({newAddition1.Pid}, '{newAddition1.address.houseNum}', '{newAddition1.address.street}', '{newAddition1.address.city}', '{newAddition1.address.State}', '{newAddition1.address.Country}', '{newAddition1.address.zipcode}') " +
                $"insert into Phone (Pid, countryCode, areaCode, number, extension) values " +
                $"({newAddition1.Pid}, '{newAddition1.phone.countrycode}', '{newAddition1.phone.areaCode}', '{newAddition1.phone.number}', '{newAddition1.phone.ext}')";
                        try
                        {
                            connec.Open();
                            SqlCommand cmd1 = new SqlCommand(command2, connec);
                            cmd1.ExecuteNonQuery();
                            Console.WriteLine("Successfully Added");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Logger logger = LogManager.GetCurrentClassLogger();
                            logger.Error(e);
                        }
                        connec.Close();
                        break;
                    #endregion
                    #region DELETE_DATA
                    case "3":
                        Console.WriteLine("What is the id of the person you want to delete?");
                        int toDelete = int.Parse(Console.ReadLine());
                        string command3 = $"DELETE FROM Address WHERE Pid = {toDelete}" + $"DELETE FROM Phone WHERE Pid = {toDelete}"+$"DELETE FROM Person WHERE Pid = {toDelete}";
                        try
                        {
                            connec.Open();
                            SqlCommand cmd2 = new SqlCommand(command3, connec);
                            cmd2.ExecuteNonQuery();
                            Console.WriteLine("Successfully Deleted");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        connec.Close();
                        break;
                    #endregion
                    #region UPDATE_DATA
                    case "4":
                        try
                        {
                            connec.Open();
                            Console.WriteLine("What is the ID you want to update?");
                            int idToUpdate = int.Parse(Console.ReadLine());
                            Console.WriteLine("What would you like to update? [(1)Name, (2)Address, (3) Phone Number]");
                            string change = Console.ReadLine();
                            switch (change)
                            {
                                case "1":// Update Name
                                    Console.WriteLine("First Name:");
                                    string nameToUpdate = Console.ReadLine();
                                    string updater = $"UPDATE Person SET firstName = '{nameToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdName = new SqlCommand(updater, connec);
                                    cmdName.ExecuteNonQuery();
                                    Console.WriteLine("Last Name:");
                                    string LnameToUpdate = Console.ReadLine();
                                    string updaterL = $"UPDATE Person SET lastName = '{LnameToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdLName = new SqlCommand(updaterL, connec);
                                    cmdLName.ExecuteNonQuery();
                                    break;
                                case "2":// Update Address
                                    Console.WriteLine("House Number:");
                                    string HouseToUpdate = Console.ReadLine();
                                    string updaterHouse = $"UPDATE Address SET houseNum = '{HouseToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdHouse = new SqlCommand(updaterHouse, connec);
                                    cmdHouse.ExecuteNonQuery();
                                    Console.WriteLine("Zipcode:");
                                    string ZipToUpdate = Console.ReadLine();
                                    string updaterZip = $"UPDATE Address SET houseNum = '{ZipToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdZip = new SqlCommand(updaterZip, connec);
                                    cmdZip.ExecuteNonQuery();
                                    Console.WriteLine("City:");
                                    string CityToUpdate = Console.ReadLine();
                                    string updaterCity = $"UPDATE Address SET houseNum = '{CityToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdCity = new SqlCommand(updaterCity, connec);
                                    cmdCity.ExecuteNonQuery();
                                    Console.WriteLine("Country:");
                                    string CountryToUpdate = Console.ReadLine();
                                    string updaterCountry = $"UPDATE Address SET houseNum = '{CountryToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdCountry = new SqlCommand(updaterCountry, connec);
                                    cmdCountry.ExecuteNonQuery();
                                    Console.WriteLine("State:");
                                    string StateToUpdate = Console.ReadLine();
                                    string updaterState = $"UPDATE Address SET houseNum = '{StateToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdState = new SqlCommand(updaterState, connec);
                                    cmdState.ExecuteNonQuery();
                                    break;
                                case "3":// Update Phone Number
                                    Console.WriteLine("Phone Areacode:");
                                    string AreaToUpdate = Console.ReadLine();
                                    string updaterArea = $"UPDATE Phone SET houseNum = '{AreaToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdArea = new SqlCommand(updaterArea, connec);
                                    cmdArea.ExecuteNonQuery();
                                    Console.WriteLine("Phone Number");
                                    string NumberToUpdate = Console.ReadLine();
                                    string updaterNumber = $"UPDATE Address SET houseNum = '{NumberToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdNumber = new SqlCommand(updaterNumber, connec);
                                    cmdNumber.ExecuteNonQuery();
                                    Console.WriteLine("Phone Extension");
                                    string ExtToUpdate = Console.ReadLine();
                                    string updaterExt = $"UPDATE Address SET houseNum = '{ExtToUpdate}' WHERE Pid = {idToUpdate}";
                                    SqlCommand cmdExt = new SqlCommand(updaterExt, connec);
                                    cmdExt.ExecuteNonQuery();
                                    break;
                            }
                            connec.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine("Succesfully Updated!");
                        break;
                        
                    #endregion
                    #region SEARCH_DATA
                    case "5":
                        try
                        {
                            Console.WriteLine("Searching... Please provide first name:");
                            string nameTosearch1 = Console.ReadLine();
                            string command4 = $"SELECT Person.Pid,firstName,lastName,countryCode,areaCode,number,extension,houseNumber,Street,City,States,Country,zipCode FROM Person INNER JOIN Phone ON Phone.Pid = Person.Pid INNER JOIN Address ON Address.Pid = Person.Pid WHERE Person.firstName = '{nameTosearch1}'; ";
                            connec.Open();
                            SqlCommand cmd4 = new SqlCommand(command4, connec);
                            SqlDataReader reader1 = cmd4.ExecuteReader();
                            while (reader1.Read())
                            {
                                Console.WriteLine("\nID:" + reader1[0] + "\nFirstName:" + reader1[1] + " " + "\nLastName:" + reader1[2] + " " + "\nCountryCode:" + reader1[3] + " " + "\nAreaCode:" + reader1[4] + " " + "\nNumber:" + reader1[5] + " " + "\nExt:" + reader1[6] + " " + "\nHouseNumber:" + reader1[7] + " " +
                                    "\nStreet:" + reader1[8] + " " + "\nCity:" + reader1[9] + " " + "\nState:" + reader1[10] + " " + "\nCountry:" + reader1[11] + " " + "\nZipCode:" + reader1[12]);
                            }
                            connec.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    #endregion
                    #region EXIT
                    case "6":
                        Console.WriteLine("Closing...");
                        Environment.Exit(0);
                        break;
                        #endregion
                        #endregion

                }
            }
       
        }
    }
}
