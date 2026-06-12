// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoWriterTest.cs
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
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The video writer test class
    /// </summary>
    /// <seealso cref="VideoWriter" />
    public class VideoWriterTest
    {
        /// <summary>
        /// Tests that video writer file ctor should throw on null filename
        /// </summary>
        [Fact]
        public void VideoWriter_FileCtor_ShouldThrowOnNullFilename()
        {
            Assert.Throws<ArgumentNullException>(() => new VideoWriter((string)null, 1920, 1080, 30));
        }

        /// <summary>
        /// Tests that video writer file ctor should throw on empty filename
        /// </summary>
        [Fact]
        public void VideoWriter_FileCtor_ShouldThrowOnEmptyFilename()
        {
            Assert.Throws<ArgumentNullException>(() => new VideoWriter("", 1920, 1080, 30));
        }

        /// <summary>
        /// Tests that video writer file ctor should throw on zero width
        /// </summary>
        [Fact]
        public void VideoWriter_FileCtor_ShouldThrowOnZeroWidth()
        {
            Assert.Throws<InvalidDataException>(() => new VideoWriter("out.mp4", 0, 1080, 30));
        }

        /// <summary>
        /// Tests that video writer file ctor should throw on negative width
        /// </summary>
        [Fact]
        public void VideoWriter_FileCtor_ShouldThrowOnNegativeWidth()
        {
            Assert.Throws<InvalidDataException>(() => new VideoWriter("out.mp4", -1, 1080, 30));
        }

        /// <summary>
        /// Tests that video writer file ctor should throw on zero height
        /// </summary>
        [Fact]
        public void VideoWriter_FileCtor_ShouldThrowOnZeroHeight()
        {
            Assert.Throws<InvalidDataException>(() => new VideoWriter("out.mp4", 1920, 0, 30));
        }

        /// <summary>
        /// Tests that video writer file ctor should throw on negative height
        /// </summary>
        [Fact]
        public void VideoWriter_FileCtor_ShouldThrowOnNegativeHeight()
        {
            Assert.Throws<InvalidDataException>(() => new VideoWriter("out.mp4", 1920, -1, 30));
        }

        /// <summary>
        /// Tests that video writer file ctor should throw on zero framerate
        /// </summary>
        [Fact]
        public void VideoWriter_FileCtor_ShouldThrowOnZeroFramerate()
        {
            Assert.Throws<InvalidDataException>(() => new VideoWriter("out.mp4", 1920, 1080, 0));
        }

        /// <summary>
        /// Tests that video writer file ctor should throw on negative framerate
        /// </summary>
        [Fact]
        public void VideoWriter_FileCtor_ShouldThrowOnNegativeFramerate()
        {
            Assert.Throws<InvalidDataException>(() => new VideoWriter("out.mp4", 1920, 1080, -1));
        }

        /// <summary>
        /// Tests that video writer stream ctor should throw on null stream
        /// </summary>
        [Fact]
        public void VideoWriter_StreamCtor_ShouldThrowOnNullStream()
        {
            Assert.Throws<ArgumentNullException>(() => new VideoWriter((Stream)null, 1920, 1080, 30));
        }

        /// <summary>
        /// Tests that video writer stream ctor should throw on zero width
        /// </summary>
        [Fact]
        public void VideoWriter_StreamCtor_ShouldThrowOnZeroWidth()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 0, 1080, 30));
            }
        }

        /// <summary>
        /// Tests that video writer stream ctor should throw on negative width
        /// </summary>
        [Fact]
        public void VideoWriter_StreamCtor_ShouldThrowOnNegativeWidth()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, -1, 1080, 30));
            }
        }

        /// <summary>
        /// Tests that video writer stream ctor should throw on zero height
        /// </summary>
        [Fact]
        public void VideoWriter_StreamCtor_ShouldThrowOnZeroHeight()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 0, 30));
            }
        }

        /// <summary>
        /// Tests that video writer stream ctor should throw on zero framerate
        /// </summary>
        [Fact]
        public void VideoWriter_StreamCtor_ShouldThrowOnZeroFramerate()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 1080, 0));
            }
        }

        /// <summary>
        /// Tests that video writer close write should throw when not opened
        /// </summary>
        [Fact]
        public void VideoWriter_CloseWrite_ShouldThrowWhenNotOpened()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 1920, 1080, 30);

            Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());
        }

        /// <summary>
        /// Tests that video writer file ctor should create with default encoder options
        /// </summary>
        [Fact]
        public void VideoWriter_FileCtor_ShouldCreateWithDefaultEncoderOptions()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 1920, 1080, 30);

            Assert.NotNull(writer.EncoderOptions);
            Assert.True(writer.UseFilename);
            Assert.Equal(1920, writer.Width);
            Assert.Equal(1080, writer.Height);
            Assert.Equal(30, writer.Framerate);
        }

        /// <summary>
        /// Tests that video writer stream ctor should create with default encoder options
        /// </summary>
        [Fact]
        public void VideoWriter_StreamCtor_ShouldCreateWithDefaultEncoderOptions()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                VideoWriter writer = new VideoWriter(ms, 1920, 1080, 30);

                Assert.NotNull(writer.EncoderOptions);
                Assert.False(writer.UseFilename);
                Assert.Equal(ms, writer.DestinationStream);
            }
        }
    }
}