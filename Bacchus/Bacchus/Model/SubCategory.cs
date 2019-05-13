using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class SubCategory
    {
        public string Description { get; set; }

        public Category Category { get; set; }

        public SubCategory(string Description, Category Category)
        {
            this.Description = Description;
            this.Category = Category;
        }
    }
}
