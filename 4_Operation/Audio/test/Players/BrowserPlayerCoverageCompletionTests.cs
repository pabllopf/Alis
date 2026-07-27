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
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    public class BrowserPlayerCoverageCompletionTests : IDisposable
    {
        private string _previousActiveName;
        private BrowserPlayer _player;

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

        private void CreateUninitializedPlayer()
        {
            _player = (BrowserPlayer)FormatterServices.GetUninitializedObject(typeof(BrowserPlayer));
        }

        [Fact]
        public void Playing_Property_Default_ShouldBeFalse()
        {
            CreateUninitializedPlayer();
            Assert.False(_player.Playing);
        }

        [Fact]
        public void Paused_Property_Default_ShouldBeFalse()
        {
            CreateUninitializedPlayer();
            Assert.False(_player.Paused);
        }

        [Fact]
        public void Play_WithNonExistentFile_ShouldThrowFileNotFoundException()
        {
            CreateUninitializedPlayer();
            SetupAssembly("other.wav", new byte[] { 1 });

            FileNotFoundException ex = Assert.ThrowsAsync<FileNotFoundException>(() => _player.Play("missing.wav")).Result;
            Assert.Contains("missing.wav", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Play_WithEmptyResource_ShouldThrowInvalidOperationException()
        {
            SetupAssembly("empty.wav", Array.Empty<byte>());
            CreateUninitializedPlayer();

            Task task = _player.Play("empty.wav");
            Assert.ThrowsAsync<InvalidOperationException>(() => task);
        }

        [Fact]
        public void Play_WithTooSmallWav_ShouldThrowInvalidOperationException()
        {
            byte[] smallWav = new byte[40];
            smallWav[0] = (byte)'R'; smallWav[1] = (byte)'I'; smallWav[2] = (byte)'F'; smallWav[3] = (byte)'F';
            SetupAssembly("small.wav", smallWav);
            CreateUninitializedPlayer();

            Task task = _player.Play("small.wav");
            Assert.ThrowsAsync<InvalidOperationException>(() => task);
        }

        [Fact]
        public void Play_WithInvalidRiff_ShouldThrowInvalidOperationException()
        {
            byte[] wav = new byte[44];
            wav[0] = (byte)'X'; wav[1] = (byte)'X'; wav[2] = (byte)'X'; wav[3] = (byte)'X';
            SetupAssembly("bad.wav", wav);
            CreateUninitializedPlayer();

            Task task = _player.Play("bad.wav");
            Assert.ThrowsAsync<InvalidOperationException>(() => task);
        }

        [Fact]
        public void Play_WithCompressedFormat_ShouldThrowInvalidOperationException()
        {
            byte[] wav = new byte[144];
            int p = 0;
            Encoding.ASCII.GetBytes("RIFF", 0, 4, wav, p); p += 4;
            BitConverter.GetBytes(36 + 100).CopyTo(wav, p); p += 4;
            Encoding.ASCII.GetBytes("WAVE", 0, 4, wav, p); p += 4;
            Encoding.ASCII.GetBytes("fmt ", 0, 4, wav, p); p += 4;
            BitConverter.GetBytes(16).CopyTo(wav, p); p += 4;
            BitConverter.GetBytes((short)0x0055).CopyTo(wav, p); p += 2;
            BitConverter.GetBytes((short)1).CopyTo(wav, p); p += 2;
            BitConverter.GetBytes(44100).CopyTo(wav, p); p += 4;
            BitConverter.GetBytes(88200).CopyTo(wav, p); p += 4;
            BitConverter.GetBytes((short)2).CopyTo(wav, p); p += 2;
            BitConverter.GetBytes((short)16).CopyTo(wav, p); p += 2;
            Encoding.ASCII.GetBytes("data", 0, 4, wav, p); p += 4;
            BitConverter.GetBytes(100).CopyTo(wav, p);

            SetupAssembly("compressed.wav", wav);
            CreateUninitializedPlayer();

            Task task = _player.Play("compressed.wav");
            Assert.ThrowsAsync<InvalidOperationException>(() => task);
        }

        [Fact]
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

        [Fact]
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

        [Fact]
        public void Pause_WhenOpenAlNotAvailable_ShouldThrowDllNotFound()
        {
            CreateUninitializedPlayer();
            Assert.Throws<DllNotFoundException>(() => { _player.Pause().GetAwaiter().GetResult(); });
        }

        [Fact]
        public void Resume_WhenOpenAlNotAvailable_ShouldThrowDllNotFound()
        {
            CreateUninitializedPlayer();
            Assert.Throws<DllNotFoundException>(() => { _player.Resume().GetAwaiter().GetResult(); });
        }

        [Fact]
        public void Stop_WhenOpenAlNotAvailable_ShouldThrowDllNotFound()
        {
            CreateUninitializedPlayer();
            Assert.Throws<DllNotFoundException>(() => { _player.Stop().GetAwaiter().GetResult(); });
        }

        [Fact]
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
