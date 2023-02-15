using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Gym_Booking_Manager
{
    
    public static class MenuSystem 
    {
        private static int id;

        public static void Login()
        {
            LocalStorage userdata = new LocalStorage();
            string userID = "";
            string password = "";
            int count = 0;
            Console.Write("   ┌───────────────────────────────────────┐\n");
            Console.Write("   │  Gym Booking Manager (Grp2 Version)   │\n");
            Console.Write("   │              LOGIN SCREEN             │\n");
            Console.Write("   │                                       │\n");
            Console.Write("   │"); 
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("                  Type 'quit' to quit");        
            Console.ResetColor();
            Console.Write("  │\n");
            Console.Write("   └───────────────────────────────────────┘\n\n");
            do
            {
                Console.Write("   Please enter User ID: ");
                userID = Console.ReadLine();
                if (userID == "quit".ToLower())
                {
                    Console.WriteLine("   Good Bye!");
                    break;
                }
                if (userID != "")
                {

                    if (userdata.staffs.read("id", userID).Count == 0 && userdata.customer.read("id",userID).Count == 0)
                    {
                        Console.WriteLine($" {userID} was not found in the database");
                    }
                    foreach (Staff user in userdata.staffs.read("id", userID))
                    {
                        Console.WriteLine($"   User {userID} selected");
                        do
                        {
                            Console.Write($"   [Try: {count} / 5]\n   Please enter password for <{userID}>: ");
                            password = Console.ReadLine();
                            if (password != "")
                            {
                                if (user.password == password)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"    Welcome {user.name}!");
                                    StaffMenuMain(user.id);
                                }
                                else
                                {
                                    Console.WriteLine(" Incorrect password");
                                    count++;
                                }
                            }
                            else
                            {
                                Console.WriteLine(" Please type ur password");
                                count++;
                            }
                        }while(count != 5);
                    }
                    foreach (Customer user in userdata.customer.read("id", userID))
                    {
                        Console.WriteLine($" User {userID} selected");
                        do
                        {
                            Console.Write($"   [Try: {count} / 5]\n   Please enter password for <{userID}>: ");
                            password = Console.ReadLine();
                            if (password != "")
                            {
                                if (user.password == password)
                                {
                                    count = 5;
                                    Console.WriteLine($"   Welcome {user.name}!");
                                    int id = user.id;
                                    MemberCustomerMenu();
                                }
                                else
                                {
                                    Console.WriteLine("   Incorrect password!");
                                    count++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("  Please type password");
                                count++;
                            }
                        } while (count != 5);
                    }
                }
                else
                {
                    Console.WriteLine("   Please type a valid UserID to continue.");
                }
            } while (userID != "quit".ToLower() || userID != "stop".ToLower());
            
        }
        //This menu will appear when a user of the type "staff" logged in: 
        public static void StaffMenuMain(int id)
        {
            do
            {

                Console.Write("   ┌────────────────┐                                          \n");
                Console.Write("   │   Main Menu    │                                          \n");
                Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
                Console.Write("   │-- [1] Calendar                                           │\n");
                Console.Write("   │-- [2] Equipment                                          │\n");
                Console.Write("   │-- [3] Spaces                                             │\n");
                Console.Write("   │-- [4] Users                                              │\n");
                Console.Write("   │-- [5] Group Schedule                                     │\n");
                Console.Write("   │                                                          │\n");
                Console.Write("   │-- [6] Help                                               │\n");
                Console.Write("   │-- [7] Logout/Exit                                        │\n");
                Console.Write("   └──────────────────────────────────────────────────────────┘\n");
                Console.Write("   >> ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Entering Calendar.");
                        Linger();
                        StaffMenuCalendar(id);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Entering Equipment.");
                        StaffMenuEquipment(id);
                        Linger();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Entering Spaces.");
                        Linger();
                        StaffMenuSpaces(id);
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Entering Users.");
                        Linger();

                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   EnteringGroupSchedule.");
                        Linger();
                        StaffMenuGroupSchedule(id);
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Entering Help.");
                        Linger();
                        StaffHelp();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Logging out.");
                        Linger();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("   Invalid choice!");
                        break;
                }
            } while (true);
        }
        public static void StaffMenuGroupSchedule(int id)
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Spaces       │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View all Group Activities                          │\n");
            Console.Write("   │-- [2] Add  Group activity                                │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [3] Help                                               │\n");
            Console.Write("   │-- [4] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    Console.WriteLine("Group Activities:");
                    Console.WriteLine();
                    GroupSchedule.ViewSchedule();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("\n Add Group Activity");
                    Console.WriteLine("------------------------------------------------");
                    GroupSchedule.AddActivity();


                    break;

                case "5":
                    Console.WriteLine("\n Help");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Welcome to the Help section of the Group Menu!");
                    Console.WriteLine("\n [1] - View Group Activitys");
                    Console.WriteLine("Displays of all Group Activitys.");
                    Console.WriteLine("\n [2] - Add Group Activity");
                    Console.WriteLine("Allows you to add a Group Activity.");
                    Console.WriteLine("\n [6] - Main Menu");
                    Console.WriteLine("Returns you to the Main Menu.");
                    Console.WriteLine("------------------------------------------------");
                    break;

                case "6":
                    Console.Clear();
                    StaffMenuMain(id);
                    break;
                default:
                    Console.WriteLine("\n Invalid selection. Please try again.");
                    StaffMenuGroupSchedule(id);
                    break;
            }

        }
        public static void StaffMenuCalendar(int id)
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Calendar     │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View All Reservations                              │\n");
            Console.Write("   │-- [2] Vacant Reservations                                │\n");
            Console.Write("   │-- [3] Make Reservation                                   │\n");
            Console.Write("   │-- [4] Delete Reservation(s)                              │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");           
            Console.Write(">> ");
            string val = Console.ReadLine();
            switch (val) 
            {
                case "1":
                    Console.Write("Coming soon...");
                    break;
                case "2":
                    Console.Write("Coming soon...");
                    break;
                case "3":
                    Console.Write("Coming soon...");
                    break;
                case "4":
                    Console.Write("Coming soon...");
                    break;
                case "5":
                    Console.Write("Coming soon...");
                    break;
                case "6":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   Entering Main Menu.");
                    Linger();
                    StaffMenuMain(id);
                    break;
            }
        }
        public static void StaffMenuEquipment(int id)
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Equipment    │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] List of Equipments                                 │\n");
            Console.Write("   │-- [2] Reserve Equipment                                  │\n");
            Console.Write("   │-- [3] Reserve Large Equipment                            │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write(">> ");
            string selection = Console.ReadLine();
            GymDatabaseContext equipment = new GymDatabaseContext();
            switch (selection)
            {
                case "1":
                    Console.WriteLine("Largeequipment:");
                    Console.WriteLine();
                    foreach (Largeequipment largeequip in equipment.Read<Largeequipment>())
                    {
                        
                            Console.WriteLine(largeequip.CSVify());
                        
                    }
                    Console.WriteLine();
                    Console.WriteLine("Sportsequipment:");
                    Console.WriteLine();
                    foreach (Sportsequipment sportsequip in equipment.Read<Sportsequipment>())
                    {
                        
                            Console.WriteLine(sportsequip.CSVify());
                        
                    }
                    break;

                case "2":
                    Console.WriteLine("\n Reserve Sportsequipment");
                    Console.WriteLine("------------------------------------------------");
                    Console.Write("Enter the name of the equipment you wish to reserve: ");
                    string equipmentName = Console.ReadLine();
                    

                    foreach (Sportsequipment sportsequip in equipment.Read<Sportsequipment>("name", equipmentName))
                    {
                        if (sportsequip.isBooked == false)
                        {
                            
                            
                            sportsequip.id = id;
                            sportsequip.isBooked = true;
                            Sportsequipment newsport = new Sportsequipment(sportsequip.name, sportsequip.id, sportsequip.uniqueID, sportsequip.isBooked);
                            equipment.Update<Sportsequipment>(newsport,sportsequip);
                            Console.WriteLine($"You reserved {sportsequip.name}");
                        }
                    }


                    break;
                case "3":
                    Console.WriteLine("\n Reserve Large equipment");
                    Console.WriteLine("------------------------------------------------");
                    Console.Write("Enter the name of the equipment you wish to reserve: ");
                    string equipmentName1 = Console.ReadLine();

                    foreach (Largeequipment largeequip in equipment.Read<Largeequipment>("name", equipmentName1))
                    {
                        if (largeequip.isBooked == false)
                        {
                            largeequip.id = id;
                            largeequip.isBooked = true;
                            Largeequipment newsport = new Largeequipment(largeequip.name, largeequip.id, largeequip.uniqueID, largeequip.isBooked);
                            Console.WriteLine($"You reserved {largeequip.name}");
                        }
                    }
                    break;
                case "5":
                    Console.WriteLine("\n Help");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Welcome to the Help section of the Equipment Menu!");
                    Console.WriteLine("\n [1] - List of equipment");
                    Console.WriteLine("Displays a list of all equipments.");
                    Console.WriteLine("\n [2] - Reserve Equipment");
                    Console.WriteLine("Allows you to reserve a specific piece of equipment.");
                    Console.WriteLine("\n [6] - Main Menu");
                    Console.WriteLine("Returns you to the Main Menu.");
                    Console.WriteLine("------------------------------------------------");
                    break;
                    
                case "6":
                    Console.Clear();
                    StaffMenuMain(id);
                    break;
                default:
                    Console.WriteLine("\n Invalid selection. Please try again.");
                    StaffMenuEquipment(id);
                    break;
            }
        }

        public static void StaffMenuSpaces(int id)
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Spaces       │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View Booked Spaces                                 │\n");
            Console.Write("   │-- [2] Reserve Space                                      │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [3] Help                                               │\n");
            Console.Write("   │-- [4] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            string selection = Console.ReadLine();
            GymDatabaseContext space1 = new GymDatabaseContext();
            switch (selection)
            {
                case "1":
                    Console.WriteLine("Booked Spaces:");
                    Console.WriteLine();
                    foreach (Space place in space1.Read<Space>())
                    {

                        Console.WriteLine(place.CSVify());

                    }
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("\n Reserve Space");
                    Console.WriteLine("------------------------------------------------");
                    Console.Write("Enter the name of the space you wish to reserve: ");
                    string space2 = Console.ReadLine();


                    foreach (Space place2 in space1.Read<Space>("category", space2))
                    {
                        if (place2.isBooked == false)
                        {


                            place2.id = id;
                            place2.isBooked = true;
                            Space newspace = new Space(place2.uniqueID, place2.category, place2.id, place2.isBooked);
                            space1.Update<Space>(newspace, place2);
                            Console.WriteLine($"You reserved {place2.uniqueID}");
                            break;
                        }
                    }


                    break;
                
                case "5":
                    Console.WriteLine("\n Help");
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("Welcome to the Help section of the Spaces Menu!");
                    Console.WriteLine("\n [1] - View Booked Spaces");
                    Console.WriteLine("Displays of all booking spaces.");
                    Console.WriteLine("\n [2] - Reserve Space");
                    Console.WriteLine("Allows you to reserve a specific place of space.");
                    Console.WriteLine("\n [6] - Main Menu");
                    Console.WriteLine("Returns you to the Main Menu.");
                    Console.WriteLine("------------------------------------------------");
                    break;

                case "6":
                    Console.Clear();
                    StaffMenuSpaces(id);
                    break;
                default:
                    Console.WriteLine("\n Invalid selection. Please try again.");
                    StaffMenuSpaces(id);
                    break;
            }

        }
        public static void StaffMenuUsers(int id)
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   User Menu    │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Add User                                           │\n");
            Console.Write("   │-- [2] Delete User                                        │\n");
            Console.Write("   │-- [3] Sell Membership                                    │\n");
            Console.Write("   │-- [4] Sell Daypass                                       │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.WriteLine(" >>");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.Write("Do you want to add staff or customer?");
                string input1 = Console.ReadLine();
                if (input1 == "staff") UserMgmt.AddStaff();
                else if(input1 == "customer") UserMgmt.AddCustomer();
            }
            else if (input == "2")
            {
                Console.Write("Do you want to delete staff or customer?");
                string input2 = Console.ReadLine();
                if (input2 == "staff") UserMgmt.DelStaff();
                else if (input2 == "customer") UserMgmt.DelCustomer();
            }
            else if (input == "3")
            {
                //NYI
            }
            else if (input == "4")
            {
                //NYI
            }
            else if (input == "5")
            {
                //NYI
            }
            else if (input == "6")
            {
                Console.Clear();
                StaffMenuMain(id);
            }
        }

        //TBD
        public static void MemberCustomerMenu()
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Main Menu    │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
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
        }
        public static void NonMemberCustomerMenu()
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Main Menu    │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View Calendar                                      │\n");
            Console.Write("   │-- [2] Buy Membership                                     │\n");
            Console.Write("   │-- [3] Buy Daypass                                        │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [4] Help                                               │\n");
            Console.Write("   │-- [5] Logout/Exit                                        │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
        }


        public static void AdminMenuMain()
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Main Menu    │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
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
        }
        public static void AdminMenuCalendar()
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Calendar     │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View All Reservations                              │\n");
            Console.Write("   │-- [2] Vacant Reservations                                │\n");
            Console.Write("   │-- [3] Make Reservation                                   │\n");
            Console.Write("   │-- [4] Delete Reservation                                 │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                  You are at --> Calendar Menu \n");
        }
        public static void AdminMenuUser()
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Calendar     │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Add User                                           │\n");
            Console.Write("   │-- [2] Delete User                                        │\n");
            Console.Write("   │-- [3] Sell Membership                                    │\n");
            Console.Write("   │-- [4] Sell Daypass                                       │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                     You are at --> Users Menu \n");
        }
        public static void Linger()
        {
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.ResetColor();
            Console.Clear();
        }

        public static void StaffHelp() 
        {
            Console.WriteLine("   To be applied");
        }
        public static void CostumerHelp()
        {
            Console.WriteLine("   Sorry, coming soooooooon!");
        }
    }

    /*
    Use any of this:?

                Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
                Console.Write("   │ User: <username>              Logged in <DD/MM HH:MM:SS> │\n");
                Console.Write("   └──────────────────────────────────────────────────────────┘\n");

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