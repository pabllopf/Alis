using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Encoding;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    /// The audio writer final coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioWriterFinalCoverageTests : IDisposable
    {
        /// <summary>
        /// The stub ffmpeg
        /// </summary>
        private const string StubFfmpeg = "/tmp/ffplay_stub.sh";
        /// <summary>
        /// The writer
        /// </summary>
        private AudioWriter _writer;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            try { _writer?.Dispose(); } catch { }
        }

        /// <summary>
        /// Tests that constructor with file invalid channels throws
        /// </summary>
        [Fact]
        public void Constructor_WithFile_InvalidChannels_Throws()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(() =>
                new AudioWriter("out.mp3", 0, 44100));
            Assert.Contains("Channels", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with file invalid sample rate throws
        /// </summary>
        [Fact]
        public void Constructor_WithFile_InvalidSampleRate_Throws()
        {
            InvalidDataException ex = Assert.Throws<InvalidDataException>(() =>
                new AudioWriter("out.mp3", 2, 0));
            Assert.Contains("Channels", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with file invalid bit depth throws
        /// </summary>
        [Fact]
        public void Constructor_WithFile_InvalidBitDepth_Throws()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                new AudioWriter("out.mp3", 2, 44100, 99));
            Assert.Contains("bit depth", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with file null filename throws
        /// </summary>
        [Fact]
        public void Constructor_WithFile_NullFilename_Throws()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                new AudioWriter((string)null, 2, 44100));
            Assert.Contains("filename", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that constructor with file empty filename throws
        /// </summary>
        [Fact]
        public void Constructor_WithFile_EmptyFilename_Throws()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                new AudioWriter((string)"", 2, 44100));
            Assert.Contains("filename", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that constructor with stream invalid channels throws
        /// </summary>
        [Fact]
        public void Constructor_WithStream_InvalidChannels_Throws()
        {
            using MemoryStream ms = new MemoryStream();
            InvalidDataException ex = Assert.Throws<InvalidDataException>(() =>
                new AudioWriter(ms, 0, 44100));
            Assert.Contains("Channels", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with stream invalid sample rate throws
        /// </summary>
        [Fact]
        public void Constructor_WithStream_InvalidSampleRate_Throws()
        {
            using MemoryStream ms = new MemoryStream();
            InvalidDataException ex = Assert.Throws<InvalidDataException>(() =>
                new AudioWriter(ms, 2, 0));
            Assert.Contains("Channels", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with stream invalid bit depth throws
        /// </summary>
        [Fact]
        public void Constructor_WithStream_InvalidBitDepth_Throws()
        {
            using MemoryStream ms = new MemoryStream();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                new AudioWriter(ms, 2, 44100, 99));
            Assert.Contains("bit depth", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with stream null stream throws
        /// </summary>
        [Fact]
        public void Constructor_WithStream_NullStream_Throws()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
                new AudioWriter((Stream)null, 2, 44100));
            Assert.Contains("stream", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Tests that open write already opened throws
        /// </summary>
        [Fact]
        public void OpenWrite_AlreadyOpened_Throws()
        {
            _writer = new AudioWriter("out.mp3", 2, 44100, 16, (EncoderOptions)null, StubFfmpeg);
            FieldInfo openedField = typeof(MediaWriter<>).MakeGenericType(typeof(AudioFrame))
                .GetField("<OpenedForWriting>k__BackingField",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            openedField?.SetValue(_writer, true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _writer.OpenWrite());
            Assert.Contains("already opened", ex.Message);
        }

        /// <summary>
        /// Tests that close write not opened throws
        /// </summary>
        [Fact]
        public void CloseWrite_NotOpened_Throws()
        {
            _writer = new AudioWriter("out.mp3", 2, 44100, 16, (EncoderOptions)null, StubFfmpeg);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _writer.CloseWrite());
            Assert.Contains("not opened", ex.Message);
        }

        /// <summary>
        /// Tests that dispose after open write cleans up
        /// </summary>
        [Fact]
        public void Dispose_AfterOpenWrite_CleansUp()
        {
            _writer = new AudioWriter("out.mp3", 2, 44100, 16, (EncoderOptions)null, StubFfmpeg);
            FieldInfo openedField = typeof(MediaWriter<>).MakeGenericType(typeof(AudioFrame))
                .GetField("<OpenedForWriting>k__BackingField",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            openedField?.SetValue(_writer, true);

            FieldInfo inputStreamField = typeof(MediaWriter<>).MakeGenericType(typeof(AudioFrame))
                .GetField("<InputDataStream>k__BackingField",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            inputStreamField?.SetValue(_writer, new MemoryStream());

            FieldInfo ffmpegpField = typeof(AudioWriter).GetField("Ffmpegp",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            using Process p = new Process();
            p.StartInfo.FileName = StubFfmpeg;
            p.Start();
            ffmpegpField?.SetValue(_writer, p);

            Exception ex = Record.Exception(() => _writer.Dispose());
            Assert.Null(ex);
            if (!p.HasExited) { p.Kill(); p.WaitForExit(1000); }
        }

        /// <summary>
        /// Tests that current f fmpeg process should return process
        /// </summary>
        [Fact]
        public void CurrentFFmpegProcess_ShouldReturnProcess()
        {
            _writer = new AudioWriter("out.mp3", 2, 44100, 16, (EncoderOptions)null, StubFfmpeg);
            FieldInfo ffmpegpField = typeof(AudioWriter).GetField("Ffmpegp",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            using Process p = new Process();
            p.StartInfo.FileName = StubFfmpeg;
            p.Start();
            ffmpegpField?.SetValue(_writer, p);

            Assert.NotNull(_writer.CurrentFFmpegProcess);
            if (!p.HasExited) { p.Kill(); p.WaitForExit(1000); }
        }

        /// <summary>
        /// Tests that properties should return constructor values
        /// </summary>
        [Fact]
        public void Properties_ShouldReturnConstructorValues()
        {
            _writer = new AudioWriter("out.mp3", 2, 44100, 16);
            Assert.Equal(2, _writer.Channels);
            Assert.Equal(44100, _writer.SampleRate);
            Assert.Equal(16, _writer.BitDepth);
            Assert.True(_writer.UseFilename);
            Assert.NotNull(_writer.EncoderOptions);
            Assert.Equal("out.mp3", _writer.Filename);
        }

        /// <summary>
        /// Tests that properties with stream constructor should return correct values
        /// </summary>
        [Fact]
        public void Properties_WithStreamConstructor_ShouldReturnCorrectValues()
        {
            using MemoryStream ms = new MemoryStream();
            _writer = new AudioWriter(ms, 2, 44100, 16);
            Assert.Equal(2, _writer.Channels);
            Assert.Equal(44100, _writer.SampleRate);
            Assert.Equal(16, _writer.BitDepth);
            Assert.False(_writer.UseFilename);
            Assert.Same(ms, _writer.DestinationStream);
        }

        /// <summary>
        /// Tests that open write with stream and stub calls ff mpeg wrapper
        /// </summary>
        [Fact]
        public void OpenWrite_WithStreamAndStub_CallsFfMpegWrapper()
        {
            using MemoryStream dest = new MemoryStream();
            _writer = new AudioWriter(dest, 2, 44100, 16, (EncoderOptions)null, StubFfmpeg);
            _writer.OpenWrite();

            Assert.True(_writer.OpenedForWriting);
            Assert.NotNull(_writer.InputDataStream);
            _writer.CloseWrite();
            Assert.False(_writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that open write with file and stub calls ff mpeg wrapper
        /// </summary>
        [Fact]
        public void OpenWrite_WithFileAndStub_CallsFfMpegWrapper()
        {
            string outFile = Path.GetTempFileName() + ".wav";
            try
            {
                _writer = new AudioWriter(outFile, 2, 44100, 16, (EncoderOptions)null, StubFfmpeg);
                _writer.OpenWrite();
                Assert.True(_writer.OpenedForWriting);
                Assert.NotNull(_writer.InputDataStream);
                _writer.CloseWrite();
                Assert.False(_writer.OpenedForWriting);
            }
            finally
            {
                if (File.Exists(outFile)) File.Delete(outFile);
            }
        }
    }
}
