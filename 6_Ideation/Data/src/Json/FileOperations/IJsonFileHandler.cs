// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IJsonFileHandler.cs
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

namespace Alis.Core.Aspect.Data.Json.FileOperations
{
    /// <summary>
    ///     Defines a contract for reading and writing JSON files.
    /// </summary>
    public interface IJsonFileHandler
    {
        /// <summary>
        ///     Serializes an object to a JSON file.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize, which must implement IJsonSerializable.</typeparam>
        /// <param name="instance">The instance to serialize.</param>
        /// <param name="fileName">The name of the file (without .json extension).</param>
        /// <param name="relativePath">The relative path where the file will be saved.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when parameters are null.</exception>
        void SerializeToFile<T>(T instance, string fileName, string relativePath) where T : IJsonSerializable;

        /// <summary>
        ///     Deserializes a JSON file into an object.
        /// </summary>
        /// <typeparam name="T">The target type, which must implement IJsonSerializable and IJsonDesSerializable&lt;T&gt;.</typeparam>
        /// <param name="fileName">The name of the file (without .json extension).</param>
        /// <param name="relativePath">The relative path where the file is located.</param>
        /// <returns>An instance of the specified type populated with data from the JSON file.</returns>
        /// <exception cref="System.IO.FileNotFoundException">Thrown when the file does not exist.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when parameters are null.</exception>
        T DeserializeFromFile<T>(string fileName, string relativePath) where T : IJsonSerializable, IJsonDesSerializable<T>, new();
    }
}

