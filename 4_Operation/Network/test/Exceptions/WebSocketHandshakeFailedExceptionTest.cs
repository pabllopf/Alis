// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketHandshakeFailedExceptionTest.cs
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
using Alis.Core.Network.Exceptions;
using Xunit;

namespace Alis.Core.Network.Test.Exceptions
{
    /// <summary>
    /// The web socket handshake failed exception test class
    /// </summary>
    public class WebSocketHandshakeFailedExceptionTest
    {
        /// <summary>
        /// Tests that web socket handshake failed exception default constructor
        /// </summary>
        [Fact]
        public void WebSocketHandshakeFailedException_DefaultConstructor()
        {
            WebSocketHandshakeFailedException exception = new WebSocketHandshakeFailedException();
            Assert.NotNull(exception);
        }
        
        /// <summary>
        /// Tests that web socket handshake failed exception constructor with message
        /// </summary>
        [Fact]
        public void WebSocketHandshakeFailedException_ConstructorWithMessage()
        {
            WebSocketHandshakeFailedException exception = new WebSocketHandshakeFailedException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }
        
        /// <summary>
        /// Tests that web socket handshake failed exception constructor with message and inner exception
        /// </summary>
        [Fact]
        public void WebSocketHandshakeFailedException_ConstructorWithMessageAndInnerException()
        {
            Exception innerException = new Exception("Inner exception");
            WebSocketHandshakeFailedException exception = new WebSocketHandshakeFailedException("Test message", innerException);
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}