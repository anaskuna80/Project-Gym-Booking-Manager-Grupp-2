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
            string id = Console.ReadLine();
            Console.WriteLine("Input Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Input Phone: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Input Password: ");
            string password = Console.ReadLine();

            Staff user = new Staff(id, name, email, phone, password);



            spaces.Create<Staff>(user);
            Console.WriteLine("Staff added");



        }





        //Add a customer to the database
        public static void AddCustomer()
        {
            GymDatabaseContext spaces = new GymDatabaseContext();
            

            Console.WriteLine("Input Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input ID: ");
            string id = Console.ReadLine();
            Console.WriteLine("Input Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Input Phone: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Input Password: ");
            string password = Console.ReadLine();

            Customer user = new Customer(name:name, id:id, email:email, phone:phone, password:password);

            spaces.Create<Customer>(user);
            Console.WriteLine("Customer added");

        }



        //Delete Staff from the database
        public static void DelStaff()
        {


            GymDatabaseContext staffs = new GymDatabaseContext();
            Console.WriteLine("Here is a list of all current Staff members:");
            var staffList = staffs.Read<Staff>();
            foreach (var staff in staffList)
            {
                Console.WriteLine($"ID: {staff.id}, Name: {staff.name}");
            }


            Console.WriteLine("Enter the ID of the Staff to be deleted:");
            string staffId = Console.ReadLine();

            Staff user = staffList.FirstOrDefault(s => s.id == staffId);

            if (user == null)
            {
                Console.WriteLine("Staff not found. Please try again.");
                return;
            }

            staffs.Delete<Staff>(user);
            Console.WriteLine("Staff deleted");


        }

        //Delete Customer from the database


        public static void DelCustomer()
        {

            GymDatabaseContext customers = new GymDatabaseContext();

            Console.WriteLine("Here is a list of all current Customers:");
            var customerList = customers.Read<Customer>();
            foreach (var customer in customerList)
            {
                Console.WriteLine($"ID: {customer.id}, Name: {customer.name}");
            }


            Console.WriteLine("Enter the ID of the Customer to be deleted:");
            string customerId = Console.ReadLine();

            Customer user = customerList.FirstOrDefault(s => s.id == customerId);

            if (user == null)
            {
                Console.WriteLine("Customer member not found. Please try again.");
                return;
            }

            customers.Delete<Customer>(user);
            Console.WriteLine("customer member deleted");


        }
    }
}
