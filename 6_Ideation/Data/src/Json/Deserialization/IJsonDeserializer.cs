// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IJsonDeserializer.cs
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

namespace Alis.Core.Aspect.Data.Json.Deserialization
{
    /// <summary>
    ///     Defines a contract for deserializing JSON strings into typed objects.
    ///     Implementing types coordinate a JSON parser with object construction via
    ///     <see cref="IJsonDesSerializable{T}.CreateFromProperties" /> to produce fully
    ///     populated object instances from their JSON string representation.
    /// </summary>
    /// <remarks>
    ///     The deserialization pipeline works in two stages:
    ///     (1) Parse the JSON string into a flat dictionary of key-value string pairs using
    ///     an <see cref="IJsonParser" /> implementation.
    ///     (2) Instantiate the target type using its parameterless constructor and call
    ///     <see cref="IJsonDesSerializable{T}.CreateFromProperties" /> to populate it from
    ///     the parsed dictionary.
    /// </remarks>
    public interface IJsonDeserializer
    {
        /// <summary>
        ///     Deserializes the specified JSON string into a new instance of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">
        ///     The target type for deserialization. Must implement <see cref="IJsonSerializable" />
        ///     and <see cref="IJsonDesSerializable{T}" />, and have a parameterless constructor.
        /// </typeparam>
        /// <param name="json">The JSON string to deserialize. Must not be null.</param>
        /// <returns>A new instance of <typeparamref name="T" /> with properties populated from the JSON data.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="json" /> is null.</exception>
        T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new();
    }
}