// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: AudioSourceBuilder.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Component.Audio;

namespace Alis.Builder.Core.Ecs.Component.Audio
{
    /// <summary>
    ///     The audio source builder class
    /// </summary>
    /// <seealso cref="IBuild{AudioSource}" />
    public class AudioSourceBuilder :
        IBuild<AudioSource>,
        IIsActive<AudioSourceBuilder, bool>,
        ISetAudioClip<AudioSourceBuilder, Func<AudioClipBuilder, AudioClip>>,
        IPlayOnAwake<AudioSourceBuilder, bool>
    {
        /// <summary>
        ///     Gets or sets the value of the audio source
        /// </summary>
        private readonly AudioSource audioSource = new AudioSource();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio source</returns>
        public AudioSource Build() => audioSource;

        /// <summary>
        ///     Ises the active using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio source builder</returns>
        public AudioSourceBuilder IsActive(bool value)
        {
            audioSource.IsEnable = value;
            return this;
        }

        /// <summary>
        ///     Plays the on awake using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio source builder</returns>
        public AudioSourceBuilder PlayOnAwake(bool value)
        {
            audioSource.PlayOnAwake = value;
            return this;
        }

        /// <summary>
        ///     Sets the audio clip using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio source builder</returns>
        public AudioSourceBuilder SetAudioClip(Func<AudioClipBuilder, AudioClip> value)
        {
            audioSource.AudioClip = value.Invoke(new AudioClipBuilder());
            return this;
        }
    }
}