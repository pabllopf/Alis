namespace Alis.App.Engine.Hub
{
    public class InstalledVersion
    {
        public string Version { get; }
        public string ReleaseDate { get; }
        public string InstallPath { get; }

        public InstalledVersion(string version, string releaseDate, string installPath)
        {
            Version = version;
            ReleaseDate = releaseDate;
            InstallPath = installPath;
        }
    }
}