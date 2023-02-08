using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Equipment
    {
        private String name;
        private Calendar calendar;

        public Equipment(string name)
        {
            this.name = name;
            this.calendar = new Calendar();
        }   
    }
}
