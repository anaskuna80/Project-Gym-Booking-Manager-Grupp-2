using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Sportsequipment : Equipment
    {
        private Item item;
        
        
        public Sportsequipment(Item item,string name) : base (name)
        {
            this.name = name;
            this.item = item;  
            calendar = new Calendar();
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
