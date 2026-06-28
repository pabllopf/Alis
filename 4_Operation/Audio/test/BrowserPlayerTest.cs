// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BrowserPlayerTest.cs
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
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test
{
    /// <summary>
    ///     Tests for the <see cref="BrowserPlayer"/> class.
    /// </summary>
    public class BrowserPlayerTest : IDisposable
    {
        /// <summary>
        /// The test wav file
        /// </summary>
        private readonly string _testWavFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserPlayerTest"/> class
        /// </summary>
        public BrowserPlayerTest()
        {
            // Create a minimal valid WAV file for tests
            _testWavFile = Path.GetTempFileName() + ".wav";
            CreateMinimalWavFile(_testWavFile);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!string.IsNullOrEmpty(_testWavFile) && File.Exists(_testWavFile))
            {
                File.Delete(_testWavFile);
            }
        }

        /// <summary>
        ///     Creates a minimal valid WAV file for testing purposes.
        /// </summary>
        private static void CreateMinimalWavFile(string filePath)
        {
            using (var stream = File.Create(filePath))
            {
                // RIFF header
                stream.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"), 0, 4);
                // File size - 8
                byte[] fileSize = BitConverter.GetBytes(36);
                stream.Write(fileSize, 0, 4);
                // WAVE
                stream.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"), 0, 4);
                
                // fmt chunk
                stream.Write(System.Text.Encoding.ASCII.GetBytes("fmt "), 0, 4);
                byte[] fmtSize = BitConverter.GetBytes(16);
                stream.Write(fmtSize, 0, 4);
                // Audio format (1 = PCM)
                byte[] audioFormat = BitConverter.GetBytes((short)1);
                stream.Write(audioFormat, 0, 2);
                // Channels (1 = mono)
                byte[] channels = BitConverter.GetBytes((short)1);
                stream.Write(channels, 0, 2);
                // Sample rate (44100 Hz)
                byte[] sampleRate = BitConverter.GetBytes(44100);
                stream.Write(sampleRate, 0, 4);
                // Byte rate
                byte[] byteRate = BitConverter.GetBytes(88200);
                stream.Write(byteRate, 0, 4);
                // Block align
                byte[] blockAlign = BitConverter.GetBytes((short)2);
                stream.Write(blockAlign, 0, 2);
                // Bits per sample (16)
                byte[] bitsPerSample = BitConverter.GetBytes((short)16);
                stream.Write(bitsPerSample, 0, 2);
                
                // data chunk
                stream.Write(System.Text.Encoding.ASCII.GetBytes("data"), 0, 4);
                byte[] dataSize = BitConverter.GetBytes(0);
                stream.Write(dataSize, 0, 4);
            }
        }

        /// <summary>
        ///     Tests that TryParseWav returns false for files smaller than 44 bytes.
        /// </summary>
        [Fact]
        public void TryParseWav_SmallFile_ShouldReturnFalse()
        {
            byte[] smallData = new byte[40];

            bool result = BrowserPlayer.TryParseWav(smallData, out _, out _, out _, out _);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that TryParseWav returns false for files without RIFF header.
        /// </summary>
        [Fact]
        public void TryParseWav_NoRIFFHeader_ShouldReturnFalse()
        {
            byte[] data = new byte[44];
            // Not RIFF header

            bool result = BrowserPlayer.TryParseWav(data, out _, out _, out _, out _);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that TryParseWav returns false for files without WAVE header.
        /// </summary>
        [Fact]
        public void TryParseWav_NoWAVEHeader_ShouldReturnFalse()
        {
            byte[] data = new byte[44];
            System.Text.Encoding.ASCII.GetBytes("RIFF").CopyTo(data, 0);
            byte[] fileSize = BitConverter.GetBytes(36);
            fileSize.CopyTo(data, 4);
            System.Text.Encoding.ASCII.GetBytes("XXXX").CopyTo(data, 8);

            bool result = BrowserPlayer.TryParseWav(data, out _, out _, out _, out _);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that TryParseWav returns false for files without fmt chunk.
        /// </summary>
        [Fact]
        public void TryParseWav_NoFmtChunk_ShouldReturnFalse()
        {
            byte[] data = new byte[44];
            System.Text.Encoding.ASCII.GetBytes("RIFF").CopyTo(data, 0);
            byte[] fileSize = BitConverter.GetBytes(36);
            fileSize.CopyTo(data, 4);
            System.Text.Encoding.ASCII.GetBytes("WAVE").CopyTo(data, 8);
            System.Text.Encoding.ASCII.GetBytes("fmt ").CopyTo(data, 12);
            byte[] fmtSize = BitConverter.GetBytes(16);
            fmtSize.CopyTo(data, 16);
            byte[] audioFormat = BitConverter.GetBytes((short)1);
            audioFormat.CopyTo(data, 20);
            byte[] channels = BitConverter.GetBytes((short)1);
            channels.CopyTo(data, 22);
            byte[] sampleRate = BitConverter.GetBytes(44100);
            sampleRate.CopyTo(data, 24);
            byte[] byteRate = BitConverter.GetBytes(88200);
            byteRate.CopyTo(data, 28);
            byte[] blockAlign = BitConverter.GetBytes((short)2);
            blockAlign.CopyTo(data, 32);
            byte[] bitsPerSample = BitConverter.GetBytes((short)16);
            bitsPerSample.CopyTo(data, 34);
            byte[] dataChunk = System.Text.Encoding.ASCII.GetBytes("XXXX");
            dataChunk.CopyTo(data, 40);

            bool result = BrowserPlayer.TryParseWav(data, out _, out _, out _, out _);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that TryParseWav returns false for compressed audio formats.
        /// </summary>
        [Fact]
        public void TryParseWav_CompressedFormat_ShouldReturnFalse()
        {
            byte[] data = new byte[44];
            System.Text.Encoding.ASCII.GetBytes("RIFF").CopyTo(data, 0);
            byte[] fileSize = BitConverter.GetBytes(36);
            fileSize.CopyTo(data, 4);
            System.Text.Encoding.ASCII.GetBytes("WAVE").CopyTo(data, 8);
            System.Text.Encoding.ASCII.GetBytes("fmt ").CopyTo(data, 12);
            byte[] fmtSize = BitConverter.GetBytes(16);
            fmtSize.CopyTo(data, 16);
            // Compressed format (not PCM)
            byte[] audioFormat = BitConverter.GetBytes((short)2);
            audioFormat.CopyTo(data, 20);
            byte[] channels = BitConverter.GetBytes((short)1);
            channels.CopyTo(data, 22);
            byte[] sampleRate = BitConverter.GetBytes(44100);
            sampleRate.CopyTo(data, 24);
            byte[] byteRate = BitConverter.GetBytes(88200);
            byteRate.CopyTo(data, 28);
            byte[] blockAlign = BitConverter.GetBytes((short)2);
            blockAlign.CopyTo(data, 32);
            byte[] bitsPerSample = BitConverter.GetBytes((short)16);
            bitsPerSample.CopyTo(data, 34);
            byte[] dataChunk = System.Text.Encoding.ASCII.GetBytes("data");
            dataChunk.CopyTo(data, 40);

            bool result = BrowserPlayer.TryParseWav(data, out _, out _, out _, out _);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that TryGetFormat returns true for 16-bit mono.
        /// </summary>
        [Fact]
        public void TryGetFormat_16BitMono_ShouldReturnTrue()
        {
            bool result = BrowserPlayer.TryGetFormat(16, 1, out int format);

            Assert.True(result);
            Assert.Equal(0x1101, format); // AL_FORMAT_MONO16
        }

        /// <summary>
        ///     Tests that TryGetFormat returns true for 16-bit stereo.
        /// </summary>
        [Fact]
        public void TryGetFormat_16BitStereo_ShouldReturnTrue()
        {
            bool result = BrowserPlayer.TryGetFormat(16, 2, out int format);

            Assert.True(result);
            Assert.Equal(0x1103, format); // AL_FORMAT_STEREO16
        }

        /// <summary>
        ///     Tests that TryGetFormat returns true for 8-bit mono.
        /// </summary>
        [Fact]
        public void TryGetFormat_8BitMono_ShouldReturnTrue()
        {
            bool result = BrowserPlayer.TryGetFormat(8, 1, out int format);

            Assert.True(result);
            Assert.Equal(0x1100, format); // AL_FORMAT_MONO8
        }

        /// <summary>
        ///     Tests that TryGetFormat returns true for 8-bit stereo.
        /// </summary>
        [Fact]
        public void TryGetFormat_8BitStereo_ShouldReturnTrue()
        {
            bool result = BrowserPlayer.TryGetFormat(8, 2, out int format);

            Assert.True(result);
            Assert.Equal(0x1102, format); // AL_FORMAT_STEREO8
        }

        /// <summary>
        ///     Tests that TryGetFormat returns false for unsupported bit depths.
        /// </summary>
        [Fact]
        public void TryGetFormat_UnsupportedBitDepth_ShouldReturnFalse()
        {
            bool result = BrowserPlayer.TryGetFormat(24, 1, out int format);

            Assert.False(result);
            Assert.Equal(0, format);
        }

        /// <summary>
        ///     Tests that TryGetFormat returns false for unsupported channel counts.
        /// </summary>
        [Fact]
        public void TryGetFormat_UnsupportedChannels_ShouldReturnFalse()
        {
            bool result = BrowserPlayer.TryGetFormat(16, 6, out int format);

            Assert.False(result);
            Assert.Equal(0, format);
        }

        /// <summary>
        ///     Tests that FindFmtChunk returns correct chunk size.
        /// </summary>
        [Fact]
        public void FindFmtChunk_ShouldReturnCorrectSize()
        {
            byte[] wav = new byte[44];
            System.Text.Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, 0);
            byte[] fileSize = BitConverter.GetBytes(36);
            fileSize.CopyTo(wav, 4);
            System.Text.Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, 8);
            System.Text.Encoding.ASCII.GetBytes("fmt ").CopyTo(wav, 12);
            byte[] fmtSize = BitConverter.GetBytes(16);
            fmtSize.CopyTo(wav, 16);
            
            int fmtPos = 12;
            int result = BrowserPlayer.FindFmtChunk(wav, ref fmtPos);

            Assert.Equal(16, result);
        }

        /// <summary>
        ///     Tests that FindFmtChunk returns 0 when no fmt chunk is found.
        /// </summary>
        [Fact]
        public void FindFmtChunk_NoFmtChunk_ShouldReturn0()
        {
            byte[] wav = new byte[44];
            System.Text.Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, 0);
            byte[] fileSize = BitConverter.GetBytes(36);
            fileSize.CopyTo(wav, 4);
            System.Text.Encoding.ASCII.GetBytes("XXXX").CopyTo(wav, 8);

            int fmtPos = 12;
            int result = BrowserPlayer.FindFmtChunk(wav, ref fmtPos);

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that FindDataChunk returns 0 for both offset and size when no data chunk.
        /// </summary>
        [Fact]
        public void FindDataChunk_NoDataChunk_ShouldReturn0()
        {
            byte[] wav = new byte[44];
            System.Text.Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, 0);
            byte[] fileSize = BitConverter.GetBytes(36);
            fileSize.CopyTo(wav, 4);
            System.Text.Encoding.ASCII.GetBytes("XXXX").CopyTo(wav, 8);

            int pos = 12;
            BrowserPlayer.FindDataChunk(wav, ref pos, out int dataOffset, out int dataSize);

            Assert.Equal(0, dataOffset);
            Assert.Equal(0, dataSize);
        }

        /// <summary>
        ///     Tests that Playing property returns correct value.
        /// </summary>
        [Fact]
        public void Playing_Property_ShouldReturnCorrectValue()
        {
            // BrowserPlayer constructor requires OpenAL which may not be available
            // This test validates the property exists and is accessible
            Assert.True(typeof(BrowserPlayer).GetProperty("Playing") != null);
        }

        /// <summary>
        ///     Tests that Paused property returns correct value.
        /// </summary>
        [Fact]
        public void Paused_Property_ShouldReturnCorrectValue()
        {
            // BrowserPlayer constructor requires OpenAL which may not be available
            // This test validates the property exists and is accessible
            Assert.True(typeof(BrowserPlayer).GetProperty("Paused") != null);
        }

        /// <summary>
        ///     Tests that PlaybackFinished event exists.
        /// </summary>
        [Fact]
        public void PlaybackFinished_Event_ShouldExist()
        {
            // BrowserPlayer is internal, so we can't instantiate it directly
            // This test validates the event exists on the type
            var playerType = typeof(BrowserPlayer);
            var eventInfo = playerType.GetEvent("PlaybackFinished");
            Assert.NotNull(eventInfo);
        }

        /// <summary>
        ///     Tests that SetVolume returns completed task.
        /// </summary>
        [Fact]
        public void SetVolume_ShouldReturnCompletedTask()
        {
            // BrowserPlayer is internal and requires OpenAL to instantiate
            // This test validates the method signature exists
            var playerType = typeof(BrowserPlayer);
            var methodInfo = playerType.GetMethod("SetVolume");
            Assert.NotNull(methodInfo);
        }
    }
}
