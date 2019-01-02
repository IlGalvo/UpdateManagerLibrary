using System;
using System.Reflection;
using System.Windows.Forms;
using UpdateManagerLibrary;

namespace Sample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonCheckUpdates_Click(object sender, EventArgs e)
        {
            string downloadUrl = "https://onedrive.live.com/download?resid=7D7FF9DFDA23C644!1341&authkey=!AAPfdJrVo5UeVkE";

            if (UpdateManager.CheckForUpdates(downloadUrl, Assembly.GetExecutingAssembly(), true))
            {
                Close();
            }
        }
    }
}
