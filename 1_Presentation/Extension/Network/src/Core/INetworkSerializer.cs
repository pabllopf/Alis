// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkSerializer.cs
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

using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Network serializer using ALIS Data JSON
    /// </summary>
    public interface INetworkSerializer
    {
        /// <summary>
        ///     Serializes object to JSON string
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <typeparam name="T">The type of the object to serialize, must implement IJsonSerializable</typeparam>
        /// <returns>A JSON string representation of the object</returns>
        string Serialize<T>(T obj) where T : IJsonSerializable;

        /// <summary>
        ///     Deserializes JSON string to object
        /// </summary>
        /// <param name="json">The JSON string to deserialize</param>
        /// <typeparam name="T">The target type, must implement IJsonSerializable and IJsonDesSerializable</typeparam>
        /// <returns>The deserialized object</returns>
        T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new();

        /// <summary>
        ///     Serializes envelope
        /// </summary>
        /// <param name="envelope">The network message envelope to serialize</param>
        /// <returns>A JSON string representation of the envelope</returns>
        string SerializeEnvelope(NetworkMessageEnvelope envelope);

        /// <summary>
        ///     Deserializes envelope
        /// </summary>
        /// <param name="json">The JSON string to deserialize into an envelope</param>
        /// <returns>The deserialized network message envelope</returns>
        NetworkMessageEnvelope DeserializeEnvelope(string json);
    }
}