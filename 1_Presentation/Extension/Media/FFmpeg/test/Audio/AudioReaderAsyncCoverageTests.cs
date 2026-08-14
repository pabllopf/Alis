using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Audio.Models;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    /// The audio reader async coverage tests class
    /// </summary>
    public class AudioReaderAsyncCoverageTests
    {
        /// <summary>
        /// The assets dir
        /// </summary>
        private const string AssetsDir = "../../../Assets";

        /// <summary>
        /// Gets the asset path using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The string</returns>
        private string GetAssetPath(string file) =>
            Path.GetFullPath(Path.Combine(AssetsDir, file));

        /// <summary>
        /// Tests that load metadata async with real audio file loads successfully
        /// </summary>
        [RequireFfmpegFact]
        public async Task LoadMetadataAsync_WithRealAudioFile_LoadsSuccessfully()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                await reader.LoadMetadataAsync().WaitAsync(TimeSpan.FromSeconds(30));

                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
            }
        }

        /// <summary>
        /// Tests that load metadata async with ogg file loads successfully
        /// </summary>
        [RequireFfmpegFact]
        public async Task LoadMetadataAsync_WithOggFile_LoadsSuccessfully()
        {
            string audioFile = GetAssetPath("horse.ogg");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                await reader.LoadMetadataAsync().WaitAsync(TimeSpan.FromSeconds(30));

                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
            }
        }

        /// <summary>
        /// Tests that load metadata with real audio file loads successfully
        /// </summary>
        [RequireFfmpegFact]
        public void LoadMetadata_WithRealAudioFile_LoadsSuccessfully()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                reader.LoadMetadata();
                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
            }
        }

        /// <summary>
        /// Tests that load metadata already loaded throws
        /// </summary>
        [RequireFfmpegFact]
        public void LoadMetadata_AlreadyLoaded_Throws()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                reader.LoadMetadata();
                Exception ex = Assert.ThrowsAny<Exception>(() => reader.LoadMetadata());
                Assert.NotNull(ex);
            }
        }

        /// <summary>
        /// Tests that load metadata async already loaded throws
        /// </summary>
        [RequireFfmpegFact]
        public async Task LoadMetadataAsync_AlreadyLoaded_Throws()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                await reader.LoadMetadataAsync().WaitAsync(TimeSpan.FromSeconds(30));
                Exception ex = await Assert.ThrowsAnyAsync<Exception>(() => reader.LoadMetadataAsync());
                Assert.NotNull(ex);
            }
        }

        /// <summary>
        /// Tests that load after metadata opens stream
        /// </summary>
        [RequireFfmpegFact]
        public void Load_AfterMetadata_OpensStream()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                reader.LoadMetadata();
                reader.Load(16);

                Assert.True(reader.OpenedForReading);
                Assert.NotNull(reader.DataStream);
            }
        }

        /// <summary>
        /// Tests that load without metadata throws
        /// </summary>
        [RequireFfmpegFact]
        public void Load_WithoutMetadata_Throws()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(16));
                Assert.Contains("metadata", ex.Message);
            }
        }

        /// <summary>
        /// Tests that load already loaded throws
        /// </summary>
        [RequireFfmpegFact]
        public void Load_AlreadyLoaded_Throws()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                reader.LoadMetadata();
                reader.Load(16);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(16));
                Assert.Contains("already loaded", ex.Message);
            }
        }

        /// <summary>
        /// Tests that load invalid bit depth throws
        /// </summary>
        [RequireFfmpegFact]
        public void Load_InvalidBitDepth_Throws()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(99));
                Assert.Contains("bit depth", ex.Message);
            }
        }

        /// <summary>
        /// Tests that next frame without load throws
        /// </summary>
        [RequireFfmpegFact]
        public void NextFrame_WithoutLoad_Throws()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                reader.LoadMetadata();
                Exception ex = Assert.ThrowsAny<Exception>(() => reader.NextFrame());
                Assert.NotNull(ex);
            }
        }

        /// <summary>
        /// Tests that resolve bit depth with various formats sets correct depth
        /// </summary>
        [RequireFfmpegFact]
        public void ResolveBitDepth_WithVariousFormats_SetsCorrectDepth()
        {
            Func<AudioMetadata> m = () => new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata();

            AudioMetadata md64 = m(); md64.SampleFormat = "s64"; AudioReader.ResolveBitDepth(md64); Assert.Equal(64, md64.BitDepth);
            AudioMetadata md32 = m(); md32.SampleFormat = "s32"; AudioReader.ResolveBitDepth(md32); Assert.Equal(32, md32.BitDepth);
            AudioMetadata md24 = m(); md24.SampleFormat = "s24"; AudioReader.ResolveBitDepth(md24); Assert.Equal(24, md24.BitDepth);
            AudioMetadata md16 = m(); md16.SampleFormat = "s16"; AudioReader.ResolveBitDepth(md16); Assert.Equal(16, md16.BitDepth);
            AudioMetadata md8 = m(); md8.SampleFormat = "u8"; AudioReader.ResolveBitDepth(md8); Assert.Equal(8, md8.BitDepth);
        }

        /// <summary>
        /// Tests that resolve bit depth when bit depth already set does not change
        /// </summary>
        [RequireFfmpegFact]
        public void ResolveBitDepth_WhenBitDepthAlreadySet_DoesNotChange()
        {
            Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata metadata =
                new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata { BitDepth = 24 };
            AudioReader.ResolveBitDepth(metadata);
            Assert.Equal(24, metadata.BitDepth);
        }

        /// <summary>
        /// Tests that resolve bit depth with empty sample format does not change
        /// </summary>
        [RequireFfmpegFact]
        public void ResolveBitDepth_WithEmptySampleFormat_DoesNotChange()
        {
            Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata metadata =
                new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata { BitDepth = 0, SampleFormat = "" };
            AudioReader.ResolveBitDepth(metadata);
            Assert.Equal(0, metadata.BitDepth);
        }

        /// <summary>
        /// Tests that constructor with non existent file throws
        /// </summary>
        [RequireFfmpegFact]
        public void Constructor_WithNonExistentFile_Throws()
        {
            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => new AudioReader("nonexistent_file.mp3"));
            Assert.NotNull(ex);
        }

        /// <summary>
        /// Tests that dispose should cleanup
        /// </summary>
        [RequireFfmpegFact]
        public void Dispose_ShouldCleanup()
        {
            string audioFile = GetAssetPath("horse.mp3");
            AudioReader reader = new AudioReader(audioFile);
            reader.Dispose();
            Assert.NotNull(reader);
        }
    }
}
