using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class DAOProduct : DAO
    {
        private DAOSubCategory DaoSubCategory = new DAOSubCategory();
        private DAOBrand DaoBrand = new DAOBrand();
        public DAOProduct() : base() { }

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

        public HashSet<Product> getProducts()
        {
            HashSet<Product> Products = new HashSet<Product>();
            string QueryString = "SELECT RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite FROM Articles;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            using (Connection)
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string RefArticle = (string)reader[0];
                        string Description = (string)reader[1];
                        SubCategory _SubCategory = DaoSubCategory.getSubCategory((int)reader[2]);
                        String Brand = DaoBrand.getBrand((int)reader[3]);
                        float Price = (float)reader[4];
                        int Quantity = (int)reader[5];

                        Products.Add(new Product(Description, RefArticle, Brand, _SubCategory, Price, Quantity));
                    }
                }
            }
            return Products;
        }

        public Product getProduct(string Id)
        {
            Product _Product = null;
            string QueryString = "SELECT RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite FROM Articles WHERE RefArticle LIKE @Id;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            command.Parameters.AddWithValue("@Id", Id);
            using (Connection)
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    string RefArticle = (string)reader[0];
                    string Description = (string)reader[1];
                    SubCategory _SubCategory = DaoSubCategory.getSubCategory((int)reader[2]);
                    String Brand = DaoBrand.getBrand((int)reader[3]);
                    float Price = (float)reader[4];
                    int Quantity = (int)reader[5];

                    _Product = new Product(Description, RefArticle, Brand, _SubCategory, Price, Quantity);
                }
            }
            return _Product;
        }
    }
}
