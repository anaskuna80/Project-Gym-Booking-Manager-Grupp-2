using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class GroupActitity : ICSVable, IComparable<GroupActitity>
    {
        public string name { get; set; }
        public int uniqueID { get; set; }
        public int participantLimit { get; set; }
        private List<int> participants;

        public string instructor { get; set; }
        //public string timeSlot { get; set; }

        public GroupActitity(string name, int participantlimit, string instructor, int uniqueID)
        {
            this.name = name;
            this.participantLimit = participantlimit;
            this.instructor = instructor;
            this.participants = new List<int>();
            
            this .uniqueID = uniqueID;
            //this.timeSlot = timeslot;
        }
        public GroupActitity(Dictionary<String, String> constructionArgs)
        {
            this.name = constructionArgs[nameof(name)];
            this.participantLimit = Convert.ToInt32(constructionArgs[nameof(participantLimit)]);
            this.uniqueID = Convert.ToInt32(constructionArgs[nameof(uniqueID)]);
            this.instructor = constructionArgs[nameof(instructor)];


        }


        public void SignUp(int participant)
        {
            if (participants.Count < participantLimit)
            {
                this.participants.Add(participant);
                Console.WriteLine("You signed up to the activity");
            }

            else Console.WriteLine("Group Activity is full");
        }

        public void Modify()
        {

        }
        public override string ToString()
        {
            return this.CSVify();
        }
        public string CSVify()
        {
            return $"{nameof(uniqueID)}:{uniqueID},{nameof(name)}:{name},{nameof(participantLimit)}:{participantLimit},{nameof(instructor)}:{instructor} ";
        }
        public int CompareTo(GroupActitity? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return this.uniqueID.CompareTo(other.uniqueID);

        }
    }
}
