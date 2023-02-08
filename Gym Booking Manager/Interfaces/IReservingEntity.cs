using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager.Interfaces
{
    internal interface IReservingEntity
    {
        string Name { get; }
    }

    internal class Customer : IReservingEntity
    {
        public string Name { get; set; }
    }

    internal class GroupActivity : IReservingEntity
    {
        public string Name { get; set; }
    }

    internal class Staff : IReservingEntity
    {
        public string Name { get; set; }
    }
}
