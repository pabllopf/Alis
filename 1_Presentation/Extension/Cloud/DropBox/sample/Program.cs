// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api.Files;

namespace Alis.Extension.Cloud.DropBox.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point for the DropBox sample
        /// </summary>
        public static async Task Main()
        {
            Logger.Info("===== DropBox Integration Sample =====");
            Logger.Info("");

            // Create a new context for the game engine
            Context context = new Context();

            // Create the DropBox cloud manager
            DropBoxCloudManager dropBoxManager = new DropBoxCloudManager(context);
            Logger.Info($"DropBox Manager created: {dropBoxManager.Name} ({dropBoxManager.Tag})");
            Logger.Info("");

            try
            {
                // Example 1: Initialize with access token
                await InitializeExample(dropBoxManager);

                // Note: The following examples would require a valid Dropbox API token
                // and would interact with real Dropbox API. For demonstration purposes,
                // we show the usage patterns only.

                // Example 2: Upload a file
                Logger.Info("===== Upload Example =====");
                await UploadExample(dropBoxManager);

                // Example 3: Download a file
                Logger.Info("===== Download Example =====");
                await DownloadExample(dropBoxManager);

                // Example 4: List files
                Logger.Info("===== List Files Example =====");
                await ListFilesExample(dropBoxManager);

                // Example 5: Get metadata
                Logger.Info("===== Get Metadata Example =====");
                await GetMetadataExample(dropBoxManager);

                // Example 6: Delete a file
                Logger.Info("===== Delete Example =====");
                await DeleteExample(dropBoxManager);
            }
            catch (Exception ex)
            {
                Logger.Error($"Sample execution error: {ex.Message}");
            }
            finally
            {
                // Clean up resources
                dropBoxManager.OnDestroy();
                Logger.Info("");
                Logger.Info("Sample completed. Resources cleaned up.");
            }
        }

        /// <summary>
        ///     Demonstrates initializing the DropBox manager with an access token
        /// </summary>
        /// <param name="manager">The DropBox manager instance</param>
        private static async Task InitializeExample(DropBoxCloudManager manager)
        {
            Logger.Info("===== Initialization Example =====");
            Logger.Info("");
            Logger.Info("To use DropBox integration, you need:");
            Logger.Info("1. Create a Dropbox app at https://www.dropbox.com/developers/apps");
            Logger.Info("2. Generate an OAuth 2.0 access token");
            Logger.Info("3. Initialize the manager with: await manager.InitializeAsync(\"YOUR_TOKEN_HERE\")");
            Logger.Info("");

            try
            {
                // This would be how you initialize with a real token:
                // await manager.InitializeAsync("your-dropbox-api-token-here");
                // Logger.Info($"Successfully initialized DropBox manager. IsInitialized: {manager.IsInitialized}");

                Logger.Info("Note: Replace 'your-dropbox-api-token-here' with a valid Dropbox API token");
                Logger.Info($"Current status - IsInitialized: {manager.IsInitialized}");
            }
            catch (ArgumentException ex)
            {
                Logger.Error($"Initialization failed - Invalid token: {ex.Message}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Initialization failed: {ex.Message}");
            }

            Logger.Info("");
        }

        /// <summary>
        ///     Demonstrates uploading a file to Dropbox
        /// </summary>
        /// <param name="manager">The DropBox manager instance</param>
        private static async Task UploadExample(DropBoxCloudManager manager)
        {
            Logger.Info("File upload example:");
            Logger.Info("");

            try
            {
                if (!manager.IsInitialized)
                {
                    Logger.Info("Manager not initialized. Usage:");
                    Logger.Info("1. Create a local file");
                    Logger.Info("2. Call: var result = await manager.UploadFileAsync(");
                    Logger.Info("     \"path/to/local/file.txt\", \"/dropbox/destination.txt\");");
                    Logger.Info("");
                    return;
                }

                // Example: Upload a file
                string localFile = Path.GetTempFileName();
                try
                {
                    // Create a sample file
                    File.WriteAllText(localFile, "Sample content for Dropbox upload");

                    // Upload the file
                    FileMetadata metadata = await manager.UploadFileAsync(localFile, "/sample-upload.txt");
                    Logger.Info($"Successfully uploaded file: {metadata.Name}");
                    Logger.Info($"File path: {metadata.PathDisplay}");
                }
                finally
                {
                    if (File.Exists(localFile))
                    {
                        File.Delete(localFile);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                Logger.Info("Cannot upload: Manager is not initialized");
            }
            catch (Exception ex)
            {
                Logger.Error($"Upload failed: {ex.Message}");
            }

            Logger.Info("");
        }

        /// <summary>
        ///     Demonstrates downloading a file from Dropbox
        /// </summary>
        /// <param name="manager">The DropBox manager instance</param>
        private static async Task DownloadExample(DropBoxCloudManager manager)
        {
            Logger.Info("File download example:");
            Logger.Info("");

            try
            {
                if (!manager.IsInitialized)
                {
                    Logger.Info("Manager not initialized. Usage:");
                    Logger.Info("1. Ensure a file exists in Dropbox");
                    Logger.Info("2. Call: await manager.DownloadFileAsync(");
                    Logger.Info("     \"/dropbox/source.txt\", \"path/to/local/destination.txt\");");
                    Logger.Info("");
                    return;
                }

                // Example: Download a file
                string downloadPath = Path.Combine(Path.GetTempPath(), "downloaded-file.txt");
                await manager.DownloadFileAsync("/sample-upload.txt", downloadPath);

                if (File.Exists(downloadPath))
                {
                    string content = File.ReadAllText(downloadPath);
                    Logger.Info($"Successfully downloaded file with content: {content}");
                    File.Delete(downloadPath);
                }
            }
            catch (InvalidOperationException)
            {
                Logger.Info("Cannot download: Manager is not initialized");
            }
            catch (Exception ex)
            {
                Logger.Error($"Download failed: {ex.Message}");
            }

            Logger.Info("");
        }

        /// <summary>
        ///     Demonstrates listing files in a Dropbox folder
        /// </summary>
        /// <param name="manager">The DropBox manager instance</param>
        private static async Task ListFilesExample(DropBoxCloudManager manager)
        {
            Logger.Info("List files example:");
            Logger.Info("");

            try
            {
                if (!manager.IsInitialized)
                {
                    Logger.Info("Manager not initialized. Usage:");
                    Logger.Info("1. Call: var files = await manager.ListFilesAsync(\"/\");");
                    Logger.Info("2. Iterate through the returned Metadata list");
                    Logger.Info("3. For recursive listing: ListFilesAsync(\"/\", recursive: true)");
                    Logger.Info("");
                    return;
                }

                // Example: List files in root directory
                IList<Metadata> files = await manager.ListFilesAsync("/");

                Logger.Info($"Found {files.Count} items in Dropbox:");
                foreach (Metadata file in files)
                {
                    string fileType = file is Dropbox.Api.Files.FileMetadata ? "File" : "Folder";
                    Logger.Info($"  - {file.Name} ({fileType})");
                }
            }
            catch (InvalidOperationException)
            {
                Logger.Info("Cannot list files: Manager is not initialized");
            }
            catch (Exception ex)
            {
                Logger.Error($"List files failed: {ex.Message}");
            }

            Logger.Info("");
        }

        /// <summary>
        ///     Demonstrates getting file metadata from Dropbox
        /// </summary>
        /// <param name="manager">The DropBox manager instance</param>
        private static async Task GetMetadataExample(DropBoxCloudManager manager)
        {
            Logger.Info("Get metadata example:");
            Logger.Info("");

            try
            {
                if (!manager.IsInitialized)
                {
                    Logger.Info("Manager not initialized. Usage:");
                    Logger.Info("1. Call: var metadata = await manager.GetMetadataAsync(\"/file.txt\");");
                    Logger.Info("2. Access properties like metadata.Name, metadata.PathDisplay");
                    Logger.Info("");
                    return;
                }

                // Example: Get metadata for a specific file
                Metadata metadata = await manager.GetMetadataAsync("/sample-upload.txt");
                Logger.Info($"File metadata retrieved:");
                Logger.Info($"  - Name: {metadata.Name}");
                Logger.Info($"  - Path: {metadata.PathDisplay}");
            }
            catch (InvalidOperationException)
            {
                Logger.Info("Cannot get metadata: Manager is not initialized");
            }
            catch (Exception ex)
            {
                Logger.Error($"Get metadata failed: {ex.Message}");
            }

            Logger.Info("");
        }

        /// <summary>
        ///     Demonstrates deleting a file from Dropbox
        /// </summary>
        /// <param name="manager">The DropBox manager instance</param>
        private static async Task DeleteExample(DropBoxCloudManager manager)
        {
            Logger.Info("Delete file example:");
            Logger.Info("");

            try
            {
                if (!manager.IsInitialized)
                {
                    Logger.Info("Manager not initialized. Usage:");
                    Logger.Info("1. Call: await manager.DeleteAsync(\"/file-to-delete.txt\");");
                    Logger.Info("2. File will be permanently deleted from Dropbox");
                    Logger.Info("");
                    return;
                }

                // Example: Delete a file
                await manager.DeleteAsync("/sample-upload.txt");
                Logger.Info("Successfully deleted file from Dropbox");
            }
            catch (InvalidOperationException)
            {
                Logger.Info("Cannot delete: Manager is not initialized");
            }
            catch (Exception ex)
            {
                Logger.Error($"Delete failed: {ex.Message}");
            }

            Logger.Info("");
        }
    }
}

