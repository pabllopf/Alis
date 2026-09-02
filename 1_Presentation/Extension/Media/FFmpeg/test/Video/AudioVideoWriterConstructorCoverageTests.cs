// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriterConstructorCoverageTests.cs
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
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    ///     The audio video writer constructor coverage tests class
    /// </summary>
    public class AudioVideoWriterConstructorCoverageTests
    {
        /// <summary>
        ///     Tests the file constructor throws invalid data when the video width is zero
        /// </summary>
        [Fact]
        public void FileCtor_ZeroVideoWidth_ThrowsInvalidData()
        {
            Assert.Throws<InvalidDataException>(() => new AudioVideoWriter("out.avi", 0, 1080, 30.0, 2, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the file constructor throws invalid data when the video height is zero
        /// </summary>
        [Fact]
        public void FileCtor_ZeroVideoHeight_ThrowsInvalidData()
        {
            Assert.Throws<InvalidDataException>(() => new AudioVideoWriter("out.avi", 1920, 0, 30.0, 2, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the file constructor throws invalid data when the video framerate is zero
        /// </summary>
        [Fact]
        public void FileCtor_ZeroVideoFramerate_ThrowsInvalidData()
        {
            Assert.Throws<InvalidDataException>(() => new AudioVideoWriter("out.avi", 1920, 1080, 0.0, 2, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the file constructor throws argument when the filename is empty
        /// </summary>
        [Fact]
        public void FileCtor_EmptyFilename_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new AudioVideoWriter("", 1920, 1080, 30.0, 2, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the file constructor throws argument when the filename is null
        /// </summary>
        [Fact]
        public void FileCtor_NullFilename_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new AudioVideoWriter((string)null, 1920, 1080, 30.0, 2, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the file constructor throws invalid data when the audio channels are zero
        /// </summary>
        [Fact]
        public void FileCtor_ZeroAudioChannels_ThrowsInvalidData()
        {
            Assert.Throws<InvalidDataException>(() => new AudioVideoWriter("out.avi", 1920, 1080, 30.0, 0, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the file constructor throws invalid data when the audio sample rate is zero
        /// </summary>
        [Fact]
        public void FileCtor_ZeroAudioSampleRate_ThrowsInvalidData()
        {
            Assert.Throws<InvalidDataException>(() => new AudioVideoWriter("out.avi", 1920, 1080, 30.0, 2, 0, 16, null, null));
        }

        /// <summary>
        ///     Tests the file constructor throws invalid operation when the audio bit depth is not supported
        /// </summary>
        [Fact]
        public void FileCtor_UnsupportedAudioBitDepth_ThrowsInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() => new AudioVideoWriter("out.avi", 1920, 1080, 30.0, 2, 44100, 20, null, null));
        }

        /// <summary>
        ///     Tests the file constructor builds a valid writer for valid arguments
        /// </summary>
        [Fact]
        public void FileCtor_ValidArguments_ConstructsWriter()
        {
            using AudioVideoWriter writer = new AudioVideoWriter("out.avi", 1920, 1080, 30.0, 2, 44100, 16, null, null);
            Assert.Equal("out.avi", writer.Filename);
            Assert.True(writer.UseFilename);
            Assert.Equal(1920, writer.VideoWidth);
            Assert.Equal(1080, writer.VideoHeight);
            Assert.True(writer.UseFilename);
            writer.Dispose();
        }

        /// <summary>
        ///     Tests the stream constructor throws invalid data when the video width is zero
        /// </summary>
        [Fact]
        public void StreamCtor_ZeroVideoWidth_ThrowsInvalidData()
        {
            Assert.Throws<InvalidDataException>(() => new AudioVideoWriter(new MemoryStream(), 0, 1080, 30.0, 2, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the stream constructor throws invalid data when the video framerate is zero
        /// </summary>
        [Fact]
        public void StreamCtor_ZeroVideoFramerate_ThrowsInvalidData()
        {
            Assert.Throws<InvalidDataException>(() => new AudioVideoWriter(new MemoryStream(), 1920, 1080, 0.0, 2, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the stream constructor throws invalid data when the audio channels are zero
        /// </summary>
        [Fact]
        public void StreamCtor_ZeroAudioChannels_ThrowsInvalidData()
        {
            Assert.Throws<InvalidDataException>(() => new AudioVideoWriter(new MemoryStream(), 1920, 1080, 30.0, 0, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the stream constructor throws invalid operation when the audio bit depth is not supported
        /// </summary>
        [Fact]
        public void StreamCtor_UnsupportedAudioBitDepth_ThrowsInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() => new AudioVideoWriter(new MemoryStream(), 1920, 1080, 30.0, 2, 44100, 20, null, null));
        }

        /// <summary>
        ///     Tests the stream constructor throws argument null when the output stream is null
        /// </summary>
        [Fact]
        public void StreamCtor_NullOutputStream_ThrowsArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new AudioVideoWriter((Stream)null, 1920, 1080, 30.0, 2, 44100, 16, null, null));
        }

        /// <summary>
        ///     Tests the stream constructor builds a valid writer for valid arguments
        /// </summary>
        [Fact]
        public void StreamCtor_ValidArguments_ConstructsWriter()
        {
            using MemoryStream ms = new MemoryStream();
            using AudioVideoWriter writer = new AudioVideoWriter(ms, 1920, 1080, 30.0, 2, 44100, 16, null, null);
            Assert.False(writer.UseFilename);
            Assert.Equal(1920, writer.VideoWidth);
            Assert.Equal(1080, writer.VideoHeight);
            Assert.Equal(2, writer.AudioChannels);
            Assert.Equal(44100, writer.AudioSampleRate);
            Assert.Equal(16, writer.AudioBitDepth);
        }
    }
}