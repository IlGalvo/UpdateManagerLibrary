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
        public static bool CheckForUpdates(string updateInformationUrl, Assembly executingAssembly = null, bool verboseNotifier = false)
        {
            bool operationSuccess = false;

            try
            {
                int connectionTimeout = ((!verboseNotifier) ? Utilities.DefaultTimeout : Utilities.LongTimeout);

                using (WebClientTimeout webClientTimeout = new WebClientTimeout(connectionTimeout))
                using (StreamReader streamReader = new StreamReader(webClientTimeout.OpenRead(new Uri(updateInformationUrl))))
                {
                    Versioning versioning = ((Versioning)new XmlSerializer(typeof(Versioning)).Deserialize(streamReader));

                    if (executingAssembly == null)
                    {
                        executingAssembly = Assembly.GetExecutingAssembly();
                    }

                    versioning.ExecutingAssemblyName = executingAssembly.GetName();

                    if (versioning.ExecutingAssemblyName.Version < Version.Parse(versioning.LatestVersion))
                    {
                        ManageVisualStyles();

                        using (UpdateForm updateForm = new UpdateForm(versioning))
                        {
                            if (updateForm.ShowDialog() == DialogResult.OK)
                            {
                                using (DownloadForm downloadForm = new DownloadForm(versioning, executingAssembly.Location))
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
