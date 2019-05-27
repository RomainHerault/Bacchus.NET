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

        private static int Id = 0;

        private int getId()
        {
            return Id++;
        }

        public ProductDAO() : base() { }
        
        public override Product Add(Product Product)
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
                    // TODO: Retrieve the ids from the Product object
                    command.Parameters.AddWithValue("@refSubCategory", Product.SubCategory.Id);
                    command.Parameters.AddWithValue("@refMarque", Product.Brand.Id);
                    command.Parameters.AddWithValue("@price", Product.PricePreVAT);
                    command.Parameters.AddWithValue("@quantity", Product.Quantity);

                    command.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();
                }

                // TODO: Update the Product object
                return Product;
            }
            else
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();

                return null;
            }
        }

        public override HashSet<Product> GetList()
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
                    SubCategory SubCategory = SubCategoryDAO.Get((int)reader[2]);
                    Brand Brand = BrandDAO.Get((int)reader[3]);
                    float Price = (float)reader[4];
                    int Quantity = (int)reader[5];

                    products.Add(new Product(Description, RefArticle, Brand, SubCategory, Price, Quantity));
                }
            }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();

            return products;
        }

        public override Product Get(string Id)
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
                    SubCategory SubCategory = SubCategoryDAO.Get((int)reader[2]);
                    Brand Brand = BrandDAO.Get((int)reader[3]);
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
