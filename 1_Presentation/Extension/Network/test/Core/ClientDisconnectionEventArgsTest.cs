// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClientDisconnectionEventArgsTest.cs
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
    ///     The client disconnection event args test class
    /// </summary>
    public class ClientDisconnectionEventArgsTest
    {
        /// <summary>
        ///     Tests that constructor sets client id when reason not provided
        /// </summary>
        [Fact]
        public void Constructor_WithoutReason_SetsClientId()
        {
            ClientDisconnectionEventArgs args = new ClientDisconnectionEventArgs("client-1");

            Assert.Equal("client-1", args.ClientId);
            Assert.Null(args.Reason);
        }

        /// <summary>
        ///     Tests that constructor sets client id and reason when provided
        /// </summary>
        [Fact]
        public void Constructor_WithReason_SetsClientIdAndReason()
        {
            ClientDisconnectionEventArgs args = new ClientDisconnectionEventArgs("client-1", "timeout");

            Assert.Equal("client-1", args.ClientId);
            Assert.Equal("timeout", args.Reason);
        }

        /// <summary>
        ///     Tests that constructor with null reason sets client id and null reason
        /// </summary>
        [Fact]
        public void Constructor_WithNullReason_SetsClientIdAndNullReason()
        {
            ClientDisconnectionEventArgs args = new ClientDisconnectionEventArgs("client-1", null);

            Assert.Equal("client-1", args.ClientId);
            Assert.Null(args.Reason);
        }
    }
}
