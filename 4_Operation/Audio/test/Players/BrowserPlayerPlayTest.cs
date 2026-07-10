using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class BrowserPlayerPlayTest : IDisposable
    {
        private BrowserPlayer _player;
        private const string AssemblyName = "Alis.Core.Audio.Test";
        private const string WavFileName = "test_sound.wav";
        private string _tempZipPath;

        public void Dispose()
        {
            try { _player?.Stop(); } catch { }
            try { _player = null; } catch { }
            if (_tempZipPath != null && File.Exists(_tempZipPath)) File.Delete(_tempZipPath);
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
                ms.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);
                byte[] fileSize = BitConverter.GetBytes(36 + dataSize);
                ms.Write(fileSize, 0, 4);
                ms.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);

                ms.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);
                BitConverter.GetBytes(16).CopyTo(fileSize, 0);
                ms.Write(fileSize, 0, 4);
                ms.Write(BitConverter.GetBytes((short)1), 0, 2);
                ms.Write(BitConverter.GetBytes(channels), 0, 2);
                ms.Write(BitConverter.GetBytes(sampleRate), 0, 4);
                ms.Write(BitConverter.GetBytes(byteRate), 0, 4);
                ms.Write(BitConverter.GetBytes((short)blockAlign), 0, 2);
                ms.Write(BitConverter.GetBytes(bitsPerSample), 0, 2);

                ms.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
                ms.Write(BitConverter.GetBytes(dataSize), 0, 4);
                byte[] audioData = new byte[dataSize];
                ms.Write(audioData, 0, dataSize);

                return ms.ToArray();
            }
        }

        private static byte[] CreateZipWithWav()
        {
            byte[] wavBytes = CreateRealWavBytes();
            using (MemoryStream zipMs = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zipMs, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry(WavFileName, CompressionLevel.Optimal);
                    using (Stream entryStream = entry.Open())
                    {
                        entryStream.Write(wavBytes, 0, wavBytes.Length);
                    }
                }
                return zipMs.ToArray();
            }
        }

        private void SetupAssetRegistry()
        {
            byte[] zipBytes = CreateZipWithWav();
            AssetRegistry.RegisterAssembly(AssemblyName, () => new MemoryStream(zipBytes, false));
        }

        [Fact]
        public async Task Play_WithValidWavFromResources_ShouldSucceed()
        {
            try
            {
                SetupAssetRegistry();
                _player = new BrowserPlayer();
                Assert.NotNull(_player);

                await _player.Play(WavFileName);

                Assert.True(_player.Playing);
                Assert.False(_player.Paused);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        [Fact]
        public async Task Play_NullFileName_ShouldThrow()
        {
            try
            {
                SetupAssetRegistry();
                _player = new BrowserPlayer();

                await Assert.ThrowsAsync<ArgumentException>(() => _player.Play(null));
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        [Fact]
        public async Task Play_ThenStop_ShouldStopPlayback()
        {
            try
            {
                SetupAssetRegistry();
                _player = new BrowserPlayer();
                Assert.NotNull(_player);

                await _player.Play(WavFileName);
                Assert.True(_player.Playing);

                _player.Stop();
                Assert.False(_player.Playing);
                Assert.False(_player.Paused);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        [Fact]
        public async Task Play_ThenPauseThenResume_ShouldWork()
        {
            try
            {
                SetupAssetRegistry();
                _player = new BrowserPlayer();
                await _player.Play(WavFileName);
                Assert.True(_player.Playing);

                _player.Pause();
                Assert.True(_player.Paused);

                _player.Resume();
                Assert.True(_player.Playing);
                Assert.False(_player.Paused);

                _player.Stop();
                Assert.False(_player.Playing);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        [Fact]
        public async Task PlayLoop_WithAnyFile_ShouldDelegateToPlay()
        {
            try
            {
                SetupAssetRegistry();
                _player = new BrowserPlayer();
                await _player.PlayLoop(WavFileName, true);
                Assert.True(_player.Playing);

                _player.Stop();
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        [Fact]
        public async Task Play_WithNonExistentResource_ShouldThrow()
        {
            try
            {
                SetupAssetRegistry();
                _player = new BrowserPlayer();
                await Assert.ThrowsAsync<FileNotFoundException>(() => _player.Play("nonexistent_resource.wav"));
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }
    }
}
