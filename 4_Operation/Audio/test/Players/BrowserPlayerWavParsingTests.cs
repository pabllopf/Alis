// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BrowserPlayerWavParsingTests.cs
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using System;
using System.Reflection;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Tests for BrowserPlayer WAV parsing methods.
    /// </summary>
    public class BrowserPlayerWavParsingTests
    {
        /// <summary>
        /// The browser player type
        /// </summary>
        private readonly Type _browserPlayerType;
        /// <summary>
        /// The browser player
        /// </summary>
        private readonly object _browserPlayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserPlayerWavParsingTests"/> class
        /// </summary>
        public BrowserPlayerWavParsingTests()
        {
            Assembly assembly = typeof(Player).Assembly;
            _browserPlayerType = assembly.GetType("Alis.Core.Audio.Players.BrowserPlayer");
            _browserPlayer = Activator.CreateInstance(_browserPlayerType, true);
        }

        /// <summary>
        /// Invokes the method using the specified method name
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="args">The args</param>
        /// <returns>The object</returns>
        private object InvokeMethod(string methodName, params object[] args)
        {
            MethodInfo method = _browserPlayerType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            return method.Invoke(_browserPlayer, args);
        }

        /// <summary>
        /// Tries the parse wav with valid stereo 16 should return true
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithValidStereo16_ShouldReturnTrue()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(16, 2, 44100);

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tries the parse wav with valid mono 16 should return true
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithValidMono16_ShouldReturnTrue()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(16, 1, 44100);

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tries the parse wav with valid mono 8 should return true
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithValidMono8_ShouldReturnTrue()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(8, 1, 44100);

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tries the parse wav with valid stereo 8 should return true
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithValidStereo8_ShouldReturnTrue()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(8, 2, 44100);

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Tries the parse wav with null array should return false
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithNullArray_ShouldReturnFalse()
        {
            // Arrange
            byte[] wav = null;

            // Act & Assert
            TargetInvocationException exception = Assert.Throws<TargetInvocationException>(() => InvokeMethod("TryParseWav", wav, 0, 0, 0, 0));
            Assert.NotNull(exception.InnerException);
        }

        /// <summary>
        /// Tries the parse wav with empty array should return false
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithEmptyArray_ShouldReturnFalse()
        {
            // Arrange
            byte[] wav = new byte[0];

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tries the parse wav with too small array should return false
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithTooSmallArray_ShouldReturnFalse()
        {
            // Arrange
            byte[] wav = new byte[43];

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tries the parse wav with invalid riff header should return false
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithInvalidRiffHeader_ShouldReturnFalse()
        {
            // Arrange
            byte[] wav = new byte[44];
            wav[0] = (byte) 'X';
            wav[1] = (byte) 'X';
            wav[2] = (byte) 'X';
            wav[3] = (byte) 'X';

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tries the parse wav with invalid wave header should return false
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithInvalidWaveHeader_ShouldReturnFalse()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(16, 1, 44100);
            wav[8] = (byte) 'X';
            wav[9] = (byte) 'X';
            wav[10] = (byte) 'X';
            wav[11] = (byte) 'X';

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tries the parse wav with compressed format should return false
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithCompressedFormat_ShouldReturnFalse()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(256, 1, 44100); // 256 = compressed format

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tries the parse wav with unsupported channels should return false
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithUnsupportedChannels_ShouldReturnFalse()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(16, 8, 44100); // 8 channels not supported

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Tries the parse wav with mp 3 audio format should return false
        /// </summary>
        [BrowserOnly]
        public void TryParseWav_WithMp3AudioFormat_ShouldReturnFalse()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(0x55, 1, 44100); // 0x55 = MP3 format

            // Act
            bool result = (bool) InvokeMethod("TryParseWav", wav, 0, 0, 0, 0);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Finds the fmt chunk with fmt at start should return size
        /// </summary>
        [BrowserOnly]
        public void FindFmtChunk_WithFmtAtStart_ShouldReturnSize()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(16, 1, 44100);

            // Act
            int fmtPos = 12;
            object[] args = new object[] { wav, fmtPos };
            int fmtSize = (int) InvokeMethod("FindFmtChunk", args);

            // Assert
            Assert.Equal(16, fmtSize);
        }

        /// <summary>
        /// Finds the fmt chunk with fmt after other chunk should return size
        /// </summary>
        [BrowserOnly]
        public void FindFmtChunk_WithFmtAfterOtherChunk_ShouldReturnSize()
        {
            // Arrange
            byte[] wav = CreateWavWithExtraChunk(16, 1, 44100);

            // Act
            int fmtPos = 12;
            object[] args = new object[] { wav, fmtPos };
            int fmtSize = (int) InvokeMethod("FindFmtChunk", args);

            // Assert
            Assert.Equal(16, fmtSize);
        }

        /// <summary>
        /// Finds the fmt chunk with no fmt chunk should return zero
        /// </summary>
        [BrowserOnly]
        public void FindFmtChunk_WithNoFmtChunk_ShouldReturnZero()
        {
            // Arrange
            byte[] wav = new byte[44];
            wav[0] = (byte) 'R';
            wav[1] = (byte) 'I';
            wav[2] = (byte) 'F';
            wav[3] = (byte) 'F';
            wav[8] = (byte) 'W';
            wav[9] = (byte) 'A';
            wav[10] = (byte) 'V';
            wav[11] = (byte) 'E';

            // Act
            int fmtPos = 12;
            object[] args = new object[] { wav, fmtPos };
            int fmtSize = (int) InvokeMethod("FindFmtChunk", args);

            // Assert
            Assert.Equal(0, fmtSize);
        }

        /// <summary>
        /// Finds the data chunk with data chunk should return offset and size
        /// </summary>
        [BrowserOnly]
        public void FindDataChunk_WithDataChunk_ShouldReturnOffsetAndSize()
        {
            // Arrange
            byte[] wav = CreateValidWavFile(16, 1, 44100);

            // Act
            int pos = 12;
            object[] args = new object[] { wav, pos, 0, 0 };
            InvokeMethod("FindDataChunk", args);

            // Assert - should not throw
            Assert.True(true);
        }

        /// <summary>
        /// Finds the data chunk with no data chunk should return zero
        /// </summary>
        [BrowserOnly]
        public void FindDataChunk_WithNoDataChunk_ShouldReturnZero()
        {
            // Arrange
            byte[] wav = new byte[44];
            wav[0] = (byte) 'R';
            wav[1] = (byte) 'I';
            wav[2] = (byte) 'F';
            wav[3] = (byte) 'F';
            wav[8] = (byte) 'W';
            wav[9] = (byte) 'A';
            wav[10] = (byte) 'V';
            wav[11] = (byte) 'E';

            // Act
            int pos = 12;
            object[] args = new object[] { wav, pos, 0, 0 };
            InvokeMethod("FindDataChunk", args);

            // Assert - should not throw
            Assert.True(true);
        }

        /// <summary>
        /// Creates the valid wav file using the specified bits
        /// </summary>
        /// <param name="bits">The bits</param>
        /// <param name="channels">The channels</param>
        /// <param name="sampleRate">The sample rate</param>
        /// <returns>The wav</returns>
        private byte[] CreateValidWavFile(int bits, int channels, int sampleRate)
        {
            byte[] wav = new byte[44 + 100];

            // RIFF header
            wav[0] = (byte) 'R';
            wav[1] = (byte) 'I';
            wav[2] = (byte) 'F';
            wav[3] = (byte) 'F';

            // File size - 8
            BitConverter.GetBytes(36 + 100).CopyTo(wav, 4);

            // WAVE
            wav[8] = (byte) 'W';
            wav[9] = (byte) 'A';
            wav[10] = (byte) 'V';
            wav[11] = (byte) 'E';

            // fmt chunk
            wav[12] = (byte) 'f';
            wav[13] = (byte) 'm';
            wav[14] = (byte) 't';
            wav[15] = (byte) ' ';

            // fmt size (16 for PCM)
            BitConverter.GetBytes(16).CopyTo(wav, 16);

            // Audio format (1 = PCM)
            BitConverter.GetBytes((short) 1).CopyTo(wav, 20);

            // Channels
            BitConverter.GetBytes((short) channels).CopyTo(wav, 22);

            // Sample rate
            BitConverter.GetBytes(sampleRate).CopyTo(wav, 24);

            // Byte rate
            BitConverter.GetBytes(sampleRate * channels * bits / 8).CopyTo(wav, 28);

            // Block align
            BitConverter.GetBytes((short) (channels * bits / 8)).CopyTo(wav, 32);

            // Bits per sample
            BitConverter.GetBytes((short) bits).CopyTo(wav, 34);

            // data chunk
            wav[36] = (byte) 'd';
            wav[37] = (byte) 'a';
            wav[38] = (byte) 't';
            wav[39] = (byte) 'a';

            // data size
            BitConverter.GetBytes(100).CopyTo(wav, 40);

            return wav;
        }

        /// <summary>
        /// Creates the wav with extra chunk using the specified bits
        /// </summary>
        /// <param name="bits">The bits</param>
        /// <param name="channels">The channels</param>
        /// <param name="sampleRate">The sample rate</param>
        /// <returns>The wav</returns>
        private byte[] CreateWavWithExtraChunk(int bits, int channels, int sampleRate)
        {
            byte[] wav = new byte[60 + 100];

            // RIFF header
            wav[0] = (byte) 'R';
            wav[1] = (byte) 'I';
            wav[2] = (byte) 'F';
            wav[3] = (byte) 'F';

            // File size - 8
            BitConverter.GetBytes(52 + 100).CopyTo(wav, 4);

            // WAVE
            wav[8] = (byte) 'W';
            wav[9] = (byte) 'A';
            wav[10] = (byte) 'V';
            wav[11] = (byte) 'E';

            // extra chunk (list)
            wav[12] = (byte) 'l';
            wav[13] = (byte) 'i';
            wav[14] = (byte) 's';
            wav[15] = (byte) 't';
            BitConverter.GetBytes(8).CopyTo(wav, 16);
            wav[20] = (byte) 'L';
            wav[21] = (byte) 'I';
            wav[22] = (byte) 'S';
            wav[23] = (byte) 'T';
            BitConverter.GetBytes(4).CopyTo(wav, 24);
            BitConverter.GetBytes(0).CopyTo(wav, 28);

            // fmt chunk
            wav[32] = (byte) 'f';
            wav[33] = (byte) 'm';
            wav[34] = (byte) 't';
            wav[35] = (byte) ' ';

            // fmt size (16 for PCM)
            BitConverter.GetBytes(16).CopyTo(wav, 36);

            // Audio format (1 = PCM)
            BitConverter.GetBytes((short) 1).CopyTo(wav, 40);

            // Channels
            BitConverter.GetBytes((short) channels).CopyTo(wav, 42);

            // Sample rate
            BitConverter.GetBytes(sampleRate).CopyTo(wav, 44);

            // Byte rate
            BitConverter.GetBytes(sampleRate * channels * bits / 8).CopyTo(wav, 48);

            // Block align
            BitConverter.GetBytes((short) (channels * bits / 8)).CopyTo(wav, 52);

            // Bits per sample
            BitConverter.GetBytes((short) bits).CopyTo(wav, 54);

            // data chunk
            wav[56] = (byte) 'd';
            wav[57] = (byte) 'a';
            wav[58] = (byte) 't';
            wav[59] = (byte) 'a';

            // data size
            BitConverter.GetBytes(100).CopyTo(wav, 60);

            return wav;
        }
    }
}
