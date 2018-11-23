using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

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
                ImageFile = "Manning.jpg"
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

        }
        public static List<Customer> GetAll()
        {
            lock (s_Customers)
            {
                return new List<Customer>(s_Customers.Values);
            }
        }
        public static Customer Get(int id)
        {
            lock (s_Customers)
            {
                return s_Customers[id];
            }
        }
        public static bool TryGet(int id, out Customer customer)
        {
            lock (s_Customers)
            {
                if (s_Customers.ContainsKey(id))
                {
                    customer = Get(id);
                    return true;
                }
            }
            customer = null;
            return false;
        }
        public static int Add(Customer customer)
        {
            lock (s_Customers)
            {
                customer.Id = s_Customers.Count + 1;
                s_Customers.Add(customer.Id, customer);
                return customer.Id;
            }
        }
        public static void Update(Customer customer)
        {
            lock (s_Customers)
            {
                s_Customers[customer.Id] = customer;
            }
        }
        public static void Delete(int id)
        {
            lock (s_Customers)
            {
                s_Customers.Remove(id);
            }
        }



    }
}