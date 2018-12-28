using System;
using System.Windows.Forms;

namespace UpdaterManagerLibrary
{
    internal partial class UpdateForm : Form
    {
        #region GLOBAL_VARIABLE
        private string versionHistory;
        #endregion

        #region FORM_EVENTS
        public UpdateForm(string versionHistory)
        {
            InitializeComponent();

            this.versionHistory = versionHistory;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            richTextBoxChangelog.Text = versionHistory;

            richTextBoxChangelog.Rtf = richTextBoxChangelog.Rtf.Replace(@"\\", @"\").Replace(@"\tab", "    ");
        }
        #endregion

        #region BUTTON_EVENT
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }
        #endregion
    }
}
