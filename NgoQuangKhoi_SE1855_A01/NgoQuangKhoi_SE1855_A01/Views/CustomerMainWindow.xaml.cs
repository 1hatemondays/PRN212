using System.Windows;
using BusinessObjects;
using NgoQuangKhoiWPF.ViewModels; // Add this using statement

namespace NgoQuangKhoiWPF.Views
{
    public partial class CustomerMainWindow : Window
    {
        // The customer object passed from the login screen
        private Customer _loggedInCustomer;

        public CustomerMainWindow(Customer customer)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            // Set the DataContext to our new main ViewModel
            DataContext = new CustomerMainViewModel(_loggedInCustomer);
            this.Title = $"Customer Dashboard - Welcome, {_loggedInCustomer.ContactName}";
        }
    }
}