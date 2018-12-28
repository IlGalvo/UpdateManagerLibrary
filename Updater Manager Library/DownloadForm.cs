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
        private string downloadFilePath;

        private string downloadUrl;
        private string remoteSha256;
        #endregion

        #region FORM_EVENTS
        public DownloadForm(string downloadUrl, string remoteSha256)
        {
            InitializeComponent();

            webClientTimeout = new WebClientTimeout();
            downloadFilePath = string.Empty;

            this.downloadUrl = downloadUrl;
            this.remoteSha256 = remoteSha256;

            Thread.Sleep(Utilities.ShortSleepTime);
        }

        private void DownloadForm_Shown(object sender, EventArgs e)
        {
            SetLabelText("Preparazione al download dell'aggiornamento.");

            try
            {
                downloadFilePath = Path.GetTempFileName();

                string tmpDownloadFilePath = downloadFilePath;
                downloadFilePath = Path.ChangeExtension(tmpDownloadFilePath, Utilities.ZipExtension);

                File.Move(tmpDownloadFilePath, downloadFilePath);

                webClientTimeout.DownloadProgressChanged += WebClientTimeout_DownloadProgressChanged;
                webClientTimeout.DownloadFileCompleted += WebClientTimeout_DownloadFileCompleted;

                webClientTimeout.DownloadFileAsync(new Uri(downloadUrl), downloadFilePath);

                SetLabelText("Download dell'aggiornamento in corso...");
            }
            catch (Exception exception)
            {
                ManageResultOperations("Errore durante la preparazione del download.", exception.Message);
            }
        }

        private void DownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webClientTimeout.IsBusy)
            {
                webClientTimeout.CancelAsync();

                ManageResultOperations("Download interrotto.");
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
            if (e.Error != null)
            {
                if (!e.Cancelled)
                {
                    ManageResultOperations("Errore durante il download.", e.Error.Message);
                }
            }
            else
            {
                string updaterFilePath = string.Empty;

                try
                {
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] downloadedFile = File.ReadAllBytes(downloadFilePath);
                        string localSha256 = BitConverter.ToString(sha256.ComputeHash(downloadedFile)).Replace("-", string.Empty);

                        if (localSha256 == remoteSha256)
                        {
                            SetLabelText("Download completato e verificato con successo.");

                            updaterFilePath = Path.Combine(Path.GetTempPath(), Utilities.UpdaterName);
                            File.WriteAllBytes(updaterFilePath, Resources.Updater_Manager);

                            ProcessStartInfo processStartInfo = new ProcessStartInfo
                            {
                                FileName = updaterFilePath,
                                Arguments = string.Format(Utilities.UpdaterArguments, downloadFilePath),
                                CreateNoWindow = true,
                                WindowStyle = ProcessWindowStyle.Hidden
                            };

                            SetLabelText("Avvio dell'installazione in corso...");

                            Process.Start(processStartInfo).Dispose();

                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            throw (new Exception("Il file scaricato è danneggiato."));
                        }
                    }
                }
                catch (Exception exception)
                {
                    ManageResultOperations("Errore durante l'avvio dell'installazione.", exception.Message);

                    DeleteFile(updaterFilePath);
                }
            }
        }
        #endregion

        #region LABEL_STATUS
        private void SetLabelText(string informationText)
        {
            labelInformation.Text = informationText;

            Application.DoEvents();

            Thread.Sleep(Utilities.DefaultSleepTime);
        }
        #endregion

        #region RESULT_MANAGER
        private void ManageResultOperations(string informationText, string exceptionMessage = null)
        {
            DeleteFile(downloadFilePath);

            SetLabelText(informationText);

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                MessageBox.Show(this, exceptionMessage, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }

            SetLabelText("Chiusura in corso...");
        }
        #endregion

        #region DELETE_FILE
        private void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        #endregion
    }
}
