using System;

namespace UpdaterManager
{
    internal static class Utilities
    {
        #region GENERAL
        public static int ParametersNumber { get { return 3; } }

        public static int MaxWaitTime { get { return 5000; } }

        public static string MainProgramName { get { return ("Database Password Manager.exe"); } }
        #endregion

        #region UPDATE
        public static string UpdateAction { get { return ("/update"); } }

        public static string UpdaterTemporaryName { get { return (AppDomain.CurrentDomain.FriendlyName.Replace(".exe", ".tmp")); } }
        #endregion

        #region FINALIZER
        public static string FinalizerName { get { return ("Finalizer.bat"); } }

        public static string FinalizerContent
        {
            get
            {
                return ("@echo off\n" +
                        "timeout /t 1 /nobreak > nul\n" +
                        "del \"" + AppDomain.CurrentDomain.FriendlyName + "\"\n" +
                        "ren \"" + UpdaterTemporaryName + "\" \"" + AppDomain.CurrentDomain.FriendlyName + "\"\n" +
                        @"start """" ""{0}""" + "\n" +
                        "del /a:h \"" + FinalizerName + "\"");
            }
        }
        #endregion
    }
}
