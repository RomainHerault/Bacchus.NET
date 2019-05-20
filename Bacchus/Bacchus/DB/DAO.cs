using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    public abstract class DAO
    {
        private static string DatabasePath = "DataSource=" + AppDomain.CurrentDomain.BaseDirectory + "\\DB\\Bacchus.SQLite";

        protected SQLiteConnection Connection;

        public DAO()
        {
            Connection = new SQLiteConnection(DatabasePath);
        }

    }
}
