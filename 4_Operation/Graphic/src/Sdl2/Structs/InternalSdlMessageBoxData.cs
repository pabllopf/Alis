// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalSdlMessageBoxData.cs
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
using Alis.Core.Graphic.Sdl2.Enums;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal sdl message box data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct InternalSdlMessageBoxData
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public MessageBoxFlags flags;

        /// <summary>
        ///     The window, Parent window, can be NULL
        /// </summary>
        public IntPtr window;

        /// <summary>
        ///     The title, UTF-8 title
        /// </summary>
        public IntPtr title;

        /// <summary>
        ///     The message
        /// </summary>
        public IntPtr message;

        /// <summary>
        ///     The num buttons
        /// </summary>
        public int numButtons;

        /// <summary>
        ///     The buttons
        /// </summary>
        public IntPtr buttons;

        /// <summary>
        ///     The color scheme
        /// </summary>
        public IntPtr colorScheme;
    }
}