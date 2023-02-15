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
    internal class GroupSchedule : GroupActitity
    {
        private List<GroupActitity> activites;

        public GroupSchedule(string name,int participantlimit,string instructor,int uniqueID) : base(name, participantlimit,instructor,uniqueID)
        {
            this.activites = new List<GroupActitity>();
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
            Console.Write("UniqueID for the Activity? (500-600)");
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
            int totalequip = Convert.ToInt32(Console.ReadLine());
            int count1 = 0;
            int count2 = 0; 
            foreach (Sportsequipment sportsequip in equipment.Read<Sportsequipment>("name", equipname))
            {
                if (sportsequip.id > 0)
                {
                    Console.WriteLine($"Notification sent to id:({sportsequip.id}) email and number to return equipment for the group activity");
                    sportsequip.id = uniqueid;
                    sportsequip.isBooked = true;
                    Sportsequipment newsport = new Sportsequipment(sportsequip.name, sportsequip.id, sportsequip.uniqueID, sportsequip.isBooked);
                    equipment.Update<Sportsequipment>(newsport, sportsequip);
                    Console.WriteLine($"You reserved a {sportsequip.name}");
                    count1++;
                }
                else if (sportsequip.id >= 500 && sportsequip.id <= 600) Console.WriteLine("Sorry these equipments is already booked by another activity.. ");
                
                if (count1 == totalequip) break;
            }
            foreach (Largeequipment sportsequip in equipment.Read<Largeequipment>("name", equipname))
            {
                if (sportsequip.id > 0)
                {
                    Console.WriteLine($"Notification sent to id:({sportsequip.id}) email and number to return equipment for the group activity");
                    sportsequip.id = uniqueid;
                    sportsequip.isBooked = true;
                    Largeequipment newsport = new Largeequipment(sportsequip.name, sportsequip.id, sportsequip.uniqueID, sportsequip.isBooked);
                    equipment.Update<Largeequipment>(newsport, sportsequip);
                    Console.WriteLine($"You reserved a {sportsequip.name}");
                    count2++;
                }
                else if (sportsequip.id >= 500 && sportsequip.id <= 600) Console.WriteLine("Sorry these equipments is already booked by another activity.. ");

                if (count2 == totalequip) break;
            }
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
                if (space1.id > 0)
                {
                    Console.WriteLine($"Notification sent to id:({space1.id}) email and number that the space is been booked for a group activity");
                    space1.id = uniqueid;
                    space1.isBooked = true;
                    Space newspace = new Space(space1.category,space1.id,space1.uniqueID,space1.isBooked);
                    space.Update<Space>(newspace,space1);
                    Console.WriteLine($"you reserved {space1.category}");
                    break;

                }
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
        public void UpdateActivity()
        {
            GymDatabaseContext updateactivity = new GymDatabaseContext();
            ViewSchedule();
            Console.Write("What activity do you want to update?");
            string choise = Console.ReadLine();
            foreach (GroupSchedule activity in updateactivity.Read<GroupSchedule>("name",choise))
            {
                if (activity.name == choise)
                {
                    Console.WriteLine($"[1]name:{activity.name}, [2]participant limit:{activity.participantLimit}, [3]instructor:{activity.instructor}"); //  [4]time:{activity.timeSlot} 
                    Console.WriteLine("what do you want to update?");
                    int change = Convert.ToInt32(Console.ReadLine());
                    if (change == 1)
                    {
                        Console.Write("name:");
                        string id = Console.ReadLine();
                        activity.name = id;
                        GroupSchedule newgroup = new GroupSchedule(activity.name,activity.participantLimit,activity.instructor,activity.uniqueID);
                        updateactivity.Update<GroupSchedule>(newgroup,activity);
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
                        Console.WriteLine($"Activity particpant limit has been updated to({activity.participantLimit})");
                        break;
                    }
                    else if (change == 3)
                    {
                        Console.Write("instructor:");
                        string person = Console.ReadLine();
                        activity.instructor= person;
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
            }
        }
    }
}

