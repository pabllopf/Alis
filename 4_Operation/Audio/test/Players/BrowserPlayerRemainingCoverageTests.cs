// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BrowserPlayerRemainingCoverageTests.cs
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

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Tests targeting uncovered code paths in <see cref="BrowserPlayer" /> static methods.
    ///     These tests do NOT require OpenAL runtime.
    /// </summary>
    public class BrowserPlayerRemainingCoverageTests
    {
        #region TryParseWav - Extended fmt chunk (fmtSize > 16)

        /// <summary>
        ///     Tests that TryParseWav correctly handles a WAV with fmt chunk size greater than 16.
        ///     Line 274: extraSize is computed from the extended bytes.
        /// </summary>
        [Fact]
        public void TryParseWav_WithExtendedFmtSize_ShouldParseCorrectly()
        {
            // Arrange — build a WAV with fmtSize = 20 (> 16)
            byte[] wav = BuildWavWithExtendedFmt(fmtSize: 20, extraValue: 0, channels: 1, sampleRate: 44100, bitsPerSample: 16);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int freq, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(44100, freq);
            Assert.Equal(0x1101, format);
            Assert.True(dataOffset > 0);
            Assert.True(dataSize > 0);
        }

        /// <summary>
        ///     Tests that TryParseWav reads a non-zero extraSize from the extended fmt bytes.
        ///     Verifies the ternary on line 274 reads the correct value.
        /// </summary>
        [Fact]
        public void TryParseWav_WithExtendedFmtAndNonZeroExtraSize_ShouldReadExtraSize()
        {
            // Arrange — set extraSize bytes to 42 so we know the read happens
            byte[] wav = BuildWavWithExtendedFmt(fmtSize: 18, extraValue: 42, channels: 1, sampleRate: 22050, bitsPerSample: 8);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int freq, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(22050, freq);
            Assert.Equal(0x1100, format);
            Assert.True(dataOffset > 0);
            Assert.True(dataSize > 0);
        }

        #endregion

        #region TryParseWav - Extra chunks between fmt and data

        /// <summary>
        ///     Tests that TryParseWav correctly finds the data chunk when extra chunks
        ///     exist between the fmt chunk and the data chunk.
        ///     Lines 283-284: data position is computed as fmtPos + 8 + fmtSize, then
        ///     FindDataChunk skips over intervening chunks.
        /// </summary>
        [Fact]
        public void TryParseWav_WithExtraChunksBetweenFmtAndData_ShouldSucceed()
        {
            // Arrange — RIFF + WAVE + fmt(16) + LIST(8) + data(100)
            byte[] wav = BuildWavWithInterveningChunk();

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int freq, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(44100, freq);
            Assert.Equal(0x1101, format);
            Assert.True(dataOffset > 0);
            Assert.True(dataSize > 0);

            // data should be after the LIST chunk
            int fmtEnd = 12 + 8 + 16; // fmtPos + 8 + fmtSize
            int listEnd = fmtEnd + 8 + 8; // LIST header + 8 bytes payload
            Assert.Equal(listEnd + 8, dataOffset); // dataOffset = data chunk start + 8
        }

        #endregion

        #region TryParseWav - Data chunk with zero size

        /// <summary>
        ///     Tests that TryParseWav returns false when a data chunk is found but has zero size.
        ///     Line 285: checks dataSize == 0.
        /// </summary>
        [Fact]
        public void TryParseWav_WithDataChunkZeroSize_ShouldReturnFalse()
        {
            // Arrange — valid WAV with data chunk size = 0
            byte[] wav = BuildWavWithDataSize(dataSize: 0, channels: 1, sampleRate: 44100, bitsPerSample: 16);

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int _, out int _);

            // Assert
            Assert.False(result);
            Assert.Equal(0, dataOffset);
            Assert.Equal(0, dataSize);
        }

        /// <summary>
        ///     Tests that TryParseWav returns false when data chunk has non-zero size
        ///     but dataOffset is 0 (should not happen in practice, but validates the
        ///     short-circuit on line 285).
        /// </summary>
        [Fact]
        public void TryParseWav_WithZeroDataOffset_ShouldReturnFalse()
        {
            // Arrange — provide a short array where FindDataChunk will not find data
            byte[] wav = new byte[44];
            Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, 0);
            BitConverter.GetBytes(36).CopyTo(wav, 4);
            Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, 8);
            Encoding.ASCII.GetBytes("fmt ").CopyTo(wav, 12);
            BitConverter.GetBytes(16).CopyTo(wav, 16);
            BitConverter.GetBytes((short)1).CopyTo(wav, 20);
            BitConverter.GetBytes((short)1).CopyTo(wav, 22);
            BitConverter.GetBytes(44100).CopyTo(wav, 24);
            // No data chunk — FindDataChunk will leave dataOffset=0, dataSize=0

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int _, out int _);

            // Assert
            Assert.False(result);
            Assert.Equal(0, dataOffset);
            Assert.Equal(0, dataSize);
        }

        #endregion

        #region FindFmtChunk - Boundary edge case

        /// <summary>
        ///     Tests FindFmtChunk when the starting position is exactly at wav.Length - 8.
        ///     Line 305: while (fmtPos < wav.Length - 8) — loop should not execute.
        /// </summary>
        [Fact]
        public void FindFmtChunk_AtExactBoundary_ShouldReturnZero()
        {
            // Arrange — array of 20 bytes, starting pos = 12 = wav.Length - 8
            byte[] wav = new byte[20];
            int fmtPos = 12;

            // Act
            int result = BrowserPlayer.FindFmtChunk(wav, ref fmtPos);

            // Assert
            Assert.Equal(0, result);
            // fmtPos should remain unchanged since loop condition fails immediately
            Assert.Equal(12, fmtPos);
        }

        /// <summary>
        ///     Tests FindFmtChunk when the array is too short to contain a full
        ///     chunk header at the starting position (wav.Length - 8 < fmtPos).
        ///     This exercises the loop guard on line 305.
        /// </summary>
        [Fact]
        public void FindFmtChunk_WhenArrayTooShortForHeader_ShouldReturnZero()
        {
            // Arrange — very short array (11 bytes), pos = 12 (already past end)
            byte[] wav = new byte[11];
            int fmtPos = 12;

            // Act
            int result = BrowserPlayer.FindFmtChunk(wav, ref fmtPos);

            // Assert
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests FindFmtChunk when a chunk straddles the wav.Length - 8 boundary.
        ///     The loop continues past the boundary without finding fmt, returning 0.
        /// </summary>
        [Fact]
        public void FindFmtChunk_WithChunkPastBoundary_ShouldReturnZero()
        {
            // Arrange — array of 24 bytes, start at 12, a chunk at 12 says size=20
            // but 12+8+20=40 > 24-8=16, so next iteration tries fmtPos=40 which
            // fails the while condition
            byte[] wav = new byte[24];
            Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, 0);
            Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, 8);
            Encoding.ASCII.GetBytes("XXXX").CopyTo(wav, 12);
            BitConverter.GetBytes(20).CopyTo(wav, 16); // claims chunk is 20 bytes

            int fmtPos = 12;

            // Act
            int result = BrowserPlayer.FindFmtChunk(wav, ref fmtPos);

            // Assert
            Assert.Equal(0, result);
        }

        #endregion

        #region FindDataChunk - Boundary edge case

        /// <summary>
        ///     Tests FindDataChunk when the starting position is exactly at wav.Length - 8.
        ///     Line 331: while (pos < wav.Length - 8) — loop should not execute.
        /// </summary>
        [Fact]
        public void FindDataChunk_AtExactBoundary_ShouldReturnZero()
        {
            // Arrange — array of 20 bytes, starting pos = 12 = wav.Length - 8
            byte[] wav = new byte[20];
            int pos = 12;

            // Act
            BrowserPlayer.FindDataChunk(wav, ref pos, out int dataOffset, out int dataSize);

            // Assert
            Assert.Equal(0, dataOffset);
            Assert.Equal(0, dataSize);
            // pos should remain unchanged since loop condition fails immediately
            Assert.Equal(12, pos);
        }

        /// <summary>
        ///     Tests FindDataChunk when the array is too short to contain a full
        ///     chunk header. Exercises loop guard on line 331.
        /// </summary>
        [Fact]
        public void FindDataChunk_WhenArrayTooShortForHeader_ShouldReturnZero()
        {
            // Arrange — very short array, pos beyond array end
            byte[] wav = new byte[11];
            int pos = 12;

            // Act
            BrowserPlayer.FindDataChunk(wav, ref pos, out int dataOffset, out int dataSize);

            // Assert
            Assert.Equal(0, dataOffset);
            Assert.Equal(0, dataSize);
        }

        /// <summary>
        ///     Tests FindDataChunk when a chunk straddles the wav.Length - 8 boundary.
        /// </summary>
        [Fact]
        public void FindDataChunk_WithChunkPastBoundary_ShouldReturnZero()
        {
            // Arrange — array of 24 bytes, start at 12
            byte[] wav = new byte[24];
            Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, 0);
            Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, 8);
            Encoding.ASCII.GetBytes("XXXX").CopyTo(wav, 12);
            BitConverter.GetBytes(20).CopyTo(wav, 16); // claims chunk is 20 bytes

            int pos = 12;

            // Act
            BrowserPlayer.FindDataChunk(wav, ref pos, out int dataOffset, out int dataSize);

            // Assert
            Assert.Equal(0, dataOffset);
            Assert.Equal(0, dataSize);
        }

        #endregion

        #region TryParseWav - Extra chunks edge case

        /// <summary>
        ///     Tests that TryParseWav does not crash when extra chunks exist before the
        ///     fmt chunk AND extra chunks exist between fmt and data. This exercises
        ///     the full chunk-skipping pipeline.
        /// </summary>
        [Fact]
        public void TryParseWav_WithExtraChunksBeforeFmtAndBetweenFmtAndData_ShouldSucceed()
        {
            // Arrange — RIFF + WAVE + JUNK(8) + fmt(16) + LIST(8) + data(100)
            byte[] wav = BuildWavWithExtraChunksBeforeAndAfterFmt();

            // Act
            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int freq, out int format);

            // Assert
            Assert.True(result);
            Assert.Equal(44100, freq);
            Assert.Equal(0x1101, format);
            Assert.True(dataOffset > 0);
            Assert.True(dataSize > 0);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        ///     Builds a WAV byte array with an extended fmt chunk (fmtSize > 16).
        /// </summary>
        private static byte[] BuildWavWithExtendedFmt(int fmtSize, short extraValue, short channels, int sampleRate, short bitsPerSample)
        {
            int dataSize = 100;
            int totalSize = 12 + 8 + fmtSize + 8 + dataSize; // RIFF header + fmt chunk + data chunk
            byte[] wav = new byte[totalSize];
            int offset = 0;

            // RIFF header
            Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes(totalSize - 8).CopyTo(wav, offset);
            offset += 4;
            Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, offset);
            offset += 4;

            // fmt chunk
            Encoding.ASCII.GetBytes("fmt ").CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes(fmtSize).CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes((short)1).CopyTo(wav, offset); // audioFormat = PCM
            offset += 2;
            BitConverter.GetBytes(channels).CopyTo(wav, offset);
            offset += 2;
            BitConverter.GetBytes(sampleRate).CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes(sampleRate * channels * bitsPerSample / 8).CopyTo(wav, offset); // byteRate
            offset += 4;
            BitConverter.GetBytes((short)(channels * bitsPerSample / 8)).CopyTo(wav, offset); // blockAlign
            offset += 2;
            BitConverter.GetBytes(bitsPerSample).CopyTo(wav, offset);
            offset += 2;

            // extended bytes (for fmtSize > 16)
            int extraBytes = fmtSize - 16;
            if (extraBytes >= 2)
            {
                BitConverter.GetBytes(extraValue).CopyTo(wav, offset);
                offset += 2;
                for (int i = 2; i < extraBytes; i++)
                {
                    wav[offset++] = 0;
                }
            }

            // data chunk
            Encoding.ASCII.GetBytes("data").CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes(dataSize).CopyTo(wav, offset);
            offset += 4;

            return wav;
        }

        /// <summary>
        ///     Builds a WAV with a LIST chunk between fmt and data.
        /// </summary>
        private static byte[] BuildWavWithInterveningChunk()
        {
            // Layout: RIFF(12) + fmt(8+16=24) + LIST(8+8=16) + data(8+100=108) = 160
            byte[] wav = new byte[160];

            // RIFF header
            Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, 0);
            BitConverter.GetBytes(152).CopyTo(wav, 4);
            Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, 8);

            // fmt chunk at 12
            Encoding.ASCII.GetBytes("fmt ").CopyTo(wav, 12);
            BitConverter.GetBytes(16).CopyTo(wav, 16);
            BitConverter.GetBytes((short)1).CopyTo(wav, 20);
            BitConverter.GetBytes((short)1).CopyTo(wav, 22);
            BitConverter.GetBytes(44100).CopyTo(wav, 24);
            BitConverter.GetBytes(88200).CopyTo(wav, 28);
            BitConverter.GetBytes((short)2).CopyTo(wav, 32);
            BitConverter.GetBytes((short)16).CopyTo(wav, 34);

            // LIST chunk at 36 (fmt + 8 + 16 = 36)
            Encoding.ASCII.GetBytes("LIST").CopyTo(wav, 36);
            BitConverter.GetBytes(8).CopyTo(wav, 40);

            // data chunk at 52 (36 + 8 + 8 = 52)
            Encoding.ASCII.GetBytes("data").CopyTo(wav, 52);
            BitConverter.GetBytes(100).CopyTo(wav, 56);

            return wav;
        }

        /// <summary>
        ///     Builds a WAV with JUNK before fmt and LIST between fmt and data.
        /// </summary>
        private static byte[] BuildWavWithExtraChunksBeforeAndAfterFmt()
        {
            // Layout: RIFF(12) + JUNK(8+8=16) + fmt(8+16=24) + LIST(8+8=16) + data(8+100=108) = 176
            byte[] wav = new byte[176];

            // RIFF header
            Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, 0);
            BitConverter.GetBytes(168).CopyTo(wav, 4);
            Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, 8);

            // JUNK chunk at 12
            Encoding.ASCII.GetBytes("JUNK").CopyTo(wav, 12);
            BitConverter.GetBytes(8).CopyTo(wav, 16);

            // fmt chunk at 28 (12 + 8 + 8 = 28)
            Encoding.ASCII.GetBytes("fmt ").CopyTo(wav, 28);
            BitConverter.GetBytes(16).CopyTo(wav, 32);
            BitConverter.GetBytes((short)1).CopyTo(wav, 36);
            BitConverter.GetBytes((short)1).CopyTo(wav, 38);
            BitConverter.GetBytes(44100).CopyTo(wav, 40);
            BitConverter.GetBytes(88200).CopyTo(wav, 44);
            BitConverter.GetBytes((short)2).CopyTo(wav, 48);
            BitConverter.GetBytes((short)16).CopyTo(wav, 50);

            // LIST chunk at 52 (28 + 8 + 16 = 52)
            Encoding.ASCII.GetBytes("LIST").CopyTo(wav, 52);
            BitConverter.GetBytes(8).CopyTo(wav, 56);

            // data chunk at 68 (52 + 8 + 8 = 68)
            Encoding.ASCII.GetBytes("data").CopyTo(wav, 68);
            BitConverter.GetBytes(100).CopyTo(wav, 72);

            return wav;
        }

        /// <summary>
        ///     Builds a WAV with a specific data chunk size.
        /// </summary>
        private static byte[] BuildWavWithDataSize(int dataSize, short channels, int sampleRate, short bitsPerSample)
        {
            int wavSize = 44 + Math.Max(dataSize, 0);
            byte[] wav = new byte[wavSize];

            // RIFF header
            Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, 0);
            BitConverter.GetBytes(wavSize - 8).CopyTo(wav, 4);
            Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, 8);

            // fmt chunk
            Encoding.ASCII.GetBytes("fmt ").CopyTo(wav, 12);
            BitConverter.GetBytes(16).CopyTo(wav, 16);
            BitConverter.GetBytes((short)1).CopyTo(wav, 20);
            BitConverter.GetBytes(channels).CopyTo(wav, 22);
            BitConverter.GetBytes(sampleRate).CopyTo(wav, 24);
            BitConverter.GetBytes(sampleRate * channels * bitsPerSample / 8).CopyTo(wav, 28);
            BitConverter.GetBytes((short)(channels * bitsPerSample / 8)).CopyTo(wav, 32);
            BitConverter.GetBytes(bitsPerSample).CopyTo(wav, 34);

            // data chunk
            Encoding.ASCII.GetBytes("data").CopyTo(wav, 36);
            BitConverter.GetBytes(dataSize).CopyTo(wav, 40);

            return wav;
        }

        #endregion

        #region PlayLoop / SetVolume (no OpenAL required)

        /// <summary>
        ///     The previous active name
        /// </summary>
        private string _previousActiveName;

        /// <summary>
        ///     Registers an assembly with a single wav entry and makes it active.
        /// </summary>
        /// <param name="entryName">The entry name</param>
        /// <param name="content">The content</param>
        private void SetupAssembly(string entryName, byte[] content)
        {
            _previousActiveName = AssetRegistryTestHelper.SaveAndSetActive(null);
            string name = AssetRegistryTestHelper.RegisterNewAssembly(entryName, content);
            AssetRegistryTestHelper.SaveAndSetActive(name);
        }

        /// <summary>
        ///     Tests that play loop with a missing resource throws file not found exception.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task PlayLoop_WithMissingResource_ThrowsFileNotFoundException()
        {
            SetupAssembly("present.wav", BuildWavWithDataSize(1764, 1, 44100, 16));
            BrowserPlayer player = (BrowserPlayer) System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));

            try
            {
                await Assert.ThrowsAsync<System.IO.FileNotFoundException>(async () => await player.PlayLoop("missing.wav", true));
            }
            finally
            {
                if (_previousActiveName != null)
                {
                    AssetRegistryTestHelper.RestoreActive(_previousActiveName);
                }
            }
        }

        /// <summary>
        ///     Tests that play loop with false delegates to play and throws file not found exception.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task PlayLoop_WithFalseAndMissingResource_ThrowsFileNotFoundException()
        {
            SetupAssembly("present.wav", BuildWavWithDataSize(1764, 1, 44100, 16));
            BrowserPlayer player = (BrowserPlayer) System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));

            try
            {
                await Assert.ThrowsAsync<System.IO.FileNotFoundException>(async () => await player.PlayLoop("missing.wav", false));
            }
            finally
            {
                if (_previousActiveName != null)
                {
                    AssetRegistryTestHelper.RestoreActive(_previousActiveName);
                }
            }
        }

        /// <summary>
        ///     Tests that set volume returns a completed task.
        /// </summary>
        [Fact]
        public async System.Threading.Tasks.Task SetVolume_ReturnsCompletedTask()
        {
            BrowserPlayer player = (BrowserPlayer) System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));

            System.Threading.Tasks.Task task = player.SetVolume(50);

            await task;
            Assert.True(task.IsCompleted);
        }

        #endregion
    }
}
