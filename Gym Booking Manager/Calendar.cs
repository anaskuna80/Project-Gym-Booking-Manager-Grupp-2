// Placeholder name for file until we get a more complete grasp of classes in the system
// and the organisation thereof.


using Gym_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public List<Reservation> GetSlice(DateTime start, DateTime end)
        {
            return this.reservations.FindAll(r => r.Start >= start && r.End <= end);
        }

        public void MakeReservation(IReservingEntity owner, DateTime start, DateTime end)
        {
            var newReservation = new Reservation(owner, start, end);
            this.reservations.Add(newReservation);
        }

        public void CancelReservation(Reservation reservation)
        {
            this.reservations.Remove(reservation);
        }
    }
}