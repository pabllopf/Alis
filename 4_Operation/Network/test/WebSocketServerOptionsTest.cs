// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketServerOptionsTest.cs
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
using Xunit;

namespace Alis.Core.Network.Test
{
    /// <summary>
    /// The web socket server options test class
    /// </summary>
    public class WebSocketServerOptionsTest
    {
        /// <summary>
        /// Tests that web socket server options default constructor
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
        /// Tests that web socket server options constructor with parameters
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
        /// Tests that web socket server options constructor with time span and sub protocol
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