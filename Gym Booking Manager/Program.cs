using Gym_Booking_Manager;
using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Program: MenuSystem
    {
        static void Main(string[] args)
        {
          MainMenu(); 
        }

        // Static methods for the program
    }
}