// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBaseRemainingCoverageTests.cs
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
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The unix player base remaining coverage tests class
    /// </summary>
    public class UnixPlayerBaseRemainingCoverageTests
    {
        /// <summary>
        ///     The test player for coverage class
        /// </summary>
        private class TestPlayerForCoverage : UnixPlayerBase
        {
            /// <summary>
            ///     Gets the bash command using the specified file name
            /// </summary>
            /// <param name="fileName">The file name</param>
            /// <returns>The command</returns>
            internal override string GetBashCommand(string fileName) => "true";

            /// <summary>
            ///     Sets the volume using the specified percent
            /// </summary>
            /// <param name="percent">The percent</param>
            /// <returns>The task</returns>
            public override Task SetVolume(byte percent) => Task.CompletedTask;

            /// <summary>
            ///     Handles the playback finished using the specified sender
            /// </summary>
            /// <param name="sender">The sender</param>
            /// <param name="e">The e</param>
            public new void HandlePlaybackFinished(object sender, EventArgs e) => base.HandlePlaybackFinished(sender, e);
        }

        /// <summary>
        ///     Creates the valid wav
        /// </summary>
        /// <returns>The wav</returns>
        private static byte[] CreateValidWav()
        {
            const int sampleRate = 44100;
            const short channels = 1;
            const short bitsPerSample = 16;
            const int dataSize = 1764;
            short blockAlign = (short) (channels * bitsPerSample / 8);
            int byteRate = sampleRate * blockAlign;
            int totalSize = 44 + dataSize;
            byte[] wav = new byte[totalSize];
            int offset = 0;

            Encoding.ASCII.GetBytes("RIFF").CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes(totalSize - 8).CopyTo(wav, offset);
            offset += 4;
            Encoding.ASCII.GetBytes("WAVE").CopyTo(wav, offset);
            offset += 4;

            Encoding.ASCII.GetBytes("fmt ").CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes(16).CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes((short) 1).CopyTo(wav, offset);
            offset += 2;
            BitConverter.GetBytes(channels).CopyTo(wav, offset);
            offset += 2;
            BitConverter.GetBytes(sampleRate).CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes(byteRate).CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes(blockAlign).CopyTo(wav, offset);
            offset += 2;
            BitConverter.GetBytes(bitsPerSample).CopyTo(wav, offset);
            offset += 2;

            Encoding.ASCII.GetBytes("data").CopyTo(wav, offset);
            offset += 4;
            BitConverter.GetBytes(dataSize).CopyTo(wav, offset);

            return wav;
        }

        /// <summary>
        ///     Tests that handle playback finished with playing invokes the event.
        /// </summary>
        [Fact]
        public async Task HandlePlaybackFinished_WithPlayingTrue_InvokesEvent()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            int invoked = 0;
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.Play(tempFile);
                Assert.True(player.Playing);
                player.PlaybackFinished += (sender, e) => invoked++;
                player.HandlePlaybackFinished(player, EventArgs.Empty);

                Assert.False(player.Playing);
                Assert.Equal(1, invoked);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        /// <summary>
        ///     Tests that handle playback finished when not playing does not invoke the event.
        /// </summary>
        [Fact]
        public async Task HandlePlaybackFinished_WhenNotPlaying_DoesNotInvokeEvent()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            int invoked = 0;
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.Play(tempFile);
                player.PlaybackFinished += (sender, e) => invoked++;
                player.HandlePlaybackFinished(player, EventArgs.Empty);
                player.HandlePlaybackFinished(player, EventArgs.Empty);

                Assert.False(player.Playing);
                Assert.Equal(1, invoked);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        /// <summary>
        ///     Tests that get audio duration with a real wav file parses the duration.
        /// </summary>
        [Fact]
        public async Task PlayLoop_WithRealWavFile_ParsesDuration()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllBytes(tempFile, CreateValidWav());
                await player.PlayLoop(tempFile, false);

                Assert.True(player.Playing);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        /// <summary>
        ///     The sleeping player for coverage class
        /// </summary>
        private class SleepingPlayerForCoverage : UnixPlayerBase
        {
            /// <summary>
            ///     Gets the bash command using the specified file name
            /// </summary>
            /// <param name="fileName">The file name</param>
            /// <returns>The command</returns>
            internal override string GetBashCommand(string fileName) => "sleep 5; true";

            /// <summary>
            ///     Sets the volume using the specified percent
            /// </summary>
            /// <param name="percent">The percent</param>
            /// <returns>The task</returns>
            public override Task SetVolume(byte percent) => Task.CompletedTask;
        }

        /// <summary>
        ///     Tests that resume after pause clears the paused state.
        /// </summary>
        [Fact]
        public async Task Resume_AfterPause_ClearsPausedState()
        {
            SleepingPlayerForCoverage player = new SleepingPlayerForCoverage();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.Play(tempFile);
                Assert.True(player.Playing);
                await player.Pause();
                Assert.True(player.Paused);
                await player.Resume();

                Assert.False(player.Paused);
            }
            finally
            {
                await player.Stop();
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        /// <summary>
        ///     Tests that get audio duration with a missing file throws file not found exception.
        /// </summary>
        [Fact]
        public void GetAudioDuration_WithMissingFile_ThrowsFileNotFoundException()
        {
            TestPlayerForCoverage player = new TestPlayerForCoverage();
            MethodInfo method = typeof(UnixPlayerBase).GetMethod("GetAudioDuration",
                BindingFlags.NonPublic | BindingFlags.Instance);

            TargetInvocationException ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(player, new object[] { "nonexistent_file_12345.wav" }));

            Assert.IsType<FileNotFoundException>(ex.InnerException);
            Assert.Contains("no existe", ex.InnerException.Message);
        }
    }
}
