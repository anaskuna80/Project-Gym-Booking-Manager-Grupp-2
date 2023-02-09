using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Staff : User , ICSVable
    {
        public Staff(string name) : base(name)
        {

        }
        public override string ToString()
        {
            return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        override public string CSVify()
        {
            return $"{nameof(name)}:{name},{nameof(id)}:{id},{nameof(email)}:{email},{nameof(phone)}:{phone}";
        }
    }
}
