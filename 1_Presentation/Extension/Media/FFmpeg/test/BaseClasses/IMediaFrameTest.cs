// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IMediaFrameTest.cs
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

using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    ///     The i media frame test class
    /// </summary>
    /// <seealso cref="IMediaFrame" />
    public class IMediaFrameTest
    {
        /// <summary>
        ///     Tests that audio frame should implement i media frame
        /// </summary>
        [Fact]
        public void AudioFrame_ShouldImplementIMediaFrame()
        {
            // Arrange
            AudioFrame frame = new AudioFrame(2);

            // Act & Assert
            Assert.IsAssignableFrom<IMediaFrame>(frame);
        }

        /// <summary>
        ///     Tests that video frame should implement i media frame
        /// </summary>
        [Fact]
        public void VideoFrame_ShouldImplementIMediaFrame()
        {
            // Arrange
            VideoFrame frame = new VideoFrame(1920, 1080);

            // Act & Assert
            Assert.IsAssignableFrom<IMediaFrame>(frame);
        }

        /// <summary>
        ///     Tests that i media frame raw data should not be null for audio frame
        /// </summary>
        [Fact]
        public void IMediaFrame_RawDataShouldNotBeNullForAudioFrame()
        {
            // Arrange
            IMediaFrame frame = new AudioFrame(2);

            // Act
            byte[] rawData = frame.RawData;

            // Assert
            Assert.NotNull(rawData);
        }

        /// <summary>
        ///     Tests that i media frame raw data should not be null for video frame
        /// </summary>
        [Fact]
        public void IMediaFrame_RawDataShouldNotBeNullForVideoFrame()
        {
            // Arrange
            IMediaFrame frame = new VideoFrame(1920, 1080);

            // Act
            byte[] rawData = frame.RawData;

            // Assert
            Assert.NotNull(rawData);
        }

        /// <summary>
        ///     Tests that i media frame load should work with empty stream for audio frame
        /// </summary>
        [Fact]
        public void IMediaFrame_LoadShouldWorkWithEmptyStreamForAudioFrame()
        {
            // Arrange
            IMediaFrame frame = new AudioFrame(2);
            MemoryStream emptyStream = new MemoryStream();

            // Act
            bool result = frame.Load(emptyStream);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that i media frame load should work with empty stream for video frame
        /// </summary>
        [Fact]
        public void IMediaFrame_LoadShouldWorkWithEmptyStreamForVideoFrame()
        {
            // Arrange
            IMediaFrame frame = new VideoFrame(1920, 1080);
            MemoryStream emptyStream = new MemoryStream();

            // Act
            bool result = frame.Load(emptyStream);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that i media frame load should work with data stream for audio frame
        /// </summary>
        [Fact]
        public void IMediaFrame_LoadShouldWorkWithDataStreamForAudioFrame()
        {
            // Arrange
            IMediaFrame frame = new AudioFrame(2, 100);
            byte[] testData = new byte[400];
            MemoryStream stream = new MemoryStream(testData);

            // Act
            bool result = frame.Load(stream);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that i media frame load should work with data stream for video frame
        /// </summary>
        [Fact]
        public void IMediaFrame_LoadShouldWorkWithDataStreamForVideoFrame()
        {
            // Arrange
            IMediaFrame frame = new VideoFrame(10, 10);
            byte[] testData = new byte[300];
            MemoryStream stream = new MemoryStream(testData);

            // Act
            bool result = frame.Load(stream);

            // Assert
            Assert.True(result);
        }
    }
}