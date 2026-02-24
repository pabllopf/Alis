// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoModeTests.cs
// 
//  Author:GitHub Copilot
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
        /// Tests that video mode struct size is 24 bytes
        /// </summary>
        [Fact]
        public void VideoMode_StructSize_Is24Bytes()
        {
            // Act
            int size = Marshal.SizeOf<VideoMode>();

            // Assert
            Assert.Equal(24, size);
        }

        /// <summary>
        /// Tests that video mode width field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_WidthField_HasCorrectOffset()
        {
            // Act
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.Width)).ToInt64();

            // Assert
            Assert.Equal(0, offset);
        }

        /// <summary>
        /// Tests that video mode height field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_HeightField_HasCorrectOffset()
        {
            // Act
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.Height)).ToInt64();

            // Assert
            Assert.Equal(4, offset);
        }

        /// <summary>
        /// Tests that video mode red bits field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_RedBitsField_HasCorrectOffset()
        {
            // Act
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.RedBits)).ToInt64();

            // Assert
            Assert.Equal(8, offset);
        }

        /// <summary>
        /// Tests that video mode green bits field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_GreenBitsField_HasCorrectOffset()
        {
            // Act
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.GreenBits)).ToInt64();

            // Assert
            Assert.Equal(12, offset);
        }

        /// <summary>
        /// Tests that video mode blue bits field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_BlueBitsField_HasCorrectOffset()
        {
            // Act
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.BlueBits)).ToInt64();

            // Assert
            Assert.Equal(16, offset);
        }

        /// <summary>
        /// Tests that video mode refresh rate field has correct offset
        /// </summary>
        [Fact]
        public void VideoMode_RefreshRateField_HasCorrectOffset()
        {
            // Act
            long offset = Marshal.OffsetOf<VideoMode>(nameof(VideoMode.RefreshRate)).ToInt64();

            // Assert
            Assert.Equal(20, offset);
        }

        /// <summary>
        /// Tests that video mode can be allocated in unmanaged memory
        /// </summary>
        [Fact]
        public void VideoMode_CanBeAllocatedInUnmanagedMemory()
        {
            // Arrange
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf<VideoMode>());

            try
            {
                // Act - Write test data
                Marshal.WriteInt32(ptr, 0, 1920);  // Width
                Marshal.WriteInt32(ptr, 4, 1080);  // Height
                Marshal.WriteInt32(ptr, 8, 8);     // RedBits
                Marshal.WriteInt32(ptr, 12, 8);    // GreenBits
                Marshal.WriteInt32(ptr, 16, 8);    // BlueBits
                Marshal.WriteInt32(ptr, 20, 60);   // RefreshRate

                // Read back
                VideoMode mode = Marshal.PtrToStructure<VideoMode>(ptr);

                // Assert
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

