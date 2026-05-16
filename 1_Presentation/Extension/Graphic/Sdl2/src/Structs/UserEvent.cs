// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UserEvent.cs
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
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL user event, a custom event type defined by the application with user-specified data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UserEvent
    {
        /// <summary>
        ///     The event type identifier, in the range SDL_USEREVENT through SDL_LASTEVENT.
        /// </summary>
        public uint type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The ID of the target window, or 0 if not associated with a window.
        /// </summary>
        public uint windowID;

        /// <summary>
        ///     A user-defined integer code for the event type.
        /// </summary>
        public int code;

        /// <summary>
        ///     A user-defined data pointer (first user data field).
        /// </summary>
        public IntPtr Data1 { get; set; }

        /// <summary>
        ///     A user-defined data pointer (second user data field).
        /// </summary>
        public IntPtr Data2 { get; set; }
    }
}