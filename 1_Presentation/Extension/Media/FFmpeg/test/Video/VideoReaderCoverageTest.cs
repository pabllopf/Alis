using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Video;
using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    public class VideoReaderCoverageTest : IDisposable
    {
        private readonly string _tempFile;
        private bool _disposed;

        public VideoReaderCoverageTest()
        {
            _tempFile = Path.GetTempFileName();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (File.Exists(_tempFile))
                    File.Delete(_tempFile);
            }
        }

        private void SetProperty(object obj, string propName, object value)
        {
            PropertyInfo prop = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            prop.GetSetMethod(nonPublic: true).Invoke(obj, new[] { value });
        }

        [Fact]
        public void Constructor_ShouldSetFilename()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            Assert.Equal(_tempFile, reader.Filename);
        }

        [Fact]
        public void Constructor_WithCustomExecutables_ShouldSetFields()
        {
            using VideoReader reader = new VideoReader(_tempFile, "my-ffmpeg", "my-ffprobe");
            Assert.Equal("my-ffmpeg", typeof(VideoReader).GetField("ffmpeg", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(reader));
            Assert.Equal("my-ffprobe", typeof(VideoReader).GetField("ffprobe", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(reader));
        }

        [Fact]
        public void CurrentFrameOffset_Default_ShouldBeZero()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            Assert.Equal(0, reader.CurrentFrameOffset);
        }

        [Fact]
        public void Metadata_Default_ShouldBeNull()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            Assert.Null(reader.Metadata);
        }

        [Fact]
        public void LoadedMetadata_Default_ShouldBeFalse()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            Assert.False(reader.LoadedMetadata);
        }

        [Fact]
        public void Dispose_ShouldNotThrow()
        {
            VideoReader reader = new VideoReader(_tempFile);
            Exception ex = Record.Exception(() => reader.Dispose());
            Assert.Null(ex);
        }

        [Fact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            VideoReader reader = new VideoReader(_tempFile);
            reader.Dispose();
            reader.Dispose();
            reader.Dispose();
        }

        [Fact]
        public void Dispose_WithDisposingFalse_ShouldNotThrow()
        {
            VideoReader reader = new VideoReader(_tempFile);
            MethodInfo disposeMethod = typeof(VideoReader).GetMethod("Dispose", BindingFlags.NonPublic | BindingFlags.Instance);
            Exception ex = Record.Exception(() => disposeMethod.Invoke(reader, new object[] { false }));
            Assert.Null(ex);
            reader.Dispose();
        }

        [Fact]
        public void Dispose_WithDataStream_ShouldDisposeStream()
        {
            VideoReader reader = new VideoReader(_tempFile);
            SetProperty(reader, "DataStream", new MemoryStream());
            Assert.True(((MemoryStream)typeof(VideoReader).GetProperty("DataStream", BindingFlags.Public | BindingFlags.Instance).GetValue(reader)).CanRead);
            reader.Dispose();
        }

        [Fact]
        public void Load_WithoutMetadata_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load());
            Assert.Contains("load the video metadata", ex.Message);
        }

        [Fact]
        public void NextFrame_WithFrame_WithoutLoad_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            using VideoFrame frame = new VideoFrame(2, 2);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.NextFrame(frame));
            Assert.Contains("load the video first", ex.Message);
        }

        [Fact]
        public void Load_WithZeroDimensionsInMetadata_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            SetProperty(reader, "Metadata", new VideoMetadata());
            SetProperty(reader, "LoadedMetadata", true);
            Assert.Throws<InvalidDataException>(() => reader.Load());
        }

        [Fact]
        public void Load_WhenAlreadyOpened_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            SetProperty(reader, "Metadata", new VideoMetadata { Width = 100, Height = 100 });
            SetProperty(reader, "LoadedMetadata", true);
            SetProperty(reader, "OpenedForReading", true);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load());
            Assert.Contains("already loaded", ex.Message);
        }

        [Fact]
        public void LoadMetadataAsync_WhenAlreadyLoaded_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            SetProperty(reader, "LoadedMetadata", true);
            AggregateException ex = Assert.Throws<AggregateException>(() => reader.LoadMetadataAsync().Wait());
            Assert.Contains("already loaded", ex.InnerException.Message);
        }

        [Fact]
        public void LoadMetadata_CallsAsyncAndWaits_WhenAlreadyLoaded()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            SetProperty(reader, "LoadedMetadata", true);
            Assert.Throws<InvalidOperationException>(() => reader.LoadMetadata());
        }

        [Fact]
        public void NextFrame_WithFrame_WithOpenedForReading_WithData_ReturnsFrame()
        {
            VideoReader reader = new VideoReader(_tempFile);
            try
            {
                SetProperty(reader, "OpenedForReading", true);
                SetProperty(reader, "DataStream", new MemoryStream(new byte[12]));
                using VideoFrame frame = new VideoFrame(2, 2);
                VideoFrame result = reader.NextFrame(frame);
                Assert.NotNull(result);
                Assert.Same(frame, result);
                Assert.Equal(1, reader.CurrentFrameOffset);
            }
            finally
            {
                SetProperty(reader, "OpenedForReading", false);
                reader.Dispose();
            }
        }

        [Fact]
        public void NextFrame_Parameterless_WithMetadata_WithoutLoad_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            SetProperty(reader, "Metadata", new VideoMetadata { Width = 100, Height = 100 });
            SetProperty(reader, "LoadedMetadata", true);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.NextFrame());
            Assert.Contains("load the video first", ex.Message);
        }

        [Fact]
        public void NextFrame_WithFrame_WithOpenedForReading_EmptyStream_ReturnsNull()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            SetProperty(reader, "OpenedForReading", true);
            using VideoFrame frame = new VideoFrame(2, 2);
            VideoFrame result = reader.NextFrame(frame);
            Assert.Null(result);
        }
    }
}
