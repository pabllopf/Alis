// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSourceBuilder.cs
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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Components.Audio;

namespace Alis.Builder.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     The audio source builder class
    /// </summary>
    /// <seealso cref="IBuild{AudioSource}" />
    public class AudioSourceBuilder :
        IBuild<AudioSource>,
        ISetAudioClip<AudioSourceBuilder, Action<AudioClipBuilder>>
    {
        private AudioClip audioClip = new AudioClip();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio source</returns>
        public AudioSource Build() => new AudioSource(audioClip);
        
        public AudioSourceBuilder SetAudioClip(Action<AudioClipBuilder> config)
        {
            AudioClipBuilder audioClipBuilder = new AudioClipBuilder();
            config(audioClipBuilder);
            AudioClip build = audioClipBuilder.Build();
            this.audioClip = build;
            return this;
        }
    }
}