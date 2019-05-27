
namespace Bacchus.Model
{
    public class Brand : IListable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Brand(string Name)
        {
            this.Name = Name;
        }

        public Brand(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public string[] GetListColumns()
        {
            return new string[] { "Name" };
        }

        public string[] GetListItems()
        {
            return new string[] { Name };
        }
    }
}
