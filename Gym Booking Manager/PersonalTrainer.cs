
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Gym_Booking_Manager.Space;


namespace Gym_Booking_Manager
{
    internal class PersonalTrainer : ICSVable, IComparable<PersonalTrainer>
    {

        public int uniqueID { get; set; }
        public string name { get; set; }

        public PersonalTrainer(int uniqueID, string name)
        {
            this.uniqueID = uniqueID;
            this.name = name;

            
        }

        public PersonalTrainer(Dictionary<String, String> constructionArgs)
        {
            this.uniqueID = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);
            this.name = (constructionArgs[nameof(name)]);

        }
        /*public void MakeReservation(User person, DateTime start, DateTime end)
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
        }*/
        public static void ListPT()
        {
            GymDatabaseContext pts = new GymDatabaseContext();
            Console.WriteLine("All Personal trainers:");
            foreach (PersonalTrainer pt in pts.Read<PersonalTrainer>())
            {
                
                
                   Console.WriteLine(pt);
                

            }
        }
        public static void BookPT()
        {
            GymDatabaseContext reserv = new GymDatabaseContext();
            ListPT();
            Console.WriteLine("Which Personal Trainer do you want to book?");
            string choise1 = Console.ReadLine();
            Console.WriteLine("Supervised training session or consultation?");
            string training = Console.ReadLine();
            Console.WriteLine("Id of the person who is booking the personal trainer");
            int id = Convert.ToInt32(Console.ReadLine());
            string reservation = Calendar.AddTime();

            foreach (PersonalTrainer pt in reserv.Read<PersonalTrainer>("name", choise1))
            {


                Calendar newpt = new Calendar(pt.uniqueID, pt.name, training, id,reservation);
                reserv.Create<Calendar>(newpt);
                Console.WriteLine("You have made an reservation for personal trainer");
                break;

            }
        }
        public int CompareTo(PersonalTrainer? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
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
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name}";
        }
    }
}
