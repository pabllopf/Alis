// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.InternalSdlMessageBoxData.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
        ///     The internal sdl messageboxdata
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct InternalSdlMessageBoxData
        {
            /// <summary>
            ///     The flags
            /// </summary>
            public SdlMessageBoxFlags flags;

            /// <summary>
            ///     The window
            /// </summary>
            public IntPtr window; /* Parent window, can be NULL */

            /// <summary>
            ///     The title
            /// </summary>
            public IntPtr title; /* UTF-8 title */

            /// <summary>
            ///     The message
            /// </summary>
            public IntPtr message; /* UTF-8 message text */

            /// <summary>
            ///     The numbuttons
            /// </summary>
            public int numbuttons;

            /// <summary>
            ///     The buttons
            /// </summary>
            public IntPtr buttons;

            /// <summary>
            ///     The color scheme
            /// </summary>
            public IntPtr colorScheme; /* Can be NULL to use system settings */
        }
}