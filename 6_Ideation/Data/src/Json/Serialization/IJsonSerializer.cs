// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IJsonSerializer.cs
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

namespace Alis.Core.Aspect.Data.Json.Serialization
{
    /// <summary>
    ///     Defines a contract for serializing objects that implement IJsonSerializable to JSON strings.
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        ///     Serializes an object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize, which must implement IJsonSerializable.</typeparam>
        /// <param name="instance">The instance to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when instance is null.</exception>
        string Serialize<T>(T instance) where T : IJsonSerializable;
    }
}

