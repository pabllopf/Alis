// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateManagerFlowCoverageTests.cs
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
    ///     The update manager flow coverage tests class
    /// </summary>
    public class UpdateManagerFlowCoverageTests
    {
        /// <summary>
        ///     Tests that get latest release async with a matching version returns the release.
        /// </summary>
        [Fact]
        public void GetLatestReleaseAsync_WithMatchingVersion_ReturnsRelease()
        {
            using LoopbackHttpServer server = LoopbackHttpServer.Start();
            Mock<IGitHubApiService> api = new Mock<IGitHubApiService>();
            api.SetupGet(x => x.ApiUrl).Returns(server.Uri);
            UpdateManager sut = new UpdateManager(api.Object, "v0.7.5", Mock.Of<IFileService>(), Path.GetTempPath());
            sut.ContinueDelayMilliseconds = 0;

            Dictionary<string, object> result = sut.GetLatestReleaseAsync().GetAwaiter().GetResult();

            Assert.NotNull(result);
            Assert.Equal("v0.7.5", result["tag_name"]);
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
            ///     The response content
            /// </summary>
            private string _responseContent = "ok";

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
