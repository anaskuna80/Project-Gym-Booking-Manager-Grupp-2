using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Sportsequipment;

namespace Gym_Booking_Manager
{
    internal class Largeequipment :Equipment, ICSVable, IComparable<Largeequipment>
    {
        

        public Largeequipment(string name,int uniqueID) : base (name, uniqueID)
        {
            

        }
        public Largeequipment(Dictionary<String,String> constructionArgs) : base (constructionArgs) 
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

            foreach (Largeequipment equip in reserv.Read<Largeequipment>("name", choise1))
            {


                Calendar newpt = new Calendar(equip.uniqueID, equip.name, choise2, id, reservation);
                reserv.Create<Calendar>(newpt);
                Console.WriteLine("You have made an reservation for a Large equipment");
                break;

            }
        }
        public static void ListEquipment()
        {
            GymDatabaseContext space = new GymDatabaseContext();
            Console.WriteLine("All Large equipment:");
            foreach (Largeequipment allequip in space.Read<Largeequipment>())
            {


                Console.WriteLine(allequip);


            }
        }
 
        public override string ToString()
        {
            return this.CSVify();
        }
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name}";
        }
        public int CompareTo(Largeequipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return this.uniqueID.CompareTo(other.uniqueID);
            
        }


    }

    
}
