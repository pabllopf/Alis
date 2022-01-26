// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FilterType.cs
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
    ///     Filter type definitions to be used with EfxFilteri.FilterType.
    /// </summary>
    public enum FilterType
    {
        /// <summary>
        ///     No Filter, disable. This Filter type is used when a Filter object is initially created.
        /// </summary>
        Null = 0x0000,

        /// <summary>
        ///     A low-pass filter is used to remove high frequency content from a signal.
        /// </summary>
        Lowpass = 0x0001,

        /// <summary>
        ///     Currently not implemented. A high-pass filter is used to remove low frequency content from a signal.
        /// </summary>
        Highpass = 0x0002,

        /// <summary>
        ///     Currently not implemented. A band-pass filter is used to remove high and low frequency content from a signal.
        /// </summary>
        Bandpass = 0x0003
    }
}