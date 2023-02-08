using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Equipment
    {
        public String name { get; set;}
        public Calendar calendar;

        public Equipment(string name)
        {
            this.name = name;
            calendar = new Calendar();
        }
    }

}
