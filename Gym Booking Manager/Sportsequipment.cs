using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Sportsequipment : Equipment, ICSVable, IComparable<Sportsequipment>
    {

        public override bool IsAvailable()
        {

            return true;

        }
        protected Sportsequipment(string name, int id, int uniqueID) : base(name, id, uniqueID)
        {

        
        }
        public Sportsequipment(Dictionary<String, String> constructionArgs) : base (constructionArgs) 
        {
            
        }
        public override string ToString()
        {
            return this.CSVify(); 
        }
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name},{nameof(id)}:{id},{nameof(IsBooked)}:{IsBooked.ToString()} ";
        }
        public int CompareTo(Sportsequipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return this.uniqueID.CompareTo(other.uniqueID);
            
        }





    }
}
