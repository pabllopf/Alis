// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerTest.cs
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
using System.Diagnostics;
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
using Moq;
using Xunit;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    ///     The update manager test class
    /// </summary>
    public class UpdateManagerTest
    {
        /// <summary>
        ///     Tests that constructor stores dependencies
        /// </summary>
        [Fact]
        public void Constructor_StoresDependencies()
        {
            IGitHubApiService api = Mock.Of<IGitHubApiService>();
            IFileService files = Mock.Of<IFileService>();
            string folder = "/tmp/alis-updater";

            UpdateManager sut = new UpdateManager(api, "latest", files, folder);

            Assert.Same(api, sut.GitHubApiService);
            Assert.Same(files, sut.FileService);
            Assert.Equal("latest", sut.VersionToInstall);
            Assert.Equal(folder, sut.ProgramFolder);
        }

        /// <summary>
        ///     Tests that on update progress changed updates state and raises event
        /// </summary>
        [Fact]
        public void OnUpdateProgressChanged_UpdatesStateAndRaisesEvent()
        {
            UpdateManager sut = CreateManager();
            float capturedProgress = -1;
            string capturedMessage = null;

            sut.UpdateProgressChanged += (progress, message) =>
            {
                capturedProgress = progress;
                capturedMessage = message;
            };

            sut.OnUpdateProgressChanged(0.55f, "half-way");

            Assert.Equal(0.55f, sut.Progress);
            Assert.Equal("half-way", sut.Message);
            Assert.Equal(0.55f, capturedProgress);
            Assert.Equal("half-way", capturedMessage);
        }

        /// <summary>
        ///     Tests that start returns false when cancellation is requested
        /// </summary>
        [Fact]
        public async Task Start_ReturnsFalse_WhenCancellationIsRequested()
        {
            UpdateManager sut = CreateManager();
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            bool result = await sut.Start(cts.Token);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that start wraps exception when release resolution fails
        /// </summary>
        [Fact]
        public async Task Start_WrapsException_WhenReleaseResolutionFails()
        {
            using LoopbackHttpServer server = new LoopbackHttpServer("[]", 1);
            UpdateManager sut = CreateManager("v9.9.9", apiUrl: server.Uri);

            Exception ex = await Assert.ThrowsAsync<Exception>(async () => await sut.Start(CancellationToken.None));

            Assert.Contains("Error updating program", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that handle cancellation request returns expected value
        /// </summary>
        [Fact]
        public void HandleCancellationRequest_ReturnsExpectedValue()
        {
            UpdateManager sut = CreateManager();

            bool notCancelled = sut.HandleCancellationRequest(CancellationToken.None);
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            bool cancelled = sut.HandleCancellationRequest(cts.Token);

            Assert.False(notCancelled);
            Assert.True(cancelled);
        }

        /// <summary>
        ///     Tests that get architecture returns lowercase token
        /// </summary>
        [Fact]
        public void GetArchitecture_ReturnsLowercaseToken()
        {
            UpdateManager sut = CreateManager();

            string architecture = sut.GetArchitecture();

            Assert.False(string.IsNullOrWhiteSpace(architecture));
            Assert.Equal(architecture.ToLower(), architecture);
        }

        /// <summary>
        ///     Tests that get selected asset returns matching entry
        /// </summary>
        [Fact]
        public void GetSelectedAsset_ReturnsMatchingEntry()
        {
            UpdateManager sut = CreateManager();
            Dictionary<string, object> release = new Dictionary<string, object>
            {
                {
                    "assets", new object[]
                    {
                        Asset("pkg-linux-arm64.zip", "https://example.invalid/linux"),
                        Asset("pkg-win-x64.zip", "https://example.invalid/win")
                    }
                }
            };

            Dictionary<string, object> selected = sut.GetSelectedAsset(release, "win", "x64");

            Assert.NotNull(selected);
            Assert.Equal("pkg-win-x64.zip", selected["name"]);
        }

        /// <summary>
        ///     Tests that handle missing compatible package returns false and updates state
        /// </summary>
        [Fact]
        public void HandleMissingCompatiblePackage_ReturnsFalseAndUpdatesState()
        {
            UpdateManager sut = CreateManager();

            bool result = sut.HandleMissingCompatiblePackage("osx", "arm64");

            Assert.False(result);
            Assert.Equal(0f, sut.Progress);
            Assert.Contains("No compatible package", sut.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that is latest version already downloaded returns false when url is null
        /// </summary>
        [Fact]
        public void IsLatestVersionAlreadyDownloaded_ReturnsFalse_WhenUrlIsNull()
        {
            UpdateManager sut = CreateManager();

            bool result = sut.IsLatestVersionAlreadyDownloaded(null);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is latest version already downloaded returns true when file exists
        /// </summary>
        [Fact]
        public void IsLatestVersionAlreadyDownloaded_ReturnsTrue_WhenFileExists()
        {
            UpdateManager sut = CreateManager();
            string id = Guid.NewGuid().ToString("N");
            string fileName = "already-" + id + ".zip";
            string downloadUrl = "https://example.invalid/downloads/" + fileName;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            File.WriteAllText(filePath, "content");

            try
            {
                bool result = sut.IsLatestVersionAlreadyDownloaded(downloadUrl);
                Assert.True(result);
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
        ///     Tests that handle download failure returns false and sets error progress
        /// </summary>
        [Fact]
        public void HandleDownloadFailure_ReturnsFalseAndSetsErrorProgress()
        {
            UpdateManager sut = CreateManager();

            bool result = sut.HandleDownloadFailure();

            Assert.False(result);
            Assert.Equal(0f, sut.Progress);
            Assert.Contains("Error downloading package", sut.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that backup when program folder does not exist only reports progress
        /// </summary>
        [Fact]
        public void Backup_WhenProgramFolderDoesNotExist_OnlyReportsProgress()
        {
            string folder = Path.Combine(Path.GetTempPath(), "alis-updater-not-exists", Guid.NewGuid().ToString("N"));
            UpdateManager sut = CreateManager(programFolder: folder);

            sut.Backup();

            Assert.Equal(0.7f, sut.Progress);
            Assert.Contains("backup", sut.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that extract and replace with zip extracts and reports completion
        /// </summary>
        [Fact]
        public void ExtractAndReplace_WithZip_ExtractsAndReportsCompletion()
        {
            using TempFolder temp = TempFolder.Create();
            string targetFolder = Path.Combine(temp.Path, "program");
            string zipPath = Path.Combine(temp.Path, "safe.zip");

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry("content/readme.txt", CompressionLevel.Fastest);
                using StreamWriter writer = new StreamWriter(entry.Open());
                writer.Write("safe-content");
            }

            UpdateManager sut = CreateManager(programFolder: targetFolder);
            sut.ExtractAndReplace(zipPath);

            Assert.True(File.Exists(Path.Combine(targetFolder, "content", "readme.txt")));
            Assert.Equal(0.8f, sut.Progress);
        }

        /// <summary>
        ///     Tests that extract and replace throws when extension is invalid
        /// </summary>
        [Fact]
        public void ExtractAndReplace_Throws_WhenExtensionIsInvalid()
        {
            UpdateManager sut = CreateManager();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.ExtractAndReplace("file.invalid"));
            Assert.Contains("invalid extension", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that extract dmg creates program folder when missing
        /// </summary>
        [Fact]
        public void ExtractDmg_CreatesProgramFolder_WhenMissing()
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = Path.Combine(temp.Path, "program-folder");
            string dmgPath = Path.Combine(temp.Path, "fake.dmg");
            File.WriteAllText(dmgPath, "dummy");

            UpdateManager sut = CreateManager(programFolder: programFolder);

            sut.ExtractDmg(dmgPath);

            Assert.True(Directory.Exists(programFolder));
        }

        /// <summary>
        ///     Tests that get dmg mount path returns expected volumes path
        /// </summary>
        [Fact]
        public void GetDmgMountPath_ReturnsExpectedVolumesPath()
        {
            UpdateManager sut = CreateManager();

            string mountPath = sut.GetDmgMountPath("/tmp/example.dmg");

            Assert.Equal("/Volumes/example", mountPath);
        }

        /// <summary>
        ///     Tests that ensure program folder exists creates missing directory
        /// </summary>
        [Fact]
        public void EnsureProgramFolderExists_CreatesMissingDirectory()
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = Path.Combine(temp.Path, "created-program-folder");
            UpdateManager sut = CreateManager(programFolder: programFolder);

            sut.EnsureProgramFolderExists();

            Assert.True(Directory.Exists(programFolder));
        }

        /// <summary>
        ///     Tests that wait for continue sleeps at least one second
        /// </summary>
        [Fact]
        public void WaitForContinue_SleepsAtLeastOneSecond()
        {
            UpdateManager sut = CreateManager();
            Stopwatch sw = Stopwatch.StartNew();

            sut.WaitForContinue();

            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds >= 900);
        }

        /// <summary>
        ///     Tests that execute shell command executes without throwing
        /// </summary>
        [Fact]
        public void ExecuteShellCommand_ExecutesWithoutThrowing()
        {
            UpdateManager sut = CreateManager();
            string marker = Path.Combine(Path.GetTempPath(), "alis-updater-shell-" + Guid.NewGuid().ToString("N"));

            try
            {
                sut.ExecuteShellCommand("touch " + marker);
                Assert.True(File.Exists(marker));
            }
            finally
            {
                if (File.Exists(marker))
                {
                    File.Delete(marker);
                }
            }
        }

        /// <summary>
        ///     Tests that extract zip throws when entry count exceeds threshold
        /// </summary>
        [Fact]
        public void ExtractZip_Throws_WhenEntryCountExceedsThreshold()
        {
            using TempFolder temp = TempFolder.Create();
            string zipPath = Path.Combine(temp.Path, "too-many-entries.zip");

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                for (int i = 0; i < 10001; i++)
                {
                    zip.CreateEntry("entry-" + i + ".txt", CompressionLevel.NoCompression);
                }
            }

            UpdateManager sut = CreateManager(programFolder: Path.Combine(temp.Path, "program"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.ExtractZip(zipPath));
            Assert.Contains("number of entries", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that clean temp file removes only non backup artifacts
        /// </summary>
        [Fact]
        public void CleanTempFile_RemovesOnlyNonBackupArtifacts()
        {
            UpdateManager sut = CreateManager();
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string id = Guid.NewGuid().ToString("N");

            string tempZip = Path.Combine(baseDir, "tmp-" + id + ".zip");
            string tempDmg = Path.Combine(baseDir, "tmp-" + id + ".dmg");
            string backupZip = Path.Combine(baseDir, "Backup_" + id + ".zip");

            File.WriteAllText(tempZip, "zip");
            File.WriteAllText(tempDmg, "dmg");
            File.WriteAllText(backupZip, "backup");

            try
            {
                sut.CleanTempFile();
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
        ///     Tests that clean temporary files by pattern deletes only matching non backup files
        /// </summary>
        [Fact]
        public void CleanTemporaryFilesByPattern_DeletesOnlyMatchingNonBackupFiles()
        {
            UpdateManager sut = CreateManager();
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string id = Guid.NewGuid().ToString("N");

            string tmpA = Path.Combine(baseDir, "tmp-a-" + id + ".zip");
            string tmpB = Path.Combine(baseDir, "tmp-b-" + id + ".zip");
            string backup = Path.Combine(baseDir, "Backup_" + id + ".zip");

            File.WriteAllText(tmpA, "a");
            File.WriteAllText(tmpB, "b");
            File.WriteAllText(backup, "backup");

            try
            {
                sut.CleanTemporaryFilesByPattern("*.zip");

                Assert.False(File.Exists(tmpA));
                Assert.False(File.Exists(tmpB));
                Assert.True(File.Exists(backup));
            }
            finally
            {
                if (File.Exists(tmpA))
                {
                    File.Delete(tmpA);
                }

                if (File.Exists(tmpB))
                {
                    File.Delete(tmpB);
                }

                if (File.Exists(backup))
                {
                    File.Delete(backup);
                }
            }
        }


        /// <summary>
        ///     Tests that select asset returns null when no matches are found
        /// </summary>
        [Fact]
        public void SelectAsset_ReturnsNull_WhenNoMatchesAreFound()
        {
            UpdateManager sut = CreateManager();
            object[] assets =
            {
                Asset("pkg-linux-arm64.zip", "https://example.invalid/linux"),
                Asset("pkg-osx-x64.dmg", "https://example.invalid/osx")
            };

            Dictionary<string, object> selected = InvokeNonPublic<Dictionary<string, object>>(sut, "SelectAsset", assets, "win", "x64");
            Assert.Null(selected);
        }

        /// <summary>
        ///     Creates the manager using the specified version to install
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
            return new UpdateManager(api.Object, versionToInstall, fileService,
                programFolder ?? Path.Combine(Path.GetTempPath(), "alis-updater", Guid.NewGuid().ToString("N")));
        }

        /// <summary>
        ///     Assets the name
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
        ///     Invokes the non public using the specified manager
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="manager">The manager</param>
        /// <param name="methodName">The method name</param>
        /// <param name="args">The args</param>
        /// <returns>The</returns>
        private static T InvokeNonPublic<T>(UpdateManager manager, string methodName, params object[] args)
        {
            object result = InvokeNonPublic(manager, methodName, args);
            return (T) result;
        }

        /// <summary>
        ///     Invokes the non public using the specified manager
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="manager">The manager</param>
        /// <param name="methodName">The method name</param>
        /// <param name="args">The args</param>
        /// <returns>A task containing the</returns>
        private static Task<T> InvokeNonPublicAsync<T>(UpdateManager manager, string methodName, params object[] args)
        {
            object result = InvokeNonPublic(manager, methodName, args);
            return (Task<T>) result;
        }

        /// <summary>
        ///     Invokes the non public using the specified manager
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
        ///     The temp folder class
        /// </summary>
        /// <seealso cref="IDisposable" />
        private sealed class TempFolder : IDisposable
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TempFolder" /> class
            /// </summary>
            /// <param name="path">The path</param>
            private TempFolder(string path) => Path = path;

            /// <summary>
            ///     Gets the value of the path
            /// </summary>
            public string Path { get; }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public void Dispose()
            {
                if (Directory.Exists(Path))
                {
                    Directory.Delete(Path, true);
                }
            }

            /// <summary>
            ///     Creates
            /// </summary>
            /// <returns>The temp folder</returns>
            public static TempFolder Create()
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-tests", Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(path);
                return new TempFolder(path);
            }
        }

        /// <summary>
        ///     The loopback http server class
        /// </summary>
        /// <seealso cref="IDisposable" />
        private sealed class LoopbackHttpServer : IDisposable
        {
            /// <summary>
            ///     The cancellation
            /// </summary>
            private readonly CancellationTokenSource _cancellation;

            /// <summary>
            ///     The listener
            /// </summary>
            private readonly TcpListener _listener;

            /// <summary>
            ///     The worker
            /// </summary>
            private readonly Task _worker;

            /// <summary>
            ///     Initializes a new instance of the <see cref="LoopbackHttpServer" /> class
            /// </summary>
            /// <param name="responseBody">The response body</param>
            /// <param name="maxRequests">The max requests</param>
            public LoopbackHttpServer(string responseBody, int maxRequests)
            {
                _cancellation = new CancellationTokenSource();
                _listener = new TcpListener(IPAddress.Loopback, 0);
                _listener.Start();

                int port = ((IPEndPoint) _listener.LocalEndpoint).Port;
                Uri = new Uri("http://127.0.0.1:" + port + "/");

                _worker = Task.Run(async () =>
                {
                    int handled = 0;
                    while (!_cancellation.IsCancellationRequested && (handled < maxRequests))
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
                                             "Content-Length: " + bodyBytes.Length + "\r\n" +
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
            ///     Gets the value of the uri
            /// </summary>
            public Uri Uri { get; }

            /// <summary>
            ///     Disposes this instance
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
                }

                _cancellation.Dispose();
            }
        }
    }
}