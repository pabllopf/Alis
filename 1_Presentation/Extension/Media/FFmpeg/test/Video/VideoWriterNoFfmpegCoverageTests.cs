// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoWriterNoFfmpegCoverageTests.cs
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
    ///     Coverage tests for VideoWriter that do not require FFmpeg/avformat.
    /// </summary>
    public class VideoWriterNoFfmpegCoverageTests : IDisposable
    {
        /// <summary>
        ///     The temp file path
        /// </summary>
        private readonly string _tempFile;

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoWriterNoFfmpegCoverageTests"/> class
        /// </summary>
        public VideoWriterNoFfmpegCoverageTests()
        {
            _tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".mp4");
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (File.Exists(_tempFile))
            {
                try { File.Delete(_tempFile); } catch { }
            }
        }

        /// <summary>
        ///     Tests that file constructor throws ArgumentNullException when filename is null
        /// </summary>
        [Fact]
        public void FileCtor_NullFilename_ThrowsArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new VideoWriter((string)null, 1920, 1080, 30));
            Assert.Contains("Filename can't be null or empty!", ex.Message);
        }

        /// <summary>
        ///     Tests that file constructor throws ArgumentNullException when filename is empty
        /// </summary>
        [Fact]
        public void FileCtor_EmptyFilename_ThrowsArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new VideoWriter("", 1920, 1080, 30));
            Assert.Contains("Filename can't be null or empty!", ex.Message);
        }

        /// <summary>
        ///     Tests that file constructor throws InvalidDataException when width is zero
        /// </summary>
        [Fact]
        public void FileCtor_ZeroWidth_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter(_tempFile, 0, 1080, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that file constructor throws InvalidDataException when width is negative
        /// </summary>
        [Fact]
        public void FileCtor_NegativeWidth_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter(_tempFile, -1, 1080, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that file constructor throws InvalidDataException when height is zero
        /// </summary>
        [Fact]
        public void FileCtor_ZeroHeight_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter(_tempFile, 1920, 0, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that file constructor throws InvalidDataException when height is negative
        /// </summary>
        [Fact]
        public void FileCtor_NegativeHeight_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter(_tempFile, 1920, -1, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that file constructor throws InvalidDataException when framerate is zero
        /// </summary>
        [Fact]
        public void FileCtor_ZeroFramerate_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter(_tempFile, 1920, 1080, 0));
            Assert.Contains("framerate has to be bigger than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that file constructor throws InvalidDataException when framerate is negative
        /// </summary>
        [Fact]
        public void FileCtor_NegativeFramerate_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter(_tempFile, 1920, 1080, -1));
            Assert.Contains("framerate has to be bigger than 0", ex.Message);
        }

        /// <summary>
        ///     Tests that file constructor sets properties correctly with valid parameters
        /// </summary>
        [Fact]
        public void FileCtor_ValidParams_SetsPropertiesCorrectly()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 640, 480, 29.97);

            Assert.True(writer.UseFilename);
            Assert.Equal(_tempFile, writer.Filename);
            Assert.Equal(640, writer.Width);
            Assert.Equal(480, writer.Height);
            Assert.Equal(29.97, writer.Framerate, 5);
            Assert.Null(writer.DestinationStream);
            Assert.Null(writer.OutputDataStream);
            Assert.Null(writer.CurrentFFmpegProcess);
            Assert.Null(writer.InputDataStream);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that file constructor with custom encoder options uses provided options
        /// </summary>
        [Fact]
        public void FileCtor_WithCustomEncoderOptions_UsesProvidedOptions()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "matroska",
                EncoderName = "libx265",
                EncoderArguments = "-preset fast"
            };

            using VideoWriter writer = new VideoWriter(_tempFile, 640, 480, 30, options);

            Assert.Equal("matroska", writer.EncoderOptions.Format);
            Assert.Equal("libx265", writer.EncoderOptions.EncoderName);
            Assert.Equal("-preset fast", writer.EncoderOptions.EncoderArguments);
        }

        /// <summary>
        ///     Tests that file constructor with default encoder options creates H264 encoder
        /// </summary>
        [Fact]
        public void FileCtor_DefaultEncoderOptions_CreatesH264Encoder()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 1920, 1080, 30);

            Assert.NotNull(writer.EncoderOptions);
            Assert.Equal("mp4", writer.EncoderOptions.Format);
            Assert.Equal("libx264", writer.EncoderOptions.EncoderName);
        }

        /// <summary>
        ///     Tests that stream constructor throws ArgumentNullException when stream is null
        /// </summary>
        [Fact]
        public void StreamCtor_NullStream_ThrowsArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new VideoWriter((Stream)null, 1920, 1080, 30));
            Assert.Contains("Stream can't be null!", ex.Message);
        }

        /// <summary>
        ///     Tests that stream constructor throws InvalidDataException when width is zero
        /// </summary>
        [Fact]
        public void StreamCtor_ZeroWidth_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 0, 1080, 30));
        }

        /// <summary>
        ///     Tests that stream constructor throws InvalidDataException when width is negative
        /// </summary>
        [Fact]
        public void StreamCtor_NegativeWidth_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, -1, 1080, 30));
        }

        /// <summary>
        ///     Tests that stream constructor throws InvalidDataException when height is zero
        /// </summary>
        [Fact]
        public void StreamCtor_ZeroHeight_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 0, 30));
        }

        /// <summary>
        ///     Tests that stream constructor throws InvalidDataException when height is negative
        /// </summary>
        [Fact]
        public void StreamCtor_NegativeHeight_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, -1, 30));
        }

        /// <summary>
        ///     Tests that stream constructor throws InvalidDataException when framerate is zero
        /// </summary>
        [Fact]
        public void StreamCtor_ZeroFramerate_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 1080, 0));
        }

        /// <summary>
        ///     Tests that stream constructor throws InvalidDataException when framerate is negative
        /// </summary>
        [Fact]
        public void StreamCtor_NegativeFramerate_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 1080, -1));
        }

        /// <summary>
        ///     Tests that stream constructor sets properties correctly with valid parameters
        /// </summary>
        [Fact]
        public void StreamCtor_ValidParams_SetsPropertiesCorrectly()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 1280, 720, 60);

            Assert.False(writer.UseFilename);
            Assert.Null(writer.Filename);
            Assert.Equal(1280, writer.Width);
            Assert.Equal(720, writer.Height);
            Assert.Equal(60, writer.Framerate);
            Assert.Equal(ms, writer.DestinationStream);
            Assert.Null(writer.OutputDataStream);
            Assert.Null(writer.CurrentFFmpegProcess);
            Assert.Null(writer.InputDataStream);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that stream constructor with custom encoder options uses provided options
        /// </summary>
        [Fact]
        public void StreamCtor_WithCustomEncoderOptions_UsesProvidedOptions()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "flv",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 1280, 720, 60, options);

            Assert.Equal("flv", writer.EncoderOptions.Format);
            Assert.Equal("libx264", writer.EncoderOptions.EncoderName);
            Assert.Equal("-crf 23", writer.EncoderOptions.EncoderArguments);
        }

        /// <summary>
        ///     Tests that stream constructor with default encoder options creates H264 encoder
        /// </summary>
        [Fact]
        public void StreamCtor_DefaultEncoderOptions_CreatesH264Encoder()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 1920, 1080, 30);

            Assert.NotNull(writer.EncoderOptions);
            Assert.Equal("mp4", writer.EncoderOptions.Format);
            Assert.Equal("libx264", writer.EncoderOptions.EncoderName);
        }

        /// <summary>
        ///     Tests that CloseWrite throws InvalidOperationException when not opened
        /// </summary>
        [Fact]
        public void CloseWrite_NotOpened_ThrowsInvalidOperationException()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 640, 480, 30);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());
            Assert.Contains("not opened for writing", ex.Message);
        }

        /// <summary>
        ///     Tests that Dispose completes without exception
        /// </summary>
        [Fact]
        public void Dispose_CompletesWithoutException()
        {
            VideoWriter writer = new VideoWriter(_tempFile, 640, 480, 30);
            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that Dispose can be called multiple times
        /// </summary>
        [Fact]
        public void Dispose_CalledMultipleTimes_DoesNotThrow()
        {
            VideoWriter writer = new VideoWriter(_tempFile, 640, 480, 30);
            writer.Dispose();
            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that Dispose with stream disposes the destination stream
        /// </summary>
        [Fact]
        public void Dispose_WithStream_DisposesDestinationStream()
        {
            MemoryStream dest = new MemoryStream();
            VideoWriter writer = new VideoWriter(dest, 640, 480, 30);

            writer.Dispose();

            Assert.Throws<ObjectDisposedException>(() => dest.WriteByte(0));
        }

        /// <summary>
        ///     Tests that file constructor with custom ffmpeg executable sets the ffmpeg field
        /// </summary>
        [Fact]
        public void FileCtor_WithCustomFfmpeg_SetsExecutable()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 640, 480, 30, null, "custom-ffmpeg");

            System.Reflection.FieldInfo field = typeof(VideoWriter).GetField("ffmpeg",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(field);
            Assert.Equal("custom-ffmpeg", field.GetValue(writer));
        }

        /// <summary>
        ///     Tests that stream constructor with custom ffmpeg executable sets the ffmpeg field
        /// </summary>
        [Fact]
        public void StreamCtor_WithCustomFfmpeg_SetsExecutable()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 640, 480, 30, null, "stream-ffmpeg");

            System.Reflection.FieldInfo field = typeof(VideoWriter).GetField("ffmpeg",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(field);
            Assert.Equal("stream-ffmpeg", field.GetValue(writer));
        }

        /// <summary>
        ///     Tests that Width property returns the value set by the file constructor
        /// </summary>
        [Fact]
        public void Width_FileCtor_ReturnsSetValue()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.Equal(320, writer.Width);
        }

        /// <summary>
        ///     Tests that Height property returns the value set by the file constructor
        /// </summary>
        [Fact]
        public void Height_FileCtor_ReturnsSetValue()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.Equal(240, writer.Height);
        }

        /// <summary>
        ///     Tests that Framerate property returns the value set by the file constructor
        /// </summary>
        [Fact]
        public void Framerate_FileCtor_ReturnsSetValue()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.Equal(15, writer.Framerate);
        }

        /// <summary>
        ///     Tests that UseFilename property is true for file constructor
        /// </summary>
        [Fact]
        public void UseFilename_FileCtor_ReturnsTrue()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.True(writer.UseFilename);
        }

        /// <summary>
        ///     Tests that UseFilename property is false for stream constructor
        /// </summary>
        [Fact]
        public void UseFilename_StreamCtor_ReturnsFalse()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 320, 240, 15);
            Assert.False(writer.UseFilename);
        }

        /// <summary>
        ///     Tests that Filename property is set by file constructor
        /// </summary>
        [Fact]
        public void Filename_FileCtor_ReturnsSetValue()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.Equal(_tempFile, writer.Filename);
        }

        /// <summary>
        ///     Tests that Filename property is null for stream constructor
        /// </summary>
        [Fact]
        public void Filename_StreamCtor_ReturnsNull()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 320, 240, 15);
            Assert.Null(writer.Filename);
        }

        /// <summary>
        ///     Tests that DestinationStream is null for file constructor
        /// </summary>
        [Fact]
        public void DestinationStream_FileCtor_ReturnsNull()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.Null(writer.DestinationStream);
        }

        /// <summary>
        ///     Tests that DestinationStream returns the provided stream for stream constructor
        /// </summary>
        [Fact]
        public void DestinationStream_StreamCtor_ReturnsProvidedStream()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 320, 240, 15);
            Assert.Equal(ms, writer.DestinationStream);
        }

        /// <summary>
        ///     Tests that OutputDataStream is null initially for file constructor
        /// </summary>
        [Fact]
        public void OutputDataStream_FileCtor_ReturnsNull()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.Null(writer.OutputDataStream);
        }

        /// <summary>
        ///     Tests that OutputDataStream is null initially for stream constructor
        /// </summary>
        [Fact]
        public void OutputDataStream_StreamCtor_ReturnsNull()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 320, 240, 15);
            Assert.Null(writer.OutputDataStream);
        }

        /// <summary>
        ///     Tests that CurrentFFmpegProcess is null initially
        /// </summary>
        [Fact]
        public void CurrentFFmpegProcess_FileCtor_ReturnsNull()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.Null(writer.CurrentFFmpegProcess);
        }

        /// <summary>
        ///     Tests that CurrentFFmpegProcess is null initially for stream constructor
        /// </summary>
        [Fact]
        public void CurrentFFmpegProcess_StreamCtor_ReturnsNull()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 320, 240, 15);
            Assert.Null(writer.CurrentFFmpegProcess);
        }

        /// <summary>
        ///     Tests that InputDataStream is null initially for file constructor
        /// </summary>
        [Fact]
        public void InputDataStream_FileCtor_ReturnsNull()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.Null(writer.InputDataStream);
        }

        /// <summary>
        ///     Tests that InputDataStream is null initially for stream constructor
        /// </summary>
        [Fact]
        public void InputDataStream_StreamCtor_ReturnsNull()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 320, 240, 15);
            Assert.Null(writer.InputDataStream);
        }

        /// <summary>
        ///     Tests that OpenedForWriting is false initially for file constructor
        /// </summary>
        [Fact]
        public void OpenedForWriting_FileCtor_ReturnsFalse()
        {
            using VideoWriter writer = new VideoWriter(_tempFile, 320, 240, 15);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        ///     Tests that OpenedForWriting is false initially for stream constructor
        /// </summary>
        [Fact]
        public void OpenedForWriting_StreamCtor_ReturnsFalse()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 320, 240, 15);
            Assert.False(writer.OpenedForWriting);
        }
    }
}
