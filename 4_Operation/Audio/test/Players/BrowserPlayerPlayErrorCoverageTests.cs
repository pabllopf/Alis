using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The browser player play error coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class BrowserPlayerPlayErrorCoverageTests : IDisposable
    {
        /// <summary>
        /// The player
        /// </summary>
        private BrowserPlayer _player;
        /// <summary>
        /// The previous active name
        /// </summary>
        private string _previousActiveName;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (_previousActiveName != null)
                AssetRegistryTestHelper.RestoreActive(_previousActiveName);
            try { _player?.Stop(); } catch { }
        }

        /// <summary>
        /// Setup the assembly using the specified entry name
        /// </summary>
        /// <param name="entryName">The entry name</param>
        /// <param name="content">The content</param>
        /// <returns>The name</returns>
        private string SetupAssembly(string entryName, byte[] content)
        {
            _previousActiveName = AssetRegistryTestHelper.SaveAndSetActive(null);
            string name = AssetRegistryTestHelper.RegisterNewAssembly(entryName, content);
            AssetRegistryTestHelper.SaveAndSetActive(name);
            return name;
        }

        /// <summary>
        /// Tests that play with invalid wav data should throw invalid operation exception
        /// </summary>
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

        /// <summary>
        /// Tests that play with too small wav data should throw invalid operation exception
        /// </summary>
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

        /// <summary>
        /// Tests that play with compressed wav format should throw invalid operation exception
        /// </summary>
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

        /// <summary>
        /// Tests that play with non existent resource should throw file not found exception
        /// </summary>
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

        /// <summary>
        /// Tests that play with playback finished handler should invoke event
        /// </summary>
        [Fact]
        public async Task Play_WithPlaybackFinishedHandler_ShouldInvokeEvent()
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

            SetupAssembly("eventTest.wav", wavBytes);

            try
            {
                _player = new BrowserPlayer();
                bool eventRaised = false;
                _player.PlaybackFinished += (sender, e) => eventRaised = true;

                await _player.Play("eventTest.wav");
                Assert.True(eventRaised);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        /// <summary>
        /// Tests that play with empty resource should throw
        /// </summary>
        [Fact]
        public async Task Play_WithEmptyResource_ShouldThrow()
        {
            SetupAssembly("empty.wav", Array.Empty<byte>());

            try
            {
                _player = new BrowserPlayer();
                await Assert.ThrowsAsync<InvalidOperationException>(() => _player.Play("empty.wav"));
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
            catch (DllNotFoundException)
            {
            }
        }

        /// <summary>
        /// Tests that play without event handler should not throw
        /// </summary>
        [Fact]
        public async Task Play_WithoutEventHandler_ShouldNotThrow()
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

            SetupAssembly("noHandler.wav", wavBytes);

            try
            {
                _player = new BrowserPlayer();
                await _player.Play("noHandler.wav");

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

        /// <summary>
        /// Tests that play loop with valid wav should delegate to play
        /// </summary>
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
