// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketHttpContextTest.cs
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
          [Fact]
        public void Constructor_SetsAllProperties()
        {
            bool isWebSocketRequest = true;
            List<string> subProtocols = new List<string> { "chat", "json" };
            string httpHeader = "GET /chat HTTP/1.1\r\nHost: example.com\r\n\r\n";
            string path = "/chat";
            MemoryStream stream = new MemoryStream();

            WebSocketHttpContext context = new WebSocketHttpContext(isWebSocketRequest, subProtocols, httpHeader, path, stream);

            Assert.True(context.IsWebSocketRequest);
            Assert.Equal(subProtocols, context.WebSocketRequestedProtocols);
            Assert.Equal(httpHeader, context.HttpHeader);
            Assert.Equal(path, context.Path);
            Assert.Same(stream, context.Stream);
        }

        [Fact]
        public void Constructor_WithFalseIsWebSocketRequest_SetsProperty()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string>(), "header", "/path", new MemoryStream());

            Assert.False(context.IsWebSocketRequest);
        }

        [Fact]
        public void Constructor_WithEmptySubProtocols_SetsProperty()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "header", "/path", new MemoryStream());

            Assert.NotNull(context.WebSocketRequestedProtocols);
            Assert.Empty(context.WebSocketRequestedProtocols);
        }

        [Fact]
        public void Constructor_WithNullHttpHeader_SetsProperty()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), null, "/path", new MemoryStream());

            Assert.Null(context.HttpHeader);
        }

        [Fact]
        public void Constructor_WithNullPath_SetsProperty()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "header", null, new MemoryStream());

            Assert.Null(context.Path);
        }

        [Fact]
        public void Constructor_WithNullStream_SetsProperty()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "header", "/path", null);

            Assert.Null(context.Stream);
        }

        [Fact]
        public void IsWebSocketRequest_WithValidRequest_ReturnsTrue()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "header", "/path", new MemoryStream());

            Assert.True(context.IsWebSocketRequest);
        }

        [Fact]
        public void IsWebSocketRequest_WithInvalidRequest_ReturnsFalse()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string>(), "header", "/path", new MemoryStream());

            Assert.False(context.IsWebSocketRequest);
        }

        [Fact]
        public void WebSocketRequestedProtocols_ReturnsList()
        {
            List<string> expectedProtocols = new List<string> { "chat", "json", "xml" };
            WebSocketHttpContext context = new WebSocketHttpContext(true, expectedProtocols, "header", "/path", new MemoryStream());

            Assert.Equal(expectedProtocols, context.WebSocketRequestedProtocols);
        }

        [Fact]
        public void HttpHeader_ReturnsRawHeader()
        {
            string expectedHeader = "GET /chat HTTP/1.1\r\nHost: example.com\r\nUpgrade: websocket\r\n\r\n";
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), expectedHeader, "/path", new MemoryStream());

            Assert.Equal(expectedHeader, context.HttpHeader);
        }

        [Fact]
        public void Path_ReturnsPath()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "header", "/api/chat", new MemoryStream());

            Assert.Equal("/api/chat", context.Path);
        }

        [Fact]
        public void Stream_ReturnsStream()
        {
            MemoryStream stream = new MemoryStream();
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "header", "/path", stream);

            Assert.Same(stream, context.Stream);
        }

        [Fact]
        public void Equals_WithSameProperties_ReturnsTrue()
        {
            MemoryStream stream1 = new MemoryStream();
            MemoryStream stream2 = new MemoryStream();
            
            WebSocketHttpContext context1 = new WebSocketHttpContext(true, new List<string>(), "header", "/path", stream1);
            WebSocketHttpContext context2 = new WebSocketHttpContext(true, new List<string>(), "header", "/path", stream2);

            Assert.NotEqual(context1, context2);
        }

        [Fact]
        public void ToString_ReturnsTypeFullName()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "header", "/path", new MemoryStream());

            string result = context.ToString();
            Assert.Contains("WebSocketHttpContext", result);
            
        }
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