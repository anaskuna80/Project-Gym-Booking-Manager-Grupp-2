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
    internal class Largeequipment :Equipment, ICSVable, IComparable<Largeequipment>
    {
        

        public override bool IsAvailable()
        {

            return true;

        }
        protected Largeequipment(string name, int id,int uniqueID) : base (name, id, uniqueID)
        {
            

        }
        public Largeequipment(Dictionary<String,String> constructionArgs) : base (constructionArgs) 
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
        public int CompareTo(Largeequipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return this.uniqueID.CompareTo(other.uniqueID);
            
        }


    }

    
}
