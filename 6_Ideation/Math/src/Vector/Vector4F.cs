// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector4F.cs
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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Alis.Core.Aspect.Math.Vector
{
    /// <summary>
    ///     Represents a 4D vector with single-precision floating-point X, Y, Z, and W components.
    ///     Commonly used for homogeneous coordinates in 3D graphics. Implements <see cref="ISerializable" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector4F : ISerializable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Vector4F" /> struct with the specified component values.
        /// </summary>
        /// <param name="x">The X (horizontal) component.</param>
        /// <param name="y">The Y (vertical) component.</param>
        /// <param name="z">The Z (depth) component.</param>
        /// <param name="w">The W (projective/homogeneous) component.</param>
        public Vector4F(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        ///     Gets the component of the vector at the specified zero-based index.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <param name="index">The zero-based component index (0 = X, 1 = Y, 2 = Z, 3 = W).</param>
        /// <returns>The component value, or 0 if the index is out of range.</returns>
        public static float Get(Vector4F v, int index)
        {
            switch (index)
            {
                case 0: return v.X;
                case 1: return v.Y;
                case 2: return v.Z;
                case 3: return v.W;
                default: return 0;
            }
        }

        /// <summary>Gets or sets the horizontal (X) component of the vector.</summary>
        public float X { get; set; }

        /// <summary>Gets or sets the vertical (Y) component of the vector.</summary>
        public float Y { get; set; }

        /// <summary>Gets or sets the depth (Z) component of the vector.</summary>
        public float Z { get; set; }

        /// <summary>Gets or sets the projective/homogeneous (W) component of the vector.</summary>
        public float W { get; set; }

        /// <summary>
        ///     Populates a <see cref="SerializationInfo" /> with the vector's component data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo" /> to populate.</param>
        /// <param name="context">The streaming context.</param>
        [ExcludeFromCodeCoverage]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", X);
            info.AddValue("y", Y);
            info.AddValue("z", Z);
            info.AddValue("w", W);
        }
    }
}
