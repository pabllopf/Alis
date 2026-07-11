using System;
using System.Diagnostics;
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
        private readonly string _realVideoFile;
        private bool _disposed;

        public VideoReaderCoverageTest()
        {
            _tempFile = Path.GetTempFileName();
            _realVideoFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".mp4");
            using Process p = new Process();
            p.StartInfo.FileName = "ffmpeg";
            p.StartInfo.Arguments = $"-f lavfi -i color=c=red:s=4x4:d=0.1 -f lavfi -i anullsrc=r=44100:cl=mono -t 0.1 -c:v libx264 -pix_fmt yuv420p -c:a aac -shortest \"{_realVideoFile}\" -y -loglevel quiet";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit(30000);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (File.Exists(_tempFile))
                    File.Delete(_tempFile);
                if (File.Exists(_realVideoFile))
                    try { File.Delete(_realVideoFile); } catch { }
            }
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
        public void Properties_DefaultValues()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            Assert.Equal(0, reader.CurrentFrameOffset);
            Assert.Null(reader.Metadata);
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
            TestableVideoReader reader = new TestableVideoReader(_tempFile);
            MemoryStream ms = new MemoryStream();
            reader.SetDataStream(ms);
            Assert.True(ms.CanRead);
            reader.Dispose();
            Assert.False(ms.CanRead);
        }

        [Fact]
        public void Load_WithoutMetadata_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            Assert.Throws<InvalidOperationException>(() => reader.Load());
        }

        [Fact]
        public void NextFrame_WithoutLoad_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            using VideoFrame frame = new VideoFrame(2, 2);
            Assert.Throws<InvalidOperationException>(() => reader.NextFrame(frame));
        }

        [Fact]
        public void LoadMetadata_WhenAlreadyLoaded_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            PropertyInfo loadedProp = typeof(VideoReader).GetProperty("LoadedMetadata", BindingFlags.Public | BindingFlags.Instance);
            loadedProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { true });
            AggregateException ex = Assert.Throws<AggregateException>(() => reader.LoadMetadata());
            Assert.Contains("already loaded", ex.InnerException.Message);
        }

        [Fact]
        public void LoadMetadataAsync_WhenAlreadyLoaded_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            PropertyInfo loadedProp = typeof(VideoReader).GetProperty("LoadedMetadata", BindingFlags.Public | BindingFlags.Instance);
            loadedProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { true });
            AggregateException ex = Assert.Throws<AggregateException>(() => reader.LoadMetadataAsync().Wait());
            Assert.Contains("already loaded", ex.InnerException.Message);
        }

        [Fact]
        public void Load_WithZeroDimensions_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            PropertyInfo metadataProp = typeof(VideoReader).GetProperty("Metadata", BindingFlags.Public | BindingFlags.Instance);
            metadataProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { new VideoMetadata() });
            PropertyInfo loadedProp = typeof(VideoReader).GetProperty("LoadedMetadata", BindingFlags.Public | BindingFlags.Instance);
            loadedProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { true });
            Assert.Throws<InvalidDataException>(() => reader.Load());
        }

        [Fact]
        public void Load_WhenAlreadyOpened_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            PropertyInfo metadataProp = typeof(VideoReader).GetProperty("Metadata", BindingFlags.Public | BindingFlags.Instance);
            metadataProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { new VideoMetadata { Width = 100, Height = 100 } });
            PropertyInfo loadedProp = typeof(VideoReader).GetProperty("LoadedMetadata", BindingFlags.Public | BindingFlags.Instance);
            loadedProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { true });
            PropertyInfo openedProp = typeof(VideoReader).GetProperty("OpenedForReading", BindingFlags.Public | BindingFlags.Instance);
            openedProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { true });
            Assert.Throws<InvalidOperationException>(() => reader.Load());
        }

        [Fact]
        public void NextFrame_Parameterless_WithMetadata_NotOpened_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            PropertyInfo metadataProp = typeof(VideoReader).GetProperty("Metadata", BindingFlags.Public | BindingFlags.Instance);
            metadataProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { new VideoMetadata { Width = 100, Height = 100 } });
            PropertyInfo loadedProp = typeof(VideoReader).GetProperty("LoadedMetadata", BindingFlags.Public | BindingFlags.Instance);
            loadedProp.GetSetMethod(nonPublic: true).Invoke(reader, new object[] { true });
            Assert.Throws<InvalidOperationException>(() => reader.NextFrame());
        }

        [Fact]
        public void NextFrame_Opened_EmptyStream_ReturnsNull()
        {
            TestableVideoReader reader = new TestableVideoReader(_tempFile);
            try
            {
                reader.SetOpenedForReading(true);
                reader.SetDataStream(new MemoryStream());
                using VideoFrame frame = new VideoFrame(2, 2);
                Assert.Null(reader.NextFrame(frame));
            }
            finally { reader.Dispose(); }
        }

        [Fact]
        public void NextFrame_Opened_WithData_ReturnsFrame()
        {
            TestableVideoReader reader = new TestableVideoReader(_tempFile);
            try
            {
                reader.SetOpenedForReading(true);
                reader.SetDataStream(new MemoryStream(new byte[12]));
                using VideoFrame frame = new VideoFrame(2, 2);
                VideoFrame result = reader.NextFrame(frame);
                Assert.NotNull(result);
                Assert.Same(frame, result);
                Assert.Equal(1, reader.CurrentFrameOffset);
            }
            finally { reader.Dispose(); }
        }

        [Fact]
        public void Load_WithRealVideo_LoadsSuccessfully()
        {
            if (!File.Exists(_realVideoFile)) return;
            using VideoReader reader = new VideoReader(_realVideoFile);
            reader.LoadMetadata();
            Assert.NotNull(reader.Metadata);
            Assert.True(reader.Metadata.Width > 0);
            Assert.True(reader.Metadata.Height > 0);
            reader.Load();
            Assert.True(reader.OpenedForReading);
            VideoFrame frame = reader.NextFrame();
            Assert.NotNull(frame);
            Assert.Equal(1, reader.CurrentFrameOffset);
            frame.Dispose();
        }

        [Fact]
        public void Load_WithRealVideo_WithOffset_LoadsSuccessfully()
        {
            if (!File.Exists(_realVideoFile)) return;
            using VideoReader reader = new VideoReader(_realVideoFile);
            reader.LoadMetadata();
            reader.Load(0.05);
            Assert.True(reader.OpenedForReading);
            VideoFrame frame = reader.NextFrame();
            if (frame != null) frame.Dispose();
        }

        [Fact]
        public async Task LoadMetadataAsync_WithRealVideo_Succeeds()
        {
            if (!File.Exists(_realVideoFile)) return;
            using VideoReader reader = new VideoReader(_realVideoFile);
            await reader.LoadMetadataAsync();
            Assert.NotNull(reader.Metadata);
            Assert.True(reader.LoadedMetadata);
        }

        [Fact]
        public async Task LoadMetadataAsync_WithIgnoreStreamErrors_Succeeds()
        {
            if (!File.Exists(_realVideoFile)) return;
            using VideoReader reader = new VideoReader(_realVideoFile);
            await reader.LoadMetadataAsync(ignoreStreamErrors: true);
            Assert.True(reader.LoadedMetadata);
        }

        [Fact]
        public async Task LoadMetadataAsync_WithNonexistentFfprobe_Throws()
        {
            if (!File.Exists(_realVideoFile)) return;
            using VideoReader reader = new VideoReader(_realVideoFile, "ffmpeg", "ffprobe-nonexistent");
            await Assert.ThrowsAsync<InvalidOperationException>(() => reader.LoadMetadataAsync());
        }

        [Fact]
        public void TryParseBitDepth_WithMatchingFormat_ReturnsDepth()
        {
            MethodInfo method = typeof(VideoReader).GetMethod("TryParseBitDepth",
                BindingFlags.NonPublic | BindingFlags.Static);
            Assert.Equal(10, method.Invoke(null, new object[] { "yuv420p10le" }));
            Assert.Equal(24, method.Invoke(null, new object[] { "rgb24le" }));
            Assert.Equal(16, method.Invoke(null, new object[] { "gray16le" }));
            Assert.Equal(8, method.Invoke(null, new object[] { "yuv420p8le" }));
        }

        [Fact]
        public void TryParseBitDepth_WithNonMatchingFormat_ReturnsNegativeOne()
        {
            MethodInfo method = typeof(VideoReader).GetMethod("TryParseBitDepth",
                BindingFlags.NonPublic | BindingFlags.Static);
            Assert.Equal(-1, method.Invoke(null, new object[] { "yuv420p" }));
            Assert.Equal(-1, method.Invoke(null, new object[] { "" }));
            Assert.Equal(-1, method.Invoke(null, new object[] { "nv12" }));
        }
    }

    public class TestableVideoReader : VideoReader
    {
        public TestableVideoReader(string filename, string ffmpeg = "ffmpeg", string ffprobe = "ffprobe")
            : base(filename, ffmpeg, ffprobe) { }

        public void SetOpenedForReading(bool value) => OpenedForReading = value;
        public void SetDataStream(Stream stream) => DataStream = stream;
    }
}
