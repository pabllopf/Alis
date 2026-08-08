using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The player play coverage tests class
    /// </summary>
    public class PlayerPlayCoverageTests
    {
        /// <summary>
        /// Creates the temp wav file
        /// </summary>
        /// <returns>The file path</returns>
        private static string CreateTempWavFile()
        {
            string filePath = Path.GetTempFileName() + ".wav";
            using (FileStream stream = File.Create(filePath))
            {
                stream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);
                byte[] fileSize = BitConverter.GetBytes(36);
                stream.Write(fileSize, 0, 4);
                stream.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);

                stream.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);
                BitConverter.GetBytes(16).CopyTo(fileSize, 0);
                stream.Write(fileSize, 0, 4);
                byte[] audioFormat = BitConverter.GetBytes((short)1);
                stream.Write(audioFormat, 0, 2);
                byte[] channels = BitConverter.GetBytes((short)1);
                stream.Write(channels, 0, 2);
                byte[] sampleRate = BitConverter.GetBytes(44100);
                stream.Write(sampleRate, 0, 4);
                byte[] byteRate = BitConverter.GetBytes(88200);
                stream.Write(byteRate, 0, 4);
                byte[] blockAlign = BitConverter.GetBytes((short)2);
                stream.Write(blockAlign, 0, 2);
                byte[] bitsPerSample = BitConverter.GetBytes((short)16);
                stream.Write(bitsPerSample, 0, 2);

                stream.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
                byte[] dataSize = BitConverter.GetBytes(0);
                stream.Write(dataSize, 0, 4);
            }
            return filePath;
        }

        /// <summary>
        /// Tests that player play with real wav file should complete successfully
        /// </summary>
        [Fact]
        public async Task Player_Play_WithRealWavFile_ShouldCompleteSuccessfully()
        {
            string wavFile = CreateTempWavFile();
            try
            {
                Player player = new Player();
                await player.Play(wavFile);
                Assert.True(player.Playing);
            }
            finally
            {
                if (File.Exists(wavFile)) File.Delete(wavFile);
            }
        }

        /// <summary>
        /// Tests that player play loop with loop false should complete successfully
        /// </summary>
        [Fact]
        public async Task Player_PlayLoop_WithLoopFalse_ShouldCompleteSuccessfully()
        {
            string wavFile = CreateTempWavFile();
            try
            {
                Player player = new Player();
                await player.PlayLoop(wavFile, false);
                Assert.True(player.Playing);
            }
            finally
            {
                if (File.Exists(wavFile)) File.Delete(wavFile);
            }
        }

        /// <summary>
        /// Tests that player play then stop should work
        /// </summary>
        [Fact]
        public async Task Player_PlayThenStop_ShouldWork()
        {
            string wavFile = CreateTempWavFile();
            try
            {
                Player player = new Player();
                await player.Play(wavFile);
                Assert.True(player.Playing);
                await player.Stop();
                Assert.False(player.Playing);
            }
            finally
            {
                if (File.Exists(wavFile)) File.Delete(wavFile);
            }
        }

        /// <summary>
        /// Tests that mac player play with real wav file should set playing true
        /// </summary>
        [Fact]
        public async Task MacPlayer_Play_WithRealWavFile_ShouldSetPlayingTrue()
        {
            string wavFile = CreateTempWavFile();
            try
            {
                MacPlayer player = new MacPlayer();
                await player.Play(wavFile);
                Assert.True(player.Playing);
            }
            finally
            {
                if (File.Exists(wavFile)) File.Delete(wavFile);
            }
        }

        /// <summary>
        /// Tests that player play update last played file should cache correctly
        /// </summary>
        [Fact]
        public async Task Player_Play_UpdateLastPlayedFile_ShouldCacheCorrectly()
        {
            string wavFile1 = CreateTempWavFile();
            string wavFile2 = CreateTempWavFile();
            try
            {
                Player player = new Player();
                await player.Play(wavFile1);
                Assert.True(player.Playing);
                await player.Stop();

                await player.Play(wavFile1);
                Assert.True(player.Playing);
                await player.Stop();

                await player.Play(wavFile2);
                Assert.True(player.Playing);
                await player.Stop();
            }
            finally
            {
                if (File.Exists(wavFile1)) File.Delete(wavFile1);
                if (File.Exists(wavFile2)) File.Delete(wavFile2);
            }
        }

        /// <summary>
        /// Creates the real wav file
        /// </summary>
        /// <returns>The file path</returns>
        private static string CreateRealWavFile()
        {
            int sampleRate = 44100;
            short channels = 1;
            short bitsPerSample = 16;
            int dataSize = 1764;
            int blockAlign = channels * bitsPerSample / 8;
            int byteRate = sampleRate * blockAlign;

            string filePath = Path.GetTempFileName() + ".wav";
            using (FileStream stream = File.Create(filePath))
            {
                stream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);
                byte[] fileSize = BitConverter.GetBytes(36 + dataSize);
                stream.Write(fileSize, 0, 4);
                stream.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);

                stream.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);
                byte[] fmtSize = BitConverter.GetBytes(16);
                stream.Write(fmtSize, 0, 4);
                byte[] audioFormat = BitConverter.GetBytes((short)1);
                stream.Write(audioFormat, 0, 2);
                byte[] ch = BitConverter.GetBytes(channels);
                stream.Write(ch, 0, 2);
                byte[] sr = BitConverter.GetBytes(sampleRate);
                stream.Write(sr, 0, 4);
                byte[] br = BitConverter.GetBytes(byteRate);
                stream.Write(br, 0, 4);
                byte[] ba = BitConverter.GetBytes((short)blockAlign);
                stream.Write(ba, 0, 2);
                byte[] bps = BitConverter.GetBytes(bitsPerSample);
                stream.Write(bps, 0, 2);

                stream.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
                byte[] ds = BitConverter.GetBytes(dataSize);
                stream.Write(ds, 0, 4);
                byte[] audioData = new byte[dataSize];
                stream.Write(audioData, 0, dataSize);
            }
            return filePath;
        }

        /// <summary>
        /// Tests that mac player play loop with loop true should start background loop
        /// </summary>
        [Fact]
        public async Task MacPlayer_PlayLoop_WithLoopTrue_ShouldStartBackgroundLoop()
        {
            string wavFile = CreateRealWavFile();
            try
            {
                MacPlayer player = new MacPlayer();
                await player.PlayLoop(wavFile, true);
                Assert.True(player.Playing);

                await Task.Delay(300);
                await player.Stop();
                Assert.False(player.Playing);
            }
            finally
            {
                await Task.Delay(50);
                if (File.Exists(wavFile)) File.Delete(wavFile);
            }
        }
    }
}
