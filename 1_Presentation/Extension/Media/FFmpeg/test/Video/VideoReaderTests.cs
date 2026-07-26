using System;
using System.IO;
using Alis.Extension.Media.FFmpeg.Video;
using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    public class VideoReaderTests
    {
        [Fact]
        public void Constructor_WithExistingFile_SetsFilename()
        {
            string path = Path.GetTempFileName();
            try
            {
                using VideoReader reader = new VideoReader(path);
                Assert.Equal(path, reader.Filename);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void Constructor_WhenFileMissing_ThrowsFileNotFoundException()
        {
            string missing = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".mp4");
            Assert.Throws<FileNotFoundException>(() => new VideoReader(missing));
        }

        [Fact]
        public void Properties_HaveDefaultValues()
        {
            string path = Path.GetTempFileName();
            try
            {
                using VideoReader reader = new VideoReader(path);
                Assert.Equal(0, reader.CurrentFrameOffset);
                Assert.False(reader.LoadedMetadata);
                Assert.Null(reader.Metadata);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void Dispose_DoesNotThrow()
        {
            string path = Path.GetTempFileName();
            try
            {
                VideoReader reader = new VideoReader(path);
                reader.Dispose();
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void Dispose_MultipleCalls_DoesNotThrow()
        {
            string path = Path.GetTempFileName();
            try
            {
                VideoReader reader = new VideoReader(path);
                reader.Dispose();
                reader.Dispose();
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void Dispose_WithDataStream_DisposesStream()
        {
            string path = Path.GetTempFileName();
            try
            {
                TestableVideoReader reader = new TestableVideoReader(path);
                MemoryStream ms = new MemoryStream();
                reader.SetDataStream(ms);
                reader.Dispose();
                Assert.False(ms.CanRead);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void Load_WhenMetadataNotLoaded_ThrowsInvalidOperationException()
        {
            string path = Path.GetTempFileName();
            try
            {
                using VideoReader reader = new VideoReader(path);
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load());
                Assert.Contains("metadata", ex.Message);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void NextFrame_WithParameter_WhenNotLoaded_ThrowsInvalidOperationException()
        {
            string path = Path.GetTempFileName();
            try
            {
                using VideoReader reader = new VideoReader(path);
                using VideoFrame frame = new VideoFrame(2, 2);
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.NextFrame(frame));
                Assert.Contains("load the video", ex.Message);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void NextFrame_WithEmptyStream_ReturnsNull()
        {
            string path = Path.GetTempFileName();
            try
            {
                TestableVideoReader reader = new TestableVideoReader(path);
                reader.SetOpenedForReading(true);
                reader.SetDataStream(new MemoryStream());
                using VideoFrame frame = new VideoFrame(2, 2);
                Assert.Null(reader.NextFrame(frame));
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void NextFrame_WithSufficientData_ReturnsFrameAndIncrementsOffset()
        {
            string path = Path.GetTempFileName();
            try
            {
                TestableVideoReader reader = new TestableVideoReader(path);
                reader.SetOpenedForReading(true);
                reader.SetDataStream(new MemoryStream(new byte[12]));
                using VideoFrame frame = new VideoFrame(2, 2);
                VideoFrame result = reader.NextFrame(frame);
                Assert.NotNull(result);
                Assert.Same(frame, result);
                Assert.Equal(1, reader.CurrentFrameOffset);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
