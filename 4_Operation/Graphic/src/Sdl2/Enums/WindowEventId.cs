// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlWindowEventId.cs
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
    ///     The sdl window event id enum
    /// </summary>
    public enum WindowEventId : byte
    {
        /// <summary>
        ///     The sdl window event none sdl window event id
        /// </summary>
        SdlWindowEventNone,

        /// <summary>
        ///     The sdl window event shown sdl window event id
        /// </summary>
        SdlWindowEventShown,

        /// <summary>
        ///     The sdl window event hidden sdl window event id
        /// </summary>
        SdlWindowEventHidden,

        /// <summary>
        ///     The sdl window event exposed sdl window event id
        /// </summary>
        SdlWindowEventExposed,

        /// <summary>
        ///     The sdl window event moved sdl window event id
        /// </summary>
        SdlWindowEventMoved,

        /// <summary>
        ///     The sdl window event resized sdl window event id
        /// </summary>
        SdlWindowEventResized,

        /// <summary>
        ///     The sdl window event size changed sdl window event id
        /// </summary>
        SdlWindowEventSizeChanged,

        /// <summary>
        ///     The sdl window event minimized sdl window event id
        /// </summary>
        SdlWindowEventMinimized,

        /// <summary>
        ///     The sdl window event maximized sdl window event id
        /// </summary>
        SdlWindowEventMaximized,

        /// <summary>
        ///     The sdl window event restored sdl window event id
        /// </summary>
        SdlWindowEventRestored,

        /// <summary>
        ///     The sdl window event enter sdl window event id
        /// </summary>
        SdlWindowEventEnter,

        /// <summary>
        ///     The sdl window event leave sdl window event id
        /// </summary>
        SdlWindowEventLeave,

        /// <summary>
        ///     The sdl window event focus gained sdl window event id
        /// </summary>
        SdlWindowEventFocusGained,

        /// <summary>
        ///     The sdl window event focus lost sdl window event id
        /// </summary>
        SdlWindowEventFocusLost,

        /// <summary>
        ///     The sdl window event close sdl window event id
        /// </summary>
        SdlWindowEventClose,

        /// <summary>
        ///     The sdl window event take focus sdl window event id
        /// </summary>
        SdlWindowEventTakeFocus,

        /// <summary>
        ///     The sdl window event hit test sdl window event id
        /// </summary>
        SdlWindowEventHitTest,

        /// <summary>
        ///     The sdl window event icc prof changed sdl window event id
        /// </summary>
        SdlWindowEventIccProfChanged,

        /// <summary>
        ///     The sdl window event display changed sdl window event id
        /// </summary>
        SdlWindowEventDisplayChanged
    }
}