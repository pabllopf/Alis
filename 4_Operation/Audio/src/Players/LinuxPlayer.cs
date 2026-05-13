// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinuxPlayer.cs
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
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     Audio player implementation for Linux platforms.
    ///     Uses ALSA (amixer) for volume control and delegates playback to Unix command-line tools
    ///     such as aplay (for WAV) or mpg123 (for MP3 and other formats).
    /// </summary>
    /// <seealso cref="UnixPlayerBase" />
    /// <seealso cref="IPlayer" />
    internal class LinuxPlayer : UnixPlayerBase, IPlayer
    {
        /// <summary>
        ///     Sets the system master volume using the ALSA amixer command-line tool.
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

            Process tempProcess = StartBashProcess($"amixer -M set 'Master' {percent}%");
            tempProcess.WaitForExit();

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Returns the appropriate bash command-line audio player for the given file based on its extension.
        ///     Uses mpg123 for WAV files and aplay for all other formats.
        /// </summary>
        /// <param name="fileName">The path to the audio file.</param>
        /// <returns>The name of the command-line player tool (e.g., "aplay -q" or "mpg123 -q").</returns>
        internal override string GetBashCommand(string fileName)
        {
            if (Path.GetExtension(fileName).ToLower().Equals(".wav"))
            {
                return "mpg123 -q";
            }

            return "aplay -q";
        }
    }
}
