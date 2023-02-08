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

<<<<<<< HEAD
        // Leaving this method for now. Idea being it may be useful to get entries within a "start" and "end" time/date range.
        // Need parameters if so.
        // Or maybe we'll come up with a better solution elsewhere.


        public List<Reservation> GetSlice(DateTime start, DateTime end, IReservingEntity owner = null)
        {
            var query = this.reservations.Where(r => r.StartDate >= start && r.EndDate <= end);
            if (owner != null)
            {
                query = query.Where(r => r.Owner == owner);
            }
            return query.ToList();
=======
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
>>>>>>> master
        }


    }
}