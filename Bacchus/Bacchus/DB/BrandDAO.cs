using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public class BrandDAO : DAO
    {
        public BrandDAO() : base() { }

        /// <summary>
        /// Ajoute une marque à la base de données si elle n'existe pas déjà
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Retourne l'id de la marque</returns>
        public int AddBrand(Brand Brand)
        {
  
            SQLiteCommand command = new SQLiteCommand("SELECT RefMarque FROM Marques WHERE Nom LIKE @nom", Connection);
            command.Parameters.AddWithValue("@nom", Brand.Nom);
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
                using (command = new SQLiteCommand("INSERT INTO Marques(Nom) VALUES (@nom)", Connection))
                {
                    command.Parameters.AddWithValue("@nom", Brand.Nom);

                    Connection.Open();

                    int idBrand = (int)command.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();

                    return idBrand;
                }
            }
        }

        public HashSet<Brand> GetBrands()
        {
            HashSet<Brand> Brands = new HashSet<Brand>();
            string QueryString = "SELECT * FROM Marques;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            Connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Brands.Add(new Brand((string) reader[0]));
                    }
                }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
            return Brands;
        }

        public Brand GetBrand(int Id)
        {
            Brand brand = null;
            string queryString = "SELECT Nom FROM Marques WHERE RefMarque = @Id;";
            SQLiteCommand command = new SQLiteCommand(queryString, Connection);
            command.Parameters.AddWithValue("@Id", Id);
            Connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    brand = new Brand((string)reader[0]);
                }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
            return Brand;
        }
    }

}
