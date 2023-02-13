
using Gym_Booking_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Equipment : Calendar
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Calendar Calendar { get; set; }
        public static object Sportsequipment { get; internal set; }
        public bool IsBooked { get; internal set; }
        public static IEnumerable<Equipment> EquipmentList { get; internal set; }
        public object ID { get; internal set; }

        public Equipment(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            Calendar = new Calendar();
        }
        public bool IsAvailable()
        {
            return Quantity > 0;
        }

        public void BookEquipment(User person, DateTime startTime, DateTime endTime)
        {
            if (Quantity > 0 && Calendar.IsAvailable(startTime, endTime))
            {
                Quantity--;
                Calendar.MakeReservation(person, startTime, endTime);
                Console.WriteLine("Equipment '{0}' has been successfully booked.", Name);
            }
            else
            {
                Console.WriteLine("Equipment '{0}' is not available for booking.", Name);
            }
        }

        public bool CancelBooking(Reservation reservation)
        {
            if (Calendar.HasReservation(reservation))
            {
                Calendar.RemoveReservation(reservation);
                Quantity++;
                return true;
            }
            else
            {
                Console.WriteLine("This reservation does not exist for this equipment.");
                return false;
            }
        }

        public List<Equipment> GetAvailableEquipments(List<Equipment> equipments, DateTime startTime, DateTime endTime)
        {
            List<Equipment> availableEquipments = new List<Equipment>();
            foreach (var equipment in equipments)
            {
                if (equipment.IsAvailable() && equipment.Calendar.IsAvailable(startTime, endTime))
                {
                    availableEquipments.Add(equipment);
                }
            }
            return availableEquipments;
        }

        public void DisplayAvailableEquipments(List<Equipment> equipments, DateTime startTime, DateTime endTime)
        {
            List<Equipment> availableEquipments = GetAvailableEquipments(equipments, startTime, endTime);
            if (availableEquipments.Count > 0)
            {
                Console.WriteLine("The following equipment is available:");
                foreach (var equipment in availableEquipments)
                {
                    Console.WriteLine("- {0}", equipment.Name);
                }
            }
            else
            {
                Console.WriteLine("No equipment is available.");
            }
        }

        internal static Equipment GetEquipment(string v, string? equipmentName)
        {
            throw new NotImplementedException();
        }

        internal void MakeReservation(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }
    }
}



