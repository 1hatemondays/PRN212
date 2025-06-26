using System.Windows;

namespace NgoQuangKhoiWPF.Views
{
    public partial class CustomerDialog : Window
    {
        public CustomerDialog()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // This tells the window that the user finished successfully.
            DialogResult = true;
        }
    }
}