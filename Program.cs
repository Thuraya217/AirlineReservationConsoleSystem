using System;
using System.Data.SqlTypes;
using System.Net.NetworkInformation;
using System.Threading.Channels;

namespace AirlineReservationConsoleSystem
{
    internal class Program
    {
        static int MaxFlight = 10;
        static string[] FlightCode = new string[10];
        static string[] FromCity = new string[10];
        static string[] ToCity = new string[10];
        static int[] Duration = new int[10];
        static DateTime[] DepartureTime = new DateTime[10];
        static bool[] ProgramContinue = new bool[10];
        static int FlightCount = 0;

        //booking 
        static int MaxBooking = 10;
        static string[] passengerNames = new string[10];
        static string[] bookingIDs = new string[10];
        static int[] basePrice = new int[10];
        static string[] BookedFlightCodes = new string[10];

        static int bookingCount = 0;


        static void DisplayWelcomeMessage()
        {

            Console.WriteLine("Welcome to Airline System");

        }

        static void Main(string[] args)
        {
            StartSystem();
        }

        static int ShowMainMenu()
        {

            Console.WriteLine("Main Menu");
            Console.WriteLine("choose a process");
            Console.WriteLine("1. AddFlight");
            Console.WriteLine("2. Display All Flights");
            Console.WriteLine("3. Find Flight By Code");
            Console.WriteLine("4. Update Flight Departure");
            Console.WriteLine("5. Cancel Flight Booking");
            Console.WriteLine("6. Book Flight");
            Console.WriteLine("7. Validate Flight Code");
            Console.WriteLine("8. Generate Booking ID");
            Console.WriteLine("9. Display Flight Details"); 
            Console.WriteLine("10. Search Bookings By Destination");
            Console.WriteLine("11. Exit");

            int input = int.Parse(Console.ReadLine());
            Console.Clear();

            return input;
        }

        static void ExitApplication()
        {
            Console.WriteLine("Thank you for using the Airline System");
            return;
        }

        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration)
        {
            if (FlightCount < 100)
            {
                FlightCode[FlightCount] = flightCode;
                FromCity[FlightCount] = fromCity;
                ToCity[FlightCount] = toCity;
                Duration[FlightCount] = duration;
                DepartureTime[FlightCount] = departureTime;
                ProgramContinue[FlightCount] = true;
                FlightCount++;
                Console.WriteLine("Flight added successfully.");
            }
            else
            {
                Console.WriteLine("There is not space for add more flight ");
            }
        }            
        
        public static void DisplayAllFlights()
        {
            if (FlightCount == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }

            for (int i = 0; i < FlightCount; i++)
            {
                Console.WriteLine($"Flight code: {FlightCode[i]}, From: {FromCity[i]}, To: {ToCity[i]}, Duration: {Duration[i]}, Departure Time: {DepartureTime[i]} ");
            }
        }

        public static bool FindFlightByCode(string code)
        {
            Console.Write("Enter flight code to search: ");
            string SearchCode = Console.ReadLine().ToLower();

            for (int i = 0; i < FlightCount; i++)
            {
                if (FlightCode[i].ToLower() == SearchCode)
                {
                    Console.WriteLine($"Flight code: {FlightCode[i]}, From: {FromCity[i]}, To: {ToCity[i]}, Duration: {Duration[i]}, Departure Time: {DepartureTime[i]} ");
                    return true;   
                }
            }    
            return false;
            Console.WriteLine("Flight Not found ");   
        }

        public static void UpdateFlightDeparture(ref DateTime departure)
        {
            Console.WriteLine("Enter flight code to update: ");
            string flightCode = Console.ReadLine();
            for (int i = 0; i < FlightCount; i++)
            {
                if (FlightCode[i] == flightCode)
                {
                    DepartureTime[i] = departure;
                    Console.WriteLine("Flight departure updated successfully.");
                    return;
                }
            }
            Console.WriteLine("Flight not found.");
        }

        public static void CancelFlightBooking(out string passengerName)
        {
            Console.Write("Enter flight code to cancel: ");
            string code = Console.ReadLine().ToLower();
            passengerName = "";

            bool isFound = false;

            for (int i = 0; i < FlightCount; i++)
            {
                if (FlightCode[i].ToLower() == code && ProgramContinue[i])
                {
                    ProgramContinue[i] = false;
                    Console.WriteLine($"Booking for {passengerName} on flight {FlightCode[i]} has been cancelled.");
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("Flight not found or already cancelled.");
            }
        }

        static string BookFlight(string passengerName, string flightCode = "Default001")
        {

        }

        static bool ValidateFlightCode(string flightCode)
        {

        }
        static string GenerateBookingID(string passengerName)
        {

        }

        static void DisplayFlightDetails(string code)
        {

        }

        static void SearchBookingsByDestination(string toCity)
        {

        }

        static bool ConfirmAction(string action)

        {
            {
                Console.Write($"Are you sure you want to {action}? (y/n): ");
                string input = Console.ReadLine().ToLower();
                while (input != "y" && input != "n")
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    input = Console.ReadLine().ToLower();
                }
                return input == "y";
            }
        }

        static void StartSystem()
        {

            DisplayWelcomeMessage();

            while (true)
            {
                int choice = ShowMainMenu(); ;

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("Enter flight code");
                        string flightCode = Console.ReadLine();

                        Console.WriteLine("Enter from City");
                        string fromCity = Console.ReadLine();

                        Console.WriteLine("Enter to City");
                        string toCity = Console.ReadLine();

                        
                        Console.Write("Departure Time (yyyy-mm-dd hh:mm): ");
                        DateTime departureTime = DateTime.Parse(Console.ReadLine());

                        Console.Write("Duration (in hourse): ");
                        int duration = int.Parse(Console.ReadLine());

                        AddFlight(flightCode, fromCity, toCity, departureTime, duration);
                        Console.WriteLine("Flight is saved ");
                         break;
            

                    case 2:

                    Console.WriteLine("flight Details:");
                    DisplayAllFlights();
                    break;

                    case 3:
                    Console.WriteLine("Find Flight By Code: Enter flight code to search:");

                    break;

                case 4:

                    Console.Write("Enter flight code to update: ");
                    string UpdateCode = Console.ReadLine();
                    Console.Write("Enter new departure time (yyyy-mm-dd hh:mm): ");
                    DateTime NewDepartureTime = DateTime.Parse(Console.ReadLine());
                    UpdateFlightDeparture(ref NewDepartureTime);

                    break;

                case 5:

                    Console.Write("Enter passenger name to cancel booking: ");
                    string passengerNameToCancel = null;
                    passengerNameToCancel = Console.ReadLine();
                    CancelFlightBooking(out passengerNameToCancel);

                    break;

                case 6:



                    break;

                case 7:



                    break;

                case 8:



                    break;

                case 9:

                    Console.Write("Enter flight code: ");
                    string Code = Console.ReadLine();
                    DisplayFlightDetails(Code);
                    break;

                    break;

                case 10:

                    Console.Write("Enter destination city: ");
                    string City = Console.ReadLine();
                    SearchBookingsByDestination(City);

                    break;

                case 11:

                    ExitApplication();

                    break;

                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
                }
            }

            Console.WriteLine();
        
        }
    }
}

