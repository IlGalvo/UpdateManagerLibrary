namespace UpdaterManagerLibrary
{
    public sealed class Versioning
    {
        public string LatestVersion { get; set; }
        public string DownloadUrl { get; set; }
        public string VersionHistory { get; set; }

        public Versioning()
        {
            LatestVersion = string.Empty;
            DownloadUrl = string.Empty;
            VersionHistory = string.Empty;
        }
    }
}
