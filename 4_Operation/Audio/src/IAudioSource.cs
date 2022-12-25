// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAudioSource.cs
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

namespace Alis.Core.Audio
{
    /// <summary>
    ///     The audio source interface
    /// </summary>
    public interface IAudioSource<T> 
    {
        /// <summary>
        ///     Gets or sets the value of the audio clip base
        /// </summary>
        public T AudioClip { get; set; }

        /// <summary>
        ///     Gets the value of the is playing
        /// </summary>
        public bool IsPlaying { get; }

        /// <summary>
        ///     Gets or sets the value of the play on awake
        /// </summary>
        public bool PlayOnAwake { get; set; }

        /// <summary>
        ///     Gets or sets the value of the mute
        /// </summary>
        public bool Mute { get; set; }

        /// <summary>
        ///     Gets or sets the value of the loop
        /// </summary>
        public bool Loop { get; set; }

        /// <summary>
        ///     Gets or sets the value of the volume
        /// </summary>
        public float Volume { get; set; }

        /// <summary>
        ///     Plays this instance
        /// </summary>
        public void Play();

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public void Stop();

        /// <summary>
        ///     Resumes this instance
        /// </summary>
        public void Resume();
    }
}