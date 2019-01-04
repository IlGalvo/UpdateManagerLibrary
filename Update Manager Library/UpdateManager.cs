using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace UpdateManagerLibrary
{
    public static class UpdateManager
    {
        #region CHECK_UPDATES
        public static bool CheckForUpdates(string updateCheckUrl, Assembly applicationAssembly = null, bool verboseNotifier = false)
        {
            bool operationSuccess = false;

            try
            {
                int connectionTimeout = ((!verboseNotifier) ? Utilities.DefaultTimeout : Utilities.LongTimeout);

                using (WebClientTimeout webClientTimeout = new WebClientTimeout(connectionTimeout))
                {
                    Versioning versioning = Versioning.CreateOrLoad(webClientTimeout.OpenRead(new Uri(updateCheckUrl)));

                    if (applicationAssembly == null)
                    {
                        applicationAssembly = Assembly.GetEntryAssembly();
                    }

                    versioning.ApplicationAssemblyName = applicationAssembly.GetName();

                    if (versioning.ApplicationAssemblyName.Version < Version.Parse(versioning.LatestVersion))
                    {
                        ManageVisualStyles();

                        using (UpdateForm updateForm = new UpdateForm(versioning))
                        {
                            if (updateForm.ShowDialog() == DialogResult.OK)
                            {
                                using (DownloadForm downloadForm = new DownloadForm(versioning, applicationAssembly.Location))
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
