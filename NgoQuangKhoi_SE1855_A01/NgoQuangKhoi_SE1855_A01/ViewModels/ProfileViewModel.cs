using BusinessObjects;
using NgoQuangKhoiWPF.ViewModels;

namespace NgoQuangKhoiWPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        public Customer CurrentCustomer { get; set; }

        public ProfileViewModel(Customer customer)
        {
            CurrentCustomer = customer;
        }
    }
}