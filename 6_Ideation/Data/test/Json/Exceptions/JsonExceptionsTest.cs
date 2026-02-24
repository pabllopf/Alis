// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonExceptionsTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Data.Json.Exceptions;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Exceptions
{
    /// <summary>
    /// The json exceptions test class
    /// </summary>
    public class JsonExceptionsTest
    {
        /// <summary>
        /// Tests that json parsing exception with message stores message
        /// </summary>
        [Fact]
        public void JsonParsingException_WithMessage_StoresMessage()
        {
            string message = "Parsing failed at position 0";
            JsonParsingException exception = new JsonParsingException(message);

            Assert.Equal(message, exception.Message);
        }

        /// <summary>
        /// Tests that json parsing exception with message and inner exception stores data
        /// </summary>
        [Fact]
        public void JsonParsingException_WithMessageAndInnerException_StoresData()
        {
            string message = "Parsing failed";
            InvalidOperationException innerException = new InvalidOperationException("Inner error");
            JsonParsingException exception = new JsonParsingException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        /// <summary>
        /// Tests that json deserialization exception with message stores message
        /// </summary>
        [Fact]
        public void JsonDeserializationException_WithMessage_StoresMessage()
        {
            string message = "Deserialization failed";
            JsonDeserializationException exception = new JsonDeserializationException(message);

            Assert.Equal(message, exception.Message);
        }

        /// <summary>
        /// Tests that json deserialization exception with message and inner exception stores data
        /// </summary>
        [Fact]
        public void JsonDeserializationException_WithMessageAndInnerException_StoresData()
        {
            string message = "Deserialization failed";
            FormatException innerException = new FormatException("Format error");
            JsonDeserializationException exception = new JsonDeserializationException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        /// <summary>
        /// Tests that json serialization exception with message stores message
        /// </summary>
        [Fact]
        public void JsonSerializationException_WithMessage_StoresMessage()
        {
            string message = "Serialization failed";
            JsonSerializationException exception = new JsonSerializationException(message);

            Assert.Equal(message, exception.Message);
        }

        /// <summary>
        /// Tests that json serialization exception with message and inner exception stores data
        /// </summary>
        [Fact]
        public void JsonSerializationException_WithMessageAndInnerException_StoresData()
        {
            string message = "Serialization failed";
            NotSupportedException innerException = new NotSupportedException("Type not supported");
            JsonSerializationException exception = new JsonSerializationException(message, innerException);

            Assert.Equal(message, exception.Message);
            Assert.Equal(innerException, exception.InnerException);
        }

        /// <summary>
        /// Tests that json parsing exception is exception
        /// </summary>
        [Fact]
        public void JsonParsingException_IsException()
        {
            JsonParsingException exception = new JsonParsingException("test");
            Assert.IsAssignableFrom<Exception>(exception);
        }

        /// <summary>
        /// Tests that json deserialization exception is exception
        /// </summary>
        [Fact]
        public void JsonDeserializationException_IsException()
        {
            JsonDeserializationException exception = new JsonDeserializationException("test");
            Assert.IsAssignableFrom<Exception>(exception);
        }

        /// <summary>
        /// Tests that json serialization exception is exception
        /// </summary>
        [Fact]
        public void JsonSerializationException_IsException()
        {
            JsonSerializationException exception = new JsonSerializationException("test");
            Assert.IsAssignableFrom<Exception>(exception);
        }
    }
}

