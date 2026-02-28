// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CloudFileMetadataTest.cs
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
using Xunit;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    /// <summary>
    ///     Unit tests for CloudFileMetadata
    /// </summary>
    public class CloudFileMetadataTest
    {
        /// <summary>
        ///     Tests default constructor creates empty metadata
        /// </summary>
        [Fact]
        public void CloudFileMetadata_DefaultConstructor_CreatesEmptyMetadata()
        {
            // Act
            CloudFileMetadata metadata = new CloudFileMetadata();

            // Assert
            Assert.Null(metadata.Id);
            Assert.Null(metadata.Name);
            Assert.Equal(0, metadata.Size);
            Assert.Null(metadata.Path);
            Assert.False(metadata.IsFolder);
        }

        /// <summary>
        ///     Tests setting all properties
        /// </summary>
        [Fact]
        public void CloudFileMetadata_SetAllProperties_WorksCorrectly()
        {
            // Arrange
            CloudFileMetadata metadata = new CloudFileMetadata();
            string id = "test-id-123";
            string name = "testfile.txt";
            long size = 2048L;
            string path = "/test/testfile.txt";
            bool isFolder = false;

            // Act
            metadata.Id = id;
            metadata.Name = name;
            metadata.Size = size;
            metadata.Path = path;
            metadata.IsFolder = isFolder;

            // Assert
            Assert.Equal(id, metadata.Id);
            Assert.Equal(name, metadata.Name);
            Assert.Equal(size, metadata.Size);
            Assert.Equal(path, metadata.Path);
            Assert.Equal(isFolder, metadata.IsFolder);
        }

        /// <summary>
        ///     Tests properties with large file size
        /// </summary>
        [Fact]
        public void CloudFileMetadata_WithLargeFileSize_WorksCorrectly()
        {
            // Arrange
            CloudFileMetadata metadata = new CloudFileMetadata
            {
                Id = "large-file-123",
                Name = "largefile.bin",
                Size = 1073741824, // 1 GB
                Path = "/data/largefile.bin",
                IsFolder = false
            };

            // Assert
            Assert.Equal(1073741824, metadata.Size);
            Assert.Equal("largefile.bin", metadata.Name);
        }

        /// <summary>
        ///     Tests folder metadata
        /// </summary>
        [Fact]
        public void CloudFileMetadata_AsFolder_IsCorrectlyIdentified()
        {
            // Arrange
            CloudFileMetadata metadata = new CloudFileMetadata
            {
                Id = "folder-456",
                Name = "MyDocuments",
                Size = 0,
                Path = "/MyDocuments",
                IsFolder = true
            };

            // Assert
            Assert.True(metadata.IsFolder);
            Assert.Equal(0, metadata.Size);
            Assert.Equal("MyDocuments", metadata.Name);
        }

        /// <summary>
        ///     Tests metadata with special characters in path
        /// </summary>
        [Fact]
        public void CloudFileMetadata_WithSpecialCharactersInPath_WorksCorrectly()
        {
            // Arrange
            CloudFileMetadata metadata = new CloudFileMetadata
            {
                Id = "special-123",
                Name = "file with spaces & chars.txt",
                Size = 512,
                Path = "/folder/with spaces/file with spaces & chars.txt",
                IsFolder = false
            };

            // Assert
            Assert.Equal("file with spaces & chars.txt", metadata.Name);
            Assert.Contains("spaces", metadata.Path);
        }

        /// <summary>
        ///     Tests metadata equality based on content
        /// </summary>
        [Fact]
        public void CloudFileMetadata_MultipleInstances_CanBeCompared()
        {
            // Arrange
            CloudFileMetadata metadata1 = new CloudFileMetadata
            {
                Id = "same-id",
                Name = "samefile.txt",
                Size = 1024,
                Path = "/same/samefile.txt",
                IsFolder = false
            };

            CloudFileMetadata metadata2 = new CloudFileMetadata
            {
                Id = "same-id",
                Name = "samefile.txt",
                Size = 1024,
                Path = "/same/samefile.txt",
                IsFolder = false
            };

            // Act & Assert
            Assert.Equal(metadata1.Id, metadata2.Id);
            Assert.Equal(metadata1.Name, metadata2.Name);
            Assert.Equal(metadata1.Size, metadata2.Size);
            Assert.Equal(metadata1.Path, metadata2.Path);
            Assert.Equal(metadata1.IsFolder, metadata2.IsFolder);
        }

        /// <summary>
        ///     Tests nested folder paths
        /// </summary>
        [Fact]
        public void CloudFileMetadata_WithNestedFolderPaths_WorksCorrectly()
        {
            // Arrange
            CloudFileMetadata metadata = new CloudFileMetadata
            {
                Id = "nested-folder",
                Name = "DeepFolder",
                Size = 0,
                Path = "/root/level1/level2/level3/DeepFolder",
                IsFolder = true
            };

            // Assert
            Assert.True(metadata.IsFolder);
            Assert.Contains("level3", metadata.Path);
        }

        /// <summary>
        ///     Tests metadata for different file types
        /// </summary>
        [Theory, InlineData("document.pdf", 1024), InlineData("image.png", 2048), InlineData("video.mp4", 1073741824), InlineData("data.csv", 512)]
        public void CloudFileMetadata_DifferentFileTypes_WorksCorrectly(string filename, long filesize)
        {
            // Arrange & Act
            CloudFileMetadata metadata = new CloudFileMetadata
            {
                Id = $"file-{filename}",
                Name = filename,
                Size = filesize,
                Path = $"/files/{filename}",
                IsFolder = false
            };

            // Assert
            Assert.Equal(filename, metadata.Name);
            Assert.Equal(filesize, metadata.Size);
            Assert.False(metadata.IsFolder);
        }

        /// <summary>
        ///     Tests metadata list collection
        /// </summary>
        [Fact]
        public void CloudFileMetadata_InList_WorksCorrectly()
        {
            // Arrange
            List<CloudFileMetadata> metadataList = new List<CloudFileMetadata>
            {
                new CloudFileMetadata {Id = "1", Name = "file1.txt", Size = 100, Path = "/file1.txt", IsFolder = false},
                new CloudFileMetadata {Id = "2", Name = "file2.txt", Size = 200, Path = "/file2.txt", IsFolder = false},
                new CloudFileMetadata {Id = "3", Name = "folder1", Size = 0, Path = "/folder1", IsFolder = true}
            };

            // Assert
            Assert.Equal(3, metadataList.Count);
            int filesCount = metadataList.FindAll(m => !m.IsFolder).Count;
            int foldersCount = metadataList.FindAll(m => m.IsFolder).Count;
            Assert.Equal(2, filesCount);
            Assert.Equal(1, foldersCount);
        }
    }
}