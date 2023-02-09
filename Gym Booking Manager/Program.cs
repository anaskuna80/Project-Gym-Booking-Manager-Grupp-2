using Gym_Booking_Manager;
using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Program 
    {
        static void Main(string[] args)
        {

            Space space = new Space(Space.Category.Hall, "Emil");
            GymDatabaseContext spaces = new GymDatabaseContext();           
            spaces.Create<Space>(space);
            Space space1 = new Space(Space.Category.Studio, "Erik");
            spaces.Create<Space>(space1);
            Staff user = new Staff("emil");
            spaces.Create<Staff>(user);
            Staff user1 = new Staff("Erik");
            spaces.Create<Staff>(user1);
            
            
        }       // Static methods for the program
    }
}