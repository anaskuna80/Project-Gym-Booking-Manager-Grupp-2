using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Largeequipment
    {
        private Litem item;
        private String name;
        private readonly Calendar calendar;

        public Largeequipment(Litem item, String name)
        {
            this.item = item;
            this.name = name;
            this.calendar = new Calendar();
        }
        public enum Litem
        {
            Bench,
            legpress,
            rowmachine,
            boxingsack
        }
    }
}
