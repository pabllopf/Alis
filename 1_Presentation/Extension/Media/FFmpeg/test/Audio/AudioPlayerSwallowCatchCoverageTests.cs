// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayerSwallowCatchCoverageTests.cs
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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     The audio player swallow catch coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class AudioPlayerSwallowCatchCoverageTests : IDisposable
    {
        /// <summary>
        ///     The temp dir
        /// </summary>
        private readonly string _tempDir;

        /// <summary>
        ///     The fake ffplay path
        /// </summary>
        private readonly string _fakeFfplayPath;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioPlayerSwallowCatchCoverageTests"/> class
        /// </summary>
        public AudioPlayerSwallowCatchCoverageTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);

            _fakeFfplayPath = Path.Combine(_tempDir, "ffplay");
            File.WriteAllText(_fakeFfplayPath, "#!/bin/bash\nexec sleep 30");
            using Process chmod = Process.Start("chmod", $"+x \"{_fakeFfplayPath}\"");
            chmod.WaitForExit();
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (Directory.Exists(_tempDir))
                {
                    try { Directory.Delete(_tempDir, recursive: true); } catch { }
                }
            }
        }

        /// <summary>
        ///     Gets the ffplay process using the specified player
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>The process</returns>
        private static Process GetFfplayp(AudioPlayer player)
        {
            FieldInfo field = typeof(AudioPlayer).GetField("ffplayp", BindingFlags.NonPublic | BindingFlags.Instance);
            return (Process)field.GetValue(player);
        }

        /// <summary>
        ///     Kills the process using the specified pid
        /// </summary>
        /// <param name="pid">The pid</param>
        private static void KillPid(int pid)
        {
            if (pid <= 0) return;
            try
            {
                using Process k = new Process();
                k.StartInfo.FileName = "kill";
                k.StartInfo.Arguments = "-9 " + pid;
                k.StartInfo.CreateNoWindow = true;
                k.StartInfo.UseShellExecute = false;
                k.Start();
                k.WaitForExit(5000);
            }
            catch
            {
            }
        }

        /// <summary>
        ///     Tests that OpenWrite kills a running ffplayp before reopening
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WithRunningFfplayp_ShouldKillAndReopen()
        {
            TestableAudioPlayer player = new TestableAudioPlayer(null, _fakeFfplayPath);
            int pid = -1;
            try
            {
                player.OpenWrite(44100, 2, 16);
                Process p = GetFfplayp(player);
                pid = p.Id;
                Assert.False(p.HasExited);
                player.SetOpenedForWriting(false);

                Exception ex = Record.Exception(() => player.OpenWrite(48000, 2, 16));

                Assert.Null(ex);
                Assert.True(player.OpenedForWriting);
                p.WaitForExit(5000);
                Assert.True(p.HasExited);
            }
            finally
            {
                KillPid(pid);
                player.Dispose();
            }
        }

        /// <summary>
        ///     Tests that OpenWrite swallows exceptions when killing a disposed ffplayp
        /// </summary>
        [RequireFfmpegFact]
        public void OpenWrite_WithDisposedFfplayp_ShouldReopen()
        {
            TestableAudioPlayer player = new TestableAudioPlayer(null, _fakeFfplayPath);
            int pid = -1;
            try
            {
                player.OpenWrite(44100, 2, 16);
                Process p = GetFfplayp(player);
                pid = p.Id;
                p.Dispose();
                player.SetOpenedForWriting(false);

                Exception ex = Record.Exception(() => player.OpenWrite(48000, 2, 16));

                Assert.Null(ex);
                Assert.True(player.OpenedForWriting);
            }
            finally
            {
                KillPid(pid);
                player.Dispose();
            }
        }

        /// <summary>
        ///     Tests that CloseWrite swallows the kill exception but rethrows on WaitForExit
        /// </summary>
        [RequireFfmpegFact]
        public void CloseWrite_WithDisposedFfplayp_ShouldThrowInvalidOperation()
        {
            TestableAudioPlayer player = new TestableAudioPlayer(null, _fakeFfplayPath);
            int pid = -1;
            try
            {
                player.OpenWrite(44100, 2, 16);
                Process p = GetFfplayp(player);
                pid = p.Id;
                p.Dispose();

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.CloseWrite());
                Assert.NotNull(ex);
                Assert.False(player.OpenedForWriting);
            }
            finally
            {
                KillPid(pid);
                player.Dispose();
            }
        }
    }
}
