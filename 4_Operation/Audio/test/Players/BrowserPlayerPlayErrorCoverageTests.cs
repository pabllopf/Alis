using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class BrowserPlayerPlayErrorCoverageTests : IDisposable
    {
        private BrowserPlayer _player;
        private string _previousActiveName;

        public void Dispose()
        {
            if (_previousActiveName != null)
                AssetRegistryTestHelper.RestoreActive(_previousActiveName);
            try { _player?.Stop(); } catch { }
        }

        private string SetupAssembly(string entryName, byte[] content)
        {
            _previousActiveName = AssetRegistryTestHelper.SaveAndSetActive(null);
            string name = AssetRegistryTestHelper.RegisterNewAssembly(entryName, content);
            AssetRegistryTestHelper.SaveAndSetActive(name);
            return name;
        }

        [Fact]
        public async Task Play_WithInvalidWavData_ShouldThrowInvalidOperationException()
        {
            byte[] badWavData = Encoding.ASCII.GetBytes("NOT A WAV FILE");
            SetupAssembly("bad.wav", badWavData);

            try
            {
                _player = new BrowserPlayer();
                InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => _player.Play("bad.wav"));
                Assert.Contains("WAV", ex.Message);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        [Fact]
        public async Task Play_WithTooSmallWavData_ShouldThrowInvalidOperationException()
        {
            byte[] wavBytes = new byte[40];
            wavBytes[0] = (byte)'R'; wavBytes[1] = (byte)'I'; wavBytes[2] = (byte)'F'; wavBytes[3] = (byte)'F';
            SetupAssembly("small.wav", wavBytes);

            try
            {
                _player = new BrowserPlayer();
                InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => _player.Play("small.wav"));
                Assert.Contains("WAV", ex.Message);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        [Fact]
        public async Task Play_WithCompressedWavFormat_ShouldThrowInvalidOperationException()
        {
            byte[] wavBytes = new byte[144];
            int pos = 0;
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wavBytes, pos); pos += 4;
            BitConverter.GetBytes(36 + 100).CopyTo(wavBytes, pos); pos += 4;
            Encoding.ASCII.GetBytes("WAVE", 0, 4, wavBytes, pos); pos += 4;

            Encoding.ASCII.GetBytes("fmt ", 0, 4, wavBytes, pos); pos += 4;
            BitConverter.GetBytes(16).CopyTo(wavBytes, pos); pos += 4;
            BitConverter.GetBytes((short)0x0055).CopyTo(wavBytes, pos); pos += 2;
            BitConverter.GetBytes((short)1).CopyTo(wavBytes, pos); pos += 2;
            BitConverter.GetBytes(44100).CopyTo(wavBytes, pos); pos += 4;
            BitConverter.GetBytes(88200).CopyTo(wavBytes, pos); pos += 4;
            BitConverter.GetBytes((short)2).CopyTo(wavBytes, pos); pos += 2;
            BitConverter.GetBytes((short)16).CopyTo(wavBytes, pos); pos += 2;

            Encoding.ASCII.GetBytes("data", 0, 4, wavBytes, pos); pos += 4;
            BitConverter.GetBytes(100).CopyTo(wavBytes, pos);

            SetupAssembly("mp3wav.wav", wavBytes);

            try
            {
                _player = new BrowserPlayer();
                InvalidOperationException ex = await Assert.ThrowsAsync<InvalidOperationException>(() => _player.Play("mp3wav.wav"));
                Assert.Contains("WAV", ex.Message);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        [Fact]
        public async Task Play_WithNonExistentResource_ShouldThrowFileNotFoundException()
        {
            SetupAssembly("some_other_file.wav", new byte[] { 1, 2, 3 });

            try
            {
                _player = new BrowserPlayer();
                await Assert.ThrowsAsync<FileNotFoundException>(() => _player.Play("nonexistent.wav"));
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        [Fact]
        public async Task PlayLoop_WithValidWav_ShouldDelegateToPlay()
        {
            byte[] wavBytes = new byte[144];
            int pos = 0;
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wavBytes, pos); pos += 4;
            BitConverter.GetBytes(36 + 100).CopyTo(wavBytes, pos); pos += 4;
            Encoding.ASCII.GetBytes("WAVE", 0, 4, wavBytes, pos); pos += 4;

            Encoding.ASCII.GetBytes("fmt ", 0, 4, wavBytes, pos); pos += 4;
            BitConverter.GetBytes(16).CopyTo(wavBytes, pos); pos += 4;
            BitConverter.GetBytes((short)1).CopyTo(wavBytes, pos); pos += 2;
            BitConverter.GetBytes((short)1).CopyTo(wavBytes, pos); pos += 2;
            BitConverter.GetBytes(44100).CopyTo(wavBytes, pos); pos += 4;
            BitConverter.GetBytes(88200).CopyTo(wavBytes, pos); pos += 4;
            BitConverter.GetBytes((short)2).CopyTo(wavBytes, pos); pos += 2;
            BitConverter.GetBytes((short)16).CopyTo(wavBytes, pos); pos += 2;

            Encoding.ASCII.GetBytes("data", 0, 4, wavBytes, pos); pos += 4;
            BitConverter.GetBytes(100).CopyTo(wavBytes, pos);

            SetupAssembly("looptest.wav", wavBytes);

            try
            {
                _player = new BrowserPlayer();
                await _player.PlayLoop("looptest.wav", true);
                Assert.True(_player.Playing);
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
    }
}
