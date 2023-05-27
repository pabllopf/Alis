// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StressTest.cs
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
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Core.Network.Sample.Client.Complex
{
    /// <summary>
    ///     The stress test class
    /// </summary>
    internal class StressTest
    {
        /// <summary>
        ///     The client factory
        /// </summary>
        private readonly IWebSocketClientFactory _clientFactory;

        /// <summary>
        ///     The max num bytes per message
        /// </summary>
        private readonly int _maxNumBytesPerMessage;

        /// <summary>
        ///     The min num bytes per message
        /// </summary>
        private readonly int _minNumBytesPerMessage;

        /// <summary>
        ///     The num items
        /// </summary>
        private readonly int _numItems;

        /// <summary>
        ///     The seed
        /// </summary>
        private readonly int _seed;

        /// <summary>
        ///     The uri
        /// </summary>
        private readonly Uri _uri;

        /// <summary>
        ///     The expected values
        /// </summary>
        private byte[][] _expectedValues;

        /// <summary>
        ///     The token
        /// </summary>
        private CancellationToken _token;

        /// <summary>
        ///     The web socket
        /// </summary>
        private WebSocket _webSocket;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StressTest" /> class
        /// </summary>
        /// <param name="seed">The seed</param>
        /// <param name="uri">The uri</param>
        /// <param name="numItems">The num items</param>
        /// <param name="minNumBytesPerMessage">The min num bytes per message</param>
        /// <param name="maxNumBytesPerMessage">The max num bytes per message</param>
        public StressTest(int seed, Uri uri, int numItems, int minNumBytesPerMessage, int maxNumBytesPerMessage)
        {
            _seed = seed;
            _uri = uri;
            _numItems = numItems;
            _minNumBytesPerMessage = minNumBytesPerMessage;
            _maxNumBytesPerMessage = maxNumBytesPerMessage;
            _clientFactory = new WebSocketClientFactory();
        }

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public async Task Run()
        {
            // NOTE: if the service is so busy that it cannot respond to a PING within the KeepAliveInterval interval the websocket connection will be closed
            // To run extreme tests it is best to set the KeepAliveInterval to TimeSpan.Zero to disable ping pong
            WebSocketClientOptions options = new WebSocketClientOptions
            {
                NoDelay = true, KeepAliveInterval = TimeSpan.FromSeconds(2), SecWebSocketProtocol = "chatV2, chatV1"
            };
            using (_webSocket = await _clientFactory.ConnectAsync(_uri, options))
            {
                CancellationTokenSource source = new CancellationTokenSource();
                _token = source.Token;
                
                RandomNumberGenerator rand = RandomNumberGenerator.Create();
                
                _expectedValues = new byte[50][];
                for (int i = 0; i < _expectedValues.Length; i++)
                {
                    int numBytes = RandomNumberGenerator.GetInt32(_minNumBytesPerMessage, _maxNumBytesPerMessage);
                    byte[] bytes = new byte[numBytes];
                    rand.GetBytes(bytes);
                    _expectedValues[i] = bytes;
                }

                Task recTask = Task.Run(ReceiveLoop);
                byte[] sendBuffer = new byte[_maxNumBytesPerMessage];
                for (int i = 0; i < _numItems; i++)
                {
                    int index = i % _expectedValues.Length;
                    byte[] bytes = _expectedValues[index];
                    Buffer.BlockCopy(bytes, 0, sendBuffer, 0, bytes.Length);
                    ArraySegment<byte> buffer = new ArraySegment<byte>(sendBuffer, 0, bytes.Length);
                    await _webSocket.SendAsync(buffer, WebSocketMessageType.Binary, true, source.Token);
                }

                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, source.Token);
                recTask.Wait();
            }
        }

        /// <summary>
        ///     Describes whether are equal
        /// </summary>
        /// <param name="actual">The actual</param>
        /// <param name="expected">The expected</param>
        /// <param name="countActual">The count actual</param>
        /// <returns>The bool</returns>
        private static bool AreEqual(byte[] actual, byte[] expected, int countActual)
        {
            if (countActual != expected.Length)
            {
                return false;
            }

            for (int i = 0; i < countActual; i++)
            {
                if (actual[i] != expected[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Receives the loop
        /// </summary>
        /// <exception cref="Exception">Expected: {valueExpected.Length} bytes Actual: {result.Count} bytes. Contents different.</exception>
        /// <exception cref="Exception">Multi frame messages not supported</exception>
        private async Task ReceiveLoop()
        {
            // the recArray should be large enough to at least receive control frames like Ping and Close frames (with payload)
            const int minBufferSize = 510;
            int size = _maxNumBytesPerMessage < minBufferSize ? minBufferSize : _maxNumBytesPerMessage;
            byte[] recArray = new byte[size];
            ArraySegment<byte> recBuffer = new ArraySegment<byte>(recArray);

            int i = 0;
            while (true)
            {
                WebSocketReceiveResult result = await _webSocket.ReceiveAsync(recBuffer, _token);

                if (!result.EndOfMessage)
                {
                    throw new Exception("Multi frame messages not supported");
                }

                if (result.MessageType == WebSocketMessageType.Close || _token.IsCancellationRequested)
                {
                    return;
                }

                if (result.Count == 0)
                {
                    await _webSocket.CloseOutputAsync(WebSocketCloseStatus.InvalidPayloadData, "Zero bytes in payload",
                        _token);
                    return;
                }

                byte[] valueActual = recBuffer.Array;
                int index = i % _expectedValues.Length;
                i++;
                byte[] valueExpected = _expectedValues[index];

                if (!AreEqual(valueActual, valueExpected, result.Count))
                {
                    await _webSocket.CloseOutputAsync(WebSocketCloseStatus.InvalidPayloadData,
                        "Value actual does not equal value expected", _token);
                    throw new Exception(
                        $"Expected: {valueExpected.Length} bytes Actual: {result.Count} bytes. Contents different.");
                }
            }
        }
    }
}