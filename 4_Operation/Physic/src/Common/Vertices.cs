// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vertices.cs
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     The vertices class
    /// </summary>
    /// <seealso cref="List{Vector2F}" />
    [DebuggerDisplay("Count = {Count} Vertices = {ToString()}")]
    public class Vertices : List<Vector2F>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Vertices" /> class
        /// </summary>
        public Vertices()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Vertices" /> class
        /// </summary>
        /// <param name="capacity">The capacity</param>
        public Vertices(int capacity) : base(capacity)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Vertices" /> class
        /// </summary>
        /// <param name="vertices">The vertices</param>
        public Vertices(IEnumerable<Vector2F> vertices)
        {
            AddRange(vertices);
        }

        /// <summary>
        ///     Gets or sets the value of the attached to body
        /// </summary>
        internal bool AttachedToBody { get; set; }

        /// <summary>
        ///     You can add holes to this collection.
        ///     It will get respected by some of the triangulation algoithms, but otherwise not used.
        /// </summary>
        public List<Vertices> Holes { get; set; }

        /// <summary>
        ///     Gets the next index. Used for iterating all the edges with wrap-around.
        /// </summary>
        /// <param name="index">The current index</param>
        public int NextIndex(int index) => index + 1 > Count - 1 ? 0 : index + 1;

        /// <summary>
        ///     Gets the next vertex. Used for iterating all the edges with wrap-around.
        /// </summary>
        /// <param name="index">The current index</param>
        public Vector2F NextVertex(int index) => this[NextIndex(index)];

        /// <summary>
        ///     Gets the previous index. Used for iterating all the edges with wrap-around.
        /// </summary>
        /// <param name="index">The current index</param>
        public int PreviousIndex(int index) => index - 1 < 0 ? Count - 1 : index - 1;

        /// <summary>
        ///     Gets the previous vertex. Used for iterating all the edges with wrap-around.
        /// </summary>
        /// <param name="index">The current index</param>
        public Vector2F PreviousVertex(int index) => this[PreviousIndex(index)];

        /// <summary>
        ///     Gets the signed area.
        ///     If the area is less than 0, it indicates that the polygon is clockwise winded.
        /// </summary>
        /// <returns>The signed area</returns>
        public float GetSignedArea()
        {
            //The simplest polygon which can exist in the Euclidean plane has 3 sides.
            if (Count < 3)
            {
                return 0;
            }

            int i;
            float area = 0;

            for (i = 0; i < Count; i++)
            {
                int j = (i + 1) % Count;

                Vector2F vi = this[i];
                Vector2F vj = this[j];

                area += vi.X * vj.Y;
                area -= vi.Y * vj.X;
            }

            area /= 2.0f;
            return area;
        }

        /// <summary>
        ///     Gets the area.
        /// </summary>
        /// <returns></returns>
        public float GetArea()
        {
            float area = GetSignedArea();
            return area < 0 ? -area : area;
        }

        /// <summary>
        ///     Gets the centroid.
        /// </summary>
        /// <returns></returns>
        public Vector2F GetCentroid()
        {
            //The simplest polygon which can exist in the Euclidean plane has 3 sides.
            if (Count < 3)
            {
                return new Vector2F(float.NaN, float.NaN);
            }

            // Same algorithm is used by Box2D
            Vector2F c = Vector2F.Zero;
            float area = 0.0f;
            const float inv3 = 1.0f / 3.0f;

            for (int i = 0; i < Count; ++i)
            {
                // Triangle vertices.
                Vector2F current = this[i];
                Vector2F next = i + 1 < Count ? this[i + 1] : this[0];

                float triangleArea = 0.5f * (current.X * next.Y - current.Y * next.X);
                area += triangleArea;

                // Area weighted centroid
                c += triangleArea * inv3 * (current + next);
            }

            // Centroid
            c *= 1.0f / area;
            return c;
        }

        /// <summary>
        ///     Returns an AABB that fully contains this polygon.
        /// </summary>
        public Aabb GetAabb()
        {
            Aabb aabb;
            Vector2F lowerBound = new Vector2F(float.MaxValue, float.MaxValue);
            Vector2F upperBound = new Vector2F(float.MinValue, float.MinValue);

            for (int i = 0; i < Count; ++i)
            {
                if (this[i].X < lowerBound.X)
                {
                    lowerBound.X = this[i].X;
                }

                if (this[i].X > upperBound.X)
                {
                    upperBound.X = this[i].X;
                }

                if (this[i].Y < lowerBound.Y)
                {
                    lowerBound.Y = this[i].Y;
                }

                if (this[i].Y > upperBound.Y)
                {
                    upperBound.Y = this[i].Y;
                }
            }

            aabb.LowerBound = lowerBound;
            aabb.UpperBound = upperBound;

            return aabb;
        }

        /// <summary>
        ///     Translates the vertices with the specified vector.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Translate(Vector2F value)
        {
            Translate(ref value);
        }

        /// <summary>
        ///     Translates the vertices with the specified vector.
        /// </summary>
        /// <param name="value">The vector.</param>
        public void Translate(ref Vector2F value)
        {
            Debug.Assert(!AttachedToBody, "Translating vertices that are used by a Body can result in unstable behavior. Use Body.Position instead.");

            for (int i = 0; i < Count; i++)
            {
                this[i] = this[i] + value;
            }

            if ((Holes != null) && (Holes.Count > 0))
            {
                foreach (Vertices hole in Holes)
                {
                    hole.Translate(ref value);
                }
            }
        }

        /// <summary>
        ///     Scales the vertices with the specified vector.
        /// </summary>
        /// <param name="value">The Value.</param>
        public void Scale(Vector2F value)
        {
            Scale(ref value);
        }

        /// <summary>
        ///     Scales the vertices with the specified vector.
        /// </summary>
        /// <param name="value">The Value.</param>
        public void Scale(ref Vector2F value)
        {
            Debug.Assert(!AttachedToBody, "Scaling vertices that are used by a Body can result in unstable behavior.");

            for (int i = 0; i < Count; i++)
            {
                this[i] = this[i] * value;
            }

            if ((Holes != null) && (Holes.Count > 0))
            {
                foreach (Vertices hole in Holes)
                {
                    hole.Scale(ref value);
                }
            }
        }

        /// <summary>
        ///     Rotate the vertices with the defined value in radians.
        ///     Warning: Using this method on an active set of vertices of a Body,
        ///     will cause problems with collisions. Use Body.Rotation instead.
        /// </summary>
        /// <param name="value">The amount to rotate by in radians.</param>
        public void Rotate(float value)
        {
            Debug.Assert(!AttachedToBody, "Rotating vertices that are used by a Body can result in unstable behavior.");

            float num1 = (float) Math.Cos(value);
            float num2 = (float) Math.Sin(value);

            for (int i = 0; i < Count; i++)
            {
                Vector2F position = this[i];
                this[i] = new Vector2F(position.X * num1 + position.Y * -num2, position.X * num2 + position.Y * num1);
            }

            if ((Holes != null) && (Holes.Count > 0))
            {
                foreach (Vertices hole in Holes)
                {
                    hole.Rotate(value);
                }
            }
        }

        /// <summary>
        ///     Determines whether the polygon is convex.
        ///     O(n^2) running time.
        ///     Assumptions:
        ///     - The polygon is in counter clockwise order
        ///     - The polygon has no overlapping edges
        /// </summary>
        /// <returns>
        ///     <c>true</c> if it is convex; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConvex()
        {
            //The simplest polygon which can exist in the Euclidean plane has 3 sides.
            if (Count < 3)
            {
                return false;
            }

            //Triangles are always convex
            if (Count == 3)
            {
                return true;
            }

            // Checks the polygon is convex and the interior is to the left of each edge.
            for (int i = 0; i < Count; ++i)
            {
                int next = i + 1 < Count ? i + 1 : 0;
                Vector2F edge = this[next] - this[i];

                for (int j = 0; j < Count; ++j)
                {
                    // Don't check vertices on the current edge.
                    if (j == i || j == next)
                    {
                        continue;
                    }

                    Vector2F r = this[j] - this[i];

                    float s = edge.X * r.Y - edge.Y * r.X;

                    if (s <= 0.0f)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///     Indicates if the vertices are in counter clockwise order.
        ///     Warning: If the area of the polygon is 0, it is unable to determine the winding.
        /// </summary>
        public bool IsCounterClockWise()
        {
            //The simplest polygon which can exist in the Euclidean plane has 3 sides.
            if (Count < 3)
            {
                return false;
            }

            return GetSignedArea() > 0.0f;
        }

        /// <summary>
        ///     Forces the vertices to be counter clock wise order.
        /// </summary>
        public void ForceCounterClockWise()
        {
            //The simplest polygon which can exist in the Euclidean plane has 3 sides.
            if (Count < 3)
            {
                return;
            }

            if (!IsCounterClockWise())
            {
                Reverse();
            }
        }

        /// <summary>
        ///     Checks if the vertices forms an simple polygon by checking for edge crossings.
        /// </summary>
        public bool IsSimple()
        {
            //The simplest polygon which can exist in the Euclidean plane has 3 sides.
            if (Count < 3)
            {
                return false;
            }

            for (int i = 0; i < Count; ++i)
            {
                Vector2F a1 = this[i];
                Vector2F a2 = NextVertex(i);
                for (int j = i + 1; j < Count; ++j)
                {
                    Vector2F b1 = this[j];
                    Vector2F b2 = NextVertex(j);

                    if (LineTools.LineIntersect2(ref a1, ref a2, ref b1, ref b2, out Vector2F _))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///     Checks if the polygon is valid for use in the engine.
        ///     Performs a full check, for simplicity, convexity,
        ///     orientation, minimum angle, and volume.
        ///     From Eric Jordan's convex decomposition library
        /// </summary>
        /// <returns>PolygonError.NoError if there were no error.</returns>
        public PolygonError CheckPolygon()
        {
            if (Count < 3 || Count > SettingEnv.MaxPolygonVertices)
            {
                return PolygonError.InvalidAmountOfVertices;
            }

            if (!IsSimple())
            {
                return PolygonError.NotSimple;
            }

            if (GetArea() <= SettingEnv.Epsilon)
            {
                return PolygonError.AreaTooSmall;
            }

            if (!IsConvex())
            {
                return PolygonError.NotConvex;
            }

            //Check if the sides are of adequate length.
            for (int i = 0; i < Count; ++i)
            {
                int next = i + 1 < Count ? i + 1 : 0;
                Vector2F edge = this[next] - this[i];
                if (edge.LengthSquared() <= SettingEnv.Epsilon * SettingEnv.Epsilon)
                {
                    return PolygonError.SideTooSmall;
                }
            }

            if (!IsCounterClockWise())
            {
                return PolygonError.NotCounterClockWise;
            }

            return PolygonError.NoError;
        }

        /// <summary>
        ///     Projects to axis.
        /// </summary>
        /// <param name="axis">The axis.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        public void ProjectToAxis(ref Vector2F axis, out float min, out float max)
        {
            // To project a point on an axis use the dot product
            float dotProduct = Vector2F.Dot(axis, this[0]);
            min = dotProduct;
            max = dotProduct;

            for (int i = 0; i < Count; i++)
            {
                dotProduct = Vector2F.Dot(this[i], axis);
                if (dotProduct < min)
                {
                    min = dotProduct;
                }
                else
                {
                    if (dotProduct > max)
                    {
                        max = dotProduct;
                    }
                }
            }
        }

        /// <summary>
        ///     Winding number test for a point in a polygon.
        /// </summary>
        /// See more info about the algorithm here: http://softsurfer.com/Archive/algorithm_0103/algorithm_0103.htm
        /// <param name="point">The point to be tested.</param>
        /// <returns>
        ///     -1 if the winding number is zero and the point is outside
        ///     the polygon, 1 if the point is inside the polygon, and 0 if the point
        ///     is on the polygons edge.
        /// </returns>
        public int PointInPolygon(ref Vector2F point)
        {
            // Winding number
            int wn = 0;

            // Iterate through polygon's edges
            for (int i = 0; i < Count; i++)
            {
                // Get points
                Vector2F p1 = this[i];
                Vector2F p2 = this[NextIndex(i)];

                // Test if a point is directly on the edge
                Vector2F edge = p2 - p1;
                float area = MathUtils.Area(ref p1, ref p2, ref point);
                if ((Math.Abs(area) < float.Epsilon) && (Vector2F.Dot(point - p1, edge) >= 0f) && (Vector2F.Dot(point - p2, edge) <= 0f))
                {
                    return 0;
                }

                // Test edge for intersection with ray from point
                if (p1.Y <= point.Y)
                {
                    if ((p2.Y > point.Y) && (area > 0f))
                    {
                        ++wn;
                    }
                }
                else
                {
                    if ((p2.Y <= point.Y) && (area < 0f))
                    {
                        --wn;
                    }
                }
            }

            return wn == 0 ? -1 : 1;
        }

        /// <summary>
        ///     Compute the sum of the angles made between the test point and each pair of points making up the polygon.
        ///     If this sum is 2pi then the point is an interior point, if 0 then the point is an exterior point.
        ///     ref: http://ozviz.wasp.uwa.edu.au/~pbourke/geometry/insidepoly/  - Solution 2
        /// </summary>
        public bool PointInPolygonAngle(ref Vector2F point)
        {
            double angle = 0;

            // Iterate through polygon's edges
            for (int i = 0; i < Count; i++)
            {
                // Get points
                Vector2F p1 = this[i] - point;
                Vector2F p2 = this[NextIndex(i)] - point;

                angle += MathUtils.VectorAngle(ref p1, ref p2);
            }

            if (Math.Abs(angle) < Math.PI)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                builder.Append(this[i].ToString());
                if (i < Count - 1)
                {
                    builder.Append(" ");
                }
            }

            return builder.ToString();
        }
    }
}