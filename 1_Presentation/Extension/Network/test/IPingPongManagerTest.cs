// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPingPongManagerTest.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Tests for IPingPongManager interface
    /// </summary>
    public class IPingPongManagerTest
    {
        private class TestPingPongManager : IPingPongManager
        {
            public event EventHandler<PongEventArgs> Pong;
            
            public Task SendPing(ArraySegment<byte> payload, CancellationToken cancellation)
                => Task.CompletedTask;
        }
        

        [Fact]
        public void SendPing_CompletesSuccessfully()
        {
            // Arrange
            TestPingPongManager manager = new TestPingPongManager();
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[] { 1, 2, 3 });

            // Act
            Task result = manager.SendPing(payload, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        [Fact]
        public void SendPing_WithEmptyPayload_CompletesSuccessfully()
        {
            // Arrange
            TestPingPongManager manager = new TestPingPongManager();
            ArraySegment<byte> payload = new ArraySegment<byte>(Array.Empty<byte>());

            // Act
            Task result = manager.SendPing(payload, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        [Fact]
        public void SendPing_WithCancellationToken_CompletesSuccessfully()
        {
            // Arrange
            TestPingPongManager manager = new TestPingPongManager();
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[] { 1, 2, 3 });
            CancellationToken token = new CancellationToken();

            // Act
            Task result = manager.SendPing(payload, token);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }
    }
}
