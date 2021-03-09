using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinalProject_Console
{
    public class ProgramUI
    {
        private static string AuthorizationKey = "lMwac_8oKKNAw-Zvx2kZedrqqrd4BKtO6VMkn1Zs-Qoyao2AJ2ldjfHclOrru03hZTEzMMouWbzaQeqaXa3w_dAJ-59cEFZx-vFGLi8NabDIn_6_TJ3HV8reiDXKmzWidenqxKtfoSvLPRFcQOU88MeYwXwnyE8hrJFI4DhV34ghWg_SWN21uuyhTNpdcxSjtyq-ntaIKXxsDHTk8CJFKtgE8iCeprfZ0bNPlgY-b-cnlelbOF4HDFhuqha7kalQMP0IdOknE0jZjYOatGJKzsbY7TOL_W9cY0e_11SWVksl-g5Ng083vQqNubas21oPp-L8DzX6JA_u0dkeI5wvF9rg3VyMEdNI-SCKJSpeC1Dwy-_xK14HQbUJ73HJ2kGcRNynBruuxdCgEbvNwnTI3q6h1ejJaaYulmIYGYBNt5eWn9kgqmUA7ImG6VdOuDxXg_7WpJCUzpVv6yu-i3z5FCZKjaEtJOHvl1noZWtKzko";

        private readonly HotelAPI hotelAPI = new HotelAPI(AuthorizationKey);
        private readonly CustomerAPI customerIPA = new CustomerAPI(AuthorizationKey);
        private readonly TransactionAPI transactionAPI = new TransactionAPI(AuthorizationKey);
        private readonly ReviewAPI reviewsAPI = new ReviewAPI(AuthorizationKey);
        private readonly VacationPackageAPI vacPacAPI = new VacationPackageAPI(AuthorizationKey);
        private readonly JunctionAPI junctionAPI = new JunctionAPI(AuthorizationKey);
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("                                            Welcome To Vacation Destination.com Hotel");
                Console.ResetColor();
                Console.WriteLine("                                            ===========================================\n");

                Console.WriteLine("Choose an Option:\n" +
                    "\n" +
                    "1.Show All Hotels\n" +
                    "2.Show All Customers\n" +
                    "3.Show All Transactions\n" +
                    "4.Show All Reviews\n"+
                    "5.Show All Vacation Packages\n" +
                    "6.Show All Junctions\n"+                  
                    "7.Exit\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowAllHotels();

                        break;
                    case "2":
                        ShowAllCustomers();
                        break;
                    case "3":
                        ShowAllTransactions();
                        break;
                    case "4":
                        ShowAllReviews();
                        break;
                    case "5":
                        ShowAllVacationPackages();
                        break;
                    case "6":
                        ShowAllJunctions();
                        break;
                    case "7":
                        keepRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice.\n");
                        Console.WriteLine("Press any key to return to main menu.");
                        Console.ReadKey();
                        break;
                }

            }
        }
  

        private void ShowAllHotels()
        {
            Console.Clear();
            string hotels = "List Of Hotels:";
            Console.WriteLine(hotels);

            var result = hotelAPI.GetAllHotels();
            string listOfHotels = result.responseContent;
            string errorMessage = result.errorMessage;

            //If there is an error
            if(errorMessage != "")
            {
                Console.Clear();
                Console.WriteLine($"\n{errorMessage}");
                Console.WriteLine("\nPress any key to return to main menu");
                Console.ReadLine();
                return;
               
            }
            else
            {
                Console.WriteLine("");

                JArray hotelArray = JArray.Parse(listOfHotels);
                Console.WriteLine(hotelArray);
            }
           
            Console.WriteLine("\nChoose an option: \n" +
                  "1.Delete Hotel.\n" +
                  "2.Go back to the main menu.\n");
            string input = Console.ReadLine();
            bool keepRunning = true;

            switch (input)
            {
                case "1":
                    RemoveHotel();
                    break;
                case "2":
                    return;
                    
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice.\n");
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    break;
            }
        }

        private void ShowAllCustomers()
        {
            Console.Clear();
            string customers = "List of customers:";
            Console.WriteLine(customers);
            var result = customerIPA.GetAllCustomers();
            string listOfCustomers = result.responseContent;
            string errorMessage = result.errorMessage;

            //If there is an error
            if (errorMessage != "")
            {
                Console.Clear();
                Console.WriteLine($"\n{errorMessage}");
                Console.WriteLine("\nPress any key to return to main menu");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("");
                JArray customerArray = JArray.Parse(listOfCustomers);
                Console.WriteLine(customerArray);
            }
        }

        private void ShowAllTransactions()
        {
            Console.Clear();
            string transactions = "List of transactions:";
            Console.WriteLine(transactions);
            var result = transactionAPI.GetAllTransactions();
            string listOfTransactions = result.responseContent;
            string errorMessage = result.errorMessage;

            // If there is an error
            if(errorMessage != "")
            {
                Console.Clear();
                Console.WriteLine($"\n{errorMessage}");
                Console.WriteLine("\nPress any key to return to main menu");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("");
                JArray transactionArray = JArray.Parse(listOfTransactions);
                Console.WriteLine(transactionArray);
            }
        }
        private void ShowAllReviews()
        {
            Console.Clear();
            string reviews = "List of Reviews:";
            Console.WriteLine(reviews);
            var result = reviewsAPI.GetAllReviews();
            string listOfReviews = result.responseContent;
            string errorMessage = result.errorMessage;

            // If there is an error
            if (errorMessage != "")
            {
                Console.Clear();
                Console.WriteLine($"\n{errorMessage}");
                Console.WriteLine("\nPress any key to return to main menu");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("");
                JArray ReviewsArray = JArray.Parse(listOfReviews);
                Console.WriteLine(ReviewsArray);
            }

        }

        private void ShowAllVacationPackages()
        {
            Console.Clear();
            string vacPac = "List Of Vaction Packages:";
            Console.WriteLine(vacPac);
            var result= vacPacAPI.GetAllVacPacs();
            string listOfVacPacs = result.responseContent;
            string errorMessage=result.errorMessage;

            // If there is an error
            if (errorMessage != "")
            {
                Console.Clear();
                Console.WriteLine($"\n{errorMessage}");
                Console.WriteLine("\nPress any key to return to main menu");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("");
                JArray VacPacArray = JArray.Parse(listOfVacPacs);
                Console.WriteLine(VacPacArray);
            }

        }

        private void ShowAllJunctions()
        {
            Console.Clear();
            string junctions = "List of junctions:";
            Console.WriteLine(junctions);
            var result = junctionAPI.GetJunctions();
            string ListOfJunctions = result.responseContent;
            string errorMessage = result.errorMessage;
            //if there is an error
            if (errorMessage != "")
            {
                Console.Clear();
                Console.WriteLine($"\n{errorMessage}");
                Console.WriteLine("\nPress any key to return to main menu");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("");
                JArray junctionArray = JArray.Parse(ListOfJunctions);
                Console.WriteLine(junctionArray);
            }
        }

       // Helper method
        private void RemoveHotel()
        {
            bool KeepRunning = true;

            while (KeepRunning)
            {

                Console.Write("\nEnter Hotel ID: ");

                int hotelId;

                if (int.TryParse(Console.ReadLine(), out hotelId))
                {
                    string errorMessage = hotelAPI.DeleteHotel(hotelId);

                    //if there is an error message,int.TryParse successful or unsuccessful.
                    if (errorMessage != "")
                    {
                        Console.WriteLine($"\n{errorMessage}");
                        Console.WriteLine("\nPress any key to return to main menu");
                        Console.ReadLine();
                        return;
                    }
                    Console.WriteLine("\nThe hotel has been Deleted");
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Hotel Id should be numerical");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("\nWould you Like to Delete another hotel?(y/n)");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "y":
                        RemoveHotel();
                        break;
                    case "n":
                        Console.WriteLine("\nPress any key to return to main menu.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice.\n");
                        Console.WriteLine("Press any key to return to main menu\n.");
                        Console.ReadKey();
                        break;
                }

               
               KeepRunning = false;
            }
        }

       
        






    }
}
