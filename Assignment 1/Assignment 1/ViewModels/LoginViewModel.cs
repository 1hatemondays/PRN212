// In NgoQuangKhoiWPF/ViewModels/LoginViewModel.cs
using Assignment_1;
using DataAccessLayer;
using System.Windows;

namespace NgoQuangKhoiWPF.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        private string _password;

        public void SetPassword(string password)
        {
            _password = password;
        }

        public void Login()
        {
            var employee = EmployeeDAO.Instance.GetEmployeeByUsernameAndPassword(Username, _password);

            if (employee != null)
            {
                // Successful login: open main window
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                // Close the login window
                Application.Current.Windows[0]?.Close();
            }
            else
            {
                // Failed login: show error
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}