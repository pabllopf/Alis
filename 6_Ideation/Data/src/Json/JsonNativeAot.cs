// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonNativeAot.cs
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
using Alis.Core.Aspect.Data.Json.Deserialization;
using Alis.Core.Aspect.Data.Json.FileOperations;
using Alis.Core.Aspect.Data.Json.Helpers;
using Alis.Core.Aspect.Data.Json.Parsing;
using Alis.Core.Aspect.Data.Json.Serialization;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Provides a static facade for JSON serialization, deserialization, parsing, and file I/O
    ///     operations. This class is designed to be AOT-compatible by avoiding runtime code generation
    ///     and reflection-heavy patterns, relying instead on the <see cref="IJsonSerializable" /> and
    ///     <see cref="IJsonDesSerializable{T}" /> interfaces for type-safe conversion.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="JsonNativeAot" /> configures and exposes a complete JSON pipeline through
    ///     lazily-initialized singletons:
    ///     <list type="bullet">
    ///     <item><description><see cref="IEscapeSequenceHandler" /> — handles escape sequences in quoted strings</description></item>
    ///     <item><description><see cref="IJsonParser" /> — parses JSON strings into flat property dictionaries</description></item>
    ///     <item><description><see cref="IJsonSerializer" /> — serializes objects to JSON strings</description></item>
    ///     <item><description><see cref="IJsonDeserializer" /> — deserializes JSON strings into objects</description></item>
    ///     <item><description><see cref="IJsonFileHandler" /> — reads/writes JSON files</description></item>
    ///     </list>
    ///     </para>
    ///     <para>
    ///     All components are initialized on first use and are thread-safe via <see cref="Lazy{T}" />.
    ///     This design makes <see cref="JsonNativeAot" /> suitable for use in AOT-compiled environments
    ///     where runtime reflection and code generation are unavailable.
    ///     </para>
    /// </remarks>
    public static class JsonNativeAot
    {
        /// <summary>
        ///     Lazily-initialized singleton for handling JSON escape sequences within string values.
        /// </summary>
        private static readonly Lazy<IEscapeSequenceHandler> _escapeSequenceHandler =
            new(() => new EscapeSequenceHandler());

        /// <summary>
        ///     Lazily-initialized singleton for parsing JSON strings into flat property dictionaries.
        ///     Depends on <see cref="_escapeSequenceHandler" /> for correct string processing.
        /// </summary>
        private static readonly Lazy<IJsonParser> _jsonParser =
            new(() => new JsonParser(_escapeSequenceHandler.Value));

        /// <summary>
        ///     Lazily-initialized singleton for serializing objects that implement
        ///     <see cref="IJsonSerializable" /> into JSON strings.
        /// </summary>
        private static readonly Lazy<IJsonSerializer> _jsonSerializer =
            new(() => new JsonSerializer());

        /// <summary>
        ///     Lazily-initialized singleton for deserializing JSON strings into typed objects.
        ///     Depends on <see cref="_jsonParser" /> for the initial parsing step.
        /// </summary>
        private static readonly Lazy<IJsonDeserializer> _jsonDeserializer =
            new(() => new JsonDeserializer(_jsonParser.Value));

        /// <summary>
        ///     Lazily-initialized singleton for reading JSON files into objects and writing
        ///     objects to JSON files. Depends on both the serializer and deserializer.
        /// </summary>
        private static readonly Lazy<IJsonFileHandler> _jsonFileHandler =
            new(() => new JsonFileHandler(_jsonSerializer.Value, _jsonDeserializer.Value));

        /// <summary>
        ///     Serializes the specified object instance to a JSON string representation.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize. Must implement <see cref="IJsonSerializable" />.</typeparam>
        /// <param name="instance">The object instance to serialize. Must not be null.</param>
        /// <returns>A JSON string representation of the object enclosed in curly braces.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="instance" /> is null.</exception>
        public static string Serialize<T>(T instance) where T : IJsonSerializable => _jsonSerializer.Value.Serialize(instance);

        /// <summary>
        ///     Serializes the specified object instance to a JSON file on disk.
        ///     Creates the target directory if it does not exist.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize. Must implement <see cref="IJsonSerializable" />.</typeparam>
        /// <param name="instance">The object instance to serialize and write to file. Must not be null.</param>
        /// <param name="fileName">The name of the output file without the .json extension. Must not be null.</param>
        /// <param name="relativePath">The relative directory path (relative to the current working directory) where the file will be saved. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the file cannot be written.</exception>
        public static void SerializeToFile<T>(T instance, string fileName, string relativePath) where T : IJsonSerializable
        {
            _jsonFileHandler.Value.SerializeToFile(instance, fileName, relativePath);
        }

        /// <summary>
        ///     Deserializes the specified JSON string into a new instance of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">
        ///     The target type for deserialization. Must implement <see cref="IJsonSerializable" />
        ///     and <see cref="IJsonDesSerializable{T}" />, and have a parameterless constructor.
        /// </typeparam>
        /// <param name="json">The JSON string to deserialize. Must not be null.</param>
        /// <returns>A new instance of <typeparamref name="T" /> populated with data from the JSON string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="json" /> is null.</exception>
        public static T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new() => _jsonDeserializer.Value.Deserialize<T>(json);

        /// <summary>
        ///     Parses a JSON string into a dictionary of property names and their string values.
        ///     Provides low-level access to JSON parsing without deserializing to a specific type.
        /// </summary>
        /// <param name="json">The JSON string to parse. Must not be null.</param>
        /// <returns>
        ///     A dictionary where each key is a property name from the JSON object and the value
        ///     is its string representation. Complex values (objects and arrays) are returned as
        ///     raw JSON substrings. Returns an empty dictionary for empty or whitespace-only input.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="json" /> is null.</exception>
        /// <exception cref="Exceptions.JsonParsingException">Thrown when JSON parsing fails due to malformed input.</exception>
        /// <remarks>
        ///     This method provides low-level access to JSON parsing. It returns a raw dictionary
        ///     of property names and values without deserializing to a specific type.
        ///     Complex values (objects and arrays) are returned as raw JSON strings.
        ///     Time Complexity: O(n) where n is the length of the JSON string.
        ///     Space Complexity: O(n) for the output dictionary.
        /// </remarks>
        /// <example>
        ///     <code>
        ///     string json = "{\"Name\":\"John\",\"Age\":\"30\"}";
        ///     var props = JsonNativeAot.ParseJsonToDictionary(json);
        ///     // props["Name"] = "John"
        ///     // props["Age"] = "30"
        ///     </code>
        /// </example>
        public static Dictionary<string, string> ParseJsonToDictionary(string json) => _jsonParser.Value.ParseToDictionary(json);

        /// <summary>
        ///     Deserializes a JSON file from disk into a new instance of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">
        ///     The target type for deserialization. Must implement <see cref="IJsonSerializable" />
        ///     and <see cref="IJsonDesSerializable{T}" />, and have a parameterless constructor.
        /// </typeparam>
        /// <param name="fileName">The name of the input file without the .json extension. Must not be null.</param>
        /// <param name="relativePath">The relative directory path (relative to the current working directory) where the file is located. Must not be null.</param>
        /// <returns>A new instance of <typeparamref name="T" /> populated with data from the JSON file.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileName" /> or <paramref name="relativePath" /> is null.</exception>
        /// <exception cref="System.IO.FileNotFoundException">Thrown when the specified file does not exist.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the file cannot be read.</exception>
        public static T DeserializeFromFile<T>(string fileName, string relativePath) where T : IJsonSerializable, IJsonDesSerializable<T>, new() => _jsonFileHandler.Value.DeserializeFromFile<T>(fileName, relativePath);
    }
}