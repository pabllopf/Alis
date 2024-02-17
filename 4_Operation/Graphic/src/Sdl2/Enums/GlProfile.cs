// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlProfile.cs
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
    ///     The sdl gl profile enum
    /// </summary>
    [Flags]
    public enum GlProfile
    {
        /// <summary>
        ///     The sdl gl context profile core sdl gl profile
        /// </summary>
        SdlGlContextProfileCore = 0x0001,

        /// <summary>
        ///     The sdl gl context profile compatibility sdl gl profile
        /// </summary>
        SdlGlContextProfileCompatibility = 0x0002,

        /// <summary>
        ///     The sdl gl context profile es sdl gl profile
        /// </summary>
        SdlGlContextProfileEs = 0x0004
    }
}