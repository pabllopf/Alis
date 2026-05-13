// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonSerializer.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Alis.Core.Aspect.Data.Json.Exceptions;

namespace Alis.Core.Aspect.Data.Json.Serialization
{
    /// <summary>
    ///     Provides JSON serialization for objects implementing <see cref="IJsonSerializable" />.
    ///     Converts an object's serializable properties into a compact JSON string representation,
    ///     properly quoting primitive values and inserting complex nested structures as raw JSON.
    /// </summary>
    /// <remarks>
    ///     The serializer iterates over the property tuples returned by
    ///     <see cref="IJsonSerializable.GetSerializableProperties" /> and builds a JSON object string.
    ///     Properties with null values are skipped. Complex values (JSON objects or arrays starting
    ///     with '{' or '[') are appended without additional quoting. All other values are escaped
    ///     and quoted as JSON strings.
    ///     This class is used internally by <see cref="JsonNativeAot.Serialize{T}" />.
    /// </remarks>
    public sealed class JsonSerializer : IJsonSerializer
    {
        /// <summary>
        ///     Serializes the specified object instance into a JSON string representation.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize. Must implement <see cref="IJsonSerializable" />.</typeparam>
        /// <param name="instance">The object instance to serialize. Must not be null.</param>
        /// <returns>
        ///     A JSON string representation of the object enclosed in curly braces.
        ///     Returns "{}" if all properties have null values or if no properties are defined.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="instance" /> is null.</exception>
        /// <exception cref="JsonSerializationException">Thrown when serialization fails due to an underlying error.</exception>
        [ExcludeFromCodeCoverage]
        public string Serialize<T>(T instance) where T : IJsonSerializable
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            try
            {
                StringBuilder jsonBuilder = new StringBuilder();
                jsonBuilder.Append("{");

                bool isFirst = true;

                foreach ((string propertyName, string value) in instance.GetSerializableProperties())
                {
                    if (value == null)
                    {
                        continue;
                    }

                    if (!isFirst)
                    {
                        jsonBuilder.Append(",");
                    }

                    jsonBuilder.Append($"\"{propertyName}\":");

                    if (IsComplexJsonValue(value))
                    {
                        jsonBuilder.Append(value);
                    }
                    else
                    {
                        jsonBuilder.Append($"\"{value}\"");
                    }

                    isFirst = false;
                }

                jsonBuilder.Append("}");
                return jsonBuilder.ToString();
            }
            catch (JsonSerializationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException($"Failed to serialize object of type {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        /// <summary>
        ///     Determines whether the specified string value represents a complex JSON structure
        ///     (a JSON object or JSON array) rather than a simple primitive value.
        /// </summary>
        /// <param name="value">The string value to evaluate. May be null or empty.</param>
        /// <returns>
        ///     <c>true</c> if the trimmed value starts with '{' (object) or '[' (array);
        ///     otherwise, <c>false</c>. Returns <c>false</c> for null, empty, or whitespace-only strings.
        /// </returns>
        private static bool IsComplexJsonValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            string trimmed = value.TrimStart();
            return trimmed.StartsWith("{") || trimmed.StartsWith("[");
        }
    }
}