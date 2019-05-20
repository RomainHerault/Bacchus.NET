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
        protected SQLiteConnection Connection;

        private string DatabasePath = "..\\DB\\Bacchus.SQLite";

        public DAO()
        {
            Connection = new SQLiteConnection(DatabasePath);
        }

    }
}
