// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Surface.cs
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
using Alis.Core.Aspect.Math.Shape.Rectangle;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl surface
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Surface
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public readonly uint flags;
        
        /// <summary>
        ///     The format
        /// </summary>
        public IntPtr format;
        
        /// <summary>
        ///     The
        /// </summary>
        public readonly int w;
        
        /// <summary>
        ///     The
        /// </summary>
        public readonly int h;
        
        /// <summary>
        ///     The pitch
        /// </summary>
        public readonly int pitch;
        
        /// <summary>
        ///     The pixels
        /// </summary>
        public IntPtr pixels;
        
        /// <summary>
        ///     The userdata
        /// </summary>
        public IntPtr userdata;
        
        /// <summary>
        ///     The locked
        /// </summary>
        public readonly int locked;
        
        /// <summary>
        ///     The list blit map
        /// </summary>
        public IntPtr listBlitMap;
        
        /// <summary>
        ///     The clip rect
        /// </summary>
        public RectangleI clipRect;
        
        /// <summary>
        ///     The map
        /// </summary>
        public IntPtr map;
        
        /// <summary>
        ///     The ref count
        /// </summary>
        public readonly int refCount;
    }
}