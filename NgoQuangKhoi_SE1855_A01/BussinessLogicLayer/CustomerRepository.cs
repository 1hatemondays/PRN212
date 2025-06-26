using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer)
        {
            CustomerDAO.AddCustomer(customer);
        }
        public void DeleteCustomer(int id)
        {
            CustomerDAO.DeleteCustomer(id);
        }
        public Customer GetCustomerById(int id)
        {
            return CustomerDAO.GetCustomerById(id);
        }
        public List<Customer> GetCustomers()
        {
            return CustomerDAO.GetCustomers();
        }
        public void UpdateCustomer(Customer customer)
        {
            CustomerDAO.UpdateCustomer(customer);
        }
        public Customer Login(string phone)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            return customerDAO.Login(phone);
        }
        public List<Customer> SearchCustomer(string searchTerm)
        {
            return CustomerDAO.SearchCustomer(searchTerm);
        }
        public Customer GetCustomerByPhone(string phone)
        {
            return CustomerDAO.GetCustomerByPhone(phone);
        }
    }
}