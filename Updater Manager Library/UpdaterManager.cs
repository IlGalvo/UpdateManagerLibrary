using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UpdaterManagerLibrary
{
    public static class UpdaterManager
    {
        #region CHECK_UPDATES
        public static bool CheckForUpdates(string updateCheckUrl, Assembly mainAssembly = null, bool verboseNotifier = false)
        {
            bool operationSuccess = false;

            try
            {
                int connectionTimeout = ((!verboseNotifier) ? Utilities.DefaultTimeout : Utilities.LongTimeout);

                using (WebClientTimeout webClientTimeout = new WebClientTimeout(connectionTimeout))
                using (StreamReader streamReader = new StreamReader(webClientTimeout.OpenRead(new Uri(updateCheckUrl))))
                {
                    Versioning versioning = ((Versioning)new XmlSerializer(typeof(Versioning)).Deserialize(streamReader));

                    if (mainAssembly == null)
                    {
                        mainAssembly = Assembly.GetEntryAssembly();
                    }

                    versioning.MainAssemblyName = mainAssembly.GetName();

                    if (versioning.MainAssemblyName.Version < Version.Parse(versioning.LatestVersion))
                    {
                        ManageVisualStyles();

                        using (UpdateForm updateForm = new UpdateForm(versioning))
                        {
                            if (updateForm.ShowDialog() == DialogResult.OK)
                            {
                                using (DownloadForm downloadForm = new DownloadForm(versioning, mainAssembly.Location))
                                {
                                    if (downloadForm.ShowDialog() == DialogResult.OK)
                                    {
                                        operationSuccess = true;
                                    }
                                }
                            }
                        }
                    }
                    else if (verboseNotifier)
                    {
                        MessageBox.Show("Nessun aggiornamento trovato.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exception)
            {
                if ((verboseNotifier) || (!(exception is WebException)))
                {
                    MessageBox.Show(exception.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return operationSuccess;
        }
        #endregion

        #region VISUALSTYLES_MANAGER
        private static void ManageVisualStyles()
        {
            if (!Application.MessageLoop)
            {
                Application.EnableVisualStyles();

                if (Application.OpenForms.Count == 0)
                {
                    Application.SetCompatibleTextRenderingDefault(false);
                }
            }
        }
        #endregion
    }
}
