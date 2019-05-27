using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class ProductDAO : DAO
    {
        private SubCategoryDAO SubCategoryDAO = new SubCategoryDAO();
        private BrandDAO BrandDAO = new BrandDAO();
        public ProductDAO() : base() { }

        public bool AddProduct(Product Product, int SubcategoryId, int BrandId)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Articles WHERE RefArticle LIKE @ref ", Connection);
            command.Parameters.AddWithValue("@ref", Product.Ref);
            Connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();

            // Si l'article n'existe pas
            if (!reader.Read())
            {
                using (command = new SQLiteCommand("INSERT INTO Articles(RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite) VALUES (@ref, @desc, @refSubCategory, @refMarque, @price, @quantity)", Connection))
                {
                    command.Parameters.AddWithValue("@ref", Product.Ref);
                    command.Parameters.AddWithValue("@desc", Product.Description);
                    command.Parameters.AddWithValue("@refSubCategory", SubcategoryId);
                    command.Parameters.AddWithValue("@refMarque", BrandId);
                    command.Parameters.AddWithValue("@price", Product.PricePreVAT);
                    command.Parameters.AddWithValue("@quantity", Product.Quantity);
                    Connection.Open();

                    command.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();
                }
                return true;
            }
            else
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();

                return false;
            }
        }

        public HashSet<Product> GetProducts()
        {
            HashSet<Product> products = new HashSet<Product>();
            string QueryString = "SELECT RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite FROM Articles;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            Connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string RefArticle = (string)reader[0];
                    string Description = (string)reader[1];
                    SubCategory SubCategory = SubCategoryDAO.GetSubCategory((int)reader[2]);
                    Brand Brand = BrandDAO.GetBrand((int)reader[3]);
                    float Price = (float)reader[4];
                    int Quantity = (int)reader[5];

                    products.Add(new Product(Description, RefArticle, Brand, SubCategory, Price, Quantity));
                }
            }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();

            return products;
        }

        public Product GetProduct(string Id)
        {
            Product Product = null;
            string QueryString = "SELECT RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite FROM Articles WHERE RefArticle LIKE @Id;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            command.Parameters.AddWithValue("@Id", Id);
            Connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    string RefArticle = (string)reader[0];
                    string Description = (string)reader[1];
                    SubCategory SubCategory = SubCategoryDAO.GetSubCategory((int)reader[2]);
                    Brand Brand = BrandDAO.GetBrand((int)reader[3]);
                    float Price = (float)reader[4];
                    int Quantity = (int)reader[5];

                    Product = new Product(Description, RefArticle, Brand, SubCategory, Price, Quantity);
                }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
                return Product;
        }
    }
}
