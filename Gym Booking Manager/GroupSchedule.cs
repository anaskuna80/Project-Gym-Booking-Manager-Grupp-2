using Gym_Booking_Manager.Database;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
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

        public GroupSchedule(string name, int participantlimit, string instructor) : base(name, participantlimit, instructor)
        {
            this.activites = new List<GroupActivity>();
        }

        public GroupSchedule(Dictionary<String, String> constructionArgs) : base( constructionArgs)
        {
           

        }
        public static void ViewSchedule()
        {
            //GymDatabaseContext equipment = new GymDatabaseContext();
            Console.WriteLine("All schedule:");
            PostgreSQLDatabase.readAndPrintAllRecord("GroupActivity");

            //foreach (GroupSchedule activity in equipment.Read<GroupSchedule>())
            //{
            //    Console.WriteLine(activity);
            //}

        }
        public static void AddActivity()
        {
            GymDatabaseContext equipment = new GymDatabaseContext();
            GymDatabaseContext space = new GymDatabaseContext();
            Console.Write("Name of your Activity:");
            string name = Console.ReadLine();
            Console.Write("How many participants?:");
            int participantlimit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Set id for the instructor?:");
            string instuctor = Console.ReadLine();
            Console.Write("Set id for the customer");
            int uniqueid = Convert.ToInt32(Console.ReadLine());
            GroupActivity activity = new GroupActivity(name,participantlimit,instuctor);
            Console.WriteLine("Sports equipment:");
            PostgreSQLDatabase.readAndPrintAllRecord("SportsEquipment");

            //foreach (SportsEquipment sportsequip in equipment.Read<SportsEquipment>())
            //{

            //    Console.WriteLine(sportsequip.CSVify());

            //}
            Console.WriteLine();
            Console.WriteLine("Large equipment:");
            PostgreSQLDatabase.readAndPrintAllRecord("LargeEquipment");

            //foreach (LargeEquipment largeequip in equipment.Read<LargeEquipment>())
            //{

            //    Console.WriteLine(largeequip.CSVify());

            //}
            Console.WriteLine("--------------------------------------------------");
            Console.Write("name of the equipment you need?");
            string equipname = Console.ReadLine();
            string time = Calendar.AddTime();
            Console.Write("how many?");
            int totalequip = Convert.ToInt32(Console.ReadLine());
            int count1 = 0;
            int count2 = 0;
            Calendar newsport = new Calendar(equipname, name, uniqueid, time);
            PostgreSQLDatabase.createRecord(newsport);

            //foreach (SportsEquipment sportsequip in equipment.Read<SportsEquipment>("name", equipname))
            //{


            //        Calendar newsport = new Calendar(sportsequip.name,name, 2,time);
            //        equipment.Create<Calendar>(newsport);
            //        count1++;



            //    if (count1 == totalequip) break;
            //}
            //if (count1 > 0) Console.WriteLine($"You reserved {count1}.");

            //foreach (LargeEquipment sportsequip in equipment.Read<LargeEquipment>("name", equipname))
            //{
                
                   
            //        Calendar newsport = new Calendar(sportsequip.name, name, 2, time);
            //        equipment.Create<Calendar>(newsport);
            //        count2++;
            //        if (count2 == totalequip) break;


            //}
            //if(count2 > 0 ) Console.WriteLine($"You reserved {count2}.");
            Console.WriteLine();
            PostgreSQLDatabase.readAndPrintAllRecord("Space");

            //foreach (Space spaces in space.Read<Space>())
            //{
            //    Console.WriteLine(spaces);
            //}
            Console.WriteLine("--------------------------------------------------");
            Console.Write("What space do you need?:");
            string choise = Console.ReadLine();
            Calendar newspace = new Calendar(choise, name, uniqueid, time);
            PostgreSQLDatabase.createRecord(newspace);


            //foreach (Space space1 in space.Read<Space>("category", choise))
            //{
           
                    
            //        Calendar newspace = new Calendar(space1.category.ToString(), name, 2, time);
            //        //Calendar newspace = new Calendar(space1.uniqueID, space1.category.ToString(), name, uniqueid, time);
            //        space.Create<Calendar>(newspace);
            //        Console.WriteLine($"you reserved {space1.category}");
            //        break;

                
            //}
            

            //this.activites.Add(activity);
            //equipment.Create<GroupSchedule>(activity);
            PostgreSQLDatabase.createRecord(activity);

        }
        public static void RemoveActivity()
        {
            GymDatabaseContext grpactivity= new GymDatabaseContext();
            ViewSchedule();
            Console.Write("What Activity do you want to remove?, enter the id of it:");
            int remove = int.Parse(Console.ReadLine());
            PostgreSQLDatabase.deleteRecord("GroupActivity", remove);
            //foreach (GroupSchedule activity in grpactivity.Read<GroupSchedule>("name", remove))
            //{
            //    grpactivity.Delete<GroupSchedule>(activity);
            //    Console.WriteLine($"You have removed {activity.name} from the groupschedule");
            //}
        }
        public static void UpdateActivity()
        {
            //GymDatabaseContext updateactivity = new GymDatabaseContext();
            ViewSchedule();
            Console.Write("type the id of the activty:");
            int choise = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("what do you want to update?");
            Console.WriteLine("1:Name 2:Participantlimit 3:Instructor");
            try
            {
                int change = Convert.ToInt32(Console.ReadLine());
                if (change == 1)
                {
                    Console.Write("New name:");
                    string name = Console.ReadLine();
                    PostgreSQLDatabase.updateRecord("GroupActivity", choise,"name",name);
                    Console.WriteLine($"Activity name has been updated to({name})");
                    
                }
                else if (change == 2)
                {
                    Console.Write("New participant limit:");
                    string max = Console.ReadLine();
                    PostgreSQLDatabase.updateRecord("GroupActivity", choise, "participantLimit", max);
                    Console.WriteLine($"Activity participant limit has been updated to({max})");
                    
                }
                else if (change == 3)
                {
                    Console.Write("New instructor:");
                    string person = Console.ReadLine();
                    PostgreSQLDatabase.updateRecord("GroupActivity", choise, "instructor", person);
                    Console.WriteLine($"Activity instructor has been updated to({person})");
                  
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
            } 
        }
    }
}

