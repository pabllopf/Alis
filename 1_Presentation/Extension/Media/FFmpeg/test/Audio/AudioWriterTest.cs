// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioWriterTest.cs
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
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     The audio writer test class
    /// </summary>
    /// <seealso cref="AudioWriter" />
    public class AudioWriterTest
    {
        /// <summary>
        /// Tests that audio writer file ctor should throw on zero channels
        /// </summary>
        [Fact]
        public void AudioWriter_FileCtor_ShouldThrowOnZeroChannels()
        {
            Assert.Throws<InvalidDataException>(() => new AudioWriter("out.mp3", 0, 44100));
        }

        /// <summary>
        /// Tests that audio writer file ctor should throw on negative channels
        /// </summary>
        [Fact]
        public void AudioWriter_FileCtor_ShouldThrowOnNegativeChannels()
        {
            Assert.Throws<InvalidDataException>(() => new AudioWriter("out.mp3", -1, 44100));
        }

        /// <summary>
        /// Tests that audio writer file ctor should throw on zero sample rate
        /// </summary>
        [Fact]
        public void AudioWriter_FileCtor_ShouldThrowOnZeroSampleRate()
        {
            Assert.Throws<InvalidDataException>(() => new AudioWriter("out.mp3", 2, 0));
        }

        /// <summary>
        /// Tests that audio writer file ctor should throw on negative sample rate
        /// </summary>
        [Fact]
        public void AudioWriter_FileCtor_ShouldThrowOnNegativeSampleRate()
        {
            Assert.Throws<InvalidDataException>(() => new AudioWriter("out.mp3", 2, -1));
        }

        /// <summary>
        /// Tests that audio writer file ctor should throw on invalid bit depth
        /// </summary>
        [Fact]
        public void AudioWriter_FileCtor_ShouldThrowOnInvalidBitDepth()
        {
            Assert.Throws<InvalidOperationException>(() => new AudioWriter("out.mp3", 2, 44100, 8));
        }

        /// <summary>
        /// Tests that audio writer file ctor should throw on null filename
        /// </summary>
        [Fact]
        public void AudioWriter_FileCtor_ShouldThrowOnNullFilename()
        {
            Assert.Throws<ArgumentException>(() => new AudioWriter((string)null, 2, 44100));
        }

        /// <summary>
        /// Tests that audio writer file ctor should throw on empty filename
        /// </summary>
        [Fact]
        public void AudioWriter_FileCtor_ShouldThrowOnEmptyFilename()
        {
            Assert.Throws<ArgumentException>(() => new AudioWriter("", 2, 44100));
        }

        /// <summary>
        /// Tests that audio writer stream ctor should throw on null stream
        /// </summary>
        [Fact]
        public void AudioWriter_StreamCtor_ShouldThrowOnNullStream()
        {
            Assert.Throws<ArgumentNullException>(() => new AudioWriter((Stream)null, 2, 44100));
        }

        /// <summary>
        /// Tests that audio writer stream ctor should throw on zero channels
        /// </summary>
        [Fact]
        public void AudioWriter_StreamCtor_ShouldThrowOnZeroChannels()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidDataException>(() => new AudioWriter(ms, 0, 44100));
            }
        }

        /// <summary>
        /// Tests that audio writer stream ctor should throw on invalid bit depth
        /// </summary>
        [Fact]
        public void AudioWriter_StreamCtor_ShouldThrowOnInvalidBitDepth()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidOperationException>(() => new AudioWriter(ms, 2, 44100, 8));
            }
        }

        /// <summary>
        /// Tests that audio writer close write should throw when not opened
        /// </summary>
        [Fact]
        public void AudioWriter_CloseWrite_ShouldThrowWhenNotOpened()
        {
            AudioWriter writer = new AudioWriter("out.mp3", 2, 44100);

            Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());
        }

        /// <summary>
        /// Tests that audio writer file ctor should set properties
        /// </summary>
        [Fact]
        public void AudioWriter_FileCtor_ShouldSetProperties()
        {
            AudioWriter writer = new AudioWriter("out.mp3", 2, 44100, 16);

            Assert.Equal(2, writer.Channels);
            Assert.Equal(44100, writer.SampleRate);
            Assert.Equal(16, writer.BitDepth);
            Assert.True(writer.UseFilename);
            Assert.NotNull(writer.EncoderOptions);
        }

        /// <summary>
        /// Tests that audio writer stream ctor should set properties
        /// </summary>
        [Fact]
        public void AudioWriter_StreamCtor_ShouldSetProperties()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                AudioWriter writer = new AudioWriter(ms, 2, 44100, 16);

                Assert.Equal(2, writer.Channels);
                Assert.Equal(44100, writer.SampleRate);
                Assert.Equal(16, writer.BitDepth);
                Assert.False(writer.UseFilename);
                Assert.Equal(ms, writer.DestinationStream);
            }
        }

        /// <summary>
        /// Tests that audio writer stream ctor should throw on negative channels
        /// </summary>
        [Fact]
        public void AudioWriter_StreamCtor_ShouldThrowOnNegativeChannels()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidDataException>(() => new AudioWriter(ms, -1, 44100));
            }
        }

        /// <summary>
        /// Tests that audio writer stream ctor should throw on zero sample rate
        /// </summary>
        [Fact]
        public void AudioWriter_StreamCtor_ShouldThrowOnZeroSampleRate()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidDataException>(() => new AudioWriter(ms, 2, 0));
            }
        }
    }
}