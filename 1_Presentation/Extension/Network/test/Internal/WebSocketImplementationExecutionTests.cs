// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketImplementationExecutionTests.cs
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     Exercises the buffer fallback, ping send and close-frame receive paths of
    ///     <see cref="WebSocketImplementation" />.
    /// </summary>
    public class WebSocketImplementationExecutionTests
    {
        /// <summary>
        ///     Tests that get buffer falls back to to array when the stream does not expose its buffer.
        /// </summary>
        [Fact]
        public void GetBuffer_WithUnexposedBuffer_FallsBackToToArray()
        {
            WebSocketImplementation webSocket = CreateOpenSocket();

            MemoryStream stream = new MemoryStream(new byte[64], 0, 64, true, false);
            byte[] payload = Encoding.UTF8.GetBytes("alis");
            stream.Write(payload, 0, payload.Length);

            ArraySegment<byte> buffer = webSocket.GetBuffer(stream);

            Assert.True(buffer.Count > 0);
        }

        /// <summary>
        ///     Tests that send ping async with an open socket writes the ping frame.
        /// </summary>
        [Fact]
        public async Task SendPingAsync_WithOpenSocket_WritesFrame()
        {
            WebSocketImplementation webSocket = CreateOpenSocket();

            await webSocket.SendPingAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("ping")), CancellationToken.None);
        }


        /// <summary>
        ///     Tests that receiving a close frame dispatches to the connection close handler.
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_WithCloseFrame_HandlesConnectionClose()
        {
            WebSocketImplementation webSocket = CreateOpenSocket();
            byte[] closeFrame = {0x88, 0x00};
            webSocket.Stream.Write(closeFrame, 0, closeFrame.Length);
            webSocket.Stream.Position = 0;

            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(new byte[1024]), CancellationToken.None);

            Assert.Equal(WebSocketMessageType.Close, result.MessageType);
        }

        /// <summary>
        ///     Creates an open web socket implementation over a memory stream
        /// </summary>
        /// <returns>The web socket implementation</returns>
        private static WebSocketImplementation CreateOpenSocket()
        {
            return new WebSocketImplementation(Guid.NewGuid(), () => new MemoryStream(), new MemoryStream(),
                TimeSpan.FromSeconds(30), null, false, true, null);
        }
    }
}
