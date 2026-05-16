// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameControllerAxis.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl game controller axis enum
    /// </summary>
    public enum GameControllerAxis
    {
    /// <summary>
    ///     Invalid or uninitialized axis identifier
    /// </summary>
    SdlControllerAxisInvalid = -1,

    /// <summary>
    ///     Left analog stick horizontal axis
    /// </summary>
    SdlControllerAxisLeftX,

    /// <summary>
    ///     Left analog stick vertical axis
    /// </summary>
    SdlControllerAxisLeftY,

    /// <summary>
    ///     Right analog stick horizontal axis
    /// </summary>
    SdlControllerAxisRightX,

    /// <summary>
    ///     Right analog stick vertical axis
    /// </summary>
    SdlControllerAxisRightY,

    /// <summary>
    ///     Left analog trigger axis
    /// </summary>
    SdlControllerAxisTriggerLeft,

    /// <summary>
    ///     Right analog trigger axis
    /// </summary>
    SdlControllerAxisTriggerRight,

    /// <summary>
    ///     Total number of axis entries (sentinel value)
    /// </summary>
    SdlControllerAxisMax
    }
}