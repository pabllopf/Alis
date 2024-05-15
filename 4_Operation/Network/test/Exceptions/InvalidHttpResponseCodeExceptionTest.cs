// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InvalidHttpResponseCodeExceptionTest.cs
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
    /// The invalid http response code exception test class
    /// </summary>
    public class InvalidHttpResponseCodeExceptionTest
    {
        /// <summary>
        /// Tests that invalid http response code exception default constructor
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCodeException_DefaultConstructor()
        {
            InvalidHttpResponseCodeException exception = new InvalidHttpResponseCodeException();
            Assert.NotNull(exception);
        }
        
        /// <summary>
        /// Tests that invalid http response code exception constructor with message
        /// </summary>
        [Fact]
        public void InvalidHttpResponseCodeException_ConstructorWithMessage()
        {
            InvalidHttpResponseCodeException exception = new InvalidHttpResponseCodeException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }
        
        /// <summary>
        /// Tests that invalid http response code exception constructor with response details
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
        /// Tests that invalid http response code exception constructor with message and inner exception
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