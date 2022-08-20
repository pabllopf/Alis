// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Collision.cs
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

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions.Shape;

namespace Alis.Core.Physic.Collisions
{
    // Structures and functions used for computing contact points, distance
    // queries, and TOI queries.

    /// <summary>
    ///     The collision class
    /// </summary>
    public static class Collision
    {
        /// <summary>
        ///     The uchar max
        /// </summary>
        public static readonly byte NullFeature = Math.UcharMax;

        /// <summary>
        ///     The max toi iters
        /// </summary>
        public static int MaxToiIters;

        /// <summary>
        ///     The max toi root iters
        /// </summary>
        public static int MaxToiRootIters;

        /// <summary>
        ///     Describes whether test overlap
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        public static bool TestOverlap(Aabb a, Aabb b)
        {
            Vector2 d1, d2;
            d1 = b.LowerBound - a.UpperBound;
            d2 = a.LowerBound - b.UpperBound;

            if (d1.X > 0.0f || d1.Y > 0.0f)
            {
                return false;
            }

            if (d2.X > 0.0f || d2.Y > 0.0f)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Compute the point states given two manifolds. The states pertain to the transition from manifold1
        ///     to manifold2. So state1 is either persist or remove while state2 is either add or persist.
        /// </summary>
        public static void GetPointStates(PointState[ /*b2_maxManifoldPoints*/] state1,
            PointState[ /*b2_maxManifoldPoints*/] state2,
            Manifold manifold1, Manifold manifold2)
        {
            for (int i = 0; i < Settings.MaxManifoldPoints; ++i)
            {
                state1[i] = PointState.NullState;
                state2[i] = PointState.NullState;
            }

            // Detect persists and removes.
            for (int i = 0; i < manifold1.PointCount; ++i)
            {
                ContactId id = manifold1.Points[i].Id;

                state1[i] = PointState.RemoveState;

                for (int j = 0; j < manifold2.PointCount; ++j)
                {
                    if (manifold2.Points[j].Id.Key == id.Key)
                    {
                        state1[i] = PointState.PersistState;
                        break;
                    }
                }
            }

            // Detect persists and adds.
            for (int i = 0; i < manifold2.PointCount; ++i)
            {
                ContactId id = manifold2.Points[i].Id;

                state2[i] = PointState.AddState;

                for (int j = 0; j < manifold1.PointCount; ++j)
                {
                    if (manifold1.Points[j].Id.Key == id.Key)
                    {
                        state2[i] = PointState.PersistState;
                        break;
                    }
                }
            }
        }

        // Sutherland-Hodgman clipping.
        /// <summary>
        ///     Clips the segment to line using the specified v out
        /// </summary>
        /// <param name="vOut">The out</param>
        /// <param name="vIn">The in</param>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <returns>The num out</returns>
        public static int ClipSegmentToLine(out ClipVertex[ /*2*/] vOut, ClipVertex[ /*2*/] vIn, Vector2 normal,
            float offset)
        {
            vOut = new ClipVertex[2];

            // Start with no output points
            int numOut = 0;

            // Calculate the distance of end points to the line
            float distance0 = Vector2.Dot(normal, vIn[0].V) - offset;
            float distance1 = Vector2.Dot(normal, vIn[1].V) - offset;

            // If the points are behind the plane
            if (distance0 <= 0.0f)
            {
                vOut[numOut++] = vIn[0];
            }

            if (distance1 <= 0.0f)
            {
                vOut[numOut++] = vIn[1];
            }

            // If the points are on different sides of the plane
            if (distance0 * distance1 < 0.0f)
            {
                // Find intersection point of edge and plane
                float interp = distance0 / (distance0 - distance1);
                vOut[numOut].V = vIn[0].V + interp * (vIn[1].V - vIn[0].V);
                if (distance0 > 0.0f)
                {
                    vOut[numOut].Id = vIn[0].Id;
                }
                else
                {
                    vOut[numOut].Id = vIn[1].Id;
                }

                ++numOut;
            }

            return numOut;
        }


        /// <summary>
        ///     Collides the circles using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="circle1">The circle</param>
        /// <param name="xf1">The xf</param>
        /// <param name="circle2">The circle</param>
        /// <param name="xf2">The xf</param>
        public static void CollideCircles(ref Manifold manifold,
            CircleShape circle1, XForm xf1, CircleShape circle2, XForm xf2)
        {
            manifold.PointCount = 0;

            Vector2 p1 = Math.Mul(xf1, circle1.Position);
            Vector2 p2 = Math.Mul(xf2, circle2.Position);

            Vector2 d = p2 - p1;
            float distSqr = Vector2.Dot(d, d);
            float radius = circle1.GetRadius() + circle2.GetRadius();
            if (distSqr > radius * radius)
            {
                return;
            }

            manifold.Type = ManifoldType.Circles;
            manifold.LocalPoint = circle1.Position;
            manifold.LocalPlaneNormal.SetZero();
            manifold.PointCount = 1;

            manifold.Points[0].LocalPoint = circle2.Position;
            manifold.Points[0].Id.Key = 0;
        }

        /// <summary>
        ///     Collides the polygon and circle using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="polygon">The polygon</param>
        /// <param name="xf1">The xf</param>
        /// <param name="circle">The circle</param>
        /// <param name="xf2">The xf</param>
        public static void CollidePolygonAndCircle(ref Manifold manifold,
            PolygonShape polygon, XForm xf1, CircleShape circle, XForm xf2)
        {
            manifold.PointCount = 0;

            // Compute circle position in the frame of the polygon.
            Vector2 c = Math.Mul(xf2, circle.Position);
            Vector2 cLocal = Math.MulT(xf1, c);

            // Find the min separating edge.
            int normalIndex = 0;
            float separation = -Settings.FltMax;
            float radius = polygon.GetRadius() + circle.GetRadius();
            int vertexCount = polygon.VertexCount;
            Vector2[] vertices = polygon.Vertices;
            Vector2[] normals = polygon.Normals;

            for (int i = 0; i < vertexCount; ++i)
            {
                float s = Vector2.Dot(normals[i], cLocal - vertices[i]);
                if (s > radius)
                {
                    // Early out.
                    return;
                }

                if (s > separation)
                {
                    separation = s;
                    normalIndex = i;
                }
            }

            // Vertices that subtend the incident face.
            int vertIndex1 = normalIndex;
            int vertIndex2 = vertIndex1 + 1 < vertexCount ? vertIndex1 + 1 : 0;
            Vector2 v1 = vertices[vertIndex1];
            Vector2 v2 = vertices[vertIndex2];

            // If the center is inside the polygon ...
            if (separation < Settings.FltEpsilon)
            {
                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = normals[normalIndex];
                manifold.LocalPoint = 0.5f * (v1 + v2);
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
                return;
            }

            // Compute barycentric coordinates
            float u1 = Vector2.Dot(cLocal - v1, v2 - v1);
            float u2 = Vector2.Dot(cLocal - v2, v1 - v2);
            if (u1 <= 0.0f)
            {
                if (Vector2.DistanceSquared(cLocal, v1) > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = cLocal - v1;
                manifold.LocalPlaneNormal.Normalize();
                manifold.LocalPoint = v1;
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
            else if (u2 <= 0.0f)
            {
                if (Vector2.DistanceSquared(cLocal, v2) > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = cLocal - v2;
                manifold.LocalPlaneNormal.Normalize();
                manifold.LocalPoint = v2;
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
            else
            {
                Vector2 faceCenter = 0.5f * (v1 + v2);
                float dot = Vector2.Dot(cLocal - faceCenter, normals[vertIndex1]);
                if (dot > radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = normals[vertIndex1];
                manifold.LocalPoint = faceCenter;
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
        }

        // This implements 2-sided edge vs circle collision.
        /// <summary>
        ///     Collides the edge and circle using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="edge">The edge</param>
        /// <param name="transformA">The transform</param>
        /// <param name="circle">The circle</param>
        /// <param name="transformB">The transform</param>
        public static void CollideEdgeAndCircle(ref Manifold manifold, EdgeShape edge, XForm transformA,
            CircleShape circle, XForm transformB)
        {
            manifold.PointCount = 0;
            Vector2 cLocal = Math.MulT(transformA, Math.Mul(transformB, circle.Position));
            Vector2 normal = edge.NormalVector;
            Vector2 v1 = edge.Vertex1;
            Vector2 v2 = edge.Vertex2;
            float radius = edge.GetRadius() + circle.GetRadius();

            // Barycentric coordinates
            float u1 = Vector2.Dot(cLocal - v1, v2 - v1);
            float u2 = Vector2.Dot(cLocal - v2, v1 - v2);

            if (u1 <= 0.0f)
            {
                // Behind v1
                if (Vector2.DistanceSquared(cLocal, v1) > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = cLocal - v1;
                manifold.LocalPlaneNormal.Normalize();
                manifold.LocalPoint = v1;
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
            else if (u2 <= 0.0f)
            {
                // Ahead of v2
                if (Vector2.DistanceSquared(cLocal, v2) > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = cLocal - v2;
                manifold.LocalPlaneNormal.Normalize();
                manifold.LocalPoint = v2;
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
            else
            {
                float separation = Vector2.Dot(cLocal - v1, normal);
                if (separation < -radius || radius < separation)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalPlaneNormal = separation < 0.0f ? -normal : normal;
                manifold.LocalPoint = 0.5f * (v1 + v2);
                manifold.Points[0].LocalPoint = circle.Position;
                manifold.Points[0].Id.Key = 0;
            }
        }

        // Polygon versus 2-sided edge.
        /// <summary>
        ///     Collides the poly and edge using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="polygon">The polygon</param>
        /// <param name="transformA">The transform</param>
        /// <param name="edge">The edge</param>
        /// <param name="transformB">The transform</param>
        public static void CollidePolyAndEdge(ref Manifold manifold, PolygonShape polygon, XForm transformA,
            EdgeShape edge, XForm transformB)
        {
            PolygonShape polygonB = new PolygonShape();
            polygonB.SetAsEdge(edge.Vertex1, edge.Vertex2);

            CollidePolygons(ref manifold, polygon, transformA, polygonB, transformB);
        }

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

            Box2DxDebug.Assert((0 <= edge1) && (edge1 < count1));

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
            if ((sPrev > s) && (sPrev > sNext))
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

            Box2DxDebug.Assert((0 <= edge1) && (edge1 < count1));

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
            float totalRadius = polyA.GetRadius() + polyB.GetRadius();

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

        /// <summary>
        ///     Compute the closest points between two shapes. Supports any combination of:
        ///     CircleShape, PolygonShape, EdgeShape. The simplex cache is input/output.
        ///     On the first call set SimplexCache.Count to zero.
        /// </summary>
        public static unsafe void Distance(out DistanceOutput output, ref SimplexCache cache, ref DistanceInput input,
            IShape shapeA, IShape shapeB)
        {
            output = new DistanceOutput();

            XForm transformA = input.TransformA;
            XForm transformB = input.TransformB;

            // Initialize the simplex.
            Simplex simplex = new Simplex();
            fixed (SimplexCache* sPtr = &cache)
            {
                simplex.ReadCache(sPtr, shapeA, transformA, shapeB, transformB);
            }

            // Get simplex vertices as an array.
            SimplexVertex* vertices = &simplex.V1;

            // These store the vertices of the last simplex so that we
            // can check for duplicates and prevent cycling.
            int* lastA = stackalloc int[4], lastB = stackalloc int[4];
            int lastCount;

            // Main iteration loop.
            int iter = 0;
            const int kMaxIterationCount = 20;
            while (iter < kMaxIterationCount)
            {
                // Copy simplex so we can identify duplicates.
                lastCount = simplex.Count;
                int i;
                for (i = 0; i < lastCount; ++i)
                {
                    lastA[i] = vertices[i].IndexA;
                    lastB[i] = vertices[i].IndexB;
                }

                switch (simplex.Count)
                {
                    case 1:
                        break;

                    case 2:
                        simplex.Solve2();
                        break;

                    case 3:
                        simplex.Solve3();
                        break;

                    default:
#if DEBUG
                        Box2DxDebug.Assert(false);
#endif
                        break;
                }

                // If we have 3 points, then the origin is in the corresponding triangle.
                if (simplex.Count == 3)
                {
                    break;
                }

                // Compute closest point.
                Vector2 p = simplex.GetClosestPoint();
                float distanceSqr = p.LengthSquared();

                // Ensure the search direction is numerically fit.
                if (distanceSqr < Settings.FltEpsilonSquared)
                {
                    // The origin is probably contained by a line segment
                    // or triangle. Thus the shapes are overlapped.

                    // We can't return zero here even though there may be overlap.
                    // In case the simplex is a point, segment, or triangle it is difficult
                    // to determine if the origin is contained in the CSO or very close to it.
                    break;
                }

                // Compute a tentative new simplex vertex using support points.
                SimplexVertex* vertex = vertices + simplex.Count;
                vertex->IndexA = shapeA.GetSupport(Math.MulT(transformA.R, p));
                vertex->Wa = Math.Mul(transformA, shapeA.GetVertex(vertex->IndexA));
                //Vec2 wBLocal;
                vertex->IndexB = shapeB.GetSupport(Math.MulT(transformB.R, -p));
                vertex->Wb = Math.Mul(transformB, shapeB.GetVertex(vertex->IndexB));
                vertex->W = vertex->Wb - vertex->Wa;

                // Iteration count is equated to the number of support point calls.
                ++iter;

                // Check for convergence.
                float lowerBound = Vector2.Dot(p, vertex->W);
                float upperBound = distanceSqr;
                const float kRelativeTolSqr = 0.01f * 0.01f; // 1:100
                if (upperBound - lowerBound <= kRelativeTolSqr * upperBound)
                {
                    // Converged!
                    break;
                }

                // Check for duplicate support points.
                bool duplicate = false;
                for (i = 0; i < lastCount; ++i)
                {
                    if ((vertex->IndexA == lastA[i]) && (vertex->IndexB == lastB[i]))
                    {
                        duplicate = true;
                        break;
                    }
                }

                // If we found a duplicate support point we must exit to avoid cycling.
                if (duplicate)
                {
                    break;
                }

                // New vertex is ok and needed.
                ++simplex.Count;
            }


            fixed (DistanceOutput* doPtr = &output)
            {
                // Prepare output.
                simplex.GetWitnessPoints(&doPtr->PointA, &doPtr->PointB);
                doPtr->Distance = Vector2.Distance(doPtr->PointA, doPtr->PointB);
                doPtr->Iterations = iter;
            }

            fixed (SimplexCache* sPtr = &cache)
            {
                // Cache the simplex.
                simplex.WriteCache(sPtr);
            }

            // Apply radii if requested.
            if (input.UseRadii)
            {
                float rA = shapeA.GetRadius();
                float rB = shapeB.GetRadius();

                if ((output.Distance > rA + rB) && (output.Distance > Settings.FltEpsilon))
                {
                    // Shapes are still no overlapped.
                    // Move the witness points to the outer surface.
                    output.Distance -= rA + rB;
                    Vector2 normal = output.PointB - output.PointA;
                    normal.Normalize();
                    output.PointA += rA * normal;
                    output.PointB -= rB * normal;
                }
                else
                {
                    // Shapes are overlapped when radii are considered.
                    // Move the witness points to the middle.
                    Vector2 p = 0.5f * (output.PointA + output.PointB);
                    output.PointA = p;
                    output.PointB = p;
                    output.Distance = 0.0f;
                }
            }
        }

        // CCD via the secant method.
        /// <summary>
        ///     Compute the time when two shapes begin to touch or touch at a closer distance.
        ///     TOI considers the shape radii. It attempts to have the radii overlap by the tolerance.
        ///     Iterations terminate with the overlap is within 0.5 * tolerance. The tolerance should be
        ///     smaller than sum of the shape radii.
        ///     Warning the sweeps must have the same time interval.
        /// </summary>
        /// <returns>
        ///     The fraction between [0,1] in which the shapes first touch.
        ///     fraction=0 means the shapes begin touching/overlapped, and fraction=1 means the shapes don't touch.
        /// </returns>
        public static float TimeOfImpact(ToiInput input, IShape shapeA, IShape shapeB)
        {
            Sweep sweepA = input.SweepA;
            Sweep sweepB = input.SweepB;

            Box2DxDebug.Assert(sweepA.T0 == sweepB.T0);
            Box2DxDebug.Assert(1.0f - sweepA.T0 > Settings.FltEpsilon);

            float radius = shapeA.GetRadius() + shapeB.GetRadius();
            float tolerance = input.Tolerance;

            float alpha = 0.0f;

            const int kMaxIterations = 1000; // TODO_ERIN b2Settings
            int iter = 0;
            float target = 0.0f;

            // Prepare input for distance query.
            SimplexCache cache = new SimplexCache();
            cache.Count = 0;
            DistanceInput distanceInput;
            distanceInput.UseRadii = false;

            for (;;)
            {
                XForm xfA, xfB;
                sweepA.GetTransform(out xfA, alpha);
                sweepB.GetTransform(out xfB, alpha);

                // Get the distance between shapes.
                distanceInput.TransformA = xfA;
                distanceInput.TransformB = xfB;
                DistanceOutput distanceOutput;
                Distance(out distanceOutput, ref cache, ref distanceInput, shapeA, shapeB);

                if (distanceOutput.Distance <= 0.0f)
                {
                    alpha = 1.0f;
                    break;
                }

                SeparationFunction fcn = new SeparationFunction();
                unsafe
                {
                    fcn.Initialize(&cache, shapeA, xfA, shapeB, xfB);
                }

                float separation = fcn.Evaluate(xfA, xfB);
                if (separation <= 0.0f)
                {
                    alpha = 1.0f;
                    break;
                }

                if (iter == 0)
                {
                    // Compute a reasonable target distance to give some breathing room
                    // for conservative advancement. We take advantage of the shape radii
                    // to create additional clearance.
                    if (separation > radius)
                    {
                        target = Math.Max(radius - tolerance, 0.75f * radius);
                    }
                    else
                    {
                        target = Math.Max(separation - tolerance, 0.02f * radius);
                    }
                }

                if (separation - target < 0.5f * tolerance)
                {
                    if (iter == 0)
                    {
                        alpha = 1.0f;
                    }

                    break;
                }

#if _FALSE
				// Dump the curve seen by the root finder
				{
					const int32 N = 100;
					float32 dx = 1.0f / N;
					float32 xs[N+1];
					float32 fs[N+1];

					float32 x = 0.0f;

					for (int32 i = 0; i <= N; ++i)
					{
						sweepA.GetTransform(&xfA, x);
						sweepB.GetTransform(&xfB, x);
						float32 f = fcn.Evaluate(xfA, xfB) - target;

						printf("%g %g\n", x, f);

						xs[i] = x;
						fs[i] = f;

						x += dx;
					}
				}
#endif

                // Compute 1D root of: f(x) - target = 0
                float newAlpha = alpha;
                {
                    float x1 = alpha, x2 = 1.0f;

                    float f1 = separation;

                    sweepA.GetTransform(out xfA, x2);
                    sweepB.GetTransform(out xfB, x2);
                    float f2 = fcn.Evaluate(xfA, xfB);

                    // If intervals don't overlap at t2, then we are done.
                    if (f2 >= target)
                    {
                        alpha = 1.0f;
                        break;
                    }

                    // Determine when intervals intersect.
                    int rootIterCount = 0;
                    for (;;)
                    {
                        // Use a mix of the secant rule and bisection.
                        float x;
                        if ((rootIterCount & 1) != 0)
                        {
                            // Secant rule to improve convergence.
                            x = x1 + (target - f1) * (x2 - x1) / (f2 - f1);
                        }
                        else
                        {
                            // Bisection to guarantee progress.
                            x = 0.5f * (x1 + x2);
                        }

                        sweepA.GetTransform(out xfA, x);
                        sweepB.GetTransform(out xfB, x);

                        float f = fcn.Evaluate(xfA, xfB);

                        if (Math.Abs(f - target) < 0.025f * tolerance)
                        {
                            newAlpha = x;
                            break;
                        }

                        // Ensure we continue to bracket the root.
                        if (f > target)
                        {
                            x1 = x;
                            f1 = f;
                        }
                        else
                        {
                            x2 = x;
                            f2 = f;
                        }

                        ++rootIterCount;

                        Box2DxDebug.Assert(rootIterCount < 50);
                    }

                    MaxToiRootIters = Math.Max(MaxToiRootIters, rootIterCount);
                }

                // Ensure significant advancement.
                if (newAlpha < (1.0f + 100.0f * Settings.FltEpsilon) * alpha)
                {
                    break;
                }

                alpha = newAlpha;

                ++iter;

                if (iter == kMaxIterations)
                {
                    break;
                }
            }

            MaxToiIters = Math.Max(MaxToiIters, iter);

            return alpha;
        }
    }
}