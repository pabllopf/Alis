// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameReaderRemainingCoverageTests.cs
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
    ///     Coverage tests for WebSocketFrameReader targeting uncovered branches.
    /// </summary>
    public class WebSocketFrameReaderRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that ReadFromCursorAsync applies mask when cursor frame has mask key.
        /// </summary>
        [Fact]
        public async Task ReadFromCursorAsync_WithMaskKey_AppliesMask()
        {
            byte[] maskKeyBytes = { 0x01, 0x02, 0x03, 0x04 };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyBytes);
            byte[] originalPayload = Encoding.UTF8.GetBytes("HelloWorld");
            byte[] maskedPayload = new byte[originalPayload.Length];
            for (int i = 0; i < originalPayload.Length; i++)
            {
                maskedPayload[i] = (byte)(originalPayload[i] ^ maskKeyBytes[i % 4]);
            }

            using MemoryStream stream = new MemoryStream(maskedPayload);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = CancellationToken.None;

            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, originalPayload.Length, maskKey);
            WebSocketReadCursor readCursor = new WebSocketReadCursor(frame, 0, originalPayload.Length);

            WebSocketReadCursor result = await WebSocketFrameReader.ReadFromCursorAsync(stream, buffer, readCursor, cancellationToken);

            Assert.NotNull(result);
            Assert.Equal(WebSocketOpCode.TextFrame, result.WebSocketFrame.OpCode);
            Assert.Equal(originalPayload.Length, result.NumBytesRead);

            byte[] unmasked = new byte[originalPayload.Length];
            Array.Copy(buffer.Array, buffer.Offset, unmasked, 0, originalPayload.Length);
            Assert.Equal(originalPayload, unmasked);
        }

        /// <summary>
        ///     Tests that ReadAsync correctly reads a masked WebSocket frame.
        /// </summary>
        [Fact]
        public async Task ReadAsync_MaskedFrame_ReadsCorrectly()
        {
            byte[] maskKey = { 0x0A, 0x0B, 0x0C, 0x0D };
            byte[] payload = Encoding.UTF8.GetBytes("Hello");
            byte[] maskedPayload = new byte[payload.Length];
            for (int i = 0; i < payload.Length; i++)
            {
                maskedPayload[i] = (byte)(payload[i] ^ maskKey[i % 4]);
            }

            byte[] frameBytes = new byte[2 + maskKey.Length + payload.Length];
            frameBytes[0] = 0x81;
            frameBytes[1] = (byte)(0x80 | payload.Length);
            Array.Copy(maskKey, 0, frameBytes, 2, maskKey.Length);
            Array.Copy(maskedPayload, 0, frameBytes, 6, payload.Length);

            using MemoryStream stream = new MemoryStream(frameBytes);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = CancellationToken.None;

            WebSocketReadCursor result = await WebSocketFrameReader.ReadAsync(stream, buffer, cancellationToken);

            Assert.NotNull(result);
            Assert.True(result.WebSocketFrame.IsFinBitSet);
            Assert.Equal(WebSocketOpCode.TextFrame, result.WebSocketFrame.OpCode);
            Assert.Equal(payload.Length, result.NumBytesRead);

            byte[] readPayload = new byte[payload.Length];
            Array.Copy(buffer.Array, buffer.Offset, readPayload, 0, payload.Length);
            Assert.Equal(payload, readPayload);
        }

        /// <summary>
        ///     Tests that ReadAsync with ConnectionClose frame returns decoded close frame.
        /// </summary>
        [Fact]
        public async Task ReadAsync_ConnectionCloseFrame_ReturnsDecodedFrame()
        {
            ushort statusCode = 1000;
            byte[] statusBytes = BitConverter.GetBytes(statusCode);
            Array.Reverse(statusBytes);

            byte[] frameBytes = new byte[2 + statusBytes.Length];
            frameBytes[0] = 0x88;
            frameBytes[1] = (byte)statusBytes.Length;
            Array.Copy(statusBytes, 0, frameBytes, 2, statusBytes.Length);

            using MemoryStream stream = new MemoryStream(frameBytes);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = CancellationToken.None;

            WebSocketReadCursor result = await WebSocketFrameReader.ReadAsync(stream, buffer, cancellationToken);

            Assert.NotNull(result);
            Assert.Equal(WebSocketOpCode.ConnectionClose, result.WebSocketFrame.OpCode);
            Assert.True(result.WebSocketFrame.IsFinBitSet);
            Assert.Equal(WebSocketCloseStatus.NormalClosure, result.WebSocketFrame.CloseStatus);
        }

        /// <summary>
        ///     Tests that DecodeCloseFrame returns Empty status for undefined close status code.
        /// </summary>
        [Fact]
        public void DecodeCloseFrame_WithUndefinedCloseStatus_ReturnsEmptyStatus()
        {
            ushort undefinedStatus = 3000;
            byte[] statusBytes = BitConverter.GetBytes(undefinedStatus);
            Array.Reverse(statusBytes);

            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2]);
            buffer.Array[0] = statusBytes[0];
            buffer.Array[1] = statusBytes[1];
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);

            WebSocketFrame result = WebSocketFrameReader.DecodeCloseFrame(true, WebSocketOpCode.ConnectionClose, 2, buffer, maskKey);

            Assert.NotNull(result);
            Assert.Equal(WebSocketCloseStatus.Empty, result.CloseStatus);
            Assert.Null(result.CloseStatusDescription);
        }

        /// <summary>
        ///     Tests that DecodeCloseFrame returns description when count > 2.
        /// </summary>
        [Fact]
        public void DecodeCloseFrame_WithDescription_ReturnsDescription()
        {
            ushort statusCode = 1000;
            string description = "Normal";
            byte[] statusBytes = BitConverter.GetBytes(statusCode);
            Array.Reverse(statusBytes);
            byte[] descBytes = Encoding.UTF8.GetBytes(description);
            int totalCount = 2 + descBytes.Length;

            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[totalCount]);
            Array.Copy(statusBytes, 0, buffer.Array, 0, 2);
            Array.Copy(descBytes, 0, buffer.Array, 2, descBytes.Length);
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);

            WebSocketFrame result = WebSocketFrameReader.DecodeCloseFrame(true, WebSocketOpCode.ConnectionClose, totalCount, buffer, maskKey);

            Assert.NotNull(result);
            Assert.Equal(WebSocketCloseStatus.NormalClosure, result.CloseStatus);
            Assert.Equal(description, result.CloseStatusDescription);
        }

        /// <summary>
        ///     Tests that ReadAsync with ConnectionClose frame including description returns decoded frame.
        /// </summary>
        [Fact]
        public async Task ReadAsync_ConnectionCloseFrameWithDescription_ReturnsDecodedFrame()
        {
            ushort statusCode = 1000;
            string description = "Normal";
            byte[] statusBytes = BitConverter.GetBytes(statusCode);
            Array.Reverse(statusBytes);
            byte[] descBytes = Encoding.UTF8.GetBytes(description);
            int payloadLen = 2 + descBytes.Length;

            byte[] frameBytes = new byte[2 + payloadLen];
            frameBytes[0] = 0x88;
            frameBytes[1] = (byte)payloadLen;
            Array.Copy(statusBytes, 0, frameBytes, 2, 2);
            Array.Copy(descBytes, 0, frameBytes, 4, descBytes.Length);

            using MemoryStream stream = new MemoryStream(frameBytes);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = CancellationToken.None;

            WebSocketReadCursor result = await WebSocketFrameReader.ReadAsync(stream, buffer, cancellationToken);

            Assert.NotNull(result);
            Assert.Equal(WebSocketOpCode.ConnectionClose, result.WebSocketFrame.OpCode);
            Assert.Equal(WebSocketCloseStatus.NormalClosure, result.WebSocketFrame.CloseStatus);
            Assert.Equal(description, result.WebSocketFrame.CloseStatusDescription);
        }
    }
}
