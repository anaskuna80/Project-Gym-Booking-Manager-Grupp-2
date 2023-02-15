
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class PersonalTrainer
    {
        public enum PT
        {
            Emil,
            Andreas,
            Alex,
            Tassanee
        }
        

        public PT PersonalTrainerType { get; set; }
        public User Name { get; set; }
        public string Description { get; set; }
        public Calendar Calendar { get; set; }
        public List<Equipment> EquipmentList { get; set; }

        public PersonalTrainer(PT personalTrainerType, User name, string description)
        {
            PersonalTrainerType = personalTrainerType;
            Name = name;
            Description = description;
            Calendar = new Calendar();
            EquipmentList = new List<Equipment>();
        }

        public void BookSession(User owner, DateTime startTime, DateTime endTime)
        {
            if (Calendar.IsAvailable(startTime, endTime))
            {
                Calendar.MakeReservation(owner, startTime, endTime);
                Console.WriteLine("Session with personal trainer '{0}' has been successfully booked.", Name);
            }
            else
            {
                Console.WriteLine("Session with personal trainer '{0}' is not available for booking.", Name);
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
    }
}
