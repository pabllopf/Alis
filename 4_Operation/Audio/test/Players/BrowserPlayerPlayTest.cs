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
        private string _previousActiveName;
        private const string WavFileName = "test_sound.wav";

        public void Dispose()
        {
            if (_previousActiveName != null)
                AssetRegistryTestHelper.RestoreActive(_previousActiveName);
            try { _player?.Stop(); } catch { }
        }

        private string SetupNewAssembly()
        {
            _previousActiveName = AssetRegistryTestHelper.SaveAndSetActive(null);

            int sampleRate = 44100;
            short channels = 1;
            short bitsPerSample = 16;
            int dataSize = 1764;
            int blockAlign = channels * bitsPerSample / 8;
            int byteRate = sampleRate * blockAlign;

            byte[] wavBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);
                ms.Write(BitConverter.GetBytes(36 + dataSize), 0, 4);
                ms.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);
                ms.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);
                ms.Write(BitConverter.GetBytes(16), 0, 4);
                ms.Write(BitConverter.GetBytes((short)1), 0, 2);
                ms.Write(BitConverter.GetBytes(channels), 0, 2);
                ms.Write(BitConverter.GetBytes(sampleRate), 0, 4);
                ms.Write(BitConverter.GetBytes(byteRate), 0, 4);
                ms.Write(BitConverter.GetBytes((short)blockAlign), 0, 2);
                ms.Write(BitConverter.GetBytes(bitsPerSample), 0, 2);
                ms.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
                ms.Write(BitConverter.GetBytes(dataSize), 0, 4);
                ms.Write(new byte[dataSize], 0, dataSize);
                wavBytes = ms.ToArray();
            }

            return AssetRegistryTestHelper.RegisterNewAssembly(WavFileName, wavBytes);
        }

        private void SetupPlayer()
        {
            string name = SetupNewAssembly();
            AssetRegistryTestHelper.SaveAndSetActive(name);
            _player = new BrowserPlayer();
        }

        [Fact]
        public async Task Play_WithValidWavFromResources_ShouldSucceed()
        {
            try
            {
                SetupPlayer();
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
            string name = SetupNewAssembly();
            AssetRegistryTestHelper.SaveAndSetActive(name);

            if (!IsOpenAlAvailable())
            {
                Assert.ThrowsAnyAsync<Exception>(() =>
                {
                    BrowserPlayer p = new BrowserPlayer();
                    return p.Play(null);
                });
                return;
            }
            _player = new BrowserPlayer();
            await Assert.ThrowsAsync<ArgumentException>(() => _player.Play(null));
        }

        [Fact]
        public async Task Play_ThenStop_ShouldStopPlayback()
        {
            try
            {
                SetupPlayer();
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
                SetupPlayer();
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
                SetupPlayer();
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
            string name = SetupNewAssembly();
            AssetRegistryTestHelper.SaveAndSetActive(name);

            if (!IsOpenAlAvailable())
            {
                return;
            }
            _player = new BrowserPlayer();
            await Assert.ThrowsAsync<FileNotFoundException>(() => _player.Play("nonexistent_resource.wav"));
        }

        private static bool IsOpenAlAvailable()
        {
            try
            {
                BrowserPlayer p = new BrowserPlayer();
                p.Stop();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
