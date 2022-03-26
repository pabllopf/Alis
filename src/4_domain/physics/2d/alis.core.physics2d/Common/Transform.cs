// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Transform.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     A transform contains translation and rotation.
    ///     It is used to represent the position and orientation of rigid frames.
    /// </summary>
    public struct Transform
    {
        /// <summary>
        ///     Position
        /// </summary>
        public Vector2 p;

        /// <summary>
        ///     Rotation
        /// </summary>
        // public Mat22 q;
        public Matrix3x2 q;

        /// <summary>
        ///     Initialize using a position vector and a rotation matrix.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="R"></param>
        // public Transform(Vector2 position, Mat22 rotation)
        // {
        // 	p = position;
        // 	q = rotation;
        // }
        public Transform(Vector2 position, Matrix3x2 rotation)
        {
            p = position;
            q = rotation;
        }

        /// <summary>
        ///     Set this to the identity transform.
        /// </summary>
        public void SetIdentity()
        {
            p = Vector2.Zero;
            // q.SetIdentity();
            q = Matrix3x2.Identity;
        }

        /// Set this based on the position and angle.
        public void Set(Vector2 p, float angle)
        {
            this.p = p;
            q = Matrex.CreateRotation(angle); // Actually about twice as fast to use our own function
        }

        /// Calculate the angle that the rotation matrix represents.
        public float GetAngle() =>
            //	|  ex  |  ey  |
            //  +------+------+
            //	| ex.X | ey.X |
            //  | M11  | M12  |
            //  +------+------+
            //  | ex.Y | ey.Y |
            //  | M21  | M22  |
            //  +------+------+
            MathF.Atan2(q.M21, q.M11);

        /// <summary>
        ///     Gets the value of the identity
        /// </summary>
        public static Transform Identity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Transform(Vector2.Zero, Matrix3x2.Identity);
        }
    }
}