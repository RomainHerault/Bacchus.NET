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
        private string Description { get; set; }

        private HashSet<SubCategory> SubCategories { get; set; } 

        public Category(string Description, HashSet<SubCategory> SubCategories)
        {
            this.Description = Description;
            this.SubCategories = SubCategories;
        }
    }
}
