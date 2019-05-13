using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class DAOCategory : DAO
    {
        public DAOCategory() : base() { }

        public int AddCategory(Category _Category)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT RefFamille FROM Familles WHERE Nom LIKE @nom", Connection);
            command.Parameters.AddWithValue("@nom", _Category.Description);
            SQLiteDataReader reader = command.ExecuteReader();

            //Si la famille existe déjà
            if (reader.Read())
            {
                //On retourne son id
                return (int)reader["RefFamille"];
            }
            else
            {
                //On l'ajoute à la bdd
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Familles(Nom) VALUES (@nom)", Connection))
                {
                    cmd.Parameters.AddWithValue("@nom", _Category.Description);

                    Connection.Open();

                    int idCategory = (int)cmd.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();

                    return idCategory;
                }
            }
        }

        public HashSet<Category> getCategories()
        {
            HashSet<Category> Categories = new HashSet<Category>();
            string QueryString = "SELECT Nom FROM Familles;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            using (Connection)
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categories.Add(new Category((string)reader[0]));
                    }
                }
            }
            return Categories;
        }

        public Category getCategory(int Id)
        {
            Category _Category = null;
            string QueryString = "SELECT Nom FROM Familles WHERE RefFamille = @Id;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            command.Parameters.AddWithValue("@Id", Id);
            using (Connection)
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    _Category = new Category((string)reader[0]);
                }
            }
            return _Category;
        }

    }
}
