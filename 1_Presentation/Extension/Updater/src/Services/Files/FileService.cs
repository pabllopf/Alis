

using System;
using System.Threading.Tasks;

namespace Alis.Extension.Updater.Services.Files
{
    /// <summary>
    ///     The file service class
    /// </summary>
    /// <seealso cref="IFileService" />
    public class FileService : IFileService
    {
        /// <summary>
        ///     Downloads the file using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <param name="directory">The directory</param>
        /// <returns>A task containing the string</returns>
        public Task<string> DownloadFileAsync(Uri url, string directory) => throw new NotImplementedException();

        /// <summary>
        ///     Extracts the and replace using the specified zip path
        /// </summary>
        /// <param name="zipPath">The zip path</param>
        /// <param name="directory">The directory</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void ExtractAndReplace(string zipPath, string directory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Cleans the temp files using the specified directory
        /// </summary>
        /// <param name="directory">The directory</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void CleanTempFiles(string directory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Backups the directory
        /// </summary>
        /// <param name="directory">The directory</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Backup(string directory)
        {
            throw new NotImplementedException();
        }
    }
}