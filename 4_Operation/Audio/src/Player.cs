// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Player.cs
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
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;

namespace Alis.Core.Audio
{
    /// <summary>
    ///     The top-level audio player that delegates playback to the appropriate platform-specific implementation.
    ///     Automatically detects the current operating system and selects the corresponding player (Windows, macOS, Linux,
    ///     or Web).
    /// </summary>
    /// <seealso cref="IPlayer" />
    public class Player : IPlayer
    {
        /// <summary>
        ///     The platform-specific player instance determined at construction time via OS detection.
        /// </summary>
        private readonly IPlayer _internalPlayer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        ///     Detects the current operating system and creates the appropriate internal player implementation.
        /// </summary>
        /// <exception cref="Exception">Thrown when no audio player implementation exists for the current operating system.</exception>
        public Player()
        {
            _internalPlayer = CheckOs();
            _internalPlayer.PlaybackFinished += OnPlaybackFinished;
        }

        /// <summary>
        ///     Occurs when audio playback has finished. Internally sets the Playing flag to <c>false</c>.
        ///     Additional handlers can be attached to handle custom post-playback logic.
        /// </summary>
        public event EventHandler PlaybackFinished;

        /// <summary>
        ///     Gets a value indicating whether the audio is currently playing.
        /// </summary>
        public bool Playing => _internalPlayer.Playing;

        /// <summary>
        ///     Gets a value indicating whether the audio playback is currently paused.
        /// </summary>
        public bool Paused => _internalPlayer.Paused;

        /// <summary>
        ///     Starts playback of the specified audio file. Stops any current playback before starting.
        ///     Sets the <see cref="Playing" /> flag to <c>true</c> and the <see cref="Paused" /> flag to <c>false</c>.
        /// </summary>
        /// <param name="fileName">The absolute or relative path to the audio file to play.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        public async Task Play(string fileName)
        {
            await _internalPlayer.Play(fileName);
        }

        /// <summary>
        ///     Starts playback of the specified audio file with optional looping.
        /// </summary>
        /// <param name="fileName">The absolute or relative path to the audio file to play.</param>
        /// <param name="loop">If <c>true</c>, the audio file loops continuously; otherwise it plays once.</param>
        /// <returns>A task that represents the asynchronous playback operation.</returns>
        public async Task PlayLoop(string fileName, bool loop)
        {
            await _internalPlayer.PlayLoop(fileName, loop);
        }

        /// <summary>
        ///     Pauses the currently playing audio. Sets the <see cref="Paused" /> flag to <c>true</c>.
        ///     Does not modify the <see cref="Playing" /> flag.
        /// </summary>
        /// <returns>A task that represents the asynchronous pause operation.</returns>
        public async Task Pause()
        {
            await _internalPlayer.Pause();
        }

        /// <summary>
        ///     Resumes playback of a previously paused audio file. Sets the <see cref="Paused" /> flag to <c>false</c>.
        ///     Does not modify the <see cref="Playing" /> flag.
        /// </summary>
        /// <returns>A task that represents the asynchronous resume operation.</returns>
        public async Task Resume()
        {
            await _internalPlayer.Resume();
        }

        /// <summary>
        ///     Stops any current playback and clears the audio buffer. Sets both <see cref="Playing" /> and <see cref="Paused" />
        ///     flags to <c>false</c>.
        /// </summary>
        /// <returns>A task that represents the asynchronous stop operation.</returns>
        public async Task Stop()
        {
            await _internalPlayer.Stop();
        }

        /// <summary>
        ///     Sets the audio playback volume as a percentage of the maximum volume.
        /// </summary>
        /// <param name="percent">The volume level from 0 (silence) to 100 (maximum).</param>
        /// <returns>A task that represents the asynchronous volume change operation.</returns>
        public async Task SetVolume(byte percent)
        {
            await _internalPlayer.SetVolume(percent);
        }

        /// <summary>
        ///     Detects the current operating system and returns the corresponding platform-specific player instance.
        /// </summary>
        /// <exception cref="Exception">Thrown when no player implementation exists for the detected operating system.</exception>
        /// <returns>An <see cref="IPlayer" /> implementation for the current platform.</returns>
        internal static IPlayer CheckOs()
        {
#if osxarm64 || osxarm || osxx64 || osx || osxarm || osxx64 || osx
            return new MacPlayer();
#elif winx64 || winx86 || winarm64 || winarm || win
            return new WindowsPlayer();
#elif linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
            return new LinuxPlayer();
#elif webassembly || browser
            return new WebPlayer();
#else
            return null;
#endif
            throw new Exception("No implementation exist for the current OS");
        }

        /// <summary>
        ///     Handles the <see cref="IPlayer.PlaybackFinished" /> event from the internal player.
        ///     Forwards the event to external subscribers.
        /// </summary>
        /// <param name="sender">The source of the event (the internal player).</param>
        /// <param name="e">An <see cref="EventArgs" /> that contains no event data.</param>
        internal void OnPlaybackFinished(object sender, EventArgs e)
        {
            PlaybackFinished?.Invoke(this, e);
        }
    }
}
