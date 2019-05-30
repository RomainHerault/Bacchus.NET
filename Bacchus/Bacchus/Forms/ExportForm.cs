using Bacchus.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Forms
{
    public partial class ExportForm : Form
    {
        private string FilePath;
        public ExportForm()
        {
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            string Message = Parser.WriteFile(FilePath, ProgressBar);
            MessageBox.Show(Message, "Exportation");
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            ProgressBar.Value = ProgressBar.Minimum;
            using (SaveFileDialog SaveFileDialog = new SaveFileDialog())
            {
                // openFileDialog.InitialDirectory = "c:\\";
                SaveFileDialog.Filter = "csv files (*.csv) |*.csv";
                SaveFileDialog.FilterIndex = 2;
                SaveFileDialog.RestoreDirectory = true;

                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    this.FilePath = SaveFileDialog.FileName;
                    FileTextBox.Text = this.FilePath;
                }
            }
        }
    }
}
