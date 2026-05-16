// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseWheelEvent.cs
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
    ///     Represents an SDL mouse wheel event, fired when the mouse wheel is scrolled.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MouseWheelEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.MouseWheel"/>.
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
        ///     The horizontal scroll amount (positive for right, negative for left).
        /// </summary>
        public readonly int x;

        /// <summary>
        ///     The vertical scroll amount (positive for up/away from user, negative for down/toward user).
        /// </summary>
        public readonly int y;

        /// <summary>
        ///     The scroll direction, indicating the coordinate system (e.g. SDL_MOUSEWHEEL_NORMAL, SDL_MOUSEWHEEL_FLIPPED).
        /// </summary>
        public readonly uint direction;

        /// <summary>
        ///     The precise horizontal scroll amount with sub-pixel precision (for high-resolution scroll wheels).
        /// </summary>
        public readonly float preciseX;

        /// <summary>
        ///     The precise vertical scroll amount with sub-pixel precision (for high-resolution scroll wheels).
        /// </summary>
        public readonly float preciseY;
    }
}