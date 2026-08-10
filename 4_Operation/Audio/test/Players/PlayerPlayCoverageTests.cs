using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The player play coverage tests class
    /// </summary>
    public class PlayerPlayCoverageTests
    {
        /// <summary>
        /// Deletes the file with retries to account for the mci device releasing the file asynchronously
        /// </summary>
        /// <param name="path">The path</param>
        private static void DeleteWithRetry(string path)
        {
            for (int attempt = 0; attempt < 20; attempt++)
            {
                try
                {
                    if (File.Exists(path)) File.Delete(path);
                    return;
                }
                catch (IOException)
                {
                    System.Threading.Thread.Sleep(25);
                }
            }
        }

        /// <summary>
        /// Creates the temp wav file
        /// </summary>
        /// <returns>The file path</returns>
        private static string CreateTempWavFile()
        {
            int sampleRate = 44100;
            short channels = 1;
            short bitsPerSample = 16;
            int dataSize = 88200;
            int blockAlign = channels * bitsPerSample / 8;
            int byteRate = sampleRate * blockAlign;

            string filePath = Path.GetTempFileName() + ".wav";
            using (FileStream stream = File.Create(filePath))
            {
                stream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);
                stream.Write(BitConverter.GetBytes(36 + dataSize), 0, 4);
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
                stream.Write(new byte[dataSize], 0, dataSize);
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
            Player player = new Player();
            try
            {
                await player.Play(wavFile);
                Assert.True(player.Playing);
            }
            finally
            {
                await player.Stop();
                DeleteWithRetry(wavFile);
            }
        }

        /// <summary>
        /// Tests that player play loop with loop false should complete successfully
        /// </summary>
        [Fact]
        public async Task Player_PlayLoop_WithLoopFalse_ShouldCompleteSuccessfully()
        {
            string wavFile = CreateTempWavFile();
            Player player = new Player();
            try
            {
                await player.PlayLoop(wavFile, false);
                Assert.True(player.Playing);
            }
            finally
            {
                await player.Stop();
                DeleteWithRetry(wavFile);
            }
        }

        /// <summary>
        /// Tests that player play then stop should work
        /// </summary>
        [Fact]
        public async Task Player_PlayThenStop_ShouldWork()
        {
            string wavFile = CreateTempWavFile();
            Player player = new Player();
            try
            {
                await player.Play(wavFile);
                Assert.True(player.Playing);
                await player.Stop();
                Assert.False(player.Playing);
            }
            finally
            {
                await player.Stop();
                DeleteWithRetry(wavFile);
            }
        }

        /// <summary>
        /// Tests that mac player play with real wav file should set playing true
        /// </summary>
        [UnixOnly]
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
                DeleteWithRetry(wavFile);
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
            Player player = new Player();
            try
            {
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
                await player.Stop();
                DeleteWithRetry(wavFile1);
                DeleteWithRetry(wavFile2);
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
        [UnixOnly]
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
                DeleteWithRetry(wavFile);
            }
        }
    }
}
