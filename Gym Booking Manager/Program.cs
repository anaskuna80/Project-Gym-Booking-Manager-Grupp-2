using Gym_Booking_Manager;
using System.Runtime.CompilerServices;
using System.Xml;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Program 
    {
        
        static void Main(string[] args)
        {
            string choice;
            do 
            {



                MenuSystem.Login();
                Console.Write("   Retry Login? y/n\n   >> ");
                choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    Console.Clear();
                    MenuSystem.Login();
                }
                else if (choice == "n")
                {
                    Console.Write("\n   Bye, then!");
                    Environment.Exit(0); 
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.Write("\n   Invalid command!");
                    Console.ResetColor();
                }
            } while (true);


            /*
            Space space = new Space(Space.Category.Hall, "Emil");
            GymDatabaseContext spaces = new GymDatabaseContext();           
            spaces.Create<Space>(space);
            Space space1 = new Space(Space.Category.Studio, "Erik");
            spaces.Create<Space>(space1);
            Staff user = new Staff("emil","1","hej@hej","0903432423","hej123");
            spaces.Create<Staff>(user);
            Staff user1 = new Staff("erik", "2", "hej1@hej1", "070123424", "hej12345");
            spaces.Create<Staff>(user1);
            GymDatabaseContext spaces = new GymDatabaseContext(); 

            spaces.Read<Staff>("id", "2");

            

            MenuSystem.Login();
            //UserMgmt.AddStaff();
            //UserMgmt.DelStaff();
            //MenuSystem.StaffMenuEquipment();
            //GroupSchedule activity = new GroupSchedule();
            //activity.AddActivity();*/
            // Static methods for the program
            
            

        }
    }
}