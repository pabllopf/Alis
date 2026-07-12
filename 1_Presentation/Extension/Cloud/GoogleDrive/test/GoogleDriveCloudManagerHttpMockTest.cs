// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManagerHttpMockTest.cs
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
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Google.Apis.Drive.v3;
using Google.Apis.Http;
using Google.Apis.Services;
using Moq;
using Xunit;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    /// <summary>
    ///     Tests for GoogleDriveCloudManager using HTTP-level mocking
    /// </summary>
    public class GoogleDriveCloudManagerHttpMockTest
    {
        /// <summary>
        ///     Creates a DriveService with a mock HTTP message handler for controlled responses
        /// </summary>
        private static (DriveService Service, MockHttpMessageHandler Handler) CreateMockDriveService()
        {
            MockHttpMessageHandler innerHandler = new MockHttpMessageHandler();
            ConfigurableMessageHandler configurableHandler = new ConfigurableMessageHandler(innerHandler);
            ConfigurableHttpClient httpClient = new ConfigurableHttpClient(configurableHandler);

            Mock<IHttpClientFactory> factoryMock = new Mock<IHttpClientFactory>();
            factoryMock
                .Setup(f => f.CreateHttpClient(It.IsAny<CreateHttpClientArgs>()))
                .Returns(httpClient);

            DriveService service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientFactory = factoryMock.Object,
                ApplicationName = "Test"
            });

            return (service, innerHandler);
        }

        /// <summary>
        ///     Tests that ListFilesAsync with root path returns file names
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_RootPath_ReturnsFileList()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"f1\",\"name\":\"doc.txt\"},{\"id\":\"f2\",\"name\":\"image.png\"}]}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            IList<string> files = await manager.ListFilesAsync("/");

            Assert.Equal(2, files.Count);
            Assert.Contains("doc.txt", files);
            Assert.Contains("image.png", files);
        }

        /// <summary>
        ///     Tests that ListFilesAsync with empty folder returns empty list
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_EmptyFolder_ReturnsEmptyList()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[]}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            IList<string> files = await manager.ListFilesAsync("/");

            Assert.Empty(files);
        }

        /// <summary>
        ///     Tests that ListFilesAsync when folder not found returns empty list
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_FolderPathNotFound_ReturnsEmptyList()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[]}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            IList<string> files = await manager.ListFilesAsync("nonexistent");

            Assert.Empty(files);
        }

        /// <summary>
        ///     Tests that GetMetadataAsync returns file metadata for a non-folder file
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_ExistingFile_ReturnsMetadata()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"f123\",\"name\":\"test.txt\"}]}");
            handler.QueueJsonResponse("{\"id\":\"f123\",\"name\":\"test.txt\",\"size\":\"1024\",\"mimeType\":\"text/plain\"}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            CloudFileMetadata metadata = await manager.GetMetadataAsync("/test.txt");

            Assert.Equal("f123", metadata.Id);
            Assert.Equal("test.txt", metadata.Name);
            Assert.Equal(1024, metadata.Size);
            Assert.Equal("/test.txt", metadata.Path);
            Assert.False(metadata.IsFolder);
        }

        /// <summary>
        ///     Tests that GetMetadataAsync correctly identifies folders
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_ExistingFolder_ReturnsIsFolderTrue()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"folder1\",\"name\":\"MyFolder\"}]}");
            handler.QueueJsonResponse("{\"id\":\"folder1\",\"name\":\"MyFolder\",\"size\":\"0\",\"mimeType\":\"application/vnd.google-apps.folder\"}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            CloudFileMetadata metadata = await manager.GetMetadataAsync("/MyFolder");

            Assert.Equal("folder1", metadata.Id);
            Assert.Equal("MyFolder", metadata.Name);
            Assert.True(metadata.IsFolder);
        }

        /// <summary>
        ///     Tests that DeleteAsync with existing file completes without exception
        /// </summary>
        [Fact]
        public async Task DeleteAsync_ExistingFile_CompletesSuccessfully()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"del123\",\"name\":\"delete.txt\"}]}");
            handler.QueueResponse(new HttpResponseMessage(HttpStatusCode.NoContent));

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            await manager.DeleteAsync("/delete.txt");
        }

        /// <summary>
        ///     Tests that DownloadFileAsync creates directory and downloads content
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_ExistingFile_CreatesDirectoryAndDownloads()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            string tempFile = Path.Combine(tempDir, "downloaded.txt");

            try
            {
                (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
                handler.QueueJsonResponse("{\"files\":[{\"id\":\"dl123\",\"name\":\"remote.txt\"}]}");
                handler.QueueResponse(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Hello from Google Drive!")
                });

                GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

                await manager.DownloadFileAsync("/remote.txt", tempFile);

                Assert.True(File.Exists(tempFile));
                Assert.Equal("Hello from Google Drive!", File.ReadAllText(tempFile));
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
        ///     Tests that DownloadFileAsync with directory already existing works correctly
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_ExistingDirectory_DoesNotThrow()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            string tempFile = Path.Combine(tempDir, "downloaded.txt");

            try
            {
                (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
                handler.QueueJsonResponse("{\"files\":[{\"id\":\"dl456\",\"name\":\"data.bin\"}]}");
                handler.QueueResponse(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("binary data")
                });

                GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

                await manager.DownloadFileAsync("/data.bin", tempFile);

                Assert.True(File.Exists(tempFile));
                Assert.Equal("binary data", File.ReadAllText(tempFile));
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
        ///     Tests that ListFilesAsync returns files when intermediate folder exists
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithSubFolderPath_ReturnsFileList()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"sub1\",\"name\":\"subfolder\"}]}");
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"f1\",\"name\":\"deep.txt\"}]}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            IList<string> files = await manager.ListFilesAsync("/subfolder");

            Assert.Single(files);
            Assert.Contains("deep.txt", files);
        }

        /// <summary>
        ///     Tests that GetMetadataAsync with multi-segment path works correctly
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithSubFolderPath_ReturnsMetadata()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"parent1\",\"name\":\"parent\"}]}");
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"child1\",\"name\":\"child.txt\"}]}");
            handler.QueueJsonResponse("{\"id\":\"child1\",\"name\":\"child.txt\",\"size\":\"512\",\"mimeType\":\"text/plain\"}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            CloudFileMetadata metadata = await manager.GetMetadataAsync("/parent/child.txt");

            Assert.Equal("child1", metadata.Id);
            Assert.Equal("child.txt", metadata.Name);
            Assert.Equal(512, metadata.Size);
        }

        /// <summary>
        ///     Tests that DeleteAsync with multi-segment path works correctly
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithSubFolderPath_CompletesSuccessfully()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"parent1\",\"name\":\"parent\"}]}");
            handler.QueueJsonResponse("{\"files\":[{\"id\":\"child1\",\"name\":\"delete.txt\"}]}");
            handler.QueueResponse(new HttpResponseMessage(HttpStatusCode.NoContent));

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            await manager.DeleteAsync("/parent/delete.txt");
        }

        /// <summary>
        ///     Tests that GetMetadataAsync when file not found throws FileNotFoundException
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_FileNotFound_ThrowsFileNotFoundException()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[]}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.GetMetadataAsync("/missing.txt"));
        }

        /// <summary>
        ///     Tests that DeleteAsync when file not found throws FileNotFoundException
        /// </summary>
        [Fact]
        public async Task DeleteAsync_FileNotFound_ThrowsFileNotFoundException()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[]}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.DeleteAsync("/missing.txt"));
        }

        /// <summary>
        ///     Tests that GetMetadataAsync with null file id from path throws FileNotFoundException
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_PathNormalized_FileNotFound_ThrowsFileNotFoundException()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[]}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.GetMetadataAsync("missing.txt"));
        }

        /// <summary>
        ///     Tests that DeleteAsync with null file id from path throws FileNotFoundException
        /// </summary>
        [Fact]
        public async Task DeleteAsync_PathNormalized_FileNotFound_ThrowsFileNotFoundException()
        {
            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[]}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.DeleteAsync("missing.txt"));
        }

        /// <summary>
        ///     Tests that DownloadFileAsync when file not found throws FileNotFoundException
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_FileNotFound_ThrowsFileNotFoundException()
        {
            string tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString(), "out.txt");

            (DriveService service, MockHttpMessageHandler handler) = CreateMockDriveService();
            handler.QueueJsonResponse("{\"files\":[]}");

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), service);

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.DownloadFileAsync("/missing.txt", tempFile));
        }
    }
}
