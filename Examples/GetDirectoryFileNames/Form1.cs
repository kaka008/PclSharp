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

namespace GetDirectoryFileNames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_getFileNames_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txt_DirectoryPath.Text))
            {
                return;
            }
            var files = Directory.GetFiles(txt_DirectoryPath.Text);

            foreach (var file in files)
            {
                var result = System.Text.RegularExpressions.Regex.IsMatch(file, txt_Regex.Text);
                if (result)
                {
                    txt_fileNames.AppendText(txt_nameHead.Text+System.IO.Path.GetFileName(file) + Environment.NewLine);
                }
            }
        }

        private void btn_chooseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                String DirPath = f.SelectedPath;
                this.txt_DirectoryPath.Text = DirPath;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.txt_fileNames.Clear();
        }

        private void txt_Regex_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
