using Bacchus.Forms;
using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ImportForm Import = new ImportForm();
           Import.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        HashSet<Product> ProductsSet = new HashSet<Product>();
        HashSet<Category> CategoriesSet = new HashSet<Category>();
        HashSet<SubCategory> SubCategoriesSet = new HashSet<SubCategory>();

        private void generateData()
        {
            Category myCategory = new Category("MyCategory");

            CategoriesSet.Add(myCategory);

            SubCategory mySubCategory = new SubCategory("MySubCategory", myCategory);

            SubCategoriesSet.Add(mySubCategory);

            Product myProduct = new Product("MyDescription", "0123456789", "MyBrand", mySubCategory, 123.456f);

            ProductsSet.Add(myProduct);
        }

        private void ProductsTreeView_Load(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            //List<Product> SortedProductsList = ProductsSet.ToList().OrderBy(p => p.SubCategory.Category.Description).ToList();

            var Nodes = new List<TreeNode>() {
                new TreeNode("Articles"),
                new TreeNode("Marques"),
                new TreeNode("Familles"),
                new TreeNode("Sous-familles")
            };

            foreach (TreeNode Node in Nodes)
            {
                ProductsTreeView.Nodes.Add(Node);
            }
        }

        private void ProductsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
    }
}
