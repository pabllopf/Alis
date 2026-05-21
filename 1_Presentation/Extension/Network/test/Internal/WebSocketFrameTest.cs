

using System;
using System.Net.WebSockets;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The web socket frame test class
    /// </summary>
    public class WebSocketFrameTest
    {
        /// <summary>
        ///     Tests that web socket frame constructor 1 valid input
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor1_ValidInput()
        {
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            int count = 10;
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);

            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);

            Assert.True(frame.IsFinBitSet);
            Assert.Equal(webSocketOpCode, frame.OpCode);
            Assert.Equal(count, frame.Count);
            Assert.Equal(maskKey, frame.MaskKey);
        }

        /// <summary>
        ///     Tests that web socket frame constructor 2 valid input
        /// </summary>
        [Fact]
        public void WebSocketFrame_Constructor2_ValidInput()
        {
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            int count = 10;
            WebSocketCloseStatus closeStatus = WebSocketCloseStatus.NormalClosure;
            string closeStatusDescription = "Test description";
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);

            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, closeStatus, closeStatusDescription, maskKey);

            Assert.True(frame.IsFinBitSet);
            Assert.Equal(webSocketOpCode, frame.OpCode);
            Assert.Equal(count, frame.Count);
            Assert.Equal(closeStatus, frame.CloseStatus);
            Assert.Equal(closeStatusDescription, frame.CloseStatusDescription);
            Assert.Equal(maskKey, frame.MaskKey);
        }
    }
}