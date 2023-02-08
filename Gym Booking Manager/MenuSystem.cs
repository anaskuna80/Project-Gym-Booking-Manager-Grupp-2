using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class MenuSystem
    {
        static void MainMenu()
        {
            Console.WriteLine(" *** Gym Booking Manager ***");
            Console.WriteLine("Welcome, you need to login, please enter your userID: ");
            string userID = Console.ReadLine();
            // Check the database that UserID exists...
            if (userID == "0")
            {
                throw new IndexOutOfRangeException(); // Please delete this...
            }
            // If user X exists program proceed, else system will ask for a new userID.
            Console.Write($"User {userID} password: ");
            // Check if password is correct. A counter will appear if the entered password was wrong that say the user have 2 chances left of 3.
            // If the user entered right credentials we go in to next screen:
            Console.Write("********************************************************************************************\n");
            Console.Write("*  User: <username>  *** Logged in <timestamp> *** Type of account: <accounttype>          *\n");
            Console.Write("********************************************************************************************\n");
            Console.WriteLine("");
            Console.Write("********************************************************************************************\n");
            //Here we write the menu considered about accounttype:
            Console.Write("*__Menu________________________________*\n");
            Console.Write("*                                      *\n");
            Console.Write("* View Log [Admin]                     *\n");
            Console.Write("* View Group Schedule [Admin, Staff]   *\n");
            Console.Write("* View Log [Admin]                     *\n");
            Console.Write("* Make reservation                     *\n");
            Console.Write("* Cancel Reservation                   *\n");
            Console.Write("* Daypass                              *\n");
            Console.Write("* Membership                           *\n");
            Console.Write("* Add User                             *\n");
            Console.Write("* Delete User                          *\n");
            Console.Write("*                                      *\n");
            Console.Write("*                                      *\n");
        }
    }
}
