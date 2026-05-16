// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkSerializer.cs
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
    ///     Network serializer implementation using ALIS Data
    /// </summary>
    public sealed class NetworkSerializer : INetworkSerializer
    {
        /// <summary>
        ///     Serializes object to JSON string
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        /// <typeparam name="T">The type of the object, must implement IJsonSerializable</typeparam>
        /// <returns>A JSON string representation of the object</returns>
        public string Serialize<T>(T obj) where T : IJsonSerializable => JsonNativeAot.Serialize(obj);

        /// <summary>
        ///     Deserializes JSON string to object
        /// </summary>
        /// <param name="json">The JSON string to deserialize</param>
        /// <typeparam name="T">The target type</typeparam>
        /// <returns>The deserialized object</returns>
        public T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new() => JsonNativeAot.Deserialize<T>(json);

        /// <summary>
        ///     Serializes envelope
        /// </summary>
        /// <param name="envelope">The envelope to serialize</param>
        /// <returns>A JSON string representation of the envelope</returns>
        public string SerializeEnvelope(NetworkMessageEnvelope envelope) => Serialize(envelope);

        /// <summary>
        ///     Deserializes envelope
        /// </summary>
        /// <param name="json">The JSON string to deserialize</param>
        /// <returns>The deserialized network message envelope</returns>
        public NetworkMessageEnvelope DeserializeEnvelope(string json) => Deserialize<NetworkMessageEnvelope>(json);
    }
}