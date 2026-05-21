

using System;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The web socket client options test class
    /// </summary>
    public class WebSocketClientOptionsTest
    {
        /// <summary>
        ///     Tests that web socket client options default constructor
        /// </summary>
        [Fact]
        public void WebSocketClientOptions_DefaultConstructor()
        {
            WebSocketClientOptions options = new WebSocketClientOptions();
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(20), options.KeepAliveInterval);
            Assert.True(options.NoDelay);
            Assert.NotNull(options.AdditionalHttpHeaders);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Null(options.SecWebSocketProtocol);
        }

        /// <summary>
        ///     Tests that web socket client options keep alive interval
        /// </summary>
        [Fact]
        public void WebSocketClientOptions_KeepAliveInterval()
        {
            WebSocketClientOptions options = new WebSocketClientOptions();
            options.KeepAliveInterval = TimeSpan.FromSeconds(30);
            Assert.Equal(TimeSpan.FromSeconds(30), options.KeepAliveInterval);
        }

        /// <summary>
        ///     Tests that web socket client options no delay
        /// </summary>
        [Fact]
        public void WebSocketClientOptions_NoDelay()
        {
            WebSocketClientOptions options = new WebSocketClientOptions();
            options.NoDelay = false;
            Assert.False(options.NoDelay);
        }

        /// <summary>
        ///     Tests that web socket client options additional http headers
        /// </summary>
        [Fact]
        public void WebSocketClientOptions_AdditionalHttpHeaders()
        {
            WebSocketClientOptions options = new WebSocketClientOptions();
            options.AdditionalHttpHeaders.Add("TestHeader", "TestValue");
            Assert.True(options.AdditionalHttpHeaders.ContainsKey("TestHeader"));
            Assert.Equal("TestValue", options.AdditionalHttpHeaders["TestHeader"]);
        }

        /// <summary>
        ///     Tests that web socket client options sec web socket protocol
        /// </summary>
        [Fact]
        public void WebSocketClientOptions_SecWebSocketProtocol()
        {
            WebSocketClientOptions options = new WebSocketClientOptions();
            options.SecWebSocketProtocol = "test";
            Assert.Equal("test", options.SecWebSocketProtocol);
        }

        /// <summary>
        ///     Tests that sec web socket extensions get returns expected value
        /// </summary>
        [Fact]
        public void SecWebSocketExtensions_Get_ReturnsExpectedValue()
        {
            WebSocketClientOptions webSocketClientOptions = new WebSocketClientOptions();
            Assert.Null(webSocketClientOptions.SecWebSocketExtensions);
        }
    }
}