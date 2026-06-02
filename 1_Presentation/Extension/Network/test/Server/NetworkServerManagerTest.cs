// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkServerManagerTest.cs
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
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;
using Xunit;

namespace Alis.Extension.Network.Test.Server
{
    /// <summary>
    ///     The network server manager test class
    /// </summary>
    public class NetworkServerManagerTest
    {
        /// <summary>
        ///     Tests that constructor initializes default state
        /// </summary>
        [Fact]
        public void Constructor_DefaultState_IsUninitialized()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            Assert.Equal(NetworkManagerState.Uninitialized, manager.State);
            Assert.NotNull(manager.Id);
            Assert.NotEmpty(manager.Id);
            Assert.Null(manager.CurrentSession);
            Assert.Null(manager.LocalPlayer);
            Assert.Null(manager.Config);
            Assert.Null(manager.ListenUri);
        }

        /// <summary>
        ///     Tests that constructor generates unique ids
        /// </summary>
        [Fact]
        public void Constructor_GeneratesUniqueIds()
        {
            using NetworkServerManager manager1 = new NetworkServerManager();
            using NetworkServerManager manager2 = new NetworkServerManager();

            Assert.NotEqual(manager1.Id, manager2.Id);
        }
    }
}
