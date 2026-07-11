using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    public class AudioReaderAsyncCoverageTests
    {
        private const string AssetsDir = "../../../Assets";

        private string GetAssetPath(string file) =>
            Path.GetFullPath(Path.Combine(AssetsDir, file));

        [Fact]
        public async Task LoadMetadataAsync_WithRealAudioFile_LoadsSuccessfully()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile), $"Audio file not found: {audioFile}");

            using (AudioReader reader = new AudioReader(audioFile))
            {
                await reader.LoadMetadataAsync();

                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
                Assert.NotNull(reader.Metadata.Codec);
                Assert.NotNull(reader.Metadata.Format);
            }
        }

        [Fact]
        public async Task LoadMetadataAsync_WithOggFile_LoadsSuccessfully()
        {
            string audioFile = GetAssetPath("horse.ogg");
            Assert.True(File.Exists(audioFile), $"Audio file not found: {audioFile}");

            using (AudioReader reader = new AudioReader(audioFile))
            {
                await reader.LoadMetadataAsync();

                Assert.True(reader.MetadataLoaded);
                Assert.NotNull(reader.Metadata);
                Assert.NotNull(reader.Metadata.Codec);
                Assert.NotNull(reader.Metadata.Format);
            }
        }

        [Fact]
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

        [Fact]
        public void LoadMetadata_AlreadyLoaded_Throws()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                reader.LoadMetadata();

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.LoadMetadata());
                Assert.Contains("already loaded", ex.Message);
            }
        }

        [Fact]
        public async Task LoadMetadataAsync_AlreadyLoaded_Throws()
        {
            string audioFile = GetAssetPath("horse.mp3");
            Assert.True(File.Exists(audioFile));

            using (AudioReader reader = new AudioReader(audioFile))
            {
                await reader.LoadMetadataAsync();

                InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(
                    () => reader.LoadMetadataAsync());
                Assert.Contains("already loaded", ex.Message);
            }
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void ResolveBitDepth_WithVariousFormats_SetsCorrectDepth()
        {
            var m = () => new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata();

            var md64 = m(); md64.SampleFormat = "s64"; AudioReader.ResolveBitDepth(md64); Assert.Equal(64, md64.BitDepth);
            var md32 = m(); md32.SampleFormat = "s32"; AudioReader.ResolveBitDepth(md32); Assert.Equal(32, md32.BitDepth);
            var md24 = m(); md24.SampleFormat = "s24"; AudioReader.ResolveBitDepth(md24); Assert.Equal(24, md24.BitDepth);
            var md16 = m(); md16.SampleFormat = "s16"; AudioReader.ResolveBitDepth(md16); Assert.Equal(16, md16.BitDepth);
            var md8 = m(); md8.SampleFormat = "u8"; AudioReader.ResolveBitDepth(md8); Assert.Equal(8, md8.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_WhenBitDepthAlreadySet_DoesNotChange()
        {
            Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata metadata =
                new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata { BitDepth = 24 };
            AudioReader.ResolveBitDepth(metadata);
            Assert.Equal(24, metadata.BitDepth);
        }

        [Fact]
        public void ResolveBitDepth_WithEmptySampleFormat_DoesNotChange()
        {
            Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata metadata =
                new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata { BitDepth = 0, SampleFormat = "" };
            AudioReader.ResolveBitDepth(metadata);
            Assert.Equal(0, metadata.BitDepth);
        }

        [Fact]
        public void Constructor_WithNonExistentFile_Throws()
        {
            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => new AudioReader("nonexistent_file.mp3"));
            Assert.NotNull(ex);
        }

        [Fact]
        public void Dispose_ShouldCleanup()
        {
            string audioFile = GetAssetPath("horse.mp3");
            AudioReader reader = new AudioReader(audioFile);
            reader.Dispose();
            Assert.NotNull(reader);
        }
    }
}
