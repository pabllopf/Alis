// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DummyTest.cs
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
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;
using Moq;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    /// The updater module test class
    /// </summary>
    public class UpdaterModuleTest
    {
        /// <summary>
        /// Tests that constructor assigns all dependencies
        /// </summary>
        [Fact]
        public void Constructor_AssignsAllDependencies()
        {
            IGitHubApiService api = Mock.Of<IGitHubApiService>();
            IFileService fileService = Mock.Of<IFileService>();
            string programFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));

            UpdateManager manager = new UpdateManager(api, "latest", fileService, programFolder);

            Assert.Same(api, manager.GitHubApiService);
            Assert.Same(fileService, manager.FileService);
            Assert.Equal("latest", manager.VersionToInstall);
            Assert.Equal(programFolder, manager.ProgramFolder);
        }

        /// <summary>
        /// Tests that on update progress changed updates state and raises event
        /// </summary>
        [Fact]
        public void OnUpdateProgressChanged_UpdatesState_AndRaisesEvent()
        {
            UpdateManager manager = CreateManager();
            int eventCalls = 0;
            float eventProgress = -1;
            string eventMessage = null;

            manager.UpdateProgressChanged += (progress, message) =>
            {
                eventCalls++;
                eventProgress = progress;
                eventMessage = message;
            };

            InvokeNonPublicVoid(manager, "OnUpdateProgressChanged", 0.33f, "processing");

            Assert.Equal(1, eventCalls);
            Assert.Equal(0.33f, eventProgress);
            Assert.Equal("processing", eventMessage);
            Assert.Equal(0.33f, manager.Progress);
            Assert.Equal("processing", manager.Message);
        }

        /// <summary>
        /// Tests that select asset returns null when no asset matches
        /// </summary>
        [Fact]
        public void SelectAsset_ReturnsNull_WhenNoAssetMatches()
        {
            UpdateManager manager = CreateManager();
            object[] assets =
            {
                Asset("pkg-linux-arm64.zip", "https://example.invalid/linux"),
                Asset("pkg-osx-x64.dmg", "https://example.invalid/osx")
            };

            Dictionary<string, object> selected = InvokeNonPublic<Dictionary<string, object>>(manager, "SelectAsset", assets, "win", "x64");

            Assert.Null(selected);
        }

        /// <summary>
        /// Tests that select asset ignores null asset name and finds match
        /// </summary>
        [Fact]
        public void SelectAsset_IgnoresNullAssetName_AndFindsMatch()
        {
            UpdateManager manager = CreateManager();
            object[] assets =
            {
                Asset(null, "https://example.invalid/a"),
                Asset("pkg-win-x64.zip", "https://example.invalid/win")
            };

            Dictionary<string, object> selected = InvokeNonPublic<Dictionary<string, object>>(manager, "SelectAsset", assets, "win", "x64");

            Assert.NotNull(selected);
            Assert.Contains("win", selected["name"].ToString());
            Assert.Contains("x64", selected["name"].ToString());
        }

        /// <summary>
        /// Tests that get platform returns expected current platform token
        /// </summary>
        [Fact]
        public void GetPlatform_ReturnsExpectedCurrentPlatformToken()
        {
            UpdateManager manager = CreateManager();
            string platform = InvokeNonPublic<string>(manager, "GetPlatform");

            Assert.Contains(platform, new[] { "win", "linux", "osx" });
        }
        
        /// <summary>
        /// Tests that extract and replace throws for invalid extension
        /// </summary>
        [Fact]
        public void ExtractAndReplace_ThrowsForInvalidExtension()
        {
            UpdateManager manager = CreateManager();
            TargetInvocationException ex = Assert.Throws<TargetInvocationException>(() =>
                InvokeNonPublicVoid(manager, "ExtractAndReplace", "archive.tar"));

            Assert.IsType<InvalidOperationException>(ex.InnerException);
            Assert.Contains("invalid extension", ex.InnerException.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that extract zip extracts safe archive
        /// </summary>
        [Fact]
        public void ExtractZip_ExtractsSafeArchive()
        {
            using TempFolder temp = TempFolder.Create();
            string targetFolder = Path.Combine(temp.Path, "program");
            string zipPath = Path.Combine(temp.Path, "safe.zip");

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry("folder/readme.txt", CompressionLevel.Fastest);
                using StreamWriter writer = new StreamWriter(entry.Open());
                writer.Write("safe-content");
            }

            UpdateManager manager = CreateManager(programFolder: targetFolder);
            InvokeNonPublicVoid(manager, "ExtractZip", zipPath);

            Assert.True(File.Exists(Path.Combine(targetFolder, "folder", "readme.txt")));
            Assert.Equal(0.7f, manager.Progress);
        }

        /// <summary>
        /// Tests that extract zip throws when too many entries
        /// </summary>
        [Fact]
        public void ExtractZip_ThrowsWhenTooManyEntries()
        {
            using TempFolder temp = TempFolder.Create();
            string zipPath = Path.Combine(temp.Path, "too-many-entries.zip");

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                for (int i = 0; i < 10001; i++)
                {
                    zip.CreateEntry($"entry-{i}.txt", CompressionLevel.NoCompression);
                }
            }

            UpdateManager manager = CreateManager(programFolder: Path.Combine(temp.Path, "program"));
            TargetInvocationException ex = Assert.Throws<TargetInvocationException>(() =>
                InvokeNonPublicVoid(manager, "ExtractZip", zipPath));

            Assert.IsType<InvalidOperationException>(ex.InnerException);
            Assert.Contains("number of entries", ex.InnerException.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that extract zip throws when compression ratio is suspicious
        /// </summary>
        [Fact]
        public void ExtractZip_ThrowsWhenCompressionRatioIsSuspicious()
        {
            using TempFolder temp = TempFolder.Create();
            string zipPath = Path.Combine(temp.Path, "ratio.zip");

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry("big.txt", CompressionLevel.Optimal);
                using StreamWriter writer = new StreamWriter(entry.Open());
                writer.Write(new string('A', 500000));
            }

            UpdateManager manager = CreateManager(programFolder: Path.Combine(temp.Path, "program"));
            TargetInvocationException ex = Assert.Throws<TargetInvocationException>(() =>
                InvokeNonPublicVoid(manager, "ExtractZip", zipPath));

            Assert.IsType<InvalidOperationException>(ex.InnerException);
            Assert.Contains("compression ratio", ex.InnerException.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that clean temp file deletes non backup artifacts only
        /// </summary>
        [Fact]
        public void CleanTempFile_DeletesNonBackupArtifactsOnly()
        {
            UpdateManager manager = CreateManager();
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string id = Guid.NewGuid().ToString("N");

            string tempZip = Path.Combine(baseDir, $"tmp-{id}.zip");
            string tempDmg = Path.Combine(baseDir, $"tmp-{id}.dmg");
            string backupZip = Path.Combine(baseDir, $"Backup_{id}.zip");

            File.WriteAllText(tempZip, "zip");
            File.WriteAllText(tempDmg, "dmg");
            File.WriteAllText(backupZip, "backup");

            try
            {
                InvokeNonPublicVoid(manager, "CleanTempFile");

                Assert.False(File.Exists(tempZip));
                Assert.False(File.Exists(tempDmg));
                Assert.True(File.Exists(backupZip));
            }
            finally
            {
                if (File.Exists(tempZip))
                {
                    File.Delete(tempZip);
                }

                if (File.Exists(tempDmg))
                {
                    File.Delete(tempDmg);
                }

                if (File.Exists(backupZip))
                {
                    File.Delete(backupZip);
                }
            }
        }

        /// <summary>
        /// Tests that git hub api service get latest release async returns response dictionary
        /// </summary>
        [Fact]
        public async Task GitHubApiService_GetLatestReleaseAsync_ReturnsResponseDictionary()
        {
            const string payload = "{\"ok\":true}";
            using LoopbackHttpServer server = new LoopbackHttpServer(payload, 1);
            using GitHubApiService service = new GitHubApiService(server.Uri);

            Dictionary<string, object> result = await service.GetLatestReleaseAsync();

            Assert.NotNull(result);
            Assert.True(result.ContainsKey("response"));
            Assert.Equal(payload, result["response"]);
        }

        /// <summary>
        /// Tests that git hub api service constructor assigns api url
        /// </summary>
        [Fact]
        public void GitHubApiService_Constructor_AssignsApiUrl()
        {
            Uri url = new Uri("http://127.0.0.1:8089/");
            using GitHubApiService service = new GitHubApiService(url);

            Assert.Equal(url, service.ApiUrl);
        }

        /// <summary>
        /// Tests that file service methods throw not implemented exception
        /// </summary>
        [Fact]
        public void FileService_Methods_ThrowNotImplementedException()
        {
            FileService service = new FileService();

            Assert.Throws<NotImplementedException>(() => service.Backup("/tmp"));
            Assert.Throws<NotImplementedException>(() => service.CleanTempFiles("/tmp"));
            Assert.Throws<NotImplementedException>(() => service.ExtractAndReplace("archive.zip", "/tmp"));
            Assert.Throws<NotImplementedException>(() => service.DownloadFileAsync(new Uri("http://127.0.0.1:7777/"), "/tmp").GetAwaiter().GetResult());
        }

        /// <summary>
        /// Tests that select asset massive coverage
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <param name="shouldMatch">The should match</param>
        /// <param name="nullNameEntries">The null name entries</param>
        [Theory]
        [MemberData(nameof(SelectAssetMassiveCases))]
        public void SelectAsset_MassiveCoverage(int caseId, string platform, string architecture, bool shouldMatch, int nullNameEntries)
        {
            UpdateManager manager = CreateManager();
            object[] assets = BuildAssetsForCase(caseId, platform, architecture, shouldMatch, nullNameEntries);

            Dictionary<string, object> selected = InvokeNonPublic<Dictionary<string, object>>(manager, "SelectAsset", assets, platform, architecture);

            if (shouldMatch)
            {
                Assert.NotNull(selected);
                string name = selected["name"].ToString();
                Assert.Contains(platform, name);
                Assert.Contains(architecture, name);
            }
            else
            {
                Assert.Null(selected);
            }
        }

        /// <summary>
        /// Tests that extract and replace invalid extensions always throw
        /// </summary>
        /// <param name="fileName">The file name</param>
        [Theory]
        [MemberData(nameof(InvalidExtensionCases))]
        public void ExtractAndReplace_InvalidExtensions_AlwaysThrow(string fileName)
        {
            UpdateManager manager = CreateManager();

            TargetInvocationException ex = Assert.Throws<TargetInvocationException>(() =>
                InvokeNonPublicVoid(manager, "ExtractAndReplace", fileName));

            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }

        /// <summary>
        /// Selects the asset massive cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> SelectAssetMassiveCases()
        {
            string[] platforms = { "win", "linux", "osx" };
            string[] architectures = { "x64", "arm64", "x86", "arm" };

            for (int i = 0; i < 1200; i++)
            {
                string platform = platforms[i % platforms.Length];
                string architecture = architectures[(i / platforms.Length) % architectures.Length];
                bool shouldMatch = i % 3 != 0;
                int nullNameEntries = i % 4;
                yield return new object[] { i, platform, architecture, shouldMatch, nullNameEntries };
            }
        }

        /// <summary>
        /// Invalids the extension cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> InvalidExtensionCases()
        {
            string[] extensions = { "tar", "7z", "rar", "pkg", "bin", "msi", "txt", "json", "gz", "iso" };

            for (int i = 0; i < 350; i++)
            {
                string ext = extensions[i % extensions.Length];
                yield return new object[] { $"update-package-{i}.{ext}" };
            }
        }

        /// <summary>
        /// Builds the assets for case using the specified case id
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        /// <param name="shouldMatch">The should match</param>
        /// <param name="nullNameEntries">The null name entries</param>
        /// <returns>The object array</returns>
        private static object[] BuildAssetsForCase(int caseId, string platform, string architecture, bool shouldMatch, int nullNameEntries)
        {
            List<object> assets = new List<object>();

            for (int i = 0; i < 5; i++)
            {
                assets.Add(Asset($"unrelated-{caseId}-{i}-ios-arm64.zip", "https://example.invalid/no-match"));
            }

            for (int i = 0; i < nullNameEntries; i++)
            {
                assets.Add(Asset(null, "https://example.invalid/null-name"));
            }

            if (shouldMatch)
            {
                assets.Insert(caseId % (assets.Count + 1), Asset($"alis-{platform}-preview-{architecture}-{caseId}.zip", "https://example.invalid/match"));
            }

            return assets.ToArray();
        }

        /// <summary>
        /// Assets the name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="url">The url</param>
        /// <returns>A dictionary of string and object</returns>
        private static Dictionary<string, object> Asset(string name, string url)
        {
            return new Dictionary<string, object>
            {
                { "name", name },
                { "browser_download_url", url }
            };
        }

        /// <summary>
        /// Creates the manager using the specified version to install
        /// </summary>
        /// <param name="versionToInstall">The version to install</param>
        /// <param name="programFolder">The program folder</param>
        /// <param name="apiUrl">The api url</param>
        /// <returns>The update manager</returns>
        private static UpdateManager CreateManager(string versionToInstall = "latest", string programFolder = null, Uri apiUrl = null)
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(apiUrl ?? new Uri("http://127.0.0.1:55000/"));
            api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync(new Dictionary<string, object>());

            IFileService fileService = Mock.Of<IFileService>();
            return new UpdateManager(api.Object, versionToInstall, fileService, programFolder ?? Path.Combine(Path.GetTempPath(), "alis-updater", Guid.NewGuid().ToString("N")));
        }

        /// <summary>
        /// Invokes the non public using the specified manager
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="manager">The manager</param>
        /// <param name="methodName">The method name</param>
        /// <param name="args">The args</param>
        /// <returns>The</returns>
        private static T InvokeNonPublic<T>(UpdateManager manager, string methodName, params object[] args)
        {
            object result = InvokeNonPublic(manager, methodName, args);
            return (T)result;
        }

        /// <summary>
        /// Invokes the non public using the specified manager
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="manager">The manager</param>
        /// <param name="methodName">The method name</param>
        /// <param name="args">The args</param>
        /// <returns>A task containing the</returns>
        private static Task<T> InvokeNonPublicAsync<T>(UpdateManager manager, string methodName, params object[] args)
        {
            object result = InvokeNonPublic(manager, methodName, args);
            return (Task<T>)result;
        }

        /// <summary>
        /// Invokes the non public void using the specified manager
        /// </summary>
        /// <param name="manager">The manager</param>
        /// <param name="methodName">The method name</param>
        /// <param name="args">The args</param>
        private static void InvokeNonPublicVoid(UpdateManager manager, string methodName, params object[] args)
        {
            InvokeNonPublic(manager, methodName, args);
        }

        /// <summary>
        /// Invokes the non public using the specified manager
        /// </summary>
        /// <param name="manager">The manager</param>
        /// <param name="methodName">The method name</param>
        /// <param name="args">The args</param>
        /// <returns>The object</returns>
        private static object InvokeNonPublic(UpdateManager manager, string methodName, params object[] args)
        {
            MethodInfo method = typeof(UpdateManager).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            return method.Invoke(manager, args);
        }

        /// <summary>
        /// The temp folder class
        /// </summary>
        /// <seealso cref="IDisposable"/>
        private sealed class TempFolder : IDisposable
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TempFolder"/> class
            /// </summary>
            /// <param name="path">The path</param>
            private TempFolder(string path)
            {
                Path = path;
            }

            /// <summary>
            /// Gets the value of the path
            /// </summary>
            public string Path { get; }

            /// <summary>
            /// Creates
            /// </summary>
            /// <returns>The temp folder</returns>
            public static TempFolder Create()
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-tests", Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(path);
                return new TempFolder(path);
            }

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
        }

        /// <summary>
        /// The loopback http server class
        /// </summary>
        /// <seealso cref="IDisposable"/>
        private sealed class LoopbackHttpServer : IDisposable
        {
            /// <summary>
            /// The cancellation
            /// </summary>
            private readonly CancellationTokenSource _cancellation;
            /// <summary>
            /// The listener
            /// </summary>
            private readonly TcpListener _listener;
            /// <summary>
            /// The worker
            /// </summary>
            private readonly Task _worker;

            /// <summary>
            /// Initializes a new instance of the <see cref="LoopbackHttpServer"/> class
            /// </summary>
            /// <param name="responseBody">The response body</param>
            /// <param name="maxRequests">The max requests</param>
            public LoopbackHttpServer(string responseBody, int maxRequests)
            {
                _cancellation = new CancellationTokenSource();
                _listener = new TcpListener(IPAddress.Loopback, 0);
                _listener.Start();

                int port = ((IPEndPoint)_listener.LocalEndpoint).Port;
                Uri = new Uri($"http://127.0.0.1:{port}/");

                _worker = Task.Run(async () =>
                {
                    int handled = 0;
                    while (!_cancellation.IsCancellationRequested && handled < maxRequests)
                    {
                        TcpClient client;
                        try
                        {
                            client = await _listener.AcceptTcpClientAsync(_cancellation.Token);
                        }
                        catch
                        {
                            break;
                        }

                        using (client)
                        using (NetworkStream network = client.GetStream())
                        using (StreamReader reader = new StreamReader(network, Encoding.ASCII, false, 1024, true))
                        {
                            while (!_cancellation.IsCancellationRequested)
                            {
                                string line = await reader.ReadLineAsync();
                                if (line == null || line.Length == 0)
                                {
                                    break;
                                }
                            }

                            byte[] bodyBytes = Encoding.UTF8.GetBytes(responseBody);
                            string headers = "HTTP/1.1 200 OK\r\n" +
                                             "Content-Type: application/json\r\n" +
                                             $"Content-Length: {bodyBytes.Length}\r\n" +
                                             "Connection: close\r\n\r\n";
                            byte[] headerBytes = Encoding.ASCII.GetBytes(headers);

                            await network.WriteAsync(headerBytes, 0, headerBytes.Length, _cancellation.Token);
                            await network.WriteAsync(bodyBytes, 0, bodyBytes.Length, _cancellation.Token);
                            await network.FlushAsync(_cancellation.Token);
                        }

                        handled++;
                    }
                }, _cancellation.Token);
            }

            /// <summary>
            /// Gets the value of the uri
            /// </summary>
            public Uri Uri { get; }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose()
            {
                _cancellation.Cancel();
                _listener.Stop();

                try
                {
                    _worker.GetAwaiter().GetResult();
                }
                catch
                {
                    // Intentionally ignored during shutdown.
                }

                _cancellation.Dispose();
            }
        }
    }
}

