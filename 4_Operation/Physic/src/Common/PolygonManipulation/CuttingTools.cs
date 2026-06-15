// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CuttingTools.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.PolygonManipulation
{
    /// <summary>
    ///     The cutting tools class
    /// </summary>
    public static class CuttingTools
    {
        /// <summary>
        ///     Split a fixture into 2 vertice collections using the given entry and exit-point.
        /// </summary>
        /// <param name="fixture">The Fixture to split</param>
        /// <param name="entryPoint">The entry point - The start point</param>
        /// <param name="exitPoint">The exit point - The end point</param>
        /// <param name="first">The first collection of vertexes</param>
        /// <param name="second">The second collection of vertexes</param>
        public static void SplitShape(Fixture fixture, Vector2F entryPoint, Vector2F exitPoint, out Vertices first, out Vertices second)
        {
            Vector2F localEntryPoint = fixture.GetBody.GetLocalPoint(ref entryPoint);
            Vector2F localExitPoint = fixture.GetBody.GetLocalPoint(ref exitPoint);

            if (!(fixture.GetShape is PolygonShape shape))
            {
                first = new Vertices();
                second = new Vertices();
                return;
            }

            AdjustPointsNearVertices(shape, ref localEntryPoint, ref localExitPoint);

            Vertices vertices = new Vertices(shape.Vertices);
            Vertices[] newPolygon = new Vertices[2];

            for (int i = 0; i < newPolygon.Length; i++)
            {
                newPolygon[i] = new Vertices(vertices.Count);
            }

            int[] cutAdded = SplitVertices(vertices, localEntryPoint, localExitPoint, newPolygon);
            EnsureCutPointsAdded(newPolygon, cutAdded, localEntryPoint, localExitPoint);
            AdjustCutPointOffsets(newPolygon, cutAdded);

            first = newPolygon[0];
            second = newPolygon[1];
        }

        /// <summary>
        /// Adjusts the points near vertices using the specified shape
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <param name="localEntryPoint">The local entry point</param>
        /// <param name="localExitPoint">The local exit point</param>
        private static void AdjustPointsNearVertices(PolygonShape shape, ref Vector2F localEntryPoint, ref Vector2F localExitPoint)
        {
            foreach (Vector2F vertex in shape.Vertices)
            {
                if (vertex.Equals(localEntryPoint))
                {
                    localEntryPoint -= new Vector2F(0, SettingEnv.Epsilon);
                }

                if (vertex.Equals(localExitPoint))
                {
                    localExitPoint += new Vector2F(0, SettingEnv.Epsilon);
                }
            }
        }

        /// <summary>
        /// Splits the vertices using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="localEntryPoint">The local entry point</param>
        /// <param name="localExitPoint">The local exit point</param>
        /// <param name="newPolygon">The new polygon</param>
        /// <returns>The cut added</returns>
        private static int[] SplitVertices(Vertices vertices, Vector2F localEntryPoint, Vector2F localExitPoint, Vertices[] newPolygon)
        {
            int[] cutAdded = {-1, -1};
            int last = -1;
            for (int i = 0; i < vertices.Count; i++)
            {
                int n = ClassifyVertex(vertices[i], localEntryPoint, localExitPoint);

                if (last != n)
                {
                    AddCutPoints(newPolygon, cutAdded, last, localEntryPoint, localExitPoint);
                }

                newPolygon[n].Add(vertices[i]);
                last = n;
            }

            return cutAdded;
        }

        /// <summary>
        /// Classifies the vertex using the specified vertex
        /// </summary>
        /// <param name="vertex">The vertex</param>
        /// <param name="localEntryPoint">The local entry point</param>
        /// <param name="localExitPoint">The local exit point</param>
        /// <returns>The int</returns>
        private static int ClassifyVertex(Vector2F vertex, Vector2F localEntryPoint, Vector2F localExitPoint) => Vector2F.Dot(MathUtils.Cross(localExitPoint - localEntryPoint, 1), vertex - localEntryPoint) > SettingEnv.Epsilon ? 0 : 1;

        /// <summary>
        /// Adds the cut points using the specified new polygon
        /// </summary>
        /// <param name="newPolygon">The new polygon</param>
        /// <param name="cutAdded">The cut added</param>
        /// <param name="last">The last</param>
        /// <param name="localEntryPoint">The local entry point</param>
        /// <param name="localExitPoint">The local exit point</param>
        private static void AddCutPoints(Vertices[] newPolygon, int[] cutAdded, int last, Vector2F localEntryPoint, Vector2F localExitPoint)
        {
            if (last == 0)
            {
                cutAdded[0] = newPolygon[last].Count;
                newPolygon[last].Add(localExitPoint);
                newPolygon[last].Add(localEntryPoint);
            }

            if (last == 1)
            {
                cutAdded[last] = newPolygon[last].Count;
                newPolygon[last].Add(localEntryPoint);
                newPolygon[last].Add(localExitPoint);
            }
        }

        /// <summary>
        /// Ensures the cut points added using the specified new polygon
        /// </summary>
        /// <param name="newPolygon">The new polygon</param>
        /// <param name="cutAdded">The cut added</param>
        /// <param name="localEntryPoint">The local entry point</param>
        /// <param name="localExitPoint">The local exit point</param>
        private static void EnsureCutPointsAdded(Vertices[] newPolygon, int[] cutAdded, Vector2F localEntryPoint, Vector2F localExitPoint)
        {
            if (cutAdded[0] == -1)
            {
                cutAdded[0] = newPolygon[0].Count;
                newPolygon[0].Add(localExitPoint);
                newPolygon[0].Add(localEntryPoint);
            }

            if (cutAdded[1] == -1)
            {
                cutAdded[1] = newPolygon[1].Count;
                newPolygon[1].Add(localEntryPoint);
                newPolygon[1].Add(localExitPoint);
            }
        }

        /// <summary>
        /// Adjusts the cut point offsets using the specified new polygon
        /// </summary>
        /// <param name="newPolygon">The new polygon</param>
        /// <param name="cutAdded">The cut added</param>
        private static void AdjustCutPointOffsets(Vertices[] newPolygon, int[] cutAdded)
        {
            for (int n = 0; n < 2; n++)
            {
                Vector2F offset = ComputeOffsetBeforeCut(newPolygon, n, cutAdded);
                newPolygon[n][cutAdded[n]] += SettingEnv.Epsilon * offset;

                offset = ComputeOffsetAfterCut(newPolygon, n, cutAdded);
                newPolygon[n][cutAdded[n] + 1] += SettingEnv.Epsilon * offset;
            }
        }

        /// <summary>
        /// Computes the offset before cut using the specified new polygon
        /// </summary>
        /// <param name="newPolygon">The new polygon</param>
        /// <param name="n">The </param>
        /// <param name="cutAdded">The cut added</param>
        /// <returns>The offset</returns>
        private static Vector2F ComputeOffsetBeforeCut(Vertices[] newPolygon, int n, int[] cutAdded)
        {
            Vector2F offset;
            if (cutAdded[n] > 0)
            {
                offset = newPolygon[n][cutAdded[n] - 1] - newPolygon[n][cutAdded[n]];
            }
            else
            {
                offset = newPolygon[n][newPolygon[n].Count - 1] - newPolygon[n][0];
            }

            offset.Normalize();

            if (!offset.IsValid())
            {
                offset = Vector2F.One;
            }

            return offset;
        }

        /// <summary>
        /// Computes the offset after cut using the specified new polygon
        /// </summary>
        /// <param name="newPolygon">The new polygon</param>
        /// <param name="n">The </param>
        /// <param name="cutAdded">The cut added</param>
        /// <returns>The offset</returns>
        private static Vector2F ComputeOffsetAfterCut(Vertices[] newPolygon, int n, int[] cutAdded)
        {
            Vector2F offset;
            if (cutAdded[n] < newPolygon[n].Count - 2)
            {
                offset = newPolygon[n][cutAdded[n] + 2] - newPolygon[n][cutAdded[n] + 1];
            }
            else
            {
                offset = newPolygon[n][0] - newPolygon[n][newPolygon[n].Count - 1];
            }

            offset.Normalize();

            if (!offset.IsValid())
            {
                offset = Vector2F.One;
            }

            return offset;
        }

        /// <summary>
        ///     This is a high-level function to cuts fixtures inside the given world, using the start and end points.
        ///     Note: We don't support cutting when the start or end is inside a shape.
        /// </summary>
        /// <param name="worldPhysic">The world.</param>
        /// <param name="start">The startpoint.</param>
        /// <param name="end">The endpoint.</param>
        /// <returns>True if the cut was performed.</returns>
        public static bool Cut(WorldPhysic worldPhysic, Vector2F start, Vector2F end)
        {
            List<Fixture> fixtures = new List<Fixture>();
            List<Vector2F> entryPoints = new List<Vector2F>();
            List<Vector2F> exitPoints = new List<Vector2F>();

            if (worldPhysic.TestPoint(start) != null || worldPhysic.TestPoint(end) != null)
            {
                return false;
            }

            worldPhysic.RayCast((f, p, n, fr) =>
            {
                fixtures.Add(f);
                entryPoints.Add(p);
                return 1;
            }, start, end);

            worldPhysic.RayCast((f, p, n, fr) =>
            {
                exitPoints.Add(p);
                return 1;
            }, end, start);

            if (entryPoints.Count + exitPoints.Count < 2)
            {
                return false;
            }

            for (int i = 0; i < fixtures.Count; i++)
            {
                if (fixtures[i].GetShape.ShapeType != ShapeType.Polygon)
                {
                    continue;
                }

                if (fixtures[i].GetBody.GetBodyType != BodyType.Static)
                {
                    SplitShape(fixtures[i], entryPoints[i], exitPoints[i], out Vertices first, out Vertices second);

                    if (first.CheckPolygon() == PolygonError.NoError)
                    {
                        Body firstFixture = worldPhysic.CreatePolygon(first, fixtures[i].GetShape.GetDensity, fixtures[i].GetBody.Position);
                        firstFixture.Rotation = fixtures[i].GetBody.Rotation;
                        firstFixture.LinearVelocity = fixtures[i].GetBody.LinearVelocity;
                        firstFixture.AngularVelocity = fixtures[i].GetBody.AngularVelocity;
                        firstFixture.GetBodyType = BodyType.Dynamic;
                    }

                    if (second.CheckPolygon() == PolygonError.NoError)
                    {
                        Body secondFixture = worldPhysic.CreatePolygon(second, fixtures[i].GetShape.GetDensity, fixtures[i].GetBody.Position);
                        secondFixture.Rotation = fixtures[i].GetBody.Rotation;
                        secondFixture.LinearVelocity = fixtures[i].GetBody.LinearVelocity;
                        secondFixture.AngularVelocity = fixtures[i].GetBody.AngularVelocity;
                        secondFixture.GetBodyType = BodyType.Dynamic;
                    }

                    worldPhysic.Remove(fixtures[i].GetBody);
                }
            }

            return true;
        }
    }
}