using System;
using System.IO;

namespace UpdaterManager
{
    internal static class Utilities
    {
        #region GENERAL
        public static int ParametersNumber { get { return 3; } }

        public static int MaxWaitTime { get { return 5000; } }
        #endregion

        #region UPDATE
        public static string UpdateAction { get { return ("/update"); } }
        #endregion

        #region FINALIZER
        public static string FinalizerName { get { return ("Finalizer.bat"); } }

        // Environment.GetCommandLineArgs()[0]
        public static string FinalizerContent
        {
            get
            {
                return ("@echo off\n" +
                        "timeout /t 1 /nobreak > nul\n" +
                        "del \"" + Path.Combine(Path.GetTempPath(), AppDomain.CurrentDomain.FriendlyName) + "\"\n" +
                        "start \"\" \"{0}\"" + "\n" +
                        "del /a:h \"" + FinalizerName + "\"");
            }
        }
        #endregion
    }
}
