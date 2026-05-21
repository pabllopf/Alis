

using System;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test.Exceptions
{
    /// <summary>
    ///     The server listener socket exception test class
    /// </summary>
    public class ServerListenerSocketExceptionTest
    {
        /// <summary>
        ///     Tests that server listener socket exception default constructor
        /// </summary>
        [Fact]
        public void ServerListenerSocketException_DefaultConstructor()
        {
            ServerListenerSocketException exception = new ServerListenerSocketException();
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that server listener socket exception constructor with message
        /// </summary>
        [Fact]
        public void ServerListenerSocketException_ConstructorWithMessage()
        {
            ServerListenerSocketException exception = new ServerListenerSocketException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }

        /// <summary>
        ///     Tests that server listener socket exception constructor with message and inner exception
        /// </summary>
        [Fact]
        public void ServerListenerSocketException_ConstructorWithMessageAndInnerException()
        {
            Exception innerException = new Exception("Inner exception");
            ServerListenerSocketException exception = new ServerListenerSocketException("Test message", innerException);
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}