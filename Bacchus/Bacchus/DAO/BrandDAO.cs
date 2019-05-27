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

        private static int Id = 0;

        private int getId()
        {
            ResetConnection();
            SQLiteCommand command = new SQLiteCommand("SELECT MAX(RefMarque) FROM Marques", Connection);
            Connection.Open();

            object Max = command.ExecuteScalar();
            int MaxId = int.Parse(Max.ToString());

            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();

            Connection.Dispose();
            Console.WriteLine(MaxId);
            return MaxId+1;
           // }
        }


        /// <summary>
        /// Ajoute une marque à la base de données si elle n'existe pas déjà
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Retourne la marque</returns>
        public override Brand Add(Brand Brand)
        {
            ResetConnection();
            SQLiteCommand command = new SQLiteCommand("SELECT RefMarque FROM Marques WHERE Nom LIKE @nom", Connection);
            command.Parameters.AddWithValue("@nom", Brand.Name);
            Connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();
         
            // Si la marque existe déjà
            if (reader.Read())
            {
                int BrandID = (int)reader["RefMarque"];

                reader.Close();
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();

                Connection.Dispose();
                Console.WriteLine("Marque existante");
                Brand.Id = BrandID;                
                return Brand;
            }
            else
            {
                Console.WriteLine("On ajoute la marque");
                ResetConnection();
                Connection.Open();
                // On l'ajoute
                using (command = new SQLiteCommand("INSERT INTO Marques(RefMarque,Nom) VALUES (@refMarque,@nom)", Connection))
                {
                    Brand.Id = getId();
                    command.Parameters.AddWithValue("@refMarque", Brand.Id);
                    command.Parameters.AddWithValue("@nom", Brand.Name);
                    command.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();

                    return Brand;
                }
            }
        }

        public override HashSet<Brand> GetList()
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

        public override Brand Get(int Id)
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

            return brand;
        }
    }

}
