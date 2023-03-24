
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
    internal class Space : ICSVable, IComparable<Space>
    {


        //private static readonly List<Tuple<Category, int>> hourlyCosts = InitializeHourlyCosts(); // Costs may not be relevant for the prototype. Let's see what the time allows.
        public Category category { get; set; }
        //public Category category { get; set; }
        public int? uniqueID { get; set; } = null;
        public bool isRestricted { get; set; }


        public Space(Category category, bool isRestricted )
        {
            this.category = category;
            this.isRestricted= isRestricted;
        
            
        }

        // Every class T to be used for DbSet<T> needs a constructor with this parameter signature. Make sure the object is properly initialized.
        public Space(Dictionary<String, String> constructionArgs)
        {
           
            this.category = (Category)
                Enum.Parse(typeof(Category), constructionArgs[nameof(category)]);
            this.uniqueID = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);
            this.isRestricted = Convert.ToBoolean(constructionArgs[nameof(isRestricted)]);  
           
            
        }

        public Space(int uniqueID, Category category, int id, bool isBooked)
        {
            this.uniqueID = uniqueID;
            this.category = category;
        }

        public int CompareTo(Space? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            if (this.category != other.category) return this.category.CompareTo(other.category);
            // When category is the same, sort on name.
            return 2;
            //return this.uniqueID.CompareTo(other.uniqueID);
        }

        public override string ToString()
        {
            return $"'{category}', {isRestricted}";
            //return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }


        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(category)}:{category.ToString()},{nameof(isRestricted)}:{isRestricted}";
        }
        public enum Category
        {
            hall,
            lane,
            studio
        }
        public static void ListSpace()
        {
            GymDatabaseContext space = new GymDatabaseContext();
            Console.WriteLine("All Personal trainers:");
            foreach (Space allspace in space.Read<Space>())
            {


                Console.WriteLine(allspace);


            }
        }

        public static void BookSpace()
        {
            GymDatabaseContext reserv = new GymDatabaseContext();
            ListSpace();
            Console.WriteLine("Which space do you want to book?");
            string choise1 = Console.ReadLine();
            Console.WriteLine("What are you reserving the space for?");
            string choise2 = Console.ReadLine();
            Console.WriteLine("Id of the person who is booking the space");
            int id = Convert.ToInt32(Console.ReadLine());
            string reservation = Calendar.AddTime();

            foreach (Space pt in reserv.Read<Space>("category", choise1))
            {

                if (pt.isRestricted == false)
                {
                    Calendar newpt = new Calendar(pt.category.ToString(), choise2, reservation);
                    //Calendar newpt = new Calendar(pt.uniqueID, pt.category.ToString(), choise2, id, reservation);
                    reserv.Create<Calendar>(newpt);
                    Console.WriteLine("You have made an reservation for personal trainer");
                    break;

                }
                else
                {
                    Console.WriteLine("Sorry that space is restricted");
                }

            }
        }
        public static void RestrictedItems()
        {
            GymDatabaseContext restricted = new GymDatabaseContext();
            Console.WriteLine();
            Console.WriteLine("Restricted Spaces:");
            foreach (Space restrict in restricted.Read<Space>())
            {
                if (restrict.isRestricted == true)
                {
                    Console.WriteLine(restrict);
                }

            }
        }
        public static void RestrictItem()
        {
            GymDatabaseContext restrict = new GymDatabaseContext();
            ListSpace();
            Console.WriteLine("What Space do you want to restict?");
            string item = Console.ReadLine();
            foreach (Space restricted in restrict.Read<Space>("name", item))
            {
                if (restricted.isRestricted == false)
                {
                    restricted.isRestricted = true;
                    Space newitem = new Space(restricted.category, restricted.isRestricted);
                    //Space newitem = new Space(restricted.uniqueID, restricted.category, restricted.isRestricted);
                    restrict.Update<Space>(newitem, restricted);
                    Console.WriteLine("You have restricted the Space");
                    break;
                }

            }
        }

    }
}
