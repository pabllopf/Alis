// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkMessageEnvelope.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Network message envelope for framing and routing
    /// </summary>
    public class NetworkMessageEnvelope : IJsonSerializable, IJsonDesSerializable<NetworkMessageEnvelope>
    {
        /// <summary>
        ///     Unique message identifier
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        ///     Message type identifier
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        ///     Sender player ID
        /// </summary>
        public string SenderId { get; set; }

        /// <summary>
        ///     Target player ID (null for broadcast)
        /// </summary>
        public string TargetId { get; set; }

        /// <summary>
        ///     Channel identifier
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        ///     Message payload as JSON string
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        ///     Server timestamp
        /// </summary>
        public long ServerTimestamp { get; set; }

        /// <summary>
        ///     Client timestamp
        /// </summary>
        public long ClientTimestamp { get; set; }

        /// <summary>
        ///     Message sequence number
        /// </summary>
        public uint SequenceNumber { get; set; }

        /// <summary>
        ///     Is reliable delivery
        /// </summary>
        public bool IsReliable { get; set; } = true;

        /// <summary>
        ///     Is ordered delivery
        /// </summary>
        public bool IsOrdered { get; set; } = true;

        /// <summary>
        ///     Gets serializable properties
        /// </summary>
        public IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(MessageId), MessageId);
            yield return (nameof(MessageType), MessageType);
            yield return (nameof(SenderId), SenderId);
            yield return (nameof(TargetId), TargetId);
            yield return (nameof(Channel), Channel);
            yield return (nameof(Payload), Payload);
            yield return (nameof(ServerTimestamp), ServerTimestamp.ToString());
            yield return (nameof(ClientTimestamp), ClientTimestamp.ToString());
            yield return (nameof(SequenceNumber), SequenceNumber.ToString());
            yield return (nameof(IsReliable), IsReliable.ToString());
            yield return (nameof(IsOrdered), IsOrdered.ToString());
        }

        /// <summary>
        ///     Creates instance from properties
        /// </summary>
        public NetworkMessageEnvelope CreateFromProperties(Dictionary<string, string> properties)
        {
            if (properties == null)
                return new NetworkMessageEnvelope();

            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
            {
                MessageId = properties.ContainsKey(nameof(MessageId)) ? properties[nameof(MessageId)] : null,
                MessageType = properties.ContainsKey(nameof(MessageType)) ? properties[nameof(MessageType)] : null,
                SenderId = properties.ContainsKey(nameof(SenderId)) ? properties[nameof(SenderId)] : null,
                TargetId = properties.ContainsKey(nameof(TargetId)) ? properties[nameof(TargetId)] : null,
                Channel = properties.ContainsKey(nameof(Channel)) ? properties[nameof(Channel)] : null,
                Payload = properties.ContainsKey(nameof(Payload)) ? properties[nameof(Payload)] : null,
                ServerTimestamp = properties.ContainsKey(nameof(ServerTimestamp)) && long.TryParse(properties[nameof(ServerTimestamp)], out long st) ? st : 0,
                ClientTimestamp = properties.ContainsKey(nameof(ClientTimestamp)) && long.TryParse(properties[nameof(ClientTimestamp)], out long ct) ? ct : 0,
                SequenceNumber = properties.ContainsKey(nameof(SequenceNumber)) && uint.TryParse(properties[nameof(SequenceNumber)], out uint sn) ? sn : 0,
                IsReliable = properties.ContainsKey(nameof(IsReliable)) && bool.TryParse(properties[nameof(IsReliable)], out bool ir) ? ir : true,
                IsOrdered = properties.ContainsKey(nameof(IsOrdered)) && bool.TryParse(properties[nameof(IsOrdered)], out bool io) ? io : true
            };

            return envelope;
        }
    }
}


