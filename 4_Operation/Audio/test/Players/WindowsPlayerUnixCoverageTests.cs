// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowsPlayerUnixCoverageTests.cs
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     Exercises the WindowsPlayer entry points on hosts where the winmm native library
    ///     is unavailable.
    /// </summary>
    public class WindowsPlayerUnixCoverageTests : IDisposable
    {
        /// <summary>
        ///     The temp wav path used by the playback tests
        /// </summary>
        private readonly string _tempWav;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WindowsPlayerUnixCoverageTests"/> class
        /// </summary>
        public WindowsPlayerUnixCoverageTests()
        {
            _tempWav = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".wav");
            File.WriteAllText(_tempWav, "test");
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (File.Exists(_tempWav))
            {
                File.Delete(_tempWav);
            }
        }

        /// <summary>
        ///     Verifies that playing a missing file falls back to the resource lookup and
        ///     reports the file as not found.
        /// </summary>
        [Fact]
        public void Play_WithMissingFile_ThrowsFileNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.Throws<FileNotFoundException>(() => { player.Play("missing_resource_xyz.wav"); });
        }

        /// <summary>
        ///     Verifies that playing an existing file sets the playback state and fails at
        ///     the winmm boundary.
        /// </summary>
        [UnixOnly]
        public void Play_WithExistingFile_ThrowsDllNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.Throws<DllNotFoundException>(() => { player.Play(_tempWav); });
        }

        /// <summary>
        ///     Verifies that looping an existing file sets the playback state and fails at
        ///     the winmm boundary.
        /// </summary>
        [UnixOnly]
        public void PlayLoop_WithExistingFile_ThrowsDllNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.Throws<DllNotFoundException>(() => { player.PlayLoop(_tempWav, true); });
            Assert.Throws<DllNotFoundException>(() => { player.PlayLoop(_tempWav, false); });
        }

        /// <summary>
        ///     Verifies that a raw mci command fails at the winmm boundary.
        /// </summary>
        [UnixOnly]
        public void ExecuteMsiCommand_WithoutWinmm_ThrowsDllNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            Assert.Throws<DllNotFoundException>(() => player.ExecuteMsiCommand("Status x Length"));
        }

        /// <summary>
        ///     Verifies that pausing before playback starts is a safe no-op.
        /// </summary>
        [Fact]
        public void Pause_WhenNotPlaying_DoesNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            Task task = player.Pause();
            Assert.NotNull(task);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Verifies that disposing a player with a set file name stops playback at the
        ///     winmm boundary.
        /// </summary>
        [UnixOnly]
        public void Dispose_WithFileName_ThrowsDllNotFoundException()
        {
            WindowsPlayer player = new WindowsPlayer();
            player._fileName = "track.wav";
            Assert.Throws<DllNotFoundException>(() => { player.Dispose(); });
        }

        /// <summary>
        ///     Verifies that resuming before playback starts is a safe no-op.
        /// </summary>
        [Fact]
        public void Resume_WhenNotPlaying_DoesNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            Task task = player.Resume();
            Assert.NotNull(task);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }

        /// <summary>
        ///     Verifies that stopping before playback starts is a safe no-op.
        /// </summary>
        [Fact]
        public void Stop_WhenNotPlaying_DoesNotThrow()
        {
            WindowsPlayer player = new WindowsPlayer();
            Task task = player.Stop();
            Assert.NotNull(task);
            Assert.False(player.Playing);
            Assert.False(player.Paused);
        }
    }
}
