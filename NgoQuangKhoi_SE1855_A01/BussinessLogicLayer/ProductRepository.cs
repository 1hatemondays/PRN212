using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product)
        {
            ProductDAO.AddProduct(product);
        }
        public void DeleteProduct(int id)
        {
            ProductDAO.DeleteProduct(id);
        }
        public List<Product> GetProducts()
        {
            return ProductDAO.GetProducts();
        }
        public Product GetProductById(int id)
        {
            return ProductDAO.GetProductById(id);
        }
        public void UpdateProduct(Product product)
        {
            ProductDAO.UpdateProduct(product);
        }
        public List<Product> SearchProduct(string searchTerm)
        {
            return ProductDAO.SearchProduct(searchTerm);
        }
    }
}
