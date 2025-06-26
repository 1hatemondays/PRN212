// Trong dự án Services/CustomerService.cs

using BusinessObjects;
using Repositories; // Using đến dự án chứa Repository
using System.Collections.Generic;

namespace Services
{
    // Lớp này vẫn implement ICustomerService
    public class CustomerService : ICustomerService
    {
        // NHƯNG, nó phụ thuộc vào ICustomerRepository
        private readonly ICustomerRepository _customerRepository;

        // Constructor bây giờ nhận vào một ICustomerRepository
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Các phương thức bây giờ sẽ gọi đến repository để làm việc
        public List<Customer> GetCustomers()
        {
            // Thay vì _customerService, chúng ta gọi _customerRepository
            return _customerRepository.GetCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public Customer Login(string phone)
        {
            return _customerRepository.Login(phone);
        }
        public List<Customer> SearchCustomer(string searchTerm)
        {
            return _customerRepository.SearchCustomer(searchTerm);
        }
    }
}