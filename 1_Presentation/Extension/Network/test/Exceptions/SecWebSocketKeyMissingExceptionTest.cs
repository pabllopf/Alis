

using System;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test.Exceptions
{
    /// <summary>
    ///     The sec web socket key missing exception test class
    /// </summary>
    public class SecWebSocketKeyMissingExceptionTest
    {
        /// <summary>
        ///     Tests that sec web socket key missing exception default constructor
        /// </summary>
        [Fact]
        public void SecWebSocketKeyMissingException_DefaultConstructor()
        {
            SecWebSocketKeyMissingException exception = new SecWebSocketKeyMissingException();
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that sec web socket key missing exception constructor with message
        /// </summary>
        [Fact]
        public void SecWebSocketKeyMissingException_ConstructorWithMessage()
        {
            SecWebSocketKeyMissingException exception = new SecWebSocketKeyMissingException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }

        /// <summary>
        ///     Tests that sec web socket key missing exception constructor with message and inner exception
        /// </summary>
        [Fact]
        public void SecWebSocketKeyMissingException_ConstructorWithMessageAndInnerException()
        {
            Exception innerException = new Exception("Inner exception");
            SecWebSocketKeyMissingException exception = new SecWebSocketKeyMissingException("Test message", innerException);
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}