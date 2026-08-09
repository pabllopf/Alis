using System;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The unix player base extraction coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class UnixPlayerBaseExtractionCoverageTests : IDisposable
    {
        /// <summary>
        /// The previous active name
        /// </summary>
        private string _previousActiveName;
        /// <summary>
        /// The wav resource name
        /// </summary>
        private const string WavResourceName = "extract_test.wav";

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (_previousActiveName != null)
                AssetRegistryTestHelper.RestoreActive(_previousActiveName);
        }

        /// <summary>
        /// Creates the real wav bytes
        /// </summary>
        /// <returns>The byte array</returns>
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

        /// <summary>
        /// Setup the assembly
        /// </summary>
        internal void SetupAssembly()
        {
            _previousActiveName = AssetRegistryTestHelper.SaveAndSetActive(null);
            byte[] wavBytes = CreateRealWavBytes();
            string name = AssetRegistryTestHelper.RegisterNewAssembly(WavResourceName, wavBytes);
            AssetRegistryTestHelper.SaveAndSetActive(name);
        }

        /// <summary>
        /// Tests that play with resource extraction should succeed
        /// </summary>
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

        /// <summary>
        /// Tests that play loop with resource extraction should succeed
        /// </summary>
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

        /// <summary>
        /// Tests that play with cached extraction should reuse cached file
        /// </summary>
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
