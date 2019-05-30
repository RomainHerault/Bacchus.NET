using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public abstract class DAO<T, P>
    {
        protected static string DatabasePath = "DataSource=" + AppDomain.CurrentDomain.BaseDirectory + "\\DB\\Bacchus.SQLite";

        public static void DeleteDatabase()
        {
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Articles; DELETE FROM SousFamilles; DELETE FROM Familles; DELETE FROM Marques;", c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected int getId(string Query)
        {

            int MaxId;
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(Query, c))
                {
                    object Max = cmd.ExecuteScalar();
                    if (!Max.ToString().Equals("") && Max.ToString() != null)
                    {
                        MaxId = int.Parse(Max.ToString());
                    }
                    else
                    {
                        MaxId = 0;
                    }
                }
            }
            return MaxId + 1;
        }
        public abstract T Get(P id);

        public abstract HashSet<T> GetList();

        public abstract T Add(T obj);
    }
}
