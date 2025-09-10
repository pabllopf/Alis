// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Pixelformatdescriptor.cs
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

#if winx64
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct Pixelformatdescriptor
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort nSize;

        /// <summary>
        /// 
        /// </summary>
        public ushort nVersion;

        /// <summary>
        /// 
        /// </summary>
        public uint dwFlags;

        /// <summary>
        /// 
        /// </summary>
        public byte iPixelType;

        /// <summary>
        /// 
        /// </summary>
        public byte cColorBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cRedBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cRedShift;

        /// <summary>
        /// 
        /// </summary>
        public byte cGreenBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cGreenShift;

        /// <summary>
        /// 
        /// </summary>
        public byte cBlueBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cBlueShift;

        /// <summary>
        /// 
        /// </summary>
        public byte cAlphaBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cAlphaShift;

        /// <summary>
        /// 
        /// </summary>
        public byte cAccumBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cAccumRedBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cAccumGreenBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cAccumBlueBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cAccumAlphaBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cDepthBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cStencilBits;

        /// <summary>
        /// 
        /// </summary>
        public byte cAuxBuffers;

        /// <summary>
        /// 
        /// </summary>
        public byte iLayerType;

        /// <summary>
        /// 
        /// </summary>
        public byte bReserved;

        /// <summary>
        /// 
        /// </summary>
        public uint dwLayerMask;

        /// <summary>
        /// 
        /// </summary>
        public uint dwVisibleMask;

        /// <summary>
        /// 
        /// </summary>
        public uint dwDamageMask;
    }
}

#endif