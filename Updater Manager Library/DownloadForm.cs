using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using UpdaterManagerLibrary.Properties;

namespace UpdaterManagerLibrary
{
    internal partial class DownloadForm : Form
    {
        #region GLOBAL_VARIABLE
        private string downloadUrl;
        #endregion

        #region FORM_EVENTS
        public DownloadForm(string downloadUrl)
        {
            InitializeComponent();

            this.downloadUrl = downloadUrl;
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

                using (WebClientTimeout webClientTimeout = new WebClientTimeout())
                {
                    webClientTimeout.DownloadProgressChanged += WebClientTimeout_DownloadProgressChanged;
                    webClientTimeout.DownloadFileCompleted += WebClientTimeout_DownloadFileCompleted;

                    webClientTimeout.DownloadFileAsync(new Uri(downloadUrl), fileNamePath, fileNamePath);
                }
            }
            catch (Exception exception)
            {
                File.Delete(fileNamePath);

                MessageBox.Show(exception.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }
        }
        #endregion

        #region WEBCLIENTTIMEOUT_EVENTS
        private void WebClientTimeout_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            labelCurrentByte.Text = (((e.BytesReceived / 1024f) / 1024f).ToString("00. 00") + " MB");

            coloredProgressBarDownload.Value = e.ProgressPercentage;

            labelTotalByte.Text = (((e.TotalBytesToReceive / 1024f) / 1024f).ToString("00. 00") + " MB");
        }

        private void WebClientTimeout_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            labelInformation.Text = UpdateUtilities.DownloadCompletedInformation;

            string fileName = (nameof(Resources.Updater_Manager).Replace("_", " ") + ".exe");
            File.WriteAllBytes(fileName, Resources.Updater_Manager);

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = fileName;

            using (SHA512 sha512 = SHA512.Create())
            {
                string hashCode = BitConverter.ToString(sha512.ComputeHash(File.ReadAllBytes(e.UserState.ToString())));
                string processname = Process.GetCurrentProcess().ProcessName;

                processStartInfo.Arguments = string.Format(UpdateUtilities.UpdaterArguments, processname, e.UserState, hashCode);
            }

            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process.Start(processStartInfo).Dispose();

            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion
    }
}
