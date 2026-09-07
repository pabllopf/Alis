// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameReaderCoverageTest.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     Coverage tests for WebSocketFrameReader fault and edge paths.
    /// </summary>
    public class WebSocketFrameReaderCoverageTest
    {
        /// <summary>
        ///     Tests that ReadAsync rethrows a buffer overflow with a descriptive message when the stream signals one.
        /// </summary>
        [Fact]
        public async Task ReadAsync_StreamSignalsBufferOverflow_RethrowsDescriptiveException()
        {
            byte[] header = { 0x81, 0x01 };
            using Stream throwingStream = new BufferOverflowInjectingStream(header);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[64]);
            CancellationToken cancellationToken = CancellationToken.None;

            InternalBufferOverflowException exception =
                await Assert.ThrowsAsync<InternalBufferOverflowException>(() =>
                    WebSocketFrameReader.ReadAsync(throwingStream, buffer, cancellationToken));

            Assert.Contains("Supplied buffer too small", exception.Message);
            Assert.NotNull(exception.InnerException);
            Assert.IsType<InternalBufferOverflowException>(exception.InnerException);
        }

        /// <summary>
        ///     Tests that ReadAsync rethrows a buffer overflow from the masked payload read.
        /// </summary>
        [Fact]
        public async Task ReadAsync_StreamSignalsBufferOverflow_WhileReadingMaskedPayload_Rethrows()
        {
            byte[] header = { 0x81, 0x81 };
            byte[] maskBytes = { 0x10, 0x20, 0x30, 0x40 };
            byte[] streamBytes = new byte[6];
            streamBytes[0] = header[0];
            streamBytes[1] = header[1];
            maskBytes.CopyTo(streamBytes, 2);

            using Stream throwingStream = new BufferOverflowInjectingStreamAfterBytes(streamBytes, 4);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[64]);
            CancellationToken cancellationToken = CancellationToken.None;

            InternalBufferOverflowException exception =
                await Assert.ThrowsAsync<InternalBufferOverflowException>(() =>
                    WebSocketFrameReader.ReadAsync(throwingStream, buffer, cancellationToken));

            Assert.Contains("Supplied buffer too small", exception.Message);
            Assert.NotNull(exception.InnerException);
        }
    }

    /// <summary>
    ///     A memory stream that yields its data then throws a buffer overflow on the next read.
    /// </summary>
    internal class BufferOverflowInjectingStream : MemoryStream
    {
        /// <summary>
        ///     Tracks whether the underlying bytes have been exhausted.
        /// </summary>
        private bool _throwNextRead;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BufferOverflowInjectingStream"/> class
        /// </summary>
        /// <param name="data">The data</param>
        public BufferOverflowInjectingStream(byte[] data) : base(data)
        {
        }

        /// <summary>
        ///     Reads the next chunk, throwing a buffer overflow once the source data is exhausted.
        /// </summary>
        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (_throwNextRead)
            {
                throw new InternalBufferOverflowException("Simulated stream buffer overflow");
            }

            _throwNextRead = true;
            return await base.ReadAsync(buffer, offset, count, cancellationToken);
        }
    }

    /// <summary>
    ///     A memory stream that yields a fixed number of bytes then throws a buffer overflow.
    /// </summary>
    internal class BufferOverflowInjectingStreamAfterBytes : MemoryStream
    {
        /// <summary>
        ///     The number of bytes to yield before throwing.
        /// </summary>
        private readonly int _bytesBeforeThrow;

        /// <summary>
        ///     Tracks how many bytes have been read so far.
        /// </summary>
        private int _bytesRead;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BufferOverflowInjectingStreamAfterBytes"/> class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="bytesBeforeThrow">The bytes to yield before the overflow</param>
        public BufferOverflowInjectingStreamAfterBytes(byte[] data, int bytesBeforeThrow) : base(data)
        {
            _bytesBeforeThrow = bytesBeforeThrow;
        }

        /// <summary>
        ///     Reads the next chunk, throwing a buffer overflow once the byte budget is spent.
        /// </summary>
        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (_bytesRead >= _bytesBeforeThrow)
            {
                throw new InternalBufferOverflowException("Simulated stream buffer overflow");
            }

            int toYield = Math.Min(count, _bytesBeforeThrow - _bytesRead);
            int read = await base.ReadAsync(buffer, offset, toYield, cancellationToken);
            _bytesRead += read;
            return read;
        }
    }
}