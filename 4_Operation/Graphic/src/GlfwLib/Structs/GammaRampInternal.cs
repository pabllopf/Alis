// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GammaRampInternal.cs
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

namespace Alis.Core.Graphic.GlfwLib.Structs
{
    // TODO:  Make custom marshaller instead of this

    /// <summary>
    ///     Used internally for marshalling
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct GammaRampInternal
    {
        /// <summary>
        ///     The red
        /// </summary>
        public readonly IntPtr Red;

        /// <summary>
        ///     The green
        /// </summary>
        public readonly IntPtr Green;

        /// <summary>
        ///     The blue
        /// </summary>
        public readonly IntPtr Blue;

        /// <summary>
        ///     The size
        /// </summary>
        public readonly int Size;

        public static explicit operator GammaRamp(GammaRampInternal ramp)
        {
            int offset = 0;
            ushort[] red = new ushort[ramp.Size];
            ushort[] green = new ushort[ramp.Size];
            ushort[] blue = new ushort[ramp.Size];
            for (int i = 0; i < ramp.Size; i++, offset += sizeof(ushort))
            {
                red[i] = unchecked((ushort) Marshal.ReadInt16(ramp.Red, offset));
                green[i] = unchecked((ushort) Marshal.ReadInt16(ramp.Green, offset));
                blue[i] = unchecked((ushort) Marshal.ReadInt16(ramp.Blue, offset));
            }

            return new GammaRamp(red, green, blue);
        }
    }
}