using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class GroupActivty : GroupSchedule
    {
        private string ActivityID;
        private int participantLimit;
        private List<User> participants;
        private Space space;
        private Equipment equipment;
        private string instructor;
        private string timeSlot;

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
