

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Tests for VideoMode structure
    /// </summary>
    public class VideoModeTests
    {
        /// <summary>
        ///     Tests that video mode struct size is 24 bytes
        /// </summary>
        [Fact]
        public void VideoMode_StructSize_Is24Bytes()
        {
            int size = Marshal.SizeOf<VideoMode>();

            Assert.Equal(24, size);
        }

        /// <summary>
        ///     Tests that video mode width field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_WidthField_HasCorrectOffset()
        {
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.Width)).ToInt64();

            Assert.Equal(0, offset);
        }

        /// <summary>
        ///     Tests that video mode height field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_HeightField_HasCorrectOffset()
        {
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.Height)).ToInt64();

            Assert.Equal(4, offset);
        }

        /// <summary>
        ///     Tests that video mode red bits field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_RedBitsField_HasCorrectOffset()
        {
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.RedBits)).ToInt64();

            Assert.Equal(8, offset);
        }

        /// <summary>
        ///     Tests that video mode green bits field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_GreenBitsField_HasCorrectOffset()
        {
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.GreenBits)).ToInt64();

            Assert.Equal(12, offset);
        }

        /// <summary>
        ///     Tests that video mode blue bits field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_BlueBitsField_HasCorrectOffset()
        {
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.BlueBits)).ToInt64();

            Assert.Equal(16, offset);
        }

        /// <summary>
        ///     Tests that video mode refresh rate field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_RefreshRateField_HasCorrectOffset()
        {
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.RefreshRate)).ToInt64();

            Assert.Equal(20, offset);
        }

        /// <summary>
        ///     Tests that video mode can be allocated in unmanaged memory
        /// </summary>
        [Fact]
        public void VideoMode_CanBeAllocatedInUnmanagedMemory()
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<VideoMode>());

            try
            {
                Marshal.WriteInt32(ptr, 0, 1920); // Width
                Marshal.WriteInt32(ptr, 4, 1080); // Height
                Marshal.WriteInt32(ptr, 8, 8); // RedBits
                Marshal.WriteInt32(ptr, 12, 8); // GreenBits
                Marshal.WriteInt32(ptr, 16, 8); // BlueBits
                Marshal.WriteInt32(ptr, 20, 60); // RefreshRate

                VideoMode mode = Marshal.PtrToStructure<VideoMode>(ptr);

                Assert.Equal(1920, mode.Width);
                Assert.Equal(1080, mode.Height);
                Assert.Equal(8, mode.RedBits);
                Assert.Equal(8, mode.GreenBits);
                Assert.Equal(8, mode.BlueBits);
                Assert.Equal(60, mode.RefreshRate);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}