using System.IO;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    /// The media reader remaining coverage tests class
    /// </summary>
    public class MediaReaderRemainingCoverageTests
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
        }

        /// <summary>
        /// The test reader class
        /// </summary>
        /// <seealso cref="MediaReader{TestFrame, TestWriter}"/>
        internal sealed class TestReader : MediaReader<TestFrame, TestWriter>
        {
            /// <summary>
            /// Sets the filename using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            public void SetFilename(string value) => Filename = value;
            /// <summary>
            /// Sets the data stream using the specified stream
            /// </summary>
            /// <param name="stream">The stream</param>
            public void SetDataStream(Stream stream) => DataStream = stream;
            /// <summary>
            /// Sets the opened for reading using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            public void SetOpenedForReading(bool value) => OpenedForReading = value;

            /// <summary>
            /// Gets the filename
            /// </summary>
            /// <returns>The string</returns>
            public string GetFilename() => Filename;
            /// <summary>
            /// Gets the data stream
            /// </summary>
            /// <returns>The stream</returns>
            public Stream GetDataStream() => DataStream;
            /// <summary>
            /// Gets the opened for reading
            /// </summary>
            /// <returns>The bool</returns>
            public bool GetOpenedForReading() => OpenedForReading;

            /// <summary>
            /// Nexts the frame
            /// </summary>
            /// <returns>The test frame</returns>
            public override TestFrame NextFrame() => null;
            /// <summary>
            /// Nexts the frame using the specified frame
            /// </summary>
            /// <param name="frame">The frame</param>
            /// <returns>The test frame</returns>
            public override TestFrame NextFrame(TestFrame frame) => null;
        }

        /// <summary>
        /// Tests that filename default should be null
        /// </summary>
        [RequireFfmpegFact]
        public void Filename_Default_ShouldBeNull()
        {
            TestReader reader = new TestReader();
            Assert.Null(reader.GetFilename());
        }

        /// <summary>
        /// Tests that filename should be settable
        /// </summary>
        [RequireFfmpegFact]
        public void Filename_ShouldBeSettable()
        {
            TestReader reader = new TestReader();
            reader.SetFilename("input.mp4");
            Assert.Equal("input.mp4", reader.GetFilename());
        }

        /// <summary>
        /// Tests that data stream default should be null
        /// </summary>
        [RequireFfmpegFact]
        public void DataStream_Default_ShouldBeNull()
        {
            TestReader reader = new TestReader();
            Assert.Null(reader.GetDataStream());
        }

        /// <summary>
        /// Tests that opened for reading default should be false
        /// </summary>
        [RequireFfmpegFact]
        public void OpenedForReading_Default_ShouldBeFalse()
        {
            TestReader reader = new TestReader();
            Assert.False(reader.GetOpenedForReading());
        }

        /// <summary>
        /// Tests that opened for reading should be settable
        /// </summary>
        [RequireFfmpegFact]
        public void OpenedForReading_ShouldBeSettable()
        {
            TestReader reader = new TestReader();
            reader.SetOpenedForReading(true);
            Assert.True(reader.GetOpenedForReading());
        }
    }
}
