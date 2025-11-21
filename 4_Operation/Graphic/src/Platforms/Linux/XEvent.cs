// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:XEvent.cs
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

#if linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;


namespace Alis.Core.Graphic.Platforms.Linux
{
    /// <summary>
    /// The event
    /// </summary>
    internal struct XEvent
    {
        /// <summary>
        /// The type
        /// </summary>
        public int type;

        /// <summary>
        /// The pad
        /// </summary>
        public IntPtr pad1;

        /// <summary>
        /// The pad
        /// </summary>
        public IntPtr pad2;

        /// <summary>
        /// The pad
        /// </summary>
        public IntPtr pad3;

        /// <summary>
        /// The pad
        /// </summary>
        public IntPtr pad4;

        /// <summary>
        /// The pad
        /// </summary>
        public IntPtr pad5;

        /// <summary>
        /// The pad
        /// </summary>
        public IntPtr pad6;

        /// <summary>
        /// The pad
        /// </summary>
        public IntPtr pad7;

        /// <summary>
        /// The pad
        /// </summary>
        public IntPtr pad8;

        /// <summary>
        /// The pad
        /// </summary>
        public IntPtr pad9;

        /// <summary>
        /// The pad 10
        /// </summary>
        public IntPtr pad10;

        /// <summary>
        /// The pad 11
        /// </summary>
        public IntPtr pad11;

        /// <summary>
        /// The pad 12
        /// </summary>
        public IntPtr pad12;

        /// <summary>
        /// The pad 13
        /// </summary>
        public IntPtr pad13;

        /// <summary>
        /// The pad 14
        /// </summary>
        public IntPtr pad14;

        /// <summary>
        /// The pad 15
        /// </summary>
        public IntPtr pad15;

        /// <summary>
        /// The pad 16
        /// </summary>
        public IntPtr pad16;

        /// <summary>
        /// The pad 17
        /// </summary>
        public IntPtr pad17;

        /// <summary>
        /// The pad 18
        /// </summary>
        public IntPtr pad18;

        /// <summary>
        /// The pad 19
        /// </summary>
        public IntPtr pad19;

        /// <summary>
        /// The pad 20
        /// </summary>
        public IntPtr pad20;

        /// <summary>
        /// The pad 21
        /// </summary>
        public IntPtr pad21;

        /// <summary>
        /// The pad 22
        /// </summary>
        public IntPtr pad22;

        /// <summary>
        /// The pad 23
        /// </summary>
        public IntPtr pad23;
    }
}

#endif