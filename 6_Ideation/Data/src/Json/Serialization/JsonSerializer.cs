// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonSerializer.cs
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
using System.Text;
using Alis.Core.Aspect.Data.Json.Exceptions;

namespace Alis.Core.Aspect.Data.Json.Serialization
{
    /// <summary>
    ///     Serializes objects that implement IJsonSerializable to JSON strings.
    /// </summary>
    public sealed class JsonSerializer : IJsonSerializer
    {
        /// <summary>
        ///     Serializes an object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize, which must implement IJsonSerializable.</typeparam>
        /// <param name="instance">The instance to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        /// <exception cref="ArgumentNullException">Thrown when instance is null.</exception>
        /// <exception cref="JsonSerializationException">Thrown when serialization fails.</exception>
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
        ///     Determines if a string value represents a complex JSON structure (object or array).
        /// </summary>
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

