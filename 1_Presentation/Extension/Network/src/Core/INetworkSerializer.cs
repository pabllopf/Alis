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
        string Serialize<T>(T obj) where T : IJsonSerializable;

        /// <summary>
        ///     Deserializes JSON string to object
        /// </summary>
        T Deserialize<T>(string json) where T : IJsonSerializable, IJsonDesSerializable<T>, new();

        /// <summary>
        ///     Serializes envelope
        /// </summary>
        string SerializeEnvelope(NetworkMessageEnvelope envelope);

        /// <summary>
        ///     Deserializes envelope
        /// </summary>
        NetworkMessageEnvelope DeserializeEnvelope(string json);
    }
}