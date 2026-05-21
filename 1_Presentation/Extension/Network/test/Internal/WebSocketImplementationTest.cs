

using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The web socket implementation test class
    /// </summary>
    public class WebSocketImplementationTest
    {
        /// <summary>
        ///     Tests that send async valid input
        /// </summary>
        [Fact]
        public async Task SendAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";

            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);

        }

        /// <summary>
        ///     Tests that receive async valid input
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";

            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            await Assert.ThrowsAsync<EndOfStreamException>(() => webSocket.ReceiveAsync(buffer, CancellationToken.None));
        }

        /// <summary>
        ///     Tests that close async valid input
        /// </summary>
        [Fact]
        public async Task CloseAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            Func<MemoryStream> recycledStreamFactory = () => new MemoryStream();
            Stream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            string secWebSocketExtensions = "permessage-deflate";
            bool includeExceptionInCloseResponse = true;
            bool isClient = true;
            string subProtocol = "subProtocol";

            WebSocketImplementation webSocket = new WebSocketImplementation(guid, recycledStreamFactory, stream, keepAliveInterval, secWebSocketExtensions, includeExceptionInCloseResponse, isClient, subProtocol);
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test close", CancellationToken.None);

            Assert.Equal(WebSocketState.CloseSent, webSocket.State);
        }

        /// <summary>
        ///     Tests that send async valid input 7
        /// </summary>
        [Fact]
        public async Task SendAsync_ValidInput_7()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));

            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);

        }

        /// <summary>
        ///     Tests that receive async valid input 6
        /// </summary>
        [Fact]
        public async Task ReceiveAsync_ValidInput_6()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);

            EndOfStreamException result = await Assert.ThrowsAsync<EndOfStreamException>(() => webSocket.ReceiveAsync(buffer, CancellationToken.None));

        }

        /// <summary>
        ///     Tests that close async valid input v 5
        /// </summary>
        [Fact]
        public async Task CloseAsync_ValidInput_v5()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Test close", CancellationToken.None);

            Assert.Equal(WebSocketState.CloseSent, webSocket.State);
        }

        /// <summary>
        ///     Tests that abort valid input
        /// </summary>
        [Fact]
        public void Abort_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            webSocket.Abort();

            Assert.Equal(WebSocketState.Aborted, webSocket.State);
        }

        /// <summary>
        ///     Tests that close output async valid input
        /// </summary>
        [Fact]
        public async Task CloseOutputAsync_ValidInput()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Test close", CancellationToken.None);

            Assert.Equal(WebSocketState.Closed, webSocket.State);
        }

        /// <summary>
        ///     Tests that sub protocol test
        /// </summary>
        [Fact]
        public void SubProtocol_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            Assert.Equal("subProtocol", webSocket.SubProtocol);
        }

        /// <summary>
        ///     Tests that keep alive interval test
        /// </summary>
        [Fact]
        public void KeepAliveInterval_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            TimeSpan keepAliveInterval = TimeSpan.FromSeconds(30);
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, keepAliveInterval, "permessage-deflate", true, true, "subProtocol");

            Assert.Equal(keepAliveInterval, webSocket.KeepAliveInterval);
        }

        /// <summary>
        ///     Tests that pong test
        /// </summary>
        [Fact]
        public void Pong_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            bool eventRaised = false;
            webSocket.Pong += (sender, args) => eventRaised = true;

            Assert.False(eventRaised);
        }

        /// <summary>
        ///     Tests that close status test
        /// </summary>
        [Fact]
        public void CloseStatus_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            Assert.Null(webSocket.CloseStatus);
        }

        /// <summary>
        ///     Tests that close status description test
        /// </summary>
        [Fact]
        public void CloseStatusDescription_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");

            Assert.Null(webSocket.CloseStatusDescription);
        }

        /// <summary>
        ///     Tests that handle binary frame test
        /// </summary>
        [Fact]
        public void HandleBinaryFrame_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, buffer.Count, buffer);

            WebSocketReceiveResult result = webSocket.HandleBinaryFrame(frame, true);

            Assert.Equal(WebSocketMessageType.Binary, result.MessageType);
            Assert.True(result.EndOfMessage);
            Assert.Equal(0, result.Count);
        }

        /// <summary>
        ///     Tests that handle pong test
        /// </summary>
        [Fact]
        public void HandlePong_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, buffer.Count, buffer);

            WebSocketReceiveResult result = webSocket.HandlePong(frame, buffer);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that handle continuation frame test
        /// </summary>
        [Fact]
        public void HandleContinuationFrame_Test()
        {
            Guid guid = Guid.NewGuid();
            MemoryStream stream = new MemoryStream();
            WebSocketImplementation webSocket = new WebSocketImplementation(guid, () => new MemoryStream(), stream, TimeSpan.FromSeconds(30), "permessage-deflate", true, true, "subProtocol");
            ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test message"));
            WebSocketFrame frame = new WebSocketFrame(true, WebSocketOpCode.BinaryFrame, buffer.Count, buffer);

            WebSocketReceiveResult result = webSocket.HandleContinuationFrame(frame, true);

            Assert.Equal(WebSocketMessageType.Binary, result.MessageType);
            Assert.True(result.EndOfMessage);
            Assert.Equal(0, result.Count);
        }
    }
}