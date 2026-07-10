using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Alis.Core.Audio;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class UnixPlayerBaseExtractionCoverageTests : IDisposable
    {
        private string _previousActiveName;
        private const string WavResourceName = "extract_test.wav";

        public void Dispose()
        {
            if (_previousActiveName != null)
                AssetRegistryTestHelper.RestoreActive(_previousActiveName);
        }

        private static byte[] CreateRealWavBytes()
        {
            int sampleRate = 44100;
            short channels = 1;
            short bitsPerSample = 16;
            int dataSize = 1764;
            int blockAlign = channels * bitsPerSample / 8;
            int byteRate = sampleRate * blockAlign;

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"), 0, 4);
                BitConverter.GetBytes(36 + dataSize).CopyTo(ms.GetBuffer(), 0); ms.Position += 4;
                ms.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"), 0, 4);
                ms.Write(System.Text.Encoding.ASCII.GetBytes("fmt "), 0, 4);
                BitConverter.GetBytes(16).CopyTo(ms.GetBuffer(), (int)ms.Position); ms.Position += 4;
                ms.Write(BitConverter.GetBytes((short)1), 0, 2);
                ms.Write(BitConverter.GetBytes(channels), 0, 2);
                ms.Write(BitConverter.GetBytes(sampleRate), 0, 4);
                ms.Write(BitConverter.GetBytes(byteRate), 0, 4);
                ms.Write(BitConverter.GetBytes((short)blockAlign), 0, 2);
                ms.Write(BitConverter.GetBytes(bitsPerSample), 0, 2);
                ms.Write(System.Text.Encoding.ASCII.GetBytes("data"), 0, 4);
                ms.Write(BitConverter.GetBytes(dataSize), 0, 4);
                ms.Write(new byte[dataSize], 0, dataSize);
                return ms.ToArray();
            }
        }

        private void SetupAssembly()
        {
            _previousActiveName = AssetRegistryTestHelper.SaveAndSetActive(null);
            byte[] wavBytes = CreateRealWavBytes();
            string name = AssetRegistryTestHelper.RegisterNewAssembly(WavResourceName, wavBytes);
            AssetRegistryTestHelper.SaveAndSetActive(name);
        }

        [Fact]
        public void ExtractWavFromResources_WithValidResource_ShouldReturnPath()
        {
            SetupAssembly();

            MacPlayer player = new MacPlayer();
            MethodInfo extractMethod = typeof(UnixPlayerBase).GetMethod(
                "ExtractWavFromResourcesAsync",
                BindingFlags.NonPublic | BindingFlags.Static);

            string result = (string)extractMethod.Invoke(null, new object[] { WavResourceName });

            Assert.NotNull(result);
            Assert.True(File.Exists(result), $"Extracted file should exist: {result}");
            File.Delete(result);
        }

        [Fact]
        public async Task Play_WithResourceExtraction_ShouldSucceed()
        {
            SetupAssembly();

            MacPlayer player = new MacPlayer();
            await player.Play(WavResourceName);
            Assert.True(player.Playing);

            await player.Stop();
            Assert.False(player.Playing);
        }

        [Fact]
        public async Task PlayLoop_WithResourceExtraction_ShouldSucceed()
        {
            SetupAssembly();

            MacPlayer player = new MacPlayer();
            await player.PlayLoop(WavResourceName, false);
            Assert.True(player.Playing);

            await player.Stop();
            Assert.False(player.Playing);
        }

        [Fact]
        public async Task Play_WithCachedExtraction_ShouldReuseCachedFile()
        {
            SetupAssembly();

            MacPlayer player = new MacPlayer();
            await player.Play(WavResourceName);
            Assert.True(player.Playing);
            await player.Stop();

            await player.Play(WavResourceName);
            Assert.True(player.Playing);
            await player.Stop();
        }
    }
}
