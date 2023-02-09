using Gym_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class PersonalTrainer
    {
        
        private PT personaltrainer;
        private String name;
        private String description;
        private readonly Calendar calendar;

        /*public PersonalTrainer(PT personaltrainer, String name, string description) // desciption(consultation or supervised training session), maybe it will need space/equipment booked in with it?
        {
            this.personaltrainer = personaltrainer;
            this.name = name;
            this.calendar = new Calendar();
            this.description = description;
        }*/
        public enum PT
        {
            Emil,
            Andreas,
            Alex,
            Tassanee
        }
        

        public PT PersonalTrainerType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Calendar Calendar { get; set; }
        //public List<Equipment> EquipmentList { get; set; }

        public PersonalTrainer(PT personalTrainerType, string name, string description)
        {
            PersonalTrainerType = personalTrainerType;
            Name = name;
            Description = description;
            Calendar = new Calendar();
            EquipmentList = new List<Equipment>();
        }

        public void BookSession(IReservingEntity owner, DateTime startTime, DateTime endTime)
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

        /*public void AddEquipment(Equipment equipment)
        {
            EquipmentList.Add(equipment);
        }

        public void BookEquipment(Equipment equipment, IReservingEntity owner, DateTime startTime, DateTime endTime)
        {
            if (EquipmentList.Contains(equipment))
            {
                equipment.BookEquipment(owner, startTime, endTime);
            }
            else
            {
                Console.WriteLine("This equipment is not available for this personal trainer.");
            }
        }

        public bool CancelEquipmentBooking(Equipment equipment, Reservation reservation)
        {
            if (EquipmentList.Contains(equipment))
            {
                return equipment.CancelBooking(reservation);
            }
            else
            {
                Console.WriteLine("This equipment is not available for this personal trainer.");
                return false;
            }
        }*/
    }
}
