// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSettingBuilder.cs
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
using Alis.Core.Ecs.Systems.Configuration.Audio;

namespace Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Audio
{
    /// <summary>
    ///     The audio setting builder class
    /// </summary>
    public class AudioSettingBuilder :
        IBuild<AudioSetting>
    {
        /// <summary>
        ///     The is mute
        /// </summary>
        private bool isMute;

        /// <summary>
        ///     The volume
        /// </summary>
        private int volume;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio setting</returns>
        public AudioSetting Build() => new AudioSetting(volume, isMute);

        /// <summary>
        ///     Volumes the volume
        /// </summary>
        /// <param name="volume">The volume</param>
        /// <returns>The audio setting builder</returns>
        public AudioSettingBuilder Volume(int volume)
        {
            this.volume = volume;
            return this;
        }

        /// <summary>
        ///     Ises the mute using the specified mute
        /// </summary>
        /// <param name="mute">The mute</param>
        /// <returns>The audio setting builder</returns>
        public AudioSettingBuilder IsMute(bool mute)
        {
            isMute = mute;
            return this;
        }
    }
}