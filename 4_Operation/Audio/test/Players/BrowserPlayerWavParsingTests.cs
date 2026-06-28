using System;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The browser player wav parsing tests class
    /// </summary>
    public class BrowserPlayerWavParsingTests
    {
        /// <summary>
        /// Tests that try parse wav with valid stereo 16 should return true
        /// </summary>
        [Fact]
        public void TryParseWav_WithValidStereo16_ShouldReturnTrue()
        {
            byte[] wav = CreateValidWavFile(16, 2, 44100);
            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.True(result);
        }

        /// <summary>
        /// Tests that try parse wav with valid mono 16 should return true
        /// </summary>
        [Fact]
        public void TryParseWav_WithValidMono16_ShouldReturnTrue()
        {
            byte[] wav = CreateValidWavFile(16, 1, 44100);
            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.True(result);
        }

        /// <summary>
        /// Tests that try parse wav with valid mono 8 should return true
        /// </summary>
        [Fact]
        public void TryParseWav_WithValidMono8_ShouldReturnTrue()
        {
            byte[] wav = CreateValidWavFile(8, 1, 44100);
            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.True(result);
        }

        /// <summary>
        /// Tests that try parse wav with valid stereo 8 should return true
        /// </summary>
        [Fact]
        public void TryParseWav_WithValidStereo8_ShouldReturnTrue()
        {
            byte[] wav = CreateValidWavFile(8, 2, 44100);
            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.True(result);
        }

        /// <summary>
        /// Tests that try parse wav with empty array should return false
        /// </summary>
        [Fact]
        public void TryParseWav_WithEmptyArray_ShouldReturnFalse()
        {
            byte[] wav = Array.Empty<byte>();
            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that try parse wav with too small array should return false
        /// </summary>
        [Fact]
        public void TryParseWav_WithTooSmallArray_ShouldReturnFalse()
        {
            byte[] wav = new byte[43];
            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that try parse wav with invalid riff header should return false
        /// </summary>
        [Fact]
        public void TryParseWav_WithInvalidRiffHeader_ShouldReturnFalse()
        {
            byte[] wav = new byte[44];
            wav[0] = (byte)'X';
            wav[1] = (byte)'X';
            wav[2] = (byte)'X';
            wav[3] = (byte)'X';

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that try parse wav with invalid wave header should return false
        /// </summary>
        [Fact]
        public void TryParseWav_WithInvalidWaveHeader_ShouldReturnFalse()
        {
            byte[] wav = CreateValidWavFile(16, 1, 44100);
            wav[8] = (byte)'X';
            wav[9] = (byte)'X';
            wav[10] = (byte)'X';
            wav[11] = (byte)'X';

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that try parse wav with compressed format should return false
        /// </summary>
        [Fact]
        public void TryParseWav_WithCompressedFormat_ShouldReturnFalse()
        {
            byte[] wav = CreateValidWavFile(256, 1, 44100);

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that try parse wav with unsupported channels should return false
        /// </summary>
        [Fact]
        public void TryParseWav_WithUnsupportedChannels_ShouldReturnFalse()
        {
            byte[] wav = CreateValidWavFile(16, 8, 44100);

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that try parse wav with mp 3 audio format should return false
        /// </summary>
        [Fact]
        public void TryParseWav_WithMp3AudioFormat_ShouldReturnFalse()
        {
            byte[] wav = CreateValidWavFile(0x55, 1, 44100);

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that find fmt chunk with fmt at start should return size
        /// </summary>
        [Fact]
        public void FindFmtChunk_WithFmtAtStart_ShouldReturnSize()
        {
            byte[] wav = CreateValidWavFile(16, 1, 44100);
            int fmtPos = 12;
            int fmtSize = BrowserPlayer.FindFmtChunk(wav, ref fmtPos);
            Assert.Equal(16, fmtSize);
        }

        /// <summary>
        /// Tests that find fmt chunk with fmt after other chunk should return size
        /// </summary>
        [Fact]
        public void FindFmtChunk_WithFmtAfterOtherChunk_ShouldReturnSize()
        {
            byte[] wav = CreateWavWithExtraChunk(16, 1, 44100);
            int fmtPos = 12;
            int fmtSize = BrowserPlayer.FindFmtChunk(wav, ref fmtPos);
            Assert.Equal(16, fmtSize);
        }

        /// <summary>
        /// Tests that find fmt chunk with no fmt chunk should return zero
        /// </summary>
        [Fact]
        public void FindFmtChunk_WithNoFmtChunk_ShouldReturnZero()
        {
            byte[] wav = new byte[44];
            wav[0] = (byte)'R';
            wav[1] = (byte)'I';
            wav[2] = (byte)'F';
            wav[3] = (byte)'F';
            wav[8] = (byte)'W';
            wav[9] = (byte)'A';
            wav[10] = (byte)'V';
            wav[11] = (byte)'E';

            int fmtPos = 12;
            int fmtSize = BrowserPlayer.FindFmtChunk(wav, ref fmtPos);
            Assert.Equal(0, fmtSize);
        }

        /// <summary>
        /// Tests that find data chunk with data chunk should return offset and size
        /// </summary>
        [Fact]
        public void FindDataChunk_WithDataChunk_ShouldReturnOffsetAndSize()
        {
            byte[] wav = CreateValidWavFile(16, 1, 44100);
            int pos = 12;
            BrowserPlayer.FindDataChunk(wav, ref pos, out int dataOffset, out int dataSize);
            Assert.NotEqual(0, dataOffset);
            Assert.NotEqual(0, dataSize);
        }

        /// <summary>
        /// Tests that find data chunk with no data chunk should return zero
        /// </summary>
        [Fact]
        public void FindDataChunk_WithNoDataChunk_ShouldReturnZero()
        {
            byte[] wav = new byte[44];
            wav[0] = (byte)'R';
            wav[1] = (byte)'I';
            wav[2] = (byte)'F';
            wav[3] = (byte)'F';
            wav[8] = (byte)'W';
            wav[9] = (byte)'A';
            wav[10] = (byte)'V';
            wav[11] = (byte)'E';

            int pos = 12;
            BrowserPlayer.FindDataChunk(wav, ref pos, out int dataOffset, out int dataSize);
            Assert.Equal(0, dataOffset);
            Assert.Equal(0, dataSize);
        }

        /// <summary>
        /// Tests that try parse wav should parse valid outputs
        /// </summary>
        [Fact]
        public void TryParseWav_ShouldParseValidOutputs()
        {
            byte[] wav = CreateValidWavFile(16, 2, 44100);

            bool result = BrowserPlayer.TryParseWav(wav, out int dataOffset, out int dataSize, out int freq, out int format);

            Assert.True(result);
            Assert.Equal(44100, freq);
            Assert.Equal(0x1103, format);
        }

        /// <summary>
        /// Tests that try parse wav with mono 16 should return format mono 16
        /// </summary>
        [Fact]
        public void TryParseWav_WithMono16_ShouldReturnFormatMono16()
        {
            byte[] wav = CreateValidWavFile(16, 1, 44100);

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int format);

            Assert.True(result);
            Assert.Equal(0x1101, format);
        }

        /// <summary>
        /// Tests that try parse wav with mono 8 should return format mono 8
        /// </summary>
        [Fact]
        public void TryParseWav_WithMono8_ShouldReturnFormatMono8()
        {
            byte[] wav = CreateValidWavFile(8, 1, 44100);

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int format);

            Assert.True(result);
            Assert.Equal(0x1100, format);
        }

        /// <summary>
        /// Tests that try parse wav with stereo 8 should return format stereo 8
        /// </summary>
        [Fact]
        public void TryParseWav_WithStereo8_ShouldReturnFormatStereo8()
        {
            byte[] wav = CreateValidWavFile(8, 2, 44100);

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int format);

            Assert.True(result);
            Assert.Equal(0x1102, format);
        }

        /// <summary>
        /// Tests that try parse wav with extra fmt size should still parse
        /// </summary>
        [Fact]
        public void TryParseWav_WithExtraFmtSize_ShouldStillParse()
        {
            byte[] wav = CreateWavWithExtendedFmt(16, 1, 44100);

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int format);

            Assert.True(result);
            Assert.Equal(0x1101, format);
        }

        /// <summary>
        /// Tests that try get format with 16 bits 1 channel should return mono 16
        /// </summary>
        [Fact]
        public void TryGetFormat_With16Bits1Channel_ShouldReturnMono16()
        {
            bool result = BrowserPlayer.TryGetFormat(16, 1, out int format);
            Assert.True(result);
            Assert.Equal(0x1101, format);
        }

        /// <summary>
        /// Tests that try get format with 16 bits 2 channels should return stereo 16
        /// </summary>
        [Fact]
        public void TryGetFormat_With16Bits2Channels_ShouldReturnStereo16()
        {
            bool result = BrowserPlayer.TryGetFormat(16, 2, out int format);
            Assert.True(result);
            Assert.Equal(0x1103, format);
        }

        /// <summary>
        /// Tests that try get format with 8 bits 1 channel should return mono 8
        /// </summary>
        [Fact]
        public void TryGetFormat_With8Bits1Channel_ShouldReturnMono8()
        {
            bool result = BrowserPlayer.TryGetFormat(8, 1, out int format);
            Assert.True(result);
            Assert.Equal(0x1100, format);
        }

        /// <summary>
        /// Tests that try get format with 8 bits 2 channels should return stereo 8
        /// </summary>
        [Fact]
        public void TryGetFormat_With8Bits2Channels_ShouldReturnStereo8()
        {
            bool result = BrowserPlayer.TryGetFormat(8, 2, out int format);
            Assert.True(result);
            Assert.Equal(0x1102, format);
        }

        /// <summary>
        /// Tests that try get format with unsupported bits should return false
        /// </summary>
        [Fact]
        public void TryGetFormat_WithUnsupportedBits_ShouldReturnFalse()
        {
            bool result = BrowserPlayer.TryGetFormat(24, 1, out int format);
            Assert.False(result);
            Assert.Equal(0, format);
        }

        /// <summary>
        /// Tests that try get format with unsupported channels should return false
        /// </summary>
        [Fact]
        public void TryGetFormat_WithUnsupportedChannels_ShouldReturnFalse()
        {
            bool result = BrowserPlayer.TryGetFormat(16, 5, out int format);
            Assert.False(result);
            Assert.Equal(0, format);
        }

        /// <summary>
        /// Tests that try get format with 8 bits 5 channels should return false
        /// </summary>
        [Fact]
        public void TryGetFormat_With8Bits5Channels_ShouldReturnFalse()
        {
            bool result = BrowserPlayer.TryGetFormat(8, 5, out int format);
            Assert.False(result);
            Assert.Equal(0, format);
        }

        /// <summary>
        /// Tests that find fmt chunk with null bytes should throw null reference exception
        /// </summary>
        [Fact]
        public void FindFmtChunk_WithNullBytes_ShouldThrowNullReferenceException()
        {
            int fmtPos = 12;
            Assert.Throws<NullReferenceException>(() => BrowserPlayer.FindFmtChunk(null, ref fmtPos));
        }

        /// <summary>
        /// Tests that find data chunk with null bytes should throw null reference exception
        /// </summary>
        [Fact]
        public void FindDataChunk_WithNullBytes_ShouldThrowNullReferenceException()
        {
            int pos = 12;
            Assert.Throws<NullReferenceException>(() => BrowserPlayer.FindDataChunk(null, ref pos, out int _, out int _));
        }

        /// <summary>
        /// Tests that try parse wav with null array should throw null reference exception
        /// </summary>
        [Fact]
        public void TryParseWav_WithNullArray_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => BrowserPlayer.TryParseWav(null, out int _, out int _, out int _, out int _));
        }

        /// <summary>
        /// Tests that try parse wav with percussion one shot should return correct format
        /// </summary>
        [Fact]
        public void TryParseWav_WithPercussionOneShot_ShouldReturnCorrectFormat()
        {
            byte[] wav = CreateValidWavFile(16, 1, 22050);

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int freq, out int format);

            Assert.True(result);
            Assert.Equal(22050, freq);
            Assert.Equal(0x1101, format);
        }

        /// <summary>
        /// Tests that try parse wav with voice sample should return correct format
        /// </summary>
        [Fact]
        public void TryParseWav_WithVoiceSample_ShouldReturnCorrectFormat()
        {
            byte[] wav = CreateValidWavFile(16, 1, 8000);

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int freq, out int format);

            Assert.True(result);
            Assert.Equal(8000, freq);
            Assert.Equal(0x1101, format);
        }

        /// <summary>
        /// Tests that try parse wav with no riff header should return false
        /// </summary>
        [Fact]
        public void TryParseWav_WithNoRiffHeader_ShouldReturnFalse()
        {
            byte[] wav = new byte[44];

            bool result = BrowserPlayer.TryParseWav(wav, out int _, out int _, out int _, out int _);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that find data chunk with data only should return non zero
        /// </summary>
        [Fact]
        public void FindDataChunk_WithDataOnly_ShouldReturnNonZero()
        {
            byte[] wav = new byte[48];
            wav[0] = (byte)'R';
            wav[1] = (byte)'I';
            wav[2] = (byte)'F';
            wav[3] = (byte)'F';
            BitConverter.GetBytes(36).CopyTo(wav, 4);
            wav[8] = (byte)'W';
            wav[9] = (byte)'A';
            wav[10] = (byte)'V';
            wav[11] = (byte)'E';
            wav[12] = (byte)'d';
            wav[13] = (byte)'a';
            wav[14] = (byte)'t';
            wav[15] = (byte)'a';
            BitConverter.GetBytes(100).CopyTo(wav, 16);

            int pos = 12;
            BrowserPlayer.FindDataChunk(wav, ref pos, out int dataOffset, out int dataSize);

            Assert.NotEqual(0, dataOffset);
            Assert.Equal(100, dataSize);
        }

        /// <summary>
        /// Creates the valid wav file using the specified bits
        /// </summary>
        /// <param name="bits">The bits</param>
        /// <param name="channels">The channels</param>
        /// <param name="sampleRate">The sample rate</param>
        /// <returns>The wav</returns>
        private static byte[] CreateValidWavFile(int bits, int channels, int sampleRate)
        {
            byte[] wav = new byte[44 + 100];

            wav[0] = (byte)'R';
            wav[1] = (byte)'I';
            wav[2] = (byte)'F';
            wav[3] = (byte)'F';
            BitConverter.GetBytes(36 + 100).CopyTo(wav, 4);
            wav[8] = (byte)'W';
            wav[9] = (byte)'A';
            wav[10] = (byte)'V';
            wav[11] = (byte)'E';

            wav[12] = (byte)'f';
            wav[13] = (byte)'m';
            wav[14] = (byte)'t';
            wav[15] = (byte)' ';
            BitConverter.GetBytes(16).CopyTo(wav, 16);
            BitConverter.GetBytes((short)1).CopyTo(wav, 20);
            BitConverter.GetBytes((short)channels).CopyTo(wav, 22);
            BitConverter.GetBytes(sampleRate).CopyTo(wav, 24);
            BitConverter.GetBytes(sampleRate * channels * bits / 8).CopyTo(wav, 28);
            BitConverter.GetBytes((short)(channels * bits / 8)).CopyTo(wav, 32);
            BitConverter.GetBytes((short)bits).CopyTo(wav, 34);

            wav[36] = (byte)'d';
            wav[37] = (byte)'a';
            wav[38] = (byte)'t';
            wav[39] = (byte)'a';
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
        private static byte[] CreateWavWithExtraChunk(int bits, int channels, int sampleRate)
        {
            byte[] wav = new byte[60 + 100];

            wav[0] = (byte)'R';
            wav[1] = (byte)'I';
            wav[2] = (byte)'F';
            wav[3] = (byte)'F';
            BitConverter.GetBytes(52 + 100).CopyTo(wav, 4);
            wav[8] = (byte)'W';
            wav[9] = (byte)'A';
            wav[10] = (byte)'V';
            wav[11] = (byte)'E';

            wav[12] = (byte)'J';
            wav[13] = (byte)'u';
            wav[14] = (byte)'n';
            wav[15] = (byte)'k';
            BitConverter.GetBytes(8).CopyTo(wav, 16);
            BitConverter.GetBytes(0).CopyTo(wav, 20);

            wav[28] = (byte)'f';
            wav[29] = (byte)'m';
            wav[30] = (byte)'t';
            wav[31] = (byte)' ';
            BitConverter.GetBytes(16).CopyTo(wav, 32);
            BitConverter.GetBytes((short)1).CopyTo(wav, 36);
            BitConverter.GetBytes((short)channels).CopyTo(wav, 38);
            BitConverter.GetBytes(sampleRate).CopyTo(wav, 40);
            BitConverter.GetBytes(sampleRate * channels * bits / 8).CopyTo(wav, 44);
            BitConverter.GetBytes((short)(channels * bits / 8)).CopyTo(wav, 48);
            BitConverter.GetBytes((short)bits).CopyTo(wav, 50);

            wav[52] = (byte)'d';
            wav[53] = (byte)'a';
            wav[54] = (byte)'t';
            wav[55] = (byte)'a';
            BitConverter.GetBytes(100).CopyTo(wav, 56);
            return wav;
        }

        /// <summary>
        /// Creates the wav with extended fmt using the specified bits
        /// </summary>
        /// <param name="bits">The bits</param>
        /// <param name="channels">The channels</param>
        /// <param name="sampleRate">The sample rate</param>
        /// <returns>The wav</returns>
        private static byte[] CreateWavWithExtendedFmt(int bits, int channels, int sampleRate)
        {
            byte[] wav = new byte[60 + 100];

            wav[0] = (byte)'R';
            wav[1] = (byte)'I';
            wav[2] = (byte)'F';
            wav[3] = (byte)'F';
            BitConverter.GetBytes(52 + 100).CopyTo(wav, 4);
            wav[8] = (byte)'W';
            wav[9] = (byte)'A';
            wav[10] = (byte)'V';
            wav[11] = (byte)'E';

            wav[12] = (byte)'f';
            wav[13] = (byte)'m';
            wav[14] = (byte)'t';
            wav[15] = (byte)' ';
            BitConverter.GetBytes(18).CopyTo(wav, 16);
            BitConverter.GetBytes((short)1).CopyTo(wav, 20);
            BitConverter.GetBytes((short)channels).CopyTo(wav, 22);
            BitConverter.GetBytes(sampleRate).CopyTo(wav, 24);
            BitConverter.GetBytes(sampleRate * channels * bits / 8).CopyTo(wav, 28);
            BitConverter.GetBytes((short)(channels * bits / 8)).CopyTo(wav, 32);
            BitConverter.GetBytes((short)bits).CopyTo(wav, 34);
            BitConverter.GetBytes((short)0).CopyTo(wav, 36);

            wav[38] = (byte)'d';
            wav[39] = (byte)'a';
            wav[40] = (byte)'t';
            wav[41] = (byte)'a';
            BitConverter.GetBytes(100).CopyTo(wav, 42);
            return wav;
        }
    }
}
