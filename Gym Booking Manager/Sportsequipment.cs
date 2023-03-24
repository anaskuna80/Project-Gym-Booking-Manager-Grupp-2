using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class SportsEquipment : Equipment, ICSVable, IComparable<SportsEquipment>
    {


        public SportsEquipment(string name, bool isRestricted) : base(name, isRestricted)
        {

        
        }
        public SportsEquipment(Dictionary<String, String> constructionArgs) : base (constructionArgs) 
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

            foreach (SportsEquipment equip in reserv.Read<SportsEquipment>("name", choice1))
            {

                if (equip.isRestricted == false)
                {
                    Calendar newpt = new Calendar(equip.name, choice2, reservation);
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
            foreach (SportsEquipment allequip in space.Read<SportsEquipment>())
            {


                Console.WriteLine(allequip);


            }
        }
        public static void RestrictedItems()
        {
            GymDatabaseContext restricted = new GymDatabaseContext();
            Console.WriteLine();
            Console.WriteLine("Restricted Sport equipment:");
            foreach (SportsEquipment restrict in restricted.Read<SportsEquipment>())
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
            foreach (SportsEquipment restricted in restrict.Read<SportsEquipment>("name", item))
            {
                if (restricted.isRestricted == false)
                {
                    restricted.isRestricted = true;
                    SportsEquipment newitem = new SportsEquipment(restricted.name, restricted.isRestricted);
                    restrict.Update<SportsEquipment>(newitem, restricted);
                    Console.WriteLine("You have restricted the Item");
                    break;
                }

            }
        }
        public override string ToString()
        {
            return $"'{name}', {isRestricted}";
            //return this.CSVify(); 
        }
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name},{nameof(isRestricted)}:{isRestricted}";
        }
        public int CompareTo(SportsEquipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return 2;
            //return this.uniqueID.CompareTo(other.uniqueID);
            
        }





    }
}
