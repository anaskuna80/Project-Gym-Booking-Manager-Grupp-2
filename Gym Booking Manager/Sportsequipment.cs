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


        public Sportsequipment(string name, int uniqueID) : base(name,  uniqueID)
        {

        
        }
        public Sportsequipment(Dictionary<String, String> constructionArgs) : base (constructionArgs) 
        {
            
        }
        public static void BookEquipment()
        {
            GymDatabaseContext reserv = new GymDatabaseContext();
            ListEquipment();
            Console.WriteLine("Which sportequipment do you want to book?");
            string choise1 = Console.ReadLine();
            Console.WriteLine("What are you reserving the equipment for?");
            string choise2 = Console.ReadLine();
            Console.WriteLine("Id of the person who is booking the sportequipment");
            int id = Convert.ToInt32(Console.ReadLine());
            string reservation = Calendar.AddTime();

            foreach (Sportsequipment equip in reserv.Read<Sportsequipment>("name", choise1))
            {


                Calendar newpt = new Calendar(equip.uniqueID, equip.name, choise2, id, reservation);
                reserv.Create<Calendar>(newpt);
                Console.WriteLine("You have made an reservation for a Sportequipment");
                break;

            }
        }
        public static void ListEquipment()
        {
            GymDatabaseContext space = new GymDatabaseContext();
            Console.WriteLine("All Sportequipment:");
            foreach (Sportsequipment allequip in space.Read<Sportsequipment>())
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
        public int CompareTo(Sportsequipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return this.uniqueID.CompareTo(other.uniqueID);
            
        }





    }
}
