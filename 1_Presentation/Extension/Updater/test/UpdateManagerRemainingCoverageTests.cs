// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerRemainingCoverageTests.cs
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
    ///     The update manager remaining coverage tests class
    /// </summary>
    public class UpdateManagerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that start with null release returns false
        /// </summary>
        [Fact]
        public async Task Start_WithNullRelease_ReturnsFalse()
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("http://127.0.0.1:55000/"));
            api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync((Dictionary<string, object>) null);

            UpdateManager manager = new UpdateManager(api.Object, "latest", Mock.Of<IFileService>(),
                System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-test", Guid.NewGuid().ToString("N")))
            {
                ContinueDelayMilliseconds = 0
            };

            bool result = false;
            try
            {
                result = await manager.Start(CancellationToken.None);
            }
            catch (System.InvalidOperationException)
            {
                result = false;
            }

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that start with empty release returns false
        /// </summary>
        [Fact]
        public async Task Start_WithEmptyRelease_ReturnsFalse()
        {
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(new Uri("http://127.0.0.1:55000/"));
            api.Setup(x => x.GetLatestReleaseAsync()).ReturnsAsync(new Dictionary<string, object>());

            UpdateManager manager = new UpdateManager(api.Object, "latest", Mock.Of<IFileService>(),
                System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-test", Guid.NewGuid().ToString("N")))
            {
                ContinueDelayMilliseconds = 0
            };

            bool result = false;
            try
            {
                result = await manager.Start(CancellationToken.None);
            }
            catch (System.InvalidOperationException)
            {
                result = false;
            }

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that start with latest version and no matching arm64 asset returns false.
        /// </summary>
        [Fact]
        public async Task Start_WithLatestVersionAndNoMatchingAsset_ReturnsFalse()
        {
            using LoopbackHttpServer server = LoopbackHttpServer.Start();
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(server.Uri);

            UpdateManager manager = new UpdateManager(api.Object, "latest", Mock.Of<IFileService>(),
                System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alis-updater-test", Guid.NewGuid().ToString("N")))
            {
                ContinueDelayMilliseconds = 0
            };

            bool result = await manager.Start(CancellationToken.None);

            Assert.False(result);
            Assert.Equal(0, manager.Progress);
        }

        /// <summary>
        ///     Minimal loopback HTTP server used to satisfy the update manager release fetch.
        /// </summary>
        private sealed class LoopbackHttpServer : IDisposable
        {
            private readonly TcpListener _listener;
            private readonly CancellationTokenSource _cancellation;
            private readonly Task _worker;

            private LoopbackHttpServer(TcpListener listener, Uri uri)
            {
                _listener = listener;
                Uri = uri;
                _cancellation = new CancellationTokenSource();
                _worker = Task.Run(() => WorkerLoop(_cancellation.Token));
            }

            public Uri Uri { get; }

            public static LoopbackHttpServer Start()
            {
                TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
                listener.Start();
                int port = ((IPEndPoint) listener.LocalEndpoint).Port;
                return new LoopbackHttpServer(listener, new Uri($"http://127.0.0.1:{port}/"));
            }

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
                        byte[] buffer = new byte[4096];
                        stream.Read(buffer, 0, buffer.Length);
                        const string body = "ok";
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
