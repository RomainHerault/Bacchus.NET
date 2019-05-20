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
            Parser.ReadFile(FilePath);
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            //var fileContent = string.Empty;
            //var filePath = string.Empty;
            Console.WriteLine("Coucou, vous avez bien cliqué sur le bouton séléctionner");
            using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
            {
                Console.WriteLine("Coucou, la boite de dialogue à du se lancer");
                // openFileDialog.InitialDirectory = "c:\\";
                OpenFileDialog.Filter = "csv files (*.csv) |*.csv";
                OpenFileDialog.FilterIndex = 2;
                OpenFileDialog.RestoreDirectory = true;
                Console.WriteLine("Coucou, j'en ai marre");

                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Coucou, là vous avez cliqué sur oK");
                    //Get the path of specified file
                    this.FilePath = OpenFileDialog.FileName;

                   /* //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        this.FilePath = reader.ReadToEnd();
                    }
                    */
                    FileTextBox.Text = this.FilePath;
                }
            }
        }

        private void OverwriteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
