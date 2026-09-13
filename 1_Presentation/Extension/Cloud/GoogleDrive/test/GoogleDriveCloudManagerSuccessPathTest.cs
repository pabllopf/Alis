// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManagerSuccessPathTest.cs
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Google.Apis.Drive.v3;
using Google.Apis.Http;
using Google.Apis.Services;
using Moq;
using Xunit;
using File = System.IO.File;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    /// <summary>
    ///     Success path tests for GoogleDriveCloudManager mocking the Google Drive HTTP chain with Moq
    /// </summary>
    public class GoogleDriveCloudManagerSuccessPathTest
    {
        /// <summary>
        ///     The file content served by the mocked download request
        /// </summary>
        private const string DownloadContent = "downloaded file content";

        /// <summary>
        ///     The callback http message handler class
        /// </summary>
        /// <seealso cref="ConfigurableMessageHandler"/>
        private sealed class CallbackHttpMessageHandler : ConfigurableMessageHandler
        {
            /// <summary>
            ///     The callback
            /// </summary>
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _callback;

            /// <summary>
            ///     Initializes a new instance of the <see cref="CallbackHttpMessageHandler"/> class
            /// </summary>
            /// <param name="callback">The callback</param>
            public CallbackHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> callback)
                : base(new HttpClientHandler())
            {
                _callback = callback;
            }

            /// <summary>
            ///     Sends the request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>A task containing the http response message</returns>
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
                Task.FromResult(_callback(request));
        }

        /// <summary>
        ///     Creates the manager with mock service using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <returns>The google drive cloud manager</returns>
        private static GoogleDriveCloudManager CreateManagerWithMockHttpService(Func<HttpRequestMessage, HttpResponseMessage> callback)
        {
            CallbackHttpMessageHandler handler = new CallbackHttpMessageHandler(callback);
            ConfigurableHttpClient httpClient = new ConfigurableHttpClient(handler);
            Mock<IHttpClientFactory> factory = new Mock<IHttpClientFactory>();
            factory.Setup(instance => instance.CreateHttpClient(It.IsAny<CreateHttpClientArgs>())).Returns(httpClient);
            DriveService service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientFactory = factory.Object,
                ApplicationName = "Test"
            });
            return new GoogleDriveCloudManager(new Context(), service);
        }

        /// <summary>
        ///     Jsons the response using the specified json
        /// </summary>
        /// <param name="json">The json</param>
        /// <param name="status">The status</param>
        /// <returns>The http response message</returns>
        private static HttpResponseMessage JsonResponse(string json, HttpStatusCode status = HttpStatusCode.OK) =>
            new HttpResponseMessage(status)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

        /// <summary>
        ///     Lists the response using the specified file defs
        /// </summary>
        /// <param name="fileDefs">The file defs</param>
        /// <returns>The http response message</returns>
        private static HttpResponseMessage ListResponse(params string[] fileDefs)
        {
            StringBuilder json = new StringBuilder("{\"files\":[");
            for (int i = 0; i < fileDefs.Length; i++)
            {
                string[] parts = fileDefs[i].Split('|');
                string id = parts.Length > 0 ? parts[0] : $"f{i}";
                string name = parts.Length > 1 ? parts[1] : id;
                string mime = parts.Length > 2 ? parts[2] : "application/octet-stream";
                if (i > 0) json.Append(',');
                json.Append("{\"id\":\"").Append(id).Append("\",\"name\":\"").Append(name).Append("\",\"mimeType\":\"").Append(mime).Append("\"}");
            }
            json.Append("]}");
            return JsonResponse(json.ToString());
        }

        /// <summary>
        ///     Files the response using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="mime">The mime</param>
        /// <param name="size">The size</param>
        /// <returns>The http response message</returns>
        private static HttpResponseMessage FileResponse(string id, string name, string mime, long size = 1024) =>
            JsonResponse("{\"id\":\"" + id + "\",\"name\":\"" + name + "\",\"size\":\"" + size + "\",\"mimeType\":\"" + mime + "\"}");

        /// <summary>
        ///     Initiates the upload response using the specified upload uri
        /// </summary>
        /// <param name="uploadUri">The upload uri</param>
        /// <returns>The response</returns>
        private static HttpResponseMessage InitiateUploadResponse(string uploadUri)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}", Encoding.UTF8, "application/json")
            };
            response.Headers.Location = new Uri(uploadUri);
            return response;
        }

        /// <summary>
        ///     Tests that ListFilesAsync on the success path returns the file names
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_SuccessPath_ReturnsFileNames()
        {
            using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
                ListResponse("f1|doc.txt|text/plain", "f2|image.png|image/png"));

            IList<string> result = await manager.ListFilesAsync("/");

            Assert.Equal(2, result.Count);
            Assert.Contains("doc.txt", result);
            Assert.Contains("image.png", result);
        }

        /// <summary>
        ///     Tests that ListFilesAsync when the file list payload has no files returns an empty list
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WhenFileListIsNull_ReturnsEmptyList()
        {
            using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
                JsonResponse("{}"));

            IList<string> result = await manager.ListFilesAsync("/");

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that GetMetadataAsync on the success path returns the file metadata
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_SuccessPath_ReturnsMetadata()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("meta123|document.pdf");
                }
                return FileResponse("meta123", "document.pdf", "application/pdf", 2048);
            });

            CloudFileMetadata metadata = await manager.GetMetadataAsync("/document.pdf");

            Assert.Equal("meta123", metadata.Id);
            Assert.Equal("document.pdf", metadata.Name);
            Assert.Equal(2048, metadata.Size);
            Assert.Equal("/document.pdf", metadata.Path);
            Assert.False(metadata.IsFolder);
        }

        /// <summary>
        ///     Tests that GetMetadataAsync with a null size returns zero and a folder mime type sets is folder true
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WhenSizeIsNullAndFolderMime_ReturnsZeroAndIsFolderTrue()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("folder789|MyFolder|application/vnd.google-apps.folder");
                }
                return JsonResponse("{\"id\":\"folder789\",\"name\":\"MyFolder\",\"mimeType\":\"application/vnd.google-apps.folder\"}");
            });

            CloudFileMetadata metadata = await manager.GetMetadataAsync("/MyFolder");

            Assert.Equal(0, metadata.Size);
            Assert.True(metadata.IsFolder);
            Assert.Equal("MyFolder", metadata.Name);
        }

        /// <summary>
        ///     Tests that DownloadFileAsync on the success path creates the directory and writes the file content
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_SuccessPath_CreatesDirectoryAndWritesContent()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            string destFile = Path.Combine(tempDir, "subdir", "downloaded.txt");
            try
            {
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return ListResponse("file123|test.txt");
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(DownloadContent, Encoding.UTF8, "text/plain")
                    };
                });

                await manager.DownloadFileAsync("test.txt", destFile);

                Assert.True(File.Exists(destFile));
                Assert.Equal(DownloadContent, File.ReadAllText(destFile));
            }
            finally
            {
                if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true);
            }
        }

        /// <summary>
        ///     Tests that DeleteAsync on the success path completes without error
        /// </summary>
        [Fact]
        public async Task DeleteAsync_SuccessPath_CompletesWithoutError()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("delete123|delete.txt");
                }
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            });

            Exception exception = await Record.ExceptionAsync(() => manager.DeleteAsync("/delete.txt"));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that UploadFileAsync on the success path with a directoryless cloud path uses the root folder
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_SuccessPath_WithDirectorylessPath_UsesRootFolder()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "upload content");
                string uploadUri = "https://www.googleapis.com/upload/drive/v3/files?upload_id=successRoot123";
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return InitiateUploadResponse(uploadUri);
                    }
                    return FileResponse("rootUploaded", "dest.txt", "text/plain");
                });

                string result = await manager.UploadFileAsync(tempFile, "dest.txt");

                Assert.Equal("unknown", result);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that UploadFileAsync with a cloud path whose directory is null falls back to the root folder
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WhenDirectoryIsNull_FallsBackToRootFolder()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "upload content");
                string uploadUri = "https://www.googleapis.com/upload/drive/v3/files?upload_id=successRoot456";
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return ListResponse("rootFolderId|root|application/vnd.google-apps.folder");
                    }
                    if (callCount == 2)
                    {
                        return InitiateUploadResponse(uploadUri);
                    }
                    return FileResponse("rootUploaded2", "file", "text/plain");
                });

                string result = await manager.UploadFileAsync(tempFile, string.Empty);

                Assert.Equal("unknown", result);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that UploadFileAsync on the success path creates the parent folder when missing
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_SuccessPath_CreatesParentFolderWhenMissing()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "upload content");
                string uploadUri = "https://www.googleapis.com/upload/drive/v3/files?upload_id=successFolder456";
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return ListResponse();
                    }
                    if (callCount == 2)
                    {
                        return JsonResponse("{\"id\":\"createdFolder123\",\"name\":\"docs\",\"mimeType\":\"application/vnd.google-apps.folder\"}");
                    }
                    if (callCount == 3)
                    {
                        return InitiateUploadResponse(uploadUri);
                    }
                    return FileResponse("uploadedFolder", "file.txt", "text/plain");
                });

                string result = await manager.UploadFileAsync(tempFile, "docs/file.txt");

                Assert.Equal("unknown", result);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that UploadFileAsync on the success path uses an existing parent folder
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_SuccessPath_UsesExistingParentFolder()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "upload content");
                string uploadUri = "https://www.googleapis.com/upload/drive/v3/files?upload_id=successExisting789";
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockHttpService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return ListResponse("existing123|docs|application/vnd.google-apps.folder");
                    }
                    if (callCount == 2)
                    {
                        return InitiateUploadResponse(uploadUri);
                    }
                    return FileResponse("uploadedExisting", "file.txt", "text/plain");
                });

                string result = await manager.UploadFileAsync(tempFile, "docs/file.txt");

                Assert.Equal("unknown", result);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }
    }
}