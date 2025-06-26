using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static List<Product> products = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Chai", SupplierID = 1, CategoryID = 1, QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18.00m, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false },
            new Product { ProductID = 2, ProductName = "Chang", SupplierID = 1, CategoryID = 1, QuantityPerUnit = "24 - 12 oz bottles", UnitPrice = 19.00m, UnitsInStock = 17, UnitsOnOrder = 40, ReorderLevel = 25, Discontinued = false },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", SupplierID = 1, CategoryID = 2, QuantityPerUnit = "12 - 550 ml bottles", UnitPrice = 10.00m, UnitsInStock = 13, UnitsOnOrder = 70, ReorderLevel = 25, Discontinued = false },
            new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", SupplierID = 2, CategoryID = 2, QuantityPerUnit = "48 - 6 oz jars", UnitPrice = 22.00m, UnitsInStock = 53, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = false },
            new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", SupplierID = 2, CategoryID = 2, QuantityPerUnit = "36 boxes", UnitPrice = 21.35m, UnitsInStock = 0, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = true }
        };

        public static List<Product> GetProducts() => new List<Product>(products);
        public static Product GetProductById(int id) =>
            products.FirstOrDefault(p => p.ProductID == id);
        public static void AddProduct(Product product)
        {
            if (product != null && !products.Any(p => p.ProductID == product.ProductID))
            {
                products.Add(product);
            }
        }
        public static void DeleteProduct(int id)
        {
            var toRemove = products.FirstOrDefault(p => p.ProductID == id);
            if (toRemove != null)
            {
                products.Remove(toRemove);
            }
        }
        public static void UpdateProduct(Product product)
        {
            var existing = products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.SupplierID = product.SupplierID;
                existing.CategoryID = product.CategoryID;
                existing.QuantityPerUnit = product.QuantityPerUnit;
                existing.UnitPrice = product.UnitPrice;
                existing.UnitsInStock = product.UnitsInStock;
                existing.UnitsOnOrder = product.UnitsOnOrder;
                existing.ReorderLevel = product.ReorderLevel;
                existing.Discontinued = product.Discontinued;
            }
        }
        public static List<Product> SearchProduct(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Product>(products);
            return products
                .Where(p => p.ProductName != null && p.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             p.QuantityPerUnit != null && p.QuantityPerUnit.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             p.UnitPrice.ToString("F2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
