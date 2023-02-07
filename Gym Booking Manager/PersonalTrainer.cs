using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class PersonalTrainer
    {
        private PT personaltrainer;
        private String name;
        private String description;
        private readonly Calendar calendar;

        public PersonalTrainer(PT personaltrainer, String name, string description) // desciption(consultation or supervised training session), maybe it will need space/equipment booked in with it?
        {
            this.personaltrainer = personaltrainer;
            this.name = name;
            this.calendar = new Calendar();
            this.description = description;
        }
        public enum PT
        {
            Emil,
            Andreas,
            Alex,
            Tassanee
        }
    }
}
