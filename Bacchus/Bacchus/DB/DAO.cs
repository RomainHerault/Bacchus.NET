using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.DB
{
    class DAO
    {
        private SQLiteConnection Connection;
        private string DatabasePath = "..\\DB\\Bacchus.SQLite";
        public void CreateDataBase()
        {
            this.Connection = new SQLiteConnection(DatabasePath);
        }

    }
}
