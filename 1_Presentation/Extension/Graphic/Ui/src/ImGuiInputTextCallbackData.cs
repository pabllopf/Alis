// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiInputTextCallbackData.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui input text callback data
    /// </summary>
    public struct ImGuiInputTextCallbackData
    {
        /// <summary>
        ///     The event flag
        /// </summary>
        public ImGuiInputTextFlags EventFlag { get; set; }

        /// <summary>
        ///     The flags
        /// </summary>
        public ImGuiInputTextFlags Flags { get; set; }

        /// <summary>
        ///     The user data
        /// </summary>
        public IntPtr UserData { get; set; }

        /// <summary>
        ///     The event char
        /// </summary>
        public ushort EventChar { get; set; }

        /// <summary>
        ///     The event key
        /// </summary>
        public ImGuiKey EventKey { get; set; }

        /// <summary>
        ///     The buf
        /// </summary>
        public IntPtr Buf { get; set; }

        /// <summary>
        ///     The buf text len
        /// </summary>
        public int BufTextLen { get; set; }

        /// <summary>
        ///     The buf size
        /// </summary>
        public int BufSize { get; set; }

        /// <summary>
        ///     The buf dirty
        /// </summary>
        public byte BufDirty { get; set; }

        /// <summary>
        ///     The cursor pos
        /// </summary>
        public int CursorPos { get; set; }

        /// <summary>
        ///     The selection start
        /// </summary>
        public int SelectionStart { get; set; }

        /// <summary>
        ///     The selection end
        /// </summary>
        public int SelectionEnd { get; set; }
    }
}