// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameTest.cs
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
using System.Net.WebSockets;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     Comprehensive tests for WebSocketFrame - WebSocket frame implementation for communication
    /// </summary>
    public class WebSocketFrameTest
    {
        #region Constructor Tests

        /// <summary>
        ///     Arrange: Create WebSocketFrame with all parameters using constructor 1
        ///     Act: Verify frame properties are set correctly
        ///     Assert: All frame properties match constructor parameters
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor1_ValidInput_SetsAllProperties()
        {
            // Arrange: Define frame parameters
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            int count = 10;
            byte[] maskKeyData = { 0x01, 0x02, 0x03, 0x04 };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyData);

            // Act: Create frame with constructor 1
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);

            // Assert: All properties are set correctly
            Assert.True(frame.IsFinBitSet);
            Assert.Equal(webSocketOpCode, frame.OpCode);
            Assert.Equal(count, frame.Count);
            Assert.Equal(maskKey, frame.MaskKey);
            Assert.Null(frame.CloseStatus);
            Assert.Null(frame.CloseStatusDescription);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with all parameters using constructor 2
        ///     Act: Verify frame properties including close status are set correctly
        ///     Assert: All frame properties match constructor parameters including close info
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor2_ValidInput_SetsAllPropertiesIncludingClose()
        {
            // Arrange: Define frame parameters with close status
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.ConnectionClose;
            int count = 2;
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure;
            string closeStatusDescription = "Normal closure";
            byte[] maskKeyData = { 0x01, 0x02, 0x03, 0x04 };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyData);

            // Act: Create frame with constructor 2
            WebSocketFrame frame = new WebSocketFrame(
                isFinBitSet, webSocketOpCode, count, closeStatus, closeStatusDescription, maskKey);

            // Assert: All properties including close info are set correctly
            Assert.True(frame.IsFinBitSet);
            Assert.Equal(webSocketOpCode, frame.OpCode);
            Assert.Equal(count, frame.Count);
            Assert.Equal(closeStatus, frame.CloseStatus);
            Assert.Equal(closeStatusDescription, frame.CloseStatusDescription);
            Assert.Equal(maskKey, frame.MaskKey);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with TextFrame opcode
        ///     Act: Verify frame properties for text message
        ///     Assert: Frame is configured correctly for text transmission
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor_TextFrame_IsConfiguredCorrectly()
        {
            // Arrange: Define text frame parameters
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            int count = 100;
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);

            // Act: Create text frame
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);

            // Assert: Frame is configured for text transmission
            Assert.True(frame.IsFinBitSet);
            Assert.Equal(WebSocketOpCode.TextFrame, frame.OpCode);
            Assert.Equal(100, frame.Count);
            Assert.Null(frame.CloseStatus);
            Assert.Null(frame.CloseStatusDescription);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with BinaryFrame opcode
        ///     Act: Verify frame properties for binary message
        ///     Assert: Frame is configured correctly for binary transmission
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor_BinaryFrame_IsConfiguredCorrectly()
        {
            // Arrange: Define binary frame parameters
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.BinaryFrame;
            int count = 1024;
            byte[] maskKeyData = { 0xAA, 0xBB, 0xCC, 0xDD };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyData);

            // Act: Create binary frame
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);

            // Assert: Frame is configured for binary transmission
            Assert.True(frame.IsFinBitSet);
            Assert.Equal(WebSocketOpCode.BinaryFrame, frame.OpCode);
            Assert.Equal(1024, frame.Count);
            Assert.Null(frame.CloseStatus);
            Assert.Null(frame.CloseStatusDescription);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with Ping opcode
        ///     Act: Verify frame properties for ping message
        ///     Assert: Frame is configured correctly for ping operation
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor_PingFrame_IsConfiguredCorrectly()
        {
            // Arrange: Define ping frame parameters
            bool isFinBitSet = false;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.Ping;
            int count = 5;
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);

            // Act: Create ping frame
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);

            // Assert: Frame is configured for ping operation
            Assert.False(frame.IsFinBitSet);
            Assert.Equal(WebSocketOpCode.Ping, frame.OpCode);
            Assert.Equal(5, frame.Count);
            Assert.Null(frame.CloseStatus);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with Pong opcode
        ///     Act: Verify frame properties for pong message
        ///     Assert: Frame is configured correctly for pong operation
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor_PongFrame_IsConfiguredCorrectly()
        {
            // Arrange: Define pong frame parameters
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.Pong;
            int count = 0;
            ArraySegment<byte> maskKey = new ArraySegment<byte>();

            // Act: Create pong frame
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);

            // Assert: Frame is configured for pong operation
            Assert.True(frame.IsFinBitSet);
            Assert.Equal(WebSocketOpCode.Pong, frame.OpCode);
            Assert.Equal(0, frame.Count);
            Assert.Equal(0, frame.MaskKey.Count);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with ConnectionClose opcode and status
        ///     Act: Verify frame properties for connection close
        ///     Assert: Frame includes close status and description
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor_ConnectionClose_IncludesCloseInfo()
        {
            // Arrange: Define connection close frame parameters
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.ConnectionClose;
            int count = 2;
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure;
            string closeStatusDescription = "Going away";
            byte[] maskKeyData = { 0x01, 0x02, 0x03, 0x04 };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyData);

            // Act: Create connection close frame
            WebSocketFrame frame = new WebSocketFrame(
                isFinBitSet, webSocketOpCode, count, closeStatus, closeStatusDescription, maskKey);

            // Assert: Frame includes close information
            Assert.True(frame.IsFinBitSet);
            Assert.Equal(WebSocketOpCode.ConnectionClose, frame.OpCode);
            Assert.Equal(2, frame.Count);
            Assert.Equal(closeStatus, frame.CloseStatus);
            Assert.Equal(closeStatusDescription, frame.CloseStatusDescription);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with ContinuationFrame opcode
        ///     Act: Verify frame properties for continuation message
        ///     Assert: Frame is configured correctly for continuation
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor_ContinuationFrame_IsConfiguredCorrectly()
        {
            // Arrange: Define continuation frame parameters
            bool isFinBitSet = false;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.ContinuationFrame;
            int count = 50;
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);

            // Act: Create continuation frame
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);

            // Assert: Frame is configured for continuation
            Assert.False(frame.IsFinBitSet);
            Assert.Equal(WebSocketOpCode.ContinuationFrame, frame.OpCode);
            Assert.Equal(50, frame.Count);
            Assert.Null(frame.CloseStatus);
        }

        #endregion

        #region Property Tests

        /// <summary>
        ///     Arrange: Create WebSocketFrame with FIN bit set to false
        ///     Act: Verify IsFinBitSet property returns correct value
        ///     Assert: Property correctly reflects FIN bit state
        /// </summary>
        [Fact]
        public void WebSocketFrame_IsFinBitSet_Property_ReturnsCorrectValue()
        {
            // Arrange: Create frame with FIN bit false
            WebSocketFrame frame = new WebSocketFrame(false, WebSocketOpCode.TextFrame, 10, new ArraySegment<byte>());

            // Act: Check property
            bool isFin = frame.IsFinBitSet;

            // Assert: Property returns correct value
            Assert.False(isFin);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with different opcodes
        ///     Act: Verify OpCode property for each opcode type
        ///     Assert: Property correctly reflects opcode
        /// </summary>
        [Fact]
        public void WebSocketFrame_OpCode_Property_ReturnsCorrectValue()
        {
            // Arrange: Create frames with different opcodes
            WebSocketFrame textFrame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 10, new ArraySegment<byte>());
            WebSocketFrame binaryFrame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, 10, new ArraySegment<byte>());
            WebSocketFrame pingFrame = new WebSocketFrame(false, WebSocketOpCode.Ping, 5, new ArraySegment<byte>());

            // Act: Check properties
            WebSocketOpCode textOpCode = textFrame.OpCode;
            WebSocketOpCode binaryOpCode = binaryFrame.OpCode;
            WebSocketOpCode pingOpCode = pingFrame.OpCode;

            // Assert: Properties return correct values
            Assert.Equal(WebSocketOpCode.TextFrame, textOpCode);
            Assert.Equal(WebSocketOpCode.BinaryFrame, binaryOpCode);
            Assert.Equal(WebSocketOpCode.Ping, pingOpCode);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with different counts
        ///     Act: Verify Count property for each frame
        ///     Assert: Property correctly reflects payload count
        /// </summary>
        [Fact]
        public void WebSocketFrame_Count_Property_ReturnsCorrectValue()
        {
            // Arrange: Create frames with different counts
            WebSocketFrame frame1 = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 0, new ArraySegment<byte>());
            WebSocketFrame frame2 = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 125, new ArraySegment<byte>());
            WebSocketFrame frame3 = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 65535, new ArraySegment<byte>());

            // Act: Check properties
            int count1 = frame1.Count;
            int count2 = frame2.Count;
            int count3 = frame3.Count;

            // Assert: Properties return correct values
            Assert.Equal(0, count1);
            Assert.Equal(125, count2);
            Assert.Equal(65535, count3);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with mask key
        ///     Act: Verify MaskKey property returns correct segment
        ///     Assert: Property correctly reflects mask key
        /// </summary>
        [Fact]
        public void WebSocketFrame_MaskKey_Property_ReturnsCorrectValue()
        {
            // Arrange: Create frame with mask key
            byte[] maskKeyData = { 0x12, 0x34, 0x56, 0x78 };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyData);
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 10, maskKey);

            // Act: Check property
            ArraySegment<byte> returnedMaskKey = frame.MaskKey;

            // Assert: Property returns correct mask key
            Assert.Equal(maskKey, returnedMaskKey);
            Assert.Equal(4, returnedMaskKey.Count);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame without close status
        ///     Act: Verify CloseStatus property returns null
        ///     Assert: Property correctly reflects absence of close status
        /// </summary>
        [Fact]
        public void WebSocketFrame_CloseStatus_Property_ReturnsNullWhenNotSet()
        {
            // Arrange: Create frame without close status
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 10, new ArraySegment<byte>());

            // Act: Check property
            WebSocketCloseStatus? closeStatus = frame.CloseStatus;

            // Assert: Property returns null
            Assert.Null(closeStatus);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with close status description
        ///     Act: Verify CloseStatusDescription property returns correct value
        ///     Assert: Property correctly reflects close status description
        /// </summary>
        [Fact]
        public void WebSocketFrame_CloseStatusDescription_Property_ReturnsCorrectValue()
        {
            // Arrange: Create frame with close status description
            string description = "Normal closure - client going away";
            WebSocketFrame frame = new WebSocketFrame(
                true, WebSocketOpCode.ConnectionClose, 2, WebSocketCloseStatus.NormalClosure, description, new ArraySegment<byte>());

            // Act: Check property
            string returnedDescription = frame.CloseStatusDescription;

            // Assert: Property returns correct description
            Assert.Equal(description, returnedDescription);
        }

        #endregion

        #region Edge Cases and Error Handling

        /// <summary>
        ///     Arrange: Create WebSocketFrame with zero count and empty mask key
        ///     Act: Verify frame handles edge case correctly
        ///     Assert: Frame is created successfully with minimal parameters
        /// </summary>
        [Fact]
        public void WebSocketFrame_ZeroCountAndEmptyMaskKey_HandlesEdgeCase()
        {
            // Arrange: Create frame with minimal parameters
            WebSocketFrame frame = new WebSocketFrame(false, WebSocketOpCode.ContinuationFrame, 0, new ArraySegment<byte>());

            // Act: Check properties
            bool isFin = frame.IsFinBitSet;
            WebSocketOpCode opCode = frame.OpCode;
            int count = frame.Count;

            // Assert: Frame handles edge case correctly
            Assert.False(isFin);
            Assert.Equal(WebSocketOpCode.ContinuationFrame, opCode);
            Assert.Equal(0, count);
            Assert.Equal(0, frame.MaskKey.Count);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame with maximum count value
        ///     Act: Verify frame handles large count correctly
        ///     Assert: Frame accepts large count values
        /// </summary>
        [Fact]
        public void WebSocketFrame_LargeCount_HandlesLargeValues()
        {
            // Arrange: Create frame with large count
            int largeCount = 125; // WebSocket max for 7-bit length
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, largeCount, new ArraySegment<byte>(new byte[4]));

            // Act: Check property
            int count = frame.Count;

            // Assert: Frame handles large count
            Assert.Equal(largeCount, count);
        }

    

        #endregion

        #region Integration Tests

        /// <summary>
        ///     Arrange: Create WebSocketFrame with all parameters
        ///     Act: Verify frame can be used for WebSocket communication
        ///     Assert: Frame is properly configured for transmission
        /// </summary>
        [Fact]
        public void WebSocketFrame_Integration_TextMessageTransmission()
        {
            // Arrange: Create text frame for message transmission
            byte[] maskKeyData = { 0x01, 0x02, 0x03, 0x04 };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyData);
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.TextFrame, 100, maskKey);

            // Act: Verify frame properties for transmission
            bool isFin = frame.IsFinBitSet;
            WebSocketOpCode opCode = frame.OpCode;
            int count = frame.Count;

            // Assert: Frame is properly configured for text transmission
            Assert.True(isFin);
            Assert.Equal(WebSocketOpCode.TextFrame, opCode);
            Assert.Equal(100, count);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame for binary data transmission
        ///     Act: Verify frame can handle binary message
        ///     Assert: Frame is properly configured for binary transmission
        /// </summary>
        [Fact]
        public void WebSocketFrame_Integration_BinaryMessageTransmission()
        {
            // Arrange: Create binary frame for data transmission
            byte[] maskKeyData = { 0xAA, 0xBB, 0xCC, 0xDD };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyData);
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, 1024, maskKey);

            // Act: Verify frame properties for transmission
            bool isFin = frame.IsFinBitSet;
            WebSocketOpCode opCode = frame.OpCode;
            int count = frame.Count;

            // Assert: Frame is properly configured for binary transmission
            Assert.True(isFin);
            Assert.Equal(WebSocketOpCode.BinaryFrame, opCode);
            Assert.Equal(1024, count);
        }

        /// <summary>
        ///     Arrange: Create WebSocketFrame for connection management
        ///     Act: Verify frame handles connection close properly
        ///     Assert: Frame includes all necessary close information
        /// </summary>
        [Fact]
        public void WebSocketFrame_Integration_ConnectionManagement()
        {
            // Arrange: Create connection close frame
            byte[] maskKeyData = { 0x01, 0x02, 0x03, 0x04 };
            ArraySegment<byte> maskKey = new ArraySegment<byte>(maskKeyData);
            WebSocketFrame frame = new WebSocketFrame(
                true, WebSocketOpCode.ConnectionClose, 2, WebSocketCloseStatus.NormalClosure, "Normal closure", maskKey);

            // Act: Verify frame properties for connection management
            bool isFin = frame.IsFinBitSet;
            WebSocketOpCode opCode = frame.OpCode;
            WebSocketCloseStatus? closeStatus = frame.CloseStatus;
            string description = frame.CloseStatusDescription;

            // Assert: Frame includes all close information
            Assert.True(isFin);
            Assert.Equal(WebSocketOpCode.ConnectionClose, opCode);
            Assert.Equal(WebSocketCloseStatus.NormalClosure, closeStatus);
            Assert.Equal("Normal closure", description);
        }

        #endregion
    }
}
