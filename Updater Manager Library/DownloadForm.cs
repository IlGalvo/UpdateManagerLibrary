using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using UpdaterManagerLibrary.Properties;

namespace UpdaterManagerLibrary
{
    internal partial class DownloadForm : Form
    {
        #region GLOBAL_VARIABLE
        private WebClientTimeout webClientTimeout;

        private string downloadUrl;
        private string remoteSha256;
        #endregion

        #region FORM_EVENTS
        public DownloadForm(string downloadUrl, string remoteSha256)
        {
            InitializeComponent();

            webClientTimeout = new WebClientTimeout();

            this.downloadUrl = downloadUrl;
            this.remoteSha256 = remoteSha256;
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            string fileNamePath = string.Empty;

            try
            {
                string tmpFileNamePath = Path.GetTempFileName();
                string fileExtension = ".zip";

                fileNamePath = Path.ChangeExtension(tmpFileNamePath, fileExtension);
                File.Move(tmpFileNamePath, fileNamePath);

                labelInformation.Text = UpdateUtilities.UpdateInformation;

                webClientTimeout.DownloadProgressChanged += WebClientTimeout_DownloadProgressChanged;
                webClientTimeout.DownloadFileCompleted += WebClientTimeout_DownloadFileCompleted;

                webClientTimeout.DownloadFileAsync(new Uri(downloadUrl), fileNamePath, fileNamePath);
            }
            catch (Exception exception)
            {
                File.Delete(fileNamePath);

                MessageBox.Show(exception.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }
        }

        private void DownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webClientTimeout.IsBusy)
            {
                webClientTimeout.CancelAsync();
            }

            webClientTimeout.Dispose();
        }
        #endregion

        #region WEBCLIENTTIMEOUT_EVENTS
        private void WebClientTimeout_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            labelCurrentByte.Text = (((e.BytesReceived / 1024f) / 1024f).ToString("00.00") + " MB");

            coloredProgressBarDownload.Value = e.ProgressPercentage;

            labelTotalByte.Text = (((e.TotalBytesToReceive / 1024f) / 1024f).ToString("00.00") + " MB");
        }

        private void WebClientTimeout_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ManageResultOperations(e.UserState.ToString(), "Download interrotto.");
            }
            else if (e.Error != null)
            {
                ManageResultOperations(e.UserState.ToString(), "Errore durante il download.");

                MessageBox.Show(e.Error.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] downloadedFile = File.ReadAllBytes(e.UserState.ToString());
                    string localSha256 = BitConverter.ToString(sha256.ComputeHash(downloadedFile)).Replace("-", string.Empty);

                    if (localSha256 != remoteSha256)
                    {
                        ManageResultOperations(e.UserState.ToString(), "File danneggiato.");

                        MessageBox.Show("File danneggiato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }

                ManageResultOperations(string.Empty, UpdateUtilities.DownloadCompletedInformation);

                string fileName = Path.Combine(Path.GetTempPath(), (nameof(Resources.Updater_Manager).Replace("_", " ") + ".exe"));
                File.WriteAllBytes(fileName, Resources.Updater_Manager);

                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = string.Format(UpdateUtilities.UpdaterArguments, Process.GetCurrentProcess().MainModule.FileName, e.UserState),
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(processStartInfo).Dispose();

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ManageResultOperations(string fileName, string text)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            labelInformation.Text = text;

            Application.DoEvents();
            Thread.Sleep(1000);
        }
        #endregion
    }
}
