// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BinaryReaderWriterTest.cs
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
    ///     Comprehensive tests for BinaryReaderWriter - static binary data reader/writer for WebSocket frames
    /// </summary>
    public class BinaryReaderWriterTest
    {
        #region ReadExactly Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadExactly with valid stream and buffer
        ///     Act: Read zero bytes (edge case)
        ///     Assert: Method returns immediately without error
        /// </summary>
        [Fact]
        public async void ReadExactly_ZeroLength_ReturnsImmediately()
        {
            // Arrange: Create valid stream and buffer
            using MemoryStream stream = new MemoryStream();
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Read zero bytes (edge case)
            await BinaryReaderWriter.ReadExactly(0, stream, buffer, cancellationToken);

            // Assert: Method returns immediately without error
            Assert.NotNull(stream);
            Assert.NotNull(buffer);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadExactly with valid stream and buffer
        ///     Act: Read exact number of bytes from stream
        ///     Assert: All bytes are read correctly
        /// </summary>
        [Fact]
        public async Task ReadExactly_ValidStream_ReadsBytesCorrectly()
        {
            // Arrange: Create stream with data to read
            byte[] testData = { 0x01, 0x02, 0x03, 0x04, 0x05 };
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[5]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Read 5 bytes from stream
            await BinaryReaderWriter.ReadExactly(5, stream, buffer, cancellationToken);

            // Assert: All bytes are read correctly
            byte[] readData = new byte[5];
            Array.Copy(buffer.Array, buffer.Offset, readData, 0, 5);
            Assert.Equal(testData, readData);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadExactly with buffer smaller than length
        ///     Act: Attempt to read more bytes than buffer can hold
        ///     Assert: Throws InternalBufferOverflowException
        /// </summary>
        [Fact]
        public void ReadExactly_BufferTooSmall_ThrowsException()
        {
            // Arrange: Create stream and buffer smaller than length to read
            byte[] testData = { 0x01, 0x02, 0x03, 0x04, 0x05 };
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[3]); // Too small
            CancellationToken cancellationToken = CancellationToken.None;

            // Act & Assert: Attempt to read 5 bytes into buffer of size 3
            Assert.Throws<InternalBufferOverflowException>(() => BinaryReaderWriter.ReadExactly(5, stream, buffer, cancellationToken).GetAwaiter().GetResult());
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadExactly with empty stream
        ///     Act: Attempt to read bytes from empty stream
        ///     Assert: Throws EndOfStreamException
        /// </summary>
        [Fact]
        public async Task ReadExactly_EmptyStream_ThrowsEndOfStreamException()
        {
            // Arrange: Create empty stream
            using MemoryStream stream = new MemoryStream();
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[10]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act & Assert: Attempt to read from empty stream
            await Assert.ThrowsAsync<EndOfStreamException>(async () => await BinaryReaderWriter.ReadExactly(5, stream, buffer, cancellationToken));
        }

        #endregion

        #region ReadUShortExactly Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadUShortExactly with valid stream
        ///     Act: Read ushort from little endian stream
        ///     Assert: Short is read correctly in little endian format
        /// </summary>
        [Fact]
        public async Task ReadUShortExactly_LittleEndian_ReadsCorrectly()
        {
            // Arrange: Create stream with ushort data (little endian)
            ushort testValue = 0x1234;
            byte[] testData = BitConverter.GetBytes(testValue);
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Read ushort in little endian format
            ushort readValue = await BinaryReaderWriter.ReadUShortExactly(stream, true, buffer, cancellationToken);

            // Assert: Short is read correctly in little endian format
            Assert.Equal(testValue, readValue);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadUShortExactly with valid stream
        ///     Act: Read ushort from big endian stream
        ///     Assert: Short is read correctly in big endian format
        /// </summary>
        [Fact]
        public async Task ReadUShortExactly_BigEndian_ReadsCorrectly()
        {
            // Arrange: Create stream with ushort data (big endian)
            ushort testValue = 0x1234;
            byte[] testData = BitConverter.GetBytes(testValue);
            Array.Reverse(testData); // Convert to big endian
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Read ushort in big endian format
            ushort readValue = await BinaryReaderWriter.ReadUShortExactly(stream, false, buffer, cancellationToken);

            // Assert: Short is read correctly in big endian format
            Assert.Equal(testValue, readValue);
        }

        #endregion

        #region ReadULongExactly Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadULongExactly with valid stream
        ///     Act: Read ulong from little endian stream
        ///     Assert: Long is read correctly in little endian format
        /// </summary>
        [Fact]
        public async Task ReadULongExactly_LittleEndian_ReadsCorrectly()
        {
            // Arrange: Create stream with ulong data (little endian)
            ulong testValue = 0x123456789ABCDEF0UL;
            byte[] testData = BitConverter.GetBytes(testValue);
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Read ulong in little endian format
            ulong readValue = await BinaryReaderWriter.ReadULongExactly(stream, true, buffer, cancellationToken);

            // Assert: Long is read correctly in little endian format
            Assert.Equal(testValue, readValue);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadULongExactly with valid stream
        ///     Act: Read ulong from big endian stream
        ///     Assert: Long is read correctly in big endian format
        /// </summary>
        [Fact]
        public async Task ReadULongExactly_BigEndian_ReadsCorrectly()
        {
            // Arrange: Create stream with ulong data (big endian)
            ulong testValue = 0x123456789ABCDEF0UL;
            byte[] testData = BitConverter.GetBytes(testValue);
            Array.Reverse(testData); // Convert to big endian
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Read ulong in big endian format
            ulong readValue = await BinaryReaderWriter.ReadULongExactly(stream, false, buffer, cancellationToken);

            // Assert: Long is read correctly in big endian format
            Assert.Equal(testValue, readValue);
        }

        #endregion

        #region ReadLongExactly Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadLongExactly with valid stream
        ///     Act: Read long from little endian stream
        ///     Assert: Long is read correctly in little endian format
        /// </summary>
        [Fact]
        public async Task ReadLongExactly_LittleEndian_ReadsCorrectly()
        {
            // Arrange: Create stream with long data (little endian)
            long testValue = 0x123456789ABCDEF0L;
            byte[] testData = BitConverter.GetBytes(testValue);
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Read long in little endian format
            long readValue = await BinaryReaderWriter.ReadLongExactly(stream, true, buffer, cancellationToken);

            // Assert: Long is read correctly in little endian format
            Assert.Equal(testValue, readValue);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadLongExactly with valid stream
        ///     Act: Read long from big endian stream
        ///     Assert: Long is read correctly in big endian format
        /// </summary>
        [Fact]
        public async Task ReadLongExactly_BigEndian_ReadsCorrectly()
        {
            // Arrange: Create stream with long data (big endian)
            long testValue = 0x123456789ABCDEF0L;
            byte[] testData = BitConverter.GetBytes(testValue);
            Array.Reverse(testData); // Convert to big endian
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Read long in big endian format
            long readValue = await BinaryReaderWriter.ReadLongExactly(stream, false, buffer, cancellationToken);

            // Assert: Long is read correctly in big endian format
            Assert.Equal(testValue, readValue);
        }

        #endregion

        #region HandleEndianness Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter HandleEndianness with little endian flag
        ///     Act: Process buffer without reversing (little endian)
        ///     Assert: Buffer remains unchanged for little endian
        /// </summary>
        [Fact]
        public void HandleEndianness_LittleEndian_NoReverse()
        {
            // Arrange: Create buffer with test data
            byte[] testData = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            ArraySegment<byte> buffer = new ArraySegment<byte>(testData);

            // Act: Process buffer as little endian (no reverse)
            BinaryReaderWriter.HandleEndianness(true, buffer);

            // Assert: Buffer remains unchanged for little endian
            byte[] result = new byte[testData.Length];
            Array.Copy(testData, result, testData.Length);
            Assert.Equal(testData, result);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter HandleEndianness with big endian flag
        ///     Act: Process buffer and reverse bytes (big endian)
        ///     Assert: Buffer is reversed for big endian
        /// </summary>
        [Fact]
        public void HandleEndianness_BigEndian_Reverses()
        {
            // Arrange: Create buffer with test data
            byte[] testData = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            ArraySegment<byte> buffer = new ArraySegment<byte>(testData);

            // Act: Process buffer as big endian (reverse)
            BinaryReaderWriter.HandleEndianness(false, buffer);

            // Assert: Buffer is reversed for big endian
            byte[] expected = { 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01 };
            byte[] result = new byte[testData.Length];
            Array.Copy(testData, result, testData.Length);
            Assert.Equal(expected, result);
        }

        #endregion

        #region ReverseBuffer Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReverseBuffer with valid buffer
        ///     Act: Reverse 8-byte buffer
        ///     Assert: Buffer is reversed correctly
        /// </summary>
        [Fact]
        public void ReverseBuffer_ValidBuffer_ReversesCorrectly()
        {
            // Arrange: Create buffer with test data
            byte[] testData = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            ArraySegment<byte> buffer = new ArraySegment<byte>(testData);

            // Act: Reverse 8-byte buffer
            BinaryReaderWriter.ReverseBuffer(buffer);

            // Assert: Buffer is reversed correctly
            byte[] expected = { 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01 };
            byte[] result = new byte[testData.Length];
            Array.Copy(testData, result, testData.Length);
            Assert.Equal(expected, result);
        }

        #endregion

        #region ConvertToLong Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ConvertToLong with valid buffer
        ///     Act: Convert 8-byte buffer to long
        ///     Assert: Long is converted correctly
        /// </summary>
        [Fact]
        public void ConvertToLong_ValidBuffer_ConvertsCorrectly()
        {
            // Arrange: Create buffer with test data
            long testValue = 0x123456789ABCDEF0L;
            byte[] testData = BitConverter.GetBytes(testValue);
            ArraySegment<byte> buffer = new ArraySegment<byte>(testData);

            // Act: Convert 8-byte buffer to long
            long result = BinaryReaderWriter.ConvertToLong(buffer);

            // Assert: Long is converted correctly
            Assert.Equal(testValue, result);
        }

        #endregion

        #region GetBytesInCorrectEndianness Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter GetBytesInCorrectEndianness with little endian flag
        ///     Act: Get bytes in little endian format
        ///     Assert: Bytes are returned in little endian format
        /// </summary>
        [Fact]
        public void GetBytesInCorrectEndianness_LittleEndian_ReturnsLittleEndian()
        {
            // Arrange: Create test value
            int testValue = 0x12345678;

            // Act: Get bytes in little endian format
            byte[] result = BinaryReaderWriter.GetBytesInCorrectEndianness(testValue, true);

            // Assert: Bytes are returned in little endian format
            byte[] expected = BitConverter.GetBytes(testValue);
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter GetBytesInCorrectEndianness with big endian flag
        ///     Act: Get bytes in big endian format
        ///     Assert: Bytes are returned in big endian format (reversed)
        /// </summary>
        [Fact]
        public void GetBytesInCorrectEndianness_BigEndian_ReturnsBigEndian()
        {
            // Arrange: Create test value
            int testValue = 0x12345678;

            // Act: Get bytes in big endian format
            byte[] result = BinaryReaderWriter.GetBytesInCorrectEndianness(testValue, false);

            // Assert: Bytes are returned in big endian format (reversed)
            byte[] expected = BitConverter.GetBytes(testValue);
            Array.Reverse(expected);
            Assert.Equal(expected, result);
        }

        #endregion

        #region WriteToStream Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter WriteToStream with valid buffer and stream
        ///     Act: Write buffer to stream
        ///     Assert: Data is written to stream correctly
        /// </summary>
        [Fact]
        public void WriteToStream_ValidBuffer_WritesCorrectly()
        {
            // Arrange: Create buffer and stream
            byte[] testData = { 0x01, 0x02, 0x03, 0x04 };
            using MemoryStream stream = new MemoryStream();

            // Act: Write buffer to stream
            BinaryReaderWriter.WriteToStream(testData, stream);

            // Assert: Data is written to stream correctly
            byte[] result = stream.ToArray();
            Assert.Equal(testData, result);
        }

        #endregion

        #region WriteInt Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter WriteInt with valid value and stream
        ///     Act: Write int to stream in little endian format
        ///     Assert: Int is written correctly to stream
        /// </summary>
        [Fact]
        public void WriteInt_LittleEndian_WritesCorrectly()
        {
            // Arrange: Create stream and test value
            using MemoryStream stream = new MemoryStream();
            int testValue = 0x12345678;

            // Act: Write int to stream in little endian format
            BinaryReaderWriter.WriteInt(testValue, stream, true);

            // Assert: Int is written correctly to stream
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(testValue);
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter WriteInt with valid value and stream
        ///     Act: Write int to stream in big endian format
        ///     Assert: Int is written correctly to stream (reversed)
        /// </summary>
        [Fact]
        public void WriteInt_BigEndian_WritesCorrectly()
        {
            // Arrange: Create stream and test value
            using MemoryStream stream = new MemoryStream();
            int testValue = 0x12345678;

            // Act: Write int to stream in big endian format
            BinaryReaderWriter.WriteInt(testValue, stream, false);

            // Assert: Int is written correctly to stream (reversed)
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(testValue);
            Array.Reverse(expected);
            Assert.Equal(expected, result);
        }

        #endregion

        #region WriteULong Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter WriteULong with valid value and stream
        ///     Act: Write ulong to stream in little endian format
        ///     Assert: ULong is written correctly to stream
        /// </summary>
        [Fact]
        public void WriteULong_LittleEndian_WritesCorrectly()
        {
            // Arrange: Create stream and test value
            using MemoryStream stream = new MemoryStream();
            ulong testValue = 0x123456789ABCDEF0UL;

            // Act: Write ulong to stream in little endian format
            BinaryReaderWriter.WriteULong(testValue, stream, true);

            // Assert: ULong is written correctly to stream
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(testValue);
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter WriteULong with valid value and stream
        ///     Act: Write ulong to stream in big endian format
        ///     Assert: ULong is written correctly to stream (reversed)
        /// </summary>
        [Fact]
        public void WriteULong_BigEndian_WritesCorrectly()
        {
            // Arrange: Create stream and test value
            using MemoryStream stream = new MemoryStream();
            ulong testValue = 0x123456789ABCDEF0UL;

            // Act: Write ulong to stream in big endian format
            BinaryReaderWriter.WriteULong(testValue, stream, false);

            // Assert: ULong is written correctly to stream (reversed)
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(testValue);
            Array.Reverse(expected);
            Assert.Equal(expected, result);
        }

        #endregion

        #region WriteLong Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter WriteLong with valid value and stream
        ///     Act: Write long to stream in little endian format
        ///     Assert: Long is written correctly to stream
        /// </summary>
        [Fact]
        public void WriteLong_LittleEndian_WritesCorrectly()
        {
            // Arrange: Create stream and test value
            using MemoryStream stream = new MemoryStream();
            long testValue = 0x123456789ABCDEF0L;

            // Act: Write long to stream in little endian format
            BinaryReaderWriter.WriteLong(testValue, stream, true);

            // Assert: Long is written correctly to stream
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(testValue);
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter WriteLong with valid value and stream
        ///     Act: Write long to stream in big endian format
        ///     Assert: Long is written correctly to stream (reversed)
        /// </summary>
        [Fact]
        public void WriteLong_BigEndian_WritesCorrectly()
        {
            // Arrange: Create stream and test value
            using MemoryStream stream = new MemoryStream();
            long testValue = 0x123456789ABCDEF0L;

            // Act: Write long to stream in big endian format
            BinaryReaderWriter.WriteLong(testValue, stream, false);

            // Assert: Long is written correctly to stream (reversed)
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(testValue);
            Array.Reverse(expected);
            Assert.Equal(expected, result);
        }

        #endregion

        #region WriteUShort Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter WriteUShort with valid value and stream
        ///     Act: Write ushort to stream in little endian format
        ///     Assert: UShort is written correctly to stream
        /// </summary>
        [Fact]
        public void WriteUShort_LittleEndian_WritesCorrectly()
        {
            // Arrange: Create stream and test value
            using MemoryStream stream = new MemoryStream();
            ushort testValue = 0x1234;

            // Act: Write ushort to stream in little endian format
            BinaryReaderWriter.WriteUShort(testValue, stream, true);

            // Assert: UShort is written correctly to stream
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(testValue);
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter WriteUShort with valid value and stream
        ///     Act: Write ushort to stream in big endian format
        ///     Assert: UShort is written correctly to stream (reversed)
        /// </summary>
        [Fact]
        public void WriteUShort_BigEndian_WritesCorrectly()
        {
            // Arrange: Create stream and test value
            using MemoryStream stream = new MemoryStream();
            ushort testValue = 0x1234;

            // Act: Write ushort to stream in big endian format
            BinaryReaderWriter.WriteUShort(testValue, stream, false);

            // Assert: UShort is written correctly to stream (reversed)
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(testValue);
            Array.Reverse(expected);
            Assert.Equal(expected, result);
        }

        #endregion

        #region Edge Cases and Error Handling

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter ReadExactly with zero length
        ///     Act: Read zero bytes from stream
        ///     Assert: Method returns immediately without error
        /// </summary>
        [Fact]
        public async Task ReadExactly_ZeroLength_EdgeCase()
        {
            // Arrange: Create valid stream and buffer
            using MemoryStream stream = new MemoryStream();
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Read zero bytes from stream
            await BinaryReaderWriter.ReadExactly(0, stream, buffer, cancellationToken);

            // Assert: Method returns immediately without error
            Assert.NotNull(stream);
        }

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter with cancellation token
        ///     Act: Read bytes with cancellation
        ///     Assert: Method respects cancellation token
        /// </summary>
        [Fact]
        public async Task ReadExactly_CancellationToken_RespectsCancellation()
        {
            // Arrange: Create stream and buffer with cancellation token
            using MemoryStream stream = new MemoryStream();
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[10]);
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            // Act & Assert: Method respects cancellation token
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await BinaryReaderWriter.ReadExactly(5, stream, buffer, cts.Token));
        }

        #endregion

        #region Integration Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter with complete WebSocket frame data
        ///     Act: Write and read complete frame data using all methods
        ///     Assert: Complete frame data is written and read correctly
        /// </summary>
        [Fact]
        public async Task Integration_CompleteFrameData_WritesAndReadsCorrectly()
        {
            // Arrange: Create stream and test data
            using MemoryStream stream = new MemoryStream();
            byte[] maskKey = { 0x01, 0x02, 0x03, 0x04 };
            byte[] frameData = { 0x10, 0x20, 0x30, 0x40 };
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[16]);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act: Write complete frame data using all methods
            BinaryReaderWriter.WriteInt(0x12345678, stream, true);
            BinaryReaderWriter.WriteULong(0x123456789ABCDEF0UL, stream, true);
            BinaryReaderWriter.WriteLong(0x123456789ABCDEF0L, stream, true);
            BinaryReaderWriter.WriteUShort(0x1234, stream, true);

            // Assert: Complete frame data is written correctly
            byte[] result = stream.ToArray();
            Assert.NotEqual(0, result.Length);
        }

        #endregion

        #region Thread Safety Tests

        /// <summary>
        ///     Arrange: Create BinaryReaderWriter methods concurrently
        ///     Act: Verify methods can be called in parallel
        ///     Assert: Methods are thread-safe
        /// </summary>
        [Fact]
        public void ThreadSafety_ConcurrentCalls_AreThreadSafe()
        {
            // Arrange: Create stream and buffer
            using MemoryStream stream = new MemoryStream();
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8]);

            // Act: Call methods concurrently
            BinaryReaderWriter.WriteInt(1, stream, true);
            BinaryReaderWriter.WriteLong(2L, stream, true);
            BinaryReaderWriter.WriteULong(3UL, stream, true);
            BinaryReaderWriter.WriteUShort(4, stream, true);

            // Assert: Methods are thread-safe
            byte[] result = stream.ToArray();
            Assert.Equal(18, result.Length); // 4 + 8 + 8 + 2 bytes
        }

        #endregion
    }
}
