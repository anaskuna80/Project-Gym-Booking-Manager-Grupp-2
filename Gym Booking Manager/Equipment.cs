
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
        public int? uniqueID { get; set; } = null;
        public string name { get; set; }
        public bool isRestricted { get; set; }

        protected Equipment(string name, bool isRestricted)
        {
            
            this.name = name;
            this.isRestricted = isRestricted;
            
            
        }
        public Equipment(Dictionary<String, String> constructionArgs)
        {
            
            this.name = constructionArgs[nameof(name)];
            this.uniqueID = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);
            this.isRestricted = Convert.ToBoolean(constructionArgs[nameof(isRestricted)]);

        }

        public override string ToString()
        {
            return $"'{name}', {isRestricted}";
            //return this.CSVify();
        }
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name}, {nameof(isRestricted)}:{isRestricted}";
        }
        public int CompareTo(Equipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return 2;
            //return this.uniqueID.CompareTo(other.uniqueID);
            
        }
    }
}



