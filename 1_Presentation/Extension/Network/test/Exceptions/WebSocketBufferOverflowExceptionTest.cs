

using System;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test.Exceptions
{
    /// <summary>
    ///     The web socket buffer overflow exception test class
    /// </summary>
    public class WebSocketBufferOverflowExceptionTest
    {
        /// <summary>
        ///     Tests that web socket buffer overflow exception default constructor
        /// </summary>
        [Fact]
        public void WebSocketBufferOverflowException_DefaultConstructor()
        {
            WebSocketBufferOverflowException exception = new WebSocketBufferOverflowException();
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that web socket buffer overflow exception constructor with message
        /// </summary>
        [Fact]
        public void WebSocketBufferOverflowException_ConstructorWithMessage()
        {
            WebSocketBufferOverflowException exception = new WebSocketBufferOverflowException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }

        /// <summary>
        ///     Tests that web socket buffer overflow exception constructor with message and inner exception
        /// </summary>
        [Fact]
        public void WebSocketBufferOverflowException_ConstructorWithMessageAndInnerException()
        {
            Exception innerException = new Exception("Inner exception");
            WebSocketBufferOverflowException exception = new WebSocketBufferOverflowException("Test message", innerException);
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}