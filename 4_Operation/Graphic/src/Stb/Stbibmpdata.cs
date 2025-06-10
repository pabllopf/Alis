// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Stbibmpdata.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stbi bmp data
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Stbibmpdata
    {
        /// <summary>
        ///     The bpp
        /// </summary>
        public int bpp;

        /// <summary>
        ///     The offset
        /// </summary>
        public int offset;

        /// <summary>
        ///     The hsz
        /// </summary>
        public int hsz;

        /// <summary>
        ///     The mr
        /// </summary>
        public uint mr;

        /// <summary>
        ///     The mg
        /// </summary>
        public uint mg;

        /// <summary>
        ///     The mb
        /// </summary>
        public uint mb;

        /// <summary>
        ///     The ma
        /// </summary>
        public uint ma;

        /// <summary>
        ///     The all
        /// </summary>
        public uint alla;

        /// <summary>
        ///     The extra read
        /// </summary>
        public int extraread;
    }
}