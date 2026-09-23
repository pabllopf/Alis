// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkServerManagerLatestCoverageTests.cs
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
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;
using Moq;
using Xunit;

namespace Alis.Extension.Network.Test.Server
{
    /// <summary>
    ///     The network server manager latest coverage tests class
    /// </summary>
    public class NetworkServerManagerLatestCoverageTests
    {
        /// <summary>
        ///     Tests that dispose propagates exception thrown by error handler during stop
        /// </summary>
        [Fact]
        public async Task Dispose_ErrorHandlerThrowsDuringStop_PropagatesException()
        {
            NetworkServerManager manager = new NetworkServerManager();
            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport.Setup(t => t.StopAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("stop error"));

            SetPrivateField(manager, "_transport", mockTransport.Object);
            SetPrivateField(manager, "_cancellationTokenSource", new CancellationTokenSource());

            await manager.InitializeAsync(new NetworkConfig());

            bool errorHandlerInvoked = false;
            manager.Error += (sender, args) =>
            {
                errorHandlerInvoked = true;
                throw new InvalidOperationException("error handler failure");
            };

            Exception ex = Record.Exception(() => manager.Dispose());

            Assert.NotNull(ex);
            Assert.True(errorHandlerInvoked);
        }

        /// <summary>
        ///     Tests that dispose routes exception thrown by disconnected handler to the error event
        /// </summary>
        [Fact]
        public async Task Dispose_DisconnectedHandlerThrowsDuringStop_RoutesError()
        {
            NetworkServerManager manager = new NetworkServerManager();
            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport.Setup(t => t.StopAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            SetPrivateField(manager, "_transport", mockTransport.Object);
            SetPrivateField(manager, "_cancellationTokenSource", new CancellationTokenSource());

            await manager.InitializeAsync(new NetworkConfig());

            bool disconnectedHandlerInvoked = false;
            Exception routedException = null;
            manager.Disconnected += (sender, args) =>
            {
                disconnectedHandlerInvoked = true;
                throw new InvalidOperationException("disconnected handler failure");
            };
            manager.Error += (sender, args) => routedException = args.Exception;

            Exception ex = Record.Exception(() => manager.Dispose());

            Assert.Null(ex);
            Assert.True(disconnectedHandlerInvoked);
            Assert.IsType<InvalidOperationException>(routedException);
        }

        /// <summary>
        ///     Sets the private field using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="fieldName">The field name</param>
        /// <param name="value">The value</param>
        private static void SetPrivateField(object obj, string fieldName, object value)
        {
            FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            field.SetValue(obj, value);
        }
    }
}
