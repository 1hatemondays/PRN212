using System.Collections.Generic;
using BusinessObjects;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryService iCategoryRepository;
        public CategoryService()
        {
            iCategoryRepository = new CategoryRepository();
        }
        public List<Category> GetCategories()
        {
            return 
        }
    }
}
