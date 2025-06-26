using BusinessObjects;

namespace NgoQuangKhoiWPF.ViewModels
{
    public class CustomerDialogViewModel : ViewModelBase
    {
        private Customer _customer;

        public Customer Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        public CustomerDialogViewModel(Customer customer)
        {
            // We create a copy so changes are not saved unless the user clicks "Save"
            Customer = new Customer
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                Phone = customer.Phone
            };
        }
    }
}