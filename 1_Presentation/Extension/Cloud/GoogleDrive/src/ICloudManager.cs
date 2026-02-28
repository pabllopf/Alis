// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ICloudManager.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alis.Extension.Cloud.GoogleDrive
{
    /// <summary>
    ///     The cloud manager interface
    /// </summary>
    public interface ICloudManager
    {
        /// <summary>
        ///     Gets a value indicating whether the manager is initialized
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        ///     Initializes the cloud manager with the given access token
        /// </summary>
        /// <param name="accessToken">The access token</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task InitializeAsync(string accessToken);

        /// <summary>
        ///     Uploads a file to the cloud
        /// </summary>
        /// <param name="localFilePath">The local file path to upload</param>
        /// <param name="cloudPath">The destination path in the cloud</param>
        /// <returns>A task representing the asynchronous operation with file id</returns>
        Task<string> UploadFileAsync(string localFilePath, string cloudPath);

        /// <summary>
        ///     Downloads a file from the cloud
        /// </summary>
        /// <param name="cloudPath">The cloud path of the file to download</param>
        /// <param name="localFilePath">The local destination path</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task DownloadFileAsync(string cloudPath, string localFilePath);

        /// <summary>
        ///     Lists files in a cloud folder
        /// </summary>
        /// <param name="folderPath">The cloud folder path</param>
        /// <returns>A task representing the asynchronous operation with list of file names</returns>
        Task<IList<string>> ListFilesAsync(string folderPath);

        /// <summary>
        ///     Deletes a file from the cloud
        /// </summary>
        /// <param name="cloudPath">The path to delete</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task DeleteAsync(string cloudPath);

        /// <summary>
        ///     Gets file metadata from the cloud
        /// </summary>
        /// <param name="cloudPath">The cloud path</param>
        /// <returns>A task representing the asynchronous operation with file metadata</returns>
        Task<CloudFileMetadata> GetMetadataAsync(string cloudPath);
    }

    /// <summary>
    ///     Cloud file metadata
    /// </summary>
    public class CloudFileMetadata
    {
        /// <summary>
        ///     Gets or sets the file id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the file name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the file size in bytes
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        ///     Gets or sets the file path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the item is a folder
        /// </summary>
        public bool IsFolder { get; set; }
    }
}