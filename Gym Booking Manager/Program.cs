﻿using Gym_Booking_Manager;
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

            /*Space space = new Space(Space.Category.Hall, "Emil");
            GymDatabaseContext spaces = new GymDatabaseContext();           
            spaces.Create<Space>(space);
            Space space1 = new Space(Space.Category.Studio, "Erik");
            spaces.Create<Space>(space1);
            Staff user = new Staff("emil","1","hej@hej","0903432423","hej123");
            spaces.Create<Staff>(user);
            Staff user1 = new Staff("erik", "2", "hej1@hej1", "070123424", "hej12345");
            spaces.Create<Staff>(user1);*/
            //GymDatabaseContext spaces = new GymDatabaseContext(); 

            //spaces.Read<Staff>("id", "2");

            //Console.WriteLine("Tillagd");

            //Staff Test
            //Staff user = new Staff("Alex", "1", "alex@alex", "0701234567", "alex123");
            //spaces.Create<Staff>(user);
            //Console.WriteLine("User added");


            

            MenuSystem.Login();
            //UserMgmt.AddStaff();
            //UserMgmt.DelStaff();
            //MenuSystem.StaffMenuEquipment();

        }       // Static methods for the program
    }
}