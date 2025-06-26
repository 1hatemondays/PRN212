using System.Windows.Controls;
using NgoQuangKhoiWPF.ViewModels;

namespace NgoQuangKhoiWPF.Views
{
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
            // We access the ViewModel through the DataContext
            var viewModel = (CustomerViewModel)DataContext;
            // Execute the command to load data
            viewModel.LoadCustomersCommand.Execute(null);
        }
    }
}