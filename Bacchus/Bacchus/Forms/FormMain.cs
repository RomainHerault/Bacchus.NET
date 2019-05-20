using Bacchus.Forms;
using Bacchus.Manager;
using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bacchus
{
    public partial class FormMain : Form
    {
        private ProductManager ProductManager { get; set; }

        public FormMain()
        {
            ProductManager = new ProductManager();

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

            Brand MyBrand = new Brand("MyBrand");

            Product myProduct = new Product("MyDescription", "0123456789", MyBrand, mySubCategory, 123.456f, 2);

            ProductsSet.Add(myProduct);
        }

        private void TreeView_Load(object sender, EventArgs e)
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
                TreeView.Nodes.Add(Node);
            }
        }

        private void ListView_Load(object sender, EventArgs e)
        {
            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ProductsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ListView.Columns.Clear();
            ListView.Items.Clear();

            switch (e.Node.Text)
            {
                case "Articles":

                    // Set the columns
                    foreach (var column in Product.ListColumns)
                    {
                        ColumnHeader columnHeader = new ColumnHeader();
                        columnHeader.Text = column;

                        ListView.Columns.Add(columnHeader);
                    }

                    // Set the items
                    foreach (var item in ProductManager.GetProductsList())
                    {
                        ListView.Items.Add(new ListViewItem(
                            item.ListItems()
                        ));
                    }

                    break;
            }
        }
    }
}
