

using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The web socket http context test class
    /// </summary>
    public class WebSocketHttpContextTest
    {
        /// <summary>
        ///     Tests that web socket http context constructor
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_Constructor()
        {
            MemoryStream stream = new MemoryStream();
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string> {"protocol1"}, "GET / HTTP/1.1\r\n\r\n", "/test", stream);
            Assert.NotNull(context);
            Assert.True(context.IsWebSocketRequest);
            Assert.Contains("protocol1", context.WebSocketRequestedProtocols);
            Assert.Equal("GET / HTTP/1.1\r\n\r\n", context.HttpHeader);
            Assert.Equal("/test", context.Path);
            Assert.Equal(stream, context.Stream);
        }

        /// <summary>
        ///     Tests that web socket http context is web socket request
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_IsWebSocketRequest()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "", "", new MemoryStream());
            Assert.True(context.IsWebSocketRequest);
        }

        /// <summary>
        ///     Tests that web socket http context web socket requested protocols
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_WebSocketRequestedProtocols()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string> {"protocol1", "protocol2"}, "", "", new MemoryStream());
            Assert.Contains("protocol1", context.WebSocketRequestedProtocols);
            Assert.Contains("protocol2", context.WebSocketRequestedProtocols);
        }

        /// <summary>
        ///     Tests that web socket http context http header
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_HttpHeader()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string>(), "GET / HTTP/1.1\r\n\r\n", "", new MemoryStream());
            Assert.Equal("GET / HTTP/1.1\r\n\r\n", context.HttpHeader);
        }

        /// <summary>
        ///     Tests that web socket http context path
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_Path()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string>(), "", "/test", new MemoryStream());
            Assert.Equal("/test", context.Path);
        }

        /// <summary>
        ///     Tests that web socket http context stream
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_Stream()
        {
            MemoryStream stream = new MemoryStream();
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string>(), "", "", stream);
            Assert.Equal(stream, context.Stream);
        }
    }
}