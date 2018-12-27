using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace UpdaterManager
{
    public static class MainProgram
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex mutex = new Mutex(false, (Application.ProductName + "_" + Assembly.GetExecutingAssembly().GetType().GUID.ToString())))
            {
                if ((mutex.WaitOne(0, false)) && (ValidateArguments(args)))
                {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(Utilities.FinalizerName);

                    try
                    {
                        ClosePendingProcesses(args[1]);

                        using (ZipArchive zipArchive = ZipFile.OpenRead(args[2]))
                        {
                            foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                            {
                                string completeFileName = Path.Combine(Environment.CurrentDirectory, zipArchiveEntry.FullName);
                                string directoryName = Path.GetDirectoryName(completeFileName);

                                if ((directoryName != Environment.CurrentDirectory) && (!Directory.Exists(directoryName)))
                                {
                                    Directory.CreateDirectory(directoryName);
                                }

                                zipArchiveEntry.ExtractToFile(completeFileName, true);
                            }
                        }

                        File.WriteAllText(Utilities.FinalizerName, string.Format(Utilities.FinalizerContent, args[1]));
                        File.SetAttributes(Utilities.FinalizerName, FileAttributes.Hidden);

                        processStartInfo.CreateNoWindow = true;
                        processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        processStartInfo.FileName = args[1];
                    }
                    finally
                    {
                        File.Delete(args[2]);

                        Process.Start(processStartInfo).Dispose();
                    }
                }
            }
        }

        #region ARGUMENTS_VALIDATION
        private static bool ValidateArguments(string[] args)
        {
            return ((args.Length == Utilities.ParametersNumber) &&
                (args[0] == Utilities.UpdateAction) &&
                (File.Exists(args[1])) &&
                (File.Exists(args[2])));
        }
        #endregion

        #region PROCESSES_MANAGER
        private static void ClosePendingProcesses(string processFilePath)
        {
            string mainFileVersionInfo = RemoveFirstRowValue(FileVersionInfo.GetVersionInfo(processFilePath).ToString());

            foreach (Process process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processFilePath)))
            {
                using (process)
                {
                    string fileVersionInfo = RemoveFirstRowValue(process.MainModule.FileVersionInfo.ToString());

                    if (mainFileVersionInfo == fileVersionInfo)
                    {
                        if (!process.WaitForExit(Utilities.MaxWaitTime))
                        {
                            if (!process.CloseMainWindow())
                            {
                                process.Kill();
                            }
                            else if (!process.WaitForExit(Utilities.MaxWaitTime))
                            {
                                process.Kill();
                            }
                        }
                    }
                }
            }
        }

        private static string RemoveFirstRowValue(string fullText)
        {
            return fullText.Remove(fullText.IndexOf("F"), fullText.IndexOf(Environment.NewLine)).Trim();
        }
        #endregion
    }
}
