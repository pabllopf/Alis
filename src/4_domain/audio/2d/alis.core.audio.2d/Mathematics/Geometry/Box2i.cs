// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Box2i.cs
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
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Alis.Core.Audio.Mathematics.Vector;

namespace Alis.Core.Audio.Mathematics.Geometry
{
    /// <summary>
    ///     Defines an axis-aligned 2d box (rectangle).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Box2i : IEquatable<Box2i>
    {
        /// <summary>
        ///     An empty box with Min (0, 0) and Max (0, 0).
        /// </summary>
        public static readonly Box2i Empty = new Box2i(0, 0, 0, 0);

        /// <summary>
        /// The min
        /// </summary>
        private Vector2i _min;

        /// <summary>
        ///     Gets or sets the minimum boundary of the structure.
        /// </summary>
        public Vector2i Min
        {
            get => _min;
            set
            {
                _max = Vector2i.ComponentMax(_max, value);
                _min = value;
            }
        }

        /// <summary>
        /// The max
        /// </summary>
        private Vector2i _max;

        /// <summary>
        ///     Gets or sets the maximum boundary of the structure.
        /// </summary>
        public Vector2i Max
        {
            get => _max;
            set
            {
                _min = Vector2i.ComponentMin(_min, value);
                _max = value;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Box2i" /> struct.
        /// </summary>
        /// <param name="min">The minimum point on the XY plane this box encloses.</param>
        /// <param name="max">The maximum point on the XY plane this box encloses.</param>
        public Box2i(Vector2i min, Vector2i max)
        {
            _min = Vector2i.ComponentMin(min, max);
            _max = Vector2i.ComponentMax(min, max);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Box2i" /> struct.
        /// </summary>
        /// <param name="minX">The minimum X value to be enclosed.</param>
        /// <param name="minY">The minimum Y value to be enclosed.</param>
        /// <param name="maxX">The maximum X value to be enclosed.</param>
        /// <param name="maxY">The maximum Y value to be enclosed.</param>
        public Box2i(int minX, int minY, int maxX, int maxY)
            : this(new Vector2i(minX, minY), new Vector2i(maxX, maxY))
        {
        }

        /// <summary>
        ///     Gets a vector describing the size of the Box2i structure.
        /// </summary>
        public Vector2i Size => Max - Min;

        /// <summary>
        ///     Gets or sets a vector describing half the size of the box.
        /// </summary>
        public Vector2i HalfSize
        {
            get => Size / 2;
            set
            {
                Vector2i center = new Vector2i((int) Center.X, (int) Center.Y);
                _min = center - value;
                _max = center + value;
            }
        }

        /// <summary>
        ///     Gets a vector describing the center of the box.
        /// </summary>
        /// to avoid annoying off-by-one errors in box placement, no setter is provided for this property
        public Vector2 Center => _min + (_max - _min).ToVector2() * 0.5f;

        /// <summary>
        ///     Returns whether the box contains the specified point (borders inclusive).
        /// </summary>
        /// <param name="point">The point to query.</param>
        /// <returns>Whether this box contains the point.</returns>
        [Pure]
        public bool Contains(Vector2i point) =>
            _min.X < point.X && point.X < _max.X &&
            _min.Y < point.Y && point.Y < _max.Y;

        /// <summary>
        ///     Returns whether the box contains the specified point.
        /// </summary>
        /// <param name="point">The point to query.</param>
        /// <param name="boundaryInclusive">
        ///     Whether points on the box boundary should be recognised as contained as well.
        /// </param>
        /// <returns>Whether this box contains the point.</returns>
        [Pure]
        public bool Contains(Vector2i point, bool boundaryInclusive)
        {
            if (boundaryInclusive)
            {
                return _min.X <= point.X && point.X <= _max.X &&
                       _min.Y <= point.Y && point.Y <= _max.Y;
            }

            return _min.X < point.X && point.X < _max.X &&
                   _min.Y < point.Y && point.Y < _max.Y;
        }

        /// <summary>
        ///     Returns whether the box contains the specified box (borders inclusive).
        /// </summary>
        /// <param name="other">The box to query.</param>
        /// <returns>Whether this box contains the other box.</returns>
        [Pure]
        public bool Contains(Box2i other) =>
            _max.X >= other._min.X && _min.X <= other._max.X &&
            _max.Y >= other._min.Y && _min.Y <= other._max.Y;

        /// <summary>
        ///     Creates a rectangle that represents the intersection between a and
        ///     b. If there is no intersection, a empty <see cref="Box2i" /> is returned.
        /// </summary>
        /// <param name="a">First rectangle to intersect.</param>
        /// <param name="b">Second rectangle to intersect.</param>
        /// <returns>The <see cref="Box2i" /> that represents the intersection of both Box2i.</returns>
        public static Box2i Intersect(Box2i a, Box2i b)
        {
            Vector2i min = Vector2i.ComponentMax(a.Min, b.Min);
            Vector2i max = Vector2i.ComponentMin(a.Max, b.Max);

            if (max.X >= min.X && max.Y >= min.Y)
            {
                return new Box2i(min, max);
            }

            return Empty;
        }

        /// <summary>
        ///     Returns the distance between the nearest edge and the specified point.
        /// </summary>
        /// <param name="point">The point to find distance for.</param>
        /// <returns>The distance between the specified point and the nearest edge.</returns>
        [Pure]
        public float DistanceToNearestEdge(Vector2i point)
        {
            Vector2 dist = new Vector2(
                Math.Max(0f, Math.Max(_min.X - point.X, point.X - _max.X)),
                Math.Max(0f, Math.Max(_min.Y - point.Y, point.Y - _max.Y)));
            return dist.Length;
        }

        /// <summary>
        ///     Translates this Box2i by the given amount.
        /// </summary>
        /// <param name="distance">The distance to translate the box.</param>
        public void Translate(Vector2i distance)
        {
            Min += distance;
            Max += distance;
        }

        /// <summary>
        ///     Returns a Box2i translated by the given amount.
        /// </summary>
        /// <param name="distance">The distance to translate the box.</param>
        /// <returns>The translated box.</returns>
        [Pure]
        public Box2i Translated(Vector2i distance)
        {
            // create a local copy of this box
            Box2i box = this;
            box.Translate(distance);
            return box;
        }

        /// <summary>
        ///     Scales this Box2i by the given amount.
        /// </summary>
        /// <param name="scale">The scale to scale the box.</param>
        /// <param name="anchor">The anchor to scale the box from.</param>
        public void Scale(Vector2i scale, Vector2i anchor)
        {
            _min = anchor + (_min - anchor) * scale;
            _max = anchor + (_max - anchor) * scale;
        }

        /// <summary>
        ///     Returns a Box2i scaled by a given amount from an anchor point.
        /// </summary>
        /// <param name="scale">The scale to scale the box.</param>
        /// <param name="anchor">The anchor to scale the box from.</param>
        /// <returns>The scaled box.</returns>
        [Pure]
        public Box2i Scaled(Vector2i scale, Vector2i anchor)
        {
            // create a local copy of this box
            Box2i box = this;
            box.Scale(scale, anchor);
            return box;
        }

        /// <summary>
        ///     Inflate this Box2i to encapsulate a given point.
        /// </summary>
        /// <param name="point">The point to query.</param>
        public void Inflate(Vector2i point)
        {
            _min = Vector2i.ComponentMin(_min, point);
            _max = Vector2i.ComponentMax(_max, point);
        }

        /// <summary>
        ///     Inflate this Box2i to encapsulate a given point.
        /// </summary>
        /// <param name="point">The point to query.</param>
        /// <returns>The inflated box.</returns>
        [Pure]
        public Box2i Inflated(Vector2i point)
        {
            // create a local copy of this box
            Box2i box = this;
            box.Inflate(point);
            return box;
        }

        /// <summary>
        ///     Equality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static bool operator ==(Box2i left, Box2i right) => left.Equals(right);

        /// <summary>
        ///     Inequality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static bool operator !=(Box2i left, Box2i right) => !(left == right);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Box2i && Equals((Box2i) obj);

        /// <inheritdoc />
        public bool Equals(Box2i other) =>
            _min.Equals(other._min) &&
            _max.Equals(other._max);

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(_min, _max);

        /// <inheritdoc />
        public override string ToString() => $"{Min} - {Max}";
    }
}