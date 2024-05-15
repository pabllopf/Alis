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

namespace Alis.Core.Network.Test
{
    /// <summary>
    /// The web socket http context test class
    /// </summary>
    public class WebSocketHttpContextTest
    {
        /// <summary>
        /// Tests that web socket http context constructor
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
        /// Tests that web socket http context is web socket request
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_IsWebSocketRequest()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(true, new List<string>(), "", "", new MemoryStream());
            Assert.True(context.IsWebSocketRequest);
        }
        
        /// <summary>
        /// Tests that web socket http context web socket requested protocols
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_WebSocketRequestedProtocols()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string> {"protocol1", "protocol2"}, "", "", new MemoryStream());
            Assert.Contains("protocol1", context.WebSocketRequestedProtocols);
            Assert.Contains("protocol2", context.WebSocketRequestedProtocols);
        }
        
        /// <summary>
        /// Tests that web socket http context http header
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_HttpHeader()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string>(), "GET / HTTP/1.1\r\n\r\n", "", new MemoryStream());
            Assert.Equal("GET / HTTP/1.1\r\n\r\n", context.HttpHeader);
        }
        
        /// <summary>
        /// Tests that web socket http context path
        /// </summary>
        [Fact]
        public void WebSocketHttpContext_Path()
        {
            WebSocketHttpContext context = new WebSocketHttpContext(false, new List<string>(), "", "/test", new MemoryStream());
            Assert.Equal("/test", context.Path);
        }
        
        /// <summary>
        /// Tests that web socket http context stream
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