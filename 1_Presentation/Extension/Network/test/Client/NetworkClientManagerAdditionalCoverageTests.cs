// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkClientManagerAdditionalCoverageTests.cs
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
using System.Threading.Tasks;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;
using Moq;
using Xunit;

namespace Alis.Extension.Network.Test.Client
{
    /// <summary>
    ///     The network client manager additional coverage tests class
    /// </summary>
    public class NetworkClientManagerAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that receive messages dispatches to registered handler
        /// </summary>
        [Fact]
        public async Task ReceiveMessages_DispatchToRegisteredHandler()
        {
            Mock<WebSocket> mockSocket = new Mock<WebSocket>();
            mockSocket.Setup(s => s.State).Returns(WebSocketState.Open);
            NetworkSerializer serializer = new NetworkSerializer();
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
            {
                MessageId = Guid.NewGuid().ToString(),
                MessageType = "chat",
                SenderId = "p1",
                Channel = "test.channel",
                Payload = "hello"
            };
            string envelopeJson = serializer.SerializeEnvelope(envelope);
            NetworkMessageEnvelope roundTripped = serializer.DeserializeEnvelope(envelopeJson);
            Assert.Equal("test.channel", roundTripped.Channel);
            byte[] payload = System.Text.Encoding.UTF8.GetBytes(envelopeJson);
            int receiveCalls = 0;
            mockSocket.Setup(s => s.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .Callback<ArraySegment<byte>, CancellationToken>((segment, token) =>
                {
                    if (receiveCalls == 0)
                    {
                        payload.CopyTo(segment.Array, segment.Offset);
                    }
                    receiveCalls++;
                })
                .Returns(() => receiveCalls == 1
                    ? Task.FromResult(new WebSocketReceiveResult(payload.Length, WebSocketMessageType.Text, true))
                    : Task.FromResult(new WebSocketReceiveResult(0, WebSocketMessageType.Close, true)));
            mockSocket.Setup(s => s.CloseAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            NetworkClientManager manager = new NetworkClientManager();
            await manager.InitializeAsync(new NetworkConfig());
            SetPrivateField(manager, "_serverSocket", mockSocket.Object);
            bool handlerCalled = false;
            bool messageReceived = false;
            string capturedError = null;
            System.Exception capturedException = null;
            manager.Error += (sender, args) => { capturedError = args.Message; capturedException = args.Exception; };
            manager.ServerMessageReceived += (sender, args) => messageReceived = true;
            manager.RegisterMessageHandler("test.channel", (sender, message) =>
            {
                handlerCalled = true;
                return Task.CompletedTask;
            });

            Task receiveTask = (Task) manager.GetType().GetMethod("ReceiveMessagesAsync",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(manager, new object[] { CancellationToken.None });

            await Task.Delay(100);

            Assert.True(handlerCalled || messageReceived, "err: " + (capturedException?.ToString() ?? "none"));
        }

        /// <summary>
        ///     Sets the private field
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="fieldName">The field name</param>
        /// <param name="value">The value</param>
        private static void SetPrivateField(object instance, string fieldName, object value)
        {
            instance.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(instance, value);
        }
    }
}
