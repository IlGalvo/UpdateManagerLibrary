using System.Diagnostics;
using System.IO;
using UpdaterManagerLibrary.Properties;

namespace UpdaterManagerLibrary
{
    public class UpdaterManager
    {
        public UpdaterManager()
        {
            string fileName = (nameof(Resources.Updater_Manager).Replace("_", " ") + ".exe");

            File.WriteAllBytes(fileName, Resources.Updater_Manager);
            Process.Start(fileName).WaitForExit();
            File.Delete(fileName);
        }
    }
}
