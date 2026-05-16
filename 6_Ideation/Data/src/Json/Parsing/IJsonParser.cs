// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IJsonParser.cs
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
using Alis.Core.Aspect.Data.Json.Deserialization;

namespace Alis.Core.Aspect.Data.Json.Parsing
{
    /// <summary>
    ///     Defines a contract for parsing JSON strings into flat dictionaries of key-value string pairs.
    ///     Implementing types provide the logic to traverse a JSON object structure and extract each
    ///     property as a string-based key-value entry, handling nested objects and arrays as raw JSON.
    /// </summary>
    /// <remarks>
    ///     Implementations of this interface are used as the low-level parsing engine by the
    ///     <see cref="JsonNativeAot" /> facade and the <see cref="JsonDeserializer" /> class.
    ///     The parser is expected to handle quoted strings, escape sequences, nested objects/arrays,
    ///     and primitive values (numbers, booleans, null).
    /// </remarks>
    public interface IJsonParser
    {
        /// <summary>
        ///     Parses a JSON string into a dictionary of property names and their string values.
        ///     Complex nested values (objects and arrays) are returned as raw JSON substrings.
        /// </summary>
        /// <param name="json">The JSON string to parse. Must not be null. Expected to contain a JSON object (surrounded by curly braces).</param>
        /// <returns>
        ///     A dictionary where each key is a property name from the JSON object and the corresponding
        ///     value is its string representation. Primitive values are stored as-is; nested objects and
        ///     arrays are stored as raw JSON substrings.
        ///     Returns an empty dictionary for empty, whitespace-only, or empty-object JSON strings.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="json" /> is null.</exception>
        Dictionary<string, string> ParseToDictionary(string json);
    }
}