// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerCoverageTest.cs
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
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;
using Alis.Extension.Updater.Test.Attributes;
using Moq;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    /// The update manager coverage test class
    /// </summary>
    public class UpdateManagerCoverageTest
    {
        /// <summary>
        /// Tests that select asset skips assets with null name
        /// </summary>
        [Fact]
        public void SelectAsset_SkipsAssetsWithNullName()
        {
            Dictionary<string, object> release = new Dictionary<string, object>
            {
                {
                    "assets", new object[]
                    {
                        Asset(null, "https://example.invalid/null1"),
                        Asset("app-win-x64.zip", "https://example.invalid/valid"),
                        Asset(null, "https://example.invalid/null2")
                    }
                }
            };

            Dictionary<string, object> selected = UpdateManager.GetSelectedAsset(release, "win", "x64");

            Assert.NotNull(selected);
            Assert.Equal("app-win-x64.zip", selected["name"]);
        }

        /// <summary>
        /// Tests that get latest release async throws when version does not exist
        /// </summary>
        [Fact]
        public void GetLatestReleaseAsync_Throws_WhenVersionDoesNotExist()
        {
            using LoopbackHttpServer server = LoopbackHttpServer.Start();
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(server.Uri);
            IFileService fileService = Mock.Of<IFileService>();
            UpdateManager sut = new UpdateManager(api.Object, "nonexistent-v9.9.9", fileService, Path.GetTempPath());
            sut.ContinueDelayMilliseconds = 0;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.GetLatestReleaseAsync().GetAwaiter().GetResult());
            Assert.Contains("latest version is already installed", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that get latest release async returns release for latest version
        /// </summary>
        [Fact]
        public void GetLatestReleaseAsync_ReturnsRelease_ForLatestVersion()
        {
            using LoopbackHttpServer server = LoopbackHttpServer.Start();
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(server.Uri);
            IFileService fileService = Mock.Of<IFileService>();
            UpdateManager sut = new UpdateManager(api.Object, "latest", fileService, Path.GetTempPath());
            sut.ContinueDelayMilliseconds = 0;

            Dictionary<string, object> result = sut.GetLatestReleaseAsync().GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal("v0.7.5", result["tag_name"]);
        }

        /// <summary>
        /// Tests that download file async downloads file
        /// </summary>
        [Fact]
        public void DownloadFileAsync_DownloadsFile()
        {
            using LoopbackHttpServer server = LoopbackHttpServer.Start();
            string expectedContent = "test-package-binary-" + Guid.NewGuid().ToString("N");
            string fileName = "downloaded-test-" + Guid.NewGuid().ToString("N") + ".zip";
            server.SetResponse("/" + fileName, expectedContent);

            UpdateManager sut = CreateManagerFast();
            sut.ContinueDelayMilliseconds = 0;

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            try
            {
                string result = sut.DownloadFileAsync(server.Uri + fileName).GetAwaiter().GetResult();

                Assert.NotNull(result);
                Assert.Equal(filePath, result);
                Assert.True(File.Exists(result));
                string content = File.ReadAllText(result);
                Assert.Equal(expectedContent, content);
            }
            finally
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        /// <summary>
        /// Tests that extract zip creates directory entry
        /// </summary>
        [Fact]
        public void ExtractZip_CreatesDirectoryEntry()
        {
            using TempFolder temp = TempFolder.Create();
            string targetFolder = Path.Combine(temp.Path, "program");
            string zipPath = Path.Combine(temp.Path, "dir-entry.zip");

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                zip.CreateEntry("subdir/");
            }

            UpdateManager sut = CreateManagerFast(programFolder: targetFolder);
            sut.ExtractZip(zipPath);

            Assert.True(Directory.Exists(Path.Combine(targetFolder, "subdir")));
        }

        /// <summary>
        /// Tests that extract zip throws when path traversal detected
        /// </summary>
        [Fact]
        public void ExtractZip_Throws_WhenPathTraversalDetected()
        {
            using TempFolder temp = TempFolder.Create();
            string targetFolder = Path.Combine(temp.Path, "program");
            string zipPath = Path.Combine(temp.Path, "traversal.zip");

            Directory.CreateDirectory(targetFolder);

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry("../malicious.exe");
                using StreamWriter writer = new StreamWriter(entry.Open());
                writer.Write("evil");
            }

            UpdateManager sut = CreateManagerFast(programFolder: targetFolder);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.ExtractZip(zipPath));
            Assert.Contains("path traversal", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that extract zip throws when compression ratio exceeds threshold
        /// </summary>
        [Fact]
        public void ExtractZip_Throws_WhenCompressionRatioExceedsThreshold()
        {
            using TempFolder temp = TempFolder.Create();
            string targetFolder = Path.Combine(temp.Path, "program");
            string zipPath = Path.Combine(temp.Path, "high-ratio.zip");

            using (FileStream fs = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry("compressible.dat");
                using Stream entryStream = entry.Open();
                byte[] data = new byte[100 * 1024];
                entryStream.Write(data, 0, data.Length);
            }

            UpdateManager sut = CreateManagerFast(programFolder: targetFolder);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.ExtractZip(zipPath));
            Assert.Contains("compression ratio", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the platform on mac os returns osx
        /// </summary>
        [MacOsOnly]
        public void GetPlatform_OnMacOs_ReturnsOsx()
        {
            MethodInfo method = typeof(UpdateManager).GetMethod("GetPlatform", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.NotNull(method);

            string result = (string)method.Invoke(null, null);

            Assert.Equal("osx", result);
        }

        /// <summary>
        /// Tests that start throws when release not found
        /// </summary>
        [Fact]
        public void Start_Throws_WhenReleaseNotFound()
        {
            using LoopbackHttpServer server = LoopbackHttpServer.Start();
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(server.Uri);
            IFileService fileService = Mock.Of<IFileService>();
            UpdateManager sut = new UpdateManager(api.Object, "nonexistent", fileService, Path.GetTempPath());
            sut.ContinueDelayMilliseconds = 0;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.Start(CancellationToken.None).GetAwaiter().GetResult());
            Assert.Contains("Error updating program", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Creates the manager fast using the specified version to install
        /// </summary>
        /// <param name="versionToInstall">The version to install</param>
        /// <param name="programFolder">The program folder</param>
        /// <returns>The manager</returns>
        private static UpdateManager CreateManagerFast(string versionToInstall = "latest", string programFolder = null)
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("http://127.0.0.1:55000/"));
            api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync(new Dictionary<string, object>());

            IFileService fileService = Mock.Of<IFileService>();
            UpdateManager manager = new UpdateManager(
                api.Object,
                versionToInstall,
                fileService,
                programFolder ?? Path.Combine(Path.GetTempPath(), "alis-updater", Guid.NewGuid().ToString("N")));
            manager.ContinueDelayMilliseconds = 0;
            return manager;
        }

        /// <summary>
        /// Assets the name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="url">The url</param>
        /// <returns>A dictionary of string and object</returns>
        private static Dictionary<string, object> Asset(string name, string url) => new Dictionary<string, object>
        {
            {"name", name},
            {"browser_download_url", url}
        };

        /// <summary>
        /// The loopback http server class
        /// </summary>
        /// <seealso cref="IDisposable"/>
        private sealed class LoopbackHttpServer : IDisposable
        {
            /// <summary>
            /// The listener
            /// </summary>
            private readonly TcpListener _listener;
            /// <summary>
            /// The cancellation
            /// </summary>
            private readonly CancellationTokenSource _cancellation;
            /// <summary>
            /// The worker
            /// </summary>
            private readonly Task _worker;
            /// <summary>
            /// The response content
            /// </summary>
            private string _responseContent;
            /// <summary>
            /// The expected path
            /// </summary>
            private string _expectedPath;

            /// <summary>
            /// Initializes a new instance of the <see cref="LoopbackHttpServer"/> class
            /// </summary>
            /// <param name="listener">The listener</param>
            /// <param name="uri">The uri</param>
            private LoopbackHttpServer(TcpListener listener, Uri uri)
            {
                _listener = listener;
                Uri = uri;
                _cancellation = new CancellationTokenSource();
                _responseContent = "ok";
                _expectedPath = "/";
                _worker = Task.Run(() => WorkerLoop(_cancellation.Token));
            }

            /// <summary>
            /// Gets the value of the uri
            /// </summary>
            public Uri Uri { get; }

            /// <summary>
            /// Sets the response using the specified path
            /// </summary>
            /// <param name="path">The path</param>
            /// <param name="content">The content</param>
            public void SetResponse(string path, string content)
            {
                _expectedPath = path;
                _responseContent = content;
            }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose()
            {
                _cancellation.Cancel();
                _listener.Stop();

                try
                {
                    _worker.Wait(TimeSpan.FromSeconds(5));
                }
                catch
                {
                }

                _cancellation.Dispose();
            }

            /// <summary>
            /// Starts
            /// </summary>
            /// <returns>The loopback http server</returns>
            public static LoopbackHttpServer Start()
            {
                TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
                listener.Start();
                int port = ((IPEndPoint)listener.LocalEndpoint).Port;
                Uri uri = new Uri($"http://127.0.0.1:{port}/");
                return new LoopbackHttpServer(listener, uri);
            }

            /// <summary>
            /// Workers the loop using the specified token
            /// </summary>
            /// <param name="token">The token</param>
            private void WorkerLoop(CancellationToken token)
            {
                while (!token.IsCancellationRequested)
                {
                    TcpClient client;

                    try
                    {
                        client = _listener.AcceptTcpClient();
                    }
                    catch
                    {
                        break;
                    }

                    using (client)
                    using (NetworkStream stream = client.GetStream())
                    {
                        client.ReceiveTimeout = 5000;
                        byte[] buffer = new byte[4096];
                        stream.Read(buffer, 0, buffer.Length);
                        string body = _responseContent;
                        string response = "HTTP/1.1 200 OK\r\n" +
                            "Content-Type: application/octet-stream\r\n" +
                            "Content-Length: " + body.Length + "\r\n" +
                            "Connection: close\r\n" +
                            "\r\n" +
                            body;

                        byte[] responseBytes = Encoding.ASCII.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                    }
                }
            }
        }

        /// <summary>
        /// The temp folder class
        /// </summary>
        /// <seealso cref="IDisposable"/>
        internal sealed class TempFolder : IDisposable
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TempFolder"/> class
            /// </summary>
            /// <param name="path">The path</param>
            private TempFolder(string path) => Path = path;

            /// <summary>
            /// Gets the value of the path
            /// </summary>
            public string Path { get; }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose()
            {
                if (Directory.Exists(Path))
                {
                    Directory.Delete(Path, true);
                }
            }

            /// <summary>
            /// Creates
            /// </summary>
            /// <returns>The temp folder</returns>
            public static TempFolder Create()
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-cov", Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(path);
                return new TempFolder(path);
            }
        }
    }
}
