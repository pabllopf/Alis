// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonFileHandler.cs
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
using System.IO;
using Alis.Core.Aspect.Data.Json.Deserialization;
using Alis.Core.Aspect.Data.Json.Serialization;

namespace Alis.Core.Aspect.Data.Json.FileOperations
{
    /// <summary>
    ///     Provides JSON file I/O operations by coordinating a serializer and deserializer.
    ///     Handles file path construction, directory creation, file existence verification,
    ///     and delegates the actual JSON conversion to the injected <see cref="IJsonSerializer" />
    ///     and <see cref="IJsonDeserializer" /> instances.
    /// </summary>
    /// <remarks>
    ///     File paths are constructed by combining <see cref="Environment.CurrentDirectory" />
    ///     with the provided relative path. The .json extension is appended to the file name
    ///     automatically. During serialization, the target directory is created if it does not
    ///     already exist. During deserialization, a <see cref="FileNotFoundException" /> is
    ///     thrown if the file is missing. All I/O errors are wrapped in <see cref="IOException" />.
    /// </remarks>
    public sealed class JsonFileHandler : IJsonFileHandler
    {
        /// <summary>
        ///     The deserializer used to convert JSON file contents into typed objects.
        /// </summary>
        private readonly IJsonDeserializer _jsonDeserializer;

        /// <summary>
        ///     The serializer used to convert objects into JSON strings for file output.
        /// </summary>
        private readonly IJsonSerializer _jsonSerializer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonFileHandler" /> class with the
        ///     specified serializer and deserializer.
        /// </summary>
        /// <param name="jsonSerializer">The JSON serializer to use for converting objects to JSON strings. Must not be null.</param>
        /// <param name="jsonDeserializer">The JSON deserializer to use for converting JSON strings to objects. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="jsonSerializer" /> or <paramref name="jsonDeserializer" /> is null.</exception>
        public JsonFileHandler(IJsonSerializer jsonSerializer, IJsonDeserializer jsonDeserializer)
        {
            _jsonSerializer = jsonSerializer ?? throw new ArgumentNullException(nameof(jsonSerializer));
            _jsonDeserializer = jsonDeserializer ?? throw new ArgumentNullException(nameof(jsonDeserializer));
        }

        /// <summary>
        ///     Serializes the specified object to a JSON file on disk. The file is written
        ///     to a path composed of the current working directory, the relative path, and
        ///     the file name with a .json extension. The target directory is created if
        ///     it does not exist.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize. Must implement <see cref="IJsonSerializable" />.</typeparam>
        /// <param name="instance">The object instance to serialize and write to disk. Must not be null.</param>
        /// <param name="fileName">The name of the output file without the .json extension (appended automatically). Must not be null.</param>
        /// <param name="relativePath">The relative directory path (relative to the current working directory) for the output file. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="instance" />, <paramref name="fileName" />, or <paramref name="relativePath" /> is null.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the file cannot be written due to an I/O error.</exception>
        [ExcludeFromCodeCoverage]
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
        ///     Deserializes a JSON file from disk into a new instance of the specified type.
        ///     Reads the file content, delegates to the deserializer for JSON-to-object conversion,
        ///     and returns the populated instance.
        /// </summary>
        /// <typeparam name="T">
        ///     The target type for deserialization. Must implement <see cref="IJsonSerializable" />
        ///     and <see cref="IJsonDesSerializable{T}" />, and have a parameterless constructor.
        /// </typeparam>
        /// <param name="fileName">The name of the input file without the .json extension (appended automatically). Must not be null.</param>
        /// <param name="relativePath">The relative directory path (relative to the current working directory) where the file is located. Must not be null.</param>
        /// <returns>A new instance of <typeparamref name="T" /> populated with data from the JSON file.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileName" /> or <paramref name="relativePath" /> is null.</exception>
        /// <exception cref="System.IO.FileNotFoundException">Thrown when the specified file does not exist at the constructed path.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the file cannot be read due to an I/O error.</exception>
        [ExcludeFromCodeCoverage]
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