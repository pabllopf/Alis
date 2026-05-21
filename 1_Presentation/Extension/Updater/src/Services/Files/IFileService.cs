

using System;
using System.Threading.Tasks;

namespace Alis.Extension.Updater.Services.Files
{
    /// <summary>
    ///     The file service interface
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        ///     Downloads the file using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <param name="directory">The directory</param>
        /// <returns>A task containing the string</returns>
        Task<string> DownloadFileAsync(Uri url, string directory);

        /// <summary>
        ///     Extracts the and replace using the specified zip path
        /// </summary>
        /// <param name="zipPath">The zip path</param>
        /// <param name="directory">The directory</param>
        void ExtractAndReplace(string zipPath, string directory);

        /// <summary>
        ///     Cleans the temp files using the specified directory
        /// </summary>
        /// <param name="directory">The directory</param>
        void CleanTempFiles(string directory);

        /// <summary>
        ///     Backups the directory
        /// </summary>
        /// <param name="directory">The directory</param>
        void Backup(string directory);
    }
}