// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DropBoxCloudManagerExecutionTests.cs
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
using Dropbox.Api;
using Dropbox.Api.Files;
using Xunit;

namespace Alis.Extension.Cloud.DropBox.Test
{
    /// <summary>
    ///     Executes the success paths of <see cref="DropBoxCloudManager" /> against a stub
    ///     <see cref="HttpClient" /> injected through the Dropbox SDK config so that no network
    ///     access is performed.
    /// </summary>
    public class DropBoxCloudManagerExecutionTests : IDisposable
    {
        /// <summary>
        ///     The upload temp file path
        /// </summary>
        private readonly string _uploadFilePath;

        /// <summary>
        ///     The download temp file path
        /// </summary>
        private readonly string _downloadFilePath;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DropBoxCloudManagerExecutionTests"/> class
        /// </summary>
        public DropBoxCloudManagerExecutionTests()
        {
            _uploadFilePath = Path.Combine(Path.GetTempPath(), "alis_upload_" + Guid.NewGuid().ToString("N") + ".txt");
            File.WriteAllText(_uploadFilePath, "alis dropbox upload payload");
            _downloadFilePath = Path.Combine(Path.GetTempPath(), "alis_download_" + Guid.NewGuid().ToString("N") + ".txt");
        }

        /// <summary>
        ///     Deletes the temporary files
        /// </summary>
        public void Dispose()
        {
            if (File.Exists(_uploadFilePath))
            {
                File.Delete(_uploadFilePath);
            }

            if (File.Exists(_downloadFilePath))
            {
                File.Delete(_downloadFilePath);
            }
        }

        /// <summary>
        ///     Tests that upload file async with an existing file returns the file metadata.
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithExistingFile_ReturnsMetadata()
        {
            DropBoxCloudManager manager = CreateManager(FileMetadataJson);

            FileMetadata result = await manager.UploadFileAsync(_uploadFilePath, "folder/uploaded.txt");

            Assert.Equal("uploaded.txt", result.Name);
        }

        /// <summary>
        ///     Tests that upload file async normalizes a dropbox path without a leading slash.
        /// </summary>
        [Fact]
        public async Task UploadFileAsync_WithoutLeadingSlash_NormalizesPath()
        {
            DropBoxCloudManager manager = CreateManager(FileMetadataJson);

            FileMetadata result = await manager.UploadFileAsync(_uploadFilePath, "folder/uploaded.txt");

            Assert.Equal("uploaded.txt", result.Name);
        }

        /// <summary>
        ///     Tests that download file async writes the file content.
        /// </summary>
        [Fact]
        public async Task DownloadFileAsync_WritesFileContent()
        {
            DropBoxCloudManager manager = CreateManager(FileMetadataJson);

            await manager.DownloadFileAsync("/folder/downloaded.txt", _downloadFilePath);

            Assert.True(File.Exists(_downloadFilePath));
            Assert.Equal("alis dropbox download payload", File.ReadAllText(_downloadFilePath));
        }

        /// <summary>
        ///     Tests that list files async returns the folder entries.
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_ReturnsEntries()
        {
            DropBoxCloudManager manager = CreateManager(ListFolderJson);

            IList<Metadata> result = await manager.ListFilesAsync("/folder", true);

            Assert.Equal(1, result.Count);
        }

        /// <summary>
        ///     Tests that list files async with a path without a leading slash normalizes the path.
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WithoutLeadingSlash_NormalizesPath()
        {
            DropBoxCloudManager manager = CreateManager(ListFolderJson);

            IList<Metadata> result = await manager.ListFilesAsync("folder", true);

            Assert.Equal(1, result.Count);
        }

        /// <summary>
        ///     Tests that list files async rethrows when the sdk call fails.
        /// </summary>
        [Fact]
        public async Task ListFilesAsync_WhenSdkCallFails_Rethrows()
        {
            DropBoxCloudManager manager = CreateManager(ListFolderJson, fail: true);

            await Assert.ThrowsAnyAsync<Exception>(() => manager.ListFilesAsync("/folder", true));
        }

        /// <summary>
        ///     Tests that delete async completes.
        /// </summary>
        [Fact]
        public async Task DeleteAsync_Completes()
        {
            DropBoxCloudManager manager = CreateManager(FileMetadataJson);

            await manager.DeleteAsync("/folder/deleted.txt");
        }

        /// <summary>
        ///     Tests that delete async normalizes a dropbox path without a leading slash.
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WithoutLeadingSlash_NormalizesPath()
        {
            DropBoxCloudManager manager = CreateManager(FileMetadataJson);

            await manager.DeleteAsync("folder/deleted.txt");
        }

        /// <summary>
        ///     Tests that delete async rethrows when the sdk call fails.
        /// </summary>
        [Fact]
        public async Task DeleteAsync_WhenSdkCallFails_Rethrows()
        {
            DropBoxCloudManager manager = CreateManager(FileMetadataJson, fail: true);

            await Assert.ThrowsAnyAsync<Exception>(() => manager.DeleteAsync("/folder/deleted.txt"));
        }

        /// <summary>
        ///     Tests that get metadata async returns the metadata.
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_ReturnsMetadata()
        {
            DropBoxCloudManager manager = CreateManager(TaggedFileMetadataJson);

            Metadata result = await manager.GetMetadataAsync("/folder/metadata.txt");

            Assert.Equal("uploaded.txt", result.Name);
        }

        /// <summary>
        ///     Tests that get metadata async with a path without a leading slash normalizes the path.
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WithoutLeadingSlash_NormalizesPath()
        {
            DropBoxCloudManager manager = CreateManager(TaggedFileMetadataJson);

            Metadata result = await manager.GetMetadataAsync("folder/metadata.txt");

            Assert.Equal("uploaded.txt", result.Name);
        }

        /// <summary>
        ///     Tests that get metadata async rethrows when the sdk call fails.
        /// </summary>
        [Fact]
        public async Task GetMetadataAsync_WhenSdkCallFails_Rethrows()
        {
            DropBoxCloudManager manager = CreateManager(TaggedFileMetadataJson, fail: true);

            await Assert.ThrowsAnyAsync<Exception>(() => manager.GetMetadataAsync("/folder/metadata.txt"));
        }

        /// <summary>
        ///     The file metadata json
        /// </summary>
        private const string FileMetadataJson =
            "{ \"name\": \"uploaded.txt\", \"path_lower\": \"/folder/uploaded.txt\", \"path_display\": \"/folder/uploaded.txt\", " +
            "\"id\": \"id:a4ayc_80_OEAAAAAAAAAXa\", \"client_modified\": \"2012-12-05T17:28:11Z\", " +
            "\"server_modified\": \"2012-12-05T17:28:11Z\", \"rev\": \"a1c10ce0dd78\", \"size\": 7212, " +
            "\"is_downloadable\": true, \"content_hash\": \"e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855\" }";

        /// <summary>
        ///     The tagged file metadata json
        /// </summary>
        private const string TaggedFileMetadataJson =
            "{ \".tag\": \"file\", \"name\": \"uploaded.txt\", \"path_lower\": \"/folder/uploaded.txt\", \"path_display\": \"/folder/uploaded.txt\", " +
            "\"id\": \"id:a4ayc_80_OEAAAAAAAAAXa\", \"client_modified\": \"2012-12-05T17:28:11Z\", " +
            "\"server_modified\": \"2012-12-05T17:28:11Z\", \"rev\": \"a1c10ce0dd78\", \"size\": 7212, " +
            "\"is_downloadable\": true, \"content_hash\": \"e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855\" }";

        /// <summary>
        ///     The list folder json
        /// </summary>
        private const string ListFolderJson =
            "{ \"entries\": [ " + TaggedFileMetadataJson + " ], \"cursor\": \"AAH9xXxW8PJNHVXmUc0SQNJSKOF7fM0Wk0M0HwC4Tgn0oGCtXPQ\", \"has_more\": false }";

        /// <summary>
        ///     Creates a drop box cloud manager with a stub http client
        /// </summary>
        /// <param name="json">The json</param>
        /// <param name="fail">Whether the handler should fail</param>
        /// <returns>The manager</returns>
        private static DropBoxCloudManager CreateManager(string json, bool fail = false)
        {
            HttpClient httpClient = new HttpClient(new StubHttpMessageHandler(json, fail));
            DropboxClient client = new DropboxClient("sl.B2iBBnsCXqwAAAAAAAAAAAAA", new DropboxClientConfig { HttpClient = httpClient, MaxRetriesOnError = 0 });
            return new DropBoxCloudManager(new Context(), client);
        }

        /// <summary>
        ///     The stub http message handler class
        /// </summary>
        /// <seealso cref="HttpMessageHandler"/>
        private sealed class StubHttpMessageHandler : HttpMessageHandler
        {
            /// <summary>
            ///     The json
            /// </summary>
            private readonly string _json;

            /// <summary>
            ///     Indicates whether the handler should fail
            /// </summary>
            private readonly bool _fail;

            /// <summary>
            ///     Initializes a new instance of the <see cref="StubHttpMessageHandler"/> class
            /// </summary>
            /// <param name="json">The json</param>
            /// <param name="fail">Whether the handler should fail</param>
            public StubHttpMessageHandler(string json, bool fail)
            {
                _json = json;
                _fail = fail;
            }

            /// <summary>
            ///     Sends the async request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">The cancellation token</param>
            /// <returns>The http response message</returns>
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                HttpResponseMessage response = _fail ? new HttpResponseMessage(HttpStatusCode.InternalServerError) : new HttpResponseMessage(HttpStatusCode.OK);
                if (!_fail && request.RequestUri.AbsolutePath.EndsWith("/files/download"))
                {
                    response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("alis dropbox download payload"));
                    response.Content.Headers.TryAddWithoutValidation("Content-Type", "application/octet-stream");
                    response.Headers.TryAddWithoutValidation("Dropbox-API-Result", _json);
                }
                else if (!_fail)
                {
                    response.Content = new StringContent(_json, Encoding.UTF8, "application/json");
                }

                return Task.FromResult(response);
            }
        }
    }
}
