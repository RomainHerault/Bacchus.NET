using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class Product
    {
        public static string[] ListColumns = { "Ref", "Brand", "Price", "Quantity" };

        public string Description { get; set; }

        public string Ref { get; set; }

        public string Brand { get; set; }

        public SubCategory SubCategory { get; set; }

        public float PricePreVAT { get; set; }

        public int Quantity { get; set; }

        public Product(string Description, string Ref, string Brand,
            SubCategory SubCategory, float PricePreVAT, int Quantity) {

            this.Description = Description;
            this.Ref = Ref;
            this.Brand = Brand;
            this.SubCategory = SubCategory;
            this.PricePreVAT = PricePreVAT;
            this.Quantity = Quantity;
        }

        public string[] ListItems()
        {
            return new string[] { Ref, Brand, PricePreVAT.ToString(), Quantity.ToString() };
        }
    }
}
