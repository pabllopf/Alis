// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Collision.CollidePoly.cs
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

using Alis.Aspect.Math;
using Alis.Core.Physic.Collision.Shapes;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The collision class
    /// </summary>
    public static partial class Collision
    {
        /// <summary>
        ///     Find the separation between poly1 and poly2 for a give edge normal on poly1.
        /// </summary>
        public static float EdgeSeparation(PolygonShape poly1, XForm xf1, int edge1, PolygonShape poly2, XForm xf2)
        {
            int count1 = poly1.VertexCount;
            Vector2[] vertices1 = poly1.Vertices;
            Vector2[] normals1 = poly1.Normals;

            int count2 = poly2.VertexCount;
            Vector2[] vertices2 = poly2.Vertices;

            Box2DxDebug.Assert(0 <= edge1 && edge1 < count1);

            // Convert normal from poly1's frame into poly2's frame.
            Vector2 normal1World = Math.Mul(xf1.R, normals1[edge1]);
            Vector2 normal1 = Math.MulT(xf2.R, normal1World);

            // Find support vertex on poly2 for -normal.
            int index = 0;
            float minDot = Settings.FltMax;
            for (int i = 0; i < count2; ++i)
            {
                float dot = Vector2.Dot(vertices2[i], normal1);
                if (dot < minDot)
                {
                    minDot = dot;
                    index = i;
                }
            }

            Vector2 v1 = Math.Mul(xf1, vertices1[edge1]);
            Vector2 v2 = Math.Mul(xf2, vertices2[index]);
            float separation = Vector2.Dot(v2 - v1, normal1World);
            return separation;
        }

        /// <summary>
        ///     Find the max separation between poly1 and poly2 using edge normals from poly1.
        /// </summary>
        public static float FindMaxSeparation(ref int edgeIndex, PolygonShape poly1, XForm xf1, PolygonShape poly2,
            XForm xf2)
        {
            int count1 = poly1.VertexCount;
            Vector2[] normals1 = poly1.Normals;

            // Vector pointing from the centroid of poly1 to the centroid of poly2.
            Vector2 d = Math.Mul(xf2, poly2.Centroid) - Math.Mul(xf1, poly1.Centroid);
            Vector2 dLocal1 = Math.MulT(xf1.R, d);

            // Find edge normal on poly1 that has the largest projection onto d.
            int edge = 0;
            float maxDot = -Settings.FltMax;
            for (int i = 0; i < count1; ++i)
            {
                float dot = Vector2.Dot(normals1[i], dLocal1);
                if (dot > maxDot)
                {
                    maxDot = dot;
                    edge = i;
                }
            }

            // Get the separation for the edge normal.
            float s = EdgeSeparation(poly1, xf1, edge, poly2, xf2);

            // Check the separation for the previous edge normal.
            int prevEdge = edge - 1 >= 0 ? edge - 1 : count1 - 1;
            float sPrev = EdgeSeparation(poly1, xf1, prevEdge, poly2, xf2);

            // Check the separation for the next edge normal.
            int nextEdge = edge + 1 < count1 ? edge + 1 : 0;
            float sNext = EdgeSeparation(poly1, xf1, nextEdge, poly2, xf2);

            // Find the best edge and the search direction.
            int bestEdge;
            float bestSeparation;
            int increment;
            if (sPrev > s && sPrev > sNext)
            {
                increment = -1;
                bestEdge = prevEdge;
                bestSeparation = sPrev;
            }
            else if (sNext > s)
            {
                increment = 1;
                bestEdge = nextEdge;
                bestSeparation = sNext;
            }
            else
            {
                edgeIndex = edge;
                return s;
            }

            // Perform a local search for the best edge normal.
            for (;;)
            {
                if (increment == -1)
                {
                    edge = bestEdge - 1 >= 0 ? bestEdge - 1 : count1 - 1;
                }
                else
                {
                    edge = bestEdge + 1 < count1 ? bestEdge + 1 : 0;
                }

                s = EdgeSeparation(poly1, xf1, edge, poly2, xf2);

                if (s > bestSeparation)
                {
                    bestEdge = edge;
                    bestSeparation = s;
                }
                else
                {
                    break;
                }
            }

            edgeIndex = bestEdge;
            return bestSeparation;
        }

        /// <summary>
        ///     Finds the incident edge using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <param name="poly1">The poly</param>
        /// <param name="xf1">The xf</param>
        /// <param name="edge1">The edge</param>
        /// <param name="poly2">The poly</param>
        /// <param name="xf2">The xf</param>
        public static void FindIncidentEdge(out ClipVertex[] c,
            PolygonShape poly1, XForm xf1, int edge1, PolygonShape poly2, XForm xf2)
        {
            int count1 = poly1.VertexCount;
            Vector2[] normals1 = poly1.Normals;

            int count2 = poly2.VertexCount;
            Vector2[] vertices2 = poly2.Vertices;
            Vector2[] normals2 = poly2.Normals;

            Box2DxDebug.Assert(0 <= edge1 && edge1 < count1);

            // Get the normal of the reference edge in poly2's frame.
            Vector2 normal1 = Math.MulT(xf2.R, Math.Mul(xf1.R, normals1[edge1]));

            // Find the incident edge on poly2.
            int index = 0;
            float minDot = Settings.FltMax;
            for (int i = 0; i < count2; ++i)
            {
                float dot = Vector2.Dot(normal1, normals2[i]);
                if (dot < minDot)
                {
                    minDot = dot;
                    index = i;
                }
            }

            // Build the clip vertices for the incident edge.
            int i1 = index;
            int i2 = i1 + 1 < count2 ? i1 + 1 : 0;

            c = new ClipVertex[2];

            c[0].V = Math.Mul(xf2, vertices2[i1]);
            c[0].Id.Features.ReferenceEdge = (byte) edge1;
            c[0].Id.Features.IncidentEdge = (byte) i1;
            c[0].Id.Features.IncidentVertex = 0;

            c[1].V = Math.Mul(xf2, vertices2[i2]);
            c[1].Id.Features.ReferenceEdge = (byte) edge1;
            c[1].Id.Features.IncidentEdge = (byte) i2;
            c[1].Id.Features.IncidentVertex = 1;
        }

        // Find edge normal of max separation on A - return if separating axis is found
        // Find edge normal of max separation on B - return if separation axis is found
        // Choose reference edge as min(minA, minB)
        // Find incident edge
        // Clip
        // The normal points from 1 to 2
        /// <summary>
        ///     Collides the polygons using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="polyA">The poly</param>
        /// <param name="xfA">The xf</param>
        /// <param name="polyB">The poly</param>
        /// <param name="xfB">The xf</param>
        public static void CollidePolygons(ref Manifold manifold,
            PolygonShape polyA, XForm xfA, PolygonShape polyB, XForm xfB)
        {
            manifold.PointCount = 0;
            float totalRadius = polyA.Radius + polyB.Radius;

            int edgeA = 0;
            float separationA = FindMaxSeparation(ref edgeA, polyA, xfA, polyB, xfB);
            if (separationA > totalRadius)
            {
                return;
            }

            int edgeB = 0;
            float separationB = FindMaxSeparation(ref edgeB, polyB, xfB, polyA, xfA);
            if (separationB > totalRadius)
            {
                return;
            }

            PolygonShape poly1; // reference poly
            PolygonShape poly2; // incident poly
            XForm xf1, xf2;
            int edge1; // reference edge
            byte flip;
            const float kRelativeTol = 0.98f;
            const float kAbsoluteTol = 0.001f;

            if (separationB > kRelativeTol * separationA + kAbsoluteTol)
            {
                poly1 = polyB;
                poly2 = polyA;
                xf1 = xfB;
                xf2 = xfA;
                edge1 = edgeB;
                manifold.Type = ManifoldType.FaceB;
                flip = 1;
            }
            else
            {
                poly1 = polyA;
                poly2 = polyB;
                xf1 = xfA;
                xf2 = xfB;
                edge1 = edgeA;
                manifold.Type = ManifoldType.FaceA;
                flip = 0;
            }

            ClipVertex[] incidentEdge;
            FindIncidentEdge(out incidentEdge, poly1, xf1, edge1, poly2, xf2);

            int count1 = poly1.VertexCount;
            Vector2[] vertices1 = poly1.Vertices;

            Vector2 v11 = vertices1[edge1];
            Vector2 v12 = edge1 + 1 < count1 ? vertices1[edge1 + 1] : vertices1[0];

            Vector2 dv = v12 - v11;

            Vector2 localNormal = Vector2.Cross(dv, 1.0f);
            localNormal.Normalize();
            Vector2 planePoint = 0.5f * (v11 + v12);

            Vector2 sideNormal = Math.Mul(xf1.R, v12 - v11);
            sideNormal.Normalize();
            Vector2 frontNormal = Vector2.Cross(sideNormal, 1.0f);

            v11 = Math.Mul(xf1, v11);
            v12 = Math.Mul(xf1, v12);

            float frontOffset = Vector2.Dot(frontNormal, v11);
            float sideOffset1 = -Vector2.Dot(sideNormal, v11);
            float sideOffset2 = Vector2.Dot(sideNormal, v12);

            // Clip incident edge against extruded edge1 side edges.
            ClipVertex[] clipPoints1;
            ClipVertex[] clipPoints2;
            int np;

            // Clip to box side 1
            np = ClipSegmentToLine(out clipPoints1, incidentEdge, -sideNormal, sideOffset1);

            if (np < 2)
            {
                return;
            }

            // Clip to negative box side 1
            np = ClipSegmentToLine(out clipPoints2, clipPoints1, sideNormal, sideOffset2);

            if (np < 2)
            {
                return;
            }

            // Now clipPoints2 contains the clipped points.
            manifold.LocalPlaneNormal = localNormal;
            manifold.LocalPoint = planePoint;

            int pointCount = 0;
            for (int i = 0; i < Settings.MaxManifoldPoints; ++i)
            {
                float separation = Vector2.Dot(frontNormal, clipPoints2[i].V) - frontOffset;

                if (separation <= totalRadius)
                {
                    ManifoldPoint cp = manifold.Points[pointCount];
                    cp.LocalPoint = Math.MulT(xf2, clipPoints2[i].V);
                    cp.Id = clipPoints2[i].Id;
                    cp.Id.Features.Flip = flip;
                    ++pointCount;
                }
            }

            manifold.PointCount = pointCount;
        }
    }
}