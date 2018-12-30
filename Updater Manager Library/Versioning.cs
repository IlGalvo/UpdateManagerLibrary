using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace UpdaterManagerLibrary
{
    public sealed class Versioning
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

        #region XML_SERIALIZER
        public void SerializeToXml(string filePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                new XmlSerializer(typeof(Versioning)).Serialize(streamWriter, this);
            }
        }
        #endregion

        #region XML_DESERIALIZER
        public static Versioning DeserializeFromStream(Stream stream)
        {
            using (StreamReader streamReader = new StreamReader(stream))
            {
                return ((Versioning)new XmlSerializer(typeof(Versioning)).Deserialize(streamReader));
            }
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
