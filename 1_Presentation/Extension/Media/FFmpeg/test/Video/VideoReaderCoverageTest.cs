using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Alis.Extension.Media.FFmpeg.Video;
using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video
{
    /// <summary>
    /// The video reader coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VideoReaderCoverageTest : IDisposable
    {
        /// <summary>
        /// The temp file
        /// </summary>
        private readonly string _tempFile;
        /// <summary>
        /// The real video file
        /// </summary>
        private readonly string _realVideoFile;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoReaderCoverageTest"/> class
        /// </summary>
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

        /// <summary>
        /// Disposes this instance
        /// </summary>
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

        /// <summary>
        /// Tests that constructor should set filename
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_ShouldSetFilename()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            Assert.Equal(_tempFile, reader.Filename);
        }

        /// <summary>
        /// Tests that constructor with custom executables should set fields
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithCustomExecutables_ShouldSetFields()
        {
            using VideoReader reader = new VideoReader(_tempFile, "my-ffmpeg", "my-ffprobe");
            Assert.Equal("my-ffmpeg", typeof(VideoReader).GetField("ffmpeg", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(reader));
            Assert.Equal("my-ffprobe", typeof(VideoReader).GetField("ffprobe", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(reader));
        }

        /// <summary>
        /// Tests that properties default values
        /// </summary>
        [RequireFfmpegFact]
        public void Properties_DefaultValues()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            Assert.Equal(0, reader.CurrentFrameOffset);
            Assert.Null(reader.Metadata);
            Assert.False(reader.LoadedMetadata);
        }

        /// <summary>
        /// Tests that dispose should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_ShouldNotThrow()
        {
            VideoReader reader = new VideoReader(_tempFile);
            Exception ex = Record.Exception(() => reader.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose multiple calls should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_MultipleCalls_ShouldNotThrow()
        {
            VideoReader reader = new VideoReader(_tempFile);
            reader.Dispose();
            reader.Dispose();
            reader.Dispose();
        }

        /// <summary>
        /// Tests that dispose with disposing false should not throw
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDisposingFalse_ShouldNotThrow()
        {
            VideoReader reader = new VideoReader(_tempFile);
            MethodInfo disposeMethod = typeof(VideoReader).GetMethod("Dispose", BindingFlags.NonPublic | BindingFlags.Instance);
            Exception ex = Record.Exception(() => disposeMethod.Invoke(reader, new object[] { false }));
            Assert.Null(ex);
            reader.Dispose();
        }

        /// <summary>
        /// Tests that dispose with data stream should dispose stream
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_WithDataStream_ShouldDisposeStream()
        {
            TestableVideoReader reader = new TestableVideoReader(_tempFile);
            MemoryStream ms = new MemoryStream();
            reader.SetDataStream(ms);
            Assert.True(ms.CanRead);
            reader.Dispose();
            Assert.False(ms.CanRead);
        }

        /// <summary>
        /// Tests that load without metadata should throw
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithoutMetadata_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            Assert.Throws<InvalidOperationException>(() => reader.Load());
        }

        /// <summary>
        /// Tests that next frame without load should throw
        /// </summary>
        [RequireFfmpegFact]
        public void NextFrame_WithoutLoad_ShouldThrow()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            using VideoFrame frame = new VideoFrame(2, 2);
            Assert.Throws<InvalidOperationException>(() => reader.NextFrame(frame));
        }

        /// <summary>
        /// Tests that next frame opened empty stream returns null
        /// </summary>
        [RequireFfmpegFact]
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

        /// <summary>
        /// Tests that next frame opened with data returns frame
        /// </summary>
        [RequireFfmpegFact]
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

        /// <summary>
        /// Tests that load metadata async with real video succeeds
        /// </summary>
        [RequireFfmpegFact]
        public async Task LoadMetadataAsync_WithRealVideo_Succeeds()
        {
            if (!File.Exists(_realVideoFile)) return;
            using VideoReader reader = new VideoReader(_realVideoFile);
            await reader.LoadMetadataAsync();
            Assert.NotNull(reader.Metadata);
            Assert.True(reader.LoadedMetadata);
            Assert.True(reader.Metadata.Width > 0 || reader.Metadata.Height == 0);
        }

        /// <summary>
        /// Tests that load metadata async with ignore stream errors succeeds
        /// </summary>
        [RequireFfmpegFact]
        public async Task LoadMetadataAsync_WithIgnoreStreamErrors_Succeeds()
        {
            if (!File.Exists(_realVideoFile)) return;
            using VideoReader reader = new VideoReader(_realVideoFile);
            await reader.LoadMetadataAsync(ignoreStreamErrors: true);
            Assert.True(reader.LoadedMetadata);
        }

        /// <summary>
        /// Tests that load metadata async with nonexistent ffprobe throws
        /// </summary>
        [RequireFfmpegFact]
        public async Task LoadMetadataAsync_WithNonexistentFfprobe_Throws()
        {
            if (!File.Exists(_realVideoFile)) return;
            using VideoReader reader = new VideoReader(_realVideoFile, "ffmpeg", "ffprobe-nonexistent");
            Exception ex = await Record.ExceptionAsync(() => reader.LoadMetadataAsync());
            Assert.NotNull(ex);
        }

        /// <summary>
        /// Tests that try parse bit depth with matching format returns depth
        /// </summary>
        [RequireFfmpegFact]
        public void TryParseBitDepth_WithMatchingFormat_ReturnsDepth()
        {
            MethodInfo method = typeof(VideoReader).GetMethod("TryParseBitDepth",
                BindingFlags.NonPublic | BindingFlags.Static);
            Assert.Equal(10, method.Invoke(null, new object[] { "yuv420p10le" }));
            Assert.Equal(24, method.Invoke(null, new object[] { "rgb24le" }));
            Assert.Equal(16, method.Invoke(null, new object[] { "gray16le" }));
            Assert.Equal(8, method.Invoke(null, new object[] { "yuv420p8le" }));
        }

        /// <summary>
        /// Tests that try parse bit depth with non matching format returns negative one
        /// </summary>
        [RequireFfmpegFact]
        public void TryParseBitDepth_WithNonMatchingFormat_ReturnsNegativeOne()
        {
            MethodInfo method = typeof(VideoReader).GetMethod("TryParseBitDepth",
                BindingFlags.NonPublic | BindingFlags.Static);
            Assert.Equal(-1, method.Invoke(null, new object[] { "yuv420p" }));
            Assert.Equal(-1, method.Invoke(null, new object[] { "" }));
            Assert.Equal(-1, method.Invoke(null, new object[] { "nv12" }));
        }
    }

    /// <summary>
    /// The testable video reader class
    /// </summary>
    /// <seealso cref="VideoReader"/>
    public class TestableVideoReader : VideoReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestableVideoReader"/> class
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="ffmpeg">The ffmpeg</param>
        /// <param name="ffprobe">The ffprobe</param>
        public TestableVideoReader(string filename, string ffmpeg = "ffmpeg", string ffprobe = "ffprobe")
            : base(filename, ffmpeg, ffprobe) { }

        /// <summary>
        /// Sets the opened for reading using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public void SetOpenedForReading(bool value) => OpenedForReading = value;
        /// <summary>
        /// Sets the data stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        public void SetDataStream(Stream stream) => DataStream = stream;
    }
}
