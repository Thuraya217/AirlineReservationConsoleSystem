using System.Net.NetworkInformation;

namespace AirlineReservationConsoleSystem
{
    internal class Program
    {
        
        static string[] FlightCode = new string[10];
        static string[] FromCity = new string[10];
        static string[] ToCity = new string[10];
        static int[] Duration = new int[10];
        static DateTime[] DepartureTime = new DateTime[10];
        static bool[] ProgramContinue = new bool[10];
        static int MaxFlight = 10;
        static int FlightCount = 0;


        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration)
        {
            char ChoiceChar = 'y';
            do
            {
                if (FlightCount < MaxFlight)
                {
                    FlightCode[FlightCount] = flightCode;
                    FromCity[FlightCount] = fromCity;
                    ToCity[FlightCount] = toCity;
                    Duration[FlightCount] = duration;
                    DepartureTime[FlightCount] = departureTime;
                    ProgramContinue[FlightCount] = true;

                    FlightCount++;
                    Console.WriteLine("Added Successfully");
                }
                else
                {
                    Console.WriteLine("Cannot add more people. Maximum limit reached");
                    break;
                }

                Console.WriteLine("Do you want add another people? y / n");
                ChoiceChar = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            while (ChoiceChar != 'y' && ChoiceChar != 'Y');
            
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

        public static void FindFlightByCode(string code)
        {
            Console.Write("Enter flight code to search: ");
            string SearchCode = Console.ReadLine().ToLower();

            bool IsFound = false;
            for (int i = 0; i < FlightCount; i++)
            {
                if (FlightCode[i].ToLower()== SearchCode && ProgramContinue[i])
                {
                    Console.WriteLine($"Flight code: {FlightCode[i]}, From: {FromCity[i]}, To: {ToCity[i]}, Duration: {Duration[i]}, Departure Time: {DepartureTime[i]} ");
                    IsFound = true;
                }
            }

            if (!IsFound)
            {
                Console.WriteLine("Flight Not found ");
            }
        }

        public static void UpdateFlightDeparture(ref DateTime departure)
        {

        }

        // public static void CancelFlightBooking(out string passengerName)
        // {

        // }

        public static void printValue(string input)
        {
            Console.WriteLine("the result of this operation is: " + input);
        }

        public static void ExitApp(ref bool flag)
        {
            flag = false;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("welcome to airline menu \n \n choose a process \n 1.AddFlight  \n 2.Display All Flights  \n 3.Find Flight By Code \n 4.Update Flight Departure \n 5.Cancel Flight Booking ");
            int choice = int.Parse(Console.ReadLine());

            bool ProgramContinue = true;
 
                switch (choice)
                {
                    case 1:

                        Console.WriteLine("Enter flight code");
                        string flightCode = Console.ReadLine();

                        Console.WriteLine("Enter from City");
                        string fromCity = Console.ReadLine();

                        Console.WriteLine("Enter to City");
                        string toCity = Console.ReadLine();
 
                        DateTime departureTime = DateTime.Now;

                        Console.WriteLine("Enter duration");
                        int duration = int.Parse(Console.ReadLine());

                        AddFlight(flightCode, fromCity, toCity, departureTime, duration); 
                        break;


                    case 2:

                        Console.WriteLine("flight Details:");
                        DisplayAllFlights( );
                        break;

                    case 3:
                    Console.WriteLine("Find Flight By Code: Enter flight code to search:");
                    string code = Console.ReadLine();
                    string result = FindFlightByCode(code); 
                    printValue(result);
                    break;

                    case 4:
                        break;

                    case 5:
                        break;

                    default:

                        break;
                }
                while (ProgramContinue != false) ;
            
        }
    }
}

