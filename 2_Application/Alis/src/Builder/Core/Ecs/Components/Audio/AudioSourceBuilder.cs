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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Builder.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     The audio clip builder class
    /// </summary>
    /// <seealso cref="IBuild{AudioClip}" />
    public class AudioSourceBuilder :
        IBuild<AudioSource>,
        IFilePath<AudioSourceBuilder, string>,
        IVolume<AudioSourceBuilder, float>,
        IMute<AudioSourceBuilder, bool>
    {
        /// <summary>
        /// The context
        /// </summary>
        private Context context;
        
        /// <summary>
        ///     The is mute
        /// </summary>
        private bool isMute;

        /// <summary>
        ///     The loop
        /// </summary>
        private bool loop;

        /// <summary>
        ///     The empty
        /// </summary>
        private string nameFile = string.Empty;

        /// <summary>
        ///     The play on awake
        /// </summary>
        private bool playOnAwake;

        /// <summary>
        ///     The volume
        /// </summary>
        private float volume = 100;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio clip</returns>
        public AudioSource Build() => new AudioSource(context, nameFile, volume, isMute, playOnAwake, loop);

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioSourceBuilder"/> class
        /// </summary>
        /// <param name="context">The context</param>
        public AudioSourceBuilder(Context context)
        {
            this.context = context;
        }
        
        /// <summary>
        ///     Files the path using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio clip builder</returns>
        public AudioSourceBuilder File(string value)
        {
            nameFile = value;
            return this;
        }

        /// <summary>
        ///     Mutes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio clip builder</returns>
        public AudioSourceBuilder Mute(bool value)
        {
            isMute = value;
            return this;
        }

        /// <summary>
        ///     Volumes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio clip builder</returns>
        public AudioSourceBuilder Volume(float value)
        {
            volume = value;
            return this;
        }

        /// <summary>
        ///     Plays the on awake using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio source builder</returns>
        public AudioSourceBuilder PlayOnAwake(bool value)
        {
            playOnAwake = value;
            return this;
        }

        /// <summary>
        ///     Loops the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio source builder</returns>
        public AudioSourceBuilder Loop(bool value)
        {
            loop = value;
            return this;
        }
    }
}