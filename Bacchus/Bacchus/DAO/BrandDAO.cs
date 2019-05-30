using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class BrandDAO : DAO<Brand, int>
    {
        
        public BrandDAO() : base() { }

        private int getId()
        {
            return getId("SELECT MAX(RefMarque) FROM Marques");
        }


        /// <summary>
        /// Ajoute une marque à la base de données si elle n'existe pas déjà
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Retourne la marque</returns>
        public override Brand Add(Brand Brand)
        {
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT RefMarque FROM Marques WHERE Nom LIKE @nom", c))
                {
                    cmd.Parameters.AddWithValue("@nom", Brand.Name);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int BrandID = (int)reader["RefMarque"];
                            Brand.Id = BrandID;
                            return Brand;
                        }
                        else
                        {
                            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Marques(RefMarque,Nom) VALUES (@refMarque,@nom)", c))
                            {
                                Brand.Id = getId();
                                command.Parameters.AddWithValue("@refMarque", Brand.Id);
                                command.Parameters.AddWithValue("@nom", Brand.Name);
                                command.ExecuteNonQuery();

                                return Brand;
                            }
                        }
                    }
                }
            }
        }

        public override HashSet<Brand> GetList()
        {
            HashSet<Brand> Brands = new HashSet<Brand>();

            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                string QueryString = "SELECT * FROM Marques;";
                using (SQLiteCommand cmd = new SQLiteCommand(QueryString, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Brands.Add(new Brand((string)reader[0]));
                        }
                    }
                }
            }
            return Brands;
        }

        public override Brand Get(int Id)
        {
            Brand brand = null;

            string QueryString = "SELECT Nom FROM Marques WHERE RefMarque = @Id;";

            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(QueryString, c))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        brand = new Brand((string)reader[0]);
                    }
                }
            }

            return brand;
        }
    }

}
