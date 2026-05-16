// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowPos.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The window pos enum
    /// </summary>
    [Flags]
    public enum WindowPos
    {
    /// <summary>
    ///     Bitmask value indicating the window position is undefined (let system decide)
    /// </summary>
    WindowPosUndefinedMask = 0x1FFF0000,

    /// <summary>
    ///     Bitmask value indicating the window should be centered on screen
    /// </summary>
    WindowPosCenteredMask = 0x2FFF0000,

    /// <summary>
    ///     Special value indicating an undefined window position (system chooses)
    /// </summary>
    WindowPosUndefined = 0x1FFF0000,

    /// <summary>
    ///     Special value indicating the window should be centered on its display
    /// </summary>
    WindowPosCentered = 0x2FFF0000
    }
}