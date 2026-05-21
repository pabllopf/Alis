

using System.IO;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The buffer pool test class
    /// </summary>
    public class IBufferPoolTest
    {
        /// <summary>
        ///     Tests that get buffer should return memory stream
        /// </summary>
        [Fact]
        public void GetBuffer_ShouldReturnMemoryStream()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer = bufferPool.GetBuffer();
            Assert.IsType<PublicBufferMemoryStream>(buffer);
        }

        /// <summary>
        ///     Tests that get buffer should return different instances
        /// </summary>
        [Fact]
        public void GetBuffer_ShouldReturnDifferentInstances()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer1 = bufferPool.GetBuffer();
            MemoryStream buffer2 = bufferPool.GetBuffer();
            Assert.NotSame(buffer1, buffer2);
        }

        /// <summary>
        ///     Tests that get buffer should return pooled memory stream
        /// </summary>
        [Fact]
        public void GetBuffer_ShouldReturnPooledMemoryStream()
        {
            BufferPool bufferPool = new BufferPool();
            MemoryStream buffer1 = bufferPool.GetBuffer();
            buffer1.Dispose();
            MemoryStream buffer2 = bufferPool.GetBuffer();
            Assert.Equal(buffer1.Length, buffer2.Length);
        }
    }
}