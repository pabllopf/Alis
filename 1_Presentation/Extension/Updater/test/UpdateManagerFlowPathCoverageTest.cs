// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerFlowPathCoverageTest.cs
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
    ///     The update manager flow path coverage test class
    /// </summary>
    public class UpdateManagerFlowPathCoverageTest
    {
        /// <summary>
        ///     Tests that get selected asset returns empty dictionary when no asset matches platform and architecture
        /// </summary>
        [Fact]
        public void GetSelectedAsset_ReturnsEmpty_WhenNoAssetMatches()
        {
            Dictionary<string, object> release = new Dictionary<string, object>
            {
                {
                    "assets", new object[]
                    {
                        new Dictionary<string, object>
                        {
                            {"name", "app-win-x64.zip"},
                            {"browser_download_url", "https://example.invalid/win"}
                        },
                        new Dictionary<string, object>
                        {
                            {"name", "app-linux-arm.zip"},
                            {"browser_download_url", "https://example.invalid/linux-arm"}
                        }
                    }
                }
            };

            Dictionary<string, object> selected = UpdateManager.GetSelectedAsset(release, "osx", "arm64");

            Assert.NotNull(selected);
            Assert.Empty(selected);
        }

        /// <summary>
        ///     Tests that remove old backup archives with non-standard backup name falls back to creation time
        /// </summary>
        [Fact]
        public void RemoveOldBackupArchives_WithNonStandardBackupName_UsesCreationTimeFallback()
        {
            string standardOld = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_20200101000000.zip");
            string standardMid = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_20230101000000.zip");
            string nonStandard = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup_custom-name.zip");
            File.WriteAllText(standardOld, "old");
            File.WriteAllText(standardMid, "mid");
            File.WriteAllText(nonStandard, "custom");
            try
            {
                Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
                api.SetupGet(x => x.ApiUrl).Returns(new Uri("http://127.0.0.1:55000/"));
                api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync(new Dictionary<string, object>());

                UpdateManager sut = new UpdateManager(api.Object, "latest", Mock.Of<IFileService>(), Path.Combine(Path.GetTempPath(), "alis-updater-test", Guid.NewGuid().ToString("N")))
                {
                    ContinueDelayMilliseconds = 0
                };

                sut.RemoveOldBackupArchives();

                Assert.True(File.Exists(nonStandard), "Non-standard backup should survive (sorted first by creation time)");
            }
            finally
            {
                if (File.Exists(standardOld))
                {
                    File.Delete(standardOld);
                }

                if (File.Exists(standardMid))
                {
                    File.Delete(standardMid);
                }

                if (File.Exists(nonStandard))
                {
                    File.Delete(nonStandard);
                }
            }
        }

        /// <summary>
        ///     Tests that execute update async with non-matching version and loopback returns null release
        /// </summary>
        [Fact]
        public void Start_WithNonMatchingVersion_AndLoopback_ReturnsFalse()
        {
            using LoopbackHttpServer server = LoopbackHttpServer.Start();
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(server.Uri);

            UpdateManager sut = new UpdateManager(api.Object, "v9.9.9", Mock.Of<IFileService>(), Path.GetTempPath())
            {
                ContinueDelayMilliseconds = 0
            };

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => sut.Start(CancellationToken.None).GetAwaiter().GetResult());
            Assert.Contains("Error updating program", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     The loopback http server class
        /// </summary>
        private sealed class LoopbackHttpServer : IDisposable
        {
            /// <summary>
            ///     The listener
            /// </summary>
            private readonly TcpListener _listener;

            /// <summary>
            ///     The cancellation
            /// </summary>
            private readonly CancellationTokenSource _cancellation;

            /// <summary>
            ///     The worker
            /// </summary>
            private readonly Task _worker;

            /// <summary>
            ///     Initializes a new instance of the <see cref="LoopbackHttpServer" /> class
            /// </summary>
            /// <param name="listener">The listener</param>
            /// <param name="uri">The uri</param>
            private LoopbackHttpServer(TcpListener listener, Uri uri)
            {
                _listener = listener;
                Uri = uri;
                _cancellation = new CancellationTokenSource();
                _worker = Task.Run(() => WorkerLoop(_cancellation.Token));
            }

            /// <summary>
            ///     Gets the value of the uri
            /// </summary>
            public Uri Uri { get; }

            /// <summary>
            ///     Starts this instance
            /// </summary>
            /// <returns>The server</returns>
            public static LoopbackHttpServer Start()
            {
                TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
                listener.Start();
                int port = ((IPEndPoint) listener.LocalEndpoint).Port;
                Uri uri = new Uri($"http://127.0.0.1:{port}/");
                return new LoopbackHttpServer(listener, uri);
            }

            /// <summary>
            ///     Workers the loop using the specified token
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
                        string body = "ok";
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

            /// <summary>
            ///     Disposes this instance
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
        }
    }
}
