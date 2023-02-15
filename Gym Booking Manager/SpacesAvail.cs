using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    public enum Category
    {
        Hall,
        Lane,
        Studio
    }

    internal class SpacesAvail : ICSVable, IComparable<SpacesAvail>
    {

        private GymDatabaseContext dbContext = new GymDatabaseContext();

       


        public int id { get; set; }
        public string name { get; set; }

        public Category category { get; set; }

        public bool isBooked { get; set; }

        public string timeSlot { get; set; }

        public SpacesAvail(int id, string name, Category category, bool isBooked, string timeSlot)
        {
            this.id = id;
            this.name = name;
            this.category = category;
            this.isBooked = isBooked;
            this.timeSlot = timeSlot;
        }

        public SpacesAvail(Dictionary<String, String> constructionArgs)
        {
            this.id = int.Parse(constructionArgs[nameof(id)]);
            this.name = constructionArgs[nameof(name)];
            this.category = (Category)
                Enum.Parse(typeof(Category), constructionArgs[nameof(category)]);
            this.isBooked = bool.Parse(constructionArgs[nameof(isBooked)]);
            this.timeSlot = constructionArgs[nameof(timeSlot)];
        }

        //Choose which space to view availability for Hall, Lane, or Studio
        public static void ChooseSpace()
        {
            Console.WriteLine("Choose which space to view availability for: ");
            Console.WriteLine("1. Hall");
            Console.WriteLine("2. Lane");
            Console.WriteLine("3. Studio");
            Console.WriteLine("4. Return to Main Menu");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Hall();
                    break;
                case 2:
                    Lane();
                    break;
                case 3:
                    Studio();
                    break;
                case 4:
                    MenuSystem.Login();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ChooseSpace();
                    break;
            }
        }

        //Case 1: Hall Availability


        public static void Hall()
        {
            Console.WriteLine("Hall Availability");
            Console.WriteLine("Available timeSlot: ");
            GymDatabaseContext spaces = new GymDatabaseContext();
            List<SpacesAvail> hall = spaces.Read<SpacesAvail>("category", "Hall");
            foreach (SpacesAvail space in hall)
            {
                if (space.isBooked == false)
                {
                    Console.WriteLine(space.timeSlot);
                }
            }
            Console.WriteLine("Enter the timeSlot you want to book: ");

            string timeSlot = Console.ReadLine();

            Console.WriteLine("You have booked the Hall for " + timeSlot);

            //spaces.Update<SpacesAvail>("id", "1", "isBooked", "true");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadKey();
            MenuSystem.Login();
        }

        //Case 2, same as    case 1 but for Lane

        public static void Lane()
        {
            Console.WriteLine("Lane Availability");
            Console.WriteLine("Available timeSlot: ");
            GymDatabaseContext spaces = new GymDatabaseContext();
            List<SpacesAvail> lane = spaces.Read<SpacesAvail>("category", "Lane");
            foreach (SpacesAvail space in lane)
            {
                if (space.isBooked == false)
                {
                    Console.WriteLine(space.timeSlot);
                }
            }
            Console.WriteLine("Enter the timeSlot you want to book: ");

            string timeSlot = Console.ReadLine();
            Console.WriteLine("You have booked the Lane for " + timeSlot);


           // spaces.Update<SpacesAvail>("id", "1", "isBooked", "true");
            










            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadKey();
            MenuSystem.Login();
        }

        //Case 3, same as    case 1 but for Studio

        public static void Studio()
        {
            Console.WriteLine("Studio Availability");
            Console.WriteLine("Available timeSlot: ");
            GymDatabaseContext spaces = new GymDatabaseContext();
            List<SpacesAvail> studio = spaces.Read<SpacesAvail>("category", "Studio");
            foreach (SpacesAvail space in studio)
            {
                if (space.isBooked == false)
                {
                    Console.WriteLine(space.timeSlot);
                }
            }
            Console.WriteLine("Enter the timeSlot you want to book: ");
            string timeSlot = Console.ReadLine();
            //update timeslot
            //spaces.Update<SpacesAvail>("id", "1", "isBooked", "true");
            //ask for name and update name
            //spaces.Update<SpacesAvail>("id", "1", "name", "name");



            Console.WriteLine("You have booked the Studio for " + timeSlot);
            Console.ReadKey();
            MenuSystem.Login();
        }


        public override string ToString()
        {
            return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }

        public string CSVify()
        {
            return $"{nameof(id)}:{id},{nameof(name)}:{name},{nameof(Category)}:{category},{nameof(isBooked)}:{isBooked}, {nameof(timeSlot)}:{timeSlot}";
        }

        public int CompareTo(SpacesAvail? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null)
                return 1;
            // When category is the same, sort on name.
            return this.id.CompareTo(other.id);
        }
    }
}
