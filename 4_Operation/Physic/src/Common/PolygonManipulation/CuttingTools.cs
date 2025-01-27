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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Shapes;
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

            //We can only cut polygons at the moment
            if (!(fixture.GetShape is PolygonShape shape))
            {
                first = new Vertices();
                second = new Vertices();
                return;
            }

            //Offset the entry and exit points if they are too close to the vertices
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

            Vertices vertices = new Vertices(shape.Vertices);
            Vertices[] newPolygon = new Vertices[2];

            for (int i = 0; i < newPolygon.Length; i++)
            {
                newPolygon[i] = new Vertices(vertices.Count);
            }

            int[] cutAdded = {-1, -1};
            int last = -1;
            for (int i = 0; i < vertices.Count; i++)
            {
                //Find out if this vertex is on the old or new shape.
                int n = Vector2F.Dot(MathUtils.Cross(localExitPoint - localEntryPoint, 1), vertices[i] - localEntryPoint) > SettingEnv.Epsilon ? 0 : 1;

                if (last != n)
                {
                    //If we switch from one shape to the other add the cut vertices.
                    if (last == 0)
                    {
                        Debug.Assert(cutAdded[0] == -1);
                        cutAdded[0] = newPolygon[last].Count;
                        newPolygon[last].Add(localExitPoint);
                        newPolygon[last].Add(localEntryPoint);
                    }

                    if (last == 1)
                    {
                        Debug.Assert(cutAdded[last] == -1);
                        cutAdded[last] = newPolygon[last].Count;
                        newPolygon[last].Add(localEntryPoint);
                        newPolygon[last].Add(localExitPoint);
                    }
                }

                newPolygon[n].Add(vertices[i]);
                last = n;
            }

            //Add the cut in case it has not been added yet.
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

            for (int n = 0; n < 2; n++)
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

                newPolygon[n][cutAdded[n]] += SettingEnv.Epsilon * offset;

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

                newPolygon[n][cutAdded[n] + 1] += SettingEnv.Epsilon * offset;
            }

            first = newPolygon[0];
            second = newPolygon[1];
        }

        /// <summary>
        ///     This is a high-level function to cuts fixtures inside the given world, using the start and end points.
        ///     Note: We don't support cutting when the start or end is inside a shape.
        /// </summary>
        /// <param name="world">The world.</param>
        /// <param name="start">The startpoint.</param>
        /// <param name="end">The endpoint.</param>
        /// <returns>True if the cut was performed.</returns>
        public static bool Cut(World world, Vector2F start, Vector2F end)
        {
            List<Fixture> fixtures = new List<Fixture>();
            List<Vector2F> entryPoints = new List<Vector2F>();
            List<Vector2F> exitPoints = new List<Vector2F>();

            //We don't support cutting when the start or end is inside a shape.
            if (world.TestPoint(start) != null || world.TestPoint(end) != null)
            {
                return false;
            }

            //Get the entry points
            world.RayCast((f, p, n, fr) =>
            {
                fixtures.Add(f);
                entryPoints.Add(p);
                return 1;
            }, start, end);

            //Reverse the ray to get the exitpoints
            world.RayCast((f, p, n, fr) =>
            {
                exitPoints.Add(p);
                return 1;
            }, end, start);

            //We only have a single point. We need at least 2
            if (entryPoints.Count + exitPoints.Count < 2)
            {
                return false;
            }

            for (int i = 0; i < fixtures.Count; i++)
            {
                // can't cut circles or edges yet !
                if (fixtures[i].GetShape.ShapeType != ShapeType.Polygon)
                {
                    continue;
                }

                if (fixtures[i].GetBody.GetBodyType != BodyType.Static)
                {
                    //Split the shape up into two shapes
                    SplitShape(fixtures[i], entryPoints[i], exitPoints[i], out Vertices first, out Vertices second);

                    //Delete the original shape and create two new. Retain the properties of the body.
                    if (first.CheckPolygon() == PolygonError.NoError)
                    {
                        Body firstFixture = world.CreatePolygon(first, fixtures[i].GetShape.GetDensity, fixtures[i].GetBody.Position);
                        firstFixture.Rotation = fixtures[i].GetBody.Rotation;
                        firstFixture.LinearVelocity = fixtures[i].GetBody.LinearVelocity;
                        firstFixture.AngularVelocity = fixtures[i].GetBody.AngularVelocity;
                        firstFixture.GetBodyType = BodyType.Dynamic;
                    }

                    if (second.CheckPolygon() == PolygonError.NoError)
                    {
                        Body secondFixture = world.CreatePolygon(second, fixtures[i].GetShape.GetDensity, fixtures[i].GetBody.Position);
                        secondFixture.Rotation = fixtures[i].GetBody.Rotation;
                        secondFixture.LinearVelocity = fixtures[i].GetBody.LinearVelocity;
                        secondFixture.AngularVelocity = fixtures[i].GetBody.AngularVelocity;
                        secondFixture.GetBodyType = BodyType.Dynamic;
                    }

                    world.Remove(fixtures[i].GetBody);
                }
            }

            return true;
        }
    }
}