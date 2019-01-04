using CustomControlCollection.Settings;
using System;
using System.Reflection;
using System.Security.Cryptography;

namespace UpdateManagerLibrary
{
    public sealed class Versioning : SettingsManager<Versioning>
    {
        #region GLOBAL_VARIABLES
        internal AssemblyName ApplicationAssemblyName { get; set; }

        public string LatestVersion { get; set; }
        public string DownloadUrl { get; set; }
        public string Sha256 { get; set; }
        public string VersionHistory { get; set; }
        #endregion

        #region CONSTRUCTOR
        public Versioning()
        {
            ApplicationAssemblyName = new AssemblyName();

            LatestVersion = string.Empty;
            DownloadUrl = string.Empty;
            Sha256 = string.Empty;
            VersionHistory = string.Empty;
        }
        #endregion

        #region SHA256_GENERATOR
        public static string ComputeSha256(byte[] dataBuffer)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return BitConverter.ToString(sha256.ComputeHash(dataBuffer)).Replace("-", string.Empty);
            }
        }
        #endregion
    }
}
