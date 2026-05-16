// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowEventId.cs
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
    ///     The sdl window event id enum
    /// </summary>
    public enum WindowEventId : byte
    {
    /// <summary>
    ///     No window event occurred
    /// </summary>
    SdlWindowEventNone,

    /// <summary>
    ///     Window has been shown and is now visible
    /// </summary>
    SdlWindowEventShown,

    /// <summary>
    ///     Window has been hidden and is now invisible
    /// </summary>
    SdlWindowEventHidden,

    /// <summary>
    ///     Window has been exposed and needs repainting
    /// </summary>
    SdlWindowEventExposed,

    /// <summary>
    ///     Window has been moved to a new position
    /// </summary>
    SdlWindowEventMoved,

    /// <summary>
    ///     Window has been resized to new dimensions
    /// </summary>
    SdlWindowEventResized,

    /// <summary>
    ///     Window size has changed between minimized and restored state
    /// </summary>
    SdlWindowEventSizeChanged,

    /// <summary>
    ///     Window has been minimized (iconified)
    /// </summary>
    SdlWindowEventMinimized,

    /// <summary>
    ///     Window has been maximized
    /// </summary>
    SdlWindowEventMaximized,

    /// <summary>
    ///     Window has been restored to its previous size
    /// </summary>
    SdlWindowEventRestored,

    /// <summary>
    ///     Mouse has entered the window area
    /// </summary>
    SdlWindowEventEnter,

    /// <summary>
    ///     Mouse has left the window area
    /// </summary>
    SdlWindowEventLeave,

    /// <summary>
    ///     Window has gained keyboard focus
    /// </summary>
    SdlWindowEventFocusGained,

    /// <summary>
    ///     Window has lost keyboard focus
    /// </summary>
    SdlWindowEventFocusLost,

    /// <summary>
    ///     Window close button was pressed or close requested
    /// </summary>
    SdlWindowEventClose,

    /// <summary>
    ///     Window has been offered focus (may take or ignore)
    /// </summary>
    SdlWindowEventTakeFocus,

    /// <summary>
    ///     Window hit test has been performed
    /// </summary>
    SdlWindowEventHitTest,

    /// <summary>
    ///     Window ICC profile has changed
    /// </summary>
    SdlWindowEventIccProfChanged,

    /// <summary>
    ///     Window has been moved to a different display
    /// </summary>
    SdlWindowEventDisplayChanged
    }
}