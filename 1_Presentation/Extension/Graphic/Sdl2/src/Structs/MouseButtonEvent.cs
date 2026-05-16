// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseButtonEvent.cs
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
    ///     Represents an SDL mouse button event, fired when a mouse button is pressed or released.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MouseButtonEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.MouseButtonDown"/> or <see cref="EventType.MouseButtonUp"/>.
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
        ///     The mouse button index (e.g. SDL_BUTTON_LEFT, SDL_BUTTON_RIGHT, SDL_BUTTON_MIDDLE).
        /// </summary>
        public readonly byte button;

        /// <summary>
        ///     The button state: SDL_PRESSED (1) or SDL_RELEASED (0).
        /// </summary>
        public readonly byte state;

        /// <summary>
        ///     The number of clicks in a sequence (1 for single-click, 2 for double-click, etc.).
        /// </summary>
        public readonly byte clicks;

        /// <summary>
        ///     The X coordinate of the mouse cursor at the time of the event, relative to the window.
        /// </summary>
        public readonly int x;

        /// <summary>
        ///     The Y coordinate of the mouse cursor at the time of the event, relative to the window.
        /// </summary>
        public readonly int y;
    }
}