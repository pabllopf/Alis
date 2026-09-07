// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBasePauseResumeCoverageTests.cs
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
using Alis.Core.Audio.Test.Players.Attributes;
using Xunit;

namespace Alis.Core.Audio.Test.Players
{
    /// <summary>
    ///     The unix player base pause resume coverage tests class
    /// </summary>
    public class UnixPlayerBasePauseResumeCoverageTests
    {
        /// <summary>
        ///     The long running player class
        /// </summary>
        private class LongRunningPlayer : UnixPlayerBase
        {
            /// <summary>
            ///     Sets the volume using the specified percent
            /// </summary>
            /// <param name="percent">The percent</param>
            public override Task SetVolume(byte percent) =>
                Task.CompletedTask;

            /// <summary>
            ///     Gets the bash command using the specified file name
            /// </summary>
            /// <param name="fileName">The file name</param>
            /// <returns>The string</returns>
            internal override string GetBashCommand(string fileName) =>
                "(sleep 2) #";
        }

        /// <summary>
        ///     Tests that pause when playing sets paused true
        /// </summary>
        [UnixOnly]
        public async Task Pause_WhenPlayingAndNotPaused_SetsPausedTrue()
        {
            LongRunningPlayer player = new LongRunningPlayer();
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllText(tempFile, "test");
                await player.Play(tempFile);
                Assert.True(player.Playing);
                Assert.False(player.Paused);

                await player.Pause();

                Assert.True(player.Paused);
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
    }
}
