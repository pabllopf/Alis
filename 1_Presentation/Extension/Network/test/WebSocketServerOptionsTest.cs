

using System;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The web socket server options test class
    /// </summary>
    public class WebSocketServerOptionsTest
    {
        /// <summary>
        ///     Tests that web socket server options default constructor
        /// </summary>
        [Fact]
        public void WebSocketServerOptions_DefaultConstructor()
        {
            WebSocketServerOptions options = new WebSocketServerOptions();
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(60), options.KeepAliveInterval);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Equal("", options.SubProtocol);
        }

        /// <summary>
        ///     Tests that web socket server options constructor with parameters
        /// </summary>
        [Fact]
        public void WebSocketServerOptions_ConstructorWithParameters()
        {
            WebSocketServerOptions options = new WebSocketServerOptions(30, true, "test");
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(30), options.KeepAliveInterval);
            Assert.True(options.IncludeExceptionInCloseResponse);
            Assert.Equal("test", options.SubProtocol);
        }

        /// <summary>
        ///     Tests that web socket server options constructor with time span and sub protocol
        /// </summary>
        [Fact]
        public void WebSocketServerOptions_ConstructorWithTimeSpanAndSubProtocol()
        {
            WebSocketServerOptions options = new WebSocketServerOptions(TimeSpan.FromSeconds(30), "test");
            Assert.NotNull(options);
            Assert.Equal(TimeSpan.FromSeconds(30), options.KeepAliveInterval);
            Assert.False(options.IncludeExceptionInCloseResponse);
            Assert.Equal("test", options.SubProtocol);
        }
    }
}