using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UpdaterManagerLibrary
{
    public static class UpdaterManager
    {
        public static bool CheckForUpdates(Version currentVersion, Uri url, bool notify)
        {
            bool procedureSuccess = false;

            try
            {
                int timeout = ((!notify) ? UpdateUtilities.DefaultTimeout : UpdateUtilities.LongTimeout);

                using (WebClientTimeout webClientTimeout = new WebClientTimeout(timeout))
                using (StreamReader streamReader = new StreamReader(webClientTimeout.OpenRead(url)))
                {
                    Versioning versioning = ((Versioning)new XmlSerializer(typeof(Versioning)).Deserialize(streamReader));

                    if (Version.TryParse(versioning.LatestVersion, out Version latestVersion))
                    {
                        if (currentVersion < latestVersion)
                        {
                            using (UpdateForm updateForm = new UpdateForm(versioning.VersionHistory))
                            {
                                if (updateForm.ShowDialog() == DialogResult.OK)
                                {
                                    using (DownloadForm downloadForm = new DownloadForm(versioning.DownloadUrl, versioning.Sha256))
                                    {
                                        if (downloadForm.ShowDialog() == DialogResult.OK)
                                        {
                                            procedureSuccess = true;
                                        }
                                    }
                                }
                            }
                        }
                        else if (notify)
                        {
                            string text = "Nessun aggiornamento trovato.";

                            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                if ((notify) || (!(exception is WebException)))
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return procedureSuccess;
        }
    }
}
