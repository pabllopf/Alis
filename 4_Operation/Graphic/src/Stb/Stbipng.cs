// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Stbipng.cs
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

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stbi png class
    /// </summary>
    public class Stbipng
    {
        /// <summary>
        ///     The depth
        /// </summary>
        public int Depth;

        /// <summary>
        ///     The expanded
        /// </summary>
        public IntPtr Expanded;

        /// <summary>
        ///     The idata
        /// </summary>
        public IntPtr Idata;

        /// <summary>
        ///     The @out
        /// </summary>
        public IntPtr @out;

        /// <summary>
        ///     The
        /// </summary>
        public Stbicontext S;
    }
}