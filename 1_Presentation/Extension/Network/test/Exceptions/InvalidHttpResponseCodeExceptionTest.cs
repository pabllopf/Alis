

using System;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test.Exceptions
{
    /// <summary>
    ///     The invalid http response code exception test class
    /// </summary>
    public class InvalidHttpResponseCodeExceptionTest
    {
        /// <summary>
        ///     Tests that invalid http response code exception default constructor
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCodeException_DefaultConstructor()
        {
            InvalidHttpResponseCodeException exception = new InvalidHttpResponseCodeException();
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that invalid http response code exception constructor with message
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCodeException_ConstructorWithMessage()
        {
            InvalidHttpResponseCodeException exception = new InvalidHttpResponseCodeException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }

        /// <summary>
        ///     Tests that invalid http response code exception constructor with response details
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCodeException_ConstructorWithResponseDetails()
        {
            InvalidHttpResponseCodeException exception = new InvalidHttpResponseCodeException("404", "Not Found", "HTTP/1.1 404 Not Found");
            Assert.NotNull(exception);
            Assert.Equal("404", exception.ResponseCode);
            Assert.Equal("Not Found", exception.ResponseDetails);
            Assert.Equal("HTTP/1.1 404 Not Found", exception.ResponseHeader);
        }

        /// <summary>
        ///     Tests that invalid http response code exception constructor with message and inner exception
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCodeException_ConstructorWithMessageAndInnerException()
        {
            Exception innerException = new Exception("Inner exception");
            InvalidHttpResponseCodeException exception = new InvalidHttpResponseCodeException("Test message", innerException);
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }
    }
}