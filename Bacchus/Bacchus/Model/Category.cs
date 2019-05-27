using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class Category : IListable
    {
        public int Id { get; set; }

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

        public string[] GetListColumns()
        {
            return new string[] { "Decription" };
        }

        public string[] GetListItems()
        {
            return new string[] { Description };
        }
    }
}
