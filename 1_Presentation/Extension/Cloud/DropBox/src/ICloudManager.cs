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