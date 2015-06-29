using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parseJson
{
    public partial class FormSelectInputFiles : Form
    {
        public FormSelectInputFiles()
        {
            InitializeComponent();
        }

        private void btnSetBusinessJson_Click(object sender, EventArgs e)
        {
            txtBusinessFile.Text = SelectFile();
        }

        private void btnSetReviewsJson_Click(object sender, EventArgs e)
        {
            txtReviewsFile.Text = SelectFile();
        }

        private void btnSetUsersJson_Click(object sender, EventArgs e)
        {
            txtUsersFile.Text = SelectFile();
        }

        private string SelectFile()
        {
            var result = "";

            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    result = dialog.FileName;
                }
            }


            return result;
        }

    }
}
