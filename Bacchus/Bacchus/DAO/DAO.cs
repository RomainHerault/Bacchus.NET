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

        protected int getId(string Query)
        {

            int MaxId;
            using (SQLiteConnection c = new SQLiteConnection(DatabasePath))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(Query, c))
                {
                    object Max = cmd.ExecuteScalar();
                    Console.WriteLine(Max);

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
            Console.WriteLine(MaxId);
            return MaxId + 1;
        }
        /*protected SQLiteConnection Connection;

        public DAO()
        {
            Connection = new SQLiteConnection(DatabasePath);
        }

        protected void ResetConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
            Connection.Dispose();
            Connection = new SQLiteConnection(DatabasePath);
        }*/

        public abstract T Get(P id);

        public abstract HashSet<T> GetList();

        public abstract T Add(T obj);
    }
}
