// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextEditingEvent.cs
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
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL text editing event, fired during IME text composition when the composition string changes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct TextEditingEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.TextEditing"/>.
        /// </summary>
        public readonly EventType type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The ID of the window that received the text editing event.
        /// </summary>
        public readonly uint windowID;

        /// <summary>
        ///     The native pointer to the null-terminated UTF-8 composition string.
        /// </summary>
        private readonly IntPtr textPtr;

        /// <summary>
        ///     The start position of the selection within the composition string.
        /// </summary>
        public readonly int start;

        /// <summary>
        ///     The length of the selection within the composition string.
        /// </summary>
        public readonly int length;

        /// <summary>
        ///     Gets the IME composition string as a managed string.
        /// </summary>
        public string Text => Marshal.PtrToStringAnsi(textPtr);
    }
}