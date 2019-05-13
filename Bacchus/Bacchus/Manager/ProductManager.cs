﻿using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Manager
{
    public class ProductManager
    {
        public List<Product> GetProductsList()
        {
            List<Product> list = new List<Product>();

            foreach (Product Product in ProductsSet) {
                list.Add(
                    Product
                );
            }

            return list;
        }

        public ProductManager()
        {
            generateData();
        }

        HashSet<string> BrandsSet = new HashSet<string>();
        HashSet<Category> CategoriesSet = new HashSet<Category>();
        HashSet<SubCategory> SubCategoriesSet = new HashSet<SubCategory>();
        HashSet<Product> ProductsSet = new HashSet<Product>();

        private void generateData()
        {
            string myBrand = "MyBrand";

            BrandsSet.Add(myBrand);

            Category myCategory = new Category("MyCategory");

            CategoriesSet.Add(myCategory);

            SubCategory mySubCategory = new SubCategory("MySubCategory", myCategory);

            SubCategoriesSet.Add(mySubCategory);

            Product myProduct = new Product("MyDescription", "0123456789", "MyBrand", mySubCategory, 123.456f, 2);

            ProductsSet.Add(myProduct);
        }
    }
}
