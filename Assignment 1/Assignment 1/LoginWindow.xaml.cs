// In NgoQuangKhoiWPF/LoginWindow.xaml.cs

using NgoQuangKhoiWPF.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace NgoQuangKhoiWPF
{
    public partial class LoginWindow : Window
    {
        private LoginViewModel _viewModel;

        public LoginWindow()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            this.DataContext = _viewModel; // Connect the ViewModel to the View
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Cast the sender to PasswordBox to access the Password property
            var passwordBox = this.FindName("PasswordBox") as PasswordBox;
            if (passwordBox != null)
            {
                _viewModel.SetPassword(passwordBox.Password);

                // Call the Login method in the ViewModel
                _viewModel.Login();
            }
        }
    }
}