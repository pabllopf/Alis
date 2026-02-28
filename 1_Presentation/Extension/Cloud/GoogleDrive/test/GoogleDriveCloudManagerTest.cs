// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManagerTest.cs
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
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    /// <summary>
    ///     Unit tests for GoogleDriveCloudManager
    /// </summary>
    public class GoogleDriveCloudManagerTest
    {
        /// <summary>
        ///     Tests manager creation with context
        /// </summary>
        [Fact]
        public void ManagerCreation_WithContext_InitializesCorrectly()
        {
            // Arrange
            Context context = new Context();

            // Act
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Assert
            Assert.NotNull(manager);
            Assert.NotNull(manager.Context);
            Assert.Same(context, manager.Context);
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests manager creation with custom properties
        /// </summary>
        [Fact]
        public void ManagerCreation_WithCustomProperties_InitializesCorrectly()
        {
            // Arrange
            Context context = new Context();
            string id = "test-id";
            string name = "Test Manager";
            string tag = "TestTag";
            bool isEnable = true;

            // Act
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(id, name, tag, isEnable, context);

            // Assert
            Assert.NotNull(manager);
            Assert.Equal(id, manager.Id);
            Assert.Equal(name, manager.Name);
            Assert.Equal(tag, manager.Tag);
            Assert.Equal(isEnable, manager.IsEnable);
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests initialization with null token
        /// </summary>
        [Fact]
        public async void InitializeAsync_WithNullToken_ThrowsArgumentException()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(null));
        }

        /// <summary>
        ///     Tests initialization with empty token
        /// </summary>
        [Fact]
        public async void InitializeAsync_WithEmptyToken_ThrowsArgumentException()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(string.Empty));
        }

        /// <summary>
        ///     Tests that upload fails when not initialized
        /// </summary>
        [Fact]
        public async void UploadFileAsync_WhenNotInitialized_ThrowsInvalidOperationException()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                manager.UploadFileAsync("test.txt", "/cloud/test.txt"));
        }

        /// <summary>
        ///     Tests that download fails when not initialized
        /// </summary>
        [Fact]
        public async void DownloadFileAsync_WhenNotInitialized_ThrowsInvalidOperationException()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                manager.DownloadFileAsync("/cloud/test.txt", "test.txt"));
        }

        /// <summary>
        ///     Tests that list files fails when not initialized
        /// </summary>
        [Fact]
        public async void ListFilesAsync_WhenNotInitialized_ThrowsInvalidOperationException()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                manager.ListFilesAsync("/"));
        }

        /// <summary>
        ///     Tests that delete fails when not initialized
        /// </summary>
        [Fact]
        public async void DeleteAsync_WhenNotInitialized_ThrowsInvalidOperationException()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                manager.DeleteAsync("/cloud/test.txt"));
        }

        /// <summary>
        ///     Tests that get metadata fails when not initialized
        /// </summary>
        [Fact]
        public async void GetMetadataAsync_WhenNotInitialized_ThrowsInvalidOperationException()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => 
                manager.GetMetadataAsync("/cloud/test.txt"));
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
        ///     Tests that manager can be disposed
        /// </summary>
        [Fact]
        public void ManagerDisposal_Dispose_DoesNotThrow()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act & Assert
            manager.Dispose();
        }

        /// <summary>
        ///     Tests manager properties are correctly initialized
        /// </summary>
        [Fact]
        public void ManagerProperties_DefaultValues_AreCorrectlySet()
        {
            // Arrange
            Context context = new Context();

            // Act
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Assert
            Assert.Equal("GoogleDriveManager", manager.Name);
            Assert.Equal("Cloud", manager.Tag);
            Assert.NotNull(manager.Id);
            Assert.True(manager.IsEnable);
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests manager enable/disable functionality
        /// </summary>
        [Fact]
        public void ManagerEnable_CanBeDisabled_AndReenabled()
        {
            // Arrange
            Context context = new Context();
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(context);

            // Act
            bool initialState = manager.IsEnable;
            manager.IsEnable = false;
            bool disabledState = manager.IsEnable;
            manager.IsEnable = true;
            bool reenabbledState = manager.IsEnable;

            // Assert
            Assert.True(initialState);
            Assert.False(disabledState);
            Assert.True(reenabbledState);
        }

        /// <summary>
        ///     Tests CloudFileMetadata properties
        /// </summary>
        [Fact]
        public void CloudFileMetadata_PropertiesCanBeSet()
        {
            // Arrange
            CloudFileMetadata metadata = new CloudFileMetadata();

            // Act
            metadata.Id = "file-123";
            metadata.Name = "test.txt";
            metadata.Size = 1024;
            metadata.Path = "/folder/test.txt";
            metadata.IsFolder = false;

            // Assert
            Assert.Equal("file-123", metadata.Id);
            Assert.Equal("test.txt", metadata.Name);
            Assert.Equal(1024, metadata.Size);
            Assert.Equal("/folder/test.txt", metadata.Path);
            Assert.False(metadata.IsFolder);
        }
    }
}

