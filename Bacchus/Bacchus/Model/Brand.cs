
namespace Bacchus.Model
{
    public class Brand
    {
        public static string[] ListColumns = { "Name" };

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

        public string[] ListItems()
        {
            return new string[] { Name };
        }
    }
}
