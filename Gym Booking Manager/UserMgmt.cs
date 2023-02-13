using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;


namespace Gym_Booking_Manager
{
    internal class UserMgmt : ICSVable, IComparable<Staff>
    


        

    {
        private readonly GymDatabaseContext spaces = new GymDatabaseContext();

        //Add Staff to the database
        public void AddStaff(string name, string id, string email, string phone, string password)
        {
            Staff user = new Staff(name, id, email, phone, password);
            Console.WriteLine("Input Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Input ID: ");
            id = Console.ReadLine();
            Console.WriteLine("Input Email: ");
            email = Console.ReadLine();
            Console.WriteLine("Input Phone: ");
            phone = Console.ReadLine();
            Console.WriteLine("Input Password: ");
            password = Console.ReadLine();
            



            spaces.Create<Staff>(user);
            Console.WriteLine("Staff added");



        }





        //Add a customer to the database
        public void AddCustomer(string name, string id, string email, string phone, string password)
        {
            Customer user = new Customer(name, id, email, phone, password);

            Console.WriteLine("Input Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Input ID: ");
            id = Console.ReadLine();
            Console.WriteLine("Input Email: ");
            email = Console.ReadLine();
            Console.WriteLine("Input Phone: ");
            phone = Console.ReadLine();
            Console.WriteLine("Input Password: ");
            password = Console.ReadLine();


            spaces.Create<Customer>(user);
            Console.WriteLine("Customer added");

        }



        //Delete Staff from the database
        public void DelStaff()
        {
           

            
            Console.WriteLine("Here is a list of all current Staff members:");
            var staffList = spaces.Read<Staff>();
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

            spaces.Delete<Staff>(user);
            Console.WriteLine("Staff deleted");


        }

        //Delete Customer from the database


        public void DelCustomer()
        {
            


            Console.WriteLine("Here is a list of all current Customers:");
            var customerList = spaces.Read<Customer>();
            foreach (var customer in customerList)
            {
                Console.WriteLine($"ID: {customer.id}, Name: {customer.name}");
            }


            Console.WriteLine("Enter the ID of the Customer to be deleted:");
            string customerId = Console.ReadLine();

            Customer user = customerList.FirstOrDefault(s => s.id == customerId);

            if (user == null)
            {
                Console.WriteLine("Staff member not found. Please try again.");
                return;
            }

            spaces.Delete<Customer>(user);
            Console.WriteLine("Staff member deleted");


        }





        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        override public string CSVify()
        {
            return $"{nameof(name)}:{name},{nameof(id)}:{id},{nameof(email)}:{email},{nameof(phone)}:{phone}";
        }
        public int CompareTo(Customer? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return this.name.CompareTo(other.name);
        }

        public int CompareTo(Staff? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return this.name.CompareTo(other.name);
        }

    }
}
