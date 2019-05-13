using Bacchus.Forms;
using Bacchus.Manager;
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
                TreeView.Nodes.Add(Node);
            }
        }

        private void ProductsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ListView.Items.Clear();

            switch (e.Node.Text)
            {
                case "Articles":

                    // Set the columns
                    foreach (var column in Product.ListColumns)
                    {
                        ListView.Columns.Add(new ColumnHeader(
                            column
                        ));
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

            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            ListView.Show();
        }
    }
}
