using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    class DAOSubCategory : DAO
    {
        public DAOSubCategory() : base() { }

        public int AddSubCategory(SubCategory _SubCategory, int CategoryID)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT RefSousFamille FROM SousFamilles WHERE Nom LIKE @nom AND RefFamille = @refFamille", Connection);
            command.Parameters.AddWithValue("@nom", _SubCategory.Description);
            command.Parameters.AddWithValue("@refFamille", CategoryID);
            SQLiteDataReader reader = command.ExecuteReader();

            //Si la sous-famille existe déjà
            if (reader.Read())
            {
                //On retourne son id
                return (int)reader["RefSousFamille"];
            }
            else
            {
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO SousFamilles(RefFamille, Nom) VALUES (@refFamille, @nom)", Connection))
                {
                    cmd.Parameters.AddWithValue("@refFamille", CategoryID);
                    cmd.Parameters.AddWithValue("@nom", _SubCategory.Description);

                    Connection.Open();

                    int idSubCategory = (int)cmd.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();
                    return idSubCategory;
                }
            }
        }
    }
}
