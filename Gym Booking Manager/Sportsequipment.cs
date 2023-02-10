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

        public Item Type { get; set; }
        public Sportsequipment(Item item,string name,int quantity) : base (name,quantity)
        {
            
            this.item = item;  
            
        }
        public enum Item
        {
            racket,
            floorballstick,
            football,
            basketball
        }

        public Sportsequipment(string name, int quantity, Item type) : base(name, quantity)
        {
            Type = type;
        }

        public void BookSportsequipment(User person, DateTime startTime, DateTime endTime)
        {
            BookEquipment(person, startTime, endTime);
        }

        public void UnbookSportsequipment(Reservation reservation)
        {
            CancelBooking(reservation);
        }

        /*
        
            Sportsequipment tennisRacket = new Sportsequipment("Tennis Racket", 5, Sportsequipment.Item.racket);
            tennisRacket.BookSportsequipment(user, startTime, endTime);

            Reservation reservation = new Reservation(user, startTime, endTime);
            tennisRacket.UnbookSportsequipment(reservation);
        
        */ //Can use these above in program side for call out exactly what member need to.




    }
}
