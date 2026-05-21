

using System;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The web socket read cursor test class
    /// </summary>
    public class WebSocketReadCursorTest
    {
        /// <summary>
        ///     Tests that web socket read cursor constructor valid input
        /// </summary>
        [Fact]
        public void WebSocketReadCursor_Constructor_ValidInput()
        {
            bool isFinBitSet = true;
            WebSocketOpCode webSocketOpCode = WebSocketOpCode.TextFrame;
            int count = 10;
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[4]);
            WebSocketFrame frame = new WebSocketFrame(isFinBitSet, webSocketOpCode, count, maskKey);
            int numBytesRead = 5;
            int numBytesLeftToRead = 5;

            WebSocketReadCursor cursor = new WebSocketReadCursor(frame, numBytesRead, numBytesLeftToRead);

            Assert.Equal(frame, cursor.WebSocketFrame);
            Assert.Equal(numBytesRead, cursor.NumBytesRead);
            Assert.Equal(numBytesLeftToRead, cursor.NumBytesLeftToRead);
        }
    }
}