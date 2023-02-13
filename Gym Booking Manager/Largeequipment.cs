using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Sportsequipment;

namespace Gym_Booking_Manager
{
    internal class Largeequipment
    {
        
        public string name { get; set; } 
        public string Item { get; set; }
        public string ID { get; set; }

        public bool IsBooked()
        {

            return true;

        }
        protected Largeequipment(string name, string Item, string ID)
        {
            
            this.name = name;
            this.Item = Item;
            this.ID = ID;
        }
        public Largeequipment(Dictionary<String,String> constructionArgs)
        { 
            this.name = constructionArgs[nameof(name)];
            this.ID = constructionArgs[nameof(ID)];
            this.Item = constructionArgs[nameof(Item)];
        }
        public override string ToString()
        {
            return this.CSVify();
        }
        public string CSVify()
        {
            return $"{nameof(name)}:{name},{nameof(ID)}:{ID},{nameof(IsBooked)}:{IsBooked} ";
        }
       
        
    }

    
}
