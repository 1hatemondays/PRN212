using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class CustomerDAO
    {

        private static List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerID = 1, CompanyName = "Company A", ContactName = "Alice Smith", ContactTitle = "Sales Manager", Address = "123 Main St", Phone = "555-1234" },
            new Customer { CustomerID = 2, CompanyName = "Company B", ContactName = "Bob Johnson", ContactTitle = "Marketing Director", Address = "456 Elm St", Phone = "555-5678" },
            new Customer { CustomerID = 3, CompanyName = "Company C", ContactName = "Charlie Brown", ContactTitle = "CEO", Address = "789 Oak St", Phone = "555-8765" },
            new Customer { CustomerID = 4, CompanyName = "Company D", ContactName = "Diana Prince", ContactTitle = "Operations Manager", Address = "321 Pine St", Phone = "555-4321" },
            new Customer { CustomerID = 5, CompanyName = "Company E", ContactName = "Ethan Hunt", ContactTitle = "Project Manager", Address = "654 Maple St", Phone = "555-6789" }
        };


        public static List<Customer> GetCustomers() => new List<Customer>(customers);
        public static Customer GetCustomerById(int id) =>
        customers.FirstOrDefault(c => c.CustomerID == id);
        public static void AddCustomer(Customer customer) =>
            customers.Add(customer);

        public static void UpdateCustomer(Customer customer)
        {
            var existing = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (existing != null)
            {
                existing.CompanyName = customer.CompanyName;
                existing.ContactName = customer.ContactName;
                existing.ContactTitle = customer.ContactTitle;
                existing.Address = customer.Address;
                existing.Phone = customer.Phone;
            }
        }
        public static void DeleteCustomer(int id)
        {
            var toRemove = customers.FirstOrDefault(c => c.CustomerID == id);
            if (toRemove != null)
            {
                customers.Remove(toRemove);
            }
        }
        public Customer Login(string phone)
        {
            return customers.FirstOrDefault(c =>
                            c.Phone.Trim().Equals(phone, StringComparison.OrdinalIgnoreCase));
        }
        public static List<Customer> SearchCustomer(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Customer>(customers);
            return customers
                .Where(c => c.CompanyName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.ContactName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.ContactTitle.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.Address.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.Phone.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}



