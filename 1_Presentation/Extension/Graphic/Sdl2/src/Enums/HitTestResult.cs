// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HitTestResult.cs
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
    ///     The sdl hit test result enum
    /// </summary>
    public enum HitTestResult
    {
    /// <summary>
    ///     Normal window area, no special handling
    /// </summary>
    SdlHitTestNormal,

    /// <summary>
    ///     Title bar area, allows dragging the window
    /// </summary>
    SdlHitTestDraggable,

    /// <summary>
    ///     Top-left resize corner area
    /// </summary>
    SdlHitTestResizeTopLeft,

    /// <summary>
    ///     Top edge resize area
    /// </summary>
    SdlHitTestResizeTop,

    /// <summary>
    ///     Top-right resize corner area
    /// </summary>
    SdlHitTestResizeTopRight,

    /// <summary>
    ///     Right edge resize area
    /// </summary>
    SdlHitTestResizeRight,

    /// <summary>
    ///     Bottom-right resize corner area
    /// </summary>
    SdlHitTestResizeBottomRight,

    /// <summary>
    ///     Bottom edge resize area
    /// </summary>
    SdlHitTestResizeBottom,

    /// <summary>
    ///     Bottom-left resize corner area
    /// </summary>
    SdlHitTestResizeBottomLeft,

    /// <summary>
    ///     Left edge resize area
    /// </summary>
    SdlHitTestResizeLeft
    }
}