using BusinessObjects;
using NgoQuangKhoiWPF.Commands;
using Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NgoQuangKhoiWPF.Views; // For the dialog
using System.Windows; // For MessageBox

namespace NgoQuangKhoiWPF.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly IProductService _productService;
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
        private string _searchTerm;

        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        public ICommand LoadProductsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public ProductViewModel()
        {
            _productService = new ProductService();
            LoadProductsCommand = new RelayCommand(LoadProducts);
            SearchCommand = new RelayCommand(SearchProducts);
            AddCommand = new RelayCommand(AddProduct);
            UpdateCommand = new RelayCommand(UpdateProduct, CanUpdateOrDelete);
            DeleteCommand = new RelayCommand(DeleteProduct, CanUpdateOrDelete);
        }
        private bool CanUpdateOrDelete(object obj)
        {
            return SelectedProduct != null;
        }

        private void SearchProducts(object obj)
        {
            var productList = _productService.SearchProduct(SearchTerm);
            Products = new ObservableCollection<Product>(productList);
        }

        private void AddProduct(object obj)
        {
            var newProduct = new Product();
            var dialogVM = new ProductDialogViewModel(newProduct);

            var dialog = new ProductDialog
            {
                DataContext = dialogVM,
                Owner = Application.Current.MainWindow
            };

            if (dialog.ShowDialog() == true)
            {
                _productService.AddProduct(dialogVM.Product);
                LoadProducts(null); // Reload list
            }
        }

        private void UpdateProduct(object obj)
        {
            var dialogVM = new ProductDialogViewModel(SelectedProduct);

            var dialog = new ProductDialog
            {
                DataContext = dialogVM,
                Owner = Application.Current.MainWindow
            };

            if (dialog.ShowDialog() == true)
            {
                _productService.UpdateProduct(dialogVM.Product);
                LoadProducts(null); // Reload list
            }
        }

        private void DeleteProduct(object obj)
        {
            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _productService.DeleteProduct(SelectedProduct.ProductID);
                LoadProducts(null); // Reload list
            }
        }

        private void LoadProducts(object obj)
        {
            var productList = _productService.GetProducts();
            Products = new ObservableCollection<Product>(productList);
        }
    }
}