using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    /// The audio video writer full coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioVideoWriterFullCoverageTest : IDisposable
    {
        /// <summary>
        /// The temp file
        /// </summary>
        private readonly string _tempFile;
        /// <summary>
        /// The test stream
        /// </summary>
        private readonly MemoryStream _testStream;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioVideoWriterFullCoverageTest"/> class
        /// </summary>
        public AudioVideoWriterFullCoverageTest()
        {
            _tempFile = Path.GetTempFileName();
            _testStream = new MemoryStream();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (!string.IsNullOrEmpty(_tempFile) && File.Exists(_tempFile))
                    File.Delete(_tempFile);
                _testStream?.Dispose();
            }
        }

        /// <summary>
        /// Creates the exited process
        /// </summary>
        /// <returns>The </returns>
        private static Process CreateExitedProcess()
        {
            Process p = new Process();
            p.StartInfo.FileName = "dotnet";
            p.StartInfo.Arguments = "--version";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();
            return p;
        }

        /// <summary>
        /// Tests that close write with null ffmpegp should throw null ref
        /// </summary>
        [Fact]
        public void CloseWrite_WithNullFfmpegp_ShouldThrowNullRef()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_tempFile, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            Exception ex = Record.Exception(() => writer.CloseWrite());

            Assert.NotNull(ex);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that dispose with opened for writing should complete
        /// </summary>
        [Fact]
        public void Dispose_WithOpenedForWriting_ShouldComplete()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            Process process = CreateExitedProcess();
            FieldInfo processField = typeof(AudioVideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            processField.SetValue(writer, process);

            FieldInfo cscField = typeof(AudioVideoWriter).GetField("csc",
                BindingFlags.NonPublic | BindingFlags.Instance);
            cscField.SetValue(writer, new CancellationTokenSource());

            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose without opened for writing should not throw
        /// </summary>
        [Fact]
        public void Dispose_WithoutOpenedForWriting_ShouldNotThrow()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose with csc should dispose csc
        /// </summary>
        [Fact]
        public void Dispose_WithCsc_ShouldDisposeCsc()
        {
            AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo cscField = typeof(AudioVideoWriter).GetField("csc",
                BindingFlags.NonPublic | BindingFlags.Instance);
            cscField.SetValue(writer, new CancellationTokenSource());

            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that write frame video when opened writes to stream
        /// </summary>
        [Fact]
        public void WriteFrame_Video_WhenOpened_WritesToStream()
        {
            AudioVideoWriter writer = new AudioVideoWriter(_tempFile, 640, 480, 30.0, 2, 44100, 16, null, null);

            FieldInfo openedField = typeof(AudioVideoWriter).GetField("<OpenedForWriting>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            openedField.SetValue(writer, true);

            Process process = CreateExitedProcess();
            FieldInfo processField = typeof(AudioVideoWriter).GetField("Ffmpegp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            processField.SetValue(writer, process);

            using MemoryStream videoStream = new MemoryStream();
            FieldInfo inputVideoField = typeof(AudioVideoWriter).GetField("<InputDataStreamVideo>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            inputVideoField.SetValue(writer, videoStream);

            using VideoFrame frame = new VideoFrame(2, 2);
            byte[] expectedData = frame.RawData;

            writer.WriteFrame(frame);

            Assert.Equal(expectedData.Length, videoStream.Length);
            Assert.Equal(expectedData, videoStream.ToArray());

            openedField.SetValue(writer, false);
            writer.Dispose();
        }
    }
}
