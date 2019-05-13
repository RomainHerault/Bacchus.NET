using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class DAOBrand : DAO
    {
        public DAOBrand() : base() { }

        /// <summary>
        /// Ajoute une marque à la base de données si elle n'existe pas déjà
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Retourne l'id de la marque</returns>
        public int AddBrand(string brand)
        {
  
            SQLiteCommand command = new SQLiteCommand("SELECT RefMarque FROM Marques WHERE Nom LIKE @nom", Connection);
            command.Parameters.AddWithValue("@nom", brand);
            SQLiteDataReader reader = command.ExecuteReader();
         
            //Si la marque existe déjà
            if (reader.Read())
            {
                //On retourne son id
                return (int)reader["RefMarque"];
            }
            else
            {
                //On l'ajoute
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Marques(Nom) VALUES (@nom)", Connection))
                {
                    cmd.Parameters.AddWithValue("@nom", brand);

                    Connection.Open();

                    int idBrand = (int)cmd.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();

                    return idBrand;
                }
            }
        }

        public HashSet<String> getBrands()
        {
            HashSet<String> Brands = new HashSet<string>();
            string QueryString = "SELECT * FROM Marques;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            using (Connection)
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Brands.Add((string) reader[0]);
                    }
                }
            }
            return Brands;
        }

        public string getBrand(int Id)
        {
            string Brand = null;
            string QueryString = "SELECT Nom FROM Marques WHERE RefMarque = @Id;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            command.Parameters.AddWithValue("@Id", Id);
            using (Connection)
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                        Brand = (string)reader[0];
                }
            }
            return Brand;
        }
    }

}
