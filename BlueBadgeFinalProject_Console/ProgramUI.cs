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
        private static string AuthorizationKey = "BBd5b1VSaHiZDZ4Hhb31NdG5xzOQdvbPeZQn0ac_cGgezIlnKjDkcVvjfWSV8BS46huq218OjP9OUgumywtVMgV27tSXVeYaIE7yyWWKdcaTyQ-xuzX29w3-b353jQ1Icz34BSgnoMu76iEFe6xKulSwwHmziFx-AcNXUHwqIe9FeR6uuWrX7H0ihuImgCEk9QQ-GHWycUxHe_n0ocKbtHjDGf4i4J9ENuoeXwllOOX5IG0VmX8WH81XanzACAV8kaGtVTodixlIHOwskDZfxcqtwrfCuWGZaCiKgQ64r-z3MbUdZ6qebMNAFgSh6dnVB53ZeBLJBM9DEEuNFD-AjrIPwTvowSWlb__YX9D2H6zU0dHp4MctcOmQorJKCk_p2gUD3hrxqMw68pOEGo3Pq5tgADnnz5gFiZctQI5q_9ZUsSAd9Tqm9HdKvog1AJzkeWrNS75XkVAtFhrwBc45qLP3QgYti7cSc9L1XVyktdu58kfMP6gfpdp1iKtw_0LV";

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

            DeleteHotel();
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
        private void RemoveHotel()
        {
            bool KeepRunning = true;

            while (KeepRunning)
            {

                Console.Write("\nEnter Hotel ID: ");

                int hotelId = 0;

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
                        Menu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice.\n");
                        Console.WriteLine("Press any key to return to main menu\n.");
                        Console.ReadKey();
                        break;
                }

                if (input == "yes")
                {
                    RemoveHotel();
                }
                else
                {
                    Console.WriteLine("\nPress any key to return to main menu");
                    Console.ReadLine();
                    return;
                }
                    KeepRunning = false;
            }
        }

       

        public void DeleteHotel()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\nChoose an option: \n" +
                    "1.Delete Hotel.\n" +
                    "2.Go back to the main menu.\n");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RemoveHotel();
                        break;
                    case "2":
                        Menu();
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






    }
}
