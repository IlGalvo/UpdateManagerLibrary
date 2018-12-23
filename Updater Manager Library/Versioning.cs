namespace UpdaterManagerLibrary
{
    public sealed class Versioning
    {
        public string LatestVersion { get; set; }
        public string DownloadUrl { get; set; }
        public string Sha256 { get; set; }
        public string VersionHistory { get; set; }

        public Versioning()
        {
            LatestVersion = string.Empty;
            DownloadUrl = string.Empty;
            Sha256 = string.Empty;
            VersionHistory = string.Empty;
        }
    }
}
