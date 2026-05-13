// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacPlayer.cs
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
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     Audio player implementation for macOS platforms.
    ///     Uses AppleScript (osascript) for volume control and the afplay command-line tool for audio playback.
    /// </summary>
    /// <seealso cref="UnixPlayerBase" />
    /// <seealso cref="IPlayer" />
    internal class MacPlayer : UnixPlayerBase, IPlayer
    {
        /// <summary>
        ///     Sets the system output volume on macOS using the osascript command-line utility.
        /// </summary>
        /// <param name="percent">The volume level as a percentage from 0 to 100.</param>
        /// <returns>A task that represents the asynchronous volume change operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="percent" /> exceeds 100.</exception>
        public override Task SetVolume(byte percent)
        {
            if (percent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percent), "Percent can't exceed 100");
            }

            Process tempProcess = StartBashProcess($"osascript -e \"set volume output volume {percent}\"");
            tempProcess.WaitForExit();

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Returns the bash command for audio playback on macOS, which is always "afplay".
        /// </summary>
        /// <param name="fileName">The path to the audio file (used for potential extension-based dispatch, currently unused).</param>
        /// <returns>The string "afplay" representing the macOS command-line audio player.</returns>
        internal override string GetBashCommand(string fileName) => "afplay";
    }
}
