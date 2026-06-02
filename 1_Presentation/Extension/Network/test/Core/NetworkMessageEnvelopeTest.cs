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
    }
}
