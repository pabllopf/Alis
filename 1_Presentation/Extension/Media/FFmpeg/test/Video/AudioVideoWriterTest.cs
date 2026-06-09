// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriterTest.cs
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
    /// The audio video writer test class
    /// </summary>
    public class AudioVideoWriterTest
    {
        /// <summary>
        /// Gets the value of the default video options
        /// </summary>
        private static EncoderOptions DefaultVideoOptions => new EncoderOptions { Format = "mp4", EncoderName = "libx264", EncoderArguments = "-crf 23" };
        /// <summary>
        /// Gets the value of the default audio options
        /// </summary>
        private static EncoderOptions DefaultAudioOptions => new EncoderOptions { Format = "mp4", EncoderName = "aac", EncoderArguments = "-b:a 128k" };

        /// <summary>
        /// Tests that audio video writer file ctor should throw on zero video width
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnZeroVideoWidth()
        {
            Assert.Throws<InvalidDataException>(() =>
                new AudioVideoWriter("out.mp4", 0, 1080, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on negative video width
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnNegativeVideoWidth()
        {
            Assert.Throws<InvalidDataException>(() =>
                new AudioVideoWriter("out.mp4", -1, 1080, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on zero video height
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnZeroVideoHeight()
        {
            Assert.Throws<InvalidDataException>(() =>
                new AudioVideoWriter("out.mp4", 1920, 0, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on negative video height
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnNegativeVideoHeight()
        {
            Assert.Throws<InvalidDataException>(() =>
                new AudioVideoWriter("out.mp4", 1920, -1, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on zero video framerate
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnZeroVideoFramerate()
        {
            Assert.Throws<InvalidDataException>(() =>
                new AudioVideoWriter("out.mp4", 1920, 1080, 0, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on negative video framerate
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnNegativeVideoFramerate()
        {
            Assert.Throws<InvalidDataException>(() =>
                new AudioVideoWriter("out.mp4", 1920, 1080, -1, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on empty filename
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnEmptyFilename()
        {
            Assert.Throws<ArgumentException>(() =>
                new AudioVideoWriter("", 1920, 1080, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on null filename
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnNullFilename()
        {
            Assert.Throws<ArgumentException>(() =>
                new AudioVideoWriter((string)null, 1920, 1080, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on zero audio channels
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnZeroAudioChannels()
        {
            Assert.Throws<InvalidDataException>(() =>
                new AudioVideoWriter("out.mp4", 1920, 1080, 30, 0, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on zero audio sample rate
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnZeroAudioSampleRate()
        {
            Assert.Throws<InvalidDataException>(() =>
                new AudioVideoWriter("out.mp4", 1920, 1080, 30, 2, 0, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer file ctor should throw on invalid audio bit depth
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldThrowOnInvalidAudioBitDepth()
        {
            Assert.Throws<InvalidOperationException>(() =>
                new AudioVideoWriter("out.mp4", 1920, 1080, 30, 2, 44100, 8, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer stream ctor should throw on null stream
        /// </summary>
        [Fact]
        public void AudioVideoWriter_StreamCtor_ShouldThrowOnNullStream()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new AudioVideoWriter((Stream)null, 1920, 1080, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
        }

        /// <summary>
        /// Tests that audio video writer stream ctor should throw on zero width
        /// </summary>
        [Fact]
        public void AudioVideoWriter_StreamCtor_ShouldThrowOnZeroWidth()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidDataException>(() =>
                    new AudioVideoWriter(ms, 0, 1080, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions));
            }
        }

        /// <summary>
        /// Tests that audio video writer stream ctor should throw on invalid bit depth
        /// </summary>
        [Fact]
        public void AudioVideoWriter_StreamCtor_ShouldThrowOnInvalidBitDepth()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    new AudioVideoWriter(ms, 1920, 1080, 30, 2, 44100, 8, DefaultVideoOptions, DefaultAudioOptions));
            }
        }

        /// <summary>
        /// Tests that audio video writer close write should throw when not opened
        /// </summary>
        [Fact]
        public void AudioVideoWriter_CloseWrite_ShouldThrowWhenNotOpened()
        {
            AudioVideoWriter writer = new AudioVideoWriter("out.mp4", 1920, 1080, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions);

            Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());
        }

        /// <summary>
        /// Tests that audio video writer file ctor should set properties
        /// </summary>
        [Fact]
        public void AudioVideoWriter_FileCtor_ShouldSetProperties()
        {
            AudioVideoWriter writer = new AudioVideoWriter("out.mp4", 1920, 1080, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions);

            Assert.Equal(1920, writer.VideoWidth);
            Assert.Equal(1080, writer.VideoHeight);
            Assert.Equal(30, writer.VideoFramerate);
            Assert.Equal(2, writer.AudioChannels);
            Assert.Equal(44100, writer.AudioSampleRate);
            Assert.Equal(16, writer.AudioBitDepth);
            Assert.True(writer.UseFilename);
            Assert.Equal("out.mp4", writer.Filename);
        }

        /// <summary>
        /// Tests that audio video writer stream ctor should set properties
        /// </summary>
        [Fact]
        public void AudioVideoWriter_StreamCtor_ShouldSetProperties()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                AudioVideoWriter writer = new AudioVideoWriter(ms, 1920, 1080, 30, 2, 44100, 16, DefaultVideoOptions, DefaultAudioOptions);

                Assert.Equal(1920, writer.VideoWidth);
                Assert.Equal(1080, writer.VideoHeight);
                Assert.False(writer.UseFilename);
                Assert.Equal(ms, writer.DestinationStream);
            }
        }
    }
}
