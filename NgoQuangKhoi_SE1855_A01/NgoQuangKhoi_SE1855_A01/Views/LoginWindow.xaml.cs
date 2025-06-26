using System.Windows;
using System.Windows.Controls;
using NgoQuangKhoiWPF.ViewModels;
using Services;
using Repositories;

namespace NgoQuangKhoiWPF.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            // Create CustomerRepository instance for CustomerService
            var customerRepository = new CustomerRepository();

            // Pass both EmployeesService and CustomersService to the ViewModel
            DataContext = new LoginViewModel(new EmployeeService(), new CustomerService(customerRepository));

            // Handle password changes
            PasswordBox.PasswordChanged += (s, e) =>
            {
                if (DataContext is LoginViewModel viewModel)
                {
                    viewModel.Password = PasswordBox.Password;
                }
            };
        }
    }
}
