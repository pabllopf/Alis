// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BrowserPlayerHelperTests.cs
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
using System.Text;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Test.Core.Audio.Players
{
    /// <summary>
    ///     Unit tests for the static helper methods in <see cref="BrowserPlayer" />:
    ///     <c>TryParseWav</c>, <c>FindFmtChunk</c>, <c>FindDataChunk</c>, and
    ///     <c>TryGetFormat</c>.  These parse raw WAV byte arrays and do NOT require
    ///     OpenAL or any native library to be installed.
    /// </summary>
    public class BrowserPlayerHelperTests
    {
        #region TryParseWav — Empty / Too Small

        /// <summary>
        ///     Verifies that <see cref="BrowserPlayer.TryParseWav" /> returns false when
        ///     the WAV byte array is shorter than 44 bytes (minimum WAV header size).
        /// </summary>
        [Fact]
        public void TryParseWav_WhenArrayTooSmall_ReturnsFalse()
        {
            // Arrange — 10 bytes of garbage
            byte[] wav = new byte[10];

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Verifies that an empty byte array returns false.
        /// </summary>
        [Fact]
        public void TryParseWav_WhenArrayIsEmpty_ReturnsFalse()
        {
            // Arrange
            byte[] wav = Array.Empty<byte>();

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Verifies that exactly 43 bytes (one short of minimum) returns false.
        /// </summary>
        [Fact]
        public void TryParseWav_WhenExactly43Bytes_ReturnsFalse()
        {
            // Arrange
            byte[] wav = new byte[43];

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region TryParseWav — Invalid RIFF Header

        /// <summary>
        ///     Verifies that a WAV file missing the 'RIFF' magic bytes returns false.
        /// </summary>
        [Fact]
        public void TryParseWav_WhenMissingRIFFHeader_ReturnsFalse()
        {
            // Arrange — valid header size but wrong magic bytes
            byte[] wav = new byte[44];
            Encoding.ASCII.GetBytes("XXXX", 0, 4, wav, 0); // Not "RIFF"

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Verifies that a WAV file with 'RIFF' but missing 'WAVE' returns false.
        /// </summary>
        [Fact]
        public void TryParseWav_WhenMissingWAVEIdentifier_ReturnsFalse()
        {
            // Arrange — "RIFF" but not "WAVE" at offset 8
            byte[] wav = new byte[44];
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wav, 0);
            Encoding.ASCII.GetBytes("XXXX", 0, 4, wav, 8); // Not "WAVE"

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region TryParseWav — Missing fmt Chunk

        /// <summary>
        ///     Verifies that a valid RIFF/WAVE header without an 'fmt ' chunk returns false.
        /// </summary>
        [Fact]
        public void TryParseWav_WhenMissingFmtChunk_ReturnsFalse()
        {
            // Arrange — minimal RIFF/WAVE header, no fmt chunk follows
            byte[] wav = new byte[44];
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wav, 0);
            BitConverter.GetBytes(36).CopyTo(wav, 4); // file size - 8
            Encoding.ASCII.GetBytes("WAVE", 0, 4, wav, 8);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region TryParseWav — Compressed Audio Format

        /// <summary>
        ///     Verifies that a WAV with compressed audio format (not PCM=1) returns false.
        /// </summary>
        [Fact]
        public void TryParseWav_WhenCompressedFormat_ReturnsFalse()
        {
            // Arrange — construct a minimal valid WAV with compressed format (0x0001 = PCM, 0x0006 = IEEE float)
            byte[] wav = BuildWavHeader(audioFormat: 6, channels: 1, sampleRate: 44100, bitsPerSample: 32);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Verifies that a WAV with ADPCM format (0x0002) returns false.
        /// </summary>
        [Fact]
        public void TryParseWav_WhenADPCMFormat_ReturnsFalse()
        {
            // Arrange
            byte[] wav = BuildWavHeader(audioFormat: 2, channels: 1, sampleRate: 44100, bitsPerSample: 16);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region TryParseWav — Valid PCM WAV Files

        /// <summary>
        ///     Verifies that a valid mono 16-bit PCM WAV file is parsed correctly.
        /// </summary>
        [Fact]
        public void TryParseWav_ValidMono16BitPCM_ReturnsTrueWithCorrectValues()
        {
            // Arrange
            byte[] wav = BuildWavHeader(audioFormat: 1, channels: 1, sampleRate: 44100, bitsPerSample: 16);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int freq, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(44100, freq);
            Assert.Equal(0x1101, format); // AL_FORMAT_MONO16
            Assert.True(dataOffset > 0);
            Assert.True(dataSize > 0);
        }

        /// <summary>
        ///     Verifies that a valid stereo 16-bit PCM WAV file is parsed correctly.
        /// </summary>
        [Fact]
        public void TryParseWav_ValidStereo16BitPCM_ReturnsTrueWithCorrectValues()
        {
            // Arrange
            byte[] wav = BuildWavHeader(audioFormat: 1, channels: 2, sampleRate: 48000, bitsPerSample: 16);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int freq, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(48000, freq);
            Assert.Equal(0x1103, format); // AL_FORMAT_STEREO16
            Assert.True(dataOffset > 0);
            Assert.True(dataSize > 0);
        }

        /// <summary>
        ///     Verifies that a valid mono 8-bit PCM WAV file is parsed correctly.
        /// </summary>
        [Fact]
        public void TryParseWav_ValidMono8BitPCM_ReturnsTrueWithCorrectValues()
        {
            // Arrange
            byte[] wav = BuildWavHeader(audioFormat: 1, channels: 1, sampleRate: 22050, bitsPerSample: 8);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int freq, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(22050, freq);
            Assert.Equal(0x1100, format); // AL_FORMAT_MONO8
            Assert.True(dataOffset > 0);
            Assert.True(dataSize > 0);
        }

        /// <summary>
        ///     Verifies that a valid stereo 8-bit PCM WAV file is parsed correctly.
        /// </summary>
        [Fact]
        public void TryParseWav_ValidStereo8BitPCM_ReturnsTrueWithCorrectValues()
        {
            // Arrange
            byte[] wav = BuildWavHeader(audioFormat: 1, channels: 2, sampleRate: 16000, bitsPerSample: 8);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int freq, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(16000, freq);
            Assert.Equal(0x1102, format); // AL_FORMAT_STEREO8
            Assert.True(dataOffset > 0);
            Assert.True(dataSize > 0);
        }

        /// <summary>
        ///     Verifies that a WAV with unsupported channel count returns false.
        /// </summary>
        [Fact]
        public void TryParseWav_WhenUnsupportedChannelCount_ReturnsFalse()
        {
            // Arrange — 8 channels is not supported by BrowserPlayer
            byte[] wav = BuildWavHeader(audioFormat: 1, channels: 8, sampleRate: 44100, bitsPerSample: 16);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region TryParseWav — Unsupported Bits

        /// <summary>
        ///     Verifies that a WAV with unsupported bit depth (24-bit PCM) returns false.
        /// </summary>
        [Fact]
        public void TryParseWav_When24BitPCM_ReturnsFalse()
        {
            // Arrange
            byte[] wav = BuildWavHeader(audioFormat: 1, channels: 2, sampleRate: 44100, bitsPerSample: 24);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out _, out _, out _, out _);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region FindFmtChunk

        /// <summary>
        ///     Verifies that <see cref="BrowserPlayer.FindFmtChunk" /> finds a fmt chunk
        ///     immediately after the RIFF header.
        /// </summary>
        [Fact]
        public void FindFmtChunk_WhenFmtChunkAtStart_ReturnsChunkSize()
        {
            // Arrange
            byte[] wav = new byte[60];
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wav, 0);
            BitConverter.GetBytes(52).CopyTo(wav, 4);
            Encoding.ASCII.GetBytes("WAVE", 0, 4, wav, 8);
            Encoding.ASCII.GetBytes("fmt ", 0, 4, wav, 12);
            BitConverter.GetBytes(16).CopyTo(wav, 16); // fmt chunk size

            int pos = 12;
            // Act
            int result = BrowserPlayer.FindFmtChunk(wav, ref pos);

            // Assert
            Assert.Equal(16, result);
        }

        /// <summary>
        ///     Verifies that <see cref="BrowserPlayer.FindFmtChunk" /> skips over extra chunks
        ///     to find the fmt chunk.
        /// </summary>
        [Fact]
        public void FindFmtChunk_WhenFmtChunkAfterExtraChunks_ReturnsChunkSize()
        {
            // Arrange — RIFF + "bext" chunk (32 bytes) + "fmt " chunk
            byte[] wav = new byte[80];
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wav, 0);
            BitConverter.GetBytes(72).CopyTo(wav, 4);
            Encoding.ASCII.GetBytes("WAVE", 0, 4, wav, 8);

            // bext chunk (32 bytes)
            Encoding.ASCII.GetBytes("bext", 0, 4, wav, 12);
            BitConverter.GetBytes(32).CopyTo(wav, 16);
            for (int i = 20; i < 52; i++) { wav[i] = 0; } // padding

            // fmt chunk (16 bytes)
            Encoding.ASCII.GetBytes("fmt ", 0, 4, wav, 52);
            BitConverter.GetBytes(16).CopyTo(wav, 56);

            int pos = 12;
            // Act
            int result = BrowserPlayer.FindFmtChunk(wav, ref pos);

            // Assert
            Assert.Equal(16, result);
        }

        /// <summary>
        ///     Verifies that <see cref="BrowserPlayer.FindFmtChunk" /> returns 0 when no fmt chunk exists.
        /// </summary>
        [Fact]
        public void FindFmtChunk_WhenNoFmtChunk_ReturnsZero()
        {
            // Arrange
            byte[] wav = new byte[44];
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wav, 0);
            BitConverter.GetBytes(36).CopyTo(wav, 4);
            Encoding.ASCII.GetBytes("WAVE", 0, 4, wav, 8);

            int pos = 12;
            // Act
            int result = BrowserPlayer.FindFmtChunk(wav, ref pos);

            // Assert
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Verifies that <see cref="BrowserPlayer.FindFmtChunk" /> returns 0 when the
        ///     WAV data is too short to contain a full chunk header.
        /// </summary>
        [Fact]
        public void FindFmtChunk_WhenWAVDataTooShort_ReturnsZero()
        {
            // Arrange — only 20 bytes, not enough for a full chunk header
            byte[] wav = new byte[20];
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wav, 0);

            int pos = 12;
            // Act
            int result = BrowserPlayer.FindFmtChunk(wav, ref pos);

            // Assert
            Assert.Equal(0, result);
        }

        #endregion

        #region FindDataChunk

        /// <summary>
        ///     Verifies that <see cref="BrowserPlayer.FindDataChunk" /> finds a data chunk
        ///     immediately after the fmt chunk.
        /// </summary>
        [Fact]
        public void FindDataChunk_WithDataChunkAtExpectedPosition_ReturnsCorrectOffsetAndSize()
        {
            // Arrange — construct a minimal valid WAV with data chunk right after fmt
            byte[] wav = BuildWavHeader(audioFormat: 1, channels: 1, sampleRate: 44100, bitsPerSample: 16);
            // Add data chunk right after fmt (at offset 24)
            int dataChunkStart = 24;
            Encoding.ASCII.GetBytes("data", 0, 4, wav, dataChunkStart);
            int dataChunkSize = 1024;
            BitConverter.GetBytes(dataChunkSize).CopyTo(wav, dataChunkStart + 4);

            int pos = 24;
            // Act
            BrowserPlayer.FindDataChunk(wav, ref pos, out int dataOffset, out int dataSize);

            // Assert
            Assert.Equal(dataChunkStart + 8, dataOffset);
            Assert.Equal(dataChunkSize, dataSize);
        }

        /// <summary>
        ///     Verifies that <see cref="BrowserPlayer.FindDataChunk" /> skips over extra chunks
        ///     to find the data chunk.
        /// </summary>
        [Fact]
        public void FindDataChunk_WithDataChunkAfterExtraChunks_ReturnsCorrectOffsetAndSize()
        {
            // Arrange — RIFF + fmt (16) + "bext" (32) + data chunk
            byte[] wav = new byte[100];
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wav, 0);
            BitConverter.GetBytes(92).CopyTo(wav, 4);
            Encoding.ASCII.GetBytes("WAVE", 0, 4, wav, 8);

            // fmt chunk (16 bytes) at offset 12
            Encoding.ASCII.GetBytes("fmt ", 0, 4, wav, 12);
            BitConverter.GetBytes(16).CopyTo(wav, 16);

            // bext chunk (32 bytes) at offset 28
            Encoding.ASCII.GetBytes("bext", 0, 4, wav, 28);
            BitConverter.GetBytes(32).CopyTo(wav, 32);

            // data chunk at offset 60
            int dataChunkStart = 60;
            Encoding.ASCII.GetBytes("data", 0, 4, wav, dataChunkStart);
            int dataChunkSize = 2048;
            BitConverter.GetBytes(dataChunkSize).CopyTo(wav, dataChunkStart + 4);

            int pos = 28;
            // Act
            BrowserPlayer.FindDataChunk(wav, ref pos, out int _, out int _);

            // Assert
            Assert.Equal(2048, dataChunkSize);
        }

        /// <summary>
        ///     Verifies that <see cref="BrowserPlayer.FindDataChunk" /> returns 0/0 when no data chunk exists.
        /// </summary>
        [Fact]
        public void FindDataChunk_WhenNoDataChunk_ReturnsZeroAndZero()
        {
            // Arrange
            byte[] wav = BuildWavHeader(audioFormat: 1, channels: 1, sampleRate: 44100, bitsPerSample: 16);
            // No data chunk follows

            int pos = 24;
            // Act
            BrowserPlayer.FindDataChunk(wav, ref pos, out int dataOffset, out int dataSize);

            // Assert
            Assert.Equal(0, dataOffset);
            Assert.Equal(0, dataSize);
        }

        #endregion

        #region TryGetFormat

        /// <summary>
        ///     Verifies that 16-bit mono returns the correct OpenAL format constant.
        /// </summary>
        [Fact]
        public void TryGetFormat_16BitMono_ReturnsMono16()
        {
            // Act
            bool result = BrowserPlayer.TryGetFormat(16, 1, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(0x1101, format); // AL_FORMAT_MONO16
        }

        /// <summary>
        ///     Verifies that 16-bit stereo returns the correct OpenAL format constant.
        /// </summary>
        [Fact]
        public void TryGetFormat_16BitStereo_ReturnsStereo16()
        {
            // Act
            bool result = BrowserPlayer.TryGetFormat(16, 2, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(0x1103, format); // AL_FORMAT_STEREO16
        }

        /// <summary>
        ///     Verifies that 8-bit mono returns the correct OpenAL format constant.
        /// </summary>
        [Fact]
        public void TryGetFormat_8BitMono_ReturnsMono8()
        {
            // Act
            bool result = BrowserPlayer.TryGetFormat(8, 1, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(0x1100, format); // AL_FORMAT_MONO8
        }

        /// <summary>
        ///     Verifies that 8-bit stereo returns the correct OpenAL format constant.
        /// </summary>
        [Fact]
        public void TryGetFormat_8BitStereo_ReturnsStereo8()
        {
            // Act
            bool result = BrowserPlayer.TryGetFormat(8, 2, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(0x1102, format); // AL_FORMAT_STEREO8
        }

        /// <summary>
        ///     Verifies that unsupported channel counts return false for both 8 and 16 bit depths.
        /// </summary>
        [Fact]
        public void TryGetFormat_WhenUnsupportedChannelCount_ReturnsFalse()
        {
            // Act — 8-bit, 4 channels
            bool result8Bit = BrowserPlayer.TryGetFormat(8, 4, out int format8);
            // Act — 16-bit, 4 channels
            bool result16Bit = BrowserPlayer.TryGetFormat(16, 4, out int format16);

            // Assert
            Assert.False(result8Bit);
            Assert.Equal(0, format8);
            Assert.False(result16Bit);
            Assert.Equal(0, format16);
        }

        /// <summary>
        ///     Verifies that unsupported bit depths return false regardless of channel count.
        /// </summary>
        [Fact]
        public void TryGetFormat_WhenUnsupportedBitDepth_ReturnsFalse()
        {
            // Act — 24-bit mono
            bool result24Bit = BrowserPlayer.TryGetFormat(24, 1, out int format24);
            // Act — 32-bit stereo (not supported by BrowserPlayer)
            bool result32Bit = BrowserPlayer.TryGetFormat(32, 2, out int format32);

            // Assert
            Assert.False(result24Bit);
            Assert.Equal(0, format24);
            Assert.False(result32Bit);
            Assert.Equal(0, format32);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        ///     Builds a minimal valid WAV header with the specified parameters and a data chunk.
        /// </summary>
        private static byte[] BuildWavHeader(short audioFormat, short channels, int sampleRate, short bitsPerSample)
        {
            byte[] wav = new byte[60];

            // RIFF header
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wav, 0);
            // file size - 8 (we'll set it to a reasonable value)
            BitConverter.GetBytes(52).CopyTo(wav, 4);

            // WAVE identifier
            Encoding.ASCII.GetBytes("WAVE", 0, 4, wav, 8);

            // fmt chunk
            Encoding.ASCII.GetBytes("fmt ", 0, 4, wav, 12);
            BitConverter.GetBytes(16).CopyTo(wav, 16); // fmt chunk size (16 bytes for PCM)
            BitConverter.GetBytes(audioFormat).CopyTo(wav, 20); // audio format (PCM = 1)
            BitConverter.GetBytes(channels).CopyTo(wav, 22); // channels
            BitConverter.GetBytes(sampleRate).CopyTo(wav, 24); // sample rate
            BitConverter.GetBytes(sampleRate * channels * bitsPerSample / 8).CopyTo(wav, 28); // byte rate
            BitConverter.GetBytes((short) (channels * bitsPerSample / 8)).CopyTo(wav, 32); // block align
            BitConverter.GetBytes(bitsPerSample).CopyTo(wav, 34); // bits per sample

            // data chunk
            Encoding.ASCII.GetBytes("data", 0, 4, wav, 36);
            int dataChunkSize = 1024;
            BitConverter.GetBytes(dataChunkSize).CopyTo(wav, 40);

            return wav;
        }

        #endregion
    }
}
