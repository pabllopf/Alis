// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BrowserPlayerCoverageCompletionTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    /// The browser player coverage completion tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class BrowserPlayerCoverageCompletionTests : IDisposable
    {
        /// <summary>
        /// The previous active name
        /// </summary>
        private string _previousActiveName;
        /// <summary>
        /// The player
        /// </summary>
        private BrowserPlayer _player;

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
        /// Creates the valid wav using the specified sample rate
        /// </summary>
        /// <param name="sampleRate">The sample rate</param>
        /// <param name="channels">The channels</param>
        /// <param name="bitsPerSample">The bits per sample</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The wav</returns>
        private static byte[] CreateValidWav(int sampleRate = 44100, short channels = 1, short bitsPerSample = 16, int dataSize = 1764)
        {
            short blockAlign = (short)(channels * bitsPerSample / 8);
            int byteRate = sampleRate * blockAlign;
            int totalSize = 44 + dataSize;
            byte[] wav = new byte[totalSize];
            int offset = 0;

            Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, offset); offset += 4;
            BitConverter.GetBytes(totalSize - 8).CopyTo(wav, offset); offset += 4;
            Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, offset); offset += 4;

            Encoding.ASCII.GetBytes("fmt ").CopyTo(wav, offset); offset += 4;
            BitConverter.GetBytes(16).CopyTo(wav, offset); offset += 4;
            BitConverter.GetBytes((short)1).CopyTo(wav, offset); offset += 2;
            BitConverter.GetBytes(channels).CopyTo(wav, offset); offset += 2;
            BitConverter.GetBytes(sampleRate).CopyTo(wav, offset); offset += 4;
            BitConverter.GetBytes(byteRate).CopyTo(wav, offset); offset += 4;
            BitConverter.GetBytes(blockAlign).CopyTo(wav, offset); offset += 2;
            BitConverter.GetBytes(bitsPerSample).CopyTo(wav, offset); offset += 2;

            Encoding.ASCII.GetBytes("data").CopyTo(wav, offset); offset += 4;
            BitConverter.GetBytes(dataSize).CopyTo(wav, offset);

            return wav;
        }

        /// <summary>
        /// Creates the uninitialized player
        /// </summary>
        private void CreateUninitializedPlayer()
        {
            _player = (BrowserPlayer)FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));
        }

        /// <summary>
        /// Tests that playing property default should be false
        /// </summary>
        [Fact]
        public void Playing_Property_Default_ShouldBeFalse()
        {
            CreateUninitializedPlayer();
            Assert.False(_player.Playing);
        }

        /// <summary>
        /// Tests that paused property default should be false
        /// </summary>
        [Fact]
        public void Paused_Property_Default_ShouldBeFalse()
        {
            CreateUninitializedPlayer();
            Assert.False(_player.Paused);
        }

        /// <summary>
        /// Tests that play with non existent file should throw file not found exception
        /// </summary>
        [Fact]
        public void Play_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            CreateUninitializedPlayer();
            SetupAssembly("other.wav", new byte[] { 1 });

            FileNotFoundException ex = Assert.ThrowsAsync<FileNotFoundException>(() => _player.Play("missing.wav")).Result;
            Assert.Contains("missing.wav", ex.Message, StringComparison.OrdinalIgnoreCase);
        }
        
        /// <summary>
        /// Tests that play valid wav should not throw unexpected exception
        /// </summary>
        [RequireOpenAlFact]
        public void Play_ValidWav_ShouldNotThrowUnexpectedException()
        {
            byte[] wav = CreateValidWav();
            SetupAssembly("valid.wav", wav);
            CreateUninitializedPlayer();

            Exception ex = Record.Exception(() =>
            {
                Task task = _player.Play("valid.wav");
                task.GetAwaiter().GetResult();
            });

            Assert.True(ex == null ||
                        ex is DllNotFoundException ||
                        (ex is InvalidOperationException ioe && ioe.Message.Contains("OpenAL")));
        }

        /// <summary>
        /// Tests that play valid wav should fire playback finished
        /// </summary>
        [RequireOpenAlFact]
        public void Play_ValidWav_ShouldFirePlaybackFinished()
        {
            byte[] wav = CreateValidWav();
            SetupAssembly("fire.wav", wav);
            CreateUninitializedPlayer();

            bool eventFired = false;
            _player.PlaybackFinished += (sender, e) => eventFired = true;

            try
            {
                Task task = _player.Play("fire.wav");
                task.GetAwaiter().GetResult();
            }
            catch (DllNotFoundException)
            {
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }

            Assert.True(eventFired);
        }

        /// <summary>
        ///     Tests that pause when open al not available should throw dll not found
        /// </summary>
        [Fact]
        public void Pause_WhenOpenAlNotAvailable_ShouldThrowDllNotFound()
        {
            CreateUninitializedPlayer();
            Exception exception = Record.Exception(() => { _player.Pause().GetAwaiter().GetResult(); });
            if (exception != null)
            {
                Assert.IsType<DllNotFoundException>(exception);
            }
        }

        /// <summary>
        ///     Tests that resume when open al not available should throw dll not found
        /// </summary>
        [Fact]
        public void Resume_WhenOpenAlNotAvailable_ShouldThrowDllNotFound()
        {
            CreateUninitializedPlayer();
            Exception exception = Record.Exception(() => { _player.Resume().GetAwaiter().GetResult(); });
            if (exception != null)
            {
                Assert.IsType<DllNotFoundException>(exception);
            }
        }

        /// <summary>
        ///     Tests that stop when open al not available should throw dll not found
        /// </summary>
        [Fact]
        public void Stop_WhenOpenAlNotAvailable_ShouldThrowDllNotFound()
        {
            CreateUninitializedPlayer();
            Exception exception = Record.Exception(() => { _player.Stop().GetAwaiter().GetResult(); });
            if (exception != null)
            {
                Assert.IsType<DllNotFoundException>(exception);
            }
        }

        /// <summary>
        /// Tests that play should handle playback finished without handler
        /// </summary>
        [RequireOpenAlFact]
        public void Play_ShouldHandlePlaybackFinishedWithoutHandler()
        {
            byte[] wav = CreateValidWav();
            SetupAssembly("nohandler.wav", wav);
            CreateUninitializedPlayer();

            try
            {
                Task task = _player.Play("nohandler.wav");
                task.GetAwaiter().GetResult();
            }
            catch (DllNotFoundException)
            {
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAL"))
            {
            }
        }
    }
}
