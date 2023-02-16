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

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Calendar
    {
        /*private readonly List<Reservation> reservations;

        public Calendar()
        {
            this.reservations = new List<Reservation>();
            
        }

        // Leaving this method for now. Idea being it may be useful to get entries within a "start" and "end" time/date range.
        // Need parameters if so.
        // Or maybe we'll come up with a better solution elsewhere.
        public List<Reservation> GetSlice(DateTime start, DateTime end)
        {
            return this.reservations.FindAll(r => r.Start >= start && r.End <= end);
        }

        public void MakeReservation(User person, DateTime start, DateTime end)
        {
            var newReservation = new Reservation(person, start, end);
            this.reservations.Add(newReservation);
        }

        public bool CancelReservation(Reservation reservation)
        {
            if (this.reservations.Remove(reservation))
            {
                return true;
            }
            else return false;
        }
        public bool IsAvailable( DateTime startTime, DateTime endTime)
        {
            return !this.reservations.Any(r =>
                (startTime >= r.Start && startTime < r.End) ||
                (endTime > r.Start && endTime <= r.End) ||
                (startTime <= r.Start && endTime >= r.End));
        }
        public bool HasReservation(Reservation reservation)
        {
            return reservations.Contains(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {

            if (this.reservations.Contains(reservation))
            {
                this.reservations.Remove(reservation);
                Console.WriteLine("Reservation removed successfully.");
            }
            else
            {
                Console.WriteLine("Reservation could not be found.");
            }
        }*/


        //Test code for calender. Original(the old code) is above.
        static Dictionary<DateTime, string> reservations = new Dictionary<DateTime, string>();

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

        static void provkör()
        {
            Console.WriteLine("Welcome to the gym booking calendar.");
            CalendarApp();
        }


    }
}