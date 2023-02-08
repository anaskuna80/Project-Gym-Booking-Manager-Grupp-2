using Gym_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Reservation
    {
        public readonly IReservingEntity Owner;
        public readonly DateTime StartDate;
        public readonly DateTime EndDate;

        public Reservation(IReservingEntity owner,DateTime startDate, DateTime endDate)
        {
            this.Owner = owner;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
    }
}
