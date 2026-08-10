// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketClientFactoryAdditionalCoverageTests.cs
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
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The web socket client factory additional coverage tests class
    /// </summary>
    public class WebSocketClientFactoryAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that get stream with ip literal connects and returns stream
        /// </summary>
        [Fact]
        public async Task GetStream_WithIpLiteral_ConnectsAndReturnsStream()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint) listener.LocalEndpoint).Port;
            using CancellationTokenSource cts = new CancellationTokenSource();

            Task<Stream> factoryTask = Task.Run(() => GetStreamToPort(port, cts.Token));

            TcpClient serverClient = await listener.AcceptTcpClientAsync();
            await factoryTask;

            Assert.NotNull(serverClient);
            serverClient.Dispose();
            listener.Stop();
        }

        /// <summary>
        ///     Gets the stream to port
        /// </summary>
        /// <param name="port">The port</param>
        /// <param name="token">The token</param>
        /// <returns>The stream</returns>
        private static async Task<Stream> GetStreamToPort(int port, CancellationToken token)
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            return await factory.GetStream(Guid.NewGuid(), false, true, "127.0.0.1", port, token);
        }
    }
}
