using Gym_Booking_Manager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;
using static Gym_Booking_Manager.SportsEquipment;

namespace Gym_Booking_Manager
{
    internal class LargeEquipment :Equipment, ICSVable, IComparable<LargeEquipment>
    {
        

        public LargeEquipment(string name, bool isRestricted) : base (name,isRestricted)
        {
            

        }
        public LargeEquipment(Dictionary<String,String> constructionArgs) : base (constructionArgs) 
        { 
      
        }
        public static void BookEquipment()
        {
            GymDatabaseContext reserv = new GymDatabaseContext();
            ListEquipment();
            Console.WriteLine("Which Large equipment do you want to book?");
            string choise1 = Console.ReadLine();
            Console.WriteLine("What are you reserving the equipment for?");
            string choise2 = Console.ReadLine();
            Console.WriteLine("Id of the person who is booking the large equipment");
            int id = Convert.ToInt32(Console.ReadLine());
            string reservation = Calendar.AddTime();
            Calendar newpt = new Calendar(choise1, choise2, id, reservation);
            PostgreSQLDatabase.createRecord(newpt);
            Console.WriteLine("You have made an reservation for equipment");
            //foreach (LargeEquipment equip in reserv.Read<LargeEquipment>("name", choise1))
            //{

            //    if (equip.isRestricted == false)
            //    {
            //        Calendar newpt = new Calendar(equip.name, choise2, reservation);
            //        //Calendar newpt = new Calendar(equip.uniqueID, equip.name, choise2, id, reservation);
            //        reserv.Create<Calendar>(newpt);
            //        Console.WriteLine("You have made an reservation for a Large equipment");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Sorry that item is restricted");
            //    }

            //}
        }
        public static void ListEquipment()
        {
            GymDatabaseContext space = new GymDatabaseContext();
            Console.WriteLine("All Large equipment:");
            PostgreSQLDatabase.readAndPrintAllRecord("LargeEquipment");
            //foreach (LargeEquipment allequip in space.Read<LargeEquipment>())
            //{


            //    Console.WriteLine(allequip);


            //}
        }
        public static void RestrictedItems()
        {
            GymDatabaseContext restricted = new GymDatabaseContext();
            Console.WriteLine();
            Console.WriteLine("Restricted Large equipment:");
            foreach (LargeEquipment restrict in restricted.Read<LargeEquipment>())
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
            foreach (LargeEquipment restricted in restrict.Read<LargeEquipment>("name",item))
            {
                if (restricted.isRestricted == false)
                {
                    restricted.isRestricted= true;
                    LargeEquipment newitem = new LargeEquipment(restricted.name, restricted.isRestricted);
                    restrict.Update<LargeEquipment>(newitem,restricted);
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
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name},{uniqueID},{nameof(isRestricted)}:{isRestricted}";
        }
        public int CompareTo(LargeEquipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return 2;
            //return this.uniqueID.CompareTo(other.uniqueID);
            
        }


    }

    
}
