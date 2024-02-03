// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonExceptionTest.cs
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
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The json exception test class
    /// </summary>
    public class JsonExceptionTest
    {

        /// <summary>
        /// Tests that test default constructor
        /// </summary>
        [Fact]
        public void TestDefaultConstructor()
        {
            JsonException ex = new JsonException();
            Assert.NotNull(ex);
            Assert.Equal("JSO0001: JSON exception.", ex.Message);
        }

        /// <summary>
        /// Tests that test constructor with message
        /// </summary>
        [Fact]
        public void TestConstructorWithMessage()
        {
            string message = "Test message";
            JsonException ex = new JsonException(message);
            Assert.NotNull(ex);
            Assert.Equal(message, ex.Message);
        }

        /// <summary>
        /// Tests that test constructor with message and inner exception
        /// </summary>
        [Fact]
        public void TestConstructorWithMessageAndInnerException()
        {
            string message = "Test message";
            Exception innerException = new Exception("Inner exception");
            JsonException ex = new JsonException(message, innerException);
            Assert.NotNull(ex);
            Assert.Equal(message, ex.Message);
            Assert.Equal(innerException, ex.InnerException);
        }

        /// <summary>
        /// Tests that test constructor with inner exception
        /// </summary>
        [Fact]
        public void TestConstructorWithInnerException()
        {
            Exception innerException = new Exception("Inner exception");
            JsonException ex = new JsonException(innerException);
            Assert.NotNull(ex);
            Assert.Equal(innerException, ex.InnerException);
        }

        /// <summary>
        /// Tests that test get code method
        /// </summary>
        [Fact]
        public void TestGetCodeMethod()
        {
            string message = "JSO0015: Test message";
            JsonException ex = new JsonException(message);
            Assert.Equal(15, ex.Code);
        }

        /// <summary>
        /// Tests that test get code method with invalid message
        /// </summary>
        [Fact]
        public void TestGetCodeMethodWithInvalidMessage()
        {
            string message = "Invalid message";
            JsonException ex = new JsonException(message);
            Assert.Equal(-1, ex.Code);
        }
    }
}