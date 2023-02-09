using Gym_Booking_Manager.Interfaces;
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

        public Equipment(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            Calendar = new Calendar();
        }

        public void BookEquipment(IReservingEntity owner, DateTime startTime, DateTime endTime)
        {
            if (Quantity > 0 && Calendar.IsAvailable(startTime, endTime))
            {
                Quantity--;
                Calendar.MakeReservation(owner, startTime, endTime);
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
    }
}
