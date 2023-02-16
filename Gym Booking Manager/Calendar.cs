// Placeholder name for file until we get a more complete grasp of classes in the system
// and the organisation thereof.



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;
using System.Xml;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Calendar
    {
        public int uniqueID { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public static Dictionary<DateTime, string> reservations;

        public Calendar(int uniqueID, int id, string name)
        {
            this.uniqueID = uniqueID;
            this.id = id;
            this.name = name;
            reservations = new Dictionary<DateTime, string>();
        }
        public Calendar(Dictionary<String, String> constructionArgs)
        {
            this.id = Convert.ToInt32(constructionArgs[nameof(id)]);
            this.name = constructionArgs[nameof(name)];
            this.uniqueID = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);
            reservations = constructionArgs[nameof(reservations)];

        }

        //static Dictionary<DateTime, string> reservations = new Dictionary<DateTime, string>();

        public static void CalendarApp()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Enter a command: ");
                Console.WriteLine(" 1 - View calendar");
                Console.WriteLine(" 2 - Make reservation");
                Console.WriteLine(" 3 - Cancel reservation");
                Console.WriteLine(" 4 - View reservations");
                Console.WriteLine(" 5 - Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewCalendar();
                        break;
                    case "2":
                        MakeReservation();
                        break;
                    case "3":
                        CancelReservation();
                        break;
                    case "4":
                        ViewReservations();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try again.");
                        break;
                }
            }
        }
        public static void ViewCalendar()
        {
            Console.Write("Enter the month (1-12): ");
            int month = Int32.Parse(Console.ReadLine());

            Console.Write("Enter the year: ");
            int year = Int32.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, 1);

            Console.WriteLine(date.ToString("MMMM yyyy"));
            Console.WriteLine(" Su Mo Tu We Th Fr Sa");

            int daysInMonth = DateTime.DaysInMonth(year, month);
            int dayOfWeek = (int)date.DayOfWeek;

            for (int i = 0; i < dayOfWeek; i++)
            {
                Console.Write("   ");
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                DateTime currentDate = new DateTime(year, month, i);
                string reservation = reservations.ContainsKey(currentDate) ? reservations[currentDate] : "";

                Console.Write($"{i,3} {reservation,-5}");

                if ((i + dayOfWeek) % 7 == 0 || i == daysInMonth)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" ");
                }
            }
        }
        public static void MakeReservation()
        {
            Console.Write("Enter the day (1-31): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter the month (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter the year: ");
            int year = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);

            Console.Write("Enter the time (e.g. '8am'): ");
            string time = Console.ReadLine();

            string reservation = $"{time} - {time}";

            if (reservations.ContainsKey(date))
            {
                Console.WriteLine("There is already a reservation for that day. Cancel it first to make a new reservation.");
            }
            else
            {
                reservations[date] = reservation;
                Console.WriteLine("Reservation made!");
            }
        }
        static void CancelReservation()
        {
            Console.Write("Enter the day (1-31): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter the month (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter the year: ");
            int year = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);

            if (reservations.ContainsKey(date))
            {
                string reservation = reservations[date];
                reservations.Remove(date);
                Console.WriteLine($"Reservation {reservation} on {date.ToShortDateString()} has been cancelled.");
            }
            else
            {
                Console.WriteLine("There is no reservation for that day.");
            }
        }
        static void ViewReservations()
        {
            Console.Write("Enter the day (1-31): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter the month (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter the year: ");
            int year = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);

            if (reservations.ContainsKey(date))
            {
                string reservation = reservations[date];
                Console.WriteLine($"There is a reservation for {reservation} on {date.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine("There are no reservations for that day.");
            }
        }
        public override string ToString()
        {
            return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name},{nameof(id)}:{id},{nameof(reservations)}:{reservations.ToString()}";
        }
        static void provkör()
        {
            Console.WriteLine("Welcome to the gym booking calendar.");
            CalendarApp();
        }


    }
}