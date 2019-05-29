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

        private int getId()
        {
            return getId("SELECT MAX(RefFamille) FROM Familles");
        }

        public override Category Add(Category Category)
        {
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT RefFamille FROM Familles WHERE Nom LIKE @nom", c))
                {
                    cmd.Parameters.AddWithValue("@nom", Category.Description);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        // Si la famille existe déjà
                        if (reader.Read())
                        {
                            Console.WriteLine("Category existante");
                            int CategoryId = (int)reader["RefFamille"];

                            Category.Id = CategoryId;

                            return Category;
                        }
                        else
                        {
                            Console.WriteLine("On ajoute la category");

                            // On l'ajoute à la bdd
                            using (SQLiteCommand Command = new SQLiteCommand("INSERT INTO Familles(RefFamille, Nom) VALUES (@refFamille, @nom)", c))
                            {
                                Category.Id = getId();
                                Command.Parameters.AddWithValue("@refFamille", Category.Id);
                                Command.Parameters.AddWithValue("@nom", Category.Description);
                                Command.ExecuteNonQuery();
                                return Category;
                            }
                        }
                    }
                }
            }
   
        }

        public override HashSet<Category> GetList()
        {

            HashSet<Category> categories = new HashSet<Category>();

            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT Nom FROM Familles;", c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category((string)reader[0]));
                        }
                    }
                }
            }
            return categories;
        }

        public override Category Get(int Id)
        {
            Category category = null;

            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT Nom FROM Familles WHERE RefFamille = @Id;", c))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        category = new Category((string)reader[0]);
                    }
                }
            }
            return category;
        }

    }
}
