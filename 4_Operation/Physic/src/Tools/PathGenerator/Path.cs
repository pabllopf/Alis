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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Tools.PathGenerator
{
    //Contributed by Matthew Bettcher

    /// <summary>
    ///     Path: Very similar to Vertices, but this class contains vectors describing control points on a Catmull-Rom
    ///     curve.
    /// </summary>
    public class Path
    {
        /// <summary>All the points that makes up the curve</summary>
        public List<Vector2F> ControlPoints;

        /// <summary>
        ///     The delta
        /// </summary>
        private float deltaT;

        /// <summary>Initializes a new instance of the <see cref="Path" /> class.</summary>
        public Path() => ControlPoints = new List<Vector2F>();

        /// <summary>Initializes a new instance of the <see cref="Path" /> class.</summary>
        /// <param name="vertices">The vertices to created the path from.</param>
        public Path(Vector2F[] vertices)
        {
            ControlPoints = new List<Vector2F>(vertices.Length);

            for (int i = 0; i < vertices.Length; i++)
            {
                Add(vertices[i]);
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Path" /> class.</summary>
        /// <param name="vertices">The vertices to created the path from.</param>
        public Path(IList<Vector2F> vertices)
        {
            ControlPoints = new List<Vector2F>(vertices.Count);
            for (int i = 0; i < vertices.Count; i++)
            {
                Add(vertices[i]);
            }
        }

        /// <summary>True if the curve is closed.</summary>
        /// <value><c>true</c> if closed; otherwise, <c>false</c>.</value>
        public bool Closed { get; set; }

        /// <summary>Gets the next index of a controlpoint</summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public int NextIndex(int index)
        {
            if (index == ControlPoints.Count - 1)
            {
                return 0;
            }

            return index + 1;
        }

        /// <summary>Gets the previous index of a controlpoint</summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public int PreviousIndex(int index)
        {
            if (index == 0)
            {
                return ControlPoints.Count - 1;
            }

            return index - 1;
        }

        /// <summary>Translates the control points by the specified vector.</summary>
        /// <param name="vector">The vector.</param>
        public void Translate(ref Vector2F vector)
        {
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                ControlPoints[i] = Vector2F.Add(ControlPoints[i], vector);
            }
        }

        /// <summary>Scales the control points by the specified vector.</summary>
        /// <param name="value">The Value.</param>
        public void Scale(ref Vector2F value)
        {
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                ControlPoints[i] = Vector2F.Multiply(ControlPoints[i], value);
            }
        }

        /// <summary>Rotate the control points by the defined value in radians.</summary>
        /// <param name="value">The amount to rotate by in radians.</param>
        public void Rotate(float value)
        {
            Matrix4X4F rotationMatrix = Matrix4X4F.CreateRotationZ(value);

            for (int i = 0; i < ControlPoints.Count; i++)
            {
                ControlPoints[i] = Vector2F.Transform(ControlPoints[i], rotationMatrix);
            }
        }

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                builder.Append(ControlPoints[i]);
                if (i < ControlPoints.Count - 1)
                {
                    builder.Append(" ");
                }
            }

            return builder.ToString();
        }

        /// <summary>Returns a set of points defining the curve with the specifed number of divisions between each control point.</summary>
        /// <param name="divisions">Number of divisions between each control point.</param>
        /// <returns></returns>
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
        ///     Gets the position using the specified time
        /// </summary>
        /// <param name="time">The time</param>
        /// <exception cref="Exception">You need at least 2 control points to calculate a position.</exception>
        /// <returns>The temp</returns>
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

                deltaT = 1f / (ControlPoints.Count - 1);

                int p = (int) (time / deltaT);

                // use a circular indexing system
                int p0 = p - 1;
                if (p0 < 0)
                {
                    p0 += ControlPoints.Count - 1;
                }
                else if (p0 >= ControlPoints.Count - 1)
                {
                    p0 -= ControlPoints.Count - 1;
                }

                int p1 = p;
                if (p1 < 0)
                {
                    p1 += ControlPoints.Count - 1;
                }
                else if (p1 >= ControlPoints.Count - 1)
                {
                    p1 -= ControlPoints.Count - 1;
                }

                int p2 = p + 1;
                if (p2 < 0)
                {
                    p2 += ControlPoints.Count - 1;
                }
                else if (p2 >= ControlPoints.Count - 1)
                {
                    p2 -= ControlPoints.Count - 1;
                }

                int p3 = p + 2;
                if (p3 < 0)
                {
                    p3 += ControlPoints.Count - 1;
                }
                else if (p3 >= ControlPoints.Count - 1)
                {
                    p3 -= ControlPoints.Count - 1;
                }

                // relative time
                float lt = (time - deltaT * p) / deltaT;

                temp = CatmullRom(ControlPoints[p0], ControlPoints[p1], ControlPoints[p2], ControlPoints[p3],
                    lt);

                RemoveAt(ControlPoints.Count - 1);
            }
            else
            {
                int p = (int) (time / deltaT);

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
                float lt = (time - deltaT * p) / deltaT;

                temp = CatmullRom(ControlPoints[p0], ControlPoints[p1], ControlPoints[p2], ControlPoints[p3],
                    lt);
            }

            return temp;
        }

        /// <summary>
        ///     Catmulls the rom using the specified value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="amount">The amount</param>
        /// <returns>The vector</returns>
        public static Vector2F CatmullRom(Vector2F value1, Vector2F value2, Vector2F value3, Vector2F value4,
            float amount) =>
            new Vector2F(
                Helper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                Helper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount));

        /// <summary>Gets the normal for the given time.</summary>
        /// <param name="time">The time</param>
        /// <returns>The normal.</returns>
        public Vector2F GetPositionNormal(float time)
        {
            float offsetTime = time + 0.0001f;

            Vector2F a = GetPosition(time);
            Vector2F b = GetPosition(offsetTime);


            Vector2F temp = Vector2F.Subtract(a, b);

            Vector2F output = new Vector2F
            {
                X = -temp.Y,
                Y = temp.X
            };

            output = Vector2F.Normalize(output);

            return output;
        }

        /// <summary>
        ///     Adds the point
        /// </summary>
        /// <param name="point">The point</param>
        public void Add(Vector2F point)
        {
            ControlPoints.Add(point);
            deltaT = 1f / (ControlPoints.Count - 1);
        }

        /// <summary>
        ///     Removes the point
        /// </summary>
        /// <param name="point">The point</param>
        public void Remove(Vector2F point)
        {
            ControlPoints.Remove(point);
            deltaT = 1f / (ControlPoints.Count - 1);
        }

        /// <summary>
        ///     Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void RemoveAt(int index)
        {
            ControlPoints.RemoveAt(index);
            deltaT = 1f / (ControlPoints.Count - 1);
        }

        /// <summary>
        ///     Gets the length
        /// </summary>
        /// <returns>The length</returns>
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
        ///     Subdivides the evenly using the specified divisions
        /// </summary>
        /// <param name="divisions">The divisions</param>
        /// <returns>The verts</returns>
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

                Vector3F addVector = new Vector3F(new Vector2F(end.X, end.Y), angle);
                verts.Add(addVector);

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