// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NsRect.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    /// The ns rect
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NsRect
    {
        /// <summary>
        /// The 
        /// </summary>
        public double x;
        /// <summary>
        /// The 
        /// </summary>
        public double y;
        /// <summary>
        /// The width
        /// </summary>
        public double width;
        /// <summary>
        /// The height
        /// </summary>
        public double height;
    }
}

#endif
