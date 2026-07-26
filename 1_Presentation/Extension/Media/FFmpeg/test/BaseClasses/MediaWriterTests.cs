using System;
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Encoding;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    public class MediaWriterTests
    {
        private sealed class TestFrame : IMediaFrame
        {
            public TestFrame(byte[] rawData) => RawData = rawData;

            public byte[] RawData { get; }

            public bool Load(Stream stream) => true;
        }

        private sealed class TestWriter : MediaWriter<TestFrame>
        {
            public void SetOpened(bool value) => OpenedForWriting = value;

            public void SetStream(Stream stream) => InputDataStream = stream;

            public void SetFilename(string value) => Filename = value;
        }

        [Fact]
        public void Filename_Default_ShouldBeNull()
        {
            TestWriter writer = new TestWriter();
            Assert.Null(writer.Filename);
        }

        [Fact]
        public void Filename_ShouldBeSettable()
        {
            TestWriter writer = new TestWriter();
            writer.SetFilename("output.mp4");
            Assert.Equal("output.mp4", writer.Filename);
        }

        [Fact]
        public void InputDataStream_Default_ShouldBeNull()
        {
            TestWriter writer = new TestWriter();
            Assert.Null(writer.InputDataStream);
        }

        [Fact]
        public void OpenedForWriting_Default_ShouldBeFalse()
        {
            TestWriter writer = new TestWriter();
            Assert.False(writer.OpenedForWriting);
        }

        [Fact]
        public void WriteFrame_WhenNotOpened_ShouldThrow()
        {
            TestWriter writer = new TestWriter();
            Assert.Throws<InvalidOperationException>(() => writer.WriteFrame(new TestFrame(new byte[] { 1 })));
        }

        [Fact]
        public void WriteFrame_WhenOpened_ShouldWriteToStream()
        {
            byte[] payload = { 1, 2, 3, 4, 5 };
            MemoryStream stream = new MemoryStream();
            TestWriter writer = new TestWriter();
            writer.SetStream(stream);
            writer.SetOpened(true);

            writer.WriteFrame(new TestFrame(payload));

            Assert.Equal(payload, stream.ToArray());
        }

        [Fact]
        public void FileToFile_WithEcho_ShouldReturnProcess()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "mp4",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            MediaWriter<TestFrame>.FileToFile("input.mp4", "output.mp4", options, out Process process, showOutput: true, ffmpegExecutable: "/bin/echo");

            Assert.NotNull(process);
            process?.Kill();
            process?.Dispose();
        }

        [Fact]
        public void StreamToFile_WithEcho_ShouldReturnStream()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "mp4",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            Stream stream = MediaWriter<TestFrame>.StreamToFile("output.mp4", options, out Process process, showOutput: true, ffmpegExecutable: "/bin/echo");

            Assert.NotNull(stream);
            process?.Kill();
            process?.Dispose();
        }

        [Fact]
        public void FileToStream_WithEcho_ShouldReturnStream()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "flv",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            Stream stream = MediaWriter<TestFrame>.FileToStream("input.mp4", options, out Process process, showOutput: true, ffmpegExecutable: "/bin/echo");

            Assert.NotNull(stream);
            process?.Kill();
            process?.Dispose();
        }

        [Fact]
        public void StreamToStream_WithEcho_ShouldReturnStreams()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "flv",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            (Stream input, Stream output) = MediaWriter<TestFrame>.StreamToStream(options, out Process process, showOutput: true, ffmpegExecutable: "/bin/echo");

            Assert.NotNull(input);
            Assert.NotNull(output);
            process?.Kill();
            process?.Dispose();
        }
    }
}
