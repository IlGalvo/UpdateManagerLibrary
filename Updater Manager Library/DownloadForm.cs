using System;
using System.Windows.Forms;

namespace UpdaterManagerLibrary
{
    public partial class DownloadForm : Form
    {
        private string downloadUrl;

        public DownloadForm(string downloadUrl)
        {
            InitializeComponent();

            this.downloadUrl = downloadUrl;
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {

        }
    }
}
