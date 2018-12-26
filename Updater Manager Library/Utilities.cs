namespace UpdaterManagerLibrary
{
    internal static class Utilities
    {
        #region GENERAL
        public static int DefaultSleepTime { get { return 1500; } }

        public static string UpdaterArguments { get { return ("/update \"{0}\" \"{1}\""); } }
        #endregion

        #region TIMEOUT
        public static int DefaultTimeout { get { return 2000; } }

        public static int LongTimeout { get { return 3500; } }
        #endregion
    }
}
