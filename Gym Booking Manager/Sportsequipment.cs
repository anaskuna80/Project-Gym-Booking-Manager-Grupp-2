using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Sportsequipment : Equipment, ICSVable, IComparable<Sportsequipment>
    {


        public Sportsequipment(int uniqueID, string name, bool isRestricted) : base(  uniqueID,name, isRestricted)
        {

        
        }
        public Sportsequipment(Dictionary<String, String> constructionArgs) : base (constructionArgs) 
        {
            
        }
        public static void BookEquipment()
        {
            GymDatabaseContext reserv = new GymDatabaseContext();
            ListEquipment();
            Console.WriteLine("Which sport equipment do you want to book?");
            string choice1 = Console.ReadLine();
            Console.WriteLine("What are you reserving the equipment for?");
            string choice2 = Console.ReadLine();
            Console.WriteLine("Id of the person who is booking the sport equipment");
            int id = Convert.ToInt32(Console.ReadLine());
            string reservation = Calendar.AddTime();

            foreach (Sportsequipment equip in reserv.Read<Sportsequipment>("name", choice1))
            {

                if (equip.isRestricted == false)
                {
                    Calendar newpt = new Calendar(equip.uniqueID, equip.name, choice2, id, reservation);
                    reserv.Create<Calendar>(newpt);
                    Console.WriteLine("You have made an reservation for a Sport equipment");
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry that item is restricted");
                }
            }
        }
        public static void ListEquipment()
        {
            GymDatabaseContext space = new GymDatabaseContext();
            Console.WriteLine("All Sport equipment:");
            foreach (Sportsequipment allequip in space.Read<Sportsequipment>())
            {


                Console.WriteLine(allequip);


            }
        }
        public static void RestrictedItems()
        {
            GymDatabaseContext restricted = new GymDatabaseContext();
            Console.WriteLine();
            Console.WriteLine("Restricted Sport equipment:");
            foreach (Sportsequipment restrict in restricted.Read<Sportsequipment>())
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
            ListEquipment();
            Console.WriteLine("What item do you want to restict?");
            string item = Console.ReadLine();
            foreach (Sportsequipment restricted in restrict.Read<Sportsequipment>("name", item))
            {
                if (restricted.isRestricted == false)
                {
                    restricted.isRestricted = true;
                    Sportsequipment newitem = new Sportsequipment(restricted.uniqueID, restricted.name, restricted.isRestricted);
                    restrict.Update<Sportsequipment>(newitem, restricted);
                    Console.WriteLine("You have restricted the Item");
                    break;
                }

            }
        }
        public override string ToString()
        {
            return this.CSVify(); 
        }
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name},{nameof(isRestricted)}:{isRestricted}";
        }
        public int CompareTo(Sportsequipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return this.uniqueID.CompareTo(other.uniqueID);
            
        }





    }
}
