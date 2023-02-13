
using Gym_Booking_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Equipment
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Calendar Calendar { get; set; }  
        public bool IsBooked { get; internal set; }
        public bool IsAvailable()
        {
            return true;
        }
        protected Equipment(string id, string name)
        {
            this.ID = id;
            this.Name = name;
            
        }
        public Equipment(Dictionary<String, String> constructionArgs)
        {
            this.ID = constructionArgs[nameof(ID)];
            this.Name = constructionArgs[nameof(Name)];
            
        }
        public override string ToString()
        {
            return this.CSVify();
        }
        public string CSVify()
        {
            return $"{nameof(Name)}:{Name},{nameof(ID)}:{ID},{nameof(IsBooked)}:{IsBooked} ";
        }
    }
}



