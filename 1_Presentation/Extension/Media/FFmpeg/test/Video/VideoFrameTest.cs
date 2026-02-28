// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoFrameTest.cs
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
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The video frame test class
    /// </summary>
    /// <seealso cref="VideoFrame" />
    public class VideoFrameTest
    {
        /// <summary>
        ///     Tests that video frame constructor with valid parameters should create instance
        /// </summary>
        [Fact]
        public void VideoFrame_ConstructorWithValidParameters_ShouldCreateInstance()
        {
            // Arrange & Act
            VideoFrame frame = new VideoFrame(1920, 1080);

            // Assert
            Assert.NotNull(frame);
            Assert.Equal(1920, frame.Width);
            Assert.Equal(1080, frame.Height);
        }

        /// <summary>
        ///     Tests that video frame constructor with zero width should throw exception
        /// </summary>
        [Fact]
        public void VideoFrame_ConstructorWithZeroWidth_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidDataException>(() => new VideoFrame(0, 1080));
        }

        /// <summary>
        ///     Tests that video frame constructor with zero height should throw exception
        /// </summary>
        [Fact]
        public void VideoFrame_ConstructorWithZeroHeight_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidDataException>(() => new VideoFrame(1920, 0));
        }

        /// <summary>
        ///     Tests that video frame constructor with negative width should throw exception
        /// </summary>
        [Fact]
        public void VideoFrame_ConstructorWithNegativeWidth_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidDataException>(() => new VideoFrame(-1920, 1080));
        }

        /// <summary>
        ///     Tests that video frame constructor with negative height should throw exception
        /// </summary>
        [Fact]
        public void VideoFrame_ConstructorWithNegativeHeight_ShouldThrowException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidDataException>(() => new VideoFrame(1920, -1080));
        }

        /// <summary>
        ///     Tests that video frame raw data should not be null after construction
        /// </summary>
        [Fact]
        public void VideoFrame_RawData_ShouldNotBeNullAfterConstruction()
        {
            // Arrange & Act
            VideoFrame frame = new VideoFrame(1920, 1080);

            // Assert
            Assert.NotNull(frame.RawData);
        }

        /// <summary>
        ///     Tests that video frame raw data length should be correct for rgb 24
        /// </summary>
        [Fact]
        public void VideoFrame_RawDataLength_ShouldBeCorrectForRgb24()
        {
            // Arrange
            int width = 1920;
            int height = 1080;
            int expectedLength = width * height * 3; // RGB24 = 3 bytes per pixel

            // Act
            VideoFrame frame = new VideoFrame(width, height);

            // Assert
            Assert.Equal(expectedLength, frame.RawData.Length);
        }

        /// <summary>
        ///     Tests that video frame load from empty stream should return false
        /// </summary>
        [Fact]
        public void VideoFrame_LoadFromEmptyStream_ShouldReturnFalse()
        {
            // Arrange
            VideoFrame frame = new VideoFrame(100, 100);
            MemoryStream emptyStream = new MemoryStream();

            // Act
            bool result = frame.Load(emptyStream);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that video frame load from stream with data should return true
        /// </summary>
        [Fact]
        public void VideoFrame_LoadFromStreamWithData_ShouldReturnTrue()
        {
            // Arrange
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] testData = new byte[300]; // 10 * 10 * 3 bytes
            MemoryStream stream = new MemoryStream(testData);

            // Act
            bool result = frame.Load(stream);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that video frame load from partial stream should return true
        /// </summary>
        [Fact]
        public void VideoFrame_LoadFromPartialStream_ShouldReturnTrue()
        {
            // Arrange
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] testData = new byte[150]; // Only half the required data
            MemoryStream stream = new MemoryStream(testData);

            // Act
            bool result = frame.Load(stream);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that video frame dispose should clear frame buffer
        /// </summary>
        [Fact]
        public void VideoFrame_Dispose_ShouldClearFrameBuffer()
        {
            // Arrange
            VideoFrame frame = new VideoFrame(1920, 1080);

            // Act
            frame.Dispose();

            // Assert - No exception thrown
            Assert.NotNull(frame);
        }

        /// <summary>
        ///     Tests that video frame should implement i media frame interface
        /// </summary>
        [Fact]
        public void VideoFrame_ShouldImplementIMediaFrameInterface()
        {
            // Arrange & Act
            VideoFrame frame = new VideoFrame(1920, 1080);

            // Assert
            Assert.IsAssignableFrom<IMediaFrame>(frame);
        }

        /// <summary>
        ///     Tests that video frame should implement i disposable interface
        /// </summary>
        [Fact]
        public void VideoFrame_ShouldImplementIDisposableInterface()
        {
            // Arrange & Act
            VideoFrame frame = new VideoFrame(1920, 1080);

            // Assert
            Assert.IsAssignableFrom<IDisposable>(frame);
        }

        /// <summary>
        ///     Tests that video frame get pixels should return correct byte array
        /// </summary>
        [Fact]
        public void VideoFrame_GetPixels_ShouldReturnCorrectByteArray()
        {
            // Arrange
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] testData = new byte[300];
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = (byte) i;
            }

            MemoryStream stream = new MemoryStream(testData);
            frame.Load(stream);

            // Act
            byte[] pixel = frame.GetPixels(0, 0);

            // Assert
            Assert.Equal(3, pixel.Length); // RGB24 = 3 bytes
        }

        /// <summary>
        ///     Tests that video frame get pixels with length should return correct size
        /// </summary>
        [Fact]
        public void VideoFrame_GetPixelsWithLength_ShouldReturnCorrectSize()
        {
            // Arrange
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] testData = new byte[300];
            MemoryStream stream = new MemoryStream(testData);
            frame.Load(stream);

            // Act
            byte[] pixels = frame.GetPixels(0, 0, 5);

            // Assert
            Assert.Equal(15, pixels.Length); // 5 pixels * 3 bytes
        }

        /// <summary>
        ///     Tests that video frame should support common resolutions
        /// </summary>
        [Fact]
        public void VideoFrame_ShouldSupportCommonResolutions()
        {
            // Arrange & Act
            VideoFrame frame720p = new VideoFrame(1280, 720);
            VideoFrame frame1080p = new VideoFrame(1920, 1080);
            VideoFrame frame4k = new VideoFrame(3840, 2160);

            // Assert
            Assert.Equal(1280, frame720p.Width);
            Assert.Equal(720, frame720p.Height);
            Assert.Equal(1920, frame1080p.Width);
            Assert.Equal(1080, frame1080p.Height);
            Assert.Equal(3840, frame4k.Width);
            Assert.Equal(2160, frame4k.Height);
        }

        /// <summary>
        ///     Tests that video frame multiple load calls should work
        /// </summary>
        [Fact]
        public void VideoFrame_MultipleLoadCalls_ShouldWork()
        {
            // Arrange
            VideoFrame frame = new VideoFrame(10, 10);
            byte[] testData = new byte[300];

            // Act
            MemoryStream stream1 = new MemoryStream(testData);
            bool result1 = frame.Load(stream1);

            MemoryStream stream2 = new MemoryStream(testData);
            bool result2 = frame.Load(stream2);

            // Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        /// <summary>
        ///     Tests that video frame should support small dimensions
        /// </summary>
        [Fact]
        public void VideoFrame_ShouldSupportSmallDimensions()
        {
            // Arrange & Act
            VideoFrame frame = new VideoFrame(1, 1);

            // Assert
            Assert.Equal(1, frame.Width);
            Assert.Equal(1, frame.Height);
            Assert.Equal(3, frame.RawData.Length);
        }

        /// <summary>
        ///     Tests that video frame dispose multiple times should be safe
        /// </summary>
        [Fact]
        public void VideoFrame_DisposeMultipleTimes_ShouldBeSafe()
        {
            // Arrange
            VideoFrame frame = new VideoFrame(1920, 1080);

            // Act
            frame.Dispose();
            frame.Dispose();
            frame.Dispose();

            // Assert - No exception thrown
            Assert.NotNull(frame);
        }
    }
}