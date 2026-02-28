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
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Extension.Cloud.GoogleDrive.Sample
{
    /// <summary>
    ///     Sample usage of the Google Drive Cloud Manager
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point demonstrating how to use the Google Drive manager
        /// </summary>
        public static async Task Main()
        {
            Logger.Info("=== Google Drive Cloud Manager Sample ===");

            try
            {
                // Create a new context
                Context context = new Context();

                // Create the Google Drive manager
                GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

                Logger.Info($"Manager created: {manager.Name} (Tag: {manager.Tag})");
                Logger.Info($"Manager initialized: {manager.IsInitialized}");

                // Example 1: Creating a manager with custom properties
                Logger.Info("\n--- Example 1: Custom Manager Creation ---");
                GoogleDriveCloudManager customManager = new GoogleDriveCloudManager(
                    "custom-google-drive",
                    "My Custom Google Drive",
                    "Cloud",
                    true,
                    context
                );
                Logger.Info($"Custom manager created: {customManager.Name}");
                Logger.Info($"Custom manager is enabled: {customManager.IsEnable}");

                // Example 2: Manager lifecycle
                Logger.Info("\n--- Example 2: Manager Lifecycle ---");
                Logger.Info($"Initial state - IsEnable: {manager.IsEnable}");
                manager.IsEnable = false;
                Logger.Info($"After disable - IsEnable: {manager.IsEnable}");
                manager.IsEnable = true;
                Logger.Info($"After re-enable - IsEnable: {manager.IsEnable}");

                // Example 3: Cloud file metadata
                Logger.Info("\n--- Example 3: Cloud File Metadata ---");
                CloudFileMetadata fileMetadata = new CloudFileMetadata
                {
                    Id = "file-123",
                    Name = "example.pdf",
                    Size = 2048,
                    Path = "/Documents/example.pdf",
                    IsFolder = false
                };

                Logger.Info($"File: {fileMetadata.Name}");
                Logger.Info($"Path: {fileMetadata.Path}");
                Logger.Info($"Size: {fileMetadata.Size} bytes");
                Logger.Info($"Is Folder: {fileMetadata.IsFolder}");

                // Example 4: Folder metadata
                Logger.Info("\n--- Example 4: Folder Metadata ---");
                CloudFileMetadata folderMetadata = new CloudFileMetadata
                {
                    Id = "folder-456",
                    Name = "MyDocuments",
                    Size = 0,
                    Path = "/MyDocuments",
                    IsFolder = true
                };

                Logger.Info($"Folder: {folderMetadata.Name}");
                Logger.Info($"Path: {folderMetadata.Path}");
                Logger.Info($"Is Folder: {folderMetadata.IsFolder}");

                // Example 5: Manager interface implementation
                Logger.Info("\n--- Example 5: Interface Implementation ---");
                ICloudManager cloudManager = manager;
                Logger.Info($"Manager implements ICloudManager: {cloudManager != null}");
                Logger.Info($"Manager is initialized: {cloudManager.IsInitialized}");

                // Example 6: Attempting to use uninitialized manager
                Logger.Info("\n--- Example 6: Attempting to use uninitialized manager ---");
                try
                {
                    await manager.ListFilesAsync("/");
                }
                catch (InvalidOperationException ex)
                {
                    Logger.Warning($"Expected error: {ex.Message}");
                }

                // Example 7: Initialization with invalid token would fail
                Logger.Info("\n--- Example 7: Initialization validation ---");
                try
                {
                    await manager.InitializeAsync(null);
                }
                catch (ArgumentException ex)
                {
                    Logger.Warning($"Expected validation error: {ex.Message}");
                }

                Logger.Info("\n=== Sample completed successfully ===");
            }
            catch (Exception ex)
            {
                Logger.Error($"Sample error: {ex.Message}");
            }
        }
    }
}