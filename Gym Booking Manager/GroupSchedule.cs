using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class GroupSchedule : GroupActitity
    {
        private List<GroupActitity> activites;

        public void ViewSchedule(User observer)
        {
            foreach (GroupActitity activity in activites)
            {
                Console.WriteLine(activity);
            }
            
        }
        public void AddActivity(User author)
        {
            
            GroupActitity activity = new GroupActitity();
            this.activites.Add(activity);
        }
        public void RemoveActivity(User author, GroupActitity activityID)
        {
            activites.Remove(activityID);
        }
        public void UpdateActivity(User author,GroupActitity activityID)
        {   
            foreach(GroupActitity activity in activites)
            {
                if (activity.ActivityID == activityID.ActivityID)
                {
                    Console.WriteLine($"ActivityID:{activity.ActivityID}, participant limit:{activity.participantLimit}, instructor:{activity.instructor}, time:{activity.timeSlot} ");
                    Console.WriteLine("what do you want to update?");
                    string change = Console.ReadLine();
                    if (change == activity.ActivityID)
                    {

                    }
                    else if (change == "paricipant limit")
                    {

                    }
                    else if (change == activity.instructor)
                    {

                    }
                    else if (change == "timeslot")
                    {

                    }
                }
            }
        }
    }
    
}

