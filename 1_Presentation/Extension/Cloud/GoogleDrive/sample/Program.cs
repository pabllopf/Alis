

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
                Context context = new Context();

                GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

                Logger.Info($"Manager created: {manager.Name} (Tag: {manager.Tag})");
                Logger.Info($"Manager initialized: {manager.IsInitialized}");

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

                Logger.Info("\n--- Example 2: Manager Lifecycle ---");
                Logger.Info($"Initial state - IsEnable: {manager.IsEnable}");
                manager.IsEnable = false;
                Logger.Info($"After disable - IsEnable: {manager.IsEnable}");
                manager.IsEnable = true;
                Logger.Info($"After re-enable - IsEnable: {manager.IsEnable}");

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

                Logger.Info("\n--- Example 5: Interface Implementation ---");
                ICloudManager cloudManager = manager;
                Logger.Info($"Manager implements ICloudManager: {cloudManager != null}");
                Logger.Info($"Manager is initialized: {cloudManager.IsInitialized}");

                Logger.Info("\n--- Example 6: Attempting to use uninitialized manager ---");
                try
                {
                    await manager.ListFilesAsync("/");
                }
                catch (InvalidOperationException ex)
                {
                    Logger.Warning($"Expected error: {ex.Message}");
                }

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