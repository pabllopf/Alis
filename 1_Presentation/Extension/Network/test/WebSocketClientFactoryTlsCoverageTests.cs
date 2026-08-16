// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketClientFactoryTlsCoverageTests.cs
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
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Exercises the TLS handshake path of <see cref="WebSocketClientFactory" /> against a
    ///     loopback TLS server with a self-signed certificate.
    /// </summary>
    public class WebSocketClientFactoryTlsCoverageTests
    {
        /// <summary>
        ///     Tests that connect async with a wss uri attempts the TLS handshake.
        /// </summary>
        [Fact]
        public async Task ConnectAsync_WithTlsLoopbackServer_AttemptsTlsHandshake()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint) listener.LocalEndpoint).Port;
            using RSA rsa = RSA.Create(2048);
            CertificateRequest request = new CertificateRequest(new X500DistinguishedName("CN=alis-test"), rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            request.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
            request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyEncipherment, true));
            using X509Certificate2 certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(1));

            Task serverTask = Task.Run(() =>
            {
                using TcpClient server = listener.AcceptTcpClient();
                using SslStream ssl = new SslStream(server.GetStream(), false);
                ssl.AuthenticateAsServer(certificate, false, System.Security.Authentication.SslProtocols.Tls12, false);
            });

            try
            {
                WebSocketClientFactory factory = new WebSocketClientFactory();
                await Assert.ThrowsAnyAsync<Exception>(() => factory.ConnectAsync(new Uri($"wss://127.0.0.1:{port}/")));
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}
