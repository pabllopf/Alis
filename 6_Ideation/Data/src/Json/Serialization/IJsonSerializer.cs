// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IJsonSerializer.cs
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

namespace Alis.Core.Aspect.Data.Json.Serialization
{
    /// <summary>
    ///     Defines a contract for serializing objects that implement <see cref="IJsonSerializable" />
    ///     into their JSON string representation.
    /// </summary>
    /// <remarks>
    ///     Implementations traverse the properties provided by <see cref="IJsonSerializable.GetSerializableProperties" />
    ///     and produce a compact JSON object string. Primitive values are quoted; complex values (objects or arrays)
    ///     are inserted as raw JSON. Null-valued properties are skipped.
    /// </remarks>
    public interface IJsonSerializer
    {
        /// <summary>
        ///     Serializes the specified object instance to a JSON string representation.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize. Must implement <see cref="IJsonSerializable" />.</typeparam>
        /// <param name="instance">The object instance to serialize into JSON. Must not be null.</param>
        /// <returns>A JSON string representing the serialized object, enclosed in curly braces.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="instance" /> is null.</exception>
        string Serialize<T>(T instance) where T : IJsonSerializable;
    }
}