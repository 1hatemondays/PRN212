using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQ2Object2
{
    public class ListProduct
    {
        List<Product> products;
        public ListProduct()
        {
            products = new List<Product>();
        }

        public void AddProduct()
        {
            products.Add(new Product{
                Id = 1,
                Name = "Product A",
                Quantity = 10,
                Price = 100.0
            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Product B",
                Quantity = 5,
                Price = 200.0
            });
            products.Add(new Product
            {
                Id = 3,
                Name = "Product C",
                Quantity = 20,
                Price = 150.0
            });
            products.Add(new Product
            {
                Id = 4,
                Name = "Product D",
                Quantity = 15,
                Price = 300.0
            });
            products.Add(new Product
            {
                Id = 5,
                Name = "Product E",
                Quantity = 8,
                Price = 250.0
            });
            products.Add(new Product
            {
                Id = 6,
                Name = "Product F",
                Quantity = 12,
                Price = 180.0
            });
            products.Add(new Product
            {
                Id = 7,
                Name = "Product G",
                Quantity = 7,
                Price = 220.0
            });
            products.Add(new Product
            {
                Id = 8,
                Name = "Product H",
                Quantity = 3,
                Price = 350.0
            });
            products.Add(new Product
            {
                Id = 9,
                Name = "Product I",
                Quantity = 6,
                Price = 400.0
            });
            products.Add(new Product
            {
                Id = 10,
                Name = "Product J",
                Quantity = 4,
                Price = 500.0
            });
        }

        public List<Product> FilteredProducts(double price1, double price2)
        {
            return products
                .Where(p => p.Price >= price1 && p.Price <= price2)
                .ToList();
        }

        public List<Product> FilteredProducts2(double price1, double price2)
        {
            var results = from p in products
                          where p.Price >= price1 && p.Price <= price2
                          select p;
            return results.ToList();
        }

        public List<Product> SortedProducts()
        {
            return products.OrderByDescending(p => p.Price).ToList();
        }

        public List<Product> SortedProducts2()
        {
            var results = from p in products
                          orderby p.Price descending
                          select p;
            return results.ToList();
        }

        public double SumOfValue()
        {
            return products.Sum(p => p.Price * p.Quantity);
        }
    }
}
