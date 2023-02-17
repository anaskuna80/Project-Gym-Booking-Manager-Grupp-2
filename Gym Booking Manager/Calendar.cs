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
using static Gym_Booking_Manager.PersonalTrainer;


#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    public class Calendar :  ICSVable, IComparable<Calendar>
    {
        public int uniqueID { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string timeSlot { get; set; }
        

        public Calendar(int uniqueID, string name,string description, int id, string timeSlot)
        {
            this.uniqueID = uniqueID;
            this.id = id;
            this.name = name;
            this.timeSlot = timeSlot;
            this.description = description;
        }
        public Calendar(Dictionary<String, String> constructionArgs)
        {
            this.id = Convert.ToInt32(constructionArgs[nameof(id)]);
            this.name = constructionArgs[nameof(name)];
            this.uniqueID = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);
            this.timeSlot = constructionArgs[nameof(timeSlot)];
            this.description = constructionArgs[nameof(description)];
        }

    

    //static Dictionary<DateTime, string> reservations = new Dictionary<DateTime, string>();

        public static void DeleteReservation()
        {
            GymDatabaseContext reservation = new GymDatabaseContext();
            Console.WriteLine("Here is a list of all current reservations:");
            var reservlist = reservation.Read<Calendar>();
            foreach (var staff in reservlist)
            {
                Console.WriteLine(staff);
            }


            Console.WriteLine("Enter the uniqueID of the reservation to be deleted:");
            int uniqueId = Convert.ToInt32(Console.ReadLine());

            Calendar reserv = reservlist.FirstOrDefault(c => c.uniqueID == uniqueId);

            if (reserv == null)
            {
                Console.WriteLine("Reservation not found. Please try again.");
                return;
            }

            reservation.Delete<Calendar>(reserv);
            Console.WriteLine("Reservation deleted");

        }
        public static void ViewCalendar()
        {
            GymDatabaseContext calendar = new GymDatabaseContext();
            Console.WriteLine("All Personal trainers:");
            foreach (Calendar allcalendar in calendar.Read<Calendar>())
            {
                Console.WriteLine(allcalendar);
            }
        }


        public static void MakeReservation()
        {
            GymDatabaseContext reserv = new GymDatabaseContext();
            Console.WriteLine("What do you want to book?");
            Console.WriteLine("1. Personal trainer\n2. Space\n3. Large equipment\n4. Sport equipment");
            try
            {
                int choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 1)
                {
                    PersonalTrainer.BookPT();
                    
                }
                else if (choise == 2)
                {
                    Space.BookSpace();
                }

                else if (choise == 3)
                {
                    Largeequipment.BookEquipment();
                }
                else if (choise == 4)
                {
                    Sportsequipment.BookEquipment();
                }
                else Console.WriteLine("Wrong choice");
            }
            catch
            {
                Console.WriteLine("Wrong input..");
            }
            }
        public override string ToString()
        {
            return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name},{nameof(description)}:{description},{nameof(id)}:{id},{nameof(timeSlot)}:{timeSlot}";
        }
        public int CompareTo(Calendar? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            // When category is the same, sort on name.
            return this.uniqueID.CompareTo(other.uniqueID);
        }
        public static string AddTime()
        {
            
            Console.Write("Enter the day (1-31): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter the month (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter the year: ");
            int year = int.Parse(Console.ReadLine());


            Console.Write("Enter the time (e.g. '12:00-12:30'): ");
            string time = Console.ReadLine();

            string reservation = $"{year}/{month}/{day} {time}";
            return reservation;
        }


    }
}