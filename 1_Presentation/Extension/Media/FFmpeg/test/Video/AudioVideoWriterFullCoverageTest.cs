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
    public class AudioVideoWriterFullCoverageTest : IDisposable
    {
        private readonly string _tempFile;
        private readonly MemoryStream _testStream;
        private bool _disposed;

        public AudioVideoWriterFullCoverageTest()
        {
            _tempFile = Path.GetTempFileName();
            _testStream = new MemoryStream();
        }

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

        [Fact]
        public void Dispose_WithoutOpenedForWriting_ShouldNotThrow()
        {
            using AudioVideoWriter writer = new AudioVideoWriter(_testStream, 640, 480, 30.0, 2, 44100, 16, null, null);

            Exception ex = Record.Exception(() => writer.Dispose());
            Assert.Null(ex);
        }

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
