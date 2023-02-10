using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class GroupActitity : GroupSchedule
    {
        public string ActivityID { get; set; }
        public int participantLimit { get; set; }
        private List<User> participants;
        private Space space;
        private Equipment equipment;
        public string instructor { get; set; }
        public string timeSlot { get; set; }

        public GroupActitity(string ActivityID, int participantlimit, string instructor, string timeslot)
        {
            this.ActivityID = ActivityID;
            this.participantLimit = participantlimit;
            this.instructor = instructor;
            this.timeSlot = timeslot;
            //this.equipment = new Equipment(name,20);
            //this.space = new Space(Space.Category.Hall,name);
        }



        public void SignUp(User participant)
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
    }
}
