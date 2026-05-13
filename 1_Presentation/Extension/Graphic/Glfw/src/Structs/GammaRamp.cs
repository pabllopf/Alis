// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GammaRamp.cs
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

namespace Alis.Extension.Graphic.Glfw.Structs
{
    /// <summary>
    ///     Describes the gamma ramp for a monitor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GammaRamp
    {
        /// <summary>
        ///     An array of value describing the response of the red channel.
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray)] public ushort[] Red;

        /// <summary>
        ///     An array of value describing the response of the green channel.
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray)] public readonly ushort[] Green;

        /// <summary>
        ///     An array of value describing the response of the blue channel.
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray)] public readonly ushort[] Blue;

        /// <summary>
        ///     The number of elements in each array.
        /// </summary>
        public readonly uint Size;

        /// <summary>
        ///     Creates a new instance of a <see cref="GammaRamp" /> using the specified values.
        ///     <para>WARNING: On some platforms (Windows), each value MUST be 256 in length.</para>
        /// </summary>
        /// <param name="red">An array of value describing the response of the red channel.</param>
        /// <param name="green">An array of value describing the response of the green channel.</param>
        /// <param name="blue">An array of value describing the response of the blue channel.</param>
        public GammaRamp(ushort[] red, ushort[] green, ushort[] blue)
        {
            if ((red.Length == green.Length) && (green.Length == blue.Length))
            {
                Red = red;
                Green = green;
                Blue = blue;
                Size = (uint) red.Length;
            }
            else
            {
                throw new ArgumentException(
                    $"{nameof(red)}, {nameof(green)}, and {nameof(blue)} must all be equal length.");
            }
        }
    }
}