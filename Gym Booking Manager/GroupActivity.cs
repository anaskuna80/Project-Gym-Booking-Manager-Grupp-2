using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class GroupActitity 
    {
        public string ActivityID { get; set; }
        public int participantLimit { get; set; }
        private List<User> participants;
        private Space space;
        private Equipment equipment;
        public string instructor { get; set; }
        public string timeSlot { get; set; }

        public GroupActitity()
        {
            Console.WriteLine("ActivityID?");
            string ID = Console.ReadLine();
            this.ActivityID = ID;
            Console.WriteLine("Participant Limit?");
            int Max = Convert.ToInt32(Console.ReadLine());
            this.participantLimit = Max;
            Console.WriteLine("Instructors name:");
            string name = Console.ReadLine();
            this.instructor = name;
            Console.WriteLine("Timeslot: format(2023-02-08:14:00-2023-02-08:15:00");
            string time = Console.ReadLine();
            this.timeSlot = time;
            this.equipment = new Equipment(name);
            this.space = new Space(category,name);
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
