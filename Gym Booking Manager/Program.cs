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
<<<<<<< HEAD
          MainMenu(); 
=======
            User userContext;
            /*
             * var calendar = new Calendar();
            var room = new Room("Meeting Room 1", 10);

            calendar.MakeReservation(room, new DateTime(2022, 11, 15, 10, 0, 0), new DateTime(2022, 11, 15, 12, 0, 0));
            var reservations = calendar.GetSlice(new DateTime(2022, 11, 1), new DateTime(2022, 11, 30));
            foreach (var reservation in reservations)
            {
                Console.WriteLine("Reserved by: " + reservation.Owner.Name + " from " + reservation.Start + " to " + reservation.End);
            }

            calendar.CancelReservation(reservations[0]);
            reservations = calendar.GetSlice(new DateTime(2022, 11, 1), new DateTime(2022, 11, 30));
            Console.WriteLine("After cancellation:");
            foreach (var reservation in reservations)
            {
                Console.WriteLine("Reserved by: " + reservation.Owner.Name + " from " + reservation.Start + " to " + reservation.End);
            }
            */
>>>>>>> master
        }

        // Static methods for the program
    }
}