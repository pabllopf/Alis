// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseMotionEvent.cs
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

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL mouse motion event, fired when the mouse moves within a window.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MouseMotionEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.MouseMotion"/>.
        /// </summary>
        public readonly EventType type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The ID of the window that had mouse focus when the event occurred.
        /// </summary>
        public readonly uint windowID;

        /// <summary>
        ///     The mouse instance ID (SDL internal identifier for the mouse device).
        /// </summary>
        public readonly uint which;

        /// <summary>
        ///     The current button state as a bitmask of pressed buttons (e.g. SDL_BUTTON_LMASK).
        /// </summary>
        public readonly byte state;

        /// <summary>
        ///     The absolute X coordinate of the mouse cursor, relative to the window.
        /// </summary>
        public readonly int x;

        /// <summary>
        ///     The absolute Y coordinate of the mouse cursor, relative to the window.
        /// </summary>
        public readonly int y;

        /// <summary>
        ///     The relative motion in the X direction since the last event.
        /// </summary>
        public readonly int xRel;

        /// <summary>
        ///     The relative motion in the Y direction since the last event.
        /// </summary>
        public readonly int yRel;
    }
}