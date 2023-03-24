using Gym_Booking_Manager.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;


namespace Gym_Booking_Manager
{
    public static class UserMgmt


    {
        //private readonly GymDatabaseContext spaces = new GymDatabaseContext();

        //Add Staff to the database
        public static void AddStaff()
        {
            GymDatabaseContext spaces = new GymDatabaseContext();
            
            Console.WriteLine("Input Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Input Phone: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Input Password: ");
            string password = Console.ReadLine();

            Staff user = new Staff(name, email, phone, password);


            PostgreSQLDatabase.createRecord(user);
            //spaces.Create<Staff>(user);
            Console.WriteLine("Staff added");



        }





        //Add a customer to the database
        public static void AddCustomer()
        {
            GymDatabaseContext spaces = new GymDatabaseContext();
            

            Console.WriteLine("Input Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Input Phone: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Input Password: ");
            string password = Console.ReadLine();

            Customer user = new Customer(name, email, phone, password);
            PostgreSQLDatabase.createRecord(user);

            //spaces.Create<Customer>(user);
            Console.WriteLine("Customer added");

        }



        //Delete Staff from the database
        public static void DelStaff()
        {


            GymDatabaseContext staffs = new GymDatabaseContext();
            Console.WriteLine("Here is a list of all current Staff members:");
            PostgreSQLDatabase.readAndPrintAllRecord("Staff");

            //var staffList = staffs.Read<Staff>();
            //foreach (var staff in staffList)
            //{
            //    Console.WriteLine($"ID: {staff.id}, Name: {staff.name}");
            //}


            Console.WriteLine("Enter the ID of the Staff to be deleted:");
            int staffId = Convert.ToInt32(Console.ReadLine());

            //Staff user = staffList.FirstOrDefault(s => s.id == staffId);

            //if (user == null)
            //{
            //    Console.WriteLine("Staff not found. Please try again.");
            //    return;
            //}
            PostgreSQLDatabase.deleteRecord("Staff", staffId);
            //staffs.Delete<Staff>(user);
            Console.WriteLine("Staff deleted");


        }

        //Delete Customer from the database


        public static void DelCustomer()
        {

            GymDatabaseContext customers = new GymDatabaseContext();

            Console.WriteLine("Here is a list of all current Customers:");
            PostgreSQLDatabase.readAndPrintAllRecord("Customer");
            //var customerList = customers.Read<Customer>();
            //foreach (var customer in customerList)
            //{
            //    Console.WriteLine($"ID: {customer.id}, Name: {customer.name}");
            //}


            Console.WriteLine("Enter the ID of the Customer to be deleted:");
            int customerId = Convert.ToInt32(Console.ReadLine());

            //Customer user = customerList.FirstOrDefault(s => s.id == customerId);

            //if (user == null)
            //{
            //    Console.WriteLine("Customer member not found. Please try again.");
            //    return;
            //}

            PostgreSQLDatabase.deleteRecord("Customer", customerId);
            //customers.Delete<Customer>(user);
            Console.WriteLine("customer member deleted");


        }
    }
}
