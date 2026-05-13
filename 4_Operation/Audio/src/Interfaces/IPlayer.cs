// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPlayer.cs
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
using System.Threading.Tasks;

namespace Alis.Core.Audio.Interfaces
{
    /// <summary>
    ///     Defines the contract for audio playback implementations across different platforms.
    ///     Provides methods for play, pause, resume, stop, and volume control of audio files.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        ///     Gets a value indicating whether audio playback is currently in progress.
        /// </summary>
        bool Playing { get; }

        /// <summary>
        ///     Gets a value indicating whether audio playback is currently paused.
        /// </summary>
        bool Paused { get; }

        /// <summary>
        ///     Occurs when the current audio playback has finished.
        /// </summary>
        event EventHandler PlaybackFinished;

        /// <summary>
        ///     Starts playback of the specified audio file. Stops any current playback before starting.
        /// </summary>
        /// <param name="fileName">The absolute or relative path to the audio file to play.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        Task Play(string fileName);

        /// <summary>
        ///     Starts playback of the specified audio file with optional looping. Stops any current playback before starting.
        /// </summary>
        /// <param name="fileName">The absolute or relative path to the audio file to play.</param>
        /// <param name="loop">If <c>true</c>, the audio file will be played in a continuous loop; otherwise, it plays once.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        Task PlayLoop(string fileName, bool loop);

        /// <summary>
        ///     Pauses the currently playing audio, preserving the current playback position.
        /// </summary>
        /// <returns>A task that represents the asynchronous pause operation.</returns>
        Task Pause();

        /// <summary>
        ///     Resumes playback of a previously paused audio file from the stored position.
        /// </summary>
        /// <returns>A task that represents the asynchronous resume operation.</returns>
        Task Resume();

        /// <summary>
        ///     Stops the current audio playback and resets the playback position to the beginning.
        /// </summary>
        /// <returns>A task that represents the asynchronous stop operation.</returns>
        Task Stop();

        /// <summary>
        ///     Sets the audio playback volume.
        /// </summary>
        /// <param name="percent">The volume level as a percentage from 0 to 100, where 0 is silence and 100 is maximum.</param>
        /// <returns>A task that represents the asynchronous volume set operation.</returns>
        Task SetVolume(byte percent);
    }
}
