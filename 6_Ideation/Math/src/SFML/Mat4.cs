// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Mat4.cs
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

namespace Alis.Core.Aspect.Math.SFML
{
    /// <summary>
    ///     <see cref="Mat4" /> is a struct representing a glsl mat4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Mat4
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provides easy-access to an identity matrix
        /// </summary>
        /// <remarks>
        ///     Keep in mind that a Mat4 cannot be modified after construction
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public static Mat4 Identity =>
            new Mat4(1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Mat4" /> from its components
        /// </summary>
        /// <remarks>
        ///     Arguments are in row-major order
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public Mat4(float a00, float a01, float a02, float a03,
            float a10, float a11, float a12, float a13,
            float a20, float a21, float a22, float a23,
            float a30, float a31, float a32, float a33)
        {
            // transpose to column major
            array[0] = a00;
            array[4] = a01;
            array[8] = a02;
            array[12] = a03;
            array[1] = a10;
            array[5] = a11;
            array[9] = a12;
            array[13] = a13;
            array[2] = a20;
            array[6] = a21;
            array[10] = a22;
            array[14] = a23;
            array[3] = a30;
            array[7] = a31;
            array[11] = a32;
            array[15] = a33;
        }

        
        // column major!
        /// <summary>
        ///     The array
        /// </summary>
        private fixed float array[4 * 4];
    }
}