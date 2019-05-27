﻿using Bacchus.Model;
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

        public override SubCategory Add(SubCategory SubCategory/*, int CategoryID*/)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT RefSousFamille FROM SousFamilles WHERE Nom LIKE @nom AND RefFamille = @refFamille", Connection);
            command.Parameters.AddWithValue("@nom", SubCategory.Description);
            // TODO: Récupérer la l'id de la Category depuis l'object SubCategory
            //command.Parameters.AddWithValue("@refFamille", CategoryID);

            Connection.Open();

            SQLiteDataReader reader = command.ExecuteReader();

            // Si la sous-famille existe déjà
            if (reader.Read())
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                    Connection.Close();

                // On retourne null
                return null;
            }
            else
            {
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO SousFamilles(RefFamille, Nom) VALUES (@refFamille, @nom)", Connection))
                {
                    // TODO: Récupérer la l'id de la Category depuis l'object SubCategory
                    //cmd.Parameters.AddWithValue("@refFamille", CategoryID);
                    cmd.Parameters.AddWithValue("@nom", SubCategory.Description);

                    int idSubCategory = (int)cmd.ExecuteScalar();

                    if (Connection.State == System.Data.ConnectionState.Open)
                        Connection.Close();

                    SubCategory.Id = idSubCategory;

                    return SubCategory;
                }
            }
        }
        public override HashSet<SubCategory> GetList()
        {
            HashSet<SubCategory> SubCategories = new HashSet<SubCategory>();
            string QueryString = "SELECT RefFamille, Nom FROM SousFamilles;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            Connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SubCategories.Add(new SubCategory((string)reader[1], DaoCategory.Get((int)reader[0])));
                    }
                }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
            return SubCategories;
        }

        public override SubCategory Get(int Id)
        {
            SubCategory _SubCategory = null;
            string QueryString = "SELECT RefFamille, Nom FROM SousFamilles WHERE RefSousFamille = @Id;";
            SQLiteCommand command = new SQLiteCommand(QueryString, Connection);
            command.Parameters.AddWithValue("@Id", Id);
            Connection.Open();
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                Category _Category = DaoCategory.Get((int)reader[0]);
                _SubCategory = new SubCategory((string)reader[1], _Category);
            }
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
            return _SubCategory;
        }

    }
}