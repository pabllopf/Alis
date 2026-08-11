// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBaseFullCoverageTests.cs
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

using System.IO;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The unix player base full coverage tests class
    /// </summary>
    public class UnixPlayerBaseFullCoverageTests
    {
        /// <summary>
        ///     Tests that pause with a playing process pauses the audio
        /// </summary>
        [Fact]
        public async Task Pause_WithPlayingProcess_PausesAudio()
        {
            string tempFile = Path.Combine(Path.GetTempPath(), "30");
            File.WriteAllBytes(tempFile, CreateMinimalWav());

            try
            {
                UnixPlayerBase player = new TestPlayerForCoverage();
                await player.Play(tempFile);
                await player.Pause();
                Assert.True(player.Paused);
                await player.Stop();
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        ///     Tests that play with a nonexistent file throws a file not found exception
        /// </summary>
        [Fact]
        public async Task Play_WithNonExistentFile_Throws()
        {
            UnixPlayerBase player = new TestPlayerForCoverage();

            await Assert.ThrowsAnyAsync<System.Exception>(() => player.Play(Path.Combine(Path.GetTempPath(), "unix_missing_file_xyz.wav")));
        }

        /// <summary>
        ///     Concrete test implementation of the abstract unix player base
        /// </summary>
        private class TestPlayerForCoverage : UnixPlayerBase
        {
            /// <summary>
            ///     Sets the volume using the specified percent
            /// </summary>
            /// <param name="percent">The percent</param>
            public override Task SetVolume(byte percent) => Task.CompletedTask;

            /// <summary>
            ///     Gets the bash command using the specified file name
            /// </summary>
            /// <param name="fileName">The file name</param>
            /// <returns>The string</returns>
            internal override string GetBashCommand(string fileName) => "sleep 2 #";

        }

        /// <summary>
        ///     Creates a minimal valid wav file
        /// </summary>
        /// <returns>The wav bytes</returns>
        private static byte[] CreateMinimalWav()
        {
            using MemoryStream ms = new MemoryStream();
            using BinaryWriter writer = new BinaryWriter(ms);
            writer.Write("RIFF"u8);
            writer.Write(36);
            writer.Write("WAVE"u8);
            writer.Write("fmt "u8);
            writer.Write(16);
            writer.Write((short) 1);
            writer.Write((short) 1);
            writer.Write(8000);
            writer.Write(16000);
            writer.Write((short) 2);
            writer.Write((short) 16);
            writer.Write("data"u8);
            writer.Write(0);
            writer.Flush();
            return ms.ToArray();
        }
    }
}
