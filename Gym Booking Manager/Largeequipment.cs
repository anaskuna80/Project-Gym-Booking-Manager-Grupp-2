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
        public Litem Type { get; set; }

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
        public Largeequipment(string name, int quantity, Litem type) : base(name, quantity)
        {
            Type = type;
        }
        public void BookLargeequipment(User person, DateTime startTime, DateTime endTime)
        {
            BookEquipment(person, startTime, endTime);
        }

        public void UnbookLargeequipment(Reservation reservation)
        {
            CancelBooking(reservation);
        }

        /*
 
            Largeequipment benchPress = new Largeequipment("Bench Press", 2, Largeequipment.Litem.Bench);
            benchPress.BookLargeequipment(user, startTime, endTime);

            Reservation reservation = new Reservation(user, startTime, endTime);
            benchPress.UnbookLargeequipment(reservation);
        
        */ //Can use these above in program side for call out exactly what member need to.
        
    }

    
}
