using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Audio;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class PlayerPlayCoverageTests
    {
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
    }
}
