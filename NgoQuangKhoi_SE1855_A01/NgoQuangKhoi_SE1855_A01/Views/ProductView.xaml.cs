using System.Windows;
using System.Windows.Controls;
using NgoQuangKhoiWPF.ViewModels;

namespace NgoQuangKhoiWPF.Views
{
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
            // When the view is created, get the ViewModel and load the products
            var viewModel = (ProductViewModel)DataContext;
            viewModel.LoadProductsCommand.Execute(null);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // You can add any initialization code that needs to run when the control is loaded
            // For example, refresh data or update UI elements
        }
    }
}
