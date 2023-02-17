using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class GroupSchedule : GroupActivity
    {
        private List<GroupActivity> activites;

        public GroupSchedule(string name,int participantlimit,string instructor,int uniqueID) : base(name, participantlimit,instructor,uniqueID)
        {
            this.activites = new List<GroupActivity>();
        }

        public GroupSchedule(Dictionary<String, String> constructionArgs) : base( constructionArgs)
        {
           

        }
        public static void ViewSchedule()
        {
            GymDatabaseContext equipment = new GymDatabaseContext();
            foreach (GroupSchedule activity in equipment.Read<GroupSchedule>())
            {
                Console.WriteLine(activity);
            }

        }
        public static void AddActivity()
        {
            GymDatabaseContext equipment = new GymDatabaseContext();
            GymDatabaseContext space = new GymDatabaseContext();
            Console.Write("Name of your Activity:");
            string name = Console.ReadLine();
            Console.Write("How many participants?:");
            int participantlimit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name for the instructor?:");
            string instuctor = Console.ReadLine();
            Console.Write("UniqueID for the Activity? (500-600):");
            int uniqueid = Convert.ToInt32(Console.ReadLine());
            GroupSchedule activity = new GroupSchedule(name,participantlimit,instuctor,uniqueid);
            Console.WriteLine("Sports equipment:");
            foreach (Sportsequipment sportsequip in equipment.Read<Sportsequipment>())
            {

                Console.WriteLine(sportsequip.CSVify());

            }
            Console.WriteLine();
            Console.WriteLine("Large equipment:");
            foreach (Largeequipment largeequip in equipment.Read<Largeequipment>())
            {

                Console.WriteLine(largeequip.CSVify());

            }
            Console.WriteLine("--------------------------------------------------");
            Console.Write("name of the equipment you need?");
            string equipname = Console.ReadLine();
            Console.Write("how many?");
            string time = Calendar.AddTime();
            int totalequip = Convert.ToInt32(Console.ReadLine());
            int count1 = 0;
            int count2 = 0; 
            foreach (Sportsequipment sportsequip in equipment.Read<Sportsequipment>("name", equipname))
            {
               
                    
                    Calendar newsport = new Calendar(sportsequip.uniqueID,sportsequip.name,name, uniqueid,time);
                    equipment.Create<Calendar>(newsport);
                    count1++;
                
                
                
                if (count1 == totalequip) break;
            }
            if (count1 > 0) Console.WriteLine($"You reserved {count1}.");
            foreach (Largeequipment sportsequip in equipment.Read<Largeequipment>("name", equipname))
            {
                
                   
                    Calendar newsport = new Calendar(sportsequip.uniqueID, sportsequip.name, name, uniqueid, time);
                    equipment.Create<Calendar>(newsport);
                    count2++;
                    if (count2 == totalequip) break;


            }
            if(count2 > 0 ) Console.WriteLine($"You reserved {count2}.");
            Console.WriteLine();
            foreach (Space spaces in space.Read<Space>())
            {
                Console.WriteLine(spaces);
            }
            Console.WriteLine("--------------------------------------------------");
            Console.Write("What space do you need?:");
            string choise = Console.ReadLine();
            foreach (Space space1 in space.Read<Space>("category", choise))
            {
           
                    
                    Calendar newspace = new Calendar(space1.uniqueID, space1.category.ToString(), name, uniqueid, time);
                    space.Create<Calendar>(newspace);
                    Console.WriteLine($"you reserved {space1.category}");
                    break;

                
            }
            

            //this.activites.Add(activity);
            equipment.Create<GroupSchedule>(activity);
        }
        public static void RemoveActivity()
        {
            GymDatabaseContext grpactivity= new GymDatabaseContext();
            ViewSchedule();
            Console.Write("What Activity do you want to remove?:");
            string remove = Console.ReadLine();
            foreach (GroupSchedule activity in grpactivity.Read<GroupSchedule>("name", remove))
            {
                grpactivity.Delete<GroupSchedule>(activity);
                Console.WriteLine($"You have removed {activity.name} from the groupschedule");
            }
        }
        public static void UpdateActivity()
        {
            GymDatabaseContext updateactivity = new GymDatabaseContext();
            ViewSchedule();
            Console.WriteLine("What activity do you want to update?");
            Console.Write("type the name of the activty");
            string choise = Console.ReadLine();
            foreach (GroupSchedule activity in updateactivity.Read<GroupSchedule>("name",choise))
            {
                if (activity.name == choise)
                {
                    Console.WriteLine($"[1]name:{activity.name}, [2]participant limit:{activity.participantLimit}, [3]instructor:{activity.instructor}"); //  [4]time:{activity.timeSlot} 
                    Console.WriteLine("what do you want to update?");
                    try
                    {
                        int change = Convert.ToInt32(Console.ReadLine());
                        if (change == 1)
                        {
                            Console.Write("name:");
                            string id = Console.ReadLine();
                            activity.name = id;
                            GroupSchedule newgroup = new GroupSchedule(activity.name, activity.participantLimit, activity.instructor, activity.uniqueID);
                            updateactivity.Update<GroupSchedule>(newgroup, activity);
                            Console.WriteLine($"Activity name has been updated to({activity.name})");
                            break;
                        }
                        else if (change == 2)
                        {
                            Console.Write("participant limit:");
                            int max = Convert.ToInt32(Console.ReadLine());
                            activity.participantLimit = max;
                            GroupSchedule newgroup = new GroupSchedule(activity.name, activity.participantLimit, activity.instructor, activity.uniqueID);
                            updateactivity.Update<GroupSchedule>(newgroup, activity);
                            Console.WriteLine($"Activity participant limit has been updated to({activity.participantLimit})");
                            break;
                        }
                        else if (change == 3)
                        {
                            Console.Write("instructor:");
                            string person = Console.ReadLine();
                            activity.instructor = person;
                            GroupSchedule newgroup = new GroupSchedule(activity.name, activity.participantLimit, activity.instructor, activity.uniqueID);
                            updateactivity.Update<GroupSchedule>(newgroup, activity);
                            Console.WriteLine($"Activity instructor has been updated to({activity.instructor})");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Sorry please select 1-4");
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Whoops wrong input..");
                        Console.WriteLine("Please enter: 1,2 or 3 ");
                    }
                }
            }
        }
    }
}

