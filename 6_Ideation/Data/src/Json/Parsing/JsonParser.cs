// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonParser.cs
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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Alis.Core.Aspect.Data.Json.Exceptions;
using Alis.Core.Aspect.Data.Json.Helpers;

namespace Alis.Core.Aspect.Data.Json.Parsing
{
    /// <summary>
    ///     Parses JSON strings into flat dictionaries of string key-value pairs.
    ///     Supports parsing of JSON objects with string keys and values of various types,
    ///     handling nested objects and arrays by returning them as raw JSON substrings.
    ///     Uses an <see cref="IEscapeSequenceHandler" /> to correctly process escape sequences
    ///     within quoted strings.
    /// </summary>
    /// <remarks>
    ///     The parser processes JSON input character by character, maintaining a position cursor.
    ///     It handles:
    ///     - Quoted strings with full escape sequence support (via the injected handler)
    ///     - Nested objects and arrays (tracked via depth counting, respecting string boundaries)
    ///     - Primitive values (numbers, booleans, null) delimited by structural characters
    ///     - Whitespace skipping between tokens
    ///     The parser does not perform type conversion; all values are returned as strings.
    ///     This parser is designed to be AOT-compatible and avoids runtime code generation.
    /// </remarks>
    public sealed class JsonParser : IJsonParser
    {
        /// <summary>
        ///     The escape sequence handler used to detect escaped characters and unescape
        ///     JSON strings during parsing.
        /// </summary>
        private readonly IEscapeSequenceHandler _escapeSequenceHandler;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonParser" /> class with the specified
        ///     escape sequence handler.
        /// </summary>
        /// <param name="escapeSequenceHandler">The escape sequence handler that provides escaped-character detection and unescaping. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="escapeSequenceHandler" /> is null.</exception>
        public JsonParser(IEscapeSequenceHandler escapeSequenceHandler) => _escapeSequenceHandler = escapeSequenceHandler ?? throw new ArgumentNullException(nameof(escapeSequenceHandler));

        /// <summary>
        ///     Parses the provided JSON string into a dictionary of property names and their
        ///     string representations. Complex nested values are preserved as raw JSON substrings.
        /// </summary>
        /// <param name="json">The JSON string to parse. Must not be null. Expected to represent a JSON object (surrounded by curly braces).</param>
        /// <returns>
        ///     A dictionary where each key is a property name from the JSON object and each value
        ///     is its string representation. Primitive values (numbers, booleans, null) are returned
        ///     as plain strings; quoted strings are unescaped; nested objects and arrays are returned
        ///     as raw JSON substrings.
        ///     Returns an empty dictionary for null, empty, or whitespace-only input.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="json" /> is null.</exception>
        /// <exception cref="JsonParsingException">Thrown when the JSON is malformed (e.g., missing delimiters, unterminated strings, or unexpected characters).</exception>
        [ExcludeFromCodeCoverage]
        public Dictionary<string, string> ParseToDictionary(string json)
        {
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            try
            {
                Dictionary<string, string> result = new Dictionary<string, string>();

                if (string.IsNullOrWhiteSpace(json))
                {
                    return result;
                }

                int position = 0;
                int length = json.Length;

                SkipWhitespace(json, ref position);

                if ((position < length) && (json[position] == '{'))
                {
                    position++;
                }

                while (position < length)
                {
                    SkipWhitespace(json, ref position);

                    if (position >= length || json[position] == '}')
                    {
                        break;
                    }

                    string key = ReadJsonString(json, ref position);
                    SkipWhitespace(json, ref position);

                    if (position >= length || json[position] != ':')
                    {
                        throw new JsonParsingException($"Expected ':' at position {position}");
                    }

                    position++;
                    SkipWhitespace(json, ref position);

                    string value = ReadJsonValue(json, ref position);
                    result[key] = value;

                    SkipWhitespace(json, ref position);

                    if ((position < length) && (json[position] == ','))
                    {
                        position++;
                    }
                }

                return result;
            }
            catch (JsonParsingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new JsonParsingException($"Failed to parse JSON: {ex.Message}", ex);
            }
        }

        /// <summary>
        ///     Reads and returns the next JSON value at the current parsing position.
        ///     Dispatches to the appropriate reader based on the first character encountered:
        ///     '{' or '[' for complex structures, '"' for strings, or any other character for primitives.
        /// </summary>
        /// <param name="json">The full JSON string being parsed.</param>
        /// <param name="position">The current position within the JSON string, advanced past the read value on return.</param>
        /// <returns>
        ///     The string representation of the value read. For quoted strings, the result is
        ///     unescaped. For objects and arrays, the result is the raw JSON substring including
        ///     delimiters. For primitives, the result is the trimmed token.
        ///     Returns null if the position is at or past the end of the string.
        /// </returns>
        [ExcludeFromCodeCoverage]
        private string ReadJsonValue(string json, ref int position)
        {
            SkipWhitespace(json, ref position);

            if (position >= json.Length)
            {
                return null;
            }

            if (json[position] == '{' || json[position] == '[')
            {
                return ReadRawJsonValue(json, ref position);
            }

            if (json[position] == '"')
            {
                return ReadJsonString(json, ref position);
            }

            return ReadPrimitive(json, ref position);
        }

        /// <summary>
        ///     Reads a JSON string value starting at the current position (which must point to an
        ///     opening quote character). Advances the position past the closing unescaped quote
        ///     and returns the unescaped string content.
        /// </summary>
        /// <param name="json">The full JSON string being parsed.</param>
        /// <param name="position">The current position, expected to point at a '"' character. Advanced past the closing '"' on success.</param>
        /// <returns>The unescaped string content between the opening and closing quotes.</returns>
        /// <exception cref="JsonParsingException">Thrown if no opening quote is found at the current position, or if the string is unterminated (no closing quote before end of input).</exception>
        private string ReadJsonString(string json, ref int position)
        {
            if (position >= json.Length || json[position] != '"')
            {
                throw new JsonParsingException($"Expected '\"' at position {position}");
            }

            position++;
            StringBuilder result = new StringBuilder();

            while (position < json.Length)
            {
                char current = json[position];

                if ((current == '"') && !_escapeSequenceHandler.IsEscaped(json, position))
                {
                    position++;
                    return _escapeSequenceHandler.Unescape(result.ToString());
                }

                result.Append(current);
                position++;
            }

            throw new JsonParsingException("Unterminated JSON string");
        }

        /// <summary>
        ///     Reads a raw JSON value representing a nested object or array, starting at the current
        ///     position. Tracks nesting depth to correctly handle the top-level closing delimiter,
        ///     respecting string boundaries to avoid false delimiter matches.
        /// </summary>
        /// <param name="json">The full JSON string being parsed.</param>
        /// <param name="position">The current position, expected to point at '{' or '['. Advanced past the matching closing delimiter on success.</param>
        /// <returns>The raw JSON substring from the opening to the matching closing delimiter, inclusive.</returns>
        /// <exception cref="JsonParsingException">Thrown if the JSON structure is unterminated (no matching closing delimiter found before end of input).</exception>
        [ExcludeFromCodeCoverage]
        private string ReadRawJsonValue(string json, ref int position)
        {
            char openChar = json[position];
            char closeChar = openChar == '{' ? '}' : ']';
            int start = position;
            int depth = 0;
            bool inString = false;

            while (position < json.Length)
            {
                char current = json[position];

                if ((current == '"') && !_escapeSequenceHandler.IsEscaped(json, position))
                {
                    inString = !inString;
                    position++;
                    continue;
                }

                if (!inString)
                {
                    if (current == openChar)
                    {
                        depth++;
                    }
                    else if (current == closeChar)
                    {
                        depth--;
                        position++;

                        if (depth == 0)
                        {
                            return json.Substring(start, position - start);
                        }

                        continue;
                    }
                }

                position++;
            }

            throw new JsonParsingException("Unterminated JSON structure");
        }

        /// <summary>
        ///     Reads a primitive JSON value (number, boolean literal, or null literal) starting at
        ///     the current position. The value is delimited by structural characters: comma, closing
        ///     brace, or closing bracket.
        /// </summary>
        /// <param name="json">The full JSON string being parsed.</param>
        /// <param name="position">The current position within the JSON string. Advanced past the end of the primitive value on return.</param>
        /// <returns>The trimmed string representation of the primitive value, with surrounding whitespace removed.</returns>
        private static string ReadPrimitive(string json, ref int position)
        {
            int start = position;

            while ((position < json.Length) && (json[position] != ',') && (json[position] != '}') && (json[position] != ']'))
            {
                position++;
            }

            return json.Substring(start, position - start).Trim();
        }

        /// <summary>
        ///     Advances the position past any whitespace characters (as defined by
        ///     <see cref="char.IsWhiteSpace(char)" />) at the current location in the JSON string.
        /// </summary>
        /// <param name="json">The full JSON string being parsed.</param>
        /// <param name="position">The current position. Updated to the first non-whitespace character or to the end of the string.</param>
        private static void SkipWhitespace(string json, ref int position)
        {
            while ((position < json.Length) && char.IsWhiteSpace(json[position]))
            {
                position++;
            }
        }
    }
}