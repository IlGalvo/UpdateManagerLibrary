using System.IO;
using System.Reflection;

namespace UpdateManagerWorker
{
    internal static class Utilities
    {
        #region GENERAL
        public static string ApplicationGUID { get { return Assembly.GetExecutingAssembly().GetType().GUID.ToString(); } }

        public static int MaxWaitTime { get { return 2500; } }
        #endregion

        #region UPDATE
        public static int UpdateParametersNumber { get { return 3; } }

        public static string UpdateParameterAction { get { return ("/update"); } }
        #endregion

        #region FINALIZER
        public static string FinalizerPath { get { return Path.Combine(Path.GetTempPath(), "Finalizer.bat"); } }

        public static string FinalizerContent
        {
            get
            {
                return ("@echo off\n" +
                        "timeout /t 1 /nobreak > nul\n" +
                        "del \"" + Assembly.GetExecutingAssembly().Location + "\"\n" +
                        "start \"\" \"{0}\"" + "\n" +
                        "del /a:h \"" + FinalizerPath + "\"");
            }
        }
        #endregion
    }
}
