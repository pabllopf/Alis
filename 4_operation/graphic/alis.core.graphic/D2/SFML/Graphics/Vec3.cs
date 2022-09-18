// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec3.cs
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

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    /// <summary>
    ///     <see cref="Vec3" /> is a struct represent a glsl vec3 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Implicit cast from <see cref="Vector3F" /> to <see cref="Vec3" />
        /// </summary>
        public static implicit operator Vec3(Vector3F vec) => new Vec3(vec);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vec3" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vec3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vec3" /> from a standard SFML <see cref="Vector3F" />
        /// </summary>
        /// <param name="vec">A standard SFML 3D vector</param>
        ////////////////////////////////////////////////////////////
        public Vec3(Vector3F vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        /// <summary>Horizontal component of the vector</summary>
        public float X;

        /// <summary>Vertical component of the vector</summary>
        public float Y;

        /// <summary>Depth component of the vector</summary>
        public float Z;
    }
}