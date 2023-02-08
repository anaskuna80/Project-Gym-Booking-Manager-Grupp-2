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
        private List<GroupActivty> activites;

        public void ViewSchedule(User observer)
        {
            foreach (GroupActivty activity in activites)
            {
                Console.WriteLine(activity);
            }
            
        }
        public void AddActivity(User author, ActivityDetails)
        {

        }
        public void RemoveActivity()
        {

        }
        public void UpdateActivity()
        {

        }
    }
    
}

