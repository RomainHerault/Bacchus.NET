using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class CategoryDAO : DAO
    {
        public CategoryDAO() : base() { }

        public int AddCategory(Category _Category)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT RefFamille FROM Familles WHERE Nom LIKE @nom", Connection);
            command.Parameters.AddWithValue("@nom", _Category.Description);
            SQLiteDataReader reader = command.ExecuteReader();

            // Si la famille existe déjà
            if (reader.Read())
            {
                // On retourne son id
                return (int)reader["RefFamille"];
            }
            else
            {
                // On l'ajoute à la bdd
                using (command = new SQLiteCommand("INSERT INTO Familles(Nom) VALUES (@nom)", Connection))
                {
                    command.Parameters.AddWithValue("@nom", _Category.Description);

                    Connection.Open();

                    int idCategory = (int)command.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();

                    return idCategory;
                }
            }
        }

        public HashSet<Category> GetCategories()
        {
            HashSet<Category> categories = new HashSet<Category>();
            string queryString = "SELECT Nom FROM Familles;";
            SQLiteCommand command = new SQLiteCommand(queryString, Connection);
            using (Connection)
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category((string)reader[0]));
                    }
                }
            }
            return categories;
        }

        public Category GetCategory(int Id)
        {
            Category category = null;
            string queryString = "SELECT Nom FROM Familles WHERE RefFamille = @Id;";
            SQLiteCommand command = new SQLiteCommand(queryString, Connection);
            command.Parameters.AddWithValue("@Id", Id);
            using (Connection)
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    category = new Category((string)reader[0]);
                }
            }
            return category;
        }

    }
}
