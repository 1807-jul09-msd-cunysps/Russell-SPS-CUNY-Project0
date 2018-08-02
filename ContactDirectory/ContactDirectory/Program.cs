using System;
using ContactDal;

namespace PhoneApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonCRUD FindPeople = new PersonCRUD();
            Console.WriteLine("Phone Directory App");
            Console.WriteLine("Type Any Number 1-5:\n(1):Read The Database...\n" +
                "(2):Add To the Database...\n(3):Update a Contact...\n" +
                "(4):Delete a Contact...\n(5):Search a Contact...\n(6):Exit");
            while (true)
            {
                string reply = Console.ReadLine();
                switch (reply)
                {          
                    #region DATABASE FUNCTIONS
                    #region DEFAULT
                    default:
                        Console.WriteLine("Invalid Response! Please Enter A Number Between 1-6");
                        break;
                    #endregion
                    #region READ_DATA
                    case "1":
                        FindPeople.GetPerson();
                        break;
                    #endregion
                    #region ADD_DATA
                    case "2":
                        FindPeople.Add();
                        break;
                    #endregion
                    #region DELETE_DATA
                    case "4":
                        FindPeople.Delete();
                        break;
                    #endregion
                    #region UPDATE_DATA
                    case "3":
                        FindPeople.Update();
                        break;

                    #endregion
                    #region SEARCH_DATA
                    case "5":
                        Console.WriteLine("What is the ID?");
                        int id = Convert.ToInt32(Console.ReadLine());
                        FindPeople.Search(id);
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