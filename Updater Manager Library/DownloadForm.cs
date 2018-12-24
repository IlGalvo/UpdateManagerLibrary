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
                labelInformation.Text = "Sto scaricando l'aggiornamento...";

                string tmpFileNamePath = Path.GetTempFileName();
                fileNamePath = Path.ChangeExtension(tmpFileNamePath, ".zip");

                File.Move(tmpFileNamePath, fileNamePath);

                webClientTimeout.DownloadProgressChanged += WebClientTimeout_DownloadProgressChanged;
                webClientTimeout.DownloadFileCompleted += WebClientTimeout_DownloadFileCompleted;

                webClientTimeout.DownloadFileAsync(new Uri(downloadUrl), fileNamePath, fileNamePath);
            }
            catch (Exception exception)
            {
                ManageResultOperations(fileNamePath, "Errore generico.", exception.Message);
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
                ManageResultOperations(e.UserState.ToString(), "Download interrotto.", string.Empty);
            }
            else if (e.Error != null)
            {
                ManageResultOperations(e.UserState.ToString(), "Errore durante il download.", e.Error.Message);
            }
            else
            {
                try
                {
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] downloadedFile = File.ReadAllBytes(e.UserState.ToString());
                        string localSha256 = BitConverter.ToString(sha256.ComputeHash(downloadedFile)).Replace("-", string.Empty);

                        if (localSha256 == remoteSha256)
                        {
                            ManageResultOperations(string.Empty, "Scaricamento completato. Avvio installazione.", string.Empty);

                            string fileName = Path.Combine(Path.GetTempPath(), (nameof(Resources.Updater_Manager).Replace("_", " ") + ".exe"));
                            File.WriteAllBytes(fileName, Resources.Updater_Manager);

                            string processFileName = Process.GetCurrentProcess().MainModule.FileName;

                            ProcessStartInfo processStartInfo = new ProcessStartInfo
                            {
                                FileName = fileName,
                                Arguments = string.Format(UpdateUtilities.UpdaterArguments, processFileName, e.UserState),
                                CreateNoWindow = true,
                                WindowStyle = ProcessWindowStyle.Hidden
                            };

                            Process.Start(processStartInfo).Dispose();

                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            ManageResultOperations(e.UserState.ToString(), "File danneggiato.", "File danneggiato.");
                        }
                    }
                }
                catch (Exception exception)
                {
                    ManageResultOperations(e.UserState.ToString(), "Errore generico.", exception.Message);
                }
            }
        }

        private void ManageResultOperations(string fileToDelete, string informationText, string exceptionMessage)
        {
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }

            labelInformation.Text = informationText;

            Application.DoEvents();
            Thread.Sleep(1000);

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                MessageBox.Show(exceptionMessage, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }
            /*else
            {
                Thread.Sleep(1000);
            }*/
        }
        #endregion
    }
}
