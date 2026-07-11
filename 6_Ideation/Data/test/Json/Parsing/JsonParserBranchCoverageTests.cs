// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonParserBranchCoverageTests.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json.Exceptions;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json.Parsing
{
    /// <summary>
    /// The json parser branch coverage tests class
    /// </summary>
    public class JsonParserBranchCoverageTests
    {
        /// <summary>
        /// The parser
        /// </summary>
        private readonly JsonParser _parser;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonParserBranchCoverageTests"/> class
        /// </summary>
        public JsonParserBranchCoverageTests()
        {
            EscapeSequenceHandler escapeHandler = new EscapeSequenceHandler();
            _parser = new JsonParser(escapeHandler);
        }

        /// <summary>
        /// Tests that parse to dictionary opening brace only whitespace returns empty
        /// </summary>
        [Fact]
        public void ParseToDictionary_OpeningBraceOnlyWhitespace_ReturnsEmpty()
        {
            Dictionary<string, string> result = _parser.ParseToDictionary("{  ");
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that parse to dictionary key only no colon throws json parsing exception
        /// </summary>
        [Fact]
        public void ParseToDictionary_KeyOnlyNoColon_ThrowsJsonParsingException()
        {
            string json = "{\"key\"";
            JsonParsingException ex = Assert.Throws<JsonParsingException>(() => _parser.ParseToDictionary(json));
            Assert.Contains("Expected ':'", ex.Message);
        }

        /// <summary>
        /// Tests that parse to dictionary opening brace only newline then end returns empty
        /// </summary>
        [Fact]
        public void ParseToDictionary_OpeningBraceOnlyNewlineThenEnd_ReturnsEmpty()
        {
            Dictionary<string, string> result = _parser.ParseToDictionary("{\n");
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that parse to dictionary opening brace only tab then end returns empty
        /// </summary>
        [Fact]
        public void ParseToDictionary_OpeningBraceOnlyTabThenEnd_ReturnsEmpty()
        {
            Dictionary<string, string> result = _parser.ParseToDictionary("{\t");
            Assert.Empty(result);
        }
    }
}
