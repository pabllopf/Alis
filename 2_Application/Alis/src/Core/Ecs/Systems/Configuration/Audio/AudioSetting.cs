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

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Systems.Configuration.Audio
{
    /// <summary>
    ///     The audio setting
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AudioSetting(int volume = 100, bool mute = false) : IAudioSetting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioSetting"/> class
        /// </summary>
        public AudioSetting() : this(volume: 100, mute: false)
        {
        }
        
        /// <summary>
        /// Gets or sets the value of the volume
        /// </summary>
        public int Volume { get; set; } = volume;
        
        /// <summary>
        /// Gets or sets the value of the mute
        /// </summary>
        public bool Mute { get; set; } = mute;
    }
}