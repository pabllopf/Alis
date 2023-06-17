// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlMessageBoxData.cs
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

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl messageboxdata
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlMessageBoxData
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public readonly SdlMessageBoxFlags flags;

        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr window; /* Parent window, can be NULL */

        /// <summary>
        ///     The title
        /// </summary>
        public readonly string title; /* UTF-8 title */

        /// <summary>
        ///     The message
        /// </summary>
        public readonly string message; /* UTF-8 message text */

        /// <summary>
        ///     The numbuttons
        /// </summary>
        public readonly int numbuttons;

        /// <summary>
        ///     The buttons
        /// </summary>
        public readonly SdlMessageBoxButtonData[] buttons;

        /// <summary>
        ///     The color scheme
        /// </summary>
        public SdlMessageBoxColorScheme? colorScheme; /* Can be NULL to use system settings */
    }
}