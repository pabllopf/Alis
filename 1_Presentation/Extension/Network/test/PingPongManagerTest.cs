// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PingPongManagerTest.cs
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
using System.Net.WebSockets;
using System.Threading;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for PingPongManager class
    /// </summary>
    public class PingPongManagerTest
    {
        /// <summary>
        /// Tests that constructor with zero keep alive interval creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithZeroKeepAliveInterval_CreatesInstance()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            WebSocket webSocket = null;
            TimeSpan keepAliveInterval = TimeSpan.Zero;
            CancellationToken token = CancellationToken.None;

            // Act
            Exception exception = Record.Exception(() => new PingPongManager(guid, webSocket, keepAliveInterval, token));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidCastException>(exception);
        }

      
    }
}
