// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManagerIntegrationTest.cs
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

using System.IO;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    /// <summary>
    ///     Integration tests for GoogleDriveCloudManager with local file operations
    /// </summary>
    public class GoogleDriveCloudManagerIntegrationTest
    {
        /// <summary>
        ///     Tests creating a temporary file and verifying its existence
        /// </summary>
        [Fact]
        public void CreateTemporaryFile_VerifiesFileExists()
        {
            // Arrange
            string tempFile = Path.GetTempFileName();

            try
            {
                // Act & Assert
                Assert.True(File.Exists(tempFile));
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        /// <summary>
        ///     Tests writing and reading file content
        /// </summary>
        [Fact]
        public void FileOperations_WriteAndRead_ReturnsCorrectContent()
        {
            // Arrange
            string tempFile = Path.GetTempFileName();
            string content = "Test content for Google Drive integration";

            try
            {
                // Act
                File.WriteAllText(tempFile, content);
                string readContent = File.ReadAllText(tempFile);

                // Assert
                Assert.Equal(content, readContent);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        /// <summary>
        ///     Tests that manager can be integrated with Context
        /// </summary>
        [Fact]
        public void ManagerIntegration_WithContext_WorksCorrectly()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            Assert.NotNull(manager);
            Assert.NotNull(manager.Context);
            Assert.Same(context, manager.Context);
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests manager lifecycle - enable/disable
        /// </summary>
        [Fact]
        public void ManagerLifecycle_EnableDisable_WorksCorrectly()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act
            bool initialState = manager.IsEnable;
            manager.IsEnable = false;

            // Assert
            Assert.True(initialState);
            Assert.False(manager.IsEnable);
        }

        /// <summary>
        ///     Tests that manager implements ICloudManager interface
        /// </summary>
        [Fact]
        public void ManagerImplementation_ImplementsICloudManager()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            Assert.IsAssignableFrom<ICloudManager>(manager);
        }

        /// <summary>
        ///     Tests manager properties are correctly initialized
        /// </summary>
        [Fact]
        public void ManagerProperties_AreCorrectlyInitialized()
        {
            // Arrange
            Context context = new Context();

            // Act
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Assert
            Assert.Equal("GoogleDriveManager", manager.Name);
            Assert.Equal("Cloud", manager.Tag);
            Assert.True(manager.IsEnable);
        }
        

        /// <summary>
        ///     Tests directory creation for downloads
        /// </summary>
        [Fact]
        public void FileOperations_CreateDirectory_SucceedsWhenDoesNotExist()
        {
            // Arrange
            string tempDir = Path.Combine(Path.GetTempPath(), "TestGoogleDriveDir");
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }

            try
            {
                // Act
                Directory.CreateDirectory(tempDir);

                // Assert
                Assert.True(Directory.Exists(tempDir));
            }
            finally
            {
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
            }
        }

        /// <summary>
        ///     Tests CloudFileMetadata initialization
        /// </summary>
        [Fact]
        public void CloudFileMetadata_InitializationAndProperties()
        {
            // Arrange
            CloudFileMetadata metadata = new CloudFileMetadata
            {
                Id = "drive-123",
                Name = "document.pdf",
                Size = 5120,
                Path = "/documents/document.pdf",
                IsFolder = false
            };

            // Assert
            Assert.Equal("drive-123", metadata.Id);
            Assert.Equal("document.pdf", metadata.Name);
            Assert.Equal(5120, metadata.Size);
            Assert.Equal("/documents/document.pdf", metadata.Path);
            Assert.False(metadata.IsFolder);
        }

        /// <summary>
        ///     Tests CloudFileMetadata as folder
        /// </summary>
        [Fact]
        public void CloudFileMetadata_AsFolder_ReturnsCorrectProperties()
        {
            // Arrange
            CloudFileMetadata metadata = new CloudFileMetadata
            {
                Id = "folder-456",
                Name = "MyFolder",
                Size = 0,
                Path = "/documents/MyFolder",
                IsFolder = true
            };

            // Assert
            Assert.True(metadata.IsFolder);
            Assert.Equal("MyFolder", metadata.Name);
        }
    }
}

