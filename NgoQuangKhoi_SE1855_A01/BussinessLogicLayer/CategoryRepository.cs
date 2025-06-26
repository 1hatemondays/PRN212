using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Category category)
        {
            CategoryDAO.AddCategory(category);
        }
        public void DeleteCategory(int id)
        {
            CategoryDAO.DeleteCategory(id);
        }
        public List<Category> GetCategories()
        {
            return CategoryDAO.GetCategories();
        }
        public Category GetCategoryById(int id)
        {
            return CategoryDAO.GetCategoryById(id);
        }
        public void UpdateCategory(Category category)
        {
            CategoryDAO.UpdateCategory(category);
        }
        public List<Category> SearchCategories(string searchTerm)
        {
            return CategoryDAO.SearchCategories(searchTerm);
        }
    }
}
