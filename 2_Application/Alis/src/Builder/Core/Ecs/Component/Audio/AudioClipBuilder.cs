// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioClipBuilder.cs
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
using Alis.Core.Ecs.Component.Audio;

namespace Alis.Builder.Core.Ecs.Component.Audio
{
    /// <summary>
    ///     The audio clip builder class
    /// </summary>
    /// <seealso cref="IBuild{AudioClip}" />
    public class AudioClipBuilder :
        IBuild<AudioClip>,
        IFilePath<AudioClipBuilder, string>,
        IVolume<AudioClipBuilder, float>,
        IMute<AudioClipBuilder, bool>
    {
        /// <summary>
        ///     The audio clip
        /// </summary>
        private readonly AudioClip audioClip = new AudioClip();
        
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio clip</returns>
        public AudioClip Build() => audioClip;
        
        /// <summary>
        ///     Files the path using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio clip builder</returns>
        public AudioClipBuilder FilePath(string value)
        {
            audioClip.NameFile = value;
            return this;
        }
        
        /// <summary>
        ///     Mutes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio clip builder</returns>
        public AudioClipBuilder Mute(bool value)
        {
            audioClip.IsMute = value;
            return this;
        }
        
        /// <summary>
        ///     Volumes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio clip builder</returns>
        public AudioClipBuilder Volume(float value)
        {
            audioClip.Volume = value;
            return this;
        }
    }
}