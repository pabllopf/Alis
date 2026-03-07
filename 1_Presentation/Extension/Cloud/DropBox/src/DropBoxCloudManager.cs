// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DropBoxCloudManager.cs
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Stone;
using Dropbox.Api.Users;

namespace Alis.Extension.Cloud.DropBox
{
    /// <summary>
    ///     The cloud manager class
    /// </summary>
    /// <seealso cref="AManager" />
    /// <seealso cref="ICloudManager" />
    public class DropBoxCloudManager : AManager, ICloudManager, IDisposable
    {
        /// <summary>
        ///     The access token
        /// </summary>
        private string _accessToken;

        /// <summary>
        ///     The Dropbox client
        /// </summary>
        private DropboxClient _dropboxClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DropBoxCloudManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public DropBoxCloudManager(Context context) : base(context)
        {
            Name = "DropBoxManager";
            Tag = "Cloud";
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DropBoxCloudManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context">The context</param>
        public DropBoxCloudManager(string id, string name, string tag, bool isEnable, Context context) : base(id, name, tag, isEnable, context)
        {
        }

        /// <summary>
        ///     Gets a value indicating whether the manager is initialized with a valid access token
        /// </summary>
        public bool IsInitialized => (_dropboxClient != null) && !string.IsNullOrEmpty(_accessToken);

        /// <summary>
        ///     Initializes the Dropbox client with the given access token
        /// </summary>
        /// <param name="accessToken">The Dropbox access token</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public async Task InitializeAsync(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentException("Access token cannot be null or empty", nameof(accessToken));
            }

            try
            {
                _accessToken = accessToken;
                _dropboxClient = new DropboxClient(_accessToken);

                // Verify the token is valid by getting account info
                FullAccount account = await _dropboxClient.Users.GetCurrentAccountAsync();
                Logger.Info($"DropBox initialized successfully for user: {account.Name.DisplayName}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to initialize DropBox: {ex.Message}");
                _dropboxClient = null;
                _accessToken = null;
                throw;
            }
        }

        /// <summary>
        ///     Uploads a file to Dropbox
        /// </summary>
        /// <param name="localFilePath">The local file path to upload</param>
        /// <param name="dropboxPath">The destination path in Dropbox (must start with /)</param>
        /// <returns>A task representing the asynchronous operation with file metadata</returns>
        public async Task<FileMetadata> UploadFileAsync(string localFilePath, string dropboxPath)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("DropBox manager is not initialized. Call InitializeAsync first.");
            }

            if (!File.Exists(localFilePath))
            {
                throw new FileNotFoundException($"Local file not found: {localFilePath}");
            }

            if (!dropboxPath.StartsWith("/"))
            {
                dropboxPath = "/" + dropboxPath;
            }

            try
            {
                using (FileStream stream = File.OpenRead(localFilePath))
                {
                    FileMetadata response = await _dropboxClient.Files.UploadAsync(
                        dropboxPath,
                        WriteMode.Add.Instance,
                        body: stream);

                    Logger.Info($"File uploaded successfully to DropBox: {dropboxPath}");
                    return response;
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to upload file to DropBox: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Downloads a file from Dropbox
        /// </summary>
        /// <param name="dropboxPath">The Dropbox path of the file to download</param>
        /// <param name="localFilePath">The local destination path</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public async Task DownloadFileAsync(string dropboxPath, string localFilePath)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("DropBox manager is not initialized. Call InitializeAsync first.");
            }

            if (!dropboxPath.StartsWith("/"))
            {
                dropboxPath = "/" + dropboxPath;
            }

            try
            {
                // Ensure the destination directory exists
                string directory = Path.GetDirectoryName(localFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (IDownloadResponse<FileMetadata> response = await _dropboxClient.Files.DownloadAsync(dropboxPath))
                {
                    using (FileStream fileStream = File.Create(localFilePath))
                    {
                        Stream stream = await response.GetContentAsStreamAsync();
                        await stream.CopyToAsync(fileStream);
                    }
                }

                Logger.Info($"File downloaded successfully from DropBox: {dropboxPath} to {localFilePath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to download file from DropBox: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Lists files in a Dropbox folder
        /// </summary>
        /// <param name="folderPath">The Dropbox folder path (use "/" for root)</param>
        /// <param name="recursive">Whether to list recursively</param>
        /// <returns>A task representing the asynchronous operation with list of file metadata</returns>
        public async Task<IList<Metadata>> ListFilesAsync(string folderPath, bool recursive = false)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("DropBox manager is not initialized. Call InitializeAsync first.");
            }

            if (string.IsNullOrEmpty(folderPath))
            {
                folderPath = "/";
            }

            if (!folderPath.StartsWith("/"))
            {
                folderPath = "/" + folderPath;
            }

            try
            {
                ListFolderResult result = await _dropboxClient.Files.ListFolderAsync(folderPath, recursive);
                Logger.Info($"Listed {result.Entries.Count} items from DropBox path: {folderPath}");
                return result.Entries;
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to list files from DropBox: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Deletes a file or folder from Dropbox
        /// </summary>
        /// <param name="dropboxPath">The path to delete</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public async Task DeleteAsync(string dropboxPath)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("DropBox manager is not initialized. Call InitializeAsync first.");
            }

            if (!dropboxPath.StartsWith("/"))
            {
                dropboxPath = "/" + dropboxPath;
            }

            try
            {
                await _dropboxClient.Files.DeleteV2Async(dropboxPath);
                Logger.Info($"Item deleted successfully from DropBox: {dropboxPath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to delete item from DropBox: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Gets file metadata from Dropbox
        /// </summary>
        /// <param name="dropboxPath">The Dropbox path</param>
        /// <returns>A task representing the asynchronous operation with file metadata</returns>
        public async Task<Metadata> GetMetadataAsync(string dropboxPath)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("DropBox manager is not initialized. Call InitializeAsync first.");
            }

            if (!dropboxPath.StartsWith("/"))
            {
                dropboxPath = "/" + dropboxPath;
            }

            try
            {
                Metadata metadata = await _dropboxClient.Files.GetMetadataAsync(dropboxPath);
                Logger.Info($"Retrieved metadata from DropBox: {dropboxPath}");
                return metadata;
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to get metadata from DropBox: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            OnDestroy();
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
            if (_dropboxClient != null)
            {
                _dropboxClient.Dispose();
                _dropboxClient = null;
                Logger.Info("DropBox client disposed");
            }

            base.OnDestroy();
        }
    }
}