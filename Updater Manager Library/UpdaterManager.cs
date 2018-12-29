﻿using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UpdaterManagerLibrary
{
    public static class UpdaterManager
    {
        public static bool CheckForUpdates(Version currentVersion, string updateInformationUrl, bool verboseNotifier = false)
        {
            bool operationSuccess = false;

            try
            {
                int connectionTimeout = ((!verboseNotifier) ? Utilities.DefaultTimeout : Utilities.LongTimeout);

                using (WebClientTimeout webClientTimeout = new WebClientTimeout(connectionTimeout))
                using (StreamReader streamReader = new StreamReader(webClientTimeout.OpenRead(new Uri(updateInformationUrl))))
                {
                    Versioning versioning = ((Versioning)new XmlSerializer(typeof(Versioning)).Deserialize(streamReader));

                    if (currentVersion < Version.Parse(versioning.LatestVersion))
                    {
                        if (!Application.MessageLoop)
                        {
                            Application.EnableVisualStyles();

                            if (Application.OpenForms.Count == 0)
                            {
                                Application.SetCompatibleTextRenderingDefault(false);
                            }
                        }

                        versioning.CurrentVersion = currentVersion.ToString();

                        using (UpdateForm updateForm = new UpdateForm(versioning))
                        {
                            if (updateForm.ShowDialog() == DialogResult.OK)
                            {
                                using (DownloadForm downloadForm = new DownloadForm(versioning.DownloadUrl, versioning.Sha256))
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
    }
}
