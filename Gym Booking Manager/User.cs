using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal abstract class User 
    {
        public int id { get; set; }
        public string name { get; set; } // Here the "field" is private, but properties (access of the field) public here - this constellation being purely declarative without change in functionality
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        
      

        protected User(int id, string name, string email, string phone, string password)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.password = password;
        }
        public User(Dictionary<String, String> constructionArgs)
        {
            this.id = Convert.ToInt32(constructionArgs[nameof(id)]);
            this.name = constructionArgs[nameof(name)];
            this.phone= constructionArgs[nameof(phone)];
            this.email= constructionArgs[nameof(email)];
            this.password = constructionArgs[nameof(password)];
        }
        public override string ToString()
        {
            return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        virtual public string CSVify()
        {
            return $"{nameof(id)}:{id},{nameof(name)}:{name},{nameof(email)}:{email},{nameof(phone)}:{phone},{nameof(password)}:{password}";
        }

    }
}
