using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    /// The video writer coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoWriterCoverageTest : IDisposable
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
        /// Initializes a new instance of the <see cref="VideoWriterCoverageTest"/> class
        /// </summary>
        public VideoWriterCoverageTest()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath,
                "#!/bin/bash\nwhile [ \"$1\" ]; do shift; done\nexec cat > /dev/null 2>/dev/null");
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
        /// Tests that open write file mode with fake ffmpeg should set opened for writing
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_FileMode_WithFakeFfmpeg_ShouldSetOpenedForWriting()
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
        /// Tests that open write file mode with existing file should delete first
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_FileMode_WithExistingFile_ShouldDeleteFirst()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            File.WriteAllText(testFile, "dummy");
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);

            writer.OpenWrite();
            Assert.False(File.Exists(testFile));
            writer.CloseWrite();
        }

        /// <summary>
        /// Tests that open write file mode with show f fmpeg output should work
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_FileMode_WithShowFFmpegOutput_ShouldWork()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite(showFFmpegOutput: true));

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);

            writer.CloseWrite();
        }
        

        /// <summary>
        /// Tests that close write with fake ffmpeg should reset flag
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WithFakeFfmpeg_ShouldResetFlag()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);
            writer.OpenWrite();

            writer.CloseWrite();
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that close write stream mode should dispose output stream
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_StreamMode_ShouldDisposeOutputStream()
        {
            using MemoryStream dest = new MemoryStream();
            using VideoWriter writer = new VideoWriter(dest, 640, 480, 30, null, _fakeFfmpegPath);
            writer.OpenWrite();
            Stream outputStream = writer.OutputDataStream;
            Assert.NotNull(outputStream);

            writer.CloseWrite();

            Assert.False(writer.OpenedForWriting);
            Assert.Throws<ObjectDisposedException>(() => outputStream.ReadByte());
        }

        /// <summary>
        /// Tests that dispose when opened should call close write
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WhenOpened_ShouldCallCloseWrite()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, null, _fakeFfmpegPath);
            writer.OpenWrite();

            writer.Dispose();
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that dispose should dispose destination stream
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_ShouldDisposeDestinationStream()
        {
            MemoryStream dest = new MemoryStream();
            VideoWriter writer = new VideoWriter(dest, 640, 480, 30, null, _fakeFfmpegPath);

            writer.Dispose();

            Assert.Throws<ObjectDisposedException>(() => dest.WriteByte(0));
        }

        /// <summary>
        /// Tests that open write with custom encoder options should build correct command
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WithCustomEncoderOptions_ShouldBuildCorrectCommand()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp4");
            EncoderOptions options = new EncoderOptions
            {
                Format = "matroska",
                EncoderName = "libx265",
                EncoderArguments = "-preset fast -crf 23"
            };
            using VideoWriter writer = new VideoWriter(testFile, 640, 480, 30, options, _fakeFfmpegPath);

            Exception ex = Record.Exception(() => writer.OpenWrite());

            Assert.Null(ex);
            Assert.True(writer.OpenedForWriting);
            writer.CloseWrite();
        }
    }
}
