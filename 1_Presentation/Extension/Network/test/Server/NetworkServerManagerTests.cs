// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkServerManagerTests.cs
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;
using Moq;
using Xunit;

namespace Alis.Extension.Network.Test.Server
{
    /// <summary>
    ///     The network server manager tests class
    /// </summary>
    public class NetworkServerManagerTests
    {
        /// <summary>
        ///     The test message class
        /// </summary>
        /// <seealso cref="IJsonSerializable"/>
        private sealed class TestPayload : IJsonSerializable
        {
            /// <summary>
            ///     Gets or sets the value of the text
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            ///     Gets the serializable properties
            /// </summary>
            /// <returns>An enumerable of string property name and string value</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Text", Text);
            }
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

        /// <summary>
        ///     Gets the private field
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="fieldName">The field name</param>
        /// <returns>The object</returns>
        private static object GetPrivateField(object obj, string fieldName)
        {
            FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return field.GetValue(obj);
        }

        /// <summary>
        ///     Invokes the private async method using the specified parameters
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="methodName">The method name</param>
        /// <param name="parameters">The parameters</param>
        /// <returns>The task</returns>
        private static async Task InvokePrivateAsyncMethod(object obj, string methodName, params object[] parameters)
        {
            MethodInfo method = obj.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Task task = (Task)method.Invoke(obj, parameters);
            await task.ConfigureAwait(false);
        }

        /// <summary>
        ///     Finds a free TCP port
        /// </summary>
        /// <returns>The port number</returns>
        private static int FindFreePort()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        /// <summary>
        ///     Tests that listen async success path transitions to connected state
        /// </summary>
        [Fact]
        public async Task ListenAsync_ValidAddress_TransitionsToConnected()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            int port = FindFreePort();
            bool connectedFired = false;
            manager.Connected += (sender, args) => { connectedFired = true; };

            await manager.ListenAsync(new Uri($"ws://127.0.0.1:{port}"));

            Assert.Equal(NetworkManagerState.Connected, manager.State);
            Assert.True(connectedFired);
            Assert.Contains(port.ToString(), manager.ListenUri.ToString());

            await manager.StopListeningAsync();
        }

        /// <summary>
        ///     Tests that listen async success path fires connected event
        /// </summary>
        [Fact]
        public async Task ListenAsync_ValidAddress_FiresConnectedEvent()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            int port = FindFreePort();
            int eventCount = 0;
            manager.Connected += (sender, args) =>
            {
                eventCount++;
                Assert.NotNull(sender);
            };

            await manager.ListenAsync(new Uri($"ws://127.0.0.1:{port}"));
            Assert.Equal(1, eventCount);
            await manager.StopListeningAsync();
        }

        /// <summary>
        ///     Tests that listen async success path sets listen uri
        /// </summary>
        [Fact]
        public async Task ListenAsync_ValidAddress_SetsListenUri()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            int port = FindFreePort();
            Uri expected = new Uri($"ws://127.0.0.1:{port}");

            await manager.ListenAsync(expected);

            Assert.NotNull(manager.ListenUri);
            Assert.Equal(expected.ToString(), manager.ListenUri.ToString());
            await manager.StopListeningAsync();
        }

        /// <summary>
        ///     Tests that listen async success path creates cancellation token source
        /// </summary>
        [Fact]
        public async Task ListenAsync_ValidAddress_CreatesCancellationTokenSource()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            int port = FindFreePort();
            await manager.ListenAsync(new Uri($"ws://127.0.0.1:{port}"));

            CancellationTokenSource cts = (CancellationTokenSource)GetPrivateField(manager, "_cancellationTokenSource");
            Assert.NotNull(cts);
            Assert.False(cts.IsCancellationRequested);

            await manager.StopListeningAsync();
        }

        /// <summary>
        ///     Tests that process messages async receives message and dispatches to handler
        /// </summary>
        [Fact]
        public async Task ProcessMessagesAsync_ReceivesMessage_CallsHandler()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            NetworkMessageEnvelope expectedMessage = new NetworkMessageEnvelope
            {
                MessageId = "test-msg",
                MessageType = "TestType",
                SenderId = "sender-1",
                Channel = "test-channel",
                Payload = "test-payload"
            };

            bool handlerCalled = false;
            string capturedSender = null;
            string capturedPayload = null;

            CancellationTokenSource cts = new CancellationTokenSource();
            int callCount = 0;

            mockTransport
                .Setup(t => t.ReceiveAsync(It.IsAny<CancellationToken>()))
                .Returns(async (CancellationToken ct) =>
                {
                    int current = Interlocked.Increment(ref callCount);
                    if (current == 1)
                    {
                        return ("client-1", expectedMessage);
                    }

                    cts.Cancel();
                    throw new OperationCanceledException(ct);
                });

            ConcurrentDictionary<string, Func<string, string, Task>> handlers = new ConcurrentDictionary<string, Func<string, string, Task>>();
            handlers["test-channel"] = (sender, payload) =>
            {
                handlerCalled = true;
                capturedSender = sender;
                capturedPayload = payload;
                return Task.CompletedTask;
            };

            SetPrivateField(manager, "_transport", mockTransport.Object);
            SetPrivateField(manager, "_messageHandlers", handlers);

            using (cts)
            {
                await InvokePrivateAsyncMethod(manager, "ProcessMessagesAsync", cts.Token);
            }

            Assert.True(handlerCalled);
            Assert.Equal("sender-1", capturedSender);
            Assert.Equal("test-payload", capturedPayload);
        }

        /// <summary>
        ///     Tests that process messages async calls correct handler per channel
        /// </summary>
        [Fact]
        public async Task ProcessMessagesAsync_MultipleChannels_CallsCorrectHandler()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            int chatCalls = 0;
            int systemCalls = 0;

            CancellationTokenSource cts = new CancellationTokenSource();
            int callCount = 0;

            mockTransport
                .Setup(t => t.ReceiveAsync(It.IsAny<CancellationToken>()))
                .Returns(async (CancellationToken ct) =>
                {
                    int current = Interlocked.Increment(ref callCount);
                    if (current == 1)
                    {
                        return ("client-1", new NetworkMessageEnvelope
                        {
                            Channel = "chat",
                            SenderId = "player1",
                            Payload = "hello"
                        });
                    }

                    cts.Cancel();
                    throw new OperationCanceledException(ct);
                });

            ConcurrentDictionary<string, Func<string, string, Task>> handlers = new ConcurrentDictionary<string, Func<string, string, Task>>();
            handlers["chat"] = (sender, payload) =>
            {
                Interlocked.Increment(ref chatCalls);
                return Task.CompletedTask;
            };
            handlers["system"] = (sender, payload) =>
            {
                Interlocked.Increment(ref systemCalls);
                return Task.CompletedTask;
            };

            SetPrivateField(manager, "_transport", mockTransport.Object);
            SetPrivateField(manager, "_messageHandlers", handlers);

            using (cts)
            {
                await InvokePrivateAsyncMethod(manager, "ProcessMessagesAsync", cts.Token);
            }

            Assert.Equal(1, chatCalls);
            Assert.Equal(0, systemCalls);
        }

        /// <summary>
        ///     Tests that process messages async cancellation stops loop
        /// </summary>
        [Fact]
        public async Task ProcessMessagesAsync_Cancellation_StopsLoop()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            SetPrivateField(manager, "_transport", mockTransport.Object);

            using (cts)
            {
                await InvokePrivateAsyncMethod(manager, "ProcessMessagesAsync", cts.Token);
            }
        }

        /// <summary>
        ///     Tests that process messages async transport error fires error event
        /// </summary>
        [Fact]
        public async Task ProcessMessagesAsync_TransportError_FiresErrorEvent()
        {
            using NetworkServerManager manager = new NetworkServerManager();

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport
                .Setup(t => t.ReceiveAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("transport error"));

            bool errorFired = false;
            string errorMessage = null;
            manager.Error += (sender, args) =>
            {
                errorFired = true;
                errorMessage = args.Message;
            };

            SetPrivateField(manager, "_transport", mockTransport.Object);

            CancellationTokenSource cts = new CancellationTokenSource();
            using (cts)
            {
                await InvokePrivateAsyncMethod(manager, "ProcessMessagesAsync", cts.Token);
            }

            Assert.True(errorFired);
            Assert.Contains("Error processing messages", errorMessage);
        }

        /// <summary>
        ///     Tests that listen and stop listening full cycle works
        /// </summary>
        [Fact]
        public async Task ListenStopListening_FullCycle_Works()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            int port = FindFreePort();
            bool disconnected = false;

            manager.Disconnected += (sender, args) => { disconnected = true; };

            await manager.ListenAsync(new Uri($"ws://127.0.0.1:{port}"));
            Assert.Equal(NetworkManagerState.Connected, manager.State);

            await manager.StopListeningAsync();
            Assert.True(disconnected);
            Assert.Equal(NetworkManagerState.Disconnected, manager.State);
        }

        /// <summary>
        ///     Tests that listen async in disconnected state reconnects
        /// </summary>
        [Fact]
        public async Task ListenAsync_InDisconnectedState_Reconnects()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            int port1 = FindFreePort();
            await manager.ListenAsync(new Uri($"ws://127.0.0.1:{port1}"));
            await manager.StopListeningAsync();

            int port2 = FindFreePort();
            await manager.ListenAsync(new Uri($"ws://127.0.0.1:{port2}"));

            Assert.Equal(NetworkManagerState.Connected, manager.State);

            await manager.StopListeningAsync();
        }

        /// <summary>
        ///     Tests that dispose with transport stop error is caught
        /// </summary>
        [Fact]
        public async Task Dispose_TransportStopThrows_CatchesException()
        {
            NetworkServerManager manager = new NetworkServerManager();
            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport
                .Setup(t => t.StopAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("stop failed"));

            SetPrivateField(manager, "_transport", mockTransport.Object);
            SetPrivateField(manager, "_cancellationTokenSource", new CancellationTokenSource());
            SetPrivateField(manager, "_isDisposed", false);

            await manager.InitializeAsync(new NetworkConfig());

            Exception ex = Record.Exception(() => manager.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that stop listening async with null error handler does not throw
        /// </summary>
        [Fact]
        public async Task StopListeningAsync_ErrorHandlerNull_DoesNotThrow()
        {
            using NetworkServerManager manager = new NetworkServerManager();
            await manager.InitializeAsync(new NetworkConfig());

            int port = FindFreePort();
            await manager.ListenAsync(new Uri($"ws://127.0.0.1:{port}"));

            Mock<INetworkTransport> mockTransport = new Mock<INetworkTransport>();
            mockTransport
                .Setup(t => t.StopAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidOperationException("stop error"));

            SetPrivateField(manager, "_transport", mockTransport.Object);

            Exception ex = await Record.ExceptionAsync(() => manager.StopListeningAsync());
            Assert.Null(ex);
        }
    }
}
