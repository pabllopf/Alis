// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SystemCursor.cs
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
    ///     The sdl system cursor enum
    /// </summary>
    public enum SystemCursor
    {
    /// <summary>
    ///     Standard arrow pointer cursor (default)
    /// </summary>
    SdlSystemCursorArrow,

    /// <summary>
    ///     I-beam text selection cursor
    /// </summary>
    SdlSystemCursorIbeAm,

    /// <summary>
    ///     Wait/hourglass cursor indicating busy state
    /// </summary>
    SdlSystemCursorWait,

    /// <summary>
    ///     Crosshair precision selection cursor
    /// </summary>
    SdlSystemCursorCrosshair,

    /// <summary>
    ///     Wait cursor with an arrow (background busy)
    /// </summary>
    SdlSystemCursorWaitArrow,

    /// <summary>
    ///     Size-resize cursor pointing northwest-southeast
    /// </summary>
    SdlSystemCursorSizeNwSe,

    /// <summary>
    ///     Size-resize cursor pointing northeast-southwest
    /// </summary>
    SdlSystemCursorSizeNesW,

    /// <summary>
    ///     Horizontal resize cursor (west-east arrows)
    /// </summary>
    SdlSystemCursorSizeWe,

    /// <summary>
    ///     Vertical resize cursor (north-south arrows)
    /// </summary>
    SdlSystemCursorSizeNs,

    /// <summary>
    ///     Move/resize all directions cursor (four arrows)
    /// </summary>
    SdlSystemCursorSizeAll,

    /// <summary>
    ///     Not-allowed cursor indicating an invalid operation
    /// </summary>
    SdlSystemCursorNo,

    /// <summary>
    ///     Hand pointer cursor (clickable links)
    /// </summary>
    SdlSystemCursorHand,

    /// <summary>
    ///     Total number of system cursor types (sentinel)
    /// </summary>
    SdlNumSystemCursors
    }
}