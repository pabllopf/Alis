// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSource.cs
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

namespace Alis.Core.Audio.Sample
{
    /// <summary>
    ///     The audio source class
    /// </summary>
    public class AudioSource
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioSource" /> class
        /// </summary>
        /// <param name="audioClip">The audio clip</param>
        public AudioSource(AudioClip audioClip) => AudioClip = audioClip;

        /// <summary>
        ///     Gets or sets the value of the audio clip
        /// </summary>
        public AudioClip AudioClip { get; }

        /// <summary>
        ///     Gets the value of the is playing
        /// </summary>
        public bool IsPlaying => AudioClip.IsPlaying;

        /// <summary>
        ///     Gets or sets the value of the mute
        /// </summary>
        public bool Mute
        {
            get => AudioClip.IsMute;
            set => AudioClip.IsMute = value;
        }

        /// <summary>
        ///     Gets or sets the value of the loop
        /// </summary>
        public bool Loop
        {
            get => AudioClip.IsLooping;
            set => AudioClip.IsLooping = value;
        }

        /// <summary>
        ///     Gets or sets the value of the volume
        /// </summary>
        public float Volume
        {
            get => AudioClip.Volume;
            set => AudioClip.Volume = value;
        }

        /// <summary>
        ///     Plays this instance
        /// </summary>
        public void Play() => AudioClip.Play();

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public void Stop() => AudioClip.Stop();

        /// <summary>
        ///     Resumes this instance
        /// </summary>
        public void Resume() => AudioClip.Resume();
    }
}