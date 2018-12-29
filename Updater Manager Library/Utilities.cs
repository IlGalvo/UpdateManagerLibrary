namespace UpdaterManagerLibrary
{
    internal static class Utilities
    {
        #region GENERAL
        public static string ZipExtension { get { return (".zip"); } }
        #endregion

        #region TIMEOUT
        public static int DefaultTimeout { get { return 2000; } }

        public static int LongTimeout { get { return 3500; } }
        #endregion

        #region SLEEP
        public static int DefaultSleepTime { get { return 1500; } }

        public static int ShortSleepTime { get { return 500; } }
        #endregion

        #region UPDATER
        public static string UpdaterName { get { return ("Updater Manager.exe"); } }

        public static string UpdaterArguments { get { return ("/update \"{0}\" \"{1}\""); } }
        #endregion
    }
}
