// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Vec2.cs
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

namespace Alis.Aspect.Math
{
    /// <summary>
    ///     A 2D column vector.
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(Vector2 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Vector2 && Equals((Vector2) obj);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        /// <summary>
        ///     The
        /// </summary>
        public float X, Y;

        /// <summary>
        ///     The assert
        /// </summary>
        public float this[int i]
        {
            get
            {
                if (i == 0)
                {
                    return X;
                }

                if (i == 1)
                {
                    return Y;
                }

                //Box2DxDebug.Assert(false, "Incorrect Vec2 element!");
                return 0;
            }
            set
            {
                if (i == 0)
                {
                    X = value;
                }
                else if (i == 1)
                {
                    Y = value;
                }
                //else
                //{
                  //  Box2DxDebug.Assert(false, "Incorrect Vec2 element!");
               // }
            }
        }

        /// <summary>
        ///     Construct using coordinates.
        /// </summary>
        public Vector2(float x)
        {
            X = x;
            Y = x;
        }

        /// <summary>
        ///     Construct using coordinates.
        /// </summary>
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Set this vector to all zeros.
        /// </summary>
        public void SetZero()
        {
            X = 0.0f;
            Y = 0.0f;
        }

        /// <summary>
        ///     Set this vector to some specified coordinates.
        /// </summary>
        public void Set(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Sets the xy
        /// </summary>
        /// <param name="xy">The xy</param>
        public void Set(float xy)
        {
            X = xy;
            Y = xy;
        }

        /// <summary>
        ///     Get the length of this vector (the norm).
        /// </summary>
        public float Length()
        {
            return (float) System.Math.Sqrt(X * X + Y * Y);
        }

        /// <summary>
        ///     Get the length squared. For performance, use this instead of
        ///     Length (if possible).
        /// </summary>
        public float LengthSquared()
        {
            return X * X + Y * Y;
        }

        /// <summary>
        ///     Convert this vector into a unit vector. Returns the length.
        /// </summary>
        public float Normalize()
        {
            float length = Length();
            if (length < Settings.FltEpsilon)
            {
                return 0.0f;
            }

            float invLength = 1.0f / length;
            X *= invLength;
            Y *= invLength;

            return length;
        }

        /// <summary>
        ///     Does this vector contain finite coordinates?
        /// </summary>
        public bool IsValid
        {
            get { return Math.IsValid(X) && Math.IsValid(Y); }
        }

        /// <summary>
        ///     Negate this vector.
        /// </summary>
        public static Vector2 operator -(Vector2 v1)
        {
            Vector2 v = new Vector2();
            v.Set(-v1.X, -v1.Y);
            return v;
        }

        /// <summary>
        ///     Hello
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            Vector2 v = new Vector2();
            v.Set(v1.X + v2.X, v1.Y + v2.Y);
            return v;
        }

        /// <summary>
        ///     Hello
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            Vector2 v = new Vector2();
            v.Set(v1.X - v2.X, v1.Y - v2.Y);
            return v;
        }

        /// <summary>
        ///     operator
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Vector2 operator *(Vector2 v1, float a)
        {
            Vector2 v = new Vector2();
            v.Set(v1.X * a, v1.Y * a);
            return v;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector2 operator *(float a, Vector2 v1)
        {
            Vector2 v = new Vector2();
            v.Set(v1.X * a, v1.Y * a);
            return v;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2 a, Vector2 b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        /// <summary>
        ///     Gets the value of the zero
        /// </summary>
        public static Vector2 Zero
        {
            get { return new Vector2(0, 0); }
        }

        /// <summary>
        ///     Peform the dot product on two vectors.
        /// </summary>
        public static float Dot(Vector2 a, Vector2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        /// <summary>
        ///     Perform the cross product on two vectors. In 2D this produces a scalar.
        /// </summary>
        public static float Cross(Vector2 a, Vector2 b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        /// <summary>
        ///     Perform the cross product on a vector and a scalar.
        ///     In 2D this produces a vector.
        /// </summary>
        public static Vector2 Cross(Vector2 a, float s)
        {
            Vector2 v = new Vector2();
            v.Set(s * a.Y, -s * a.X);
            return v;
        }

        /// <summary>
        ///     Perform the cross product on a scalar and a vector.
        ///     In 2D this produces a vector.
        /// </summary>
        public static Vector2 Cross(float s, Vector2 a)
        {
            Vector2 v = new Vector2();
            v.Set(-s * a.Y, s * a.X);
            return v;
        }

        /// <summary>
        ///     Distances the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float Distance(Vector2 a, Vector2 b)
        {
            Vector2 c = a - b;
            return c.Length();
        }

        /// <summary>
        ///     Distances the squared using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The float</returns>
        public static float DistanceSquared(Vector2 a, Vector2 b)
        {
            Vector2 c = a - b;
            return Dot(c, c);
        }
    }
}