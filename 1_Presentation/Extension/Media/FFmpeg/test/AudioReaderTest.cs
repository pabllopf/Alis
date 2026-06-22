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
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     Tests for the <see cref="AudioReader"/> class.
    /// </summary>
    public class AudioReaderTest : IDisposable
    {
        private readonly string _testFile;

        public AudioReaderTest()
        {
            // Create a temporary test file for tests that require file existence
            _testFile = Path.GetTempFileName();
            File.WriteAllText(_testFile, "test audio data");
        }

        public void Dispose()
        {
            if (!string.IsNullOrEmpty(_testFile) && File.Exists(_testFile))
            {
                File.Delete(_testFile);
            }
        }

        /// <summary>
        ///     Tests that the constructor throws FileNotFoundException for non-existent files.
        /// </summary>
        [Fact]
        public void Constructor_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            string nonExistentFile = "nonexistent_file.wav";

            Assert.Throws<FileNotFoundException>(() => new AudioReader(nonExistentFile));
        }

        /// <summary>
        ///     Tests that the constructor creates an AudioReader for existing files.
        /// </summary>
        [Fact]
        public void Constructor_WithExistingFile_ShouldNotThrow()
        {
            AudioReader reader = new AudioReader(_testFile);

            Assert.NotNull(reader);
        }

        /// <summary>
        ///     Tests that the constructor with custom executables creates an AudioReader.
        /// </summary>
        [Fact]
        public void Constructor_WithCustomExecutables_ShouldNotThrow()
        {
            AudioReader reader = new AudioReader(_testFile, "custom_ffmpeg", "custom_ffprobe");

            Assert.NotNull(reader);
        }

        /// <summary>
        ///     Tests that CurrentSampleOffset defaults to 0.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeCurrentSampleOffsetTo0()
        {
            AudioReader reader = new AudioReader(_testFile);

            Assert.Equal(0, reader.CurrentSampleOffset);
        }

        /// <summary>
        ///     Tests that MetadataLoaded defaults to false.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeMetadataLoadedToFalse()
        {
            AudioReader reader = new AudioReader(_testFile);

            Assert.False(reader.MetadataLoaded);
        }

        /// <summary>
        ///     Tests that Metadata is null until loaded.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeMetadataToNull()
        {
            AudioReader reader = new AudioReader(_testFile);

            Assert.Null(reader.Metadata);
        }
        
        /// <summary>
        ///     Tests that AudioReader implements IDisposable.
        /// </summary>
        [Fact]
        public void AudioReader_ShouldImplementIDisposable()
        {
            AudioReader reader = new AudioReader(_testFile);

            Assert.IsAssignableFrom<IDisposable>(reader);
        }

        /// <summary>
        ///     Tests that Load() with invalid bit depth throws exception.
        /// </summary>
        [Fact]
        public void Load_WithInvalidBitDepth_ShouldThrowException()
        {
            AudioReader reader = new AudioReader(_testFile);

            // This test validates bit depth validation
            Assert.ThrowsAny<Exception>(() => reader.Load(20)); // 20 is not valid
        }

        /// <summary>
        ///     Tests that Load() without loading metadata first throws exception.
        /// </summary>
        [Fact]
        public void Load_WithoutLoadingMetadataFirst_ShouldThrowException()
        {
            AudioReader reader = new AudioReader(_testFile);

            // This test validates that metadata must be loaded before Load()
            Assert.ThrowsAny<Exception>(() => reader.Load(16));
        }

        /// <summary>
        ///     Tests that NextFrame() without loading audio throws exception.
        /// </summary>
        [Fact]
        public void NextFrame_WithoutLoadingAudio_ShouldThrowException()
        {
            AudioReader reader = new AudioReader(_testFile);

            // This test validates that audio must be loaded before reading frames
            Assert.ThrowsAny<Exception>(() => reader.NextFrame());
        }

        /// <summary>
        ///     Tests that ResolveBitDepth sets correct bit depth for 16-bit format.
        /// </summary>
        [Fact]
        public void ResolveBitDepth_ShouldSet16BitFor16BitFormat()
        {
            var metadata = new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata
            {
                BitDepth = 0,
                SampleFormat = "s16le"
            };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(16, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth sets correct bit depth for 32-bit format.
        /// </summary>
        [Fact]
        public void ResolveBitDepth_ShouldSet32BitFor32BitFormat()
        {
            var metadata = new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata
            {
                BitDepth = 0,
                SampleFormat = "s32le"
            };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(32, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth sets correct bit depth for 64-bit format.
        /// </summary>
        [Fact]
        public void ResolveBitDepth_ShouldSet64BitFor64BitFormat()
        {
            var metadata = new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata
            {
                BitDepth = 0,
                SampleFormat = "s64le"
            };

            AudioReader.ResolveBitDepth(metadata);

            Assert.Equal(64, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth handles unknown formats.
        /// </summary>
        [Fact]
        public void ResolveBitDepth_ShouldHandleUnknownFormats()
        {
            var metadata = new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata
            {
                BitDepth = 0,
                SampleFormat = "unknown_format"
            };

            AudioReader.ResolveBitDepth(metadata);

            // Bit depth should remain 0 for unknown formats
            Assert.Equal(0, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth does not modify already set bit depth.
        /// </summary>
        [Fact]
        public void ResolveBitDepth_ShouldNotModifyAlreadySetBitDepth()
        {
            var metadata = new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata
            {
                BitDepth = 24,
                SampleFormat = "s16le"
            };

            AudioReader.ResolveBitDepth(metadata);

            // Bit depth should remain 24 as it was already set
            Assert.Equal(24, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth handles null sample format.
        /// </summary>
        [Fact]
        public void ResolveBitDepth_ShouldHandleNullSampleFormat()
        {
            var metadata = new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata
            {
                BitDepth = 0,
                SampleFormat = null
            };

            AudioReader.ResolveBitDepth(metadata);

            // Bit depth should remain 0 for null sample format
            Assert.Equal(0, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that ResolveBitDepth handles empty sample format.
        /// </summary>
        [Fact]
        public void ResolveBitDepth_ShouldHandleEmptySampleFormat()
        {
            var metadata = new Alis.Extension.Media.FFmpeg.Audio.Models.AudioMetadata
            {
                BitDepth = 0,
                SampleFormat = ""
            };

            AudioReader.ResolveBitDepth(metadata);

            // Bit depth should remain 0 for empty sample format
            Assert.Equal(0, metadata.BitDepth);
        }
    }
}
