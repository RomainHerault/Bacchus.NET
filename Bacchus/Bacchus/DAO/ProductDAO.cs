using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class ProductDAO : DAO<Product, string>
    {
        private SubCategoryDAO SubCategoryDAO = new SubCategoryDAO();
        private BrandDAO BrandDAO = new BrandDAO();

        public ProductDAO() : base() { }
        
        public override Product Add(Product Product)
        {
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Articles WHERE RefArticle LIKE @ref ", c))
                {
                    cmd.Parameters.AddWithValue("@ref", Product.Ref);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        // Si l'article n'existe pas
                        if (!reader.Read())
                        {
                            using (SQLiteCommand Command = new SQLiteCommand("INSERT INTO Articles(RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite) VALUES (@ref, @desc, @refSubCategory, @refMarque, @price, @quantity)", c))
                            {
                                Command.Parameters.AddWithValue("@ref", Product.Ref);
                                Command.Parameters.AddWithValue("@desc", Product.Description);
                                // TODO: Retrieve the ids from the Product object
                                Command.Parameters.AddWithValue("@refSubCategory", Product.SubCategory.Id);
                                Command.Parameters.AddWithValue("@refMarque", Product.Brand.Id);
                                Command.Parameters.AddWithValue("@price", Product.PricePreVAT);
                                Command.Parameters.AddWithValue("@quantity", Product.Quantity);

                                Command.ExecuteScalar();
                            }

                            // TODO: Update the Product object
                            return Product;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }    
        }

        public override HashSet<Product> GetList()
        {
            HashSet<Product> products = new HashSet<Product>();
            string QueryString = "SELECT RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite FROM Articles;";
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(QueryString, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string RefArticle = (string)reader[0];
                            string Description = (string)reader[1];
                            SubCategory SubCategory = SubCategoryDAO.Get((int)reader[2]);
                            Brand Brand = BrandDAO.Get((int)reader[3]);
                            float Price = (float)(double)reader[4];
                            int Quantity = (int)reader[5];

                            products.Add(new Product(Description, RefArticle, Brand, SubCategory, Price, Quantity));
                        }
                    }
                }
            }
            return products;
        }

        public override Product Get(string Id)
        {
            Product Product = null;
            string QueryString = "SELECT RefArticle, Description, RefSousFamille, RefMarque, PrixHT, Quantite FROM Articles WHERE RefArticle LIKE @Id;";
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(QueryString, c))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        string RefArticle = (string)reader[0];
                        string Description = (string)reader[1];
                        SubCategory SubCategory = SubCategoryDAO.Get((int)reader[2]);
                        Brand Brand = BrandDAO.Get((int)reader[3]);
                        float Price = (float)reader[4];
                        int Quantity = (int)reader[5];

                        Product = new Product(Description, RefArticle, Brand, SubCategory, Price, Quantity);
                    }
                }
            }
            return Product;
        }
    }
}
