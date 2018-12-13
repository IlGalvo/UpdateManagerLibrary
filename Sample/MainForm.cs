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
            UpdaterManager updaterManager = new UpdaterManager();
        }
    }
}
