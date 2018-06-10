using System;
using System.Collections.Generic;
using System.Drawing;

namespace CustomerDemo.Models
{
    public static class CustomerRepository
    {
        private static readonly Dictionary<int, Customer> s_Customers = new Dictionary<int, Customer>();
        static CustomerRepository()
        {
            s_Customers.Add(1, new Customer
            {
                Id = 1,
                Name = "Andrew Perez",
                Street = "Annamark",
                City = "Zhendong",
                ZipCode = null,
                Country = "CN",
            });
            s_Customers.Add(2, new Customer
            {
                Id = 2,
                Name = "Donald Davis",
                Street = "Kingsford",
                City = "Garland",
                ZipCode = "75044",
                Country = "US"
            });
            s_Customers.Add(3, new Customer
            {
                Id = 3,
                Name = "Chelsea Elizabeth Manning",
                Street = "Elrod Avenue",
                City = "Quantico",
                ZipCode = "VA22134",
                Country = "USA",
                //Image = Properties.Resource.gentleman,
            });
            s_Customers.Add(4, new Customer
            {
                Id = 4,
                Name = "Billy Alvarez",
                Street = "Ronald Regan",
                City = "Harderwijk",
                ZipCode = "3844",
                Country = "NL",
            });
            //s_Customers[3].Image = Image.FromFile(@"..\Images\gentleman.jpg");
            s_Customers[3].ImageFile = @"Images\Manning.jpg";
        }
        public static List<Customer> GetAll()
        {
            return new List<Customer>(s_Customers.Values);
        }
        public static Customer Get(int id)
        {
            return s_Customers[id];
        }
        public static void Add(Customer customer)
        {
            s_Customers.Add(customer.Id, customer);
        }
        public static void Update(Customer customer)
        {
            s_Customers[customer.Id] = customer;
        }
        public static void Delete(int id)
        {
            s_Customers.Remove(id);
        }


    }
}