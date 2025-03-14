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

using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The json GeneralAlisException test class
    /// </summary>
    public class JsonExceptionTest
    {
        /// <summary>
        ///     Tests that test get code method
        /// </summary>
        [Fact]
        public void TestGetCodeMethod()
        {
            string message = "JSO0015: Test message";
            JsonException ex = new JsonException(message);
            Assert.Equal(15, ex.Code);
        }

        /// <summary>
        ///     Tests that test get code method with invalid message
        /// </summary>
        [Fact]
        public void TestGetCodeMethodWithInvalidMessage()
        {
            string message = "Invalid message";
            JsonException ex = new JsonException(message);
            Assert.Equal(-1, ex.Code);
        }


        /// <summary>
        ///     Tests that get code null message returns minus one
        /// </summary>
        [Fact]
        public void GetCode_NullMessage_ReturnsMinusOne()
        {
            int result = JsonException.GetCode(null);
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that get code message without prefix returns minus one
        /// </summary>
        [Fact]
        public void GetCode_MessageWithoutPrefix_ReturnsMinusOne()
        {
            int result = JsonException.GetCode("Some message without prefix");
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that get code message with prefix but without colon returns minus one
        /// </summary>
        [Fact]
        public void GetCode_MessageWithPrefixButWithoutColon_ReturnsMinusOne()
        {
            int result = JsonException.GetCode("JSO1234 Some message with prefix but without colon");
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that get code message with prefix and colon but invalid number returns minus one
        /// </summary>
        [Fact]
        public void GetCode_MessageWithPrefixAndColonButInvalidNumber_ReturnsMinusOne()
        {
            int result = JsonException.GetCode("JSOABC: Some message with prefix and colon but invalid number");
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that get code valid message returns correct number
        /// </summary>
        [Fact]
        public void GetCode_ValidMessage_ReturnsCorrectNumber()
        {
            int result = JsonException.GetCode("JSO1234: Some valid message");
            Assert.Equal(1234, result);
        }
    }
}