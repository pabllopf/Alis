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
    ///     The json native aot class
    /// </summary>
    public static class JsonNativeAot
    {
        /// <summary>
        /// The escape sequence handler
        /// </summary>
        private static readonly Lazy<IEscapeSequenceHandler> _escapeSequenceHandler = 
            new(() => new EscapeSequenceHandler());

        /// <summary>
        /// The value
        /// </summary>
        private static readonly Lazy<IJsonParser> _jsonParser = 
            new(() => new JsonParser(_escapeSequenceHandler.Value));

        /// <summary>
        /// The json serializer
        /// </summary>
        private static readonly Lazy<IJsonSerializer> _jsonSerializer = 
            new(() => new JsonSerializer());

        /// <summary>
        /// The value
        /// </summary>
        private static readonly Lazy<IJsonDeserializer> _jsonDeserializer = 
            new(() => new JsonDeserializer(_jsonParser.Value));

        /// <summary>
        /// The value
        /// </summary>
        private static readonly Lazy<IJsonFileHandler> _jsonFileHandler = 
            new(() => new JsonFileHandler(_jsonSerializer.Value, _jsonDeserializer.Value));

        /// <summary>
        ///     Serializes an object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="instance">The instance to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string Serialize<T>(T instance) where T : IJsonSerializable
        {
            return _jsonSerializer.Value.Serialize(instance);
        }

        /// <summary>
        ///     Serializes an object to a JSON file.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="instance">The instance to serialize.</param>
        /// <param name="fileName">The name of the file (without .json extension).</param>
        /// <param name="relativePath">The relative path where the file will be saved.</param>
        public static void SerializeToFile<T>(T instance, string fileName, string relativePath) where T : IJsonSerializable
        {
            _jsonFileHandler.Value.SerializeToFile(instance, fileName, relativePath);
        }

        /// <summary>
        ///     Deserializes a JSON string into an object.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>An instance of the specified type.</returns>
        public static T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new()
        {
            return _jsonDeserializer.Value.Deserialize<T>(json);
        }

        /// <summary>
        ///     Parses a JSON string into a dictionary of property names and their string values.
        /// </summary>
        /// <param name="json">The JSON string to parse.</param>
        /// <returns>A dictionary containing property names as keys and their string representations as values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when json is null.</exception>
        /// <exception cref="Exceptions.JsonParsingException">Thrown when JSON parsing fails.</exception>
        /// <remarks>
        ///     This method provides low-level access to JSON parsing. It returns a raw dictionary
        ///     of property names and values without deserializing to a specific type.
        ///     
        ///     Complex values (objects and arrays) are returned as raw JSON strings.
        ///     
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
        public static Dictionary<string, string> ParseJsonToDictionary(string json)
        {
            return _jsonParser.Value.ParseToDictionary(json);
        }

        /// <summary>
        ///     Deserializes a JSON file into an object.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="fileName">The name of the file (without .json extension).</param>
        /// <param name="relativePath">The relative path where the file is located.</param>
        /// <returns>An instance of the specified type.</returns>
        public static T DeserializeFromFile<T>(string fileName, string relativePath) where T : IJsonSerializable, IJsonDesSerializable<T>, new()
        {
            return _jsonFileHandler.Value.DeserializeFromFile<T>(fileName, relativePath);
        }
    }
}