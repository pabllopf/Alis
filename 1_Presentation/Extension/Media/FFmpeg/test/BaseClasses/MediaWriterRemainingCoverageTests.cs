using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    /// The media writer remaining coverage tests class
    /// </summary>
    public class MediaWriterRemainingCoverageTests
    {
        /// <summary>
        /// The test frame class
        /// </summary>
        /// <seealso cref="IMediaFrame"/>
        internal sealed class TestFrame : IMediaFrame
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TestFrame"/> class
            /// </summary>
            /// <param name="rawData">The raw data</param>
            public TestFrame(byte[] rawData) => RawData = rawData;

            /// <summary>
            /// Gets the value of the raw data
            /// </summary>
            public byte[] RawData { get; }

            /// <summary>
            /// Loads the stream
            /// </summary>
            /// <param name="stream">The stream</param>
            /// <returns>The bool</returns>
            public bool Load(Stream stream) => true;
        }

        /// <summary>
        /// The test writer class
        /// </summary>
        /// <seealso cref="MediaWriter{TestFrame}"/>
        internal sealed class TestWriter : MediaWriter<TestFrame>
        {
            /// <summary>
            /// Sets the opened using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            public void SetOpened(bool value) => OpenedForWriting = value;

            /// <summary>
            /// Sets the stream using the specified stream
            /// </summary>
            /// <param name="stream">The stream</param>
            public void SetStream(Stream stream) => InputDataStream = stream;

            /// <summary>
            /// Sets the filename using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            public void SetFilename(string value) => Filename = value;
        }

        /// <summary>
        /// Tests that filename default should be null
        /// </summary>
        [RequireFfmpegFact]
        public void Filename_Default_ShouldBeNull()
        {
            TestWriter writer = new TestWriter();
            Assert.Null(writer.Filename);
        }

        /// <summary>
        /// Tests that filename should be settable
        /// </summary>
        [RequireFfmpegFact]
        public void Filename_ShouldBeSettable()
        {
            TestWriter writer = new TestWriter();
            writer.SetFilename("output.mp4");
            Assert.Equal("output.mp4", writer.Filename);
        }

        /// <summary>
        /// Tests that input data stream default should be null
        /// </summary>
        [RequireFfmpegFact]
        public void InputDataStream_Default_ShouldBeNull()
        {
            TestWriter writer = new TestWriter();
            Assert.Null(writer.InputDataStream);
        }

        /// <summary>
        /// Tests that opened for writing default should be false
        /// </summary>
        [RequireFfmpegFact]
        public void OpenedForWriting_Default_ShouldBeFalse()
        {
            TestWriter writer = new TestWriter();
            Assert.False(writer.OpenedForWriting);
        }

        /// <summary>
        /// Tests that file to file with echo should return process
        /// </summary>
        [RequireFfmpegFact]
        public void FileToFile_WithEcho_ShouldReturnProcess()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "mp4",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            Process process = null;
            MediaWriter<TestFrame>.FileToFile("input.mp4", "output.mp4", options, out process, showOutput: true, ffmpegExecutable: "echo");

            Assert.NotNull(process);
            process?.Kill();
            process?.Dispose();
        }

        /// <summary>
        /// Tests that stream to file with echo should return stream
        /// </summary>
        [RequireFfmpegFact]
        public void StreamToFile_WithEcho_ShouldReturnStream()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "mp4",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            Stream stream = MediaWriter<TestFrame>.StreamToFile("output.mp4", options, out Process process, showOutput: true, ffmpegExecutable: "echo");

            Assert.NotNull(stream);
            process?.Kill();
            process?.Dispose();
        }

        /// <summary>
        /// Tests that file to stream with echo should return stream
        /// </summary>
        [RequireFfmpegFact]
        public void FileToStream_WithEcho_ShouldReturnStream()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "flv",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            Stream stream = MediaWriter<TestFrame>.FileToStream("input.mp4", options, out Process process, showOutput: true, ffmpegExecutable: "echo");

            Assert.NotNull(stream);
            process?.Kill();
            process?.Dispose();
        }

        /// <summary>
        /// Tests that stream to stream with echo should return streams
        /// </summary>
        [RequireFfmpegFact]
        public void StreamToStream_WithEcho_ShouldReturnStreams()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "flv",
                EncoderName = "libx264",
                EncoderArguments = "-crf 23"
            };

            (Stream input, Stream output) = MediaWriter<TestFrame>.StreamToStream(options, out Process process, showOutput: true, ffmpegExecutable: "echo");

            Assert.NotNull(input);
            Assert.NotNull(output);
            process?.Kill();
            process?.Dispose();
        }
    }
}
