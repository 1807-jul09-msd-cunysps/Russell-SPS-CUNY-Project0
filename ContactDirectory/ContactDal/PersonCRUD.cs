using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ContactLibrary;


namespace ContactDal
{
    public class PersonCRUD
    {
        SqlConnection connec;
        SqlCommand cmd;
        SqlDataReader datareader;
        string ConnectionString = "Data Source = revaturetraining.database.windows.net; Initial Catalog = PhoneAppDB; Persist Security Info = False; User ID =adminn; Password =Password123!;MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
        string cmdStr = "";
        //READ
        #region GetPersonMethod
        public List<Person> GetPerson()
        {
            using (connec = new SqlConnection(ConnectionString))
            {
                List<Person> persons = new List<Person>();

                cmdStr = "SELECT * FROM Person INNER JOIN Address ON Person.Pid = Address.Pid INNER JOIN Phone on Phone.Pid = Person.Pid";
                connec.Open();
                cmd = new SqlCommand(cmdStr, connec);
                try
                {
                    datareader = cmd.ExecuteReader();
                    while (datareader.Read())
                    {
                        Person p = new Person();
                        p.Pid = Convert.ToInt32(datareader["Pid"]);
                        p.address.Pid = Convert.ToInt32(datareader["Pid"]);
                        p.phone.Pid = Convert.ToInt32(datareader["Pid"]);
                        p.firstName = datareader["firstName"].ToString();
                        p.lastName = datareader["lastName"].ToString();
                        p.address.houseNum = datareader["houseNumber"].ToString();
                        p.address.street = datareader["Street"].ToString();
                        p.address.city = datareader["City"].ToString();
                        p.address.State = datareader["States"].ToString();
                        p.address.Country = datareader["Country"].ToString();
                        p.address.zipcode = datareader["zipCode"].ToString();
                        p.phone.countrycode = datareader["countrycode"].ToString();
                        p.phone.areaCode = datareader["areaCode"].ToString();
                        p.phone.number = datareader["number"].ToString();
                        p.phone.ext = datareader["extension"].ToString();
                        persons.Add(p);
                        p = null;
                    }
                    foreach (Person x in persons)
                    {
                        Console.WriteLine(x.firstName + " " + x.lastName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    datareader.Close();
                }
                return persons;
            }
        }
        #endregion
        //SEARCH PERSON
        #region GetPersonBYID
        public Person Search(int Id)
        {
            using (connec = new SqlConnection(ConnectionString))
            {
                string cmdStr = $"SELECT * FROM Person WHERE Pid = {Id}";
                connec.Open();
                Person Peep = new Person();
                try
                {
                    cmd = new SqlCommand(cmdStr,connec);
                    datareader = cmd.ExecuteReader();
                    while (datareader.Read())
                    {
                        Peep.firstName = datareader["firstName"].ToString();
                        Peep.lastName = datareader["lastName"].ToString();
                        Console.WriteLine(Peep.firstName + " " + Peep.lastName);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connec.Close();
                }
                return Peep;
            }
        }
        #endregion
        //INSERT METHOD
        #region InsertPerson 
        public void Add()
        {
            using (connec = new SqlConnection(ConnectionString))
            {
                Console.WriteLine("You want to add a person");
                try
                {
                    Person newAddition1 = new Person();
                    Console.WriteLine("Please Provide ID Number:");
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
                    string command2 = $"insert into Person (Pid, firstName, lastName) VALUES ({newAddition1.Pid}, '{newAddition1.firstName}', '{newAddition1.lastName}') " +
            $"insert into Address (Pid,houseNumber, Street, City, States, Country, zipCode) VALUES " +
            $"({newAddition1.Pid}, '{newAddition1.address.houseNum}', '{newAddition1.address.street}', '{newAddition1.address.city}', '{newAddition1.address.State}', '{newAddition1.address.Country}', '{newAddition1.address.zipcode}') " +
            $"insert into Phone (Pid, countryCode, areaCode, number, extension) values " +
            $"({newAddition1.Pid}, '{newAddition1.phone.countrycode}', '{newAddition1.phone.areaCode}', '{newAddition1.phone.number}', '{newAddition1.phone.ext}')";
                    connec.Open();
                    SqlCommand cmd1 = new SqlCommand(command2, connec);
                    cmd1.ExecuteNonQuery();
                    Console.WriteLine("Successfully Added");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connec.Close();
                }
            }
        }

        public void Add(Person p)
        {
            using (connec = new SqlConnection(ConnectionString))
            {
                Console.WriteLine("You want to add a person");
                try
                {
                    connec.Open();
                    cmd.Parameters.AddWithValue("@Pid", p.Pid);
                    cmd.Parameters.AddWithValue("@firstName",p.firstName);
                    cmd.Parameters.AddWithValue("@lastName", p.lastName);
                    cmd.Parameters.AddWithValue("@houseNumber", p.address.houseNum);
                    cmd.Parameters.AddWithValue("@Street", p.address.street);
                    cmd.Parameters.AddWithValue("@City", p.address.city);
                    cmd.Parameters.AddWithValue("@Country", p.address.Country);
                    cmd.Parameters.AddWithValue("@zipCode", p.address.zipcode);
                    cmd.Parameters.AddWithValue("@countryCode", p.phone.countrycode);
                    cmd.Parameters.AddWithValue("@areaCode", p.phone.areaCode);
                    cmd.Parameters.AddWithValue("@number", p.phone.number);
                    cmd.Parameters.AddWithValue("@extension", p.phone.ext);

                    string command2 = $"insert into Person (Pid, firstName, lastName) VALUES (@Pid, @firstName, @lastName) " +
            $"insert into Address (Pid,houseNumber, Street, City, States, Country, zipCode) VALUES " +
            $"(@Pid, @houseNumber, @Street, @City, @State, @Country, @zipCode) " +
            $"insert into Phone (Pid, countryCode, areaCode, number, extension) values " +
            $"(@Pid, @countryCode, @areaCode, @number, @extension)";
                    cmd.CommandText = command2;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Successfully Added");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connec.Close();
                }
            }
        }
        #endregion
        //DELETE METHOD
        #region DELETE A PERSON
        public void Delete()
        {
            using (connec = new SqlConnection(ConnectionString))
            {
                Console.WriteLine("What is the id of the person you want to delete?");
                int toDelete = int.Parse(Console.ReadLine());
                try
                {
                    connec.Open();
                    string command3 = $"DELETE FROM Address WHERE Pid = {toDelete}" + $"DELETE FROM Phone WHERE Pid = {toDelete}" + $"DELETE FROM Person WHERE Pid = {toDelete}";
                    SqlCommand cmd2 = new SqlCommand(command3, connec);
                    cmd2.ExecuteNonQuery();
                    Console.WriteLine("Successfully Deleted");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connec.Close();
                }
            }
        }
        #endregion
        //UPDATE 
        #region UPDATE A PERSON
        public void Update()
        {
            using (connec = new SqlConnection(ConnectionString))
            {
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
                            Console.WriteLine("Succesfully Updated!");
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
                            Console.WriteLine("Succesfully Updated!");
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
                            Console.WriteLine("Succesfully Updated!");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connec.Close();
                }
            }
        }
        #endregion

    }
}
