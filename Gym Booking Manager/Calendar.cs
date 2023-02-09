// Placeholder name for file until we get a more complete grasp of classes in the system
// and the organisation thereof.



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Calendar
    {
        private readonly List<Reservation> reservations;

        public Calendar()
        {
            this.reservations = new List<Reservation>();
            
        }

        // Leaving this method for now. Idea being it may be useful to get entries within a "start" and "end" time/date range.
        // Need parameters if so.
        // Or maybe we'll come up with a better solution elsewhere.
        public List<Reservation> GetSlice(DateTime start, DateTime end)
        {
            return this.reservations.FindAll(r => r.Start >= start && r.End <= end);
        }

        public void MakeReservation(User person, DateTime start, DateTime end)
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
        }
        public bool IsAvailable( DateTime startTime, DateTime endTime)
        {
            return !this.reservations.Any(r =>
                (startTime >= r.Start && startTime < r.End) ||
                (endTime > r.Start && endTime <= r.End) ||
                (startTime <= r.Start && endTime >= r.End));
        }
        public bool HasReservation(Reservation reservation)
        {
            return reservations.Contains(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {

            if (this.reservations.Contains(reservation))
            {
                this.reservations.Remove(reservation);
                Console.WriteLine("Reservation removed successfully.");
            }
            else
            {
                Console.WriteLine("Reservation could not be found.");
            }
        }
    }
}