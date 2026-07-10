using System;
using System.IO;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    public class MediaReaderRemainingCoverageTests
    {
        private sealed class TestFrame : IMediaFrame
        {
            public TestFrame(byte[] rawData) => RawData = rawData;
            public byte[] RawData { get; }
            public bool Load(Stream stream) => true;
        }

        private sealed class TestWriter : MediaWriter<TestFrame>
        {
        }

        private sealed class TestReader : MediaReader<TestFrame, TestWriter>
        {
            public void SetFilename(string value) => Filename = value;
            public void SetDataStream(Stream stream) => DataStream = stream;
            public void SetOpenedForReading(bool value) => OpenedForReading = value;

            public string GetFilename() => Filename;
            public Stream GetDataStream() => DataStream;
            public bool GetOpenedForReading() => OpenedForReading;

            public override TestFrame NextFrame() => null;
            public override TestFrame NextFrame(TestFrame frame) => null;
        }

        [Fact]
        public void Filename_Default_ShouldBeNull()
        {
            TestReader reader = new TestReader();
            Assert.Null(reader.GetFilename());
        }

        [Fact]
        public void Filename_ShouldBeSettable()
        {
            TestReader reader = new TestReader();
            reader.SetFilename("input.mp4");
            Assert.Equal("input.mp4", reader.GetFilename());
        }

        [Fact]
        public void DataStream_Default_ShouldBeNull()
        {
            TestReader reader = new TestReader();
            Assert.Null(reader.GetDataStream());
        }

        [Fact]
        public void OpenedForReading_Default_ShouldBeFalse()
        {
            TestReader reader = new TestReader();
            Assert.False(reader.GetOpenedForReading());
        }

        [Fact]
        public void OpenedForReading_ShouldBeSettable()
        {
            TestReader reader = new TestReader();
            reader.SetOpenedForReading(true);
            Assert.True(reader.GetOpenedForReading());
        }
    }
}
