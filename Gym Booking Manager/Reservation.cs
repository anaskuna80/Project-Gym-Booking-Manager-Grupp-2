using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Reservation
    {
        public string time;
        public string id;
        public string name;

        public Reservation(string time, string id ,string name)
        {
            this.time = time;
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return $"{time}:{id}:{name}";
        }
    }
}
