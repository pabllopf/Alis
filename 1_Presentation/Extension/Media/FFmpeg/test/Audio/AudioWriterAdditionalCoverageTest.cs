using System;
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    /// The audio writer additional coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioWriterAdditionalCoverageTest : IDisposable
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
        /// Initializes a new instance of the <see cref="AudioWriterAdditionalCoverageTest"/> class
        /// </summary>
        public AudioWriterAdditionalCoverageTest()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfmpegPath = Path.Combine(_tempDir, "ffmpeg");
            File.WriteAllText(_fakeFfmpegPath,
                "#!/bin/bash\nwhile [ \"$1\" ]; do shift; done\nexec sleep 10");
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
        /// Tests that close write when ffmpegp still running kills process
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WhenFfmpegpStillRunning_KillsProcess()
        {
            string testFile = Path.Combine(_tempDir, Guid.NewGuid() + ".mp3");
            using AudioWriter writer = new AudioWriter(testFile, 2, 44100, 16, null, _fakeFfmpegPath);

            writer.OpenWrite();

            Process process = writer.CurrentFFmpegProcess;
            Assert.NotNull(process);
            Assert.False(process.HasExited);

            writer.CloseWrite();

            process.WaitForExit(5000);
            Assert.True(process.HasExited);
            Assert.False(writer.OpenedForWriting);
        }
    }
}
