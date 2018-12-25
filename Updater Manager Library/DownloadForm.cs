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

            Thread.Sleep(((int)(Utilities.DefaultSleepTime / 2.8)));
        }

        private void DownloadForm_Shown(object sender, EventArgs e)
        {
            string fileNamePath = string.Empty;

            try
            {
                SetLabelText("Preparazione al download dell'aggiornamento.");

                fileNamePath = Path.GetTempFileName();
                string tmpFileNamePath = fileNamePath;
                fileNamePath = Path.ChangeExtension(tmpFileNamePath, ".zip");

                File.Move(tmpFileNamePath, fileNamePath);

                webClientTimeout.DownloadProgressChanged += WebClientTimeout_DownloadProgressChanged;
                webClientTimeout.DownloadFileCompleted += WebClientTimeout_DownloadFileCompleted;

                webClientTimeout.DownloadFileAsync(new Uri(downloadUrl), fileNamePath, fileNamePath);

                SetLabelText("Download dell'aggiornamento in corso...");
            }
            catch (Exception exception)
            {
                ManageResultOperations(fileNamePath, "Errore durante la preparazione del download.", exception.Message);
            }
        }

        private void DownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webClientTimeout.IsBusy)
            {
                webClientTimeout.CancelAsync();

                SetLabelText("Download interrotto.");
                SetLabelText("Chiusura in corso...");
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
                ManageResultOperations(e.UserState.ToString(), "Chiusura in corso...", string.Empty);
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
                            SetLabelText("Download completato e verificato con successo.");

                            string fileName = Path.Combine(Path.GetTempPath(), (nameof(Resources.Updater_Manager).Replace("_", " ") + ".exe"));
                            File.WriteAllBytes(fileName, Resources.Updater_Manager);

                            string processFileName = Process.GetCurrentProcess().MainModule.FileName;

                            ProcessStartInfo processStartInfo = new ProcessStartInfo
                            {
                                FileName = fileName,
                                Arguments = string.Format(Utilities.UpdaterArguments, processFileName, e.UserState),
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
                            ManageResultOperations(e.UserState.ToString(), "Il file scaricato è danneggiato.", string.Empty);

                            SetLabelText("Chiusura in corso...");
                        }
                    }
                }
                catch (Exception exception)
                {
                    ManageResultOperations(e.UserState.ToString(), "Errore durante l'avvio dell'installazione.", exception.Message);
                }
            }
        }

        private void ManageResultOperations(string fileToDelete, string informationText, string exceptionMessage)
        {
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }

            SetLabelText(informationText);

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                MessageBox.Show(this, exceptionMessage, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                SetLabelText("Chiusura in corso...");

                Close();
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
    }
}
