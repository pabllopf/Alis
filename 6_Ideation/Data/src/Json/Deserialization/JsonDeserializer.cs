// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonDeserializer.cs
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
using Alis.Core.Aspect.Data.Json.Exceptions;
using Alis.Core.Aspect.Data.Json.Parsing;

namespace Alis.Core.Aspect.Data.Json.Deserialization
{
    /// <summary>
    ///     Deserializes JSON strings into typed objects by coordinating a JSON parser with
    ///     the <see cref="IJsonDesSerializable{T}" /> interface. The deserialization pipeline
    ///     first parses the JSON into a flat property dictionary, then creates a new instance
    ///     of the target type and populates it via <see cref="IJsonDesSerializable{T}.CreateFromProperties" />.
    /// </summary>
    /// <remarks>
    ///     This class is used internally by <see cref="JsonNativeAot.Deserialize{T}" /> and
    ///     <see cref="FileOperations.JsonFileHandler.DeserializeFromFile{T}" />.
    ///     The deserialization process requires the target type to have a parameterless
    ///     constructor (enforced by the generic constraint) and to implement both
    ///     <see cref="IJsonSerializable" /> and <see cref="IJsonDesSerializable{T}" />.
    ///     All non-parsing exceptions are caught and wrapped in a
    ///     <see cref="JsonDeserializationException" /> for consistent error reporting.
    /// </remarks>
    public sealed class JsonDeserializer : IJsonDeserializer
    {
        /// <summary>
        ///     The JSON parser used to convert the JSON string into a flat dictionary of
        ///     property name-value string pairs.
        /// </summary>
        private readonly IJsonParser _jsonParser;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonDeserializer" /> class with the
        ///     specified JSON parser.
        /// </summary>
        /// <param name="jsonParser">The JSON parser instance used to parse JSON strings into property dictionaries. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="jsonParser" /> is null.</exception>
        public JsonDeserializer(IJsonParser jsonParser) => _jsonParser = jsonParser ?? throw new ArgumentNullException(nameof(jsonParser));

        /// <summary>
        ///     Deserializes the specified JSON string into a new instance of type <typeparamref name="T" />.
        ///     The JSON is first parsed into a dictionary, then a new object is created and populated
        ///     via the <see cref="IJsonDesSerializable{T}.CreateFromProperties" /> method.
        /// </summary>
        /// <typeparam name="T">
        ///     The target type for deserialization. Must implement <see cref="IJsonSerializable" />
        ///     and <see cref="IJsonDesSerializable{T}" />, and have a parameterless constructor.
        /// </typeparam>
        /// <param name="json">The JSON string to deserialize. Must not be null. Expected to represent a JSON object.</param>
        /// <returns>A new instance of <typeparamref name="T" /> with its properties populated from the JSON data.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="json" /> is null.</exception>
        /// <exception cref="JsonDeserializationException">Thrown when deserialization fails due to parsing errors or property population failures.</exception>
        [ExcludeFromCodeCoverage]
        public T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new()
        {
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            try
            {
                Dictionary<string, string> properties = _jsonParser.ParseToDictionary(json);
                return new T().CreateFromProperties(properties);
            }
            catch (JsonDeserializationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new JsonDeserializationException($"Failed to deserialize JSON to type {typeof(T).Name}: {ex.Message}", ex);
            }
        }
    }
}