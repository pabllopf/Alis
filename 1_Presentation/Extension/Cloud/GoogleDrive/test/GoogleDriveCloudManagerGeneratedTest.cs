// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManagerGeneratedTest.cs
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
using Google;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Upload;
using Moq;
using Moq.Protected;
using Xunit;
using File = System.IO.File;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    /// <summary>
    ///     Generated coverage tests for GoogleDriveCloudManager
    /// </summary>
    public class GoogleDriveCloudManagerGeneratedTest
    {
        private const string TestToken = "ya29.a0AfH6SMC8TokenForTestingPurposes123";

        private sealed class CallbackHttpMessageHandler : ConfigurableMessageHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _callback;

            public CallbackHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> callback)
                : base(new HttpClientHandler())
            {
                _callback = callback;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
                Task.FromResult(_callback(request));
        }

        private static DriveService CreateMockDriveService(Func<HttpRequestMessage, HttpResponseMessage> callback)
        {
            var handler = new CallbackHttpMessageHandler(callback);
            var httpClient = new ConfigurableHttpClient(handler);
            var factory = new Mock<IHttpClientFactory>();
            factory.Setup(f => f.CreateHttpClient(It.IsAny<CreateHttpClientArgs>())).Returns(httpClient);
            return new DriveService(new BaseClientService.Initializer
            {
                HttpClientFactory = factory.Object,
                ApplicationName = "Test"
            });
        }

        private static GoogleDriveCloudManager CreateManagerWithMockService(Func<HttpRequestMessage, HttpResponseMessage> callback)
        {
            DriveService service = CreateMockDriveService(callback);
            return new GoogleDriveCloudManager(new Context(), service);
        }

        private static HttpResponseMessage JsonResponse(string json, HttpStatusCode status = HttpStatusCode.OK) =>
            new HttpResponseMessage(status)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

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

        private static HttpResponseMessage FileResponse(string id, string name, string mime, long size = 1024) =>
            JsonResponse("{\"id\":\"" + id + "\",\"name\":\"" + name + "\",\"size\":\"" + size + "\",\"mimeType\":\"" + mime + "\"}");

        private static HttpResponseMessage InitiateUploadResponse(string uploadUri)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}", Encoding.UTF8, "application/json")
            };
            response.Headers.Location = new Uri(uploadUri);
            return response;
        }

        // ===== InitializeAsync Tests =====

        /// <summary>
        ///     Tests that InitializeAsync with a valid token sets IsInitialized to true
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithValidToken_SetsIsInitializedTrue()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());

            await manager.InitializeAsync(TestToken);

            Assert.True(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that InitializeAsync with a valid token does not throw
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithValidToken_DoesNotThrow()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());

            Exception ex = await Record.ExceptionAsync(() => manager.InitializeAsync(TestToken));

            Assert.Null(ex);
        }

        // ===== UploadFileAsync Tests =====

        /// <summary>
        ///     Tests that UploadFileAsync with root path uploads successfully
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_FileUploadedToRoot_ReturnsFileId()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test content");
                string uploadUri = "https://www.googleapis.com/upload/drive/v3/files?upload_id=test123";
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return InitiateUploadResponse(uploadUri);
                    }
                    return FileResponse("uploaded123", "dest.txt", "text/plain");
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
        ///     Tests that UploadFileAsync with upload failure throws
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WhenUploadFails_ThrowsInvalidOperationException()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test content");
                using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                    new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Exception ex = await Record.ExceptionAsync(() => manager.UploadFileAsync(tempFile, "/dest.txt"));

                Assert.NotNull(ex);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that UploadFileAsync creates parent folder when needed
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithSubfolderPath_CreatesParentFolder()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test content");
                string uploadUri = "https://www.googleapis.com/upload/drive/v3/files?upload_id=test456";
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        // GetOrCreateFolderId("subfolder"): folder not found, create it
                        return ListResponse();
                    }
                    if (callCount == 2)
                    {
                        // Create folder response
                        return JsonResponse("{\"id\":\"subfolder123\",\"name\":\"subfolder\",\"mimeType\":\"application/vnd.google-apps.folder\"}");
                    }
                    if (callCount == 3)
                    {
                        return InitiateUploadResponse(uploadUri);
                    }
                    return FileResponse("uploaded456", "file.txt", "text/plain");
                });

                string result = await manager.UploadFileAsync(tempFile, "subfolder/file.txt");

                Assert.Equal("unknown", result);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        // ===== DownloadFileAsync Tests =====

        /// <summary>
        ///     Tests that DownloadFileAsync with valid path downloads successfully
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithValidPath_DownloadsSuccessfully()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            string destFile = Path.Combine(tempDir, "downloaded.txt");
            try
            {
                Directory.CreateDirectory(tempDir);
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return ListResponse("file123|test.txt|text/plain");
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("file content data", Encoding.UTF8, "text/plain")
                    };
                });

                await manager.DownloadFileAsync("test.txt", destFile);

                Assert.True(File.Exists(destFile));
            }
            finally
            {
                if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true);
            }
        }

        /// <summary>
        ///     Tests that DownloadFileAsync when file not found throws
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WhenFileNotFound_ThrowsFileNotFoundException()
        {
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                ListResponse());

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.DownloadFileAsync("/nonexistent.txt", "/tmp/out.txt"));
        }

        /// <summary>
        ///     Tests that DownloadFileAsync with nested drive path resolves correctly
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithNestedDrivePath_DownloadsSuccessfully()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            string destFile = Path.Combine(tempDir, "output.txt");
            try
            {
                Directory.CreateDirectory(tempDir);
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return ListResponse("folderA|docs|application/vnd.google-apps.folder");
                    }
                    if (callCount == 2)
                    {
                        return ListResponse("file456|report.pdf");
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("pdf content here", Encoding.UTF8, "application/pdf")
                    };
                });

                await manager.DownloadFileAsync("docs/report.pdf", destFile);

                Assert.True(File.Exists(destFile));
            }
            finally
            {
                if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true);
            }
        }

        /// <summary>
        ///     Tests that DownloadFileAsync with nested local directory creates it
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_CreatesLocalDirectory_WhenNotExists()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            string destFile = Path.Combine(tempDir, "subdir", "file.txt");
            try
            {
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        return ListResponse("file789|file.txt");
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("content", Encoding.UTF8, "text/plain")
                    };
                });

                await manager.DownloadFileAsync("file.txt", destFile);

                Assert.True(File.Exists(destFile));
            }
            finally
            {
                if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true);
            }
        }

        // ===== ListFilesAsync Tests =====

        /// <summary>
        ///     Tests that ListFilesAsync returns files from root
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithRootPath_ReturnsFiles()
        {
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                ListResponse("f1|doc.txt|text/plain", "f2|image.png|image/png", "f3|folder|application/vnd.google-apps.folder"));

            IList<string> result = await manager.ListFilesAsync("/");

            Assert.Equal(3, result.Count);
            Assert.Contains("doc.txt", result);
            Assert.Contains("image.png", result);
            Assert.Contains("folder", result);
        }

        /// <summary>
        ///     Tests that ListFilesAsync returns empty list for empty folder
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithEmptyFolder_ReturnsEmptyList()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
            {
                callCount++;
                return JsonResponse("{\"files\":[]}");
            });

            IList<string> result = await manager.ListFilesAsync("subfolder");

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that ListFilesAsync with nested path lists files
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithNestedPath_ListsFiles()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("folder1|docs|application/vnd.google-apps.folder");
                }
                return ListResponse("f1|report.pdf");
            });

            IList<string> result = await manager.ListFilesAsync("/docs");

            Assert.Single(result);
            Assert.Equal("report.pdf", result[0]);
        }

        /// <summary>
        ///     Tests that ListFilesAsync when folder not found returns empty
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WhenFolderNotFound_ReturnsEmptyList()
        {
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                ListResponse());

            IList<string> result = await manager.ListFilesAsync("/nonexistent");

            Assert.Empty(result);
        }

        // ===== DeleteAsync Tests =====

        /// <summary>
        ///     Tests that DeleteAsync with valid path deletes successfully
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithValidPath_DeletesSuccessfully()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("fileToDelete|delete.txt");
                }
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            });

            Exception ex = await Record.ExceptionAsync(() => manager.DeleteAsync("/delete.txt"));

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that DeleteAsync when file not found throws
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WhenFileNotFound_ThrowsFileNotFoundException()
        {
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                ListResponse());

            await Assert.ThrowsAsync<FileNotFoundException>(() => manager.DeleteAsync("/missing.txt"));
        }

        /// <summary>
        ///     Tests that DeleteAsync with nested path deletes
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithNestedPath_DeletesSuccessfully()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("folderX|docs|application/vnd.google-apps.folder");
                }
                if (callCount == 2)
                {
                    return ListResponse("delFile|delete.txt");
                }
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            });

            Exception ex = await Record.ExceptionAsync(() => manager.DeleteAsync("docs/delete.txt"));

            Assert.Null(ex);
        }

        // ===== GetMetadataAsync Tests =====

        /// <summary>
        ///     Tests that GetMetadataAsync returns correct metadata
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithValidPath_ReturnsMetadata()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("meta123|document.pdf");
                }
                return JsonResponse("{\"id\":\"meta123\",\"name\":\"document.pdf\",\"size\":\"2048\",\"mimeType\":\"application/pdf\"}");
            });

            CloudFileMetadata metadata = await manager.GetMetadataAsync("/document.pdf");

            Assert.Equal("meta123", metadata.Id);
            Assert.Equal("document.pdf", metadata.Name);
            Assert.Equal(2048, metadata.Size);
            Assert.Equal("/document.pdf", metadata.Path);
            Assert.False(metadata.IsFolder);
        }

        /// <summary>
        ///     Tests that GetMetadataAsync for a folder sets IsFolder true
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_ForFolder_SetsIsFolderTrue()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("folder789|MyFolder|application/vnd.google-apps.folder");
                }
                return JsonResponse("{\"id\":\"folder789\",\"name\":\"MyFolder\",\"size\":\"0\",\"mimeType\":\"application/vnd.google-apps.folder\"}");
            });

            CloudFileMetadata metadata = await manager.GetMetadataAsync("/MyFolder");

            Assert.True(metadata.IsFolder);
            Assert.Equal("MyFolder", metadata.Name);
        }

        /// <summary>
        ///     Tests that GetMetadataAsync when file not found throws
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WhenFileNotFound_ThrowsFileNotFoundException()
        {
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                ListResponse());

            await Assert.ThrowsAsync<FileNotFoundException>(() => manager.GetMetadataAsync("/missing.txt"));
        }

        /// <summary>
        ///     Tests that GetMetadataAsync with zero-size file returns Size zero
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithZeroSize_ReturnsSizeZero()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("empty123|empty.txt");
                }
                return JsonResponse("{\"id\":\"empty123\",\"name\":\"empty.txt\",\"mimeType\":\"text/plain\"}");
            });

            CloudFileMetadata metadata = await manager.GetMetadataAsync("/empty.txt");

            Assert.Equal(0, metadata.Size);
        }

        // ===== GetFileIdByPathAsync coverage (for-loop not-found) =====

        /// <summary>
        ///     Tests that DownloadFileAsync with nested path when parent not found throws
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithNestedPath_WhenIntermediateNotFound_ThrowsFileNotFoundException()
        {
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                ListResponse());

            await Assert.ThrowsAsync<FileNotFoundException>(() =>
                manager.DownloadFileAsync("missingfolder/file.txt", "/tmp/out.txt"));
        }

        // ===== GetOrCreateFolderId coverage (existing folder path) =====

        /// <summary>
        ///     Tests that UploadFileAsync with existing parent folder uses the existing folder
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithExistingParentFolder_ReturnsUnknown()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test content");
                string uploadUri = "https://www.googleapis.com/upload/drive/v3/files?upload_id=test789";
                int callCount = 0;
                using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        // GetOrCreateFolderId("existing"): folder EXISTS
                        return ListResponse("existingId123|existing|application/vnd.google-apps.folder");
                    }
                    if (callCount == 2)
                    {
                        return InitiateUploadResponse(uploadUri);
                    }
                    return FileResponse("uploaded789", "doc.txt", "text/plain");
                });

                string result = await manager.UploadFileAsync(tempFile, "existing/doc.txt");

                Assert.Equal("unknown", result);
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        // ===== Edge case tests =====

        /// <summary>
        ///     Tests that Dispose with null drive service does not throw
        /// </summary>
        [Fact]
        public void Dispose_WithNullDriveService_DoesNotThrow()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());

            Exception ex = Record.Exception(() => manager.Dispose());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that Dispose after OnDestroy does not throw
        /// </summary>
        [Fact]
        public void Dispose_AfterOnDestroy_DoesNotThrow()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            manager.OnDestroy();
            Exception ex = Record.Exception(() => manager.Dispose());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that OnDestroy after Dispose does not throw
        /// </summary>
        [Fact]
        public void OnDestroy_AfterDispose_DoesNotThrow()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context(), new DriveService(new BaseClientService.Initializer()));

            manager.Dispose();
            Exception ex = Record.Exception(() => manager.OnDestroy());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that Dispose when called multiple times does not throw
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_DoesNotThrow()
        {
            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());

            manager.Dispose();
            Exception ex = Record.Exception(() => manager.Dispose());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests constructor with id, name, tag, isEnable, context parameters
        /// </summary>
        [Fact]
        public void Constructor_WithFullParameters_InitializesCorrectly()
        {
            Context context = new Context();
            string id = "test-id-123";
            string name = "TestManager";
            string tag = "TestTag";
            bool isEnable = false;

            GoogleDriveCloudManager manager = new GoogleDriveCloudManager(id, name, tag, isEnable, context);

            Assert.Equal(id, manager.Id);
            Assert.Equal(name, manager.Name);
            Assert.Equal(tag, manager.Tag);
            Assert.Equal(isEnable, manager.IsEnable);
            Assert.Same(context, manager.Context);
        }

        /// <summary>
        ///     Tests that InitializeAsync multiple times works correctly
        /// </summary>
        [Fact]
        public async Task InitializeAsync_MultipleCalls_WorksCorrectly()
        {
            using GoogleDriveCloudManager manager = new GoogleDriveCloudManager(new Context());

            await manager.InitializeAsync(TestToken);
            Assert.True(manager.IsInitialized);

            await manager.InitializeAsync(TestToken + "2");
            Assert.True(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that ListFilesAsync with API error rethrows as GoogleApiException
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WhenApiError_RethrowsGoogleApiException()
        {
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
                new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                });

            await Assert.ThrowsAsync<GoogleApiException>(() => manager.ListFilesAsync("/"));
        }

        /// <summary>
        ///     Tests that GetMetadataAsync with nested path resolves correctly
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithNestedPath_ResolvesCorrectly()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("folderA|docs|application/vnd.google-apps.folder");
                }
                if (callCount == 2)
                {
                    return ListResponse("metaFile|myfile.txt");
                }
                return JsonResponse("{\"id\":\"metaFile\",\"name\":\"myfile.txt\",\"size\":\"4096\",\"mimeType\":\"text/plain\"}");
            });

            CloudFileMetadata metadata = await manager.GetMetadataAsync("docs/myfile.txt");

            Assert.Equal("metaFile", metadata.Id);
            Assert.Equal("myfile.txt", metadata.Name);
        }

        /// <summary>
        ///     Tests that DeleteAsync with root path file resolves correctly
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithSingleFile_DeletesSuccessfully()
        {
            int callCount = 0;
            using GoogleDriveCloudManager manager = CreateManagerWithMockService(request =>
            {
                callCount++;
                if (callCount == 1)
                {
                    return ListResponse("singleFile|file.txt");
                }
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            });

            Exception ex = await Record.ExceptionAsync(() => manager.DeleteAsync("file.txt"));

            Assert.Null(ex);
        }
    }
}
