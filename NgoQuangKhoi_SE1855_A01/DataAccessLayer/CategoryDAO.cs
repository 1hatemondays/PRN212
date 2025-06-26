using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales", Picture = null },
            new Category { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings", Picture = null },
            new Category { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads", Picture = null },
            new Category { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses", Picture = null },
            new Category { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal", Picture = null },
        };


        public static List<Category> GetCategories() => new List<Category>(categories);

        public static Category GetCategoryById(int id) =>
            categories.FirstOrDefault(c => c.CategoryID == id);

        public static void AddCategory(Category category) =>
            categories.Add(category);

        public static void UpdateCategory(Category category)
        {
            var existing = categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
            if (existing != null)
            {
                existing.CategoryName = category.CategoryName;
                existing.Description = category.Description;
            }
        }

        public static void DeleteCategory(int id)
        {
            var toRemove = categories.FirstOrDefault(c => c.CategoryID == id);
            if (toRemove != null)
            {
                categories.Remove(toRemove);
            }
        }
        public static List<Category> SearchCategories(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Category>(categories);
            return categories
                .Where(c => c.CategoryName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
