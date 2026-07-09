using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    /// The binary reader writer branch coverage tests class
    /// </summary>
    public class BinaryReaderWriterBranchCoverageTests
    {
        /// <summary>
        /// Tests that read exactly cancellation token cancelled throws operation canceled exception
        /// </summary>
        [Fact]
        public async Task ReadExactly_CancellationTokenCancelled_ThrowsOperationCanceledException()
        {
            using MemoryStream stream = new MemoryStream(new byte[] { 0x01, 0x02, 0x03 });
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[10]);
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
                BinaryReaderWriter.ReadExactly(3, stream, buffer, cts.Token));
        }

        /// <summary>
        /// Tests that read exactly multiple reads large data completes successfully
        /// </summary>
        [Fact]
        public async Task ReadExactly_MultipleReadsLargeData_CompletesSuccessfully()
        {
            byte[] testData = new byte[8192];
            new Random(42).NextBytes(testData);
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8192]);

            await BinaryReaderWriter.ReadExactly(8192, stream, buffer, CancellationToken.None);

            byte[] result = new byte[8192];
            Array.Copy(buffer.Array, buffer.Offset, result, 0, 8192);
            Assert.Equal(testData, result);
        }

        /// <summary>
        /// Tests that write int zero value writes correctly
        /// </summary>
        [Fact]
        public void WriteInt_ZeroValue_WritesCorrectly()
        {
            using MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteInt(0, stream, true);
            byte[] result = stream.ToArray();
            Assert.Equal(new byte[] { 0x00, 0x00, 0x00, 0x00 }, result);
        }

        /// <summary>
        /// Tests that write int max value writes correctly
        /// </summary>
        [Fact]
        public void WriteInt_MaxValue_WritesCorrectly()
        {
            using MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteInt(int.MaxValue, stream, true);
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(int.MaxValue);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that write long max value writes correctly
        /// </summary>
        [Fact]
        public void WriteLong_MaxValue_WritesCorrectly()
        {
            using MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteLong(long.MaxValue, stream, true);
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(long.MaxValue);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that write u long max value writes correctly
        /// </summary>
        [Fact]
        public void WriteULong_MaxValue_WritesCorrectly()
        {
            using MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteULong(ulong.MaxValue, stream, true);
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(ulong.MaxValue);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that write u short max value writes correctly
        /// </summary>
        [Fact]
        public void WriteUShort_MaxValue_WritesCorrectly()
        {
            using MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteUShort(ushort.MaxValue, stream, true);
            byte[] result = stream.ToArray();
            byte[] expected = BitConverter.GetBytes(ushort.MaxValue);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that read u short exactly zero value reads correctly
        /// </summary>
        [Fact]
        public async Task ReadUShortExactly_ZeroValue_ReadsCorrectly()
        {
            byte[] testData = new byte[] { 0x00, 0x00 };
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2]);

            ushort result = await BinaryReaderWriter.ReadUShortExactly(stream, true, buffer, CancellationToken.None);

            Assert.Equal((ushort)0, result);
        }

        /// <summary>
        /// Tests that read u long exactly zero value reads correctly
        /// </summary>
        [Fact]
        public async Task ReadULongExactly_ZeroValue_ReadsCorrectly()
        {
            byte[] testData = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream stream = new MemoryStream(testData);
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8]);

            ulong result = await BinaryReaderWriter.ReadULongExactly(stream, true, buffer, CancellationToken.None);

            Assert.Equal((ulong)0, result);
        }

        /// <summary>
        /// Tests that get bytes in correct endianness zero value returns correct bytes
        /// </summary>
        [Fact]
        public void GetBytesInCorrectEndianness_ZeroValue_ReturnsCorrectBytes()
        {
            byte[] result = BinaryReaderWriter.GetBytesInCorrectEndianness(0, true);
            Assert.Equal(new byte[] { 0x00, 0x00, 0x00, 0x00 }, result);
        }

        /// <summary>
        /// Tests that write to stream empty buffer writes nothing
        /// </summary>
        [Fact]
        public void WriteToStream_EmptyBuffer_WritesNothing()
        {
            using MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteToStream(Array.Empty<byte>(), stream);
            Assert.Equal(0, stream.Length);
        }

        /// <summary>
        /// Tests that write to stream large buffer writes correctly
        /// </summary>
        [Fact]
        public void WriteToStream_LargeBuffer_WritesCorrectly()
        {
            byte[] testData = new byte[65536];
            new Random(42).NextBytes(testData);
            using MemoryStream stream = new MemoryStream();

            BinaryReaderWriter.WriteToStream(testData, stream);

            Assert.Equal(testData.Length, stream.Length);
            Assert.Equal(testData, stream.ToArray());
        }
    }
}
