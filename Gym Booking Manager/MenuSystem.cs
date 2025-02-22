﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using Gym_Booking_Manager.Database;

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
            string staffOrCustomer = "";
            object[]? staff = null;
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
                try
                {
                    Console.WriteLine("Are you logging in as staff or customer?");
                    Console.WriteLine("1: Staff");
                    Console.WriteLine("2: Customer");
                    Console.Write(">> ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        staffOrCustomer = "staff";
                    }
                    else if (choice == 2)
                    {
                        staffOrCustomer = "customer";
                    }
                    else
                    {
                        Console.WriteLine("Wrong input!");                    
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\x1b[41m Invalid input!\x1b[0m \nPress Any Key To Retry...");
                    Console.ReadKey();
                    Console.Clear();
                    Login();
                }

                Console.Write("   Please enter User ID: ");
                
                userID = Console.ReadLine();
                if (userID == "quit".ToLower())
                {
                    Console.WriteLine("   Login Aborted!");
                    break;
                }
                staff = PostgreSQLDatabase.readRecord(staffOrCustomer, Convert.ToInt32(userID));
                if (userID != "")
                {

                    if (staff == null) //(userdata.staffs.read("id", userID).Count == 0 && userdata.customer.read("id",userID).Count == 0)
                    {
                        Console.WriteLine($" {userID} was not found in the database");
                    }
                
                    else if (staff != null) //foreach (Staff user in userdata.staffs.read("id", userID))
                    {
                        Console.WriteLine($"   User {userID} selected");
                        do
                        {
                        Console.Write($"   [Try: {count} / 5]\n   Please enter password for <{userID}>: ");
                        password = Console.ReadLine();
                        if (password != "")
                        {
                            if (Convert.ToString(staff[4]) == password)
                            {
                                Console.Clear();
                                Console.WriteLine($"    Welcome {staff[1]}!");
                                StaffMenuMain(Convert.ToInt32(staff[0]));
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
                    } while (count != 5);

                    /*foreach (Customer user in userdata.customer.read("id", userID))
                    {
                        Console.WriteLine($" User {userID} selected");
                        if (Convert.ToInt32(userID) > 300 && Convert.ToInt32(userID) < 500)
                        {
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
                                        int id = 2;//user.id;
                                        NonMemberCustomerMenu();
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
                        else if (Convert.ToInt32(userID) > 100 && Convert.ToInt32(userID) < 300)
                        {

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
                                        int id = 2;//user.id;
                                        MemberCustomerMenu(id);
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
                        }*/
                }
                }
                else
                {
                    Console.WriteLine("   Please type a valid UserID to continue.");
                }
            } while (userID != "quit".ToLower() || userID != "stop".ToLower());
            
        }

        // ----- HERE IS THE STAFF DOMAIN! ------------------------------------------------------------------------------------------------
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
                Console.Write("   │-- [6] Personal Trainer                                   │\n");
                Console.Write("   │-- [7] Restricted Items                                   │\n");
                Console.Write("   │                                                          │\n");
                Console.Write("   │-- [8] Help                                               │\n");
                Console.Write("   │-- [9] Logout/Exit                                        │\n");
                Console.Write("   └──────────────────────────────────────────────────────────┘\n");
                Console.Write("   >> ");
                try
                {
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
                            Linger();
                            StaffMenuEquipment(id);                           
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
                            StaffMenuUsers(id);
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("   Entering GroupSchedule.");
                            Linger();
                            StaffMenuGroupSchedule(id);
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("   Entering Personal Trainer.");
                            Linger();
                            StaffMenuPT();
                            break;
                        case 7:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("   Entering Restrict items."); //Restrict items or unrestrict item
                            Linger();
                            StaffMenuRestrict();
                            break;
                        case 8:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("   Entering Help.");
                            Linger();
                            StaffHelp();
                            break;
                        case 9:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("   Logging out.");
                            Linger();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("   Invalid choice!");
                            Linger();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   Invalid choice!\n   Please enter a valid selection!!!\n   Press any key to proceed...");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n   OK.");
                    Linger();
                }
            } while (true);
        }
        public static void StaffMenuGroupSchedule(int id)
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │ Group Schedule │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View All Group Activities                          │\n");
            Console.Write("   │-- [2] Add Group Activity                                 │\n");
            Console.Write("   │-- [3] Remove Group Activity                              │\n");
            Console.Write("   │-- [4] Update Group Activity                              │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    Console.Write("\nAll Group Activities:\n");
                    Console.Write("──────────────────────────────────────────────────────────\n\n");
                    GroupSchedule.ViewSchedule();
                    break;

                case "2":
                    Console.Write("\n Add Group Activity\n");
                    Console.Write("──────────────────────────────────────────────────────────\n\n");
                    GroupSchedule.AddActivity();
                    break;
                case "3":
                    Console.Write("\n Remove Group Activity\n");
                    Console.Write("──────────────────────────────────────────────────────────\n\n");
                    GroupSchedule.RemoveActivity();
                    break;
                case "4":
                    Console.Write("\n Update Group Activity\n");
                    Console.Write("──────────────────────────────────────────────────────────\n\n");
                    GroupSchedule.UpdateActivity();
                    break;

                case "5":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   Going back to Main Menu.");
                    Linger();
                    StaffMenuMain(id);
                    break;
                default:
                    Console.WriteLine("\n Invalid selection. Please try again.");
                    StaffMenuGroupSchedule(id);
                    break;
            }

        }
        public static void CustomerMenuGroupSchedule(int id)
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │ Group Schedule │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View All Group Activities                          │\n");
            Console.Write("   │-- [2] Sign up to Group activity                          │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
            string selection = Console.ReadLine();
            while (true)
            {
                switch (selection)
                {
                    case "1":
                        Console.Write("\nAll Group Activities:\n");
                        Console.Write("──────────────────────────────────────────────────────────\n\n");
                        GroupSchedule.ViewSchedule();
                        break;

                    case "2":
                        Console.Write("\n Sign up to Group Activity\n");
                        Console.Write("──────────────────────────────────────────────────────────\n\n");
                        GroupSchedule.ViewSchedule();
                        GymDatabaseContext activity = new GymDatabaseContext();
                        Console.WriteLine("What activity do you want to sign up for?");
                        string choise = Console.ReadLine();
                        foreach (GroupSchedule act in activity.Read<GroupSchedule>("name", choise))
                        {
                            act.SignUp(id);
                        }

                        break;

                    case "5":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Going back to Main Menu.");
                        Linger();
                        StaffMenuMain(id);
                        break;
                    default:
                        Console.WriteLine("\n Invalid selection. Please try again.");
                        StaffMenuGroupSchedule(id);
                        break;
                }
            }
           
        }
        public static void StaffMenuPT()
        {
            Console.Write("   ┌────────────────┐                                                                             \n");
            Console.Write("   │   PT           │                                                                             \n");
            Console.Write("   ├────────────────┴────────────────────────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View Available Personal Trainers   -   Displays of all available personal trainers.   │\n");
            Console.Write("   │-- [2] Book Personal Trainer              -   Allows you to book a personal trainer          │\n");
            Console.Write("   │                                                                                             │\n");
            Console.Write("   │-- [4] Main Menu                                                                             │\n");
            Console.Write("   └─────────────────────────────────────────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    Console.WriteLine("Available Personal trainers:");
                    Console.WriteLine();                  
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("\n Book Personal trainer");
                    Console.WriteLine("------------------------------------------------");
                    PersonalTrainer.BookPT();
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   Going back to Main Menu.");
                    Linger();
                    StaffMenuMain(id);
                    break;
                default:
                    Console.WriteLine("\n Invalid selection. Please try again.");
                    StaffMenuPT();
                    break;
            }

        }
        public static void StaffMenuCalendar(int id)
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Calendar     │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View All Reservations                              │\n");
            Console.Write("   │-- [2] Make Reservation                                   │\n");
            Console.Write("   │-- [3] Delete Reservation(s)                              │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [4] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
            string val = Console.ReadLine();
            switch (val) 
            {
                case "1":
                    Calendar.ViewCalendar();
                    break;
                case "2":
                    Calendar.MakeReservation();
                    break;
                case "3":
                    Calendar.DeleteReservation();
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   Going back to Main Menu.");
                    Linger();
                    StaffMenuMain(id);
                    break;
            }
        }
        public static void StaffMenuEquipment(int id)
        {
            Console.Write("   ┌────────────────┐                                                                      \n");
            Console.Write("   │   Equipment    │                                                                      \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] List of Equipments        - List the available equipment (large and sport)     │\n");
            Console.Write("   │-- [2] Reserve Sport Equipment   - Allows you to reserve sport equipment.             │\n");
            Console.Write("   │-- [3] Reserve Large Equipment   - Allows you to reserve large equipment.             │\n");
            Console.Write("   │                                                                                      │\n");
            Console.Write("   │-- [4] Main Menu                                                                      │\n");
            Console.Write("   └──────────────────────────────────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    LargeEquipment.ListEquipment();
                    SportsEquipment.ListEquipment();
                    break;

                case "2":
                    SportsEquipment.BookEquipment();

                    break;
                case "3":
                    LargeEquipment.BookEquipment();
                    break;  
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   Going back to Main Menu.");
                    Linger();
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
            Console.Write("   ┌────────────────┐                                                            \n");
            Console.Write("   │   Spaces       │                                                            \n");
            Console.Write("   ├────────────────┴───────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View Spaces     -  Displays of all booking spaces.                   │\n");
            Console.Write("   │-- [2] Reserve Space   -  Allows you to reserve a specific place of space.  │\n");
            Console.Write("   │                                                                            │\n");
            Console.Write("   │-- [3] Main Menu                                                            │\n");
            Console.Write("   └────────────────────────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
            string selection = Console.ReadLine();
            GymDatabaseContext space1 = new GymDatabaseContext();
            switch (selection)
            {
                case "1":
                    Space.ListSpace();
                    break;
                case "2":
                    Space.BookSpace();
                    break;         
                case "3":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   Going back to Main Menu.");
                    Linger();
                    StaffMenuMain(id);
                    break;
                default:
                    Console.WriteLine("\n Invalid selection. Please try again.");
                    //StaffMenuSpaces(id);
                    break;
            }

        }
        public static void StaffMenuUsers(int id)
        {
            Console.Write("   ┌────────────────┐                                                                                     \n");
            Console.Write("   │   User Menu    │                                                                                     \n");
            Console.Write("   ├────────────────┴────────────────────────────────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Add User          -  Add a new user (costumer).                                               │\n");
            Console.Write("   │-- [2] Delete User       -  Delete an actual user (customer).                                        │\n");
            Console.Write("   │-- [3] Sell Membership   -  Sell a membership to costumer and VIP services                           │\n");
            Console.Write("   │-- [4] Sell Daypass      -  Sell a 24h pass to let costumers have more access to some VIP services.  │\n");
            Console.Write("   │                                                                                                     │\n");
            Console.Write("   │-- [5] Main Menu                                                                                     │\n");
            Console.Write("   └─────────────────────────────────────────────────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   Going back to Main Menu.");
                Linger();
                StaffMenuMain(id);
            }          
        }

        public static void StaffMenuRestrict()
        {
            Console.Write("   ┌─────────────────┐                                                                          \n");
            Console.Write("   │   Restrict item │                                                                          \n");
            Console.Write("   ├─────────────────┴─────────────────────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View restrict items     -  Displays of all Restrict item in equipment and spaces.   │\n");
            Console.Write("   │-- [2] unrestrict item         -  Unrestrict an item                                       │\n");
            Console.Write("   │                                                                                           │\n");
            Console.Write("   │-- [3] Main Menu                                                                           │\n");
            Console.Write("   └───────────────────────────────────────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
            string selection = Console.ReadLine();
            GymDatabaseContext space1 = new GymDatabaseContext();
            switch (selection)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("");
                    SportsEquipment.RestrictedItems();
                    LargeEquipment.RestrictedItems();
                    Space.RestrictedItems();
                    //Space.ListSpace();

                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Restrictitems();
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   Going back to Main Menu.");
                    Linger();
                    StaffMenuMain(id);
                    break;
                default:
                    Console.WriteLine("\n Invalid selection. Please try again.");
                    //StaffMenuSpaces(id);
                    break;
            }

        }
        public static void Restrictitems()
        {
            try
            {

                Console.WriteLine("What item do you want to un restrict?");
                Console.WriteLine("1.Sportequipment 2.Large equipment 3.Space");
                int choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 1)
                {
                    SportsEquipment.RestrictItem();
                }
                else if (choise == 2)
                {
                    LargeEquipment.RestrictItem();
                }
                else if (choise == 3)
                {
                    Space.RestrictItem();
                }
                else
                {

                    Console.WriteLine($"Wrong choice {choise}");
                }
            }
            catch
            {
                Console.WriteLine("Wrong input..");
            }
        }

        // ----- HERE IS THE CUSTOMER DOMAIN! ---------------------------------------------------------------------------------------------
        public static void MemberCustomerMenu(int id)
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Main Menu    │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Calendar                                           │\n");
            Console.Write("   │-- [2] Equipment                                          │\n");
            Console.Write("   │-- [3] PT                                                 │\n");
            Console.Write("   │-- [4] Group Schedule                                     │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [8] Help                                               │\n");
            Console.Write("   │-- [9] Logout/Exit                                        │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
            try
            {
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
                        Linger();
                        StaffMenuEquipment(id);
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Entering Personal Trainer.");
                        Linger();
                        StaffMenuPT();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Entering GroupSchedule.");
                        Linger();
                        CustomerMenuGroupSchedule(id);
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Entering Help.");
                        Linger();
                        StaffHelp();
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Logging out.");
                        Linger();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("   Invalid choice!");
                        Linger();
                        break;
                }
            }
            catch(FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("   Invalid choice!\n   Please enter a valid selection!!!\n   Press any key to proceed...");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n   OK.");
                Linger();
            }
            
        }
        public static void NonMemberCustomerMenu()
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   Main Menu    │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View Calendar                                      │\n");
            Console.Write("   │-- [2] PT                                                 │\n");
            Console.Write("   │-- [3] Reserv sport Equipment                             │\n");
            Console.Write("   │-- [4] Buy Membership                                     │\n");
            Console.Write("   │-- [5] Buy Daypass                                        │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [8] Help                                               │\n");
            Console.Write("   │-- [9] Logout/Exit                                        │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("   >> ");
            try
            {
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
                        Console.Write("   Entering Personal Trainer.");
                        Linger();
                        StaffMenuPT();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        SportsEquipment.BookEquipment();
                        Linger();
                        
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Not yet implanted.");
                        Linger();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Not yet implanted.");
                        Linger();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Entering Help.");
                        Linger();
                        StaffHelp();
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("   Logging out.");
                        Linger();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("   Invalid choice!");
                        Linger();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("   Invalid choice!\n   Please enter a valid selection!!!\n   Press any key to proceed...");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n   OK.");
                Linger();
            }
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
            Console.Write("   │-- [1] View All Reservations                              │\n");
            Console.Write("   │-- [2] Vacant Reservations                                │\n");
            Console.Write("   │-- [3] Make Reservation                                   │\n");
            Console.Write("   │-- [4] Delete Reservation                                 │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
        }
        public static void AdminMenuUser()
        {
            Console.Write("   ┌────────────────┐                                          \n");
            Console.Write("   │   User         │                                          \n");
            Console.Write("   ├────────────────┴─────────────────────────────────────────┐\n");
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

        // ----- This Method make browsing through the menus a bit cooler -----------------------------------------------------------------
        public static void Linger()
        {
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(25);
            Console.Write(".");
            Thread.Sleep(250);
            Console.ResetColor();
            Console.Clear();
        }
        // --------------------------------------------------------------------------------------------------------------------------------
        public static void StaffHelp() 
        {
            Console.WriteLine("   To be applied");
        }
        public static void CostumerHelp()
        {
            Console.WriteLine("   Sorry, coming soooooooon!");
        }
    }
}