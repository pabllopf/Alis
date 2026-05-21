

namespace Alis.App.Hub.Entity
{
    /// <summary>
    ///     The installed version class
    /// </summary>
    public class InstalledVersion
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InstalledVersion" /> class
        /// </summary>
        /// <param name="version">The version</param>
        /// <param name="releaseDate">The release date</param>
        /// <param name="installPath">The install path</param>
        public InstalledVersion(string version, string releaseDate, string installPath)
        {
            Version = version;
            ReleaseDate = releaseDate;
            InstallPath = installPath;
        }

        /// <summary>
        ///     Gets the value of the version
        /// </summary>
        public string Version { get; }

        /// <summary>
        ///     Gets the value of the release date
        /// </summary>
        public string ReleaseDate { get; }

        /// <summary>
        ///     Gets the value of the install path
        /// </summary>
        public string InstallPath { get; }
    }
}