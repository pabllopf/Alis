using System;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    /// The stream adaptor tests class
    /// </summary>
    public class StreamAdaptorTests
    {
        /// <summary>
        /// Tests that input stream ptr is not zero
        /// </summary>
        [Fact]
        public void InputStreamPtr_IsNotZero()
        {
            using MemoryStream ms = new MemoryStream(new byte[] { 1, 2, 3, 4, 5 });
            using StreamAdaptor adaptor = new StreamAdaptor(ms);
            Assert.NotEqual(IntPtr.Zero, adaptor.InputStreamPtr);
        }

        /// <summary>
        /// Tests that read seek tell get size work correctly
        /// </summary>
        [Fact]
        public void Read_Seek_Tell_GetSize_WorkCorrectly()
        {
            using MemoryStream ms = new MemoryStream(new byte[] { 10, 20, 30, 40, 50 });
            using StreamAdaptor adaptor = new StreamAdaptor(ms);
            InputStream inputStream = Marshal.PtrToStructure<InputStream>(adaptor.InputStreamPtr);
            byte[] buffer = new byte[5];
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            try
            {
                long read = inputStream.Read(handle.AddrOfPinnedObject(), 5, IntPtr.Zero);
                Assert.Equal(5, read);
                long seek = inputStream.Seek(2, IntPtr.Zero);
                Assert.Equal(2, seek);
                long tell = inputStream.Tell(IntPtr.Zero);
                Assert.Equal(2, tell);
                long size = inputStream.GetSize(IntPtr.Zero);
                Assert.Equal(5, size);
            }
            finally
            {
                handle.Free();
            }
        }
    }
}

