﻿using Bacchus.DB;
using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Utils
{
    class Parser
    {
        private static char SEPARATOR = ';';
        private static BrandDAO BrandDAO = new BrandDAO();
        private static CategoryDAO CategoryDAO = new CategoryDAO();
        private static ProductDAO ProductDAO = new ProductDAO();
        private static SubCategoryDAO SubCategoryDAO = new SubCategoryDAO();

        public static string ReadFile(string Path, ProgressBar Pbar)
        {
            string[] Lines = System.IO.File.ReadAllLines(Path, Encoding.Default);

            // Set the initial value of the ProgressBar.
            Pbar.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            Pbar.Step = 1;

            Pbar.Minimum = 1;
            Pbar.Maximum = Lines.Length;
            int AddedProducts = 0;
            int ExistingProducts = 0;
            bool FirstLine = true;
            foreach (string Line in Lines)
            {
                if(FirstLine)
                {
                    FirstLine = false;
                }
                else
                {
                    if (WriteStringToDB(Line))
                        AddedProducts++;
                    else
                        ExistingProducts++;
                }
                Pbar.PerformStep();
            }
            string Message = "Importation réussie ! \n" +
                             "Nombre d'articles ajoutés " + AddedProducts + "\n" +
                             "Nombre d'articles déjà existants " + ExistingProducts;
            Console.WriteLine("Nombre d'objets ajoutés " + AddedProducts);
            Console.WriteLine("Nombre d'objets existants " + ExistingProducts);

            return Message;
        }

        public static bool WriteStringToDB(string Line)
        {
            string[] Objects = Line.Split(SEPARATOR);
            //Description; Ref; Marque; Famille; Sous - Famille; Prix H.T.
            string Description = Objects[0];
            string Ref = Objects[1];
            Brand Brand = new Brand(Objects[2]);
            Brand = BrandDAO.Add(Brand);

            Category Category = new Category(Objects[3]);
            Category = CategoryDAO.Add(Category);

            SubCategory SubCategory = new SubCategory(Objects[4], Category);
            SubCategory = SubCategoryDAO.Add(SubCategory);

            float Price = 0;
            Objects[5] = Objects[5].Replace(',', '.');
            Price = float.Parse(Objects[5], CultureInfo.InvariantCulture.NumberFormat);
            Product Product = new Product(Description, Ref, Brand, SubCategory, Price, 0);

            

            if (ProductDAO.Add(Product) != null)
                return true;
            else
                return false;
        }

        public static string WriteFile(string Path, ProgressBar Pbar)
        {
            Pbar.Value = 1;
            Pbar.Step = 1;
            Pbar.Minimum = 1;
            
            HashSet<Product> Products = ProductDAO.GetList();
            string[] Lines = new string[Products.Count+1];

            Pbar.Maximum = Lines.Length;
            int LinesCount = 1;
            Lines[0] = "Description;Ref;Marque;Famille;Sous-Famille;Prix H.T.";
            foreach (Product Product in Products)
            {
                string productString = "";
                productString += Product.Description;
                productString += SEPARATOR;
                productString += Product.Ref;
                productString += SEPARATOR;
                productString += Product.Brand.Name;
                productString += SEPARATOR;
                productString += Product.SubCategory.Category.Description;
                productString += SEPARATOR;
                productString += Product.SubCategory.Description;
                productString += SEPARATOR;
                productString += Product.PricePreVAT;
                Lines[LinesCount] = productString;
                LinesCount++;
                Pbar.PerformStep();
            }
            System.IO.File.WriteAllLines(Path, Lines, Encoding.Default);
            string Message = "Exportation réussie \n" +
                             Products.Count + " articles exportés";
            return Message;
        }
    }
}
