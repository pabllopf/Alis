// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketClientFactoryTests.cs
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
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test
{
    public class WebSocketClientFactoryTests
    {
        [Fact]
        public async Task ConnectAsync_UriDefault_ReturnsWebSocket()
        {
            TestableFactory factory = new TestableFactory();
            Uri uri = new Uri("ws://127.0.0.1:1/test");
            WebSocket ws = await factory.ConnectAsync(uri, CancellationToken.None);
            Assert.NotNull(ws);
            factory.Dispose();
        }

        [Fact]
        public async Task ConnectAsync_UriWithOptions_ReturnsWebSocket()
        {
            TestableFactory factory = new TestableFactory();
            Uri uri = new Uri("ws://127.0.0.1:2/test");
            WebSocket ws = await factory.ConnectAsync(uri, new WebSocketClientOptions(), CancellationToken.None);
            Assert.NotNull(ws);
            factory.Dispose();
        }

        [Fact]
        public async Task ConnectAsync_UriWithCustomOptions_ReturnsWebSocket()
        {
            TestableFactory factory = new TestableFactory();
            Uri uri = new Uri("ws://127.0.0.1:3/test");
            WebSocketClientOptions options = new WebSocketClientOptions
            {
                NoDelay = true,
                KeepAliveInterval = TimeSpan.FromSeconds(10),
                IncludeExceptionInCloseResponse = true,
                SecWebSocketProtocol = "chat"
            };
            options.AdditionalHttpHeaders["X-Custom"] = "value";
            WebSocket ws = await factory.ConnectAsync(uri, options, CancellationToken.None);
            Assert.NotNull(ws);
            factory.Dispose();
        }

        [Fact]
        public async Task ConnectAsync_UriWithSslScheme_UsesSsl()
        {
            SslSpyFactory factory = new SslSpyFactory();
            Uri uri = new Uri("wss://localhost:4/test");
            WebSocket ws = await factory.ConnectAsync(uri, new WebSocketClientOptions(), CancellationToken.None);
            Assert.NotNull(ws);
            Assert.True(factory.TlsAuthenticateWasCalled);
            factory.Dispose();
        }

        [Fact]
        public async Task GetStream_WithHostName_ReturnsStream()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            Task<TcpClient> acceptTask = listener.AcceptTcpClientAsync();
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Stream stream = await factory.GetStream(Guid.NewGuid(), false, true, "localhost", port, CancellationToken.None);
            Assert.NotNull(stream);
            Assert.True(stream.CanRead);
            Assert.True(stream.CanWrite);
            stream.Dispose();
            TcpClient accepted = await acceptTask;
            accepted.Dispose();
            factory.Dispose();
            listener.Stop();
        }

        [Fact]
        public async Task GetStream_WithIpAddress_ReturnsStream()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            Task<TcpClient> acceptTask = listener.AcceptTcpClientAsync();
            WebSocketClientFactory factory = new WebSocketClientFactory();
            Stream stream = await factory.GetStream(Guid.NewGuid(), false, true, "127.0.0.1", port, CancellationToken.None);
            Assert.NotNull(stream);
            Assert.True(stream.CanRead);
            Assert.True(stream.CanWrite);
            stream.Dispose();
            TcpClient accepted = await acceptTask;
            accepted.Dispose();
            factory.Dispose();
            listener.Stop();
        }

        [Fact]
        public async Task GetStream_WithNoDelayFalse_SetsTcpClient()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            Task<TcpClient> acceptTask = listener.AcceptTcpClientAsync();
            WebSocketClientFactory factory = new WebSocketClientFactory();
            using Stream stream = await factory.GetStream(Guid.NewGuid(), false, false, "127.0.0.1", port, CancellationToken.None);
            Assert.False(factory.TcpClient.NoDelay);
            TcpClient accepted = await acceptTask;
            accepted.Dispose();
            factory.Dispose();
            listener.Stop();
        }

        [Fact]
        public async Task GetStream_WithCancelledToken_Throws()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            WebSocketClientFactory factory = new WebSocketClientFactory();
            await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
                factory.GetStream(Guid.NewGuid(), false, true, "127.0.0.1", port, cts.Token));
            factory.Dispose();
            listener.Stop();
        }

        [Fact]
        public void TlsAuthenticateAsClient_VirtualMethod_CanBeOverridden()
        {
            SslSpyFactory factory = new SslSpyFactory();
            using MemoryStream ms = new MemoryStream();
            using SslStream sslStream = new SslStream(ms);
            factory.TlsAuthenticateAsClient(sslStream, "test");
            Assert.True(factory.TlsAuthenticateWasCalled);
        }

        [Fact]
        public void ValidateServerCertificate_RemoteCertificateNotAvailable_ReturnsFalse()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null,
                SslPolicyErrors.RemoteCertificateNotAvailable);
            Assert.False(result);
        }

        [Fact]
        public void ValidateServerCertificate_RemoteCertificateNameMismatch_ReturnsFalse()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null,
                SslPolicyErrors.RemoteCertificateNameMismatch);
            Assert.False(result);
        }

        [Fact]
        public void ValidateServerCertificate_RemoteCertificateChainErrors_ReturnsFalse()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null,
                SslPolicyErrors.RemoteCertificateChainErrors);
            Assert.False(result);
        }

        [Fact]
        public void ValidateServerCertificate_NoErrors_ReturnsTrue()
        {
            bool result = WebSocketClientFactory.ValidateServerCertificate(null, null, null, SslPolicyErrors.None);
            Assert.True(result);
        }

        [Fact]
        public void ThrowIfInvalidResponseCode_NullResponse_Throws()
        {
            Assert.Throws<InvalidHttpResponseCodeException>(() =>
                WebSocketClientFactory.ThrowIfInvalidResponseCode(string.Empty));
        }

        [Fact]
        public void ThrowIfInvalidResponseCode_101Response_DoesNotThrow()
        {
            WebSocketClientFactory.ThrowIfInvalidResponseCode("HTTP/1.1 101 Switching Protocols\r\n\r\n");
        }

        [Fact]
        public void ThrowIfInvalidResponseCode_Non101Response_Throws()
        {
            InvalidHttpResponseCodeException ex = Assert.Throws<InvalidHttpResponseCodeException>(() =>
                WebSocketClientFactory.ThrowIfInvalidResponseCode("HTTP/1.1 404 Not Found\r\nContent-Type: text/plain\r\n\r\nLine1\r\nLine2\r\n"));
            Assert.Equal("404 Not Found", ex.ResponseCode);
            Assert.Contains("Line1", ex.ResponseDetails);
            Assert.Contains("Line2", ex.ResponseDetails);
        }

        [Fact]
        public void ThrowIfInvalidResponseCode_Non101NoBody_Throws()
        {
            InvalidHttpResponseCodeException ex = Assert.Throws<InvalidHttpResponseCodeException>(() =>
                WebSocketClientFactory.ThrowIfInvalidResponseCode("HTTP/1.1 500 Error\r\n\r\n"));
            Assert.Equal("500 Error", ex.ResponseCode);
        }

        [Fact]
        public void ThrowIfInvalidResponseCode_Non101WithoutBodySeparator_FallsThrough()
        {
            WebSocketClientFactory.ThrowIfInvalidResponseCode("HTTP/1.1 200 OK\r\nContent-Type: text/plain");
        }

        [Fact]
        public void ThrowIfInvalidAcceptString_Valid_DoesNotThrow()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string accept = HttpHelper.ComputeSocketAcceptString(key);
            string response = $"HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Accept: {accept}\r\n\r\n";
            WebSocketClientFactory.ThrowIfInvalidAcceptString(Guid.NewGuid(), response, key);
        }

        [Fact]
        public void ThrowIfInvalidAcceptString_Invalid_Throws()
        {
            Assert.Throws<WebSocketHandshakeFailedException>(() =>
                WebSocketClientFactory.ThrowIfInvalidAcceptString(Guid.NewGuid(),
                    "HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Accept: invalid\r\n\r\n", "some-key"));
        }

        [Fact]
        public void GetSubProtocolFromHeader_WithProtocol_ReturnsProtocol()
        {
            string result = WebSocketClientFactory.GetSubProtocolFromHeader(
                "HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Protocol: chat\r\n\r\n");
            Assert.Equal("chat", result);
        }

        [Fact]
        public void GetSubProtocolFromHeader_WithoutProtocol_ReturnsNull()
        {
            string result = WebSocketClientFactory.GetSubProtocolFromHeader(
                "HTTP/1.1 101 Switching Protocols\r\n\r\n");
            Assert.Null(result);
        }

        [Fact]
        public void GetAdditionalHeaders_Null_ReturnsEmpty()
        {
            Assert.Equal(string.Empty, WebSocketClientFactory.GetAdditionalHeaders(null));
        }

        [Fact]
        public void GetAdditionalHeaders_Empty_ReturnsEmpty()
        {
            Assert.Equal(string.Empty, WebSocketClientFactory.GetAdditionalHeaders(
                new System.Collections.Generic.Dictionary<string, string>()));
        }

        [Fact]
        public void GetAdditionalHeaders_WithHeaders_ReturnsFormatted()
        {
            string result = WebSocketClientFactory.GetAdditionalHeaders(
                new System.Collections.Generic.Dictionary<string, string>
                {
                    {"Authorization", "Bearer token"}
                });
            Assert.Contains("Authorization: Bearer token\r\n", result);
        }

        [Fact]
        public void BuildHandshakeRequest_ReturnsFormatted()
        {
            string request = WebSocketClientFactory.BuildHandshakeRequest(
                new Uri("ws://example.com:8080/path"), "key", "protocol", "X-Hdr: val\r\n");
            Assert.Contains("GET /path HTTP/1.1", request);
            Assert.Contains("Host: example.com:8080", request);
            Assert.Contains("Sec-WebSocket-Key: key", request);
            Assert.Contains("Sec-WebSocket-Protocol: protocol", request);
            Assert.Contains("X-Hdr: val", request);
        }

        [Fact]
        public async Task SendHandshakeRequest_WritesToStream()
        {
            using MemoryStream stream = new MemoryStream();
            await WebSocketClientFactory.SendHandshakeRequest(stream, "GET / HTTP/1.1\r\n\r\n", Guid.NewGuid());
            stream.Position = 0;
            using StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            Assert.Contains("GET / HTTP/1.1", content);
        }

        [Fact]
        public void GenerateSecWebSocketKey_ReturnsBase64()
        {
            string key = WebSocketClientFactory.GenerateSecWebSocketKey();
            Assert.NotNull(key);
            Assert.Equal(24, key.Length);
            byte[] decoded = Convert.FromBase64String(key);
            Assert.Equal(16, decoded.Length);
        }

        [Fact]
        public void Constructor_Default_SetsBufferPool()
        {
            using WebSocketClientFactory factory = new WebSocketClientFactory();
            Assert.NotNull(factory.BufferPool);
            Assert.NotNull(factory.BufferFactory);
        }

        [Fact]
        public void Constructor_WithBufferFactory_SetsFactory()
        {
            Func<MemoryStream> bufferFactory = () => new MemoryStream();
            using WebSocketClientFactory factory = new WebSocketClientFactory(bufferFactory);
            Assert.NotNull(factory);
        }

        [Fact]
        public void Dispose_MultipleCalls_DoesNotThrow()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            factory.Dispose();
            factory.Dispose();
        }

        [Fact]
        public void Dispose_WithTcpClient_Disposes()
        {
            WebSocketClientFactory factory = new WebSocketClientFactory();
            factory.TcpClient = new TcpClient();
            factory.Dispose();
        }

        [Fact]
        public async Task ConnectAsync_StreamOverload_ValidResponse_ReturnsWebSocket()
        {
            string key = "dGhlIHNhbXBsZSBub25jZQ==";
            string accept = HttpHelper.ComputeSocketAcceptString(key);
            string httpResponse = $"HTTP/1.1 101 Switching Protocols\r\nSec-WebSocket-Accept: {accept}\r\n\r\n";
            byte[] bytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream stream = new MemoryStream(bytes);
            stream.Position = 0;
            WebSocket ws = await new WebSocketClientFactory().ConnectAsync(stream, key,
                new WebSocketClientOptions(), CancellationToken.None);
            Assert.NotNull(ws);
        }

        [Fact]
        public async Task ConnectAsync_StreamOverload_InvalidResponse_Throws()
        {
            string httpResponse = "HTTP/1.1 404 Not Found\r\nContent-Length: 0\r\n\r\n";
            byte[] bytes = Encoding.UTF8.GetBytes(httpResponse);
            using MemoryStream stream = new MemoryStream(bytes);
            stream.Position = 0;
            await Assert.ThrowsAsync<InvalidHttpResponseCodeException>(() =>
                new WebSocketClientFactory().ConnectAsync(stream, "key",
                    new WebSocketClientOptions(), CancellationToken.None));
        }

        [Fact]
        public async Task ConnectAsync_StreamOverload_EmptyStream_Throws()
        {
            using MemoryStream stream = new MemoryStream();
            stream.Position = 0;
            await Assert.ThrowsAsync<InvalidHttpResponseCodeException>(() =>
                new WebSocketClientFactory().ConnectAsync(stream, "key",
                    new WebSocketClientOptions(), CancellationToken.None));
        }

        [Fact]
        public async Task ConnectAsync_StreamOverload_DisposedStream_Throws()
        {
            MemoryStream stream = new MemoryStream();
            stream.Dispose();
            await Assert.ThrowsAsync<WebSocketHandshakeFailedException>(() =>
                new WebSocketClientFactory().ConnectAsync(stream, "key",
                    new WebSocketClientOptions(), CancellationToken.None));
        }

        private class TestableFactory : WebSocketClientFactory
        {
            internal override async Task<Stream> GetStream(Guid loggingGuid, bool isSecure, bool noDelay,
                string host, int port, CancellationToken cancellationToken)
            {
                return new HandshakeStream();
            }
        }

        private class SslSpyFactory : WebSocketClientFactory
        {
            public bool TlsAuthenticateWasCalled { get; private set; }

            internal override async Task<Stream> GetStream(Guid loggingGuid, bool isSecure, bool noDelay,
                string host, int port, CancellationToken cancellationToken)
            {
                if (isSecure)
                {
                    TlsAuthenticateAsClient(null, host);
                }

                return new HandshakeStream();
            }

            internal override void TlsAuthenticateAsClient(SslStream sslStream, string host)
            {
                TlsAuthenticateWasCalled = true;
            }
        }

        private class HandshakeStream : Stream
        {
            private byte[] _response;
            private int _readPosition;
            private bool _responseReady;

            public override bool CanRead => true;
            public override bool CanWrite => true;
            public override bool CanSeek => false;
            public override long Length => throw new NotSupportedException();
            public override long Position
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            public override async Task WriteAsync(byte[] buffer, int offset, int count,
                CancellationToken cancellationToken)
            {
                string request = Encoding.UTF8.GetString(buffer, offset, count);
                string key = ExtractKey(request);
                string accept = HttpHelper.ComputeSocketAcceptString(key);
                string response = $"HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: {accept}\r\n\r\n";
                _response = Encoding.UTF8.GetBytes(response);
                _responseReady = true;
            }

            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count,
                CancellationToken cancellationToken)
            {
                while (!_responseReady)
                {
                    await Task.Yield();
                }

                if (_readPosition >= _response.Length)
                {
                    return 0;
                }

                int toCopy = Math.Min(count, _response.Length - _readPosition);
                Buffer.BlockCopy(_response, _readPosition, buffer, offset, toCopy);
                _readPosition += toCopy;
                return toCopy;
            }

            public override void Flush()
            {
            }

            public override int Read(byte[] buffer, int offset, int count) =>
                ReadAsync(buffer, offset, count).GetAwaiter().GetResult();

            public override void Write(byte[] buffer, int offset, int count)
            {
                string request = Encoding.UTF8.GetString(buffer, offset, count);
                string key = ExtractKey(request);
                string accept = HttpHelper.ComputeSocketAcceptString(key);
                string response = $"HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: {accept}\r\n\r\n";
                _response = Encoding.UTF8.GetBytes(response);
                _responseReady = true;
            }

            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

            public override void SetLength(long value) => throw new NotSupportedException();

            private static string ExtractKey(string handshakeRequest)
            {
                const string prefix = "Sec-WebSocket-Key: ";
                int start = handshakeRequest.IndexOf(prefix, StringComparison.Ordinal);
                if (start < 0)
                {
                    return string.Empty;
                }

                start += prefix.Length;
                int end = handshakeRequest.IndexOf("\r\n", start, StringComparison.Ordinal);
                return end < 0 ? handshakeRequest.Substring(start) : handshakeRequest.Substring(start, end - start);
            }
        }
    }
}
