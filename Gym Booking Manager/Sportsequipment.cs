using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Sportsequipment
    {
        private Item item;
        private String name;
        private readonly Calendar calendar;
        
        public Sportsequipment(Item item, String name)
        {
            this.item = item;
            this.name = name;
            this.calendar = new Calendar();
        }
        public enum Item
        {
            racket,
            floorballstick,
            football,
            basketball
        }


    }
}
