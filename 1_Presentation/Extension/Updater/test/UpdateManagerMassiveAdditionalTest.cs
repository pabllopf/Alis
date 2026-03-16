// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerMassiveAdditionalTest.cs
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
    ///     The update manager massive additional test class
    /// </summary>
    public class UpdateManagerMassiveAdditionalTest
    {
        /// <summary>
        ///     The backup archives lock
        /// </summary>
        private static readonly object BackupArchivesLock = new object();

        /// <summary>
        ///     Tests that is latest version already downloaded matrix cases
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="useNullUrl">The use null url</param>
        /// <param name="createFile">The create file</param>
        /// <param name="expected">The expected</param>
        [Theory, MemberData(nameof(IsLatestVersionAlreadyDownloadedCases))]
        public void IsLatestVersionAlreadyDownloaded_MatrixCases(int caseId, bool useNullUrl, bool createFile, bool expected)
        {
            UpdateManager sut = CreateManagerFast();
            string fileName = "exists-check-" + caseId + ".zip";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            string downloadUrl = useNullUrl ? null : "https://example.invalid/downloads/" + fileName;

            if (createFile)
            {
                File.WriteAllText(filePath, "payload");
            }

            try
            {
                bool result = sut.IsLatestVersionAlreadyDownloaded(downloadUrl);
                Assert.Equal(expected, result);
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
        ///     Tests that handle download failure matrix cases
        /// </summary>
        /// <param name="caseId">The case id</param>
        [Theory, MemberData(nameof(HandleDownloadFailureCases))]
        public void HandleDownloadFailure_MatrixCases(int caseId)
        {
            UpdateManager sut = CreateManagerFast();

            bool result = sut.HandleDownloadFailure();

            Assert.False(result);
            Assert.Equal(0f, sut.Progress);
            Assert.Contains("Error downloading package", sut.Message, StringComparison.OrdinalIgnoreCase);
            Assert.True(caseId >= 0);
        }

        /// <summary>
        ///     Tests that handle missing compatible package matrix cases
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="platform">The platform</param>
        /// <param name="architecture">The architecture</param>
        [Theory, MemberData(nameof(HandleMissingCompatiblePackageCases))]
        public void HandleMissingCompatiblePackage_MatrixCases(int caseId, string platform, string architecture)
        {
            UpdateManager sut = CreateManagerFast();

            bool result = sut.HandleMissingCompatiblePackage(platform, architecture);

            Assert.False(result);
            Assert.Equal(0f, sut.Progress);
            Assert.Contains("No compatible package", sut.Message, StringComparison.OrdinalIgnoreCase);
            Assert.True(caseId >= 0);
        }

        /// <summary>
        ///     Tests that remove old backup archives keeps at most two files
        /// </summary>
        /// <param name="caseId">The case id</param>
        /// <param name="backupFileCount">The backup file count</param>
        [Theory, MemberData(nameof(RemoveOldBackupArchivesCases))]
        public void RemoveOldBackupArchives_KeepsAtMostTwoFiles(int caseId, int backupFileCount)
        {
            lock (BackupArchivesLock)
            {
                UpdateManager sut = CreateManagerFast();
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                List<string> created = new List<string>();

                try
                {
                    DateTime start = DateTime.UtcNow.AddMinutes(-5);
                    for (int i = 0; i < backupFileCount; i++)
                    {
                        string path = Path.Combine(baseDir, "Backup_case" + caseId + "_" + i + ".zip");
                        File.WriteAllText(path, "backup");
                        File.SetCreationTime(path, start.AddSeconds(i));
                        created.Add(path);
                    }

                    sut.RemoveOldBackupArchives();

                    int remaining = created.Count(File.Exists);
                    Assert.True(remaining <= 2);
                    Assert.True(remaining >= 0);
                }
                finally
                {
                    foreach (string file in created)
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Tests that finish already downloaded flow returns true and preserves backup files
        /// </summary>
        [Fact]
        public void FinishAlreadyDownloadedFlow_ReturnsTrue_AndPreservesBackupFiles()
        {
            UpdateManager sut = CreateManagerFast();
            string id = Guid.NewGuid().ToString("N");
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string tempZip = Path.Combine(baseDir, "tmp-" + id + ".zip");
            string tempDmg = Path.Combine(baseDir, "tmp-" + id + ".dmg");
            string backupZip = Path.Combine(baseDir, "Backup_" + id + ".zip");

            File.WriteAllText(tempZip, "zip");
            File.WriteAllText(tempDmg, "dmg");
            File.WriteAllText(backupZip, "backup");

            try
            {
                bool result = sut.FinishAlreadyDownloadedFlow();

                Assert.True(result);
                Assert.Equal(0.95f, sut.Progress);
                Assert.True(File.Exists(backupZip));
                Assert.False(File.Exists(tempZip));
                Assert.False(File.Exists(tempDmg));
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
        ///     Tests that move program folder to backup moves directory
        /// </summary>
        [Fact]
        public void MoveProgramFolderToBackup_MovesDirectory()
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = Path.Combine(temp.Path, "program");
            Directory.CreateDirectory(programFolder);
            File.WriteAllText(Path.Combine(programFolder, "file.txt"), "payload");

            UpdateManager sut = CreateManagerFast(programFolder: programFolder);

            string backupPath = sut.MoveProgramFolderToBackup();

            try
            {
                Assert.False(Directory.Exists(programFolder));
                Assert.True(Directory.Exists(backupPath));
                Assert.True(File.Exists(Path.Combine(backupPath, "file.txt")));
            }
            finally
            {
                if (Directory.Exists(backupPath))
                {
                    Directory.Delete(backupPath, true);
                }
            }
        }

        /// <summary>
        ///     Tests that compress backup folder creates zip and deletes source
        /// </summary>
        [Fact]
        public void CompressBackupFolder_CreatesZipAndDeletesSource()
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = Path.Combine(temp.Path, "program");
            Directory.CreateDirectory(programFolder);
            UpdateManager sut = CreateManagerFast(programFolder: programFolder);

            string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_test_" + Guid.NewGuid().ToString("N"));
            string filePath = Path.Combine(backupPath, "content.txt");
            Directory.CreateDirectory(backupPath);
            File.WriteAllText(filePath, "payload");

            string[] before = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Backup_*.zip");
            sut.CompressBackupFolder(backupPath);
            string[] after = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Backup_*.zip");
            string createdZip = after.Except(before).FirstOrDefault();

            try
            {
                Assert.False(Directory.Exists(backupPath));
                Assert.NotNull(createdZip);
                Assert.True(File.Exists(createdZip));
            }
            finally
            {
                if ((createdZip != null) && File.Exists(createdZip))
                {
                    File.Delete(createdZip);
                }
            }
        }

        /// <summary>
        ///     Tests that install latest version with zip package returns true and extracts
        /// </summary>
        [Fact]
        public void InstallLatestVersion_WithZipPackage_ReturnsTrueAndExtracts()
        {
            using TempFolder temp = TempFolder.Create();
            string programFolder = Path.Combine(temp.Path, "program");
            string zipPath = Path.Combine(temp.Path, "update.zip");

            using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry("bin/app.txt", CompressionLevel.Fastest);
                using StreamWriter writer = new StreamWriter(entry.Open());
                writer.Write("v2");
            }

            UpdateManager sut = CreateManagerFast(programFolder: programFolder);

            bool result = sut.InstallLatestVersion(zipPath, "v2");

            Assert.True(result);
            Assert.True(File.Exists(Path.Combine(programFolder, "bin", "app.txt")));
            Assert.Equal(1f, sut.Progress);
        }

        /// <summary>
        ///     Tests that download latest version async downloads and returns path
        /// </summary>
        [Fact]
        public async Task DownloadLatestVersionAsync_DownloadsAndReturnsPath()
        {
            string fileName = "latest-" + Guid.NewGuid().ToString("N") + ".bin";
            string payload = "payload-" + Guid.NewGuid().ToString("N");
            using LoopbackHttpServer server = new LoopbackHttpServer(payload, 1);
            UpdateManager sut = CreateManagerFast();

            string path = await sut.DownloadLatestVersionAsync(new Uri(server.Uri, fileName).ToString(), "v100");

            try
            {
                Assert.True(File.Exists(path));
                Assert.Equal(payload, File.ReadAllText(path));
                Assert.Equal(0.5f, sut.Progress);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Ises the latest version already downloaded cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> IsLatestVersionAlreadyDownloadedCases()
        {
            for (int i = 0; i < 180; i++)
            {
                bool useNullUrl = i % 6 == 0;
                bool createFile = i % 2 == 0;
                bool expected = !useNullUrl && createFile;
                yield return new object[] {i, useNullUrl, createFile, expected};
            }
        }

        /// <summary>
        ///     Handles the download failure cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> HandleDownloadFailureCases()
        {
            for (int i = 0; i < 60; i++)
            {
                yield return new object[] {i};
            }
        }

        /// <summary>
        ///     Handles the missing compatible package cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> HandleMissingCompatiblePackageCases()
        {
            string[] platforms = {"win", "linux", "osx", "android", "ios"};
            string[] arch = {"x64", "x86", "arm64", "arm", "wasm"};

            for (int i = 0; i < 60; i++)
            {
                yield return new object[] {i, platforms[i % platforms.Length], arch[i / platforms.Length % arch.Length]};
            }
        }

        /// <summary>
        ///     Removes the old backup archives cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> RemoveOldBackupArchivesCases()
        {
            for (int i = 0; i < 40; i++)
            {
                int backupCount = i % 7;
                yield return new object[] {i, backupCount};
            }
        }

        /// <summary>
        ///     Creates the manager fast using the specified version to install
        /// </summary>
        /// <param name="versionToInstall">The version to install</param>
        /// <param name="programFolder">The program folder</param>
        /// <param name="apiUrl">The api url</param>
        /// <returns>The manager</returns>
        private static UpdateManager CreateManagerFast(string versionToInstall = "latest", string programFolder = null, Uri apiUrl = null)
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(apiUrl ?? new Uri("http://127.0.0.1:55000/"));
            api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync(new Dictionary<string, object>());

            IFileService fileService = Mock.Of<IFileService>();
            UpdateManager manager = new UpdateManager(api.Object, versionToInstall, fileService,
                programFolder ?? Path.Combine(Path.GetTempPath(), "alis-updater", Guid.NewGuid().ToString("N")));
            manager.ContinueDelayMilliseconds = 0;
            return manager;
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
                                             "Content-Type: application/octet-stream\r\n" +
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