

using System;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test.Exceptions
{
    /// <summary>
    ///     The entitytoolargeexceptiontest class
    /// </summary>
    public class EntityTooLargeExceptionTest
    {
        /// <summary>
        ///     Tests that entity too large exception default constructor
        /// </summary>
        [Fact]
        public void EntityTooLargeException_DefaultConstructor()
        {
            EntityTooLargeException exception = new EntityTooLargeException();
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that entity too large exception constructor with message
        /// </summary>
        [Fact]
        public void EntityTooLargeException_ConstructorWithMessage()
        {
            EntityTooLargeException exception = new EntityTooLargeException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }

        /// <summary>
        ///     Tests that entity too large exception constructor with message and inner exception
        /// </summary>
        [Fact]
        public void EntityTooLargeException_ConstructorWithMessageAndInnerException()
        {
            Exception innerException = new Exception("Inner exception");
            EntityTooLargeException exception = new EntityTooLargeException("Test message", innerException);
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}