// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Path.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common
{
    //Contributed by Matthew Bettcher

    /// <summary>
    ///     Represents a path defined by a collection of control points that form a Catmull-Rom spline curve.
    ///     Provides interpolation, subdivision, and geometric manipulation (translation, rotation, scaling)
    ///     of the control point sequence. Supports both open and closed (looped) paths.
    /// </summary>
    /// <remarks>
    ///     Contributed by Matthew Bettcher. Paths are commonly used for defining motion trajectories,
    ///     camera paths, and AI waypoint systems in game development.
    /// </remarks>
    public class Path
    {
        /// <summary>
        ///     The list of control points that define the Catmull-Rom spline curve.
        ///     The curve passes through these points with C1 continuity.
        /// </summary>
        public List<Vector2F> ControlPoints;

        /// <summary>
        ///     The delta
        /// </summary>
        internal float _deltaT;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        public Path() => ControlPoints = new List<Vector2F>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="vertices">The vertices to created the path from.</param>
        public Path(Vector2F[] vertices)
        {
            ControlPoints = new List<Vector2F>(vertices.Length);

            for (int i = 0; i < vertices.Length; i++)
            {
                Add(vertices[i]);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Path" /> class.
        /// </summary>
        /// <param name="vertices">The vertices to created the path from.</param>
        public Path(IList<Vector2F> vertices)
        {
            ControlPoints = new List<Vector2F>(vertices.Count);
            for (int i = 0; i < vertices.Count; i++)
            {
                Add(vertices[i]);
            }
        }

        /// <summary>
        ///     True if the curve is closed.
        /// </summary>
        /// <value><c>true</c> if closed; otherwise, <c>false</c>.</value>
        public bool Closed { get; set; }

        /// <summary>
        ///     Gets the next index in the control point list with wrap-around.
        ///     Useful for iterating edges between consecutive control points.
        /// </summary>
        /// <param name="index">The current index.</param>
        /// <returns>The next index, wrapping to 0 at the end of the list.</returns>
        public int NextIndex(int index)
        {
            if (index == ControlPoints.Count - 1)
            {
                return 0;
            }

            return index + 1;
        }

        /// <summary>
        ///     Gets the previous index in the control point list with wrap-around.
        /// </summary>
        /// <param name="index">The current index.</param>
        /// <returns>The previous index, wrapping to the last element at index 0.</returns>
        public int PreviousIndex(int index)
        {
            if (index == 0)
            {
                return ControlPoints.Count - 1;
            }

            return index - 1;
        }

        /// <summary>
        ///     Translates the control points by the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        public void Translate(ref Vector2F vector)
        {
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                ControlPoints[i] = ControlPoints[i] + vector;
            }
        }

        /// <summary>
        ///     Scales the control points by the specified vector.
        /// </summary>
        /// <param name="value">The Value.</param>
        public void Scale(ref Vector2F value)
        {
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                ControlPoints[i] = ControlPoints[i] * value;
            }
        }

        /// <summary>
        ///     Rotate the control points by the defined value in radians.
        /// </summary>
        /// <param name="value">The amount to rotate by in radians.</param>
        public void Rotate(float value)
        {
            Complex rotation = Complex.FromAngle(value);

            for (int i = 0; i < ControlPoints.Count; i++)
            {
                ControlPoints[i] = Complex.Multiply(ControlPoints[i], ref rotation);
            }
        }

        /// <summary>
        ///     Returns a string representation of all control points in the path, separated by spaces.
        /// </summary>
        /// <returns>A string containing all control point coordinates.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                builder.Append(ControlPoints[i].ToString());
                if (i < ControlPoints.Count - 1)
                {
                    builder.Append(" ");
                }
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Generates a set of vertices by sampling the Catmull-Rom curve at regular intervals.
        ///     The number of sample points equals the number of divisions per segment.
        /// </summary>
        /// <param name="divisions">Number of divisions (sample points) between each pair of control points.</param>
        /// <returns>A <see cref="Vertices"/> collection containing the interpolated curve points.</returns>
        public Vertices GetVertices(int divisions)
        {
            Vertices verts = new Vertices();

            float timeStep = 1f / divisions;

            for (float i = 0; i < 1f; i += timeStep)
            {
                verts.Add(GetPosition(i));
            }

            return verts;
        }

        /// <summary>
        ///     Computes the interpolated position on the Catmull-Rom curve at the specified time parameter.
        ///     Supports both open and closed paths with proper circular indexing for loops.
        /// </summary>
        /// <param name="time">The time parameter in [0, 1], where 0 is the start and 1 is the end of the path.</param>
        /// <exception cref="Exception">Thrown when the path has fewer than 2 control points.</exception>
        /// <returns>The interpolated 2D position on the curve at the given time.</returns>
        public Vector2F GetPosition(float time)
        {
            Vector2F temp;

            if (ControlPoints.Count < 2)
            {
                throw new Exception("You need at least 2 control points to calculate a position.");
            }

            if (Closed)
            {
                Add(ControlPoints[0]);

                _deltaT = 1f / (ControlPoints.Count - 1);

                int p = (int) (time / _deltaT);

                // use a circular indexing system
                int p0 = p - 1;
                if (p0 < 0)
                {
                    p0 = p0 + (ControlPoints.Count - 1);
                }
                else if (p0 >= ControlPoints.Count - 1)
                {
                    p0 = p0 - (ControlPoints.Count - 1);
                }

                int p1 = p;
                if (p1 < 0)
                {
                    p1 = p1 + (ControlPoints.Count - 1);
                }
                else if (p1 >= ControlPoints.Count - 1)
                {
                    p1 = p1 - (ControlPoints.Count - 1);
                }

                int p2 = p + 1;
                if (p2 < 0)
                {
                    p2 = p2 + (ControlPoints.Count - 1);
                }
                else if (p2 >= ControlPoints.Count - 1)
                {
                    p2 = p2 - (ControlPoints.Count - 1);
                }

                int p3 = p + 2;
                if (p3 < 0)
                {
                    p3 = p3 + (ControlPoints.Count - 1);
                }
                else if (p3 >= ControlPoints.Count - 1)
                {
                    p3 = p3 - (ControlPoints.Count - 1);
                }

                // relative time
                float lt = (time - _deltaT * p) / _deltaT;

                CalcCatmullRom(ControlPoints[p0], ControlPoints[p1], ControlPoints[p2], ControlPoints[p3], lt, out temp);

                RemoveAt(ControlPoints.Count - 1);
            }
            else
            {
                int p = (int) (time / _deltaT);

                // 
                int p0 = p - 1;
                if (p0 < 0)
                {
                    p0 = 0;
                }
                else if (p0 >= ControlPoints.Count - 1)
                {
                    p0 = ControlPoints.Count - 1;
                }

                int p1 = p;
                if (p1 < 0)
                {
                    p1 = 0;
                }
                else if (p1 >= ControlPoints.Count - 1)
                {
                    p1 = ControlPoints.Count - 1;
                }

                int p2 = p + 1;
                if (p2 < 0)
                {
                    p2 = 0;
                }
                else if (p2 >= ControlPoints.Count - 1)
                {
                    p2 = ControlPoints.Count - 1;
                }

                int p3 = p + 2;
                if (p3 < 0)
                {
                    p3 = 0;
                }
                else if (p3 >= ControlPoints.Count - 1)
                {
                    p3 = ControlPoints.Count - 1;
                }

                // relative time
                float lt = (time - _deltaT * p) / _deltaT;

                CalcCatmullRom(ControlPoints[p0], ControlPoints[p1], ControlPoints[p2], ControlPoints[p3], lt, out temp);
            }

            return temp;
        }

        /// <summary>
        ///     Computes a point on a Catmull-Rom spline given four control points and an interpolation amount.
        ///     The spline passes through p1 and p2 with C1 continuity, using p0 and p3 for tangent calculation.
        /// </summary>
        /// <param name="p0">The first control point (used for tangent calculation at p1).</param>
        /// <param name="p1">The second control point (start of the segment).</param>
        /// <param name="p2">The third control point (end of the segment).</param>
        /// <param name="p3">The fourth control point (used for tangent calculation at p2).</param>
        /// <param name="amount">The interpolation parameter in [0, 1], where 0 returns p1 and 1 returns p2.</param>
        /// <param name="result">The interpolated point on the Catmull-Rom curve.</param>
        internal void CalcCatmullRom(Vector2F p0, Vector2F p1, Vector2F p2, Vector2F p3, float amount, out Vector2F result)
        {
            double sqAmount = amount * amount;
            double cuAmount = sqAmount * amount;

            double x;
            double y;
            x = 2.0 * p1.X;
            y = 2.0 * p1.Y;
            x += (p2.X - p0.X) * amount;
            y += (p2.Y - p0.Y) * amount;
            x += (2.0 * p0.X - 5.0 * p1.X + 4.0 * p2.X - p3.X) * sqAmount;
            y += (2.0 * p0.Y - 5.0 * p1.Y + 4.0 * p2.Y - p3.Y) * sqAmount;
            x += (3.0 * p1.X - p0.X - 3.0 * p2.X + p3.X) * cuAmount;
            y += (3.0 * p1.Y - p0.Y - 3.0 * p2.Y + p3.Y) * cuAmount;
            x *= 0.5;
            y *= 0.5;

            result = new Vector2F((float) x, (float) y);
        }

        /// <summary>
        ///     Computes the normal (perpendicular direction) of the curve at the given time parameter.
        ///     The normal is obtained by sampling the curve at slightly offset times and computing
        ///     the perpendicular of the resulting direction vector.
        /// </summary>
        /// <param name="time">The time parameter in [0, 1] at which to compute the normal.</param>
        /// <returns>A normalized 2D vector perpendicular to the curve tangent at the given time.</returns>
        public Vector2F GetPositionNormal(float time)
        {
            float offsetTime = time + 0.0001f;

            Vector2F a = GetPosition(time);
            Vector2F b = GetPosition(offsetTime);

            Vector2F output;

            Vector2F.Subtract(ref a, ref b, out Vector2F temp);

            output = new Vector2F(temp.Y, -temp.X);

            output.Normalize();

            return output;
        }

        /// <summary>
        ///     Adds a control point to the end of the path and recalculates the time delta.
        /// </summary>
        /// <param name="point">The control point to add.</param>
        public void Add(Vector2F point)
        {
            ControlPoints.Add(point);
            _deltaT = 1f / (ControlPoints.Count - 1);
        }

        /// <summary>
        ///     Removes the first occurrence of the specified control point and recalculates the time delta.
        /// </summary>
        /// <param name="point">The control point to remove.</param>
        public void Remove(Vector2F point)
        {
            ControlPoints.Remove(point);
            _deltaT = 1f / (ControlPoints.Count - 1);
        }

        /// <summary>
        ///     Removes the control point at the specified index and recalculates the time delta.
        /// </summary>
        /// <param name="index">The zero-based index of the control point to remove.</param>
        public void RemoveAt(int index)
        {
            ControlPoints.RemoveAt(index);
            _deltaT = 1f / (ControlPoints.Count - 1);
        }

        /// <summary>
        ///     Computes the approximate total arc length of the path by sampling at 25 points per control point segment.
        ///     Includes closing segment length for closed paths.
        /// </summary>
        /// <returns>The approximate total arc length of the curve.</returns>
        public float GetLength()
        {
            List<Vector2F> verts = GetVertices(ControlPoints.Count * 25);
            float length = 0;

            for (int i = 1; i < verts.Count; i++)
            {
                length += Vector2F.Distance(verts[i - 1], verts[i]);
            }

            if (Closed)
            {
                length += Vector2F.Distance(verts[ControlPoints.Count - 1], verts[0]);
            }

            return length;
        }

        /// <summary>
        ///     Evenly subdivides the path into the specified number of segments, returning points
        ///     at approximately equal arc-length intervals along the curve. Each point includes
        ///     the position and the tangent angle.
        /// </summary>
        /// <param name="divisions">The number of even subdivisions to create along the path.</param>
        /// <returns>A list of 3D vectors where X and Y are the position and Z is the tangent angle in radians.</returns>
        public List<Vector3F> SubdivideEvenly(int divisions)
        {
            List<Vector3F> verts = new List<Vector3F>();

            float length = GetLength();

            float deltaLength = length / divisions + 0.001f;
            float t = 0.000f;

            // we always start at the first control point
            Vector2F start = ControlPoints[0];
            Vector2F end = GetPosition(t);

            // increment t until we are at half the distance
            while (deltaLength * 0.5f >= Vector2F.Distance(start, end))
            {
                end = GetPosition(t);
                t += 0.0001f;

                if (t >= 1f)
                {
                    break;
                }
            }

            start = end;

            // for each box
            for (int i = 1; i < divisions; i++)
            {
                Vector2F normal = GetPositionNormal(t);
                float angle = (float) Math.Atan2(normal.Y, normal.X);

                verts.Add(new Vector3F(end.X, end.Y, angle));

                // until we reach the correct distance down the curve
                while (deltaLength >= Vector2F.Distance(start, end))
                {
                    end = GetPosition(t);
                    t += 0.00001f;

                    if (t >= 1f)
                    {
                        break;
                    }
                }

                if (t >= 1f)
                {
                    break;
                }

                start = end;
            }

            return verts;
        }
    }
}