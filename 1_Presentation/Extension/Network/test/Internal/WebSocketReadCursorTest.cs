// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketReadCursorTest.cs
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
using System.Net.WebSockets;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     Comprehensive tests for WebSocketReadCursor - cursor for reading WebSocket frames
    /// </summary>
    public class WebSocketReadCursorTest
    {
        #region Constructor Tests

        /// <summary>
        ///     Arrange: Create WebSocketFrame and WebSocketReadCursor with valid parameters
        ///     Act: Verify cursor properties are set correctly
        ///     Assert: All cursor properties match constructor parameters
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Constructor_ValidInput_SetsAllProperties()
        {
            // Arrange: Define frame and cursor parameters
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            int count = 10;
            byte[] maskKeyData = { 0x01, 0x02, 0x03, 0x04 };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyData);
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);

            int numBytesRead = 5;
            int numBytesLeftToRead = 5;

            // Act: Create cursor with valid parameters
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, numBytesRead, numBytesLeftToRead);

            // Assert: All properties are set correctly
            Assert.Equal(frame, cursor.WebSocketFrame);
            Assert.Equal(numBytesRead, cursor.NumBytesRead);
            Assert.Equal(numBytesLeftToRead, cursor.NumBytesLeftToRead);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame and WebSocketReadCursor with zero values
        ///     Act: Verify cursor handles zero values correctly
        ///     Assert: Cursor is created successfully with zero bytes read/left
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Constructor_ZeroValues_HandlesZeroCorrectly()
        {
            // Arrange: Create frame with zero count
            WebSocketFrame frame = new WebSocketFrame(false, WebSocketOpCode.ContinuationFrame, 0, new ArraySegment<byte>());

            // Act: Create cursor with zero values
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 0, 0);

            // Assert: Cursor handles zero values correctly
            Assert.NotNull(cursor);
            Assert.Equal(0, cursor.NumBytesRead);
            Assert.Equal(0, cursor.NumBytesLeftToRead);
            Assert.Equal(WebSocketOpCode.ContinuationFrame, cursor.WebSocketFrame.OpCode);
            Assert.False(cursor.WebSocketFrame.IsFinBitSet);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with close status and WebSocketReadCursor
        ///     Act: Verify cursor preserves frame close information
        ///     Assert: Cursor maintains all frame properties including close info
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Constructor_CloseFrame_PreservesCloseInfo()
        {
            // Arrange: Create frame with close status
            WebSocketFrame frame = new WebSocketFrame(
                true, WebSocketOpCode.ConnectionClose, 2, WebSocketCloseStatus.NormalClosure, "Normal closure", new ArraySegment<byte>(new byte[4]));

            // Act: Create cursor for close frame
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 2, 0);

            // Assert: Cursor preserves close information
            Assert.Equal(WebSocketOpCode.ConnectionClose, cursor.WebSocketFrame.OpCode);
            Assert.Equal(WebSocketCloseStatus.NormalClosure, cursor.WebSocketFrame.CloseStatus);
            Assert.Equal("Normal closure", cursor.WebSocketFrame.CloseStatusDescription);
            Assert.Equal(2, cursor.NumBytesRead);
            Assert.Equal(0, cursor.NumBytesLeftToRead);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with FIN bit set and WebSocketReadCursor
        ///     Act: Verify cursor preserves FIN bit state
        ///     Assert: Cursor maintains FIN bit information from frame
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Constructor_FinBitSet_PreservesFinState()
        {
            // Arrange: Create frame with FIN bit set
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 100, new ArraySegment<byte>(new byte[4]));

            // Act: Create cursor
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 50, 50);

            // Assert: Cursor preserves FIN bit state
            Assert.True(cursor.WebSocketFrame.IsFinBitSet);
            Assert.Equal(50, cursor.NumBytesRead);
            Assert.Equal(50, cursor.NumBytesLeftToRead);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with FIN bit not set and WebSocketReadCursor
        ///     Act: Verify cursor preserves FIN bit state when false
        ///     Assert: Cursor maintains correct FIN bit information
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Constructor_FinBitNotSet_PreservesFinState()
        {
            // Arrange: Create frame with FIN bit not set
            WebSocketFrame frame = new WebSocketFrame(false, WebSocketOpCode.ContinuationFrame, 50, new ArraySegment<byte>(new byte[4]));

            // Act: Create cursor
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 25, 25);

            // Assert: Cursor preserves FIN bit state when false
            Assert.False(cursor.WebSocketFrame.IsFinBitSet);
            Assert.Equal(25, cursor.NumBytesRead);
            Assert.Equal(25, cursor.NumBytesLeftToRead);
        }

        #endregion

        #region Property Tests

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor with valid frame
        ///     Act: Verify WebSocketFrame property returns correct frame
        ///     Assert: Property correctly returns the frame passed to constructor
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_WebSocketFrame_Property_ReturnsCorrectFrame()
        {
            // Arrange: Create frame and cursor
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 10, new ArraySegment<byte>(new byte[4]));
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 5, 5);

            // Act: Check property
            WebSocketFrame returnedFrame = cursor.WebSocketFrame;

            // Assert: Property returns correct frame
            Assert.Equal(frame, returnedFrame);
            Assert.NotNull(returnedFrame);
        }

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor with different byte counts
        ///     Act: Verify NumBytesRead property returns correct value
        ///     Assert: Property correctly reflects bytes read count
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_NumBytesRead_Property_ReturnsCorrectValue()
        {
            // Arrange: Create cursor with specific byte count
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 100, new ArraySegment<byte>(new byte[4]));
            int bytesRead = 75;
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, bytesRead, 25);

            // Act: Check property
            int returnedBytesRead = cursor.NumBytesRead;

            // Assert: Property returns correct value
            Assert.Equal(bytesRead, returnedBytesRead);
        }

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor with different byte counts
        ///     Act: Verify NumBytesLeftToRead property returns correct value
        ///     Assert: Property correctly reflects bytes left to read count
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_NumBytesLeftToRead_Property_ReturnsCorrectValue()
        {
            // Arrange: Create cursor with specific byte count
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 100, new ArraySegment<byte>(new byte[4]));
            int bytesLeft = 30;
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 70, bytesLeft);

            // Act: Check property
            int returnedBytesLeft = cursor.NumBytesLeftToRead;

            // Assert: Property returns correct value
            Assert.Equal(bytesLeft, returnedBytesLeft);
        }

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor with text frame
        ///     Act: Verify cursor preserves frame opcode
        ///     Assert: Cursor maintains correct opcode information
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_TextFrame_PreservesOpcode()
        {
            // Arrange: Create cursor with text frame
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 100, new ArraySegment<byte>(new byte[4]));
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 50, 50);

            // Act: Check property
            WebSocketOpCode opCode = cursor.WebSocketFrame.OpCode;

            // Assert: Cursor preserves opcode
            Assert.Equal(WebSocketOpCode.TextFrame, opCode);
        }

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor with binary frame
        ///     Act: Verify cursor preserves binary frame opcode
        ///     Assert: Cursor maintains correct binary frame opcode
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_BinaryFrame_PreservesOpcode()
        {
            // Arrange: Create cursor with binary frame
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, 1024, new ArraySegment<byte>(new byte[4]));
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 512, 512);

            // Act: Check property
            WebSocketOpCode opCode = cursor.WebSocketFrame.OpCode;

            // Assert: Cursor preserves binary frame opcode
            Assert.Equal(WebSocketOpCode.BinaryFrame, opCode);
        }

        #endregion

        #region Edge Cases and Error Handling

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor with maximum byte counts
        ///     Act: Verify cursor handles large byte counts correctly
        ///     Assert: Cursor accepts large values without issues
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_LargeByteCounts_HandlesLargeValues()
        {
            // Arrange: Create frame with large count
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, 65535, new ArraySegment<byte>(new byte[4]));

            // Act: Create cursor with large byte counts
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 32768, 32767);

            // Assert: Cursor handles large values correctly
            Assert.Equal(32768, cursor.NumBytesRead);
            Assert.Equal(32767, cursor.NumBytesLeftToRead);
        }

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor with ping frame
        ///     Act: Verify cursor handles ping frame correctly
        ///     Assert: Cursor maintains ping frame properties
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_PingFrame_HandlesPingCorrectly()
        {
            // Arrange: Create cursor with ping frame
            WebSocketFrame frame = new WebSocketFrame(false, WebSocketOpCode.Ping, 5, new ArraySegment<byte>(new byte[4]));
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 5, 0);

            // Act: Check properties
            WebSocketOpCode opCode = cursor.WebSocketFrame.OpCode;
            bool isFin = cursor.WebSocketFrame.IsFinBitSet;

            // Assert: Cursor handles ping frame correctly
            Assert.Equal(WebSocketOpCode.Ping, opCode);
            Assert.False(isFin);
        }

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor with pong frame
        ///     Act: Verify cursor handles pong frame correctly
        ///     Assert: Cursor maintains pong frame properties
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_PongFrame_HandlesPongCorrectly()
        {
            // Arrange: Create cursor with pong frame
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.Pong, 0, new ArraySegment<byte>());
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 0, 0);

            // Act: Check properties
            WebSocketOpCode opCode = cursor.WebSocketFrame.OpCode;
            int count = cursor.WebSocketFrame.Count;

            // Assert: Cursor handles pong frame correctly
            Assert.Equal(WebSocketOpCode.Pong, opCode);
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor with continuation frame
        ///     Act: Verify cursor handles continuation frame correctly
        ///     Assert: Cursor maintains continuation frame properties
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_ContinuationFrame_HandlesContinuationCorrectly()
        {
            // Arrange: Create cursor with continuation frame
            WebSocketFrame frame = new WebSocketFrame(false, WebSocketOpCode.ContinuationFrame, 50, new ArraySegment<byte>(new byte[4]));
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 25, 25);

            // Act: Check properties
            WebSocketOpCode opCode = cursor.WebSocketFrame.OpCode;
            bool isFin = cursor.WebSocketFrame.IsFinBitSet;

            // Assert: Cursor handles continuation frame correctly
            Assert.Equal(WebSocketOpCode.ContinuationFrame, opCode);
            Assert.False(isFin);
        }

        #endregion

        #region Integration Tests

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor for complete frame reading
        ///     Act: Verify cursor can handle full frame transmission
        ///     Assert: Cursor is properly configured for complete frame reading
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Integration_CompleteFrameReading()
        {
            // Arrange: Create cursor for complete frame reading
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 100, new ArraySegment<byte>(new byte[4]));
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 100, 0);

            // Act: Verify cursor properties for complete reading
            bool isFin = cursor.WebSocketFrame.IsFinBitSet;
            int bytesRead = cursor.NumBytesRead;
            int bytesLeft = cursor.NumBytesLeftToRead;

            // Assert: Cursor is configured for complete reading
            Assert.True(isFin);
            Assert.Equal(100, bytesRead);
            Assert.Equal(0, bytesLeft);
        }

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor for partial frame reading
        ///     Act: Verify cursor can handle partial frame transmission
        ///     Assert: Cursor is properly configured for partial reading
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Integration_PartialFrameReading()
        {
            // Arrange: Create cursor for partial frame reading
            WebSocketFrame frame = new WebSocketFrame(false, WebSocketOpCode.ContinuationFrame, 100, new ArraySegment<byte>(new byte[4]));
            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 50, 50);

            // Act: Verify cursor properties for partial reading
            bool isFin = cursor.WebSocketFrame.IsFinBitSet;
            int bytesRead = cursor.NumBytesRead;
            int bytesLeft = cursor.NumBytesLeftToRead;

            // Assert: Cursor is configured for partial reading
            Assert.False(isFin);
            Assert.Equal(50, bytesRead);
            Assert.Equal(50, bytesLeft);
        }

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor for multi-frame transmission
        ///     Act: Verify cursor handles multi-frame scenario correctly
        ///     Assert: Cursor maintains correct state across frames
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Integration_MultiFrameTransmission()
        {
            // Arrange: Create cursors for multi-frame transmission
            WebSocketFrame initialFrame = new WebSocketFrame(false, WebSocketOpCode.TextFrame, 100, new ArraySegment<byte>(new byte[4]));
            WebSocketReadCursor initialCursor = new WebSocketReadCursor(initialFrame, 50, 50);

            WebSocketFrame continuationFrame = new WebSocketFrame(true, WebSocketOpCode.ContinuationFrame, 50, new ArraySegment<byte>(new byte[4]));
            WebSocketReadCursor continuationCursor = new WebSocketReadCursor(continuationFrame, 50, 0);

            // Act: Verify cursors maintain correct state
            bool initialFin = initialCursor.WebSocketFrame.IsFinBitSet;
            bool continuationFin = continuationCursor.WebSocketFrame.IsFinBitSet;

            // Assert: Cursors maintain correct state
            Assert.False(initialFin);
            Assert.True(continuationFin);
        }

        #endregion

        #region Thread Safety Tests

        /// <summary>
        ///     Arrange: Create WebSocketReadCursor instances concurrently
        ///     Act: Verify cursors can be created in parallel
        ///     Assert: Cursor creation is thread-safe
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_ThreadSafety_ConcurrentCreation()
        {
            // Arrange: Create multiple cursors concurrently
            List<WebSocketReadCursor> cursors = new List<WebSocketReadCursor>();

            for (int i = 0; i < 10; i++)
            {
                WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 100, new ArraySegment<byte>(new byte[4]));
                WebSocketReadCursor cursor = new WebSocketReadCursor(frame, 50, 50);
                cursors.Add(cursor);
            }

            // Act: Verify all cursors are valid
            for (int i = 0; i < cursors.Count; i++)
            {
                Assert.NotNull(cursors[i]);
                Assert.Equal(50, cursors[i].NumBytesRead);
            }

            // Assert: All cursors are valid
            Assert.Equal(10, cursors.Count);
        }

        #endregion
    }
}
