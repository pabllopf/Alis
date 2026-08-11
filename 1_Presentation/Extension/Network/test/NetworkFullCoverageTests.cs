// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkFullCoverageTests.cs
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
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The network full coverage tests class
    /// </summary>
    public class NetworkFullCoverageTests
    {
        /// <summary>
        ///     Tests that ping forever with cancelled token completes without exception
        /// </summary>
        [Fact]
        public async Task PingForever_WithCancelledToken_Completes()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromSeconds(1), cts.Token);

            cts.Cancel();

            Exception ex = await Record.ExceptionAsync(() => manager.PingForever());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that ping loop with closed socket breaks
        /// </summary>
        [Fact]
        public async Task PingLoop_WithClosedSocket_Breaks()
        {
            Guid guid = Guid.NewGuid();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
            using CancellationTokenSource cts = new CancellationTokenSource();
            PingPongManager manager = new PingPongManager(guid, webSocket, TimeSpan.FromMilliseconds(1), cts.Token);

            await manager.PingLoop();
        }

        /// <summary>
        ///     Tests that the buffer pool finalizer disposes without throwing
        /// </summary>
        [Fact]
        public void BufferPool_Finalizer_DoesNotThrow()
        {
            BufferPool pool = new BufferPool();

            pool.Dispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        ///     Tests that the frame reader decodes a close frame with description
        /// </summary>
        [Fact]
        public void FrameReader_CloseFrameWithDescription_Decodes()
        {
            byte[] payload = new byte[] {0x03, 0xE8, 0x68, 0x69};
            ArraySegment<byte> buffer = new ArraySegment<byte>(payload, 0, payload.Length);

            WebSocketFrame frame = WebSocketFrameReader.DecodeCloseFrame(true, WebSocketOpCode.ConnectionClose, payload.Length, buffer, new ArraySegment<byte>());

            Assert.NotNull(frame);
            Assert.Equal(WebSocketCloseStatus.NormalClosure, frame.CloseStatus);
            Assert.Equal("hi", frame.CloseStatusDescription);
        }
    }
}
