using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
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
        /// Sets the field using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="fieldName">The field name</param>
        /// <param name="value">The value</param>
        private static void SetField(object obj, string fieldName, object value)
        {
            FieldInfo field = obj.GetType().GetField(fieldName,
                BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(obj, value);
        }

        /// <summary>
        /// Sets the backing field using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <param name="propName">The prop name</param>
        /// <param name="value">The value</param>
        private static void SetBackingField(object obj, string propName, object value)
        {
            FieldInfo field = obj.GetType().GetField($"<{propName}>k__BackingField",
                BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(obj, value);
        }

        /// <summary>
        /// Tests that close write with null ffmpegp should complete gracefully
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WithNullFfmpegp_ShouldNotThrow()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_tempFile, 640, 480, 30.0, 2, 44100, 16, null, null);
            SetBackingField(writer, "OpenedForWriting", true);

            Exception ex = Record.Exception(() => writer.CloseWrite());

            Assert.Null(ex);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that dispose with opened for writing should complete
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithOpenedForWriting_ShouldComplete()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);
            SetBackingField(writer, "OpenedForWriting", true);
            SetField(writer, "Ffmpegp", CreateExitedProcess());
            SetField(writer, "csc", new CancellationTokenSource());

            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose without opened for writing should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithoutOpenedForWriting_ShouldNotThrow()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);
            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose with csc should dispose csc
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithCsc_ShouldDisposeCsc()
        {
            AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);
            SetField(writer, "csc", new CancellationTokenSource());
            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that write frame video when opened writes to stream
        /// </summary>
        [RequireFfmpegFact]
        public void WriteFrame_Video_WhenOpened_WritesToStream()
        {
            AudioVideoWriter writer = new AudioVideoWriter(_tempFile, 640, 480, 30.0, 2, 44100, 16, null, null);
            SetBackingField(writer, "OpenedForWriting", true);
            SetField(writer, "Ffmpegp", CreateExitedProcess());

            using MemoryStream videoStream = new MemoryStream();
            SetBackingField(writer, "InputDataStreamVideo", videoStream);

            using VideoFrame frame = new VideoFrame(2, 2);
            byte[] expectedData = frame.RawData;

            writer.WriteFrame(frame);

            Assert.Equal(expectedData.Length, videoStream.Length);
            Assert.Equal(expectedData, videoStream.ToArray());

            SetBackingField(writer, "OpenedForWriting", false);
            writer.Dispose();
        }

        /// <summary>
        /// Tests that close write with exited process disposes streams
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WithExitedProcess_DisposesStreams()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_tempFile, 640, 480, 30.0, 2, 44100, 16, null, null);
            SetBackingField(writer, "OpenedForWriting", true);
            SetField(writer, "Ffmpegp", CreateExitedProcess());
            SetBackingField(writer, "InputDataStreamVideo", new MemoryStream());

            Exception ex = Record.Exception(() => writer.CloseWrite());
            Assert.Null(ex);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that close write stream mode with exited process disposes output data stream
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_StreamMode_WithExitedProcess_DisposesOutputDataStream()
        {
            using MemoryStream outputStream = new MemoryStream();
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);
            SetBackingField(writer, "OpenedForWriting", true);
            SetField(writer, "Ffmpegp", CreateExitedProcess());
            SetBackingField(writer, "InputDataStreamVideo", new MemoryStream());
            SetBackingField(writer, "OutputDataStream", outputStream);

            Exception ex = Record.Exception(() => writer.CloseWrite());
            Assert.Null(ex);
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that dispose with opened for writing filename mode should close write
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithOpenedForWritingFilenameMode_ShouldCloseWrite()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_tempFile, 640, 480, 30.0, 2, 44100, 16, null, null);
            SetBackingField(writer, "OpenedForWriting", true);
            SetField(writer, "Ffmpegp", CreateExitedProcess());

            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that close write with exited process and socket should complete
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WithExitedProcessAndSocket_ShouldComplete()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_tempFile, 640, 480, 30.0, 2, 44100, 16, null, null);
            SetBackingField(writer, "OpenedForWriting", true);
            SetField(writer, "Ffmpegp", CreateExitedProcess());
            SetBackingField(writer, "InputDataStreamVideo", new MemoryStream());

            Exception ex = Record.Exception(() => writer.CloseWrite());
            Assert.Null(ex);
            Assert.False(writer.OpenedForWriting);
        }
    }
}
