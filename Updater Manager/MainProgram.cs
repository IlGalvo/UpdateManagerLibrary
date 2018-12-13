using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;
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

            MessageBox.Show("ciao");

            using (Mutex mutex = new Mutex(false, (Application.ProductName + "_" + Assembly.GetExecutingAssembly().GetType().GUID.ToString())))
            {
                if ((mutex.WaitOne(0, false)) && (args.Length == Utilities.ParametersNumber) && (args[0] == Utilities.UpdateAction) &&
                    (File.Exists(args[1])) && (!string.IsNullOrEmpty(args[2])))
                {
                    using (SHA512 sha512 = SHA512.Create())
                    {
                        if (BitConverter.ToString(sha512.ComputeHash(File.ReadAllBytes(args[1]))) == args[2])
                        {
                            foreach (Process process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Utilities.MainProgramName)))
                            {
                                using (process)
                                {
                                    if ((!process.WaitForExit(Utilities.MaxWaitTime)))
                                    {
                                        process.CloseMainWindow();
                                    }
                                }
                            }

                            try
                            {
                                using (ZipArchive zipArchive = ZipFile.OpenRead(args[1]))
                                {
                                    foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
                                    {
                                        string completeFileName = Path.Combine(Environment.CurrentDirectory, zipArchiveEntry.FullName);
                                        string directoryName = Path.GetDirectoryName(completeFileName);

                                        if ((directoryName != Environment.CurrentDirectory) && (!Directory.Exists(directoryName)))
                                        {
                                            Directory.CreateDirectory(directoryName);
                                        }
                                        else if (zipArchiveEntry.Name == AppDomain.CurrentDomain.FriendlyName)
                                        {
                                            completeFileName = Path.Combine(Environment.CurrentDirectory, Utilities.UpdaterTemporaryName);
                                        }

                                        zipArchiveEntry.ExtractToFile(completeFileName, true);
                                    }
                                }

                                File.WriteAllText(Utilities.FinalizerName, string.Format(Utilities.FinalizerContent, Utilities.MainProgramName));
                                File.SetAttributes(Utilities.FinalizerName, FileAttributes.Hidden);

                                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                                processStartInfo.FileName = Utilities.FinalizerName;
                                processStartInfo.CreateNoWindow = true;
                                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                                Process.Start(processStartInfo).Dispose();
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                File.Delete(args[1]);
                            }
                        }
                    }
                }
            }
        }
    }
}
