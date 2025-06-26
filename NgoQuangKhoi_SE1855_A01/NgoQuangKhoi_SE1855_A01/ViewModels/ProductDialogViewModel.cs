using BusinessObjects;
using NgoQuangKhoiWPF.ViewModels;

namespace NgoQuangKhoiWPF.ViewModels
{
    public class ProductDialogViewModel : ViewModelBase
    {
        private Product _product;

        public Product Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public ProductDialogViewModel(Product product)
        {
            // Create a copy to avoid changing the original product until "Save" is clicked
            Product = new Product
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                CategoryID = product.CategoryID,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            };
        }
    }
}