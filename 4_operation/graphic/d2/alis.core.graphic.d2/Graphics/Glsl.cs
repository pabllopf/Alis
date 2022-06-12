// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Glsl.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.D2.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Vec2" /> is a struct represent a glsl vec2 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Implicit cast from <see cref="Vector2f" /> to <see cref="Vec2" />
        /// </summary>
        public static implicit operator Vec2(Vector2f vec)
        {
            return new Vec2(vec);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vec2" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vec2(float x, float y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vec2" /> from a standard SFML <see cref="Vector2f" />
        /// </summary>
        /// <param name="vec">A standard SFML 2D vector</param>
        ////////////////////////////////////////////////////////////
        public Vec2(Vector2f vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>Horizontal component of the vector</summary>
        public float X;

        /// <summary>Vertical component of the vector</summary>
        public float Y;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Ivec2" /> is a struct represent a glsl ivec2 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Ivec2
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Implicit cast from <see cref="Vector2i" /> to <see cref="Ivec2" />
        /// </summary>
        public static implicit operator Ivec2(Vector2i vec)
        {
            return new Ivec2(vec);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Ivec2" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Ivec2(int x, int y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Ivec2" /> from a standard SFML <see cref="Vector2i" />
        /// </summary>
        /// <param name="vec">A standard SFML 2D integer vector</param>
        ////////////////////////////////////////////////////////////
        public Ivec2(Vector2i vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>Horizontal component of the vector</summary>
        public int X;

        /// <summary>Vertical component of the vector</summary>
        public int Y;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Bvec2" /> is a struct represent a glsl bvec2 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Bvec2
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Bvec2" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Bvec2(bool x, bool y)
        {
            X = x;
            Y = y;
        }

        /// <summary>Horizontal component of the vector</summary>
        public bool X;

        /// <summary>Vertical component of the vector</summary>
        public bool Y;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Vec3" /> is a struct represent a glsl vec3 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Implicit cast from <see cref="Vector3f" /> to <see cref="Vec3" />
        /// </summary>
        public static implicit operator Vec3(Vector3f vec)
        {
            return new Vec3(vec);
        }

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
        ///     Construct the <see cref="Vec3" /> from a standard SFML <see cref="Vector3f" />
        /// </summary>
        /// <param name="vec">A standard SFML 3D vector</param>
        ////////////////////////////////////////////////////////////
        public Vec3(Vector3f vec)
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

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Ivec3" /> is a struct represent a glsl ivec3 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Ivec3
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Ivec3" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        ////////////////////////////////////////////////////////////
        public Ivec3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>Horizontal component of the vector</summary>
        public int X;

        /// <summary>Vertical component of the vector</summary>
        public int Y;

        /// <summary>Depth component of the vector</summary>
        public int Z;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Bvec3" /> is a struct represent a glsl bvec3 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Bvec3
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Bvec3" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        ////////////////////////////////////////////////////////////
        public Bvec3(bool x, bool y, bool z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>Horizontal component of the vector</summary>
        public bool X;

        /// <summary>Vertical component of the vector</summary>
        public bool Y;

        /// <summary>Depth component of the vector</summary>
        public bool Z;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Vec4" /> is a struct represent a glsl vec4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec4
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vec4" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="w">W coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vec4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        ///     Construct the <see cref="Vec4" /> from a <see cref="Color" />
        /// </summary>
        /// <remarks>
        ///     The <see cref="Color" />'s values will be normalized from 0..255 to 0..1
        /// </remarks>
        /// <param name="color">A SFML <see cref="Color" /> to be translated to a 4D floating-point vector</param>
        public Vec4(Color color)
        {
            X = color.R / 255.0f;
            Y = color.G / 255.0f;
            Z = color.B / 255.0f;
            W = color.A / 255.0f;
        }

        /// <summary>Horizontal component of the vector</summary>
        public float X;

        /// <summary>Vertical component of the vector</summary>
        public float Y;

        /// <summary>Depth component of the vector</summary>
        public float Z;

        /// <summary>Projective/Homogenous component of the vector</summary>
        public float W;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Ivec4" /> is a struct represent a glsl ivec4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Ivec4
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Ivec4" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="w">W coordinate</param>
        ////////////////////////////////////////////////////////////
        public Ivec4(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        ///     Construct the <see cref="Ivec4" /> from a <see cref="Color" />
        /// </summary>
        /// <param name="color">A SFML <see cref="Color" /> to be translated to a 4D integer vector</param>
        public Ivec4(Color color)
        {
            X = color.R;
            Y = color.G;
            Z = color.B;
            W = color.A;
        }

        /// <summary>Horizontal component of the vector</summary>
        public int X;

        /// <summary>Vertical component of the vector</summary>
        public int Y;

        /// <summary>Depth component of the vector</summary>
        public int Z;

        /// <summary>Projective/Homogenous component of the vector</summary>
        public int W;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Bvec4" /> is a struct represent a glsl bvec4 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Bvec4
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Bvec4" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="w">W coordinate</param>
        ////////////////////////////////////////////////////////////
        public Bvec4(bool x, bool y, bool z, bool w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>Horizontal component of the vector</summary>
        public bool X;

        /// <summary>Vertical component of the vector</summary>
        public bool Y;

        /// <summary>Depth component of the vector</summary>
        public bool Z;

        /// <summary>Projective/Homogenous component of the vector</summary>
        public bool W;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     <see cref="Mat3" /> is a struct representing a glsl mat3 value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Mat3
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Mat3" /> from its components
        /// </summary>
        /// <remarks>
        ///     Arguments are in row-major order
        /// </remarks>
        ////////////////////////////////////////////////////////////
        public Mat3(float a00, float a01, float a02,
            float a10, float a11, float a12,
            float a20, float a21, float a22)
        {
            array[0] = a00;
            array[3] = a01;
            array[6] = a02;
            array[1] = a10;
            array[4] = a11;
            array[7] = a12;
            array[2] = a20;
            array[5] = a21;
            array[8] = a22;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Mat3" /> from a SFML <see cref="Transform" />
        /// </summary>
        /// <param name="transform">A SFML <see cref="Transform" /></param>
        ////////////////////////////////////////////////////////////
        public Mat3(Transform transform)
        {
            array[0] = transform.m00;
            array[3] = transform.m01;
            array[6] = transform.m02;
            array[1] = transform.m10;
            array[4] = transform.m11;
            array[7] = transform.m12;
            array[2] = transform.m20;
            array[5] = transform.m21;
            array[8] = transform.m22;
        }

        // column-major!
        /// <summary>
        ///     The array
        /// </summary>
        private fixed float array[3 * 3];
    }

    ////////////////////////////////////////////////////////////
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

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Mat3" /> from a SFML <see cref="Transform" /> and expand it to a 4x4 matrix
        /// </summary>
        /// <param name="transform">A SFML <see cref="Transform" /></param>
        ////////////////////////////////////////////////////////////
        public Mat4(Transform transform)
        {
            // swapping to column-major (OpenGL) from row-major (SFML) order
            // in addition, filling in the blanks (from expanding to a mat4) with values from
            // an identity matrix
            array[0] = transform.m00;
            array[4] = transform.m01;
            array[8] = 0;
            array[12] = transform.m02;
            array[1] = transform.m10;
            array[5] = transform.m11;
            array[9] = 0;
            array[13] = transform.m12;
            array[2] = 0;
            array[6] = 0;
            array[10] = 1;
            array[14] = 0;
            array[3] = transform.m20;
            array[7] = transform.m21;
            array[11] = 0;
            array[15] = transform.m22;
        }

        // column major!
        /// <summary>
        ///     The array
        /// </summary>
        private fixed float array[4 * 4];
    }
}