// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonDeserializer.cs
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
using Alis.Core.Aspect.Data.Json.Parsing;

namespace Alis.Core.Aspect.Data.Json.Deserialization
{
    /// <summary>
    ///     Deserializes JSON strings into objects.
    /// </summary>
    public sealed class JsonDeserializer : IJsonDeserializer
    {
        /// <summary>
        /// The json parser
        /// </summary>
        private readonly IJsonParser _jsonParser;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonDeserializer" /> class.
        /// </summary>
        /// <param name="jsonParser">The JSON parser to use.</param>
        /// <exception cref="ArgumentNullException">Thrown when jsonParser is null.</exception>
        public JsonDeserializer(IJsonParser jsonParser)
        {
            _jsonParser = jsonParser ?? throw new ArgumentNullException(nameof(jsonParser));
        }

        /// <summary>
        ///     Deserializes a JSON string into an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The target type, which must implement IJsonSerializable and IJsonDesSerializable&lt;T&gt;.</typeparam>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>An instance of the specified type populated with data from the JSON.</returns>
        /// <exception cref="ArgumentNullException">Thrown when json is null.</exception>
        /// <exception cref="JsonDeserializationException">Thrown when deserialization fails.</exception>
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

