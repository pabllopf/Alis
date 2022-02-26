// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FilterFloat.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Audio.Extensions.Creative.EFX.Enums
{
    /// <summary>
    ///     A list of valid <see cref="float" /> Filter/GetFilter parameters.
    /// </summary>
    public enum FilterFloat
    {
        /// <summary>
        ///     Range [0.0f .. 1.0f] Default: 1.0f
        /// </summary>
        LowpassGain = 0x0001,

        /// <summary>
        ///     Range [0.0f .. 1.0f] Default: 1.0f
        /// </summary>
        LowpassGainHF = 0x0002,

        /// <summary>
        ///     Range [0.0f .. 1.0f] Default: 1.0f
        /// </summary>
        HighpassGain = 0x0001,

        /// <summary>
        ///     Range [0.0f .. 1.0f] Default: 1.0f
        /// </summary>
        HighpassGainLF = 0x0002,

        /// <summary>
        ///     Range [0.0f .. 1.0f] Default: 1.0f
        /// </summary>
        BandpassGain = 0x0001,

        /// <summary>
        ///     Range [0.0f .. 1.0f] Default: 1.0f
        /// </summary>
        BandpassGainLF = 0x0002,

        /// <summary>
        ///     Range [0.0f .. 1.0f] Default: 1.0f
        /// </summary>
        BandpassGainHF = 0x0003
    }
}