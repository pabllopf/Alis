// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioReaderTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Audio.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     The audio reader test class
    /// </summary>
    /// <seealso cref="AudioReader" />
    public class AudioReaderTest
    {
        /// <summary>
        ///     Tests that audio reader constructor should throw when file missing
        /// </summary>
        [Fact]
        public void AudioReader_Constructor_ShouldThrowWhenFileMissing()
        {
            string missing = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp3");

            Assert.Throws<FileNotFoundException>(() => new AudioReader(missing));
        }

        /// <summary>
        ///     Tests that audio reader constructor creates instance with valid file
        /// </summary>
        [Fact]
        public void AudioReader_Constructor_WithValidFile_ShouldCreateInstance()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                Assert.NotNull(reader);
                Assert.Equal(path, reader.Filename);
                Assert.False(reader.MetadataLoaded);
                Assert.Null(reader.Metadata);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that audio reader constructor accepts custom ffmpeg executable path
        /// </summary>
        [Fact]
        public void AudioReader_Constructor_WithCustomFfmpeg_ShouldAcceptPath()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path, "custom_ffmpeg", "custom_ffprobe");

                Assert.NotNull(reader);
                Assert.Equal(path, reader.Filename);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that audio reader constructor accepts custom ffprobe executable path
        /// </summary>
        [Fact]
        public void AudioReader_Constructor_WithCustomFfprobe_ShouldAcceptPath()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path, "ffmpeg", "custom_ffprobe");

                Assert.NotNull(reader);
                Assert.Equal(path, reader.Filename);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that audio reader load should throw for invalid bit depth
        /// </summary>
        [Fact]
        public void AudioReader_Load_ShouldThrowForInvalidBitDepth()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(8));

                Assert.Contains("Acceptable bit depths", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that audio reader load should throw when metadata not loaded
        /// </summary>
        [Fact]
        public void AudioReader_Load_ShouldThrowWhenMetadataNotLoaded()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load());

                Assert.Contains("load the audio metadata", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that audio reader load throws for bit depth 0
        /// </summary>
        [Fact]
        public void AudioReader_Load_WithBitDepthZero_ShouldThrowInvalidOperationException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(0));

                Assert.Contains("Acceptable bit depths", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that audio reader load throws for negative bit depth
        /// </summary>
        [Fact]
        public void AudioReader_Load_WithNegativeBitDepth_ShouldThrowInvalidOperationException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(-16));

                Assert.Contains("Acceptable bit depths", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that audio reader load throws for bit depth 64
        /// </summary>
        [Fact]
        public void AudioReader_Load_WithBitDepth64_ShouldThrowInvalidOperationException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.Load(64));

                Assert.Contains("Acceptable bit depths", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that audio reader dispose does not throw on fresh instance
        /// </summary>
        [Fact]
        public void AudioReader_Dispose_ShouldNotThrowOnFreshInstance()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                AudioReader reader = new(path);
                bool threw = false;

                try
                {
                    reader.Dispose();
                }
                catch
                {
                    threw = true;
                }

                Assert.False(threw);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that audio reader dispose can be called multiple times without throwing
        /// </summary>
        [Fact]
        public void AudioReader_MultipleDispose_ShouldNotThrow()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                AudioReader reader = new(path);
                bool threw = false;

                try
                {
                    reader.Dispose();
                    reader.Dispose();
                    reader.Dispose();
                }
                catch
                {
                    threw = true;
                }

                Assert.False(threw);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that NextFrame with AudioFrame parameter throws when audio is not loaded for reading
        /// </summary>
        [Fact]
        public void AudioReader_NextFrameWithFrame_WhenNotLoaded_ShouldThrowInvalidOperationException()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);
                AudioFrame frame = new(2, 1024, 16);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => reader.NextFrame(frame));

                Assert.Contains("load the audio", ex.Message);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that CurrentSampleOffset is initially zero
        /// </summary>
        [Fact]
        public void AudioReader_CurrentSampleOffset_InitialState_ShouldBeZero()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                Assert.Equal(0L, reader.CurrentSampleOffset);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that MetadataLoaded is initially false
        /// </summary>
        [Fact]
        public void AudioReader_MetadataLoaded_InitialState_ShouldBeFalse()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                Assert.False(reader.MetadataLoaded);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that Metadata is initially null
        /// </summary>
        [Fact]
        public void AudioReader_Metadata_InitialState_ShouldBeNull()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                Assert.Null(reader.Metadata);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that Filename property is correctly set after construction
        /// </summary>
        [Fact]
        public void AudioReader_Filename_ShouldBeSetByConstructor()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                Assert.Equal(path, reader.Filename);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
        /// <summary>
        ///     Tests that AudioReader implements IDisposable correctly
        /// </summary>
        [Fact]
        public void AudioReader_Idisposable_Implementation_ShouldNotThrow()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using (AudioReader reader = new(path))
                {
                    Assert.NotNull(reader);
                }
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that AudioReader with valid file has correct default state
        /// </summary>
        [Fact]
        public void AudioReader_WithValidFile_ShouldHaveCorrectDefaultState()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".wav");

            try
            {
                File.WriteAllBytes(path, new byte[] { 0 });

                using AudioReader reader = new(path);

                Assert.Equal(path, reader.Filename);
                Assert.False(reader.MetadataLoaded);
                Assert.Null(reader.Metadata);
                Assert.Equal(0L, reader.CurrentSampleOffset);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        ///     Tests that AudioReader constructor throws with correct message for missing file
        /// </summary>
        [Fact]
        public void AudioReader_Constructor_WithMissingFile_ShouldThrowFileNotFoundExceptionWithMessage()
        {
            string missing = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".mp3");

            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => new AudioReader(missing));

            Assert.Contains("not found", ex.Message);
            Assert.Contains(".mp3", ex.Message);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth returns early when bit depth already set
        /// </summary>
        [Fact]
        public void ResolveBitDepth_WhenBitDepthAlreadySet_ShouldNotChange()
        {
            AudioMetadata metadata = new AudioMetadata { BitDepth = 24, SampleFormat = "s16le" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(24, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth sets 64 for format containing 64
        /// </summary>
        [Fact]
        public void ResolveBitDepth_FormatContains64_ShouldSet64()
        {
            AudioMetadata metadata = new AudioMetadata { SampleFormat = "s64le" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(64, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth sets 32 for format containing 32
        /// </summary>
        [Fact]
        public void ResolveBitDepth_FormatContains32_ShouldSet32()
        {
            AudioMetadata metadata = new AudioMetadata { SampleFormat = "s32le" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(32, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth sets 24 for format containing 24
        /// </summary>
        [Fact]
        public void ResolveBitDepth_FormatContains24_ShouldSet24()
        {
            AudioMetadata metadata = new AudioMetadata { SampleFormat = "s24le" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(24, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth sets 16 for format containing 16
        /// </summary>
        [Fact]
        public void ResolveBitDepth_FormatContains16_ShouldSet16()
        {
            AudioMetadata metadata = new AudioMetadata { SampleFormat = "s16le" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(16, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth sets 8 for format containing 8
        /// </summary>
        [Fact]
        public void ResolveBitDepth_FormatContains8_ShouldSet8()
        {
            AudioMetadata metadata = new AudioMetadata { SampleFormat = "u8" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(8, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth leaves 0 for unknown format
        /// </summary>
        [Fact]
        public void ResolveBitDepth_UnknownFormat_ShouldLeaveZero()
        {
            AudioMetadata metadata = new AudioMetadata { SampleFormat = "fltp" };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(0, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth leaves 0 for null format
        /// </summary>
        [Fact]
        public void ResolveBitDepth_NullFormat_ShouldLeaveZero()
        {
            AudioMetadata metadata = new AudioMetadata { SampleFormat = null };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(0, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth leaves 0 for empty format
        /// </summary>
        [Fact]
        public void ResolveBitDepth_EmptyFormat_ShouldLeaveZero()
        {
            AudioMetadata metadata = new AudioMetadata { SampleFormat = string.Empty };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(0, metadata.BitDepth);
        }
    }
}
