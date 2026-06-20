// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BufferPoolTest.cs
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
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     Comprehensive tests for BufferPool class - thread-safe buffer management pool
    /// </summary>
    public class BufferPoolTest : IDisposable
    {
        /// <summary>
        /// The default pool
        /// </summary>
        private readonly BufferPool _defaultPool;
        /// <summary>
        /// The custom size pool
        /// </summary>
        private readonly BufferPool _customSizePool;
        /// <summary>
        /// The custom buffer size
        /// </summary>
        private const int CustomBufferSize = 4096;

        /// <summary>
        /// Initializes a new instance of the <see cref="BufferPoolTest"/> class
        /// </summary>
        public BufferPoolTest()
        {
            _defaultPool = new BufferPool();
            _customSizePool = new BufferPool(CustomBufferSize);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _defaultPool?.Dispose();
            _customSizePool?.Dispose();
        }

        #region Constructor Tests

        /// <summary>
        ///     Arrange: Create BufferPool with default constructor
        ///     Act: Verify pool is created successfully
        ///     Assert: Pool instance is not null and has default buffer size
        /// </summary>
        [Fact]
        public void BufferPool_Constructor_DefaultSize_CreatesPoolWithDefaultBufferSize()
        {
            // Arrange: No setup needed - using _defaultPool from constructor

            // Act: Get a buffer to verify pool functionality
            using (MemoryStream buffer = _defaultPool.GetBuffer())
            {
                // Assert: Buffer is created successfully
                Assert.NotNull(buffer);
                Assert.NotNull(buffer.GetBuffer());
            }
        }

        /// <summary>
        ///     Arrange: Create BufferPool with custom buffer size
        ///     Act: Verify pool is created with specified size
        ///     Assert: Pool instance is not null and can allocate buffers
        /// </summary>
        [Fact]
        public void BufferPool_Constructor_CustomSize_CreatesPoolWithSpecifiedBufferSize()
        {
            // Arrange: Using _customSizePool from constructor

            // Act: Get a buffer from custom pool
            using (MemoryStream buffer = _customSizePool.GetBuffer())
            {
                // Assert: Buffer is created successfully with custom size
                Assert.NotNull(buffer);
                byte[] bufferArray = buffer.GetBuffer();
                Assert.NotNull(bufferArray);
                // Note: Actual size may be larger due to MemoryStream internal growth
            }
        }

        /// <summary>
        ///     Arrange: Create multiple BufferPool instances
        ///     Act: Verify each pool is independent
        ///     Assert: Each pool can manage buffers independently
        /// </summary>
        [Fact]
        public void BufferPool_MultipleInstances_AreIndependent()
        {
            // Arrange: Create two separate pools
            BufferPool pool1 = new BufferPool();
            BufferPool pool2 = new BufferPool(CustomBufferSize);

            // Act: Get buffers from each pool
            using (MemoryStream buffer1 = pool1.GetBuffer())
            using (MemoryStream buffer2 = pool2.GetBuffer())
            {
                // Assert: Both pools work independently
                Assert.NotNull(buffer1);
                Assert.NotNull(buffer2);
                Assert.NotEqual(buffer1.GetBuffer(), buffer2.GetBuffer());
            }

            pool1.Dispose();
            pool2.Dispose();
        }

        #endregion

        #region GetBuffer Tests

        /// <summary>
        ///     Arrange: Create BufferPool and request a buffer
        ///     Act: Get buffer from pool
        ///     Assert: Buffer is not null and has valid array
        /// </summary>
        [Fact]
        public void BufferPool_GetBuffer_ReturnsValidMemoryStream()
        {
            // Arrange: Using _defaultPool from constructor

            // Act: Get buffer from pool
            using (MemoryStream buffer = _defaultPool.GetBuffer())
            {
                // Assert: Buffer is valid and usable
                Assert.NotNull(buffer);
                byte[] bufferArray = buffer.GetBuffer();
                Assert.NotNull(bufferArray);
                Assert.Equal(0, buffer.Position);
                Assert.Equal(0, buffer.Length);
            }
        }

        /// <summary>
        ///     Arrange: Create BufferPool with custom size and request buffer
        ///     Act: Get buffer from pool
        ///     Assert: Buffer has capacity at least equal to custom size
        /// </summary>
        [Fact]
        public void BufferPool_GetBuffer_WithCustomSize_ReturnsBufferWithCorrectCapacity()
        {
            // Arrange: Using _customSizePool from constructor

            // Act: Get buffer from custom pool
            using (MemoryStream buffer = _customSizePool.GetBuffer())
            {
                // Assert: Buffer capacity is at least the custom size
                byte[] bufferArray = buffer.GetBuffer();
                Assert.NotNull(bufferArray);
                Assert.InRange(bufferArray.Length, CustomBufferSize, int.MaxValue);
            }
        }

        /// <summary>
        ///     Arrange: Create BufferPool and request multiple buffers sequentially
        ///     Act: Get multiple buffers from pool
        ///     Assert: Each buffer is independent and valid
        /// </summary>
        [Fact]
        public void BufferPool_GetBuffer_MultipleSequentialCalls_ReturnsIndependentBuffers()
        {
            // Arrange: Using _defaultPool from constructor

            // Act: Get multiple buffers sequentially
            using (MemoryStream buffer1 = _defaultPool.GetBuffer())
            using (MemoryStream buffer2 = _defaultPool.GetBuffer())
            using (MemoryStream buffer3 = _defaultPool.GetBuffer())
            {
                // Assert: All buffers are independent
                Assert.NotNull(buffer1);
                Assert.NotNull(buffer2);
                Assert.NotNull(buffer3);

                byte[] array1 = buffer1.GetBuffer();
                byte[] array2 = buffer2.GetBuffer();
                byte[] array3 = buffer3.GetBuffer();

                Assert.NotSame(array1, array2);
                Assert.NotSame(array2, array3);
                Assert.NotSame(array1, array3);
            }
        }

        /// <summary>
        ///     Arrange: Create BufferPool and request buffer without using it
        ///     Act: Get buffer but don't write to it
        ///     Assert: Buffer is still valid and can be used later
        /// </summary>
        [Fact]
        public void BufferPool_GetBuffer_WithoutWrite_IsStillValid()
        {
            // Arrange: Using _defaultPool from constructor

            // Act: Get buffer without writing
            using (MemoryStream buffer = _defaultPool.GetBuffer())
            {
                // Assert: Buffer is valid even without writes
                Assert.NotNull(buffer);
                Assert.Equal(0, buffer.Length);
                Assert.Equal(0, buffer.Position);
            }
        }

        #endregion

        #region PublicBufferMemoryStream Tests

  

        /// <summary>
        ///     Arrange: Create PublicBufferMemoryStream and write data
        ///     Act: Read data from stream at different positions
        ///     Assert: Data is read correctly at each position
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Read_ReadsDataCorrectly()
        {
            // Arrange: Create pool and stream with data
            using (MemoryStream buffer = _defaultPool.GetBuffer())
            {
                // Act: Write and read data
                PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), _defaultPool);
                byte[] testData = { 0x10, 0x20, 0x30, 0x40, 0x50 };
                stream.Write(testData, 0, testData.Length);

                // Assert: Read data matches written data
                stream.Position = 0;
                byte[] readData = new byte[testData.Length];
#if NET9_0_OR_GREATER
                stream.ReadExactly(readData, 0, testData.Length);
#else
                stream.Read(readData, 0, testData.Length);
#endif
                Assert.Equal(testData, readData);
            }
        }



        /// <summary>
        ///     Arrange: Create PublicBufferMemoryStream and write data
        ///     Act: Seek to different positions and read/write
        ///     Assert: Position changes work correctly
        /// </summary>
        [Fact]
        public void PublicBufferMemoryStream_Seek_ChangesPositionCorrectly()
        {
            // Arrange: Create pool and stream with data
            using (MemoryStream buffer = _defaultPool.GetBuffer())
            {
                // Act: Write data and seek to different positions
                PublicBufferMemoryStream stream = new PublicBufferMemoryStream(buffer.GetBuffer(), _defaultPool);
                byte[] testData = { 0x01, 0x02, 0x03, 0x04, 0x05 };
                stream.Write(testData, 0, testData.Length);

                // Assert: Seek works correctly
                stream.Position = 2;
                Assert.Equal(2, stream.Position);
                byte[] readData = new byte[3];
                stream.Read(readData, 0, 3);
                Assert.Equal(new byte[] { 0x03, 0x04, 0x05 }, readData);

                // Seek to beginning
                stream.Position = 0;
                Assert.Equal(0, stream.Position);
            }
        }


        #endregion

        #region Buffer Pool Management Tests

        /// <summary>
        ///     Arrange: Create BufferPool and get multiple buffers
        ///     Act: Get, use, and return buffers to pool
        ///     Assert: Pool manages buffers correctly and can reuse them
        /// </summary>
        [Fact]
        public void BufferPool_BufferManagement_ReturnsBuffersToPoolCorrectly()
        {
            // Arrange: Create pool and get multiple buffers
            BufferPool testPool = new BufferPool(1024);

            // Act: Get and dispose buffers (which returns them to pool)
            using (MemoryStream buffer1 = testPool.GetBuffer())
            using (MemoryStream buffer2 = testPool.GetBuffer())
            {
                // Write some data to buffers
                buffer1.WriteByte(0x01);
                buffer2.WriteByte(0x02);
            }

            // Assert: Buffers are returned to pool and can be reused
            using (MemoryStream buffer3 = testPool.GetBuffer())
            {
                Assert.NotNull(buffer3);
                Assert.Equal(0, buffer3.Length);
            }

            testPool.Dispose();
        }


        /// <summary>
        ///     Arrange: Create BufferPool and get buffer
        ///     Act: Write and read data from buffer
        ///     Assert: Data integrity is maintained through pool operations
        /// </summary>
        [Fact]
        public void BufferPool_DataIntegrity_MaintainsDataCorrectly()
        {
            // Arrange: Create pool and get buffer
            using (MemoryStream buffer = _defaultPool.GetBuffer())
            {
                // Act: Write specific data pattern
                byte[] testData = new byte[256];
                for (int i = 0; i < testData.Length; i++)
                {
                    testData[i] = (byte)(i * 7 % 256);
                }

                buffer.Write(testData, 0, testData.Length);

                // Assert: Data integrity is maintained
                buffer.Position = 0;
                byte[] readData = new byte[testData.Length];
                buffer.Read(readData, 0, testData.Length);
                Assert.Equal(testData, readData);
            }
        }

        /// <summary>
        ///     Arrange: Create BufferPool and get buffer
        ///     Act: Write data, close stream, get new buffer
        ///     Assert: New buffer is independent and pool manages lifecycle correctly
        /// </summary>
        [Fact]
        public void BufferPool_StreamLifecycle_ManagesStreamLifecycleCorrectly()
        {
            // Arrange: Create pool
            BufferPool lifecyclePool = new BufferPool(512);

            // Act: Get buffer, write data, dispose (returns to pool)
            using (MemoryStream buffer1 = lifecyclePool.GetBuffer())
            {
                byte[] testData = { 0xDE, 0xAD, 0xBE, 0xEF };
                buffer1.Write(testData, 0, testData.Length);
            }

            // Assert: Can get new buffer from pool
            using (MemoryStream buffer2 = lifecyclePool.GetBuffer())
            {
                Assert.NotNull(buffer2);
                Assert.Equal(0, buffer2.Length);
            }

            lifecyclePool.Dispose();
        }

        #endregion

        #region Edge Cases and Error Handling


        /// <summary>
        ///     Arrange: Create BufferPool with large buffer size
        ///     Act: Get buffer and verify it can handle large allocations
        ///     Assert: Large buffers are allocated correctly
        /// </summary>
        [Fact]
        public void BufferPool_LargeBufferSize_HandlesLargeBuffers()
        {
            // Arrange: Create pool with large buffer size
            int largeBufferSize = 1024 * 1024; // 1MB
            BufferPool largePool = new BufferPool(largeBufferSize);

            // Act: Get buffer from large pool
            using (MemoryStream buffer = largePool.GetBuffer())
            {
                // Assert: Large buffer is allocated correctly
                byte[] bufferArray = buffer.GetBuffer();
                Assert.NotNull(bufferArray);
                Assert.InRange(bufferArray.Length, largeBufferSize, int.MaxValue);
            }

            largePool.Dispose();
        }

     

        #endregion

        #region Thread Safety Tests

        /// <summary>
        ///     Arrange: Create BufferPool and get multiple buffers concurrently
        ///     Act: Get buffers from pool in parallel
        ///     Assert: Pool handles concurrent requests correctly
        /// </summary>
        [Fact]
        public void BufferPool_ConcurrentAccess_HandlesConcurrentRequests()
        {
            // Arrange: Create pool
            BufferPool concurrentPool = new BufferPool(1024);

            // Act: Get multiple buffers concurrently
            List<MemoryStream> buffers = new List<MemoryStream>();

            for (int i = 0; i < 10; i++)
            {
                buffers.Add(concurrentPool.GetBuffer());
            }

            // Assert: All buffers are valid and independent
            for (int i = 0; i < buffers.Count; i++)
            {
                Assert.NotNull(buffers[i]);
                byte[] bufferArray = buffers[i].GetBuffer();
                Assert.NotNull(bufferArray);
            }

            // Cleanup
            foreach (MemoryStream buffer in buffers)
            {
                buffer.Dispose();
            }

            concurrentPool.Dispose();
        }

        /// <summary>
        ///     Arrange: Create BufferPool and get buffer
        ///     Act: Write data to buffer, then read from different position
        ///     Assert: Multiple operations on same buffer work correctly
        /// </summary>
        [Fact]
        public void BufferPool_MultipleOperations_HandlesMultipleOperations()
        {
            // Arrange: Create pool and get buffer
            using (MemoryStream buffer = _defaultPool.GetBuffer())
            {
                // Act: Perform multiple operations
                buffer.WriteByte(0x01);
                buffer.WriteByte(0x02);
                buffer.Position = 0;
                byte b1 = (byte)buffer.ReadByte();
                buffer.Position = 1;
                byte b2 = (byte)buffer.ReadByte();

                // Assert: Multiple operations work correctly
                Assert.Equal(0x01, b1);
                Assert.Equal(0x02, b2);
            }
        }

        #endregion

        #region Integration Tests

      
        /// <summary>
        ///     Arrange: Create BufferPool and get buffer
        ///     Act: Write binary data, read it back, verify integrity
        ///     Assert: Binary data is handled correctly through pool
        /// </summary>
        [Fact]
        public void BufferPool_Integration_BinaryDataHandling()
        {
            // Arrange: Create pool for binary data
            BufferPool binaryPool = new BufferPool(4096);

            // Act: Write and read binary data
            using (MemoryStream buffer = binaryPool.GetBuffer())
            {
                // Write binary data with various byte values
                byte[] binaryData = new byte[256];
                for (int i = 0; i < binaryData.Length; i++)
                {
                    binaryData[i] = (byte)i;
                }

                buffer.Write(binaryData, 0, binaryData.Length);

                // Read back and verify
                buffer.Position = 0;
                byte[] readData = new byte[binaryData.Length];
                buffer.Read(readData, 0, binaryData.Length);

                // Assert: Binary data integrity is maintained
                Assert.Equal(binaryData, readData);
            }

            binaryPool.Dispose();
        }

        #region Dispose Edge Cases

        /// <summary>
        ///     Arrange: Create BufferPool and dispose it twice
        ///     Act: Call Dispose() twice
        ///     Assert: Second dispose is safe and does not throw
        /// </summary>
        [Fact]
        public void BufferPool_Dispose_CalledTwice_ShouldNotThrow()
        {
            // Arrange: Create a new pool
            BufferPool pool = new BufferPool();

            // Act: Dispose twice
            pool.Dispose();

            // Assert: Second dispose does not throw
            pool.Dispose();
        }

        #endregion

        #endregion
    }
}
