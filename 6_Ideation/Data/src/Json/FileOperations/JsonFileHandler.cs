// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: JsonFileHandler.cs
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
using System.IO;
using Alis.Core.Aspect.Data.Json.Deserialization;
using Alis.Core.Aspect.Data.Json.Serialization;

namespace Alis.Core.Aspect.Data.Json.FileOperations
{
    /// <summary>
    ///     Handles reading and writing JSON files.
    /// </summary>
    public sealed class JsonFileHandler : IJsonFileHandler
    {
        /// <summary>
        /// The json serializer
        /// </summary>
        private readonly IJsonSerializer _jsonSerializer;
        /// <summary>
        /// The json deserializer
        /// </summary>
        private readonly IJsonDeserializer _jsonDeserializer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonFileHandler" /> class.
        /// </summary>
        /// <param name="jsonSerializer">The JSON serializer to use.</param>
        /// <param name="jsonDeserializer">The JSON deserializer to use.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
        public JsonFileHandler(IJsonSerializer jsonSerializer, IJsonDeserializer jsonDeserializer)
        {
            _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
            _jsonDeserializer = jsonDeserializer ?? throw new ArgumentNullException(nameof(jsonDeserializer));
        }

        /// <summary>
        ///     Serializes an object to a JSON file.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize, which must implement IJsonSerializable.</typeparam>
        /// <param name="instance">The instance to serialize.</param>
        /// <param name="fileName">The name of the file (without .json extension).</param>
        /// <param name="relativePath">The relative path where the file will be saved.</param>
        /// <exception cref="ArgumentNullException">Thrown when parameters are null.</exception>
        /// <exception cref="System.IO.IOException">Thrown when file operations fail.</exception>
        public void SerializeToFile<T>(T instance, string fileName, string relativePath) where T : IJsonSerializable
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (relativePath == null)
            {
                throw new ArgumentNullException(nameof(relativePath));
            }

            try
            {
                string json = _jsonSerializer.Serialize(instance);
                string directoryPath = Path.Combine(Environment.CurrentDirectory, relativePath);
                string filePath = Path.Combine(directoryPath, $"{fileName}.json");

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to write JSON file '{fileName}' to '{relativePath}': {ex.Message}", ex);
            }
        }

        /// <summary>
        ///     Deserializes a JSON file into an object.
        /// </summary>
        /// <typeparam name="T">The target type, which must implement IJsonSerializable and IJsonDesSerializable&lt;T&gt;.</typeparam>
        /// <param name="fileName">The name of the file (without .json extension).</param>
        /// <param name="relativePath">The relative path where the file is located.</param>
        /// <returns>An instance of the specified type populated with data from the JSON file.</returns>
        /// <exception cref="System.IO.FileNotFoundException">Thrown when the file does not exist.</exception>
        /// <exception cref="ArgumentNullException">Thrown when parameters are null.</exception>
        /// <exception cref="System.IO.IOException">Thrown when file operations fail.</exception>
        public T DeserializeFromFile<T>(string fileName, string relativePath) where T : IJsonSerializable, IJsonDesSerializable<T>, new()
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (relativePath == null)
            {
                throw new ArgumentNullException(nameof(relativePath));
            }

            try
            {
                string directoryPath = Path.Combine(Environment.CurrentDirectory, relativePath);
                string filePath = Path.Combine(directoryPath, $"{fileName}.json");

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"JSON file '{filePath}' not found.");
                }

                string json = File.ReadAllText(filePath);
                return _jsonDeserializer.Deserialize<T>(json);
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to read JSON file '{fileName}' from '{relativePath}': {ex.Message}", ex);
            }
        }
    }
}

