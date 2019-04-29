using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    class Product
    {
        private string Description { get; set; }

        private string Ref { get; set; }

        private string Brand { get; set; }

        private Category Category { get; set; }

        private SubCategory SubCategory { get; set; }

        private float PricePreVAT { get; set; }

        public Product(string Description, string Ref, string Brand,
            Category Category, SubCategory SubCategory, float PricePreVAT) {

            this.Description = Description;
            this.Ref = Ref;
            this.Brand = Brand;
            this.Category = Category;
            this.SubCategory = SubCategory;
            this.PricePreVAT = PricePreVAT;
        }
    }
}
