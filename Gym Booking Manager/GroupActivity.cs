using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class GroupActivty
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
            this.participants.Add(participant);
        }

        public void Modify()
        {

        }
    }
}
