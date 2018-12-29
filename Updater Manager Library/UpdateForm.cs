using System;
using System.Windows.Forms;

namespace UpdaterManagerLibrary
{
    internal partial class UpdateForm : Form
    {
        #region GLOBAL_VARIABLE
        private Versioning versioning;
        #endregion

        #region FORM_EVENTS
        public UpdateForm(Versioning versioning)
        {
            InitializeComponent();

            this.versioning = versioning;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            labelCurrentVersion.Text += versioning.CurrentVersion;
            labelLastVersion.Text += versioning.LatestVersion;

            richTextBoxChangelog.Text = versioning.VersionHistory;
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
