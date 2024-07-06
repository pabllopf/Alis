// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DisplayMode.cs
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

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl display mode
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayMode
    {
        /// <summary>
        ///     The format
        /// </summary>
        public readonly uint format;

        /// <summary>
        ///     The
        /// </summary>
        public readonly int w;

        /// <summary>
        ///     The
        /// </summary>
        public readonly int h;

        /// <summary>
        ///     The refresh rate
        /// </summary>
        public readonly int refresh_rate;

        /// <summary>
        ///     The driver data
        /// </summary>
        public IntPtr driverData;
    }
}