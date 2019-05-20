using Bacchus.DB;
using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Manager
{
    class ProductManager
    {

        private ProductDAO ProductDAO { get; set; }

        private HashSet<Product> ProductsSet { get; set; }

        public List<Product> GetProductsList()
        {
            List<Product> list = new List<Product>();

            foreach (Product Product in ProductsSet)
            {
                list.Add(
                    Product
                );
            }

            return list;
        }

        public void AddProduct()
        {


        }

        public void RefreshProductsSet()
        {
            ProductsSet = ProductDAO.GetProducts();
        }

        public ProductManager()
        {
            ProductDAO = new ProductDAO();

            RefreshProductsSet();
        }

        /*HashSet<string> BrandsSet = new HashSet<string>();
        HashSet<Category> CategoriesSet = new HashSet<Category>();
        HashSet<SubCategory> SubCategoriesSet = new HashSet<SubCategory>();*/

        private void generateData()
        {
            /*string myBrand = "MyBrand";

            BrandsSet.Add(myBrand);

            Category myCategory = new Category("MyCategory");

            CategoriesSet.Add(myCategory);

            SubCategory mySubCategory = new SubCategory("MySubCategory", myCategory);

            SubCategoriesSet.Add(mySubCategory);

            Product myProduct = new Product("MyDescription", "0123456789", "MyBrand", mySubCategory, 123.456f, 2);

            ProductsSet.Add(myProduct);*/
        }
    }
}
