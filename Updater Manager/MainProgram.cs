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
                if ((mutex.WaitOne(0, false)) &&
                    (args.Length == Utilities.ParametersNumber) &&
                    (args[0] == Utilities.UpdateAction) &&
                    (!string.IsNullOrEmpty(args[1])) &&
                    (File.Exists(args[2])))
                {
                    try
                    {
                        foreach (Process process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(args[1])))
                        {
                            using (process)
                            {
                                if ((!process.WaitForExit(Utilities.MaxWaitTime)))
                                {
                                    if (!process.CloseMainWindow())
                                    {
                                        process.Kill();
                                    }
                                }
                            }
                        }

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

                        // Forse meglio nel finally
                        File.WriteAllText(Utilities.FinalizerName, string.Format(Utilities.FinalizerContent, args[1]));
                        File.SetAttributes(Utilities.FinalizerName, FileAttributes.Hidden);

                        ProcessStartInfo processStartInfo = new ProcessStartInfo();
                        processStartInfo.FileName = Utilities.FinalizerName;
                        processStartInfo.CreateNoWindow = true;
                        processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                        Process.Start(processStartInfo).Dispose();
                        // Forse meglio nel finally
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        File.Delete(args[2]);
                    }
                }
            }
        }
    }
}
