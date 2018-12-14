using System;
using System.Windows.Forms;
using UpdaterManagerLibrary;

namespace Sample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //UpdaterManager updaterManager = new UpdaterManager();

            string url = "https://onedrive.live.com/download?resid=7D7FF9DFDA23C644!1195&authkey=!AKayxLNoGtz8Pjw";
            UpdaterManager.CheckForUpdates(new Version(Application.ProductVersion), new Uri(url), false);
        }
    }
}
