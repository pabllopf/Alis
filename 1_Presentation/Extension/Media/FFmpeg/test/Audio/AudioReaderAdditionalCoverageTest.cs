using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    public class AudioReaderAdditionalCoverageTest : IDisposable
    {
        private readonly string _tempFile;
        private readonly string _realAudioFile;

        public AudioReaderAdditionalCoverageTest()
        {
            _tempFile = Path.GetTempFileName();
            _realAudioFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets", "horse.mp3");
        }

        public void Dispose()
        {
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
        }

        [Fact]
        public void LoadMetadata_ShouldWork()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            Exception ex = Record.Exception(() => reader.LoadMetadata());
            Assert.Null(ex);
            Assert.True(reader.MetadataLoaded);
            Assert.NotNull(reader.Metadata);
        }

        [Fact]
        public async Task LoadMetadataAsync_WithRealAudio_ShouldPopulateMetadata()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            await reader.LoadMetadataAsync();

            Assert.True(reader.MetadataLoaded);
            Assert.NotNull(reader.Metadata);
            Assert.NotNull(reader.Metadata.Streams);
            Assert.True(reader.Metadata.Streams.Count > 0);
        }

        [Fact]
        public async Task LoadMetadataAsync_WithIgnoreStreamErrors_ShouldSucceed()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            Exception ex = await Record.ExceptionAsync(() => reader.LoadMetadataAsync(ignoreStreamErrors: true));
            Assert.Null(ex);
            Assert.True(reader.MetadataLoaded);
        }

        [Fact]
        public void LoadMetadataAsync_WhenAlreadyLoaded_ShouldThrow()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadata();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => reader.LoadMetadataAsync().Wait());
            Assert.Contains("already loaded", ex.Message);
        }

        [Fact]
        public async Task LoadMetadataAsync_WithNonExistentFfprobe_ShouldThrow()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile, "ffmpeg", "ffprobe-nonexistent");
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => reader.LoadMetadataAsync());
            Assert.Contains("Failed to interpret ffprobe", ex.Message);
        }

        [Fact]
        public void LoadMetadata_WithNonExistentFfprobe_ShouldThrow()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile, "ffmpeg", "ffprobe-nonexistent");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => reader.LoadMetadata());
            Assert.Contains("Failed to interpret ffprobe", ex.Message);
        }

        [Fact]
        public void Load_AfterMetadataLoad_ShouldOpenDataStream()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadata();
            reader.Load(16);
            Assert.True(reader.OpenedForReading);
        }

        [Fact]
        public void Load_WithBitDepth24_ShouldWork()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadata();
            reader.Load(24);
            Assert.True(reader.OpenedForReading);
        }

        [Fact]
        public void Load_WithBitDepth32_ShouldWork()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadata();
            reader.Load(32);
            Assert.True(reader.OpenedForReading);
        }

        [Fact]
        public void MetadataLoaded_Default_ShouldBeFalse()
        {
            using AudioReader reader = new AudioReader(_tempFile);
            Assert.False(reader.MetadataLoaded);
        }

        [Fact]
        public void Metadata_Default_ShouldBeNull()
        {
            using AudioReader reader = new AudioReader(_tempFile);
            Assert.Null(reader.Metadata);
        }
    }
}
