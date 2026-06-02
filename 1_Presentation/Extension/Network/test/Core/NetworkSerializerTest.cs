// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkSerializerTest.cs
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
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     The network serializer test class
    /// </summary>
    public class NetworkSerializerTest
    {
        /// <summary>
        ///     Tests that serialize and deserialize envelope round-trips correctly
        /// </summary>
        [Fact]
        public void SerializeEnvelope_DeserializeEnvelope_RoundTrips()
        {
            NetworkSerializer serializer = new NetworkSerializer();
            NetworkMessageEnvelope original = new NetworkMessageEnvelope
            {
                MessageId = "msg-1",
                MessageType = "chat",
                SenderId = "sender-1",
                TargetId = "target-1",
                Channel = "global",
                Payload = "hello",
                ServerTimestamp = 1000,
                ClientTimestamp = 500,
                SequenceNumber = 42,
                IsReliable = true,
                IsOrdered = false
            };

            string json = serializer.SerializeEnvelope(original);
            NetworkMessageEnvelope result = serializer.DeserializeEnvelope(json);

            Assert.Equal(original.MessageId, result.MessageId);
            Assert.Equal(original.MessageType, result.MessageType);
            Assert.Equal(original.SenderId, result.SenderId);
            Assert.Equal(original.TargetId, result.TargetId);
            Assert.Equal(original.Channel, result.Channel);
            Assert.Equal(original.Payload, result.Payload);
            Assert.Equal(original.ServerTimestamp, result.ServerTimestamp);
            Assert.Equal(original.ClientTimestamp, result.ClientTimestamp);
            Assert.Equal(original.SequenceNumber, result.SequenceNumber);
            Assert.Equal(original.IsReliable, result.IsReliable);
            Assert.Equal(original.IsOrdered, result.IsOrdered);
        }

        /// <summary>
        ///     Tests that serialize and deserialize empty envelope round-trips correctly
        /// </summary>
        [Fact]
        public void SerializeEnvelope_Empty_RoundTrips()
        {
            NetworkSerializer serializer = new NetworkSerializer();
            NetworkMessageEnvelope original = new NetworkMessageEnvelope();

            string json = serializer.SerializeEnvelope(original);
            NetworkMessageEnvelope result = serializer.DeserializeEnvelope(json);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that serialize and deserialize envelope with null values round-trips correctly
        /// </summary>
        [Fact]
        public void SerializeEnvelope_WithNullValues_RoundTrips()
        {
            NetworkSerializer serializer = new NetworkSerializer();
            NetworkMessageEnvelope original = new NetworkMessageEnvelope
            {
                MessageId = null,
                MessageType = null,
                Payload = null
            };

            string json = serializer.SerializeEnvelope(original);
            NetworkMessageEnvelope result = serializer.DeserializeEnvelope(json);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that serialize generic method works with envelope
        /// </summary>
        [Fact]
        public void Serialize_Generic_WithEnvelope_ReturnsJson()
        {
            NetworkSerializer serializer = new NetworkSerializer();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
            {
                MessageId = "test",
                Payload = "data"
            };

            string json = serializer.Serialize(envelope);

            Assert.NotNull(json);
            Assert.NotEmpty(json);
        }

        /// <summary>
        ///     Tests that deserialize generic method works with envelope
        /// </summary>
        [Fact]
        public void Deserialize_Generic_WithEnvelope_ReturnsObject()
        {
            NetworkSerializer serializer = new NetworkSerializer();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
            {
                MessageId = "test-id",
                MessageType = "test-type",
                Payload = "test-payload"
            };

            string json = serializer.Serialize(envelope);
            NetworkMessageEnvelope result = serializer.Deserialize<NetworkMessageEnvelope>(json);

            Assert.Equal("test-id", result.MessageId);
            Assert.Equal("test-type", result.MessageType);
            Assert.Equal("test-payload", result.Payload);
        }

        /// <summary>
        ///     Tests that deserialize envelope invalid json throws exception
        /// </summary>
        [Fact]
        public void DeserializeEnvelope_InvalidJson_ThrowsException()
        {
            NetworkSerializer serializer = new NetworkSerializer();

            Assert.ThrowsAny<Exception>(() => serializer.DeserializeEnvelope("invalid json {"));
        }

        /// <summary>
        ///     Tests that serialize envelope null payload returns json
        /// </summary>
        [Fact]
        public void SerializeEnvelope_NullPayload_ReturnsJson()
        {
            NetworkSerializer serializer = new NetworkSerializer();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope {Payload = null};

            string json = serializer.SerializeEnvelope(envelope);

            Assert.NotNull(json);
            Assert.NotEmpty(json);
        }
    }
}
