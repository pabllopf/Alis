// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkMessageEnvelopeTest.cs
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

using System.Collections.Generic;
using System.Linq;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     The network message envelope test class
    /// </summary>
    public class NetworkMessageEnvelopeTest
    {
        /// <summary>
        ///     Tests that default values are set correctly
        /// </summary>
        [Fact]
        public void DefaultValues_AreSetCorrectly()
        {
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope();

            Assert.Null(envelope.MessageId);
            Assert.Null(envelope.MessageType);
            Assert.Null(envelope.SenderId);
            Assert.Null(envelope.TargetId);
            Assert.Null(envelope.Channel);
            Assert.Null(envelope.Payload);
            Assert.Equal(0, envelope.ServerTimestamp);
            Assert.Equal(0, envelope.ClientTimestamp);
            Assert.Equal((uint)0, envelope.SequenceNumber);
            Assert.True(envelope.IsReliable);
            Assert.True(envelope.IsOrdered);
        }

        /// <summary>
        ///     Tests that properties can be set and retrieved
        /// </summary>
        [Fact]
        public void Properties_SetAndGet_ReturnCorrectValues()
        {
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
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
                IsReliable = false,
                IsOrdered = false
            };

            Assert.Equal("msg-1", envelope.MessageId);
            Assert.Equal("chat", envelope.MessageType);
            Assert.Equal("sender-1", envelope.SenderId);
            Assert.Equal("target-1", envelope.TargetId);
            Assert.Equal("global", envelope.Channel);
            Assert.Equal("hello", envelope.Payload);
            Assert.Equal(1000, envelope.ServerTimestamp);
            Assert.Equal(500, envelope.ClientTimestamp);
            Assert.Equal((uint)42, envelope.SequenceNumber);
            Assert.False(envelope.IsReliable);
            Assert.False(envelope.IsOrdered);
        }

        /// <summary>
        ///     Tests that create from properties returns envelope with correct values
        /// </summary>
        [Fact]
        public void CreateFromProperties_WithValidData_ReturnsEnvelope()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                {"MessageId", "msg-1"},
                {"MessageType", "chat"},
                {"SenderId", "sender-1"},
                {"TargetId", "target-1"},
                {"Channel", "global"},
                {"Payload", "hello"},
                {"ServerTimestamp", "1000"},
                {"ClientTimestamp", "500"},
                {"SequenceNumber", "42"},
                {"IsReliable", "false"},
                {"IsOrdered", "false"}
            };

            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope().CreateFromProperties(properties);

            Assert.Equal("msg-1", envelope.MessageId);
            Assert.Equal("chat", envelope.MessageType);
            Assert.Equal("sender-1", envelope.SenderId);
            Assert.Equal("target-1", envelope.TargetId);
            Assert.Equal("global", envelope.Channel);
            Assert.Equal("hello", envelope.Payload);
            Assert.Equal(1000, envelope.ServerTimestamp);
            Assert.Equal(500, envelope.ClientTimestamp);
            Assert.Equal((uint)42, envelope.SequenceNumber);
            Assert.False(envelope.IsReliable);
            Assert.False(envelope.IsOrdered);
        }

        /// <summary>
        ///     Tests that create from properties with null returns default envelope
        /// </summary>
        [Fact]
        public void CreateFromProperties_WithNull_ReturnsDefaultEnvelope()
        {
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope().CreateFromProperties(null);

            Assert.NotNull(envelope);
            Assert.Null(envelope.MessageId);
        }

        /// <summary>
        ///     Tests that create from properties with empty returns default values
        /// </summary>
        [Fact]
        public void CreateFromProperties_WithEmpty_ReturnsDefaults()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope().CreateFromProperties(properties);

            Assert.Null(envelope.MessageId);
            Assert.Equal((uint)0, envelope.SequenceNumber);
            Assert.True(envelope.IsReliable);
            Assert.True(envelope.IsOrdered);
        }

        /// <summary>
        ///     Tests that get serializable properties returns all expected tuples
        /// </summary>
        [Fact]
        public void GetSerializableProperties_ReturnsAllProperties()
        {
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
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
                IsOrdered = true
            };

            var properties = envelope.GetSerializableProperties().ToList();

            Assert.Equal(11, properties.Count);
            Assert.Contains(("MessageId", "msg-1"), properties);
            Assert.Contains(("MessageType", "chat"), properties);
            Assert.Contains(("SenderId", "sender-1"), properties);
            Assert.Contains(("TargetId", "target-1"), properties);
            Assert.Contains(("Channel", "global"), properties);
            Assert.Contains(("Payload", "hello"), properties);
            Assert.Contains(("ServerTimestamp", "1000"), properties);
            Assert.Contains(("ClientTimestamp", "500"), properties);
            Assert.Contains(("SequenceNumber", "42"), properties);
            Assert.Contains(("IsReliable", "True"), properties);
            Assert.Contains(("IsOrdered", "True"), properties);
        }
    }
}
