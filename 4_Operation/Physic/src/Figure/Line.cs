// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Line.cs
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

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Figure
{
    /// <summary>
    ///     The line class
    /// </summary>
    public static class Line
    {
        /// <summary>
        ///     Distances the between point and line segment using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <returns>The float</returns>
        [ExcludeFromCodeCoverage]
        public static float DistanceBetweenPointAndLineSegment(Vector2 point, Vector2 start, Vector2 end)
        {
            if (ArePointsEqual(start, end))
            {
                return CalculateDistance(point, start);
            }
            
            Vector2 v = SubtractVectors(end, start);
            Vector2 w = SubtractVectors(point, start);
            
            float c1 = DotProduct(w, v);
            if (IsC1LessThanOrEqualToZero(c1))
            {
                return CalculateDistance(point, start);
            }
            
            float c2 = DotProduct(v, v);
            if (IsC2LessThanOrEqualToC1(c2, c1))
            {
                return CalculateDistance(point, end);
            }
            
            return CalculateDistanceFromPointToLine(point, start, v, c1, c2);
        }
        
        /// <summary>
        /// Calculates the distance from point to line using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="start">The start</param>
        /// <param name="v">The </param>
        /// <param name="c1">The </param>
        /// <param name="c2">The </param>
        /// <returns>The float</returns>
        private static float CalculateDistanceFromPointToLine(Vector2 point, Vector2 start, Vector2 v, float c1, float c2)
        {
            float b = c1 / c2;
            Vector2 pointOnLine = AddVectors(start, MultiplyVectorByScalar(v, b));
            return CalculateDistance(point, pointOnLine);
        }
        
        /// <summary>
        /// Calculates the distance using the specified point 1
        /// </summary>
        /// <param name="point1">The point</param>
        /// <param name="point2">The point</param>
        /// <returns>The float</returns>
        private static float CalculateDistance(Vector2 point1, Vector2 point2) => Vector2.Distance(point1, point2);
        
        /// <summary>
        /// Subtracts the vectors using the specified vector 1
        /// </summary>
        /// <param name="vector1">The vector</param>
        /// <param name="vector2">The vector</param>
        /// <returns>The vector</returns>
        private static Vector2 SubtractVectors(Vector2 vector1, Vector2 vector2) => vector1 - vector2;
        
        /// <summary>
        /// Dots the product using the specified vector 1
        /// </summary>
        /// <param name="vector1">The vector</param>
        /// <param name="vector2">The vector</param>
        /// <returns>The float</returns>
        private static float DotProduct(Vector2 vector1, Vector2 vector2) => Vector2.Dot(vector1, vector2);
        
        /// <summary>
        /// Describes whether is c 1 less than or equal to zero
        /// </summary>
        /// <param name="c1">The </param>
        /// <returns>The bool</returns>
        private static bool IsC1LessThanOrEqualToZero(float c1) => c1 <= 0;
        
        /// <summary>
        /// Describes whether is c 2 less than or equal to c 1
        /// </summary>
        /// <param name="c2">The </param>
        /// <param name="c1">The </param>
        /// <returns>The bool</returns>
        private static bool IsC2LessThanOrEqualToC1(float c2, float c1) => c2 <= c1;
        
        /// <summary>
        /// Adds the vectors using the specified vector 1
        /// </summary>
        /// <param name="vector1">The vector</param>
        /// <param name="vector2">The vector</param>
        /// <returns>The vector</returns>
        private static Vector2 AddVectors(Vector2 vector1, Vector2 vector2) => vector1 + vector2;
        
        /// <summary>
        /// Multiplies the vector by scalar using the specified vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <param name="scalar">The scalar</param>
        /// <returns>The vector</returns>
        private static Vector2 MultiplyVectorByScalar(Vector2 vector, float scalar) => vector * scalar;
        
        /// <summary>
        ///     Describes whether line intersect 2
        /// </summary>
        /// <param name="a0">The </param>
        /// <param name="a1">The </param>
        /// <param name="b0">The </param>
        /// <param name="b1">The </param>
        /// <param name="intersectionPoint">The intersection point</param>
        /// <returns>The bool</returns>
        [ExcludeFromCodeCoverage]
        public static bool LineIntersect2(Vector2 a0, Vector2 a1, Vector2 b0, Vector2 b1, out Vector2 intersectionPoint)
        {
            intersectionPoint = Vector2.Zero;
            
            if (ArePointsEqual(a0, b0) || ArePointsEqual(a0, b1) || ArePointsEqual(a1, b0) || ArePointsEqual(a1, b1))
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
            
            if (IsOutOfRange(x1, x2, x3, x4) || IsOutOfRange(y1, y2, y3, y4))
            {
                return false;
            }
            
            float denom = CalculateDenominator(y4, y3, x2, x1, x4, x3, y2, y1);
            if (IsDenominatorZero(denom))
            {
                return false;
            }
            
            float ua = CalculateUa(x4, x3, y1, y3, y4, y3, x1, x3, denom);
            float ub = CalculateUb(x2, x1, y1, y3, y2, y1, x1, x3, denom);
            
            if (IsIntersectionValid(ua, ub))
            {
                intersectionPoint = CalculateIntersectionPoint(x1, ua, x2, x1, y1, y2);
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Describes whether are points equal
        /// </summary>
        /// <param name="point1">The point</param>
        /// <param name="point2">The point</param>
        /// <returns>The bool</returns>
        private static bool ArePointsEqual(Vector2 point1, Vector2 point2) => point1 == point2;
        
        /// <summary>
        /// Describes whether is out of range
        /// </summary>
        /// <param name="val1">The val</param>
        /// <param name="val2">The val</param>
        /// <param name="val3">The val</param>
        /// <param name="val4">The val</param>
        /// <returns>The bool</returns>
        private static bool IsOutOfRange(float val1, float val2, float val3, float val4) => CustomMathF.Max(val1, val2) < CustomMathF.Min(val3, val4) || CustomMathF.Max(val3, val4) < CustomMathF.Min(val1, val2);
        
        /// <summary>
        /// Calculates the denominator using the specified val 1
        /// </summary>
        /// <param name="val1">The val</param>
        /// <param name="val2">The val</param>
        /// <param name="val3">The val</param>
        /// <param name="val4">The val</param>
        /// <param name="val5">The val</param>
        /// <param name="val6">The val</param>
        /// <param name="val7">The val</param>
        /// <param name="val8">The val</param>
        /// <returns>The float</returns>
        private static float CalculateDenominator(float val1, float val2, float val3, float val4, float val5, float val6, float val7, float val8) => (val1 - val2) * (val3 - val4) - (val5 - val6) * (val7 - val8);
        
        /// <summary>
        /// Calculates the ua using the specified val 1
        /// </summary>
        /// <param name="val1">The val</param>
        /// <param name="val2">The val</param>
        /// <param name="val3">The val</param>
        /// <param name="val4">The val</param>
        /// <param name="val5">The val</param>
        /// <param name="val6">The val</param>
        /// <param name="val7">The val</param>
        /// <param name="val8">The val</param>
        /// <param name="denom">The denom</param>
        /// <returns>The float</returns>
        private static float CalculateUa(float val1, float val2, float val3, float val4, float val5, float val6, float val7, float val8, float denom) => (val1 - val2) * (val3 - val4) - (val5 - val6) * (val7 - val8) / denom;
        
        /// <summary>
        /// Calculates the ub using the specified val 1
        /// </summary>
        /// <param name="val1">The val</param>
        /// <param name="val2">The val</param>
        /// <param name="val3">The val</param>
        /// <param name="val4">The val</param>
        /// <param name="val5">The val</param>
        /// <param name="val6">The val</param>
        /// <param name="val7">The val</param>
        /// <param name="val8">The val</param>
        /// <param name="denom">The denom</param>
        /// <returns>The float</returns>
        private static float CalculateUb(float val1, float val2, float val3, float val4, float val5, float val6, float val7, float val8, float denom) => (val1 - val2) * (val3 - val4) - (val5 - val6) * (val7 - val8) / denom;
        
        /// <summary>
        /// Describes whether is intersection valid
        /// </summary>
        /// <param name="ua">The ua</param>
        /// <param name="ub">The ub</param>
        /// <returns>The bool</returns>
        private static bool IsIntersectionValid(float ua, float ub) => (ua >= 0) && (ua <= 1) && (ub >= 0) && (ub <= 1);
        
        /// <summary>
        /// Calculates the intersection point using the specified x 1
        /// </summary>
        /// <param name="x1">The </param>
        /// <param name="ua">The ua</param>
        /// <param name="x2">The </param>
        /// <param name="x3">The </param>
        /// <param name="y1">The </param>
        /// <param name="y2">The </param>
        /// <returns>The vector</returns>
        private static Vector2 CalculateIntersectionPoint(float x1, float ua, float x2, float x3, float y1, float y2) => new Vector2(x1 + ua * (x2 - x1), y1 + ua * (y2 - y1));
        
        /// <summary>
        ///     Lines the intersect using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="q1">The </param>
        /// <param name="q2">The </param>
        /// <returns>The </returns>
        public static Vector2 LineIntersect(Vector2 p1, Vector2 p2, Vector2 q1, Vector2 q2)
        {
            Vector2 i = Vector2.Zero;
            float a1 = p2.Y - p1.Y;
            float b1 = p1.X - p2.X;
            float c1 = a1 * p1.X + b1 * p1.Y;
            float a2 = q2.Y - q1.Y;
            float b2 = q1.X - q2.X;
            float c2 = a2 * q1.X + b2 * q1.Y;
            float det = a1 * b2 - a2 * b1;
            
            if (!MathUtils.FloatEquals(det, 0))
            {
                i = new Vector2(
                    (b2 * c1 - b1 * c2) / det,
                    (a1 * c2 - a2 * c1) / det
                );
            }
            
            return i;
        }
        
        /// <summary>
        ///     Describes whether line intersect
        /// </summary>
        /// <param name="point1">The point</param>
        /// <param name="point2">The point</param>
        /// <param name="point3">The point</param>
        /// <param name="point4">The point</param>
        /// <param name="firstIsSegment">The first is segment</param>
        /// <param name="secondIsSegment">The second is segment</param>
        /// <param name="intersectionPoint">The intersection point</param>
        /// <returns>The bool</returns>
        [ExcludeFromCodeCoverage]
        public static bool LineIntersect(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4,
            bool firstIsSegment, bool secondIsSegment, out Vector2 intersectionPoint)
        {
            intersectionPoint = Vector2.Zero;
            
            float a = point4.Y - point3.Y;
            float b = point2.X - point1.X;
            float c = point4.X - point3.X;
            float d = point2.Y - point1.Y;
            
            float denom = a * b - c * d;
            
            if (IsDenominatorZero(denom))
            {
                return false;
            }
            
            float ua = CalculateUa(a, c, d, point1, point3, denom);
            float ub = CalculateUb(b, d, a, point1, point3, denom);
            
            if (!IsInRange(ua, firstIsSegment) || !IsInRange(ub, secondIsSegment))
            {
                return false;
            }
            
            if (HasIntersection(ua, ub))
            {
                intersectionPoint = CalculateIntersectionPoint(point1, ua, b, d);
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Describes whether has intersection
        /// </summary>
        /// <param name="ua">The ua</param>
        /// <param name="ub">The ub</param>
        /// <returns>The bool</returns>
        private static bool HasIntersection(float ua, float ub) => CustomMathF.Abs(ua) >= float.Epsilon || CustomMathF.Abs(ub) >= float.Epsilon;
        
        /// <summary>
        ///     Describes whether is denominator zero
        /// </summary>
        /// <param name="denom">The denom</param>
        /// <returns>The bool</returns>
        private static bool IsDenominatorZero(float denom) => (denom >= -float.Epsilon) && (denom <= float.Epsilon);
        
        /// <summary>
        ///     Calculates the ua using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="point1">The point</param>
        /// <param name="point3">The point</param>
        /// <param name="denom">The denom</param>
        /// <returns>The float</returns>
        private static float CalculateUa(float a, float c, float d, Vector2 point1, Vector2 point3, float denom)
        {
            float e = point1.Y - point3.Y;
            float f = point1.X - point3.X;
            float oneOverDenom = 1.0f / denom;
            
            return c * e - a * f * oneOverDenom;
        }
        
        /// <summary>
        ///     Calculates the ub using the specified b
        /// </summary>
        /// <param name="b">The </param>
        /// <param name="d">The </param>
        /// <param name="a">The </param>
        /// <param name="point1">The point</param>
        /// <param name="point3">The point</param>
        /// <param name="denom">The denom</param>
        /// <returns>The float</returns>
        private static float CalculateUb(float b, float d, float a, Vector2 point1, Vector2 point3, float denom)
        {
            float e = point1.Y - point3.Y;
            float f = point1.X - point3.X;
            float oneOverDenom = 1.0f / denom;
            
            return b * e - d * f * oneOverDenom;
        }
        
        /// <summary>
        ///     Describes whether is in range
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="isSegment">The is segment</param>
        /// <returns>The bool</returns>
        private static bool IsInRange(float value, bool isSegment) => !isSegment || ((value >= 0.0f) && (value <= 1.0f));
        
        /// <summary>
        ///     Calculates the intersection point using the specified point 1
        /// </summary>
        /// <param name="point1">The point</param>
        /// <param name="ua">The ua</param>
        /// <param name="b">The </param>
        /// <param name="d">The </param>
        /// <returns>The vector</returns>
        private static Vector2 CalculateIntersectionPoint(Vector2 point1, float ua, float b, float d) => new Vector2(point1.X + ua * b, point1.Y + ua * d);
        
        
        /// <summary>
        ///     Lines the segment vertices intersect using the specified point 1
        /// </summary>
        /// <param name="point1">The point</param>
        /// <param name="point2">The point</param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The intersection points</returns>
        public static List<Vector2> LineSegmentVerticesIntersect(Vector2 point1, Vector2 point2, List<Vector2> vertices)
        {
            List<Vector2> intersectionPoints = new List<Vector2>();
            
            for (int i = 0; i < vertices.Count; i++)
            {
                if (LineIntersect(vertices[i], vertices[(i + 1) % vertices.Count], point1, point2, true, true, out Vector2 point))
                {
                    intersectionPoints.Add(point);
                }
            }
            
            return intersectionPoints;
        }
        
        /// <summary>
        ///     Lines the segment aabb intersect using the specified point 1
        /// </summary>
        /// <param name="point1">The point</param>
        /// <param name="point2">The point</param>
        /// <param name="aabb">The aabb</param>
        /// <returns>A list of vector 2</returns>
        public static List<Vector2> LineSegmentAabbIntersect(Vector2 point1, Vector2 point2, Aabb aabb) =>
            LineSegmentVerticesIntersect(point1, point2, aabb.Vertices);
    }
}