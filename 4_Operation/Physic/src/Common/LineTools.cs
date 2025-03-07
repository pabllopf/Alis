// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LineTools.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     Collection of helper methods for misc collisions.
    ///     Does float tolerance and line collisions with lines and AABBs.
    /// </summary>
    public static class LineTools
    {
        /// <summary>
        ///     Distances the between point and line segment using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <returns>The float</returns>
        public static float DistanceBetweenPointAndLineSegment(ref Vector2F point, ref Vector2F start, ref Vector2F end)
        {
            if (start == end)
            {
                return Vector2F.Distance(point, start);
            }

            Vector2F v = end - start;
            Vector2F w = point - start;

            float c1 = Vector2F.Dot(w, v);
            if (c1 <= 0)
            {
                return Vector2F.Distance(point, start);
            }

            float c2 = Vector2F.Dot(v, v);
            if (c2 <= c1)
            {
                return Vector2F.Distance(point, end);
            }

            float b = c1 / c2;
            Vector2F pointOnLine = start + v * b;
            return Vector2F.Distance(point, pointOnLine);
        }

        // From Eric Jordan's convex decomposition library
        /// <summary>
        ///     Check if the lines a0->a1 and b0->b1 cross.
        ///     If they do, intersectionPoint will be filled
        ///     with the point of crossing.
        ///     Grazing lines should not return true.
        /// </summary>
        public static bool LineIntersect2(ref Vector2F a0, ref Vector2F a1, ref Vector2F b0, ref Vector2F b1, out Vector2F intersectionPoint)
        {
            intersectionPoint = Vector2F.Zero;

            if (a0 == b0 || a0 == b1 || a1 == b0 || a1 == b1)
            {
                return false;
            }

            float x1 = a0.X;
            float y1 = a0.Y;
            float x2 = a1.X;
            float y2 = a1.Y;
            float x3 = b0.X;
            float y3 = b0.Y;
            float x4 = b1.X;
            float y4 = b1.Y;

            //AABB early exit
            if (Math.Max(x1, x2) < Math.Min(x3, x4) || Math.Max(x3, x4) < Math.Min(x1, x2))
            {
                return false;
            }

            if (Math.Max(y1, y2) < Math.Min(y3, y4) || Math.Max(y3, y4) < Math.Min(y1, y2))
            {
                return false;
            }

            float ua = (x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3);
            float ub = (x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3);
            float denom = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
            if (Math.Abs(denom) < SettingEnv.Epsilon)
            {
                //Lines are too close to parallel to call
                return false;
            }

            ua /= denom;
            ub /= denom;

            if ((0 < ua) && (ua < 1) && (0 < ub) && (ub < 1))
            {
                intersectionPoint.X = x1 + ua * (x2 - x1);
                intersectionPoint.Y = y1 + ua * (y2 - y1);
                return true;
            }

            return false;
        }

        //From Mark Bayazit's convex decomposition algorithm
        /// <summary>
        ///     Lines the intersect using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="q1">The </param>
        /// <param name="q2">The </param>
        /// <returns>The </returns>
        public static Vector2F LineIntersect(Vector2F p1, Vector2F p2, Vector2F q1, Vector2F q2)
        {
            Vector2F i = Vector2F.Zero;
            float a1 = p2.Y - p1.Y;
            float b1 = p1.X - p2.X;
            float c1 = a1 * p1.X + b1 * p1.Y;
            float a2 = q2.Y - q1.Y;
            float b2 = q1.X - q2.X;
            float c2 = a2 * q1.X + b2 * q1.Y;
            float det = a1 * b2 - a2 * b1;

            if (!MathUtils.FloatEquals(det, 0))
            {
                // lines are not parallel
                i.X = (b2 * c1 - b1 * c2) / det;
                i.Y = (a1 * c2 - a2 * c1) / det;
            }

            return i;
        }

        /// <summary>
        ///     This method detects if two line segments (or lines) intersect,
        ///     and, if so, the point of intersection. Use the <paramref name="firstIsSegment" /> and
        ///     <paramref name="secondIsSegment" /> parameters to set whether the intersection point
        ///     must be on the first and second line segments. Setting these
        ///     both to true means you are doing a line-segment to line-segment
        ///     intersection. Setting one of them to true means you are doing a
        ///     line to line-segment intersection test, and so on.
        ///     Note: If two line segments are coincident, then
        ///     no intersection is detected (there are actually
        ///     infinite intersection points).
        ///     Author: Jeremy Bell
        /// </summary>
        /// <param name="point1">The first point of the first line segment.</param>
        /// <param name="point2">The second point of the first line segment.</param>
        /// <param name="point3">The first point of the second line segment.</param>
        /// <param name="point4">The second point of the second line segment.</param>
        /// <param name="point">
        ///     This is set to the intersection
        ///     point if an intersection is detected.
        /// </param>
        /// <param name="firstIsSegment">
        ///     Set this to true to require that the
        ///     intersection point be on the first line segment.
        /// </param>
        /// <param name="secondIsSegment">
        ///     Set this to true to require that the
        ///     intersection point be on the second line segment.
        /// </param>
        /// <returns>True if an intersection is detected, false otherwise.</returns>
        public static bool LineIntersect(ref Vector2F point1, ref Vector2F point2, ref Vector2F point3, ref Vector2F point4, bool firstIsSegment, bool secondIsSegment, out Vector2F point)
        {
            point = new Vector2F();

            // these are reused later.
            // each lettered sub-calculation is used twice, except
            // for b and d, which are used 3 times
            float a = point4.Y - point3.Y;
            float b = point2.X - point1.X;
            float c = point4.X - point3.X;
            float d = point2.Y - point1.Y;

            // denominator to solution of linear system
            float denom = a * b - c * d;

            // if denominator is 0, then lines are parallel
            if (!((denom >= -SettingEnv.Epsilon) && (denom <= SettingEnv.Epsilon)))
            {
                float e = point1.Y - point3.Y;
                float f = point1.X - point3.X;
                float oneOverDenom = 1.0f / denom;

                // numerator of first equation
                float ua = c * e - a * f;
                ua *= oneOverDenom;

                // check if intersection point of the two lines is on line segment 1
                if (!firstIsSegment || ((ua >= 0.0f) && (ua <= 1.0f)))
                {
                    // numerator of second equation
                    float ub = b * e - d * f;
                    ub *= oneOverDenom;

                    // check if intersection point of the two lines is on line segment 2
                    // means the line segments intersect, since we know it is on
                    // segment 1 as well.
                    if (!secondIsSegment || ((ub >= 0.0f) && (ub <= 1.0f)))
                    {
                        // check if they are coincident (no collision in this case)
                        if ((Math.Abs(ua) > SettingEnv.Epsilon) && (Math.Abs(ub) > SettingEnv.Epsilon))
                        {
                            //There is an intersection
                            point.X = point1.X + ua * b;
                            point.Y = point1.Y + ua * d;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     This method detects if two line segments (or lines) intersect,
        ///     and, if so, the point of intersection. Use the <paramref name="firstIsSegment" /> and
        ///     <paramref name="secondIsSegment" /> parameters to set whether the intersection point
        ///     must be on the first and second line segments. Setting these
        ///     both to true means you are doing a line-segment to line-segment
        ///     intersection. Setting one of them to true means you are doing a
        ///     line to line-segment intersection test, and so on.
        ///     Note: If two line segments are coincident, then
        ///     no intersection is detected (there are actually
        ///     infinite intersection points).
        ///     Author: Jeremy Bell
        /// </summary>
        /// <param name="point1">The first point of the first line segment.</param>
        /// <param name="point2">The second point of the first line segment.</param>
        /// <param name="point3">The first point of the second line segment.</param>
        /// <param name="point4">The second point of the second line segment.</param>
        /// <param name="intersectionPoint">
        ///     This is set to the intersection
        ///     point if an intersection is detected.
        /// </param>
        /// <param name="firstIsSegment">
        ///     Set this to true to require that the
        ///     intersection point be on the first line segment.
        /// </param>
        /// <param name="secondIsSegment">
        ///     Set this to true to require that the
        ///     intersection point be on the second line segment.
        /// </param>
        /// <returns>True if an intersection is detected, false otherwise.</returns>
        public static bool LineIntersect(Vector2F point1, Vector2F point2, Vector2F point3, Vector2F point4, bool firstIsSegment, bool secondIsSegment, out Vector2F intersectionPoint) => LineIntersect(ref point1, ref point2, ref point3, ref point4, firstIsSegment, secondIsSegment, out intersectionPoint);

        /// <summary>
        ///     This method detects if two line segments intersect,
        ///     and, if so, the point of intersection.
        ///     Note: If two line segments are coincident, then
        ///     no intersection is detected (there are actually
        ///     infinite intersection points).
        /// </summary>
        /// <param name="point1">The first point of the first line segment.</param>
        /// <param name="point2">The second point of the first line segment.</param>
        /// <param name="point3">The first point of the second line segment.</param>
        /// <param name="point4">The second point of the second line segment.</param>
        /// <param name="intersectionPoint">
        ///     This is set to the intersection
        ///     point if an intersection is detected.
        /// </param>
        /// <returns>True if an intersection is detected, false otherwise.</returns>
        public static bool LineIntersect(ref Vector2F point1, ref Vector2F point2, ref Vector2F point3, ref Vector2F point4, out Vector2F intersectionPoint) => LineIntersect(ref point1, ref point2, ref point3, ref point4, true, true, out intersectionPoint);

        /// <summary>
        ///     This method detects if two line segments intersect,
        ///     and, if so, the point of intersection.
        ///     Note: If two line segments are coincident, then
        ///     no intersection is detected (there are actually
        ///     infinite intersection points).
        /// </summary>
        /// <param name="point1">The first point of the first line segment.</param>
        /// <param name="point2">The second point of the first line segment.</param>
        /// <param name="point3">The first point of the second line segment.</param>
        /// <param name="point4">The second point of the second line segment.</param>
        /// <param name="intersectionPoint">
        ///     This is set to the intersection
        ///     point if an intersection is detected.
        /// </param>
        /// <returns>True if an intersection is detected, false otherwise.</returns>
        public static bool LineIntersect(Vector2F point1, Vector2F point2, Vector2F point3, Vector2F point4, out Vector2F intersectionPoint) => LineIntersect(ref point1, ref point2, ref point3, ref point4, true, true, out intersectionPoint);

        /// <summary>
        ///     Get all intersections between a line segment and a list of vertices
        ///     representing a polygon. The vertices reuse adjacent points, so for example
        ///     edges one and two are between the first and second vertices and between the
        ///     second and third vertices. The last edge is between vertex vertices.Count - 1
        ///     and verts0. (ie, vertices from a Geometry or AABB)
        /// </summary>
        /// <param name="point1">The first point of the line segment to test</param>
        /// <param name="point2">The second point of the line segment to test.</param>
        /// <param name="vertices">The vertices, as described above</param>
        public static Vertices LineSegmentVerticesIntersect(ref Vector2F point1, ref Vector2F point2, Vertices vertices)
        {
            Vertices intersectionPoints = new Vertices();

            for (int i = 0; i < vertices.Count; i++)
            {
                if (LineIntersect(vertices[i], vertices[vertices.NextIndex(i)], point1, point2, true, true, out Vector2F point))
                {
                    intersectionPoints.Add(point);
                }
            }

            return intersectionPoints;
        }

        /// <summary>
        ///     Get all intersections between a line segment and an AABB.
        /// </summary>
        /// <param name="point1">The first point of the line segment to test</param>
        /// <param name="point2">The second point of the line segment to test.</param>
        /// <param name="aabb">The AABB that is used for testing intersection.</param>
        public static Vertices LineSegmentAabbIntersect(ref Vector2F point1, ref Vector2F point2, Aabb aabb) => LineSegmentVerticesIntersect(ref point1, ref point2, aabb.Vertices);
    }
}