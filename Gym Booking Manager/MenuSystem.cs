using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    public static class MenuSystem
    {
        public static void StartMenu()
        {
            Console.WriteLine(" *** Gym Booking Manager ***");
            Console.WriteLine("Welcome, you need to login, please enter your userID: ");
            string userID = Console.ReadLine();
            // Check the database that UserID exists...
            if (userID == null)
            {
                throw new NotImplementedException(); // Please delete this...
            }
            // If user X exists program proceed, else system will ask for a new userID.
            Console.Write($"User {userID} password: ");
            // Check if password is correct. A counter will appear if the entered password was wrong that say the user have 2 chances left of 3.
            // If the user entered right credentials we go in to next screen:
        }
        public static void AdminMenuMain()
        {
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │ User: <username>              Logged in <DD/MM HH:MM:SS> │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Calendar                                           │\n");
            Console.Write("   │-- [2] Equipment                                          │\n");
            Console.Write("   │-- [3] PT                                                 │\n");
            Console.Write("   │-- [4] Schedules                                          │\n");
            Console.Write("   │-- [5] Spaces                                             │\n");
            Console.Write("   │-- [6] User                                               │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [7] Help                                               │\n");
            Console.Write("   │-- [8] Logout/Exit                                        │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                                  > Main Menu  \n");
            //AdminMenuUser();
        }
        public static void AdminMenuCalendar()
        {
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │ User: <username>              Logged in <DD/MM HH:MM:SS> │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View All Reservations                              │\n");
            Console.Write("   │-- [2] Vacant Reservations                                │\n");
            Console.Write("   │-- [3] Make Reservation                                   │\n");
            Console.Write("   │-- [4] Delete Reservation                                 │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                             > Main / Calendar \n");
        }
        public static void AdminMenuUser()
        {
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │ User: <username>              Logged in <DD/MM HH:MM:SS> │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Add User                                           │\n");
            Console.Write("   │-- [2] Delete User                                        │\n");
            Console.Write("   │-- [3] Sell Membership                                    │\n");
            Console.Write("   │-- [4] Sell Daypass                                       │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                                 > Main / User \n");

        }
       
        public static void StaffMenu()
        {
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │ User: <username>              Logged in <DD/MM HH:MM:SS> │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Calendar                                           │\n");
            Console.Write("   │-- [2] Equipment                                          │\n");
            Console.Write("   │-- [3] PT                                                 │\n");
            Console.Write("   │-- [4] Schedules                                          │\n");
            Console.Write("   │-- [5] Spaces                                             │\n");
            Console.Write("   │-- [6] User                                               │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [7] Help                                               │\n");
            Console.Write("   │-- [8] Logout/Exit                                        │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                                  > Main Menu  \n");
        }
        public static void CustomerMenu()
        {
            // if customer == member = true then type this
            Console.WriteLine($"<user>(Member) --- Main Menu");
            Console.Write("---------------------------------------------------------");
            Console.Write("-- Calendar Menu");
            // else type this
            Console.WriteLine($"<user>(Non Member Customer) --- Main Menu");
            Console.Write("---------------------------------------------------------");
        }

    }

/*
Use any of this:?
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace Gym_Booking_Manager
{
    public class MenuSystem
    {
        private const string UsersFilePath = "Users.csv";
        public static void MainMenu()
        {
            Console.WriteLine(" *** Gym Booking Manager ***");
            Console.WriteLine("Welcome, you need to login, please enter your userID: ");
            string userID = Console.ReadLine();
            // Check if user exists in the database
            User user = GetUser(userID);
            if (user == null)
            {
                Console.WriteLine("User does not exist, would you like to create a new user?");
                string input = Console.ReadLine();
                if (input.ToLower() == "yes")
                {
                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter phone number:");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Enter email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter account type (Customer/Staff):");
                    string accountType = Console.ReadLine();
                    // Create new user and add it to the database
                    User newUser = new User()
                    {
                        id = userID,
                        name = name,
                        phone = phone,
                        email = email,
                        accountType = accountType
                    };
                    AddUser(newUser);
                }
                else
                {
                    Console.WriteLine("User creation cancelled.");
                    return;
                }
            }
            // User exists or has been created, continue with the program
            Console.WriteLine($"Welcome, {user.name}");
            Console.WriteLine("Type of account: " + user.accountType);
            // Program logic for displaying the main menu
            Console.WriteLine("Main menu options:");
            Console.WriteLine("1. View Log [Admin]");
            Console.WriteLine("2. View Group Schedule [Admin, Staff]");
            Console.WriteLine("3. Make reservation");
            Console.WriteLine("4. Cancel reservation");
            Console.WriteLine("5. Daypass");
            Console.WriteLine("6. Membership");
            Console.WriteLine("7. Add User");
            Console.WriteLine("8. Delete User");
        }
        private static User GetUser(string userID)
        {
            if (!File.Exists(UsersFilePath))
            {
                return null;
            }
            string[] lines = File.ReadAllLines(UsersFilePath);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (fields[0] == userID)
                {
                    User user = new User()
                    {
                        id = fields[0],
                        name = fields[1],
                        phone = fields[2],
                        email = fields[3],
                        accountType = fields[4]
                    };
                    return user;
                }
            }
            return null
}
*/
}