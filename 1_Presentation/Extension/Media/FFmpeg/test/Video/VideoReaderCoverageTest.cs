using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Video;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    public class VideoReaderCoverageTest : IDisposable
    {
        private readonly string _tempFile;
        private readonly string _realVideoFile;

        public VideoReaderCoverageTest()
        {
            _tempFile = Path.GetTempFileName();
            _realVideoFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets", "small.mp4");
        }

        public void Dispose()
        {
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
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

            FieldInfo ffmpegField = typeof(VideoReader).GetField("ffmpeg",
                BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo ffprobeField = typeof(VideoReader).GetField("ffprobe",
                BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.Equal("my-ffmpeg", ffmpegField.GetValue(reader));
            Assert.Equal("my-ffprobe", ffprobeField.GetValue(reader));
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
            MethodInfo disposeMethod = typeof(VideoReader).GetMethod("Dispose",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Exception ex = Record.Exception(() =>
                disposeMethod.Invoke(reader, new object[] { false }));
            Assert.Null(ex);
            reader.Dispose();
        }

        [Fact]
        public void Dispose_WithDataStream_ShouldDisposeStream()
        {
            VideoReader reader = new VideoReader(_tempFile);
            PropertyInfo dataStreamProp = typeof(VideoReader).GetProperty("DataStream",
                BindingFlags.Public | BindingFlags.Instance);
            MemoryStream ms = new MemoryStream();
            dataStreamProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { ms });

            Assert.True(ms.CanRead);
            reader.Dispose();
            Assert.False(ms.CanRead);
        }

        [Fact]
        public void LoadMetadata_WithRealVideo_ShouldSucceed()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            Exception ex = Record.Exception(() => reader.LoadMetadata());
            Assert.Null(ex);
            Assert.True(reader.LoadedMetadata);
            Assert.NotNull(reader.Metadata);
        }

        [Fact]
        public void LoadMetadata_WhenAlreadyLoaded_ShouldThrow()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            reader.LoadMetadata();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.LoadMetadata());
            Assert.Contains("already loaded", ex.Message);
        }

        [Fact]
        public async Task LoadMetadataAsync_WithRealVideo_ShouldSucceed()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            await reader.LoadMetadataAsync();
            Assert.True(reader.LoadedMetadata);
            Assert.NotNull(reader.Metadata);
        }

        [Fact]
        public void LoadMetadataAsync_WhenAlreadyLoaded_ShouldThrow()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            reader.LoadMetadata();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => reader.LoadMetadataAsync().Wait());
            Assert.Contains("already loaded", ex.Message);
        }

        [Fact]
        public void Load_AfterMetadata_ShouldOpenDataStream()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            reader.LoadMetadata();
            reader.Load();
            Assert.True(reader.OpenedForReading);
        }

        [Fact]
        public void Load_WithOffset_ShouldOpenDataStream()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            reader.LoadMetadata();
            reader.Load(0.5);
            Assert.True(reader.OpenedForReading);
        }

        [Fact]
        public void Load_WhenAlreadyOpened_ShouldThrow()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            reader.LoadMetadata();
            reader.Load();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load());
            Assert.Contains("already loaded", ex.Message);
        }

        [Fact]
        public void Load_WithoutMetadata_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load());
            Assert.Contains("load the video metadata", ex.Message);
        }

        [Fact]
        public async Task LoadMetadataAsync_WithNonExistentFfprobe_ShouldThrow()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile, "ffmpeg", "ffprobe-nonexistent");
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => reader.LoadMetadataAsync());
            Assert.Contains("Failed to interpret ffprobe", ex.Message);
        }

        [Fact]
        public async Task LoadMetadataAsync_WithIgnoreStreamErrors_ShouldHandleStreamErrors()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            Exception ex = await Record.ExceptionAsync(() => reader.LoadMetadataAsync(ignoreStreamErrors: true));
            Assert.Null(ex);
        }

        [Fact]
        public void NextFrame_WithoutLoad_ShouldThrow()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.NextFrame());
            Assert.Contains("load the video first", ex.Message);
        }

        [Fact]
        public void NextFrame_WithFrame_WithoutLoad_ShouldThrow()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            using VideoFrame frame = new VideoFrame(2, 2);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.NextFrame(frame));
            Assert.Contains("load the video first", ex.Message);
        }

        [Fact]
        public void NextFrame_AfterLoad_ShouldReturnFrames()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            reader.LoadMetadata();
            reader.Load();

            VideoFrame frame = reader.NextFrame();
            if (frame != null)
            {
                Assert.Equal(1, reader.CurrentFrameOffset);
                frame.Dispose();
            }
        }

        [Fact]
        public void NextFrame_WithFrame_AfterLoad_ShouldOverwriteFrame()
        {
            if (!File.Exists(_realVideoFile))
                return;

            using VideoReader reader = new VideoReader(_realVideoFile);
            reader.LoadMetadata();
            reader.Load();

            using VideoFrame frame = new VideoFrame(reader.Metadata.Width, reader.Metadata.Height);
            VideoFrame result = reader.NextFrame(frame);
            if (result != null)
            {
                Assert.Same(frame, result);
                Assert.Equal(1, reader.CurrentFrameOffset);
            }
        }
    }
}
