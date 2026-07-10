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
    public class JsonParserBranchCoverageTests
    {
        private readonly JsonParser _parser;

        public JsonParserBranchCoverageTests()
        {
            EscapeSequenceHandler escapeHandler = new EscapeSequenceHandler();
            _parser = new JsonParser(escapeHandler);
        }

        [Fact]
        public void ParseToDictionary_OpeningBraceOnlyWhitespace_ReturnsEmpty()
        {
            Dictionary<string, string> result = _parser.ParseToDictionary("{  ");
            Assert.Empty(result);
        }

        [Fact]
        public void ParseToDictionary_KeyOnlyNoColon_ThrowsJsonParsingException()
        {
            string json = "{\"key\"";
            JsonParsingException ex = Assert.Throws<JsonParsingException>(() => _parser.ParseToDictionary(json));
            Assert.Contains("Expected ':'", ex.Message);
        }

        [Fact]
        public void ParseToDictionary_OpeningBraceOnlyNewlineThenEnd_ReturnsEmpty()
        {
            Dictionary<string, string> result = _parser.ParseToDictionary("{\n");
            Assert.Empty(result);
        }

        [Fact]
        public void ParseToDictionary_OpeningBraceOnlyTabThenEnd_ReturnsEmpty()
        {
            Dictionary<string, string> result = _parser.ParseToDictionary("{\t");
            Assert.Empty(result);
        }
    }
}
