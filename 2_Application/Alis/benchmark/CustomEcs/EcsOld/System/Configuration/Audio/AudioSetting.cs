// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSetting.cs
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

using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;

namespace Alis.Benchmark.CustomEcs.EcsOld.System.Configuration.Audio
{
    /// <summary>
    ///     The audio setting class
    /// </summary>
    /// <seealso cref="IAudioSetting" />
    /// <seealso cref="IHasBuilder{TOut}" />
    public class AudioSetting :
        IAudioSetting,
        IHasBuilder<AudioSettingBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioSetting" /> class
        /// </summary>
        public AudioSetting()
        {
            Volume = 100;
            Mute = false;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioSetting" /> class
        /// </summary>
        /// <param name="volume">The volume</param>
        /// <param name="mute">The mute</param>
        [JsonConstructor]
        public AudioSetting(int volume, bool mute)
        {
            Volume = volume;
            Mute = mute;
        }

        /// <summary>
        ///     Gets or sets the value of the volume
        /// </summary>
        [JsonPropertyName("_Volume_")]
        public int Volume { get; set; }

        /// <summary>
        ///     Gets or sets the value of the mute
        /// </summary>
        [JsonPropertyName("_Mute_")]
        public bool Mute { get; set; }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The audio setting builder</returns>
        public AudioSettingBuilder Builder() => new AudioSettingBuilder();
    }
}