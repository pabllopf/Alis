// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlDisplayOrientation.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl display orientation enum
    /// </summary>
    public enum SdlDisplayOrientation
    {
        /// <summary>
        ///     The sdl orientation unknown sdl display orientation
        /// </summary>
        SdlOrientationUnknown,

        /// <summary>
        ///     The sdl orientation landscape sdl display orientation
        /// </summary>
        SdlOrientationLandscape,

        /// <summary>
        ///     The sdl orientation landscape flipped sdl display orientation
        /// </summary>
        SdlOrientationLandscapeFlipped,

        /// <summary>
        ///     The sdl orientation portrait sdl display orientation
        /// </summary>
        SdlOrientationPortrait,

        /// <summary>
        ///     The sdl orientation portrait flipped sdl display orientation
        /// </summary>
        SdlOrientationPortraitFlipped
    }
}