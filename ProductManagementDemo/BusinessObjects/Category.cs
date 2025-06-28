using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public Category(int catID, string catName)
        {
            this.CatID = catID;
            this.CatName = catName;
        }
        public int CatID { get; set; }
        public string CatName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}