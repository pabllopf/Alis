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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl hit test result enum
    /// </summary>
    public enum HitTestResult
    {
        /// <summary>
        ///     The sdl hit test normal sdl hit test result
        /// </summary>
        SdlHitTestNormal,

        /// <summary>
        ///     The sdl hit test draggable sdl hit test result
        /// </summary>
        SdlHitTestDraggable,

        /// <summary>
        ///     The sdl hit test resize top left sdl hit test result
        /// </summary>
        SdlHitTestResizeTopLeft,

        /// <summary>
        ///     The sdl hit test resize top sdl hit test result
        /// </summary>
        SdlHitTestResizeTop,

        /// <summary>
        ///     The sdl hit test resize top right sdl hit test result
        /// </summary>
        SdlHitTestResizeTopRight,

        /// <summary>
        ///     The sdl hit test resize right sdl hit test result
        /// </summary>
        SdlHitTestResizeRight,

        /// <summary>
        ///     The sdl hit test resize bottom right sdl hit test result
        /// </summary>
        SdlHitTestResizeBottomRight,

        /// <summary>
        ///     The sdl hit test resize bottom sdl hit test result
        /// </summary>
        SdlHitTestResizeBottom,

        /// <summary>
        ///     The sdl hit test resize bottom left sdl hit test result
        /// </summary>
        SdlHitTestResizeBottomLeft,

        /// <summary>
        ///     The sdl hit test resize left sdl hit test result
        /// </summary>
        SdlHitTestResizeLeft
    }
}