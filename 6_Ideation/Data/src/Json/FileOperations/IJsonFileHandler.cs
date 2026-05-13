// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IJsonFileHandler.cs
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

namespace Alis.Core.Aspect.Data.Json.FileOperations
{
    /// <summary>
    ///     Defines a contract for reading JSON files into objects and writing objects to JSON files.
    ///     Implementing types handle file I/O operations including directory creation, file existence
    ///     checking, and delegation to the configured serializer and deserializer.
    /// </summary>
    /// <remarks>
    ///     File paths are constructed by combining the current working directory with the provided
    ///     relative path. The .json extension is appended automatically. Directories are created
    ///     if they do not exist during serialization.
    /// </remarks>
    public interface IJsonFileHandler
    {
        /// <summary>
        ///     Serializes the specified object to a JSON file at the given location.
        ///     Creates the target directory if it does not exist.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize. Must implement <see cref="IJsonSerializable" />.</typeparam>
        /// <param name="instance">The object instance to serialize and write to disk. Must not be null.</param>
        /// <param name="fileName">The name of the output file without the .json extension (the extension is appended automatically). Must not be null.</param>
        /// <param name="relativePath">The relative directory path (relative to the current working directory) where the file will be saved. Must not be null.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="instance" />, <paramref name="fileName" />, or <paramref name="relativePath" /> is null.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the file cannot be written due to an I/O error.</exception>
        void SerializeToFile<T>(T instance, string fileName, string relativePath) where T : IJsonSerializable;

        /// <summary>
        ///     Deserializes a JSON file into an object of the specified type.
        ///     Reads the file content, parses the JSON, and constructs an object instance.
        /// </summary>
        /// <typeparam name="T">
        ///     The target type for deserialization. Must implement <see cref="IJsonSerializable" />
        ///     and <see cref="IJsonDesSerializable{T}" />, and have a parameterless constructor.
        /// </typeparam>
        /// <param name="fileName">The name of the input file without the .json extension (the extension is appended automatically). Must not be null.</param>
        /// <param name="relativePath">The relative directory path (relative to the current working directory) where the file is located. Must not be null.</param>
        /// <returns>A new instance of <typeparamref name="T" /> populated with data from the JSON file.</returns>
        /// <exception cref="System.IO.FileNotFoundException">Thrown when the specified file does not exist.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="fileName" /> or <paramref name="relativePath" /> is null.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the file cannot be read due to an I/O error.</exception>
        T DeserializeFromFile<T>(string fileName, string relativePath) where T : IJsonSerializable, IJsonDesSerializable<T>, new();
    }
}