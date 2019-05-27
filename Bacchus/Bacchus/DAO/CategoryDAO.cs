using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class CategoryDAO : DAO<Category, int>
    {
        public CategoryDAO() : base() { }

        private static int Id = 0;

        private int getId()
        {
            return Id++;
        }

        public override Category Add(Category Category)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT RefFamille FROM Familles WHERE Nom LIKE @nom", Connection);
            command.Parameters.AddWithValue("@nom", Category.Description);
            Connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();

            // Si la famille existe déjà
            if (reader.Read())
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();
                // On retourne son id
                return (int)reader["RefFamille"];
            }
            else
            {
                // On l'ajoute à la bdd
                using (command = new SQLiteCommand("INSERT INTO Familles(RefFamille, Nom) VALUES (@refFamille, @nom)", Connection))
                {
                    command.Parameters.AddWithValue("@refFamille", getId());
                    command.Parameters.AddWithValue("@nom", _Category.Description);

                    

                    int idCategory = (int)command.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();

                    Category.Id = idCategory;

                    return Category;
                }
            }
        }

        public override HashSet<Category> GetList()
        {
            HashSet<Category> categories = new HashSet<Category>();
            string QueryString = "SELECT Nom FROM Familles;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            Connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category((string)reader[0]));
                    }
                }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
            return categories;
        }

        public override Category Get(int Id)
        {
            Category category = null;
            string queryString = "SELECT Nom FROM Familles WHERE RefFamille = @Id;";
            SQLiteCommand command = new SQLiteCommand(queryString, Connection);
            command.Parameters.AddWithValue("@Id", Id);
            Connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                category = new Category((string)reader[0]);
            }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
            return category;
        }

    }
}
