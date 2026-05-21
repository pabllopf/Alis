

using System.IO;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The buffer pool test class
    /// </summary>
    public class BufferPoolTest
    {
        /// <summary>
        ///     Tests that buffer pool constructor default size
        /// </summary>
        [Fact]
        public void BufferPool_Constructor_DefaultSize()
        {
            BufferPool bufferPool = new BufferPool();
            Assert.NotNull(bufferPool);
        }

        /// <summary>
        ///     Tests that buffer pool constructor custom size
        /// </summary>
        [Fact]
        public void BufferPool_Constructor_CustomSize()
        {
            BufferPool bufferPool = new BufferPool(1024);
            Assert.NotNull(bufferPool);
        }

        /// <summary>
        ///     Tests that buffer pool get buffer
        /// </summary>
        [Fact]
        public void BufferPool_GetBuffer()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            Assert.NotNull(buffer);
        }

        /// <summary>
        ///     Tests that public buffer memory stream constructor
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Constructor()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            Assert.NotNull(stream);
        }

        /// <summary>
        ///     Tests that public buffer memory stream write byte
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_WriteByte()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.WriteByte(0x20);
            Assert.Equal(0, stream.Length);
        }

        /// <summary>
        ///     Tests that public buffer memory stream write
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Write()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.Write(new byte[] {0x20, 0x30}, 0, 2);
            Assert.Equal(0, stream.Length);
        }

        /// <summary>
        ///     Tests that public buffer memory stream read byte
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_ReadByte()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.WriteByte(0x20);
            stream.Position = 0;
            Assert.Equal(0x20, stream.ReadByte());
        }

        /// <summary>
        ///     Tests that public buffer memory stream read
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Read()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.Write(new byte[] {0x20, 0x30}, 0, 2);
            stream.Position = 0;
            byte[] readBuffer = new byte[2];
# if NET9_0_OR_GREATER
            stream.ReadExactly(readBuffer, 0, 2);
# else
            stream.Read(readBuffer, 0, 2);
#endif
            Assert.Equal(new byte[] {0x20, 0x30}, readBuffer);
        }

        /// <summary>
        ///     Tests that public buffer memory stream close
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Close()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), bufferPool);
            stream.Close();
            Assert.Equal(0, stream.Length);
        }
    }
}