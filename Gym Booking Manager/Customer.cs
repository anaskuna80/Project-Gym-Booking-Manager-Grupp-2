﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Customer : User , ICSVable , IComparable<Customer>
    {
        public Customer(string name, string email, string phone, string password) : base(name,email,phone,password)
        {

        }
        public Customer(Dictionary<String, String> constructionArgs) : base(constructionArgs)
        {

        }

        public override string ToString()
        {
            return $"'{email}', '{name}', '{password}', '{phone}'";
            //return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        override public string CSVify()
        {
            return $"{nameof(id)}:{id},{nameof(name)}:{name},{nameof(email)}:{email},{nameof(phone)}:{phone},{nameof(password)}:{password}";
        }
        public int CompareTo(Customer? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // When category is the same, sort on name.
            return 2;
            //return this.id.CompareTo(other.id);
        }
        /*public int CompareTo(Customer? other)
        {
            int idCompare = this.id.CompareTo(other.id);
            if (idCompare != 0)
            {
                return idCompare;
            }
            else
            {
                return this.name.CompareTo(other.name);
            }
        */
        }
    }

