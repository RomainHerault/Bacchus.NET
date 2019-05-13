using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    class DAOBrand : DAO
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
    }
}
