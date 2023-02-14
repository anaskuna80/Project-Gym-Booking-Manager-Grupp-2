
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    // IComparable<T> interface requires implementing the CompareTo(T other) method.
    // This interface/method is used by for instance SortedSet<T>.Add(T) (and other sorted collections).
    // There is also the non-generic IComparable interface for a CompareTo(Object obj) implementation.
    //
    // The current database class implementation uses SortedSet, and thus classes and objects that we want to store
    // in it should inherit the IComparable<T> interface.
    //
    // As alluded to from previous paragraphs, implementing IComparable<T> is not exhaustive to cover all "comparisons".
    // Refer to official C# documentation to determine what interface to implement to allow use with
    // the class/method/operator that you want.
    internal class Space : IReservable, ICSVable, IComparable<Space>
    {


        //private static readonly List<Tuple<Category, int>> hourlyCosts = InitializeHourlyCosts(); // Costs may not be relevant for the prototype. Let's see what the time allows.
        private Category category;
        private int id;
        private readonly Calendar calendar;
        public int uniqueID { get; set; }
        public bool isBooked { get; set; }

        public Space(Category category, int id, int uniqueiD, bool isBooked )
        {
            this.category = category;
            this.id = id;
            this.uniqueID= uniqueiD;
            this.isBooked = isBooked;
            
        }

        // Every class T to be used for DbSet<T> needs a constructor with this parameter signature. Make sure the object is properly initialized.
        public Space(Dictionary<String, String> constructionArgs)
        {
            this.id = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);
            if (!Category.TryParse(constructionArgs[nameof(category)], out this.category))
            {
                throw new ArgumentException("Couldn't parse a valid Space.Category value.", nameof(category));
            }
            this.uniqueID = this.uniqueID = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);
            this.isBooked = Convert.ToBoolean(constructionArgs[nameof(isBooked)]);
            
        }

        public int CompareTo(Space? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            if (this.category != other.category) return this.category.CompareTo(other.category);
            // When category is the same, sort on name.
            return this.uniqueID.CompareTo(other.uniqueID);
        }

        public override string ToString()
        {
            return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(category)}:{category.ToString()},{nameof(id)}:{id},{nameof(isBooked)}:{isBooked}";
        }
        public enum Category
        {
            Hall,
            Lane,
            Studio
        }

        public void ViewTimeTable()
        {
            // Fetch
            List<Reservation> tableSlice = this.calendar.GetSlice(DateTime.Now, DateTime.Now.AddMonths(1));
            // Show?
            foreach (Reservation reservation in tableSlice)
            {
               Console.WriteLine(reservation);  
            }

        }

        public void MakeReservation(User person)
        {
            Console.WriteLine("Enter start time (hh:mm):");
            string startTimeInput = Console.ReadLine();
            Console.WriteLine("Enter end time (hh:mm):");
            string endTimeInput = Console.ReadLine();

            // Parse the input strings into DateTime objects for start and end times.
            if (!DateTime.TryParseExact(startTimeInput, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startTime) ||
                !DateTime.TryParseExact(endTimeInput, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endTime))
            {
                Console.WriteLine("Invalid input. Please enter the time in the format hh:mm.");
                return;
            }

            // Check if the start time is before the end time.
            if (startTime >= endTime)
            {
                Console.WriteLine("The start time must be before the end time.");
                return;
            }

            // Check if the reservation time is available.
            if (!this.calendar.IsAvailable(startTime, endTime))
            {
                Console.WriteLine("The space is not available during the requested time.");
                return;
            }

            // Create a new reservation and add it to the calendar.
            this.calendar.MakeReservation(person, startTime,endTime);

            Console.WriteLine("Reservation created successfully.");

        }
        public void CancelReservation(Reservation reservation)
        {
            // First check if the reservation exists
            if (this.calendar.HasReservation(reservation))
            {
                // If it exists, remove it from the calendar
                this.calendar.RemoveReservation(reservation);
            }
            else
            {
                // If the reservation does not exist, throw an exception
                throw new Exception("The reservation could not be found and could not be cancelled.");
            }
        }

        // Consider how and when to add a new Space to the database.
        // Maybe define a method to persist it? Any other reasonable schemes?

        //private static List<Tuple<Category, int>> InitializeHourlyCosts()
        //{
        //    // TODO: fetch from "database"
        //    var hourlyCosts = new List<Tuple<Category, int>>
        //    {
        //        Tuple.Create(Category.Hall, 500),
        //        Tuple.Create(Category.Lane, 100),
        //        Tuple.Create(Category.Studio, 400)
        //    };
        //    return hourlyCosts;
        //}
                /*public void RemoveReservation(Reservation reservation)
        {
            
            if (this.calendar.CancelReservation(reservation))
            {
                Console.WriteLine("Reservation removed successfully.");
            }
            else
            {
                Console.WriteLine("Reservation could not be found.");
            }
        }
        public bool HasReservation(Reservation reservation)
        {
            return calendar.HasReservation(reservation);
        }*/
    }
}
