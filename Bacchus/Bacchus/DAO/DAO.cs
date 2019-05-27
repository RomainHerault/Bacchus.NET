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
        private static string DatabasePath = "DataSource=" + AppDomain.CurrentDomain.BaseDirectory + "\\DB\\Bacchus.SQLite";

        protected SQLiteConnection Connection;

        public DAO()
        {
            Connection = new SQLiteConnection(DatabasePath);
        }

        public abstract T Get(P id);

        public abstract HashSet<T> GetList();

        public abstract T Add(T obj);
    }
}
