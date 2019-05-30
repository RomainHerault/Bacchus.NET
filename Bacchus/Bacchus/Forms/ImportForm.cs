using Bacchus.DB;
using Bacchus.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Forms
{
    public partial class ImportForm : Form
    {
        private string FilePath;

        public ImportForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(FilePath == null || FilePath.Equals(""))
            {
                MessageBox.Show("Vous devez choisir un fichier", "Importation");
            }
            else
            {
                string Message = Parser.ReadFile(FilePath, ProgressBar);
                MessageBox.Show(Message, "Importation");
            }
            
        }

        private void OverwriteButton_Click(object sender, EventArgs e)
        {
            if (FilePath == null || FilePath.Equals(""))
            {
                MessageBox.Show("Vous devez choisir un fichier", "Importation");
            }
            else
            {
                DAO<string, int>.DeleteDatabase();
                string Message = Parser.ReadFile(FilePath, ProgressBar);
                MessageBox.Show(Message, "Importation");
            }
            
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            ProgressBar.Value = ProgressBar.Minimum;
            using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
            {
                // openFileDialog.InitialDirectory = "c:\\";
                OpenFileDialog.Filter = "csv files (*.csv) |*.csv";
                OpenFileDialog.FilterIndex = 2;
                OpenFileDialog.RestoreDirectory = true;

                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    this.FilePath = OpenFileDialog.FileName;
                    FileTextBox.Text = this.FilePath;
                }
            }
        }
    }
}
