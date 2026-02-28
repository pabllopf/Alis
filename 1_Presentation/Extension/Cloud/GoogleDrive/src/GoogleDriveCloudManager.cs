// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManager.cs
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
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using File = System.IO.File;

namespace Alis.Extension.Cloud.GoogleDrive
{
    /// <summary>
    ///     The cloud manager class
    /// </summary>
    /// <seealso cref="AManager" />
    /// <seealso cref="ICloudManager" />
    public class GoogleDriveCloudManager : AManager, ICloudManager, IDisposable
    {
        /// <summary>
        ///     The Google Drive service
        /// </summary>
        private DriveService _driveService;

        /// <summary>
        ///     The scopes required for Google Drive API
        /// </summary>
        private static readonly string[] Scopes = { DriveService.Scope.Drive };

        /// <summary>
        ///     Initializes a new instance of the <see cref="GoogleDriveCloudManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public GoogleDriveCloudManager(Context context) : base(context)
        {
            Name = "GoogleDriveManager";
            Tag = "Cloud";
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GoogleDriveCloudManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context">The context</param>
        public GoogleDriveCloudManager(string id, string name, string tag, bool isEnable, Context context) : base(id, name, tag, isEnable, context)
        {
        }

        /// <summary>
        ///     Gets a value indicating whether the manager is initialized
        /// </summary>
        public bool IsInitialized => _driveService != null;

        /// <summary>
        ///     Initializes the Google Drive service with the given access token
        /// </summary>
        /// <param name="accessToken">The Google Drive access token</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task InitializeAsync(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentException("Access token cannot be null or empty", nameof(accessToken));
            }

            try
            {
                GoogleCredential credential = GoogleCredential.FromAccessToken(accessToken);

                _driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Alis-GoogleDrive-Manager"
                });

                Logger.Info("Google Drive initialized successfully");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to initialize Google Drive: {ex.Message}");
                _driveService = null;
                throw;
            }
        }

        /// <summary>
        ///     Uploads a file to Google Drive
        /// </summary>
        /// <param name="localFilePath">The local file path to upload</param>
        /// <param name="cloudPath">The destination path in Google Drive</param>
        /// <returns>A task representing the asynchronous operation with file id</returns>
        public async Task<string> UploadFileAsync(string localFilePath, string cloudPath)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("Google Drive manager is not initialized. Call InitializeAsync first.");
            }

            if (!File.Exists(localFilePath))
            {
                throw new FileNotFoundException($"Local file not found: {localFilePath}");
            }

            try
            {
                Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(cloudPath),
                    Parents = new List<string> { GetOrCreateFolderId(Path.GetDirectoryName(cloudPath) ?? "root").Result }
                };

                using (FileStream stream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                {
                    FilesResource.CreateMediaUpload request = _driveService.Files.Create(fileMetadata, stream, "application/octet-stream");
                    request.Fields = "id";
                    IUploadProgress response = await request.UploadAsync();
                    if (response.Status == Google.Apis.Upload.UploadStatus.Completed)
                    {
                        Logger.Info($"File uploaded successfully to Google Drive: {cloudPath}");
                        return fileMetadata.Id ?? "unknown";
                    }
                    throw new Exception($"Upload failed with status: {response.Status}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to upload file to Google Drive: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Downloads a file from Google Drive
        /// </summary>
        /// <param name="cloudPath">The Google Drive path of the file to download</param>
        /// <param name="localFilePath">The local destination path</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public async Task DownloadFileAsync(string cloudPath, string localFilePath)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("Google Drive manager is not initialized. Call InitializeAsync first.");
            }

            try
            {
                string fileId = await GetFileIdByPathAsync(cloudPath);
                if (string.IsNullOrEmpty(fileId))
                {
                    throw new FileNotFoundException($"File not found in Google Drive: {cloudPath}");
                }

                string directory = Path.GetDirectoryName(localFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                FilesResource.GetRequest request = _driveService.Files.Get(fileId);
                using (FileStream fileStream = File.Create(localFilePath))
                {
                    await request.DownloadAsync(fileStream);
                }

                Logger.Info($"File downloaded successfully from Google Drive: {cloudPath} to {localFilePath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to download file from Google Drive: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Lists files in a Google Drive folder
        /// </summary>
        /// <param name="folderPath">The Google Drive folder path</param>
        /// <returns>A task representing the asynchronous operation with list of file names</returns>
        public async Task<IList<string>> ListFilesAsync(string folderPath)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("Google Drive manager is not initialized. Call InitializeAsync first.");
            }

            try
            {
                string folderId = await GetFolderIdByPathAsync(folderPath);
                if (string.IsNullOrEmpty(folderId))
                {
                    return new List<string>();
                }

                FilesResource.ListRequest request = _driveService.Files.List();
                request.Q = $"'{folderId}' in parents and trashed = false";
                request.Spaces = "drive";
                request.Fields = "files(id, name)";

                FileList result = await request.ExecuteAsync();
                List<string> fileNames = result.Files?.Select(f => f.Name).ToList() ?? new List<string>();
                Logger.Info($"Listed {fileNames.Count} items from Google Drive path: {folderPath}");
                return fileNames;
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to list files from Google Drive: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Deletes a file from Google Drive
        /// </summary>
        /// <param name="cloudPath">The path to delete</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public async Task DeleteAsync(string cloudPath)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("Google Drive manager is not initialized. Call InitializeAsync first.");
            }

            try
            {
                string fileId = await GetFileIdByPathAsync(cloudPath);
                if (string.IsNullOrEmpty(fileId))
                {
                    throw new FileNotFoundException($"File not found in Google Drive: {cloudPath}");
                }

                await _driveService.Files.Delete(fileId).ExecuteAsync();
                Logger.Info($"Item deleted successfully from Google Drive: {cloudPath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to delete item from Google Drive: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Gets file metadata from Google Drive
        /// </summary>
        /// <param name="cloudPath">The Google Drive path</param>
        /// <returns>A task representing the asynchronous operation with file metadata</returns>
        public async Task<CloudFileMetadata> GetMetadataAsync(string cloudPath)
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("Google Drive manager is not initialized. Call InitializeAsync first.");
            }

            try
            {
                string fileId = await GetFileIdByPathAsync(cloudPath);
                if (string.IsNullOrEmpty(fileId))
                {
                    throw new FileNotFoundException($"File not found in Google Drive: {cloudPath}");
                }

                FilesResource.GetRequest request = _driveService.Files.Get(fileId);
                request.Fields = "id, name, size, mimeType";
                Google.Apis.Drive.v3.Data.File file = await request.ExecuteAsync();

                CloudFileMetadata metadata = new CloudFileMetadata
                {
                    Id = file.Id,
                    Name = file.Name,
                    Size = file.Size ?? 0,
                    Path = cloudPath,
                    IsFolder = file.MimeType == "application/vnd.google-apps.folder"
                };

                Logger.Info($"Retrieved metadata from Google Drive: {cloudPath}");
                return metadata;
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to get metadata from Google Drive: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Gets the file ID by path
        /// </summary>
        private async Task<string> GetFileIdByPathAsync(string path)
        {
            string[] parts = path.Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
            string currentFolderId = "root";

            for (int i = 0; i < parts.Length - 1; i++)
            {
                FilesResource.ListRequest request = _driveService.Files.List();
                request.Q = $"'{currentFolderId}' in parents and name = '{parts[i]}' and mimeType = 'application/vnd.google-apps.folder' and trashed = false";
                request.Spaces = "drive";
                request.Fields = "files(id)";

                FileList result = await request.ExecuteAsync();
                if (result.Files.Count == 0)
                {
                    return null;
                }

                currentFolderId = result.Files[0].Id;
            }

            FilesResource.ListRequest fileRequest = _driveService.Files.List();
            fileRequest.Q = $"'{currentFolderId}' in parents and name = '{parts[parts.Length - 1]}' and trashed = false";
            fileRequest.Spaces = "drive";
            fileRequest.Fields = "files(id)";

            FileList fileResult = await fileRequest.ExecuteAsync();
            return fileResult.Files.Count > 0 ? fileResult.Files[0].Id : null;
        }

        /// <summary>
        ///     Gets the folder ID by path
        /// </summary>
        private async Task<string> GetFolderIdByPathAsync(string path)
        {
            if (string.IsNullOrEmpty(path) || path == "/")
            {
                return "root";
            }

            string[] parts = path.Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
            string currentFolderId = "root";

            foreach (string part in parts)
            {
                FilesResource.ListRequest request = _driveService.Files.List();
                request.Q = $"'{currentFolderId}' in parents and name = '{part}' and mimeType = 'application/vnd.google-apps.folder' and trashed = false";
                request.Spaces = "drive";
                request.Fields = "files(id)";

                FileList result = await request.ExecuteAsync();
                if (result.Files.Count == 0)
                {
                    return null;
                }

                currentFolderId = result.Files[0].Id;
            }

            return currentFolderId;
        }

        /// <summary>
        ///     Gets or creates a folder by path
        /// </summary>
        private async Task<string> GetOrCreateFolderId(string path)
        {
            if (string.IsNullOrEmpty(path) || path == "/")
            {
                return "root";
            }

            string[] parts = path.Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
            string currentFolderId = "root";

            foreach (string part in parts)
            {
                FilesResource.ListRequest request = _driveService.Files.List();
                request.Q = $"'{currentFolderId}' in parents and name = '{part}' and mimeType = 'application/vnd.google-apps.folder' and trashed = false";
                request.Spaces = "drive";
                request.Fields = "files(id)";

                FileList result = await request.ExecuteAsync();
                if (result.Files.Count > 0)
                {
                    currentFolderId = result.Files[0].Id;
                }
                else
                {
                    Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = part,
                        MimeType = "application/vnd.google-apps.folder",
                        Parents = new List<string> { currentFolderId }
                    };

                    FilesResource.CreateRequest createRequest = _driveService.Files.Create(fileMetadata);
                    createRequest.Fields = "id";
                    Google.Apis.Drive.v3.Data.File newFolder = await createRequest.ExecuteAsync();
                    currentFolderId = newFolder.Id;
                }
            }

            return currentFolderId;
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
            if (_driveService != null)
            {
                _driveService.Dispose();
                _driveService = null;
                Logger.Info("Google Drive service disposed");
            }

            base.OnDestroy();
        }

        /// <summary>
        ///     Disposes the manager
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            OnDestroy();
        }
    }
}