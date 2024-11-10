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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Audio.Players;

namespace Alis.Core.Audio
{
    /// <summary>
    ///     The player class
    /// </summary>
    /// <seealso cref="IPlayer" />
    public class Player : IPlayer
    {
        /// <summary>
        ///     The internal player
        /// </summary>
        private readonly IPlayer _internalPlayer;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class
        /// </summary>
        /// <exception cref="Exception">No implementation exist for the current OS</exception>
        public Player()
        {
            _internalPlayer = CheckOs();
            _internalPlayer.PlaybackFinished += OnPlaybackFinished;
        }
        
        /// <summary>
        ///     Internally, sets Playing flag to false. Additional handlers can be attached to it to handle any custom logic.
        /// </summary>
        public event EventHandler PlaybackFinished;
        
        /// <summary>
        ///     Indicates that the audio is currently playing.
        /// </summary>
        public bool Playing => _internalPlayer.Playing;
        
        /// <summary>
        ///     Indicates that the audio playback is currently paused.
        /// </summary>
        public bool Paused => _internalPlayer.Paused;
        
        /// <summary>
        ///     Will stop any current playback and will start playing the specified audio file. The fileName parameter can be an
        ///     absolute path or a path relative to the directory where the library is located. Sets Playing flag to true. Sets
        ///     Paused flag to false.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task Play(string fileName)
        {
            await _internalPlayer.Play(fileName);
        }
        
        /// <summary>
        ///     Pauses any playback. Sets Paused flag to true. Doesn't modify Playing flag.
        /// </summary>
        /// <returns></returns>
        public async Task Pause()
        {
            await _internalPlayer.Pause();
        }
        
        /// <summary>
        ///     Resumes any paused playback. Sets Paused flag to false. Doesn't modify Playing flag.
        /// </summary>
        /// <returns></returns>
        public async Task Resume()
        {
            await _internalPlayer.Resume();
        }
        
        /// <summary>
        ///     Stops any current playback and clears the buffer. Sets Playing and Paused flags to false.
        /// </summary>
        /// <returns></returns>
        public async Task Stop()
        {
            await _internalPlayer.Stop();
        }
        
        /// <summary>
        ///     Sets the playing volume as percent
        /// </summary>
        /// <returns></returns>
        public async Task SetVolume(byte percent)
        {
            await _internalPlayer.SetVolume(percent);
        }
        
        /// <summary>
        ///     Checks the os
        /// </summary>
        /// <exception>No implementation exist for the current OS</exception>
        /// <returns>The player</returns>
        internal static IPlayer CheckOs() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? new WindowsPlayer() : RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? new LinuxPlayer() : RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? new MacPlayer() : default(IPlayer);
        
        /// <summary>
        ///     Ons the playback finished using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        internal void OnPlaybackFinished(object sender, EventArgs e)
        {
            PlaybackFinished?.Invoke(this, e);
        }
    }
}