
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
        public enum PT
        {
            Emil,
            Andreas,
            Alex,
            Tassanee
        }
        public Category category { get; set; }
        public int uniqueID { get; set; }
        public string name { get; set; }
        public Calendar Calendar { get; set; }
        public bool isBooked { get; set; }
        public string Consultation { get; set; }
        public List<Equipment> EquipmentList { get; set; }
        public int id { get; set; }
        public virtual bool IsAvailable()
        {
            return true;
        }

        public PersonalTrainer(int uniqueID, string name, string consultation, int id, bool isBooked)
        {
            this.uniqueID = uniqueID;
            this.id = id;
            this.name = name;
            this.Consultation = consultation;
            Calendar = new Calendar();
            this.isBooked = isBooked;   
            
        }

        public PersonalTrainer(Dictionary<String, String> constructionArgs)
        {
            this.uniqueID = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);
            this.name = (constructionArgs[nameof(name)]);
            this.isBooked = Convert.ToBoolean(constructionArgs[nameof(isBooked)]);  
            this.Consultation = (constructionArgs[nameof(Consultation)]);
            this.id = Convert.ToInt32(constructionArgs[nameof(id)]);
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
            GymDatabaseContext pts = new GymDatabaseContext();
            Console.WriteLine("All available Personal trainer:");
            foreach (PersonalTrainer pt in pts.Read<PersonalTrainer>())
            {
                if (pt.isBooked == false)
                {
                    Console.WriteLine(pt);
                }
                
            }
            Console.WriteLine("Which Personal Trainer do you want to book?");
            string choise = Console.ReadLine();
            Console.WriteLine("Supervised traing seasion or consultation?");
            string training = Console.ReadLine(); 
            Console.WriteLine("Id of the person who is booking the personal trainer");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (PersonalTrainer pt in pts.Read<PersonalTrainer>("name", choise))
            {
                if (pt.isBooked == false)
                {
                    PersonalTrainer newpt = new PersonalTrainer(pt.uniqueID, pt.name, training, id ,true);
                    pts.Update<PersonalTrainer>(newpt, pt);
                }
                else Console.WriteLine("Sorry that personal trainer is already booked..");
                
            }
        }
        public void BookSession(User name, DateTime startTime, DateTime endTime)
        {
            if (Calendar.IsAvailable(startTime, endTime))
            {
                Calendar.MakeReservation(name, startTime, endTime);
                Console.WriteLine("Session with personal trainer '{0}' has been successfully booked.",name);
            }
            else
            {
                Console.WriteLine("Session with personal trainer '{0}' is not available for booking.", Consultation);
            }
        }

        public bool CancelSession(Reservation reservation)
        {
            if (Calendar.HasReservation(reservation))
            {
                Calendar.RemoveReservation(reservation);
                return true;
            }
            else
            {
                Console.WriteLine("This reservation does not exist for this personal trainer.");
                return false;
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
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name},{nameof(Consultation)}:{Consultation},{nameof(id)}:{id},{nameof(isBooked)}:{isBooked}";
        }
    }
}
