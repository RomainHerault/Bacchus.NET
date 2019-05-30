using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class SubCategoryDAO : DAO<SubCategory, int>
    {
        private CategoryDAO DaoCategory = new CategoryDAO();

        public SubCategoryDAO() : base() { }

        private int getId()
        {
            return getId("SELECT MAX(RefSousFamille) FROM SousFamilles");
        }


        public override SubCategory Add(SubCategory SubCategory/*, int CategoryID*/)
        {
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT RefSousFamille FROM SousFamilles WHERE Nom LIKE @nom AND RefFamille = @refFamille", c))
                {
                    cmd.Parameters.AddWithValue("@nom", SubCategory.Description);
                    cmd.Parameters.AddWithValue("@refFamille", SubCategory.Category.Id);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        // Si la sous-famille existe déjà
                        if (reader.Read())
                        {
                            int SubCategoryId = (int)reader["RefSousFamille"];

                            // On retourne l'objet
                            SubCategory.Id = SubCategoryId;
                            return SubCategory;
                        }
                        else
                        {

                            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO SousFamilles(RefSousFamille, RefFamille, Nom) VALUES (@refSousFamille, @refFamille, @nom)", c))
                            {
                                SubCategory.Id = getId();

                                command.Parameters.AddWithValue("@refSousFamille", SubCategory.Id);
                                command.Parameters.AddWithValue("@refFamille", SubCategory.Category.Id);
                                command.Parameters.AddWithValue("@nom", SubCategory.Description);
                                command.ExecuteScalar();

                                return SubCategory;
                            }
                        }
                    }
                }
            }
        }
        public override HashSet<SubCategory> GetList()
        {
            HashSet<SubCategory> SubCategories = new HashSet<SubCategory>();


            string QueryString = "SELECT RefFamille, Nom FROM SousFamilles;";

            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(QueryString, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SubCategories.Add(new SubCategory((string)reader[1], DaoCategory.Get((int)reader[0])));
                        }
                    }
                }
            }
            return SubCategories;
        }

        public override SubCategory Get(int Id)
        {
            SubCategory SubCategory = null;
            string QueryString = "SELECT RefFamille, Nom FROM SousFamilles WHERE RefSousFamille = @Id;";
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(QueryString, c))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        Category Category = DaoCategory.Get((int)reader[0]);
                        SubCategory = new SubCategory((string)reader[1], Category);
                    }
                }
            }
            return SubCategory;
        }

    }
}