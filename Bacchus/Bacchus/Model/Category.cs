using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class Category
    {
        public string Description { get; set; }

        public HashSet<SubCategory> SubCategories { get; set; } 

        public Category(string Description)
        {
            this.Description = Description;
            SubCategories = new HashSet<SubCategory>();
        }

        public void AddSubCategory(SubCategory SubCategory)
        {
            SubCategories.Add(SubCategory);
        }
    }
}
