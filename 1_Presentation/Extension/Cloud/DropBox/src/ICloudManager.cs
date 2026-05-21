

using System.Collections.Generic;
using System.Threading.Tasks;
using Dropbox.Api.Files;

namespace Alis.Extension.Cloud.DropBox
{
    /// <summary>
    ///     The cloud manager interface
    /// </summary>
    public interface ICloudManager
    {
        /// <summary>
        ///     Gets a value indicating whether the manager is initialized with a valid access token
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        ///     Initializes the Dropbox client with the given access token
        /// </summary>
        /// <param name="accessToken">The Dropbox access token</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task InitializeAsync(string accessToken);

        /// <summary>
        ///     Uploads a file to Dropbox
        /// </summary>
        /// <param name="localFilePath">The local file path to upload</param>
        /// <param name="dropboxPath">The destination path in Dropbox (must start with /)</param>
        /// <returns>A task representing the asynchronous operation with file metadata</returns>
        Task<FileMetadata> UploadFileAsync(string localFilePath, string dropboxPath);

        /// <summary>
        ///     Downloads a file from Dropbox
        /// </summary>
        /// <param name="dropboxPath">The Dropbox path of the file to download</param>
        /// <param name="localFilePath">The local destination path</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task DownloadFileAsync(string dropboxPath, string localFilePath);

        /// <summary>
        ///     Lists files in a Dropbox folder
        /// </summary>
        /// <param name="folderPath">The Dropbox folder path (use "/" for root)</param>
        /// <param name="recursive">Whether to list recursively</param>
        /// <returns>A task representing the asynchronous operation with list of file metadata</returns>
        Task<IList<Metadata>> ListFilesAsync(string folderPath, bool recursive = false);

        /// <summary>
        ///     Deletes a file or folder from Dropbox
        /// </summary>
        /// <param name="dropboxPath">The path to delete</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task DeleteAsync(string dropboxPath);

        /// <summary>
        ///     Gets file metadata from Dropbox
        /// </summary>
        /// <param name="dropboxPath">The Dropbox path</param>
        /// <returns>A task representing the asynchronous operation with file metadata</returns>
        Task<Metadata> GetMetadataAsync(string dropboxPath);
    }
}