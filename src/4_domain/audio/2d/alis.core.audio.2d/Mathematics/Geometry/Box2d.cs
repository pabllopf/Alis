// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Box2d.cs
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
    public struct Box2d : IEquatable<Box2d>
    {
        /// <summary>
        ///     The min
        /// </summary>
        private Vector2d _min;

        /// <summary>
        ///     Gets or sets the minimum boundary of the structure.
        /// </summary>
        public Vector2d Min
        {
            get => _min;
            set
            {
                if (value.X > _max.X)
                {
                    _max.X = value.X;
                }

                if (value.Y > _max.Y)
                {
                    _max.Y = value.Y;
                }

                _min = value;
            }
        }

        /// <summary>
        ///     The max
        /// </summary>
        private Vector2d _max;

        /// <summary>
        ///     Gets or sets the maximum boundary of the structure.
        /// </summary>
        public Vector2d Max
        {
            get => _max;
            set
            {
                if (value.X < _min.X)
                {
                    _min.X = value.X;
                }

                if (value.Y < _min.Y)
                {
                    _min.Y = value.Y;
                }

                _max = value;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Box2d" /> struct.
        /// </summary>
        /// <param name="min">The minimum point on the XY plane this box encloses.</param>
        /// <param name="max">The maximum point on the XY plane this box encloses.</param>
        public Box2d(Vector2d min, Vector2d max)
        {
            _min = Vector2d.ComponentMin(min, max);
            _max = Vector2d.ComponentMax(min, max);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Box2d" /> struct.
        /// </summary>
        /// <param name="minX">The minimum X value to be enclosed.</param>
        /// <param name="minY">The minimum Y value to be enclosed.</param>
        /// <param name="maxX">The maximum X value to be enclosed.</param>
        /// <param name="maxY">The maximum Y value to be enclosed.</param>
        public Box2d(double minX, double minY, double maxX, double maxY)
            : this(new Vector2d(minX, minY), new Vector2d(maxX, maxY))
        {
        }

        /// <summary>
        ///     Gets or sets a vector describing the size of the Box2d structure.
        /// </summary>
        public Vector2d Size
        {
            get => Max - Min;
            set
            {
                Vector2d center = Center;
                _min = center - value * 0.5f;
                _max = center + value * 0.5f;
            }
        }

        /// <summary>
        ///     Gets or sets a vector describing half the size of the box.
        /// </summary>
        public Vector2d HalfSize
        {
            get => Size / 2;
            set => Size = value * 2;
        }

        /// <summary>
        ///     Gets or sets a vector describing the center of the box.
        /// </summary>
        public Vector2d Center
        {
            get => HalfSize + _min;
            set => Translate(value - Center);
        }

        /// <summary>
        ///     Returns whether the box contains the specified point (borders inclusive).
        /// </summary>
        /// <param name="point">The point to query.</param>
        /// <returns>Whether this box contains the point.</returns>
        [Pure]
        public bool Contains(Vector2d point) =>
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
        public bool Contains(Vector2d point, bool boundaryInclusive)
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
        public bool Contains(Box2d other) =>
            _max.X >= other._min.X && _min.X <= other._max.X &&
            _max.Y >= other._min.Y && _min.Y <= other._max.Y;

        /// <summary>
        ///     Returns the distance between the nearest edge and the specified point.
        /// </summary>
        /// <param name="point">The point to find distance for.</param>
        /// <returns>The distance between the specified point and the nearest edge.</returns>
        [Pure]
        public double DistanceToNearestEdge(Vector2d point)
        {
            Vector2d distX = new Vector2d(
                Math.Max(0f, Math.Max(_min.X - point.X, point.X - _max.X)),
                Math.Max(0f, Math.Max(_min.Y - point.Y, point.Y - _max.Y)));
            return distX.Length;
        }

        /// <summary>
        ///     Translates this Box2d by the given amount.
        /// </summary>
        /// <param name="distance">The distance to translate the box.</param>
        public void Translate(Vector2d distance)
        {
            Min += distance;
            Max += distance;
        }

        /// <summary>
        ///     Returns a Box2d translated by the given amount.
        /// </summary>
        /// <param name="distance">The distance to translate the box.</param>
        /// <returns>The translated box.</returns>
        [Pure]
        public Box2d Translated(Vector2d distance)
        {
            // create a local copy of this box
            Box2d box = this;
            box.Translate(distance);
            return box;
        }

        /// <summary>
        ///     Scales this Box2d by the given amount.
        /// </summary>
        /// <param name="scale">The scale to scale the box.</param>
        /// <param name="anchor">The anchor to scale the box from.</param>
        public void Scale(Vector2d scale, Vector2d anchor)
        {
            _min = anchor + (_min - anchor) * scale;
            _max = anchor + (_max - anchor) * scale;
        }

        /// <summary>
        ///     Returns a Box2d scaled by a given amount from an anchor point.
        /// </summary>
        /// <param name="scale">The scale to scale the box.</param>
        /// <param name="anchor">The anchor to scale the box from.</param>
        /// <returns>The scaled box.</returns>
        [Pure]
        public Box2d Scaled(Vector2d scale, Vector2d anchor)
        {
            // create a local copy of this box
            Box2d box = this;
            box.Scale(scale, anchor);
            return box;
        }

        /// <summary>
        ///     Inflate this Box2d to encapsulate a given point.
        /// </summary>
        /// <param name="point">The point to query.</param>
        public void Inflate(Vector2d point)
        {
            _min = Vector2d.ComponentMin(_min, point);
            _max = Vector2d.ComponentMax(_max, point);
        }

        /// <summary>
        ///     Inflate this Box2d to encapsulate a given point.
        /// </summary>
        /// <param name="point">The point to query.</param>
        /// <returns>The inflated box.</returns>
        [Pure]
        public Box2d Inflated(Vector2d point)
        {
            // create a local copy of this box
            Box2d box = this;
            box.Inflate(point);
            return box;
        }

        /// <summary>
        ///     Equality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static bool operator ==(Box2d left, Box2d right) => left.Equals(right);

        /// <summary>
        ///     Inequality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static bool operator !=(Box2d left, Box2d right) => !(left == right);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is Box2d && Equals((Box2d) obj);

        /// <inheritdoc />
        public bool Equals(Box2d other) =>
            _min.Equals(other._min) &&
            _max.Equals(other._max);

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(_min, _max);

        /// <inheritdoc />
        public override string ToString() => $"{Min} - {Max}";
    }
}