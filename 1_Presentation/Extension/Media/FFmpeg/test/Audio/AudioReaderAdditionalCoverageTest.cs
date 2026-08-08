using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    /// The audio reader additional coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioReaderAdditionalCoverageTest : IDisposable
    {
        /// <summary>
        /// The temp file
        /// </summary>
        private readonly string _tempFile;
        /// <summary>
        /// The real audio file
        /// </summary>
        private readonly string _realAudioFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioReaderAdditionalCoverageTest"/> class
        /// </summary>
        public AudioReaderAdditionalCoverageTest()
        {
            _tempFile = Path.GetTempFileName();
            _realAudioFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets", "horse.mp3");
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
        }

        /// <summary>
        /// Tests that load metadata should work
        /// </summary>
        [RequireFfmpegFact]
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

        /// <summary>
        /// Tests that load metadata async with real audio should populate metadata
        /// </summary>
        [RequireFfmpegFact]
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

        /// <summary>
        /// Tests that load metadata async with ignore stream errors should succeed
        /// </summary>
        [RequireFfmpegFact]
        public async Task LoadMetadataAsync_WithIgnoreStreamErrors_ShouldSucceed()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            Exception ex = await Record.ExceptionAsync(() => reader.LoadMetadataAsync(ignoreStreamErrors: true));
            Assert.Null(ex);
            Assert.True(reader.MetadataLoaded);
        }

        /// <summary>
        /// Tests that load metadata async when already loaded should throw
        /// </summary>
        [RequireFfmpegFact]
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

        /// <summary>
        /// Tests that load metadata async with non existent ffprobe should throw
        /// </summary>
        [RequireFfmpegFact]
        public async Task LoadMetadataAsync_WithNonExistentFfprobe_ShouldThrow()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile, "ffmpeg", "ffprobe-nonexistent");
            InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => reader.LoadMetadataAsync());
            Assert.Contains("Failed to interpret ffprobe", ex.Message);
        }

        /// <summary>
        /// Tests that load metadata with non existent ffprobe should throw
        /// </summary>
        [RequireFfmpegFact]
        public void LoadMetadata_WithNonExistentFfprobe_ShouldThrow()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile, "ffmpeg", "ffprobe-nonexistent");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => reader.LoadMetadata());
            Assert.Contains("Failed to interpret ffprobe", ex.Message);
        }

        /// <summary>
        /// Tests that load after metadata load should open data stream
        /// </summary>
        [RequireFfmpegFact]
        public void Load_AfterMetadataLoad_ShouldOpenDataStream()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadata();
            reader.Load(16);
            Assert.True(reader.OpenedForReading);
        }

        /// <summary>
        /// Tests that load with bit depth 24 should work
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithBitDepth24_ShouldWork()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadata();
            reader.Load(24);
            Assert.True(reader.OpenedForReading);
        }

        /// <summary>
        /// Tests that load with bit depth 32 should work
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithBitDepth32_ShouldWork()
        {
            if (!File.Exists(_realAudioFile))
                return;

            using AudioReader reader = new AudioReader(_realAudioFile);
            reader.LoadMetadata();
            reader.Load(32);
            Assert.True(reader.OpenedForReading);
        }

        /// <summary>
        /// Tests that metadata loaded default should be false
        /// </summary>
        [RequireFfmpegFact]
        public void MetadataLoaded_Default_ShouldBeFalse()
        {
            using AudioReader reader = new AudioReader(_tempFile);
            Assert.False(reader.MetadataLoaded);
        }

        /// <summary>
        /// Tests that metadata default should be null
        /// </summary>
        [RequireFfmpegFact]
        public void Metadata_Default_ShouldBeNull()
        {
            using AudioReader reader = new AudioReader(_tempFile);
            Assert.Null(reader.Metadata);
        }
    }
}
