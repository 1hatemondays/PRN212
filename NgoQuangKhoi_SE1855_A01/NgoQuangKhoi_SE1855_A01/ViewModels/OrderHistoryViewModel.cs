using BusinessObjects;
using NgoQuangKhoiWPF.ViewModels;

namespace NgoQuangKhoiWPF.ViewModels
{
    public class OrderHistoryViewModel : ViewModelBase
    {
        public Customer CurrentCustomer { get; set; }

        public OrderHistoryViewModel(Customer customer)
        {
            CurrentCustomer = customer;
            // We'll add the logic to load orders here later
        }
    }
}