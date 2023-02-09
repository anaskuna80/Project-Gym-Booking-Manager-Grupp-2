using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Largeequipment : Equipment
    {
        private Litem item;
       

        public Largeequipment(Litem item, String name,int quantity) : base (name, quantity) 
        {
            this.item = item;
           
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
