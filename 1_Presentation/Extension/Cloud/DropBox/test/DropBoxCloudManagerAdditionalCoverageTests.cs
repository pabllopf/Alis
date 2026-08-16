// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DropBoxCloudManagerAdditionalCoverageTests.cs
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
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Dropbox.Api.Files;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    ///     The drop box cloud manager additional coverage tests class
    /// </summary>
    public class DropBoxCloudManagerAdditionalCoverageTests
    {
        /// <summary>
        ///     The file metadata json
        /// </summary>
        private const string FileMetadataJson =
            "{ \".tag\": \"file\", \"name\": \"uploaded.txt\", \"path_lower\": \"/folder/uploaded.txt\", \"path_display\": \"/folder/uploaded.txt\", " +
            "\"id\": \"id:a4ayc_80_OEAAAAAAAAAXa\", \"client_modified\": \"2012-12-05T17:28:11Z\", " +
            "\"server_modified\": \"2012-12-05T17:28:11Z\", \"rev\": \"a1c10ce0dd78\", \"size\": 7212, " +
            "\"is_downloadable\": true, \"content_hash\": \"e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855\" }";

        /// <summary>
        ///     The list folder json
        /// </summary>
        private const string ListFolderJson =
            "{ \"entries\": [ " + FileMetadataJson + " ], \"cursor\": \"AAH9xXxW8PJNHVXmUc0SQNJSKOF7fM0Wk0M0HwC4Tgn0oGCtXPQ\", \"has_more\": false }";

        /// <summary>
        ///     Tests that upload file async with an existing file and a successful response returns the file metadata
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithSuccessfulResponse_ReturnsFileMetadata()
        {
            string localPath = Path.Combine(Path.GetTempPath(), "alis_additional_upload.txt");
            File.WriteAllText(localPath, "alis dropbox upload payload");
            using DropBoxCloudManager manager = CreateManager(FileMetadataJson, null);

            try
            {
                FileMetadata result = await manager.UploadFileAsync(localPath, "/folder/uploaded.txt");

                Assert.Equal("uploaded.txt", result.Name);
            }
            finally
            {
                if (File.Exists(localPath))
                {
                    File.Delete(localPath);
                }
            }
        }

        /// <summary>
        ///     Tests that upload file async normalizes a dropbox path without a leading slash
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithoutLeadingSlash_NormalizesDropboxPath()
        {
            string localPath = Path.Combine(Path.GetTempPath(), "alis_additional_upload_normalized.txt");
            File.WriteAllText(localPath, "alis dropbox upload payload");
            using DropBoxCloudManager manager = CreateManager(FileMetadataJson, null);

            try
            {
                FileMetadata result = await manager.UploadFileAsync(localPath, "folder/uploaded.txt");

                Assert.Equal("uploaded.txt", result.Name);
            }
            finally
            {
                if (File.Exists(localPath))
                {
                    File.Delete(localPath);
                }
            }
        }

        /// <summary>
        ///     Tests that download file async with a successful response writes the file content
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithSuccessfulResponse_WritesFileContent()
        {
            string localPath = Path.Combine(Path.GetTempPath(), "alis_additional_download.txt");
            using DropBoxCloudManager manager = CreateManager(FileMetadataJson, Encoding.UTF8.GetBytes("alis dropbox download payload"));

            try
            {
                await manager.DownloadFileAsync("/folder/downloaded.txt", localPath);

                Assert.True(File.Exists(localPath));
                Assert.Equal("alis dropbox download payload", File.ReadAllText(localPath));
            }
            finally
            {
                if (File.Exists(localPath))
                {
                    File.Delete(localPath);
                }
            }
        }

        /// <summary>
        ///     Tests that download file async with a successful response and a non existent directory creates the directory
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithSuccessfulResponseAndNonExistentDirectory_CreatesDirectory()
        {
            string dirPath = Path.Combine(Path.GetTempPath(), "alis_additional_download_dir");
            string localPath = Path.Combine(dirPath, "downloaded.txt");
            using DropBoxCloudManager manager = CreateManager(FileMetadataJson, Encoding.UTF8.GetBytes("alis dropbox download payload"));

            try
            {
                await manager.DownloadFileAsync("/folder/downloaded.txt", localPath);

                Assert.True(Directory.Exists(dirPath));
                Assert.True(File.Exists(localPath));
            }
            finally
            {
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
            }
        }

        /// <summary>
        ///     Tests that download file async with a successful response and a bare file name writes the file content
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WithSuccessfulResponseAndBareFileName_WritesFileContent()
        {
            string localPath = "alis_additional_bare_download.txt";
            using DropBoxCloudManager manager = CreateManager(FileMetadataJson, Encoding.UTF8.GetBytes("alis dropbox download payload"));

            try
            {
                await manager.DownloadFileAsync("/folder/downloaded.txt", localPath);

                Assert.True(File.Exists(localPath));
                Assert.Equal("alis dropbox download payload", File.ReadAllText(localPath));
            }
            finally
            {
                if (File.Exists(localPath))
                {
                    File.Delete(localPath);
                }
            }
        }

        /// <summary>
        ///     Tests that list files async with a successful response returns the folder entries
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithSuccessfulResponse_ReturnsEntries()
        {
            using DropBoxCloudManager manager = CreateManager(ListFolderJson, null);

            System.Collections.Generic.IList<Metadata> result = await manager.ListFilesAsync("/folder", true);

            Assert.Equal(1, result.Count);
            Assert.Equal("uploaded.txt", result[0].Name);
        }

        /// <summary>
        ///     Tests that list files async with an empty folder path defaults to the root
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithEmptyPathAndSuccessfulResponse_DefaultsToRoot()
        {
            using DropBoxCloudManager manager = CreateManager(ListFolderJson, null);

            System.Collections.Generic.IList<Metadata> result = await manager.ListFilesAsync(string.Empty);

            Assert.Equal(1, result.Count);
        }

        /// <summary>
        ///     Tests that delete async with a successful response completes
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithSuccessfulResponse_Completes()
        {
            using DropBoxCloudManager manager = CreateManager("{}", null);

            await manager.DeleteAsync("/folder/deleted.txt");
        }

        /// <summary>
        ///     Tests that delete async with a path without a leading slash normalizes the path
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithoutLeadingSlash_NormalizesDropboxPath()
        {
            using DropBoxCloudManager manager = CreateManager("{}", null);

            await manager.DeleteAsync("folder/deleted.txt");
        }

        /// <summary>
        ///     Tests that get metadata async with a successful response returns the metadata
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithSuccessfulResponse_ReturnsMetadata()
        {
            using DropBoxCloudManager manager = CreateManager(FileMetadataJson, null);

            Metadata result = await manager.GetMetadataAsync("/folder/metadata.txt");

            Assert.Equal("uploaded.txt", result.Name);
        }

        /// <summary>
        ///     Tests that get metadata async with a path without a leading slash normalizes the path
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithoutLeadingSlash_NormalizesDropboxPath()
        {
            using DropBoxCloudManager manager = CreateManager(FileMetadataJson, null);

            Metadata result = await manager.GetMetadataAsync("folder/metadata.txt");

            Assert.Equal("uploaded.txt", result.Name);
        }

        /// <summary>
        ///     Tests that disposing with false and a set client does not dispose the client
        /// </summary>
        [Fact]
        public void Dispose_FalseWithSetClient_DoesNotDisposeClient()
        {
            DropboxClient client = new DropboxClient("dummy-token", new DropboxClientConfig { HttpClient = new HttpClient(new StubMessageHandler(FileMetadataJson, null)) });
            using ExposedDisposeManager exposed = new ExposedDisposeManager(new Context(), client);

            Exception exception = Record.Exception(() => exposed.DisposeWithDisposingFlag(false));

            Assert.Null(exception);
            Assert.True(exposed.IsInitialized);
        }

        /// <summary>
        ///     Tests that disposing with false and no client does not throw
        /// </summary>
        [Fact]
        public void Dispose_FalseWithoutClient_DoesNotThrow()
        {
            using ExposedDisposeManager exposed = new ExposedDisposeManager(new Context());

            Exception exception = Record.Exception(() => exposed.DisposeWithDisposingFlag(false));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Creates a drop box cloud manager with a stub http message handler
        /// </summary>
        /// <param name="json">The json</param>
        /// <param name="downloadBody">The download body</param>
        /// <returns>The manager</returns>
        private static DropBoxCloudManager CreateManager(string json, byte[] downloadBody)
        {
            StubMessageHandler handler = new StubMessageHandler(json, downloadBody);
            HttpClient httpClient = new HttpClient(handler);
            DropboxClientConfig config = new DropboxClientConfig { HttpClient = httpClient };
            DropboxClient client = new DropboxClient("dummy-token", config);
            return new DropBoxCloudManager(new Context(), client);
        }

        /// <summary>
        ///     The exposed dispose manager class
        /// </summary>
        /// <seealso cref="DropBoxCloudManager" />
        private sealed class ExposedDisposeManager : DropBoxCloudManager
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="ExposedDisposeManager"/> class
            /// </summary>
            /// <param name="context">The context</param>
            public ExposedDisposeManager(Context context) : base(context)
            {
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="ExposedDisposeManager"/> class with a pre-configured client
            /// </summary>
            /// <param name="context">The context</param>
            /// <param name="dropboxClient">The dropbox client</param>
            public ExposedDisposeManager(Context context, DropboxClient dropboxClient) : base(context, dropboxClient)
            {
            }

            /// <summary>
            ///     Disposes with the given disposing flag
            /// </summary>
            /// <param name="disposing">The disposing flag</param>
            public void DisposeWithDisposingFlag(bool disposing) => Dispose(disposing);
        }

        /// <summary>
        ///     The stub message handler class
        /// </summary>
        /// <seealso cref="HttpMessageHandler" />
        private sealed class StubMessageHandler : HttpMessageHandler
        {
            /// <summary>
            ///     The json
            /// </summary>
            private readonly string _json;

            /// <summary>
            ///     The download body
            /// </summary>
            private readonly byte[] _downloadBody;

            /// <summary>
            ///     Initializes a new instance of the <see cref="StubMessageHandler"/> class
            /// </summary>
            /// <param name="json">The json</param>
            /// <param name="downloadBody">The download body</param>
            public StubMessageHandler(string json, byte[] downloadBody)
            {
                _json = json;
                _downloadBody = downloadBody;
            }

            /// <summary>
            ///     Sends the async request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>The http response message</returns>
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                if (request.RequestUri.AbsolutePath.EndsWith("/files/download"))
                {
                    response.Content = new ByteArrayContent(_downloadBody ?? new byte[0]);
                    response.Content.Headers.TryAddWithoutValidation("Content-Type", "application/octet-stream");
                    response.Headers.TryAddWithoutValidation("Dropbox-API-Result", _json);
                }
                else
                {
                    response.Content = new StringContent(_json, Encoding.UTF8, "application/json");
                }

                return Task.FromResult(response);
            }
        }
    }
}
