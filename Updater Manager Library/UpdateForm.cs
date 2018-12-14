using System;
using System.Windows.Forms;

namespace UpdaterManagerLibrary
{
    public partial class UpdateForm : Form
    {
        private string versionHistory;

        public UpdateForm(string versionHistory)
        {
            InitializeComponent();

            this.versionHistory = versionHistory;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = (@"{\rtf1\ansi " + versionHistory.Replace("\n", @"\line") + @"}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
