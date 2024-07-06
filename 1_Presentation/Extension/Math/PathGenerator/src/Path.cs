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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;

namespace Alis.Extension.Math.PathGenerator
{
    /// <summary>
    ///     Path: Very similar to Vertices, but this class contains vectors describing control points on a Catmull-Rom
    ///     curve.
    /// </summary>
    public class Path
    {
        /// <summary>All the points that makes up the curve</summary>
        private readonly List<Vector2> controlPoints;

        /// <summary>
        ///     The delta
        /// </summary>
        private float deltaT;

        /// <summary>Initializes a new instance of the <see cref="Path" /> class.</summary>
        public Path() => controlPoints = new List<Vector2>();

        /// <summary>Initializes a new instance of the <see cref="Path" /> class.</summary>
        /// <param name="vertices">The vertices to created the path from.</param>
        public Path(Vector2[] vertices)
        {
            controlPoints = new List<Vector2>(vertices.Length);

            for (int i = 0; i < vertices.Length; i++)
            {
                Add(vertices[i]);
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Path" /> class.</summary>
        /// <param name="vertices">The vertices to created the path from.</param>
        public Path(IList<Vector2> vertices)
        {
            controlPoints = new List<Vector2>(vertices.Count);
            for (int i = 0; i < vertices.Count; i++)
            {
                Add(vertices[i]);
            }
        }

        /// <summary>True if the curve is closed.</summary>
        /// <value><c>true</c> if closed; otherwise, <c>false</c>.</value>
        public bool Closed { get; }

        /// <summary>Gets the next index of a controlpoint</summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public int NextIndex(int index)
        {
            if (index == controlPoints.Count - 1)
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
                return controlPoints.Count - 1;
            }

            return index - 1;
        }

        /// <summary>Translates the control points by the specified vector.</summary>
        /// <param name="vector">The vector.</param>
        public void Translate(ref Vector2 vector)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                controlPoints[i] = Vector2.Add(controlPoints[i], vector);
            }
        }

        /// <summary>Scales the control points by the specified vector.</summary>
        /// <param name="value">The Value.</param>
        public void Scale(ref Vector2 value)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                controlPoints[i] = Vector2.Multiply(controlPoints[i], value);
            }
        }

        /// <summary>Rotate the control points by the defined value in radians.</summary>
        /// <param name="value">The amount to rotate by in radians.</param>
        public void Rotate(float value)
        {
            Matrix4X4 rotationMatrix = Matrix4X4.CreateRotationZ(value);

            for (int i = 0; i < controlPoints.Count; i++)
            {
                controlPoints[i] = Vector2.Transform(controlPoints[i], rotationMatrix);
            }
        }

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < controlPoints.Count; i++)
            {
                builder.Append(controlPoints[i]);
                if (i < controlPoints.Count - 1)
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
        /// <returns>The vector</returns>
        public Vector2 GetPosition(float time)
        {
            if (controlPoints.Count < 2)
            {
                throw new Exception("You need at least 2 control points to calculate a position.");
            }

            deltaT = 1f / (controlPoints.Count - 1);
            int p = (int) (time / deltaT);

            return Closed ? CalculatePositionWhenClosed(p, time) : CalculatePositionWhenNotClosed(p, time);
        }

        /// <summary>
        ///     Calculates the position when closed using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="time">The time</param>
        /// <returns>The temp</returns>
        private Vector2 CalculatePositionWhenClosed(int p, float time)
        {
            Add(controlPoints[0]);

            Vector2 temp = CalculatePosition(p, time);

            RemoveAt(controlPoints.Count - 1);

            return temp;
        }

        /// <summary>
        ///     Calculates the position when not closed using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="time">The time</param>
        /// <returns>The vector</returns>
        private Vector2 CalculatePositionWhenNotClosed(int p, float time) => CalculatePosition(p, time);

        /// <summary>
        ///     Calculates the position using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="time">The time</param>
        /// <returns>The vector</returns>
        private Vector2 CalculatePosition(int p, float time)
        {
            int p0 = AdjustIndex(p - 1);
            int p1 = AdjustIndex(p);
            int p2 = AdjustIndex(p + 1);
            int p3 = AdjustIndex(p + 2);

            float lt = (time - deltaT * p) / deltaT;

            return CatmullRom(controlPoints[p0], controlPoints[p1], controlPoints[p2], controlPoints[p3], lt);
        }

        /// <summary>
        ///     Adjusts the index using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The index</returns>
        private int AdjustIndex(int index)
        {
            if (index < 0)
            {
                return Closed ? index + controlPoints.Count - 1 : 0;
            }

            if (index >= controlPoints.Count - 1)
            {
                return Closed ? index - controlPoints.Count - 1 : controlPoints.Count - 1;
            }

            return index;
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
        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4,
            float amount) =>
            new Vector2(
                Helper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                Helper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount));

        /// <summary>Gets the normal for the given time.</summary>
        /// <param name="time">The time</param>
        /// <returns>The normal.</returns>
        public Vector2 GetPositionNormal(float time)
        {
            float offsetTime = time + 0.0001f;

            Vector2 a = GetPosition(time);
            Vector2 b = GetPosition(offsetTime);


            Vector2 temp = Vector2.Subtract(a, b);

            Vector2 output = new Vector2
            (
                -temp.Y,
                temp.X
            );

            output = Vector2.Normalize(output);

            return output;
        }

        /// <summary>
        ///     Adds the point
        /// </summary>
        /// <param name="point">The point</param>
        public void Add(Vector2 point)
        {
            controlPoints.Add(point);
            deltaT = 1f / (controlPoints.Count - 1);
        }

        /// <summary>
        ///     Removes the point
        /// </summary>
        /// <param name="point">The point</param>
        public void Remove(Vector2 point)
        {
            controlPoints.Remove(point);
            deltaT = 1f / (controlPoints.Count - 1);
        }

        /// <summary>
        ///     Removes the at using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void RemoveAt(int index)
        {
            controlPoints.RemoveAt(index);
            deltaT = 1f / (controlPoints.Count - 1);
        }

        /// <summary>
        ///     Gets the length
        /// </summary>
        /// <returns>The length</returns>
        public float GetLength()
        {
            List<Vector2> verts = GetVertices(controlPoints.Count * 25);
            float length = 0;

            for (int i = 1; i < verts.Count; i++)
            {
                length += Vector2.Distance(verts[i - 1], verts[i]);
            }

            if (Closed)
            {
                length += Vector2.Distance(verts[controlPoints.Count - 1], verts[0]);
            }

            return length;
        }

        /// <summary>
        ///     Subdivides the evenly using the specified divisions
        /// </summary>
        /// <param name="divisions">The divisions</param>
        /// <returns>The verts</returns>
        public List<Vector3> SubdivideEvenly(int divisions)
        {
            List<Vector3> verts = new List<Vector3>();

            float length = GetLength();

            float deltaLength = length / divisions + 0.001f;
            float t = 0.000f;

            // we always start at the first control point
            Vector2 start = controlPoints[0];
            Vector2 end = GetPosition(t);

            // increment t until we are at half the distance
            while (deltaLength * 0.5f >= Vector2.Distance(start, end))
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
                Vector2 normal = GetPositionNormal(t);
                float angle = (float) System.Math.Atan2(normal.Y, normal.X);

                Vector3 addVector = new Vector3(new Vector2(end.X, end.Y), angle);
                verts.Add(addVector);

                // until we reach the correct distance down the curve
                while (deltaLength >= Vector2.Distance(start, end))
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