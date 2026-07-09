// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BinaryReaderWriterCoverageTest.cs
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
    ///     Coverage tests for BinaryReaderWriter — partial reads and BigEndian write paths.
    /// </summary>
    public class BinaryReaderWriterCoverageTest
    {
        /// <summary>
        ///     Tests that ReadExactly handles partial reads (do-while loop continuation).
        ///     Uses a stream that returns data one byte at a time.
        /// </summary>
        [Fact]
        public async Task ReadExactly_PartialReads_CompletesSuccessfully()
        {
            byte[] testData = { 0x0A, 0x0B, 0x0C };
            using Stream partialStream = new PartialReadStream(testData, 1);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[3]);
            CancellationToken cancellationToken = CancellationToken.None;

            await BinaryReaderWriter.ReadExactly(3, partialStream, buffer, cancellationToken);

            Assert.Equal(testData[0], buffer.Array[buffer.Offset]);
            Assert.Equal(testData[1], buffer.Array[buffer.Offset + 1]);
            Assert.Equal(testData[2], buffer.Array[buffer.Offset + 2]);
        }

        /// <summary>
        ///     Tests that ReadExactly throws EndOfStreamException on partial read beyond stream data.
        /// </summary>
        [Fact]
        public async Task ReadExactly_PartialReads_ThrowsEndOfStream()
        {
            byte[] testData = { 0x0A, 0x0B };
            using Stream partialStream = new PartialReadStream(testData, 1);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[5]);
            CancellationToken cancellationToken = CancellationToken.None;

            await Assert.ThrowsAsync<EndOfStreamException>(() =>
                BinaryReaderWriter.ReadExactly(5, partialStream, buffer, cancellationToken));
        }
    }

    /// <summary>
    ///     A memory stream that returns data in chunks of a specified maximum size per read.
    ///     Simulates partial reads from network streams.
    /// </summary>
    internal class PartialReadStream : MemoryStream
    {
        private readonly int _maxChunkSize;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PartialReadStream"/> class
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="maxChunkSize">Maximum bytes returned per read call</param>
        public PartialReadStream(byte[] data, int maxChunkSize) : base(data)
        {
            _maxChunkSize = maxChunkSize;
        }

        /// <summary>
        ///     Reads data in chunks no larger than _maxChunkSize
        /// </summary>
        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            int bytesToRead = Math.Min(count, _maxChunkSize);
            return await base.ReadAsync(buffer, offset, bytesToRead, cancellationToken);
        }
    }
}
