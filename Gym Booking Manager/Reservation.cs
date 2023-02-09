
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Reservation
    {
        public User Owner { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Reservation(User owner, DateTime start, DateTime end)
        {
            this.Owner = owner;
            this.Start = start;
            this.End = end;

        }
    }
}
