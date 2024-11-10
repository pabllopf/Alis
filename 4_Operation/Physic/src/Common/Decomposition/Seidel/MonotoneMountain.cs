// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MonotoneMountain.cs
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

/* Original source Farseer Physics Engine:
 * Copyright (c) 2014 Ian Qvist, http://farseerphysics.codeplex.com
 * Microsoft Permissive License (Ms-PL) v1.1
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    /// <summary>
    /// The monotone mountain class
    /// </summary>
    internal class MonotoneMountain
    {
        // Almost Pi!
        /// <summary>
        /// The pi slop
        /// </summary>
        private const float PiSlop = 3.1f;
        /// <summary>
        /// The convex points
        /// </summary>
        private readonly HashSet<Point> _convexPoints;
        /// <summary>
        /// The head
        /// </summary>
        private Point _head;

        // Monotone mountain points
        /// <summary>
        /// The mono poly
        /// </summary>
        private readonly List<Point> _monoPoly;

        // Used to track which side of the line we are on
        /// <summary>
        /// The positive
        /// </summary>
        private bool _positive;
        /// <summary>
        /// The size
        /// </summary>
        private int _size;
        /// <summary>
        /// The tail
        /// </summary>
        private Point _tail;

        // Triangles that constitute the mountain
        /// <summary>
        /// The triangles
        /// </summary>
        public List<List<Point>> Triangles;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonotoneMountain"/> class
        /// </summary>
        public MonotoneMountain()
        {
            _size = 0;
            _tail = null;
            _head = null;
            _positive = false;
            _convexPoints = new HashSet<Point>();
            _monoPoly = new List<Point>();
            Triangles = new List<List<Point>>();
        }

        // Append a point to the list
        /// <summary>
        /// Adds the point
        /// </summary>
        /// <param name="point">The point</param>
        public void Add(Point point)
        {
            if (_size == 0)
            {
                _head = point;
                _size = 1;
            }
            else if (_size == 1)
            {
                // Keep repeat points out of the list
                _tail = point;
                _tail.Prev = _head;
                _head.Next = _tail;
                _size = 2;
            }
            else
            {
                // Keep repeat points out of the list
                _tail.Next = point;
                point.Prev = _tail;
                _tail = point;
                _size += 1;
            }
        }

        // Remove a point from the list
        /// <summary>
        /// Removes the point
        /// </summary>
        /// <param name="point">The point</param>
        public void Remove(Point point)
        {
            Point next = point.Next;
            Point prev = point.Prev;
            point.Prev.Next = next;
            point.Next.Prev = prev;
            _size -= 1;
        }

        // Partition a x-monotone mountain into triangles O(n)
        // See "Computational Geometry in C", 2nd edition, by Joseph O'Rourke, page 52
        /// <summary>
        /// Processes this instance
        /// </summary>
        public void Process()
        {
            // Establish the proper sign
            _positive = AngleSign();
            // create monotone polygon - for dubug purposes
            GenMonoPoly();

            // Initialize internal angles at each nonbase vertex
            // Link strictly convex vertices into a list, ignore reflex vertices
            Point p = _head.Next;
            while (p.Neq(_tail))
            {
                float a = Angle(p);
                // If the point is almost colinear with it's neighbor, remove it!
                if (a >= PiSlop || a <= -PiSlop || a == 0.0f)
                    Remove(p);
                else if (IsConvex(p))
                    _convexPoints.Add(p);
                p = p.Next;
            }

            Triangulate();
        }

        /// <summary>
        /// Triangulates this instance
        /// </summary>
        private void Triangulate()
        {
            while (_convexPoints.Count != 0)
            {
                IEnumerator<Point> e = _convexPoints.GetEnumerator();
                e.MoveNext();
                Point ear = e.Current;

                _convexPoints.Remove(ear);
                Point a = ear.Prev;
                Point b = ear;
                Point c = ear.Next;
                List<Point> triangle = new List<Point>(3);
                triangle.Add(a);
                triangle.Add(b);
                triangle.Add(c);

                Triangles.Add(triangle);

                // Remove ear, update angles and convex list
                Remove(ear);
                if (Valid(a))
                    _convexPoints.Add(a);
                if (Valid(c))
                    _convexPoints.Add(c);
            }

            Debug.Assert(_size <= 3, "Triangulation bug, please report");
        }

        /// <summary>
        /// Describes whether this instance valid
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        private bool Valid(Point p) => p.Neq(_head) && p.Neq(_tail) && IsConvex(p);

        // Create the monotone polygon
        /// <summary>
        /// Gens the mono poly
        /// </summary>
        private void GenMonoPoly()
        {
            Point p = _head;
            while (p != null)
            {
                _monoPoly.Add(p);
                p = p.Next;
            }
        }

        /// <summary>
        /// Angles the p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The float</returns>
        private float Angle(Point p)
        {
            Point a = p.Next - p;
            Point b = p.Prev - p;
            return (float) Math.Atan2(a.Cross(b), a.Dot(b));
        }

        /// <summary>
        /// Describes whether this instance angle sign
        /// </summary>
        /// <returns>The bool</returns>
        private bool AngleSign()
        {
            Point a = _head.Next - _head;
            Point b = _tail - _head;
            return Math.Atan2(a.Cross(b), a.Dot(b)) >= 0;
        }

        // Determines if the inslide angle is convex or reflex
        /// <summary>
        /// Describes whether this instance is convex
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        private bool IsConvex(Point p)
        {
            if (_positive != Angle(p) >= 0)
                return false;
            return true;
        }
    }
}