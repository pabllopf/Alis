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

using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Core;
using Xunit;

namespace Alis.Extension.Network.Test.Core
{
    /// <summary>
    ///     Tests for INetworkSerializer interface
    /// </summary>
    public class INetworkSerializerTest
    {
        private class TestNetworkSerializer : INetworkSerializer
        {
            public string SerializeEnvelope(NetworkMessageEnvelope envelope) => "{}";
            
            public NetworkMessageEnvelope DeserializeEnvelope(string json) => new NetworkMessageEnvelope();
            
            string INetworkSerializer.Serialize<T>(T obj) => "{}";
            T INetworkSerializer.Deserialize<T>(string json) => default;
        }
        

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
