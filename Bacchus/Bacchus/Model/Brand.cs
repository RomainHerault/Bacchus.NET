
namespace Bacchus.Model
{
    public class Brand
    {
        public static string[] ListColumns = { "Nom" };

        public string Name { get; set; }

        public Brand(string Name)
        {
            this.Name = Name;
        }

        public string[] ListItems()
        {
            return new string[] { Name };
        }
    }
}
