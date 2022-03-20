// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MaxAuxiliarySends.cs
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

namespace Alis.Core.Audio2D.Extensions.Creative.EFX.Enums
{
    /// <summary>
    ///     May be passed at context construction time to indicate the number of desired auxiliary effect slot sends per
    ///     source.
    /// </summary>
    public enum MaxAuxiliarySends
    {
        /// <summary>
        ///     Will chose a reliably working parameter.
        /// </summary>
        UseDriverDefault = 0,

        /// <summary>
        ///     One send per source.
        /// </summary>
        One = 1,

        /// <summary>
        ///     Two sends per source.
        /// </summary>
        Two = 2,

        /// <summary>
        ///     Three sends per source.
        /// </summary>
        Three = 3,

        /// <summary>
        ///     Four sends per source.
        /// </summary>
        Four = 4
    }
}