using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class Category
    {
        public int Id { get; set; }

        public static string[] ListColumns = { "Decription" };

        public string Description { get; set; }

        public Category(string Description)
        {
            this.Description = Description;
        }

        public Category(int Id, string Description)
        {
            this.Id = Id;
            this.Description = Description;
        }

        public string[] ListItems()
        {
            return new string[] { Description };
        }
    }
}
