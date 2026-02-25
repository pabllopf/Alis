// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: EscapeSequenceHandlerTest.cs
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

using Alis.Core.Aspect.Data.Json.Helpers;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Helpers
{
    /// <summary>
    /// The escape sequence handler test class
    /// </summary>
    public class EscapeSequenceHandlerTest
    {
        /// <summary>
        /// The handler
        /// </summary>
        private readonly EscapeSequenceHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="EscapeSequenceHandlerTest"/> class
        /// </summary>
        public EscapeSequenceHandlerTest()
        {
            _handler = new EscapeSequenceHandler();
        }

        /// <summary>
        /// Tests that is escaped with escaped quote returns true
        /// </summary>
        [Fact]
        public void IsEscaped_WithEscapedQuote_ReturnsTrue()
        {
            string text = "test\\\"quote";
            bool result = _handler.IsEscaped(text, 5);
            Assert.True(result);
        }

        /// <summary>
        /// Tests that is escaped with unescaped character returns false
        /// </summary>
        [Fact]
        public void IsEscaped_WithUnescapedCharacter_ReturnsFalse()
        {
            string text = "test\"quote";
            bool result = _handler.IsEscaped(text, 4);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that is escaped with negative position returns false
        /// </summary>
        [Fact]
        public void IsEscaped_WithNegativePosition_ReturnsFalse()
        {
            string text = "test";
            bool result = _handler.IsEscaped(text, -1);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that is escaped with position out of range returns false
        /// </summary>
        [Fact]
        public void IsEscaped_WithPositionOutOfRange_ReturnsFalse()
        {
            string text = "test";
            bool result = _handler.IsEscaped(text, 10);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that is escaped with null text throws argument null exception
        /// </summary>
        [Fact]
        public void IsEscaped_WithNullText_ThrowsArgumentNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => _handler.IsEscaped(null, 0));
        }

        /// <summary>
        /// Tests that unescape with quote escape unescapes correctly
        /// </summary>
        [Fact]
        public void Unescape_WithQuoteEscape_UnescapesCorrectly()
        {
            string escaped = "test\\\"value";
            string result = _handler.Unescape(escaped);
            Assert.Equal("test\"value", result);
        }

        /// <summary>
        /// Tests that unescape with backslash escape unescapes correctly
        /// </summary>
        [Fact]
        public void Unescape_WithBackslashEscape_UnescapesCorrectly()
        {
            string escaped = "path\\\\file";
            string result = _handler.Unescape(escaped);
            Assert.Equal("path\\file", result);
        }

        /// <summary>
        /// Tests that unescape with newline escape unescapes correctly
        /// </summary>
        [Fact]
        public void Unescape_WithNewlineEscape_UnescapesCorrectly()
        {
            string escaped = "line1\\nline2";
            string result = _handler.Unescape(escaped);
            Assert.Equal("line1\nline2", result);
        }

        /// <summary>
        /// Tests that unescape with tab escape unescapes correctly
        /// </summary>
        [Fact]
        public void Unescape_WithTabEscape_UnescapesCorrectly()
        {
            string escaped = "col1\\tcol2";
            string result = _handler.Unescape(escaped);
            Assert.Equal("col1\tcol2", result);
        }

        /// <summary>
        /// Tests that unescape with multiple escapes unescapes correctly
        /// </summary>
        [Fact]
        public void Unescape_WithMultipleEscapes_UnescapesCorrectly()
        {
            string escaped = "line1\\nline2\\ttab\\\"quote";
            string result = _handler.Unescape(escaped);
            Assert.Equal("line1\nline2\ttab\"quote", result);
        }

        /// <summary>
        /// Tests that unescape with unicode escape unescapes correctly
        /// </summary>
        [Fact]
        public void Unescape_WithUnicodeEscape_UnescapesCorrectly()
        {
            string escaped = "text\\u0041more";
            string result = _handler.Unescape(escaped);
            Assert.Equal("textAmore", result);
        }

        /// <summary>
        /// Tests that unescape without escapes returns original string
        /// </summary>
        [Fact]
        public void Unescape_WithoutEscapes_ReturnsOriginalString()
        {
            string text = "plain text";
            string result = _handler.Unescape(text);
            Assert.Equal(text, result);
        }

        /// <summary>
        /// Tests that unescape with null value throws argument null exception
        /// </summary>
        [Fact]
        public void Unescape_WithNullValue_ThrowsArgumentNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => _handler.Unescape(null));
        }

        /// <summary>
        /// Tests that unescape with formfeed escape unescapes correctly
        /// </summary>
        [Fact]
        public void Unescape_WithFormfeedEscape_UnescapesCorrectly()
        {
            string escaped = "text\\fmore";
            string result = _handler.Unescape(escaped);
            Assert.Equal("text\fmore", result);
        }

        /// <summary>
        /// Tests that unescape with carriage return escape unescapes correctly
        /// </summary>
        [Fact]
        public void Unescape_WithCarriageReturnEscape_UnescapesCorrectly()
        {
            string escaped = "text\\rmore";
            string result = _handler.Unescape(escaped);
            Assert.Equal("text\rmore", result);
        }

        /// <summary>
        /// Tests that unescape with backspace escape unescapes correctly
        /// </summary>
        [Fact]
        public void Unescape_WithBackspaceEscape_UnescapesCorrectly()
        {
            string escaped = "text\\bmore";
            string result = _handler.Unescape(escaped);
            Assert.Equal("text\bmore", result);
        }

        /// <summary>
        /// Tests that unescape with invalid unicode escape keeps escape sequence
        /// </summary>
        [Fact]
        public void Unescape_WithInvalidUnicodeEscape_KeepsEscapeSequence()
        {
            string escaped = "text\\uZZZZmore";
            string result = _handler.Unescape(escaped);
            Assert.Equal("textuZZZZmore", result);
        }
    }
}

