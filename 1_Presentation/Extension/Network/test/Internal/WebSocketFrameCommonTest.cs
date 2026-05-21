

using System;
using Alis.Extension.Network.Exceptions;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The web socket frame common test class
    /// </summary>
    public class WebSocketFrameCommonTest
    {
        /// <summary>
        ///     Tests that toggle mask should not throw exception when mask key is valid
        /// </summary>
        [Fact]
        public void ToggleMask_ShouldNotThrowException_WhenMaskKeyIsValid()
        {
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[WebSocketFrameCommon.MaskKeyLength]);
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[10]);

            Exception exception = Record.Exception(() => WebSocketFrameCommon.ToggleMask(maskKey, payload));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that toggle mask should throw exception when mask key is invalid
        /// </summary>
        [Fact]
        public void ToggleMask_ShouldThrowException_WhenMaskKeyIsInvalid()
        {
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[WebSocketFrameCommon.MaskKeyLength - 1]);
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[10]);

            Assert.Throws<MaskKeyLengthException>(() => WebSocketFrameCommon.ToggleMask(maskKey, payload));
        }

        /// <summary>
        ///     Tests that toggle mask should change payload when called
        /// </summary>
        [Fact]
        public void ToggleMask_ShouldChangePayload_WhenCalled()
        {
            ArraySegment<byte> maskKey = new ArraySegment<byte>(new byte[WebSocketFrameCommon.MaskKeyLength] {1, 2, 3, 4});
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[4] {1, 2, 3, 4});
            ArraySegment<byte> expectedPayload = new ArraySegment<byte>(new byte[4] {0, 0, 0, 0});

            WebSocketFrameCommon.ToggleMask(maskKey, payload);

            Assert.Equal(expectedPayload, payload);
        }
    }
}