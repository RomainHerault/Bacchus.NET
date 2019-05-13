using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    abstract class DAO
    {
        protected SQLiteConnection Connection;
        private string DatabasePath = "..\\DB\\Bacchus.SQLite";
        public DAO()
        {
            this.Connection = new SQLiteConnection(DatabasePath);
        }

    }
}
