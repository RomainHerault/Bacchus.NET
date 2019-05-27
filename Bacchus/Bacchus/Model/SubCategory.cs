using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class SubCategory : IListable
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public SubCategory(string Description, Category Category)
        {
            this.Description = Description;
            this.Category = Category;
        }

        public SubCategory(int Id, string Description, Category Category)
        {
            this.Id = Id;
            this.Description = Description;
            this.Category = Category;
        }

        public string[] GetListColumns() {
            return new string[] { "Decription", "Category" };
        }

        public string[] GetListItems()
        {
            return new string[] { Description, Category.Description };
        }
    }
}
