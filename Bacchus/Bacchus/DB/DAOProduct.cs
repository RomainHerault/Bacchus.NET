using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    class DAOProduct : DAO
    {
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
    }
}
