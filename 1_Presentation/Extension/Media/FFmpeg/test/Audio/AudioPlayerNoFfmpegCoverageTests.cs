// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayerNoFfmpegCoverageTests.cs
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
using System.Reflection;
using Alis.Extension.Media.FFmpeg.Audio;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio
{
    /// <summary>
    ///     Coverage tests for AudioPlayer that do not require FFmpeg/ffplay.
    /// </summary>
    public class AudioPlayerNoFfmpegCoverageTests : IDisposable
    {
        /// <summary>
        ///     The player
        /// </summary>
        private AudioPlayer _player;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioPlayerNoFfmpegCoverageTests"/> class
        /// </summary>
        public AudioPlayerNoFfmpegCoverageTests()
        {
            _player = new AudioPlayer();
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _player?.Dispose();
        }

        /// <summary>
        ///     Tests that default constructor sets Filename to null
        /// </summary>
        [Fact]
        public void DefaultConstructor_SetsFilenameToNull()
        {
            AudioPlayer player = new AudioPlayer();
            Assert.Null(player.Filename);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that constructor with input sets Filename
        /// </summary>
        [Fact]
        public void Constructor_WithInput_SetsFilename()
        {
            AudioPlayer player = new AudioPlayer("test.mp3");
            Assert.Equal("test.mp3", player.Filename);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that constructor with input and custom executable sets fields
        /// </summary>
        [Fact]
        public void Constructor_WithCustomExecutable_SetsFields()
        {
            AudioPlayer player = new AudioPlayer("test.wav", "custom-ffplay");
            Assert.Equal("test.wav", player.Filename);
            FieldInfo ffplayField = typeof(AudioPlayer).GetField("ffplay",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Equal("custom-ffplay", ffplayField.GetValue(player));
            player.Dispose();
        }

        /// <summary>
        ///     Tests that OpenedForWriting is false initially
        /// </summary>
        [Fact]
        public void OpenedForWriting_Default_IsFalse()
        {
            AudioPlayer player = new AudioPlayer();
            Assert.False(player.OpenedForWriting);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that Play throws when no filename specified
        /// </summary>
        [Fact]
        public void Play_NoFilename_ThrowsInvalidOperationException()
        {
            AudioPlayer player = new AudioPlayer();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.Play());
            Assert.Contains("No filename was specified", ex.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that PlayInBackground throws when no filename specified
        /// </summary>
        [Fact]
        public void PlayInBackground_NoFilename_ThrowsInvalidOperationException()
        {
            AudioPlayer player = new AudioPlayer();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.PlayInBackground());
            Assert.Contains("No filename was specified", ex.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that OpenWrite throws on invalid bit depth 8
        /// </summary>
        [Fact]
        public void OpenWrite_BitDepth8_ThrowsInvalidOperationException()
        {
            AudioPlayer player = new AudioPlayer("test.wav");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.OpenWrite(44100, 2, 8));
            Assert.Contains("Acceptable bit depths", ex.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that OpenWrite throws on invalid bit depth 12
        /// </summary>
        [Fact]
        public void OpenWrite_BitDepth12_ThrowsInvalidOperationException()
        {
            AudioPlayer player = new AudioPlayer("test.wav");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.OpenWrite(44100, 2, 12));
            Assert.Contains("Acceptable bit depths", ex.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that OpenWrite throws on invalid bit depth 20
        /// </summary>
        [Fact]
        public void OpenWrite_BitDepth20_ThrowsInvalidOperationException()
        {
            AudioPlayer player = new AudioPlayer("test.wav");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.OpenWrite(44100, 2, 20));
            Assert.Contains("Acceptable bit depths", ex.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that CloseWrite throws when not opened for writing
        /// </summary>
        [Fact]
        public void CloseWrite_NotOpened_ThrowsInvalidOperationException()
        {
            AudioPlayer player = new AudioPlayer("test.wav");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => player.CloseWrite());
            Assert.Contains("not opened for writing", ex.Message);
            player.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose completes without exception
        /// </summary>
        [Fact]
        public void Dispose_CompletesWithoutException()
        {
            AudioPlayer player = new AudioPlayer("test.wav");
            Exception ex = Record.Exception(() => player.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that Dispose can be called multiple times safely
        /// </summary>
        [Fact]
        public void Dispose_MultipleTimes_DoesNotThrow()
        {
            AudioPlayer player = new AudioPlayer("test.wav");
            player.Dispose();
            player.Dispose();
            player.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose kills process when ffplayp is non-null and not exited
        /// </summary>
        [Fact]
        public void Dispose_ProcessRunning_KillsProcess()
        {
            AudioPlayer player = new AudioPlayer("test.wav");

            using Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.Arguments = "-c \"sleep 30\"";
            process.StartInfo.UseShellExecute = false;
            process.Start();

            FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffplaypField.SetValue(player, process);

            player.Dispose();

            Assert.True(process.HasExited || process.WaitForExit(5000));
        }

        /// <summary>
        ///     Tests that Dispose with exited process in else block completes safely
        /// </summary>
        [Fact]
        public void Dispose_ProcessExited_ElseBlockCompletes()
        {
            AudioPlayer player = new AudioPlayer("test.wav");

            using Process process = new Process();
            process.StartInfo.FileName = "dotnet";
            process.StartInfo.Arguments = "--version";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit(5000);

            FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffplaypField.SetValue(player, process);

            Exception ex = Record.Exception(() => player.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that Dispose with null ffplayp does not throw
        /// </summary>
        [Fact]
        public void Dispose_NullProcess_DoesNotThrow()
        {
            AudioPlayer player = new AudioPlayer("test.wav");
            FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            ffplaypField.SetValue(player, null);

            Exception ex = Record.Exception(() => player.Dispose());
            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that ffplayp field is null initially
        /// </summary>
        [Fact]
        public void FfplaypField_Default_IsNull()
        {
            AudioPlayer player = new AudioPlayer();
            FieldInfo ffplaypField = typeof(AudioPlayer).GetField("ffplayp",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Null(ffplaypField.GetValue(player));
            player.Dispose();
        }

        /// <summary>
        ///     Tests that ffplay field is set by constructor
        /// </summary>
        [Fact]
        public void FfplayField_Default_IsFfplay()
        {
            AudioPlayer player = new AudioPlayer();
            FieldInfo ffplayField = typeof(AudioPlayer).GetField("ffplay",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Equal("ffplay", ffplayField.GetValue(player));
            player.Dispose();
        }

        /// <summary>
        ///     Tests that ffplay field is set to custom value by constructor
        /// </summary>
        [Fact]
        public void FfplayField_Custom_IsSet()
        {
            AudioPlayer player = new AudioPlayer(null, "my-ffplay");
            FieldInfo ffplayField = typeof(AudioPlayer).GetField("ffplay",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Equal("my-ffplay", ffplayField.GetValue(player));
            player.Dispose();
        }
    }
}
