// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonParser.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json.Exceptions;
using Alis.Core.Aspect.Data.Json.Helpers;

namespace Alis.Core.Aspect.Data.Json.Parsing
{
    /// <summary>
    ///     Parses JSON strings into dictionaries of properties.
    /// </summary>
    public sealed class JsonParser : IJsonParser
    {
        /// <summary>
        /// The escape sequence handler
        /// </summary>
        private readonly IEscapeSequenceHandler _escapeSequenceHandler;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonParser" /> class.
        /// </summary>
        /// <param name="escapeSequenceHandler">The escape sequence handler.</param>
        /// <exception cref="ArgumentNullException">Thrown when escapeSequenceHandler is null.</exception>
        public JsonParser(IEscapeSequenceHandler escapeSequenceHandler)
        {
            _escapeSequenceHandler = escapeSequenceHandler ?? throw new ArgumentNullException(nameof(escapeSequenceHandler));
        }

        /// <summary>
        ///     Parses a JSON string into a dictionary of property names and their string values.
        /// </summary>
        /// <param name="json">The JSON string to parse.</param>
        /// <returns>A dictionary containing property names as keys and their string representations as values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when json is null.</exception>
        /// <exception cref="JsonParsingException">Thrown when parsing fails.</exception>
        public Dictionary<string, string> ParseToDictionary(string json)
        {
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            try
            {
                var result = new Dictionary<string, string>();

                if (string.IsNullOrWhiteSpace(json))
                {
                    return result;
                }

                int position = 0;
                int length = json.Length;

                SkipWhitespace(json, ref position);

                if (position < length && json[position] == '{')
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

                    if (position < length && json[position] == ',')
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
        ///     Reads a JSON value at the current position.
        /// </summary>
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
        ///     Reads a JSON string starting with a quote.
        /// </summary>
        private string ReadJsonString(string json, ref int position)
        {
            if (position >= json.Length || json[position] != '"')
            {
                throw new JsonParsingException($"Expected '\"' at position {position}");
            }

            position++;
            var result = new System.Text.StringBuilder();

            while (position < json.Length)
            {
                char current = json[position];

                if (current == '"' && !_escapeSequenceHandler.IsEscaped(json, position))
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
        ///     Reads a raw JSON value (object or array).
        /// </summary>
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

                if (current == '"' && !_escapeSequenceHandler.IsEscaped(json, position))
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
        ///     Reads a primitive JSON value (number, boolean, null).
        /// </summary>
        private string ReadPrimitive(string json, ref int position)
        {
            int start = position;

            while (position < json.Length && json[position] != ',' && json[position] != '}' && json[position] != ']')
            {
                position++;
            }

            return json.Substring(start, position - start).Trim();
        }

        /// <summary>
        ///     Skips whitespace characters at the current position.
        /// </summary>
        private void SkipWhitespace(string json, ref int position)
        {
            while (position < json.Length && char.IsWhiteSpace(json[position]))
            {
                position++;
            }
        }
    }
}

