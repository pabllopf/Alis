// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetworkSerializerTest.cs
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

using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     Tests for INetworkSerializer interface
    /// </summary>
    public class INetworkSerializerTest
    {
        /// <summary>
        /// The test network serializer class
        /// </summary>
        /// <seealso cref="INetworkSerializer"/>
        private class TestNetworkSerializer : INetworkSerializer
        {
            /// <summary>
            /// Serializes the envelope using the specified envelope
            /// </summary>
            /// <param name="envelope">The envelope</param>
            /// <returns>The string</returns>
            public string SerializeEnvelope(NetworkMessageEnvelope envelope) => "{}";
            
            /// <summary>
            /// Deserializes the envelope using the specified json
            /// </summary>
            /// <param name="json">The json</param>
            /// <returns>The network message envelope</returns>
            public NetworkMessageEnvelope DeserializeEnvelope(string json) => new NetworkMessageEnvelope();
            
            /// <summary>
            /// Serializes the obj
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="obj">The obj</param>
            /// <returns>The string</returns>
            string INetworkSerializer.Serialize<T>(T obj) => "{}";
            /// <summary>
            /// Deserializes the json
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="json">The json</param>
            /// <returns>The</returns>
            T INetworkSerializer.Deserialize<T>(string json) => default;
        }
        

        /// <summary>
        /// Tests that deserialize envelope deserializes envelope
        /// </summary>
        [Fact]
        public void DeserializeEnvelope_DeserializesEnvelope()
        {
            // Arrange
            TestNetworkSerializer serializer = new TestNetworkSerializer();

            // Act
            NetworkMessageEnvelope result = serializer.DeserializeEnvelope("{}");

            // Assert
            Assert.NotNull(result);
        }

    }
}
