

using System;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test.Exceptions
{
    /// <summary>
    ///     The web socket handshake failed exception test class
    /// </summary>
    public class WebSocketHandshakeFailedExceptionTest
    {
        /// <summary>
        ///     Tests that web socket handshake failed exception default constructor
        /// </summary>
        [Fact]
        public void WebSocketHandshakeFailedException_DefaultConstructor()
        {
            WebSocketHandshakeFailedException exception = new WebSocketHandshakeFailedException();
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that web socket handshake failed exception constructor with message
        /// </summary>
        [Fact]
        public void WebSocketHandshakeFailedException_ConstructorWithMessage()
        {
            WebSocketHandshakeFailedException exception = new WebSocketHandshakeFailedException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }

        /// <summary>
        ///     Tests that web socket handshake failed exception constructor with message and inner exception
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