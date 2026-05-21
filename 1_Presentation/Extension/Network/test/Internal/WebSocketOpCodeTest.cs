

using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The web socket op code test class
    /// </summary>
    public class WebSocketOpCodeTest
    {
        /// <summary>
        ///     Tests that web socket op code values
        /// </summary>
        [Fact]
        public void WebSocketOpCode_Values()
        {
            Assert.Equal(0, (int) WebSocketOpCode.ContinuationFrame);
            Assert.Equal(1, (int) WebSocketOpCode.TextFrame);
            Assert.Equal(2, (int) WebSocketOpCode.BinaryFrame);
            Assert.Equal(8, (int) WebSocketOpCode.ConnectionClose);
            Assert.Equal(9, (int) WebSocketOpCode.Ping);
            Assert.Equal(10, (int) WebSocketOpCode.Pong);
        }
    }
}