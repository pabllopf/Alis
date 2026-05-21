

using System;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test.Exceptions
{
    /// <summary>
    ///     The web socket version not supported exception test class
    /// </summary>
    public class WebSocketVersionNotSupportedExceptionTest
    {
        /// <summary>
        ///     Tests that web socket version not supported exception default constructor
        /// </summary>
        [Fact]
        public void WebSocketVersionNotSupportedException_DefaultConstructor()
        {
            WebSocketVersionNotSupportedException exception = new WebSocketVersionNotSupportedException();
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that web socket version not supported exception constructor with message
        /// </summary>
        [Fact]
        public void WebSocketVersionNotSupportedException_ConstructorWithMessage()
        {
            WebSocketVersionNotSupportedException exception = new WebSocketVersionNotSupportedException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }

        /// <summary>
        ///     Tests that web socket version not supported exception constructor with message and inner exception
        /// </summary>
        [Fact]
        public void WebSocketVersionNotSupportedException_ConstructorWithMessageAndInnerException()
        {
            Exception innerException = new Exception("Inner exception");
            WebSocketVersionNotSupportedException exception = new WebSocketVersionNotSupportedException("Test message", innerException);
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}