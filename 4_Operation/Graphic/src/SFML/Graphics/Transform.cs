// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Transform.cs
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
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;
using Alis.Core.Aspect.Math.Figures.D2.Rectangle;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Graphic.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Define a 3x3 transform matrix
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Transform
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a transform from a 3x3 matrix
        /// </summary>
        /// <param name="a00">Element (0, 0) of the matrix</param>
        /// <param name="a01">Element (0, 1) of the matrix</param>
        /// <param name="a02">Element (0, 2) of the matrix</param>
        /// <param name="a10">Element (1, 0) of the matrix</param>
        /// <param name="a11">Element (1, 1) of the matrix</param>
        /// <param name="a12">Element (1, 2) of the matrix</param>
        /// <param name="a20">Element (2, 0) of the matrix</param>
        /// <param name="a21">Element (2, 1) of the matrix</param>
        /// <param name="a22">Element (2, 2) of the matrix</param>
        ////////////////////////////////////////////////////////////
        public Transform(float a00, float a01, float a02,
            float a10, float a11, float a12,
            float a20, float a21, float a22)
        {
            m00 = a00;
            m01 = a01;
            m02 = a02;
            m10 = a10;
            m11 = a11;
            m12 = a12;
            m20 = a20;
            m21 = a21;
            m22 = a22;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Return the inverse of the transform.
        ///     If the inverse cannot be computed, an identity transform
        ///     is returned.
        /// </summary>
        /// <returns>A new transform which is the inverse of self</returns>
        ////////////////////////////////////////////////////////////
        public Transform GetInverse() => sfTransform_getInverse(ref this);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Transform a 2D point.
        /// </summary>
        /// <param name="x">X coordinate of the point to transform</param>
        /// <param name="y">Y coordinate of the point to transform</param>
        /// <returns>Transformed point</returns>
        ////////////////////////////////////////////////////////////
        public Vector2F TransformPoint(float x, float y) => TransformPoint(new Vector2F(x, y));

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Transform a 2D point.
        /// </summary>
        /// <param name="point">Point to transform</param>
        /// <returns>Transformed point</returns>
        ////////////////////////////////////////////////////////////
        public Vector2F TransformPoint(Vector2F point) => sfTransform_transformPoint(ref this, point);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Transform a rectangle.
        ///     Since SFML doesn't provide support for oriented rectangles,
        ///     the result of this function is always an axis-aligned
        ///     rectangle. Which means that if the transform contains a
        ///     rotation, the bounding rectangle of the transformed rectangle
        ///     is returned.
        /// </summary>
        /// <param name="rectangle">Rectangle to transform</param>
        /// <returns>Transformed rectangle</returns>
        ////////////////////////////////////////////////////////////
        public RectangleF TransformRect(RectangleF rectangle) => sfTransform_transformRect(ref this, rectangle);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with another one.
        ///     The result is a transform that is equivalent to applying
        ///     this followed by transform. Mathematically, it is
        ///     equivalent to a matrix multiplication.
        /// </summary>
        /// <param name="transform">Transform to combine to this transform</param>
        ////////////////////////////////////////////////////////////
        public void Combine(Transform transform)
        {
            sfTransform_combine(ref this, ref transform);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with a translation.
        /// </summary>
        /// <param name="x">Offset to apply on X axis</param>
        /// <param name="y">Offset to apply on Y axis</param>
        ////////////////////////////////////////////////////////////
        public void Translate(float x, float y)
        {
            sfTransform_translate(ref this, x, y);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with a translation.
        /// </summary>
        /// <param name="offset">Translation offset to apply</param>
        ////////////////////////////////////////////////////////////
        public void Translate(Vector2F offset)
        {
            Translate(offset.X, offset.Y);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with a rotation.
        /// </summary>
        /// <param name="angle">Rotation angle, in degrees</param>
        ////////////////////////////////////////////////////////////
        public void Rotate(float angle)
        {
            sfTransform_rotate(ref this, angle);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with a rotation.
        ///     The center of rotation is provided for convenience as a second
        ///     argument, so that you can build rotations around arbitrary points
        ///     more easily (and efficiently) than the usual
        ///     Translate(-center); Rotate(angle); Translate(center).
        /// </summary>
        /// <param name="angle">Rotation angle, in degrees</param>
        /// <param name="centerX">X coordinate of the center of rotation</param>
        /// <param name="centerY">Y coordinate of the center of rotation</param>
        ////////////////////////////////////////////////////////////
        public void Rotate(float angle, float centerX, float centerY)
        {
            sfTransform_rotateWithCenter(ref this, angle, centerX, centerY);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with a rotation.
        ///     The center of rotation is provided for convenience as a second
        ///     argument, so that you can build rotations around arbitrary points
        ///     more easily (and efficiently) than the usual
        ///     Translate(-center); Rotate(angle); Translate(center).
        /// </summary>
        /// <param name="angle">Rotation angle, in degrees</param>
        /// <param name="center">Center of rotation</param>
        ////////////////////////////////////////////////////////////
        public void Rotate(float angle, Vector2F center)
        {
            Rotate(angle, center.X, center.Y);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with a scaling.
        /// </summary>
        /// <param name="scaleX">Scaling factor on the X axis</param>
        /// <param name="scaleY">Scaling factor on the Y axis</param>
        ////////////////////////////////////////////////////////////
        public void Scale(float scaleX, float scaleY)
        {
            sfTransform_scale(ref this, scaleX, scaleY);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with a scaling.
        ///     The center of scaling is provided for convenience as a second
        ///     argument, so that you can build scaling around arbitrary points
        ///     more easily (and efficiently) than the usual
        ///     Translate(-center); Scale(factors); Translate(center).
        /// </summary>
        /// <param name="scaleX">Scaling factor on X axis</param>
        /// <param name="scaleY">Scaling factor on Y axis</param>
        /// <param name="centerX">X coordinate of the center of scaling</param>
        /// <param name="centerY">Y coordinate of the center of scaling</param>
        ////////////////////////////////////////////////////////////
        public void Scale(float scaleX, float scaleY, float centerX, float centerY)
        {
            sfTransform_scaleWithCenter(ref this, scaleX, scaleY, centerX, centerY);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with a scaling.
        /// </summary>
        /// <param name="factors">Scaling factors</param>
        ////////////////////////////////////////////////////////////
        public void Scale(Vector2F factors)
        {
            Scale(factors.X, factors.Y);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Combine the current transform with a scaling.
        ///     The center of scaling is provided for convenience as a second
        ///     argument, so that you can build scaling around arbitrary points
        ///     more easily (and efficiently) than the usual
        ///     Translate(-center); Scale(factors); Translate(center).
        /// </summary>
        /// <param name="factors">Scaling factors</param>
        /// <param name="center">Center of scaling</param>
        ////////////////////////////////////////////////////////////
        public void Scale(Vector2F factors, Vector2F center)
        {
            Scale(factors.X, factors.Y, center.X, center.Y);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare Transform and object and checks if they are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Object and transform are equal</returns>
        ////////////////////////////////////////////////////////////
        public override bool Equals(object obj) => obj is Transform transform && Equals(transform);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = m00.GetHashCode();
                hashCode = (hashCode * 397) ^ m01.GetHashCode();
                hashCode = (hashCode * 397) ^ m02.GetHashCode();
                hashCode = (hashCode * 397) ^ m10.GetHashCode();
                hashCode = (hashCode * 397) ^ m11.GetHashCode();
                hashCode = (hashCode * 397) ^ m12.GetHashCode();
                hashCode = (hashCode * 397) ^ m20.GetHashCode();
                hashCode = (hashCode * 397) ^ m21.GetHashCode();
                hashCode = (hashCode * 397) ^ m22.GetHashCode();
                return hashCode;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare two transforms for equality
        ///     Performs an element-wise comparison of the elements of this
        ///     transform with the elements of the right transform.
        /// </summary>
        /// <param name="transform">Transform to check</param>
        /// <returns>Transforms are equal</returns>
        ////////////////////////////////////////////////////////////
        public bool Equals(Transform transform) => sfTransform_equal(ref this, ref transform);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary operator * to combine two transforms.
        ///     This call is equivalent to calling new Transform(left).Combine(right).
        /// </summary>
        /// <param name="left">Left operand (the first transform)</param>
        /// <param name="right">Right operand (the second transform)</param>
        /// <returns>New combined transform</returns>
        ////////////////////////////////////////////////////////////
        public static Transform operator *(Transform left, Transform right)
        {
            left.Combine(right);
            return left;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary operator * to transform a point.
        ///     This call is equivalent to calling left.TransformPoint(right).
        /// </summary>
        /// <param name="left">Left operand (the transform)</param>
        /// <param name="right">Right operand (the point to transform)</param>
        /// <returns>New transformed point</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F operator *(Transform left, Vector2F right) => left.TransformPoint(right);

        ////////////////////////////////////////////////////////////
        /// <summary>The identity transform (does nothing)</summary>
        ////////////////////////////////////////////////////////////
        public static Transform Identity =>
            new Transform(1, 0, 0,
                0, 1, 0,
                0, 0, 1);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => string.Format("[Transform]" +
                                                           " Matrix(" +
                                                           "{0}, {1}, {2}," +
                                                           "{3}, {4}, {5}," +
                                                           "{6}, {7}, {8}, )",
            m00, m01, m02,
            m10, m11, m12,
            m20, m21, m22);

        /// <summary>
        ///     The 02
        /// </summary>
        internal readonly float m00;

        /// <summary>
        ///     The 02
        /// </summary>
        internal readonly float m01;

        /// <summary>
        ///     The 02
        /// </summary>
        internal readonly float m02;

        /// <summary>
        ///     The 12
        /// </summary>
        internal readonly float m10;

        /// <summary>
        ///     The 12
        /// </summary>
        internal readonly float m11;

        /// <summary>
        ///     The 12
        /// </summary>
        internal readonly float m12;

        /// <summary>
        ///     The 22
        /// </summary>
        internal readonly float m20;

        /// <summary>
        ///     The 22
        /// </summary>
        internal readonly float m21;

        /// <summary>
        ///     The 22
        /// </summary>
        internal readonly float m22;

        /// <summary>
        ///     Sfs the transform get inverse using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <returns>The transform</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Transform sfTransform_getInverse(ref Transform transform);

        /// <summary>
        ///     Sfs the transform transform point using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The vector 2f</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2F sfTransform_transformPoint(ref Transform transform, Vector2F point);

        /// <summary>
        ///     Sfs the transform transform rect using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="rectangle">The rectangle</param>
        /// <returns>The float rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern RectangleF sfTransform_transformRect(ref Transform transform, RectangleF rectangle);

        /// <summary>
        ///     Sfs the transform combine using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="other">The other</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfTransform_combine(ref Transform transform, ref Transform other);

        /// <summary>
        ///     Sfs the transform translate using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfTransform_translate(ref Transform transform, float x, float y);

        /// <summary>
        ///     Sfs the transform rotate using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="angle">The angle</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfTransform_rotate(ref Transform transform, float angle);

        /// <summary>
        ///     Sfs the transform rotate with center using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="angle">The angle</param>
        /// <param name="centerX">The center</param>
        /// <param name="centerY">The center</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfTransform_rotateWithCenter(ref Transform transform, float angle, float centerX,
            float centerY);

        /// <summary>
        ///     Sfs the transform scale using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfTransform_scale(ref Transform transform, float scaleX, float scaleY);

        /// <summary>
        ///     Sfs the transform scale with center using the specified transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <param name="centerX">The center</param>
        /// <param name="centerY">The center</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfTransform_scaleWithCenter(ref Transform transform, float scaleX, float scaleY,
            float centerX, float centerY);

        /// <summary>
        ///     Describes whether sf transform equal
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfTransform_equal(ref Transform left, ref Transform right);
    }
}