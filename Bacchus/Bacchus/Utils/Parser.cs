using Bacchus.DB;
using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Utils
{
    class Parser
    {
        private static BrandDAO BrandDAO = new BrandDAO();
        private static CategoryDAO CategoryDAO = new CategoryDAO();
        private static ProductDAO ProductDAO = new ProductDAO();
        private static SubCategoryDAO SubCategoryDAO = new SubCategoryDAO();

        public static void ReadFile(string path)
        {
            string[] Lines = System.IO.File.ReadAllLines(path);

            int AddedProducts = 0;
            int ExistingProducts = 0;
            foreach (string Line in Lines)
            {
                if (WriteStringToDB(Line))
                    AddedProducts++;
                else
                    ExistingProducts++;
            }
            Console.WriteLine("Nombre d'objets ajoutés" + AddedProducts);
            Console.WriteLine("Nombre d'objets existants" + ExistingProducts);


        }

        public static bool WriteStringToDB(string Line)
        {
            string[] Objects = Line.Split(';');
            //Description; Ref; Marque; Famille; Sous - Famille; Prix H.T.
            string Description = Objects[0];
            string Ref = Objects[1];
            Brand Brand = new Brand(Objects[2]);
            Category Category = new Category(Objects[3]);
            SubCategory SubCategory = new SubCategory(Objects[4], Category);
            int Price = 0 ;
            Product Product = new Product(Description, Ref, Brand, SubCategory, Price, 0);

            Int32.TryParse(Objects[5],out Price);

            //Add to the BD
            Brand = BrandDAO.AddBrand(Brand);
            Category = CategoryDAO.AddCategory(Category);
            SubCategory = SubCategoryDAO.AddSubCategory(SubCategory, CategoryId);
            if (ProductDAO.AddProduct(Product, SubCategoryId, BrandId) != null)
                return true;
            else
                return false;
        }

    }
}
