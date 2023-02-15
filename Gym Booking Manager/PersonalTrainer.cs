
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
        public int id { get; set; }
        public string name { get; set; }
        public Calendar Calendar { get; set; }
        public bool isBooked { get; set; }
        public string Consultation { get; set; }
        public List<Equipment> EquipmentList { get; set; }
        public virtual bool IsAvailable()
        {
            return true;
        }

        public PersonalTrainer(Category category, string name, string consultation, int id)
        {
            this.id = id;
            this.name = name;
            this.Consultation = consultation;
            this.category= category;
            Calendar = new Calendar();
            EquipmentList = new List<Equipment>();
        }

        public PersonalTrainer(Dictionary<String, String> constructionArgs)
        {
            this.id = Convert.ToInt32(constructionArgs[nameof(id)]);
            this.category = (Category)
                Enum.Parse(typeof(Category), constructionArgs[nameof(category)]);
            this.name = (constructionArgs[nameof(name)]);
            this.Consultation = (constructionArgs[nameof(Consultation)]);
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
            if (this.name != other.name) return this.name.CompareTo(other.name);
            // When category is the same, sort on name.
            return this.id.CompareTo(other.id);
        }

        public override string ToString()
        {
            return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        public string CSVify()
        {
            return $"{nameof(id)}:{id},{nameof(name)}:{name},{nameof(Consultation)}:{Consultation},{nameof(category)}:{category}";
        }
    }
}
