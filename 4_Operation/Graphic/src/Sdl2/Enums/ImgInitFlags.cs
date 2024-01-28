// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImgInitFlags.cs
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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The img init flags enum
    /// </summary>
    [Flags]
    public enum ImgInitFlags
    {
        /// <summary>
        ///     The img init jpg img init flags
        /// </summary>
        ImgInitJpg = 0x00000001,

        /// <summary>
        ///     The img init png img init flags
        /// </summary>
        ImgInitPng = 0x00000002,

        /// <summary>
        ///     The img init tif img init flags
        /// </summary>
        ImgInitTif = 0x00000004,

        /// <summary>
        ///     The img init webp img init flags
        /// </summary>
        ImgInitWebp = 0x00000008
    }
}