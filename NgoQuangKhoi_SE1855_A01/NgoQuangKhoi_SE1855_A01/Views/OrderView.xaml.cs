using System.Windows.Controls;
using NgoQuangKhoiWPF.ViewModels;

namespace NgoQuangKhoiWPF.Views
{
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
            var viewModel = (OrderViewModel)DataContext;
            viewModel.LoadOrdersCommand.Execute(null);
        }
    }
}