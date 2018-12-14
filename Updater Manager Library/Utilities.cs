using System;

namespace UpdaterManagerLibrary
{
    internal static class UpdateUtilities
    {
        #region GENERAL
        public static string ProcessArguments { get { return ("/passive"); } }

        public static string CurrentFileNameTemp { get { return AppDomain.CurrentDomain.FriendlyName.Replace(".exe", ".tmp"); } }
        #endregion

        #region TIMEOUT
        public static int DefaultTimeout { get { return 2000; } }

        public static int LongTimeout { get { return 3500; } }
        #endregion

        #region LINK
        public static string DriveDownloadLink { get { return ("https://onedrive.live.com/download?resid="); } }

        public static string FileCheckLink { get { return (DriveDownloadLink + "7D7FF9DFDA23C644%211118&authkey=!ADVvTeXLRDF8ktE"); } }

        public static string FileCheckLink2 { get { return (DriveDownloadLink + "7D7FF9DFDA23C644!1195&authkey=!AKayxLNoGtz8Pjw"); } }
        #endregion

        #region LABELINFO
        public static string UpdateInformation { get { return ("Sto scaricando l'aggiornamento..."); } }

        public static string DownloadCompletedInformation { get { return ("Scaricamento completato. Avvio installazione."); } }
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
                    "ren \"" + CurrentFileNameTemp + "\" \"" + AppDomain.CurrentDomain.FriendlyName + "\"\n" +
                    "start \"\" \"" + AppDomain.CurrentDomain.FriendlyName + "\"\n" +
                    "del /a:h \"" + FinalizerName + "\"");
            }
        }
        #endregion
    }
}
