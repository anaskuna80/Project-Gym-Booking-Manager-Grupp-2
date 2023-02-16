
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
    internal class Equipment: ICSVable, IComparable<Equipment>
    {
        public int uniqueID { get; set; }
        public string name { get; set; }

        protected Equipment(string name,  int uniqueID)
        {
            
            this.name = name;
            this.uniqueID = uniqueID;
            
            
        }
        public Equipment(Dictionary<String, String> constructionArgs)
        {
            
            this.name = constructionArgs[nameof(name)];
            this.uniqueID = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);

        }

        public override string ToString()
        {
            return this.CSVify();
        }
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name}";
        }
        public int CompareTo(Equipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return this.uniqueID.CompareTo(other.uniqueID);
            
        }
    }
}



