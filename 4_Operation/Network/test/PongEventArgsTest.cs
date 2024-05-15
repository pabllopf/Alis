// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PongEventArgsTest.cs
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
using Xunit;

namespace Alis.Core.Network.Test
{
    /// <summary>
    /// The pong event args test class
    /// </summary>
    public class PongEventArgsTest
    {
        /// <summary>
        /// Tests that pong event args constructor
        /// </summary>
        [Fact]
        public void PongEventArgs_Constructor()
        {
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[0]);
            PongEventArgs pongEventArgs = new PongEventArgs(payload);
            Assert.NotNull(pongEventArgs);
        }
        
        /// <summary>
        /// Tests that pong event args payload
        /// </summary>
        [Fact]
        public void PongEventArgs_Payload()
        {
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[] {1, 2, 3});
            PongEventArgs pongEventArgs = new PongEventArgs(payload);
            Assert.Equal(payload, pongEventArgs.Payload);
        }
    }
}