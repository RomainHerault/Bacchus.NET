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
        private SubCategoryDAO DaoSubCategory = new SubCategoryDAO();
        private BrandDAO DaoBrand = new BrandDAO();
        public ProductDAO() : base() { }

        public void AddProduct(Product _Product, int SubcategoryId, int BrandID, int Quantity)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Articles WHERE RefArticle LIKE @ref ", Connection);
            command.Parameters.AddWithValue("@ref", _Product.Ref);
            SQLiteDataReader reader = command.ExecuteReader();

            //Si l'article n'existe pas
            if (!reader.Read())
            {
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Articles(RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite) VALUES (@ref, @desc, @refSubCategory, @refMarque, @price, @quantity)", Connection))
                {
                    cmd.Parameters.AddWithValue("@ref", _Product.Ref);
                    cmd.Parameters.AddWithValue("@desc", _Product.Description);
                    cmd.Parameters.AddWithValue("@refSubCategory", SubcategoryId);
                    cmd.Parameters.AddWithValue("@refMarque", BrandID);
                    cmd.Parameters.AddWithValue("@price", _Product.PricePreVAT);
                    cmd.Parameters.AddWithValue("@quantity", Quantity);
                    Connection.Open();

                    cmd.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();
                }
            }
        }

        public HashSet<Product> GetProducts()
        {
            HashSet<Product> Products = new HashSet<Product>();
            string QueryString = "SELECT RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite FROM Articles;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            Connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string RefArticle = (string)reader[0];
                    string Description = (string)reader[1];
                    SubCategory SubCategory = DaoSubCategory.GetSubCategory((int)reader[2]);
                    String Brand = DaoBrand.GetBrand((int)reader[3]);
                    float Price = (float)reader[4];
                    int Quantity = (int)reader[5];

                    Products.Add(new Product(Description, RefArticle, Brand, SubCategory, Price, Quantity));
                }
            }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();

            return Products;
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
                    SubCategory SubCategory = DaoSubCategory.GetSubCategory((int)reader[2]);
                    String Brand = DaoBrand.GetBrand((int)reader[3]);
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
