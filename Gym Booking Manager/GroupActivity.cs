﻿using System;
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
    internal class GroupActivity : ICSVable, IComparable<GroupActivity>
    {
        public string name { get; set; }
        public int? ID { get; set; } = null;
        public int participantLimit { get; set; }
        public  List<int> participants;

        public string instructor { get; set; }
        //public string timeSlot { get; set; }

        public GroupActivity(string name, int participantlimit, string instructor)
        {
            this.name = name;
            this.participantLimit = participantlimit;
            this.instructor = instructor;
            this.participants = new List<int>();
            
           
            //this.timeSlot = timeslot;
        }
        public GroupActivity(Dictionary<String, String> constructionArgs)
        {
            this.name = constructionArgs[nameof(name)];
            this.participantLimit = Convert.ToInt32(constructionArgs[nameof(participantLimit)]);
            this.ID = Convert.ToInt32(constructionArgs[nameof(ID)]);
            this.instructor = constructionArgs[nameof(instructor)];
            this.participants = new List<int>();


        }


        public void SignUp(int id)
        {
            if (participants.Count < participantLimit)
            {
                participants.Add(id);
                Console.WriteLine("You signed up to the activity");
            }

            else Console.WriteLine("Group Activity is full");
        }

        public void Modify()
        {

        }
        public override string ToString()
        {
            return $"{instructor}, '{name}', {participantLimit} ";
            //return this.CSVify();
        }
        public string CSVify()
        {
            return $"{nameof(ID)}:{ID},{nameof(name)}:{name},{nameof(participantLimit)}:{participantLimit},{nameof(instructor)}:{instructor} ";
        }
        public int CompareTo(GroupActivity? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return 2;
            //return this.uniqueID.CompareTo(other.uniqueID);

        }
    }
}
