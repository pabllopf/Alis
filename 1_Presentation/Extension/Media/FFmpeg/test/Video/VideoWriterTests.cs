// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoWriterTests.cs
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
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    /// The video writer tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoWriterTests : IDisposable
    {
        /// <summary>
        /// The temp dir
        /// </summary>
        private readonly string _tempDir;
        /// <summary>
        /// The fake ffmpeg path
        /// </summary>
        private readonly string _fakeFfmpegPath;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoWriterTests"/> class
        /// </summary>
        public VideoWriterTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath,
                "#!/bin/bash\ncat > /dev/null 2>/dev/null");
            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfmpegPath}\"");
            chmod.WaitForExit();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (Directory.Exists(_tempDir))
                {
                    try { Directory.Delete(_tempDir, recursive: true); } catch { }
                }
            }
        }
        /// <summary>
        /// Tests that file ctor null filename throws argument null exception
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_NullFilename_ThrowsArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new VideoWriter((string)null, 1920, 1080, 30));
            Assert.Contains("Filename can't be null or empty!", ex.Message);
        }

        /// <summary>
        /// Tests that file ctor empty filename throws argument null exception
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_EmptyFilename_ThrowsArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new VideoWriter("", 1920, 1080, 30));
            Assert.Contains("Filename can't be null or empty!", ex.Message);
        }

        /// <summary>
        /// Tests that file ctor zero width throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_ZeroWidth_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 0, 1080, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        /// <summary>
        /// Tests that file ctor negative width throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_NegativeWidth_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", -1, 1080, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        /// <summary>
        /// Tests that file ctor zero height throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_ZeroHeight_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 1920, 0, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        /// <summary>
        /// Tests that file ctor negative height throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_NegativeHeight_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 1920, -1, 30));
            Assert.Contains("dimensions have to be bigger than 0", ex.Message);
        }

        /// <summary>
        /// Tests that file ctor zero framerate throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_ZeroFramerate_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 1920, 1080, 0));
            Assert.Contains("framerate has to be bigger than 0", ex.Message);
        }

        /// <summary>
        /// Tests that file ctor negative framerate throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_NegativeFramerate_ThrowsInvalidDataException()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(
                () => new VideoWriter("out.mp4", 1920, 1080, -1));
            Assert.Contains("framerate has to be bigger than 0", ex.Message);
        }

        /// <summary>
        /// Tests that file ctor valid params sets properties correctly
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_ValidParams_SetsPropertiesCorrectly()
        {
            EncoderOptions customOptions = new EncoderOptions
            {
                Format = "matroska",
                EncoderName = "libx265",
                EncoderArguments = "-preset fast"
            };
            using VideoWriter writer = new VideoWriter("output.mp4", 640, 480, 29.97, customOptions, "my-ffmpeg");

            Assert.Equal("output.mp4", writer.Filename);
            Assert.True(writer.UseFilename);
            Assert.Equal(640, writer.Width);
            Assert.Equal(480, writer.Height);
            Assert.Equal(29.97, writer.Framerate, 5);
            Assert.Equal(customOptions, writer.EncoderOptions);
            Assert.Null(writer.DestinationStream);
            Assert.Null(writer.OutputDataStream);
            Assert.Null(writer.CurrentFFmpegProcess);
        }

        /// <summary>
        /// Tests that file ctor default encoder options creates h 264 encoder
        /// </summary>
        [RequireFfmpegFact]
        public void FileCtor_DefaultEncoderOptions_CreatesH264Encoder()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 1920, 1080, 30);
            Assert.NotNull(writer.EncoderOptions);
            Assert.Equal("mp4", writer.EncoderOptions.Format);
            Assert.Equal("libx264", writer.EncoderOptions.EncoderName);
        }

        /// <summary>
        /// Tests that stream ctor null stream throws argument null exception
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_NullStream_ThrowsArgumentNullException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new VideoWriter((Stream)null, 1920, 1080, 30));
            Assert.Contains("Stream can't be null!", ex.Message);
        }

        /// <summary>
        /// Tests that stream ctor zero width throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_ZeroWidth_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 0, 1080, 30));
        }

        /// <summary>
        /// Tests that stream ctor negative width throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_NegativeWidth_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, -1, 1080, 30));
        }

        /// <summary>
        /// Tests that stream ctor zero height throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_ZeroHeight_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 0, 30));
        }

        /// <summary>
        /// Tests that stream ctor negative height throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_NegativeHeight_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, -1, 30));
        }

        /// <summary>
        /// Tests that stream ctor zero framerate throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_ZeroFramerate_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 1080, 0));
        }

        /// <summary>
        /// Tests that stream ctor negative framerate throws invalid data exception
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_NegativeFramerate_ThrowsInvalidDataException()
        {
            using MemoryStream ms = new MemoryStream();
            Assert.Throws<InvalidDataException>(() => new VideoWriter(ms, 1920, 1080, -1));
        }

        /// <summary>
        /// Tests that stream ctor valid params sets properties correctly
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_ValidParams_SetsPropertiesCorrectly()
        {
            using MemoryStream ms = new MemoryStream();
            EncoderOptions customOptions = new EncoderOptions
            {
                Format = "flv",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };
            using VideoWriter writer = new VideoWriter(ms, 1280, 720, 60, customOptions, "stream-ffmpeg");

            Assert.False(writer.UseFilename);
            Assert.Null(writer.Filename);
            Assert.Equal(1280, writer.Width);
            Assert.Equal(720, writer.Height);
            Assert.Equal(60, writer.Framerate);
            Assert.Equal(customOptions, writer.EncoderOptions);
            Assert.Equal(ms, writer.DestinationStream);
            Assert.Null(writer.OutputDataStream);
            Assert.Null(writer.CurrentFFmpegProcess);
        }

        /// <summary>
        /// Tests that stream ctor default encoder options creates h 264 encoder
        /// </summary>
        [RequireFfmpegFact]
        public void StreamCtor_DefaultEncoderOptions_CreatesH264Encoder()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 1920, 1080, 30);
            Assert.NotNull(writer.EncoderOptions);
            Assert.Equal("mp4", writer.EncoderOptions.Format);
            Assert.Equal("libx264", writer.EncoderOptions.EncoderName);
        }

        /// <summary>
        /// Tests that dispose public method completes without exception
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_PublicMethod_CompletesWithoutException()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that close write not opened throws invalid operation exception
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_NotOpened_ThrowsInvalidOperationException()
        {
            VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Throws<InvalidOperationException>(() => writer.CloseWrite());
            writer.Dispose();
        }

        /// <summary>
        /// Tests that current f fmpeg process returns null initially
        /// </summary>
        [RequireFfmpegFact]
        public void CurrentFFmpegProcess_ReturnsNullInitially()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Null(writer.CurrentFFmpegProcess);
        }

        /// <summary>
        /// Tests that output data stream returns null initially
        /// </summary>
        [RequireFfmpegFact]
        public void OutputDataStream_ReturnsNullInitially()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Null(writer.OutputDataStream);
        }

        /// <summary>
        /// Tests that destination stream file ctor returns null
        /// </summary>
        [RequireFfmpegFact]
        public void DestinationStream_FileCtor_ReturnsNull()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Null(writer.DestinationStream);
        }

        /// <summary>
        /// Tests that destination stream stream ctor returns provided stream
        /// </summary>
        [RequireFfmpegFact]
        public void DestinationStream_StreamCtor_ReturnsProvidedStream()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 640, 480, 30);
            Assert.Equal(ms, writer.DestinationStream);
        }

        /// <summary>
        /// Tests that input data stream default should be null
        /// </summary>
        [RequireFfmpegFact]
        public void InputDataStream_Default_ShouldBeNull()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.Null(writer.InputDataStream);
        }

        /// <summary>
        /// Tests that opened for writing default should be false
        /// </summary>
        [RequireFfmpegFact]
        public void OpenedForWriting_Default_ShouldBeFalse()
        {
            using VideoWriter writer = new VideoWriter("out.mp4", 640, 480, 30);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that filename default should be null
        /// </summary>
        [RequireFfmpegFact]
        public void Filename_Default_ShouldBeNull()
        {
            using MemoryStream ms = new MemoryStream();
            using VideoWriter writer = new VideoWriter(ms, 640, 480, 30);
            Assert.Null(writer.Filename);
        }

        /// <summary>
        /// Tests that open write file mode opens and sets input stream
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_FileMode_OpensAndSetsInputStream()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());
            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStream);
            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that open write file mode with existing file deletes file first
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_FileMode_WithExistingFile_DeletesFileFirst()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            File.WriteAllText(testFile, "dummy content");
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);

            writer.OpenWrite();
            Assert.False(File.Exists(testFile));
            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that open write file mode with show f fmpeg output works
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_FileMode_WithShowFFmpegOutput_Works()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite(showFFmpegOutput: true));
            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that open write stream mode opens and sets streams
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_StreamMode_OpensAndSetsStreams()
        {
            using MemoryStream dest = new MemoryStream();
            using VideoWriter writer = new VideoWriter(dest, 640, 480, 30, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());
            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            Assert.NotNull(writer.CurrentFFmpegProcess);
            Assert.NotNull(writer.InputDataStream);
            Assert.NotNull(writer.OutputDataStream);
            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that dispose with opened for writing calls close write
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithOpenedForWriting_CallsCloseWrite()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);
            writer.OpenWrite();

            writer.Dispose();
            Assert.False(writer.OpenedForWriting);
        }
    }
}
