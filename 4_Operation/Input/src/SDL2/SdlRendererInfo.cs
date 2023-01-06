// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.SdlRendererInfo.cs
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
        ///     The sdl rendererinfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct SdlRendererInfo
        {
            /// <summary>
            ///     The name
            /// </summary>
            public IntPtr name; // const char*

            /// <summary>
            ///     The flags
            /// </summary>
            public uint flags;

            /// <summary>
            ///     The num texture formats
            /// </summary>
            public uint num_texture_formats;

            /// <summary>
            ///     The texture formats
            /// </summary>
            public fixed uint texture_formats[16];

            /// <summary>
            ///     The max texture width
            /// </summary>
            public int max_texture_width;

            /// <summary>
            ///     The max texture height
            /// </summary>
            public int max_texture_height;
        }
    }
