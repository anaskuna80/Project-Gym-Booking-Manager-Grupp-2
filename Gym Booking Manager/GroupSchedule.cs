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
    internal class GroupSchedule 
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

           // GroupActitity activity = new GroupActitity();
            //this.activites.Add(activity);
        }
        public void RemoveActivity(User author, GroupActitity activityID)
        {
            activites.Remove(activityID);
        }
        public void UpdateActivity(User author, GroupActitity activityID)
        {
            foreach (GroupActitity activity in activites)
            {
                if (activity.ActivityID == activityID.ActivityID)
                {
                    Console.WriteLine($"[1]ActivityID:{activity.ActivityID}, [2]participant limit:{activity.participantLimit}, [3]instructor:{activity.instructor}, [4]time:{activity.timeSlot} ");
                    Console.WriteLine("what do you want to update?");
                    int change = Convert.ToInt32(Console.ReadLine());
                    if (change == 1)
                    {
                        Console.Write("ActivityID:");
                        string id = Console.ReadLine();
                        activity.ActivityID = id;
                    }
                    else if (change == 2)
                    {
                        Console.Write("participant limit:");
                        int max = Convert.ToInt32(Console.ReadLine());
                        activity.participantLimit = max;
                    }
                    else if (change == 3)
                    {
                        Console.Write("instructor:");
                        string person = Console.ReadLine();
                        activity.instructor= person;
                    }
                    else if (change == 4)
                    {
                        Console.Write("time:");
                        string time = Console.ReadLine();
                        activity.timeSlot = time;
                    }
                    else
                    {
                        Console.WriteLine("Sorry please select 1-4");
                    }
                }
            }
        }
    }
}

