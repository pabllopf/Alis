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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Transform = Alis.Core.Physic.Common.Transform;


namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     Collision methods
    /// </summary>
    public static class Collision
    {
        /// <summary>
        ///     Test overlap between the two shapes.
        /// </summary>
        /// <param name="shapeA">The first shape.</param>
        /// <param name="indexA">The index for the first shape.</param>
        /// <param name="shapeB">The second shape.</param>
        /// <param name="indexB">The index for the second shape.</param>
        /// <param name="xfA">The transform for the first shape.</param>
        /// <param name="xfB">The transform for the seconds shape.</param>
        /// <returns></returns>
        public static bool TestOverlap(Shape shapeA, int indexA, Shape shapeB, int indexB, ref Transform xfA, ref Transform xfB)
        {
            DistanceInput _input = new DistanceInput();
            _input.ProxyA = new DistanceProxy(shapeA, indexA);
            _input.ProxyB = new DistanceProxy(shapeB, indexB);
            _input.TransformA = xfA;
            _input.TransformB = xfB;
            _input.UseRadii = true;

            Distance.ComputeDistance(out DistanceOutput output, out SimplexCache _, _input);

            return output.Distance < 10.0f * SettingEnv.Epsilon;
        }

        /// <summary>
        ///     Gets the point states using the specified state 1
        /// </summary>
        /// <param name="state1">The state</param>
        /// <param name="state2">The state</param>
        /// <param name="manifold1">The manifold</param>
        /// <param name="manifold2">The manifold</param>
        public static void GetPointStates(out FixedArray2<PointState> state1, out FixedArray2<PointState> state2, ref Manifold manifold1, ref Manifold manifold2)
        {
            state1 = new FixedArray2<PointState>();
            state2 = new FixedArray2<PointState>();

            // Detect persists and removes.
            for (int i = 0; i < manifold1.PointCount; ++i)
            {
                ContactID id = manifold1.Points[i].Id;

                state1[i] = PointState.Remove;

                for (int j = 0; j < manifold2.PointCount; ++j)
                {
                    if (manifold2.Points[j].Id.Key == id.Key)
                    {
                        state1[i] = PointState.Persist;
                        break;
                    }
                }
            }

            // Detect persists and adds.
            for (int i = 0; i < manifold2.PointCount; ++i)
            {
                ContactID id = manifold2.Points[i].Id;

                state2[i] = PointState.Add;

                for (int j = 0; j < manifold1.PointCount; ++j)
                {
                    if (manifold1.Points[j].Id.Key == id.Key)
                    {
                        state2[i] = PointState.Persist;
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     Compute the collision manifold between two circles.
        /// </summary>
        public static void CollideCircles(ref Manifold manifold, CircleShape circleA, ref Transform xfA, CircleShape circleB, ref Transform xfB)
        {
            manifold.PointCount = 0;

            Vector2F pA = Transform.Multiply(ref circleA.PositionInternal, ref xfA);
            Vector2F pB = Transform.Multiply(ref circleB.PositionInternal, ref xfB);

            Vector2F d = pB - pA;
            float distSqr = Vector2F.Dot(d, d);
            float radius = circleA.GetRadius + circleB.GetRadius;
            if (distSqr > radius * radius)
            {
                return;
            }

            manifold.Type = ManifoldType.Circles;
            manifold.LocalPoint = circleA.Position;
            manifold.LocalNormal = Vector2F.Zero;
            manifold.PointCount = 1;

            ManifoldPoint p0 = manifold.Points[0];

            p0.LocalPoint = circleB.Position;
            p0.Id.Key = 0;

            manifold.Points[0] = p0;
        }

        /// <summary>
        ///     Compute the collision manifold between a polygon and a circle.
        /// </summary>
        /// <param name="manifold">The manifold.</param>
        /// <param name="polygonA">The polygon A.</param>
        /// <param name="xfA">The transform of A.</param>
        /// <param name="circleB">The circle B.</param>
        /// <param name="xfB">The transform of B.</param>
        public static void CollidePolygonAndCircle(ref Manifold manifold, PolygonShape polygonA, ref Transform xfA, CircleShape circleB, ref Transform xfB)
        {
            manifold.PointCount = 0;

            // Compute circle position in the frame of the polygon.
            Vector2F c = Transform.Multiply(ref circleB.PositionInternal, ref xfB);
            Vector2F cLocal = Transform.Divide(ref c, ref xfA);

            // Find the min separating edge.
            int normalIndex = 0;
            float separation = -SettingEnv.MaxFloat;
            float radius = polygonA.GetRadius + circleB.GetRadius;
            int vertexCount = polygonA.Vertices.Count;

            for (int i = 0; i < vertexCount; ++i)
            {
                Vector2F value1 = polygonA.Normals[i];
                Vector2F value2 = cLocal - polygonA.Vertices[i];
                float s = value1.X * value2.X + value1.Y * value2.Y;

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
            Vector2F v1 = polygonA.Vertices[vertIndex1];
            Vector2F v2 = polygonA.Vertices[vertIndex2];

            // If the center is inside the polygon ...
            if (separation < SettingEnv.Epsilon)
            {
                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = polygonA.Normals[normalIndex];
                manifold.LocalPoint = 0.5f * (v1 + v2);

                ManifoldPoint p0 = manifold.Points[0];

                p0.LocalPoint = circleB.Position;
                p0.Id.Key = 0;

                manifold.Points[0] = p0;

                return;
            }

            // Compute barycentric coordinates
            float u1 = (cLocal.X - v1.X) * (v2.X - v1.X) + (cLocal.Y - v1.Y) * (v2.Y - v1.Y);
            float u2 = (cLocal.X - v2.X) * (v1.X - v2.X) + (cLocal.Y - v2.Y) * (v1.Y - v2.Y);

            if (u1 <= 0.0f)
            {
                float r = (cLocal.X - v1.X) * (cLocal.X - v1.X) + (cLocal.Y - v1.Y) * (cLocal.Y - v1.Y);
                if (r > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = cLocal - v1;
                float factor = 1f /
                               (float)
                               Math.Sqrt(manifold.LocalNormal.X * manifold.LocalNormal.X +
                                         manifold.LocalNormal.Y * manifold.LocalNormal.Y);
                manifold.LocalNormal.X = manifold.LocalNormal.X * factor;
                manifold.LocalNormal.Y = manifold.LocalNormal.Y * factor;
                manifold.LocalPoint = v1;

                ManifoldPoint p0b = manifold.Points[0];

                p0b.LocalPoint = circleB.Position;
                p0b.Id.Key = 0;

                manifold.Points[0] = p0b;
            }
            else if (u2 <= 0.0f)
            {
                float r = (cLocal.X - v2.X) * (cLocal.X - v2.X) + (cLocal.Y - v2.Y) * (cLocal.Y - v2.Y);
                if (r > radius * radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = cLocal - v2;
                float factor = 1f /
                               (float)
                               Math.Sqrt(manifold.LocalNormal.X * manifold.LocalNormal.X +
                                         manifold.LocalNormal.Y * manifold.LocalNormal.Y);
                manifold.LocalNormal.X = manifold.LocalNormal.X * factor;
                manifold.LocalNormal.Y = manifold.LocalNormal.Y * factor;
                manifold.LocalPoint = v2;

                ManifoldPoint p0c = manifold.Points[0];

                p0c.LocalPoint = circleB.Position;
                p0c.Id.Key = 0;

                manifold.Points[0] = p0c;
            }
            else
            {
                Vector2F faceCenter = 0.5f * (v1 + v2);
                Vector2F value1 = cLocal - faceCenter;
                Vector2F value2 = polygonA.Normals[vertIndex1];
                float separation2 = value1.X * value2.X + value1.Y * value2.Y;
                if (separation2 > radius)
                {
                    return;
                }

                manifold.PointCount = 1;
                manifold.Type = ManifoldType.FaceA;
                manifold.LocalNormal = polygonA.Normals[vertIndex1];
                manifold.LocalPoint = faceCenter;

                ManifoldPoint p0d = manifold.Points[0];

                p0d.LocalPoint = circleB.Position;
                p0d.Id.Key = 0;

                manifold.Points[0] = p0d;
            }
        }

        /// <summary>
        ///     Compute the collision manifold between two polygons.
        /// </summary>
        /// <param name="manifold">The manifold.</param>
        /// <param name="polyA">The poly A.</param>
        /// <param name="transformA">The transform A.</param>
        /// <param name="polyB">The poly B.</param>
        /// <param name="transformB">The transform B.</param>
        public static void CollidePolygons(ref Manifold manifold, PolygonShape polyA, ref Transform transformA, PolygonShape polyB, ref Transform transformB)
        {
            manifold.PointCount = 0;
            float totalRadius = polyA.GetRadius + polyB.GetRadius;

            float separationA = FindMaxSeparation(out int edgeA, polyA, ref transformA, polyB, ref transformB);
            if (separationA > totalRadius)
            {
                return;
            }

            float separationB = FindMaxSeparation(out int edgeB, polyB, ref transformB, polyA, ref transformA);
            if (separationB > totalRadius)
            {
                return;
            }

            PolygonShape poly1; // reference polygon
            PolygonShape poly2; // incident polygon
            Transform xf1, xf2;
            int edge1; // reference edge
            bool flip;
            const float k_relativeTol = 0.98f;
            const float k_absoluteTol = 0.001f;

            if (separationB > k_relativeTol * separationA + k_absoluteTol)
            {
                poly1 = polyB;
                poly2 = polyA;
                xf1 = transformB;
                xf2 = transformA;
                edge1 = edgeB;
                manifold.Type = ManifoldType.FaceB;
                flip = true;
            }
            else
            {
                poly1 = polyA;
                poly2 = polyB;
                xf1 = transformA;
                xf2 = transformB;
                edge1 = edgeA;
                manifold.Type = ManifoldType.FaceA;
                flip = false;
            }

            FindIncidentEdge(out FixedArray2<ClipVertex> incidentEdge, poly1, ref xf1, edge1, poly2, ref xf2);

            int count1 = poly1.Vertices.Count;

            int iv1 = edge1;
            int iv2 = edge1 + 1 < count1 ? edge1 + 1 : 0;

            Vector2F v11 = poly1.Vertices[iv1];
            Vector2F v12 = poly1.Vertices[iv2];

            Vector2F localTangent = v12 - v11;
            localTangent.Normalize();

            Vector2F localNormal = new Vector2F(localTangent.Y, -localTangent.X);
            Vector2F planePoint = 0.5f * (v11 + v12);

            Vector2F tangent = Complex.Multiply(ref localTangent, ref xf1.q);

            float normalx = tangent.Y;
            float normaly = -tangent.X;

            v11 = Transform.Multiply(ref v11, ref xf1);
            v12 = Transform.Multiply(ref v12, ref xf1);

            // Face offset.
            float frontOffset = normalx * v11.X + normaly * v11.Y;

            // Side offsets, extended by polytope skin thickness.
            float sideOffset1 = -(tangent.X * v11.X + tangent.Y * v11.Y) + totalRadius;
            float sideOffset2 = tangent.X * v12.X + tangent.Y * v12.Y + totalRadius;

            // Clip incident edge against extruded edge1 side edges.

            // Clip to box side 1
            int np = ClipSegmentToLine(out FixedArray2<ClipVertex> clipPoints1, ref incidentEdge, -tangent, sideOffset1, iv1);

            if (np < 2)
            {
                return;
            }

            // Clip to negative box side 1
            np = ClipSegmentToLine(out FixedArray2<ClipVertex> clipPoints2, ref clipPoints1, tangent, sideOffset2, iv2);

            if (np < 2)
            {
                return;
            }

            // Now clipPoints2 contains the clipped points.
            manifold.LocalNormal = localNormal;
            manifold.LocalPoint = planePoint;

            int pointCount = 0;
            for (int i = 0; i < SettingEnv.MaxManifoldPoints; ++i)
            {
                Vector2F value = clipPoints2[i].V;
                float separation = normalx * value.X + normaly * value.Y - frontOffset;

                if (separation <= totalRadius)
                {
                    ManifoldPoint cp = manifold.Points[pointCount];
                    Transform.Divide(clipPoints2[i].V, ref xf2, out cp.LocalPoint);
                    cp.Id = clipPoints2[i].ID;

                    if (flip)
                    {
                        // Swap features
                        ContactFeature cf = cp.Id.Features;
                        cp.Id.Features.IndexA = cf.IndexB;
                        cp.Id.Features.IndexB = cf.IndexA;
                        cp.Id.Features.TypeA = cf.TypeB;
                        cp.Id.Features.TypeB = cf.TypeA;
                    }

                    manifold.Points[pointCount] = cp;

                    ++pointCount;
                }
            }

            manifold.PointCount = pointCount;
        }

        /// <summary>
        ///     Compute contact points for edge versus circle.
        ///     This accounts for edge connectivity.
        /// </summary>
        /// <param name="manifold">The manifold.</param>
        /// <param name="edgeA">The edge A.</param>
        /// <param name="transformA">The transform A.</param>
        /// <param name="circleB">The circle B.</param>
        /// <param name="transformB">The transform B.</param>
        public static void CollideEdgeAndCircle(ref Manifold manifold, EdgeShape edgeA, ref Transform transformA, CircleShape circleB, ref Transform transformB)
        {
            manifold.PointCount = 0;

            // Compute circle in frame of edge
            Vector2F Q = Transform.Divide(Transform.Multiply(ref circleB.PositionInternal, ref transformB), ref transformA);

            Vector2F A = edgeA.Vertex1, B = edgeA.Vertex2;
            Vector2F e = B - A;

            // Barycentric coordinates
            float u = Vector2F.Dot(e, B - Q);
            float v = Vector2F.Dot(e, Q - A);

            float radius = edgeA.GetRadius + circleB.GetRadius;

            ContactFeature cf;
            cf.IndexB = 0;
            cf.TypeB = (byte) ContactFeatureType.Vertex;

            Vector2F P, d;

            // Region A
            if (v <= 0.0f)
            {
                P = A;
                d = Q - P;
                Vector2F.Dot(ref d, ref d, out float dd);
                if (dd > radius * radius)
                {
                    return;
                }

                // Is there an edge connected to A?
                if (edgeA.HasVertex0)
                {
                    Vector2F A1 = edgeA.Vertex0;
                    Vector2F B1 = A;
                    Vector2F e1 = B1 - A1;
                    float u1 = Vector2F.Dot(e1, B1 - Q);

                    // Is the circle in Region AB of the previous edge?
                    if (u1 > 0.0f)
                    {
                        return;
                    }
                }

                cf.IndexA = 0;
                cf.TypeA = (byte) ContactFeatureType.Vertex;
                manifold.PointCount = 1;
                manifold.Type = ManifoldType.Circles;
                manifold.LocalNormal = Vector2F.Zero;
                manifold.LocalPoint = P;
                ManifoldPoint mp = new ManifoldPoint();
                mp.Id.Key = 0;
                mp.Id.Features = cf;
                mp.LocalPoint = circleB.Position;
                manifold.Points[0] = mp;
                return;
            }

            // Region B
            if (u <= 0.0f)
            {
                P = B;
                d = Q - P;
                Vector2F.Dot(ref d, ref d, out float dd);
                if (dd > radius * radius)
                {
                    return;
                }

                // Is there an edge connected to B?
                if (edgeA.HasVertex3)
                {
                    Vector2F B2 = edgeA.Vertex3;
                    Vector2F A2 = B;
                    Vector2F e2 = B2 - A2;
                    float v2 = Vector2F.Dot(e2, Q - A2);

                    // Is the circle in Region AB of the next edge?
                    if (v2 > 0.0f)
                    {
                        return;
                    }
                }

                cf.IndexA = 1;
                cf.TypeA = (byte) ContactFeatureType.Vertex;
                manifold.PointCount = 1;
                manifold.Type = ManifoldType.Circles;
                manifold.LocalNormal = Vector2F.Zero;
                manifold.LocalPoint = P;
                ManifoldPoint mp = new ManifoldPoint();
                mp.Id.Key = 0;
                mp.Id.Features = cf;
                mp.LocalPoint = circleB.Position;
                manifold.Points[0] = mp;
                return;
            }

            // Region AB
            Vector2F.Dot(ref e, ref e, out float den);
            Debug.Assert(den > 0.0f);
            P = 1.0f / den * (u * A + v * B);
            d = Q - P;
            Vector2F.Dot(ref d, ref d, out float dd2);
            if (dd2 > radius * radius)
            {
                return;
            }

            Vector2F n = new Vector2F(-e.Y, e.X);
            if (Vector2F.Dot(n, Q - A) < 0.0f)
            {
                n = new Vector2F(-n.X, -n.Y);
            }

            n.Normalize();

            cf.IndexA = 0;
            cf.TypeA = (byte) ContactFeatureType.Face;
            manifold.PointCount = 1;
            manifold.Type = ManifoldType.FaceA;
            manifold.LocalNormal = n;
            manifold.LocalPoint = A;
            ManifoldPoint mp2 = new ManifoldPoint();
            mp2.Id.Key = 0;
            mp2.Id.Features = cf;
            mp2.LocalPoint = circleB.Position;
            manifold.Points[0] = mp2;
        }

        /// <summary>
        ///     Collides and edge and a polygon, taking into account edge adjacency.
        /// </summary>
        /// <param name="manifold">The manifold.</param>
        /// <param name="edgeA">The edge A.</param>
        /// <param name="xfA">The xf A.</param>
        /// <param name="polygonB">The polygon B.</param>
        /// <param name="xfB">The xf B.</param>
        public static void CollideEdgeAndPolygon(ref Manifold manifold, EdgeShape edgeA, ref Transform xfA, PolygonShape polygonB, ref Transform xfB)
        {
            EPCollider.Collide(ref manifold, edgeA, ref xfA, polygonB, ref xfB);
        }

        /// <summary>
        ///     Clipping for contact manifolds.
        /// </summary>
        /// <param name="vOut">The v out.</param>
        /// <param name="vIn">The v in.</param>
        /// <param name="normal">The normal.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="vertexIndexA">The vertex index A.</param>
        /// <returns></returns>
        private static int ClipSegmentToLine(out FixedArray2<ClipVertex> vOut, ref FixedArray2<ClipVertex> vIn, Vector2F normal, float offset, int vertexIndexA)
        {
            vOut = new FixedArray2<ClipVertex>();

            ClipVertex v0 = vIn[0];
            ClipVertex v1 = vIn[1];

            // Start with no output points
            int numOut = 0;

            // Calculate the distance of end points to the line
            float distance0 = normal.X * v0.V.X + normal.Y * v0.V.Y - offset;
            float distance1 = normal.X * v1.V.X + normal.Y * v1.V.Y - offset;

            // If the points are behind the plane
            if (distance0 <= 0.0f)
            {
                vOut[numOut++] = v0;
            }

            if (distance1 <= 0.0f)
            {
                vOut[numOut++] = v1;
            }

            // If the points are on different sides of the plane
            if (distance0 * distance1 < 0.0f)
            {
                // Find intersection point of edge and plane
                float interp = distance0 / (distance0 - distance1);

                ClipVertex cv = vOut[numOut];

                cv.V.X = v0.V.X + interp * (v1.V.X - v0.V.X);
                cv.V.Y = v0.V.Y + interp * (v1.V.Y - v0.V.Y);

                // VertexA is hitting edgeB.
                cv.ID.Features.IndexA = (byte) vertexIndexA;
                cv.ID.Features.IndexB = v0.ID.Features.IndexB;
                cv.ID.Features.TypeA = (byte) ContactFeatureType.Vertex;
                cv.ID.Features.TypeB = (byte) ContactFeatureType.Face;

                vOut[numOut] = cv;

                ++numOut;
            }

            return numOut;
        }

        /// <summary>
        ///     Find the separation between poly1 and poly2 for a give edge normal on poly1.
        /// </summary>
        /// <param name="poly1">The poly1.</param>
        /// <param name="xf1">The XF1.</param>
        /// <param name="edge1">The edge1.</param>
        /// <param name="poly2">The poly2.</param>
        /// <param name="xf2">The XF2.</param>
        /// <returns></returns>
        private static float EdgeSeparation(PolygonShape poly1, ref Transform xf1To2, int edge1, PolygonShape poly2)
        {
            List<Vector2F> vertices1 = poly1.Vertices;
            List<Vector2F> normals1 = poly1.Normals;

            int count2 = poly2.Vertices.Count;
            List<Vector2F> vertices2 = poly2.Vertices;

            Debug.Assert((0 <= edge1) && (edge1 < poly1.Vertices.Count));

            // Convert normal from poly1's frame into poly2's frame.
            Vector2F normal1 = Complex.Multiply(normals1[edge1], ref xf1To2.q);

            // Find support vertex on poly2 for -normal.
            int index = 0;
            float minDot = SettingEnv.MaxFloat;

            for (int i = 0; i < count2; ++i)
            {
                float dot = MathUtils.Dot(vertices2[i], ref normal1);
                if (dot < minDot)
                {
                    minDot = dot;
                    index = i;
                }
            }

            Vector2F v1 = Transform.Multiply(vertices1[edge1], ref xf1To2);
            Vector2F v2 = vertices2[index];
            float separation = MathUtils.Dot(v2 - v1, ref normal1);

            return separation;
        }

        /// <summary>
        ///     Find the max separation between poly1 and poly2 using edge normals from poly1.
        /// </summary>
        /// <param name="edgeIndex">Index of the edge.</param>
        /// <param name="poly1">The poly1.</param>
        /// <param name="xf1">The XF1.</param>
        /// <param name="poly2">The poly2.</param>
        /// <param name="xf2">The XF2.</param>
        /// <returns></returns>
        private static float FindMaxSeparation(out int edgeIndex, PolygonShape poly1, ref Transform xf1, PolygonShape poly2, ref Transform xf2)
        {
            int count1 = poly1.Vertices.Count;
            List<Vector2F> normals1 = poly1.Normals;

            Transform xf1To2 = Transform.Divide(ref xf1, ref xf2);

            // Vector pointing from the centroid of poly1 to the centroid of poly2.
            Vector2F c2local = Transform.Divide(poly2.MassData.Centroid, ref xf1To2);
            Vector2F dLocal1 = c2local - poly1.MassData.Centroid;

            // Find edge normal on poly1 that has the largest projection onto d.
            int edge = 0;
            float maxDot = -SettingEnv.MaxFloat;
            for (int i = 0; i < count1; ++i)
            {
                float dot = MathUtils.Dot(normals1[i], ref dLocal1);
                if (dot > maxDot)
                {
                    maxDot = dot;
                    edge = i;
                }
            }

            // Get the separation for the edge normal.
            float s = EdgeSeparation(poly1, ref xf1To2, edge, poly2);

            // Check the separation for the previous edge normal.
            int prevEdge = edge - 1 >= 0 ? edge - 1 : count1 - 1;
            float sPrev = EdgeSeparation(poly1, ref xf1To2, prevEdge, poly2);

            // Check the separation for the next edge normal.
            int nextEdge = edge + 1 < count1 ? edge + 1 : 0;
            float sNext = EdgeSeparation(poly1, ref xf1To2, nextEdge, poly2);

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

                s = EdgeSeparation(poly1, ref xf1To2, edge, poly2);

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
        private static void FindIncidentEdge(out FixedArray2<ClipVertex> c, PolygonShape poly1, ref Transform xf1, int edge1, PolygonShape poly2, ref Transform xf2)
        {
            c = new FixedArray2<ClipVertex>();
            Vertices normals1 = poly1.Normals;

            int count2 = poly2.Vertices.Count;
            Vertices vertices2 = poly2.Vertices;
            Vertices normals2 = poly2.Normals;

            Debug.Assert((0 <= edge1) && (edge1 < poly1.Vertices.Count));

            // Get the normal of the reference edge in poly2's frame.
            Vector2F normal1 = Complex.Divide(Complex.Multiply(normals1[edge1], ref xf1.q), ref xf2.q);


            // Find the incident edge on poly2.
            int index = 0;
            float minDot = SettingEnv.MaxFloat;
            for (int i = 0; i < count2; ++i)
            {
                float dot = Vector2F.Dot(normal1, normals2[i]);
                if (dot < minDot)
                {
                    minDot = dot;
                    index = i;
                }
            }

            // Build the clip vertices for the incident edge.
            int i1 = index;
            int i2 = i1 + 1 < count2 ? i1 + 1 : 0;

            ClipVertex cv0 = c[0];

            cv0.V = Transform.Multiply(vertices2[i1], ref xf2);
            cv0.ID.Features.IndexA = (byte) edge1;
            cv0.ID.Features.IndexB = (byte) i1;
            cv0.ID.Features.TypeA = (byte) ContactFeatureType.Face;
            cv0.ID.Features.TypeB = (byte) ContactFeatureType.Vertex;

            c[0] = cv0;

            ClipVertex cv1 = c[1];
            cv1.V = Transform.Multiply(vertices2[i2], ref xf2);
            cv1.ID.Features.IndexA = (byte) edge1;
            cv1.ID.Features.IndexB = (byte) i2;
            cv1.ID.Features.TypeA = (byte) ContactFeatureType.Face;
            cv1.ID.Features.TypeB = (byte) ContactFeatureType.Vertex;

            c[1] = cv1;
        }

        /// <summary>
        ///     The ep collider class
        /// </summary>
        private static class EPCollider
        {
            /// <summary>
            ///     Collides the manifold
            /// </summary>
            /// <param name="manifold">The manifold</param>
            /// <param name="edgeA">The edge</param>
            /// <param name="xfA">The xf</param>
            /// <param name="polygonB">The polygon</param>
            /// <param name="xfB">The xf</param>
            public static void Collide(ref Manifold manifold, EdgeShape edgeA, ref Transform xfA, PolygonShape polygonB, ref Transform xfB)
            {
                // Algorithm:
                // 1. Classify v1 and v2
                // 2. Classify polygon centroid as front or back
                // 3. Flip normal if necessary
                // 4. Initialize normal range to [-pi, pi] about face normal
                // 5. Adjust normal range according to adjacent edges
                // 6. Visit each separating axes, only accept axes within the range
                // 7. Return if _any_ axis indicates separation
                // 8. Clip

                TempPolygon tempPolygonB = new TempPolygon(SettingEnv.MaxPolygonVertices);
                Vector2F centroidB;
                Vector2F normal0 = new Vector2F();
                Vector2F normal1;
                Vector2F normal2 = new Vector2F();
                Vector2F normal;
                Vector2F lowerLimit, upperLimit;
                float radius;
                bool front;

                Transform.Divide(ref xfB, ref xfA, out Transform xf);

                centroidB = Transform.Multiply(polygonB.MassData.Centroid, ref xf);

                Vector2F v0 = edgeA.Vertex0;
                Vector2F v1 = edgeA.Vertex11;
                Vector2F v2 = edgeA.Vertex22;
                Vector2F v3 = edgeA.Vertex3;

                bool hasVertex0 = edgeA.HasVertex0;
                bool hasVertex3 = edgeA.HasVertex3;

                Vector2F edge1 = v2 - v1;
                edge1.Normalize();
                normal1 = new Vector2F(edge1.Y, -edge1.X);
                float offset1 = Vector2F.Dot(normal1, centroidB - v1);
                float offset0 = 0.0f, offset2 = 0.0f;
                bool convex1 = false, convex2 = false;

                // Is there a preceding edge?
                if (hasVertex0)
                {
                    Vector2F edge0 = v1 - v0;
                    edge0.Normalize();
                    normal0 = new Vector2F(edge0.Y, -edge0.X);
                    convex1 = MathUtils.Cross(ref edge0, ref edge1) >= 0.0f;
                    offset0 = Vector2F.Dot(normal0, centroidB - v0);
                }

                // Is there a following edge?
                if (hasVertex3)
                {
                    Vector2F edge2 = v3 - v2;
                    edge2.Normalize();
                    normal2 = new Vector2F(edge2.Y, -edge2.X);
                    convex2 = MathUtils.Cross(ref edge1, ref edge2) > 0.0f;
                    offset2 = Vector2F.Dot(normal2, centroidB - v2);
                }

                // Determine front or back collision. Determine collision normal limits.
                if (hasVertex0 && hasVertex3)
                {
                    if (convex1 && convex2)
                    {
                        front = offset0 >= 0.0f || offset1 >= 0.0f || offset2 >= 0.0f;
                        if (front)
                        {
                            normal = normal1;
                            lowerLimit = normal0;
                            upperLimit = normal2;
                        }
                        else
                        {
                            normal = -normal1;
                            lowerLimit = -normal1;
                            upperLimit = -normal1;
                        }
                    }
                    else if (convex1)
                    {
                        front = offset0 >= 0.0f || ((offset1 >= 0.0f) && (offset2 >= 0.0f));
                        if (front)
                        {
                            normal = normal1;
                            lowerLimit = normal0;
                            upperLimit = normal1;
                        }
                        else
                        {
                            normal = -normal1;
                            lowerLimit = -normal2;
                            upperLimit = -normal1;
                        }
                    }
                    else if (convex2)
                    {
                        front = offset2 >= 0.0f || ((offset0 >= 0.0f) && (offset1 >= 0.0f));
                        if (front)
                        {
                            normal = normal1;
                            lowerLimit = normal1;
                            upperLimit = normal2;
                        }
                        else
                        {
                            normal = -normal1;
                            lowerLimit = -normal1;
                            upperLimit = -normal0;
                        }
                    }
                    else
                    {
                        front = (offset0 >= 0.0f) && (offset1 >= 0.0f) && (offset2 >= 0.0f);
                        if (front)
                        {
                            normal = normal1;
                            lowerLimit = normal1;
                            upperLimit = normal1;
                        }
                        else
                        {
                            normal = -normal1;
                            lowerLimit = -normal2;
                            upperLimit = -normal0;
                        }
                    }
                }
                else if (hasVertex0)
                {
                    if (convex1)
                    {
                        front = offset0 >= 0.0f || offset1 >= 0.0f;
                        if (front)
                        {
                            normal = normal1;
                            lowerLimit = normal0;
                            upperLimit = -normal1;
                        }
                        else
                        {
                            normal = -normal1;
                            lowerLimit = normal1;
                            upperLimit = -normal1;
                        }
                    }
                    else
                    {
                        front = (offset0 >= 0.0f) && (offset1 >= 0.0f);
                        if (front)
                        {
                            normal = normal1;
                            lowerLimit = normal1;
                            upperLimit = -normal1;
                        }
                        else
                        {
                            normal = -normal1;
                            lowerLimit = normal1;
                            upperLimit = -normal0;
                        }
                    }
                }
                else if (hasVertex3)
                {
                    if (convex2)
                    {
                        front = offset1 >= 0.0f || offset2 >= 0.0f;
                        if (front)
                        {
                            normal = normal1;
                            lowerLimit = -normal1;
                            upperLimit = normal2;
                        }
                        else
                        {
                            normal = -normal1;
                            lowerLimit = -normal1;
                            upperLimit = normal1;
                        }
                    }
                    else
                    {
                        front = (offset1 >= 0.0f) && (offset2 >= 0.0f);
                        if (front)
                        {
                            normal = normal1;
                            lowerLimit = -normal1;
                            upperLimit = normal1;
                        }
                        else
                        {
                            normal = -normal1;
                            lowerLimit = -normal2;
                            upperLimit = normal1;
                        }
                    }
                }
                else
                {
                    front = offset1 >= 0.0f;
                    if (front)
                    {
                        normal = normal1;
                        lowerLimit = -normal1;
                        upperLimit = -normal1;
                    }
                    else
                    {
                        normal = -normal1;
                        lowerLimit = normal1;
                        upperLimit = normal1;
                    }
                }

                // Get polygonB in frameA
                tempPolygonB.Count = polygonB.Vertices.Count;
                for (int i = 0; i < polygonB.Vertices.Count; ++i)
                {
                    tempPolygonB.Vertices[i] = Transform.Multiply(polygonB.Vertices[i], ref xf);
                    tempPolygonB.Normals[i] = Complex.Multiply(polygonB.Normals[i], ref xf.q);
                }

                radius = 2.0f * SettingEnv.PolygonRadius;

                manifold.PointCount = 0;

                EPAxis edgeAxis = ComputeEdgeSeparation(ref tempPolygonB, ref normal, ref v1, front);

                // If no valid normal can be found than this edge should not collide.
                if (edgeAxis.Type == EPAxisType.Unknown)
                {
                    return;
                }

                if (edgeAxis.Separation > radius)
                {
                    return;
                }

                EPAxis polygonAxis = ComputePolygonSeparation(ref tempPolygonB, ref normal, ref v1, ref v2, ref lowerLimit, ref upperLimit, radius);
                if ((polygonAxis.Type != EPAxisType.Unknown) && (polygonAxis.Separation > radius))
                {
                    return;
                }

                // Use hysteresis for jitter reduction.
                const float k_relativeTol = 0.98f;
                const float k_absoluteTol = 0.001f;

                EPAxis primaryAxis;
                if (polygonAxis.Type == EPAxisType.Unknown)
                {
                    primaryAxis = edgeAxis;
                }
                else if (polygonAxis.Separation > k_relativeTol * edgeAxis.Separation + k_absoluteTol)
                {
                    primaryAxis = polygonAxis;
                }
                else
                {
                    primaryAxis = edgeAxis;
                }

                FixedArray2<ClipVertex> ie = new FixedArray2<ClipVertex>();
                ReferenceFace rf;
                if (primaryAxis.Type == EPAxisType.EdgeA)
                {
                    manifold.Type = ManifoldType.FaceA;

                    // Search for the polygon normal that is most anti-parallel to the edge normal.
                    int bestIndex = 0;
                    float bestValue = Vector2F.Dot(normal, tempPolygonB.Normals[0]);
                    for (int i = 1; i < tempPolygonB.Count; ++i)
                    {
                        float value = Vector2F.Dot(normal, tempPolygonB.Normals[i]);
                        if (value < bestValue)
                        {
                            bestValue = value;
                            bestIndex = i;
                        }
                    }

                    int i1 = bestIndex;
                    int i2 = i1 + 1 < tempPolygonB.Count ? i1 + 1 : 0;

                    ClipVertex c0 = ie[0];
                    c0.V = tempPolygonB.Vertices[i1];
                    c0.ID.Features.IndexA = 0;
                    c0.ID.Features.IndexB = (byte) i1;
                    c0.ID.Features.TypeA = (byte) ContactFeatureType.Face;
                    c0.ID.Features.TypeB = (byte) ContactFeatureType.Vertex;
                    ie[0] = c0;

                    ClipVertex c1 = ie[1];
                    c1.V = tempPolygonB.Vertices[i2];
                    c1.ID.Features.IndexA = 0;
                    c1.ID.Features.IndexB = (byte) i2;
                    c1.ID.Features.TypeA = (byte) ContactFeatureType.Face;
                    c1.ID.Features.TypeB = (byte) ContactFeatureType.Vertex;
                    ie[1] = c1;

                    if (front)
                    {
                        rf.i1 = 0;
                        rf.i2 = 1;
                        rf.v1 = v1;
                        rf.v2 = v2;
                        rf.normal = normal1;
                    }
                    else
                    {
                        rf.i1 = 1;
                        rf.i2 = 0;
                        rf.v1 = v2;
                        rf.v2 = v1;
                        rf.normal = -normal1;
                    }
                }
                else
                {
                    manifold.Type = ManifoldType.FaceB;
                    ClipVertex c0 = ie[0];
                    c0.V = v1;
                    c0.ID.Features.IndexA = 0;
                    c0.ID.Features.IndexB = (byte) primaryAxis.Index;
                    c0.ID.Features.TypeA = (byte) ContactFeatureType.Vertex;
                    c0.ID.Features.TypeB = (byte) ContactFeatureType.Face;
                    ie[0] = c0;

                    ClipVertex c1 = ie[1];
                    c1.V = v2;
                    c1.ID.Features.IndexA = 0;
                    c1.ID.Features.IndexB = (byte) primaryAxis.Index;
                    c1.ID.Features.TypeA = (byte) ContactFeatureType.Vertex;
                    c1.ID.Features.TypeB = (byte) ContactFeatureType.Face;
                    ie[1] = c1;

                    rf.i1 = primaryAxis.Index;
                    rf.i2 = rf.i1 + 1 < tempPolygonB.Count ? rf.i1 + 1 : 0;
                    rf.v1 = tempPolygonB.Vertices[rf.i1];
                    rf.v2 = tempPolygonB.Vertices[rf.i2];
                    rf.normal = tempPolygonB.Normals[rf.i1];
                }

                rf.sideNormal1 = new Vector2F(rf.normal.Y, -rf.normal.X);
                rf.sideNormal2 = -rf.sideNormal1;
                rf.sideOffset1 = Vector2F.Dot(rf.sideNormal1, rf.v1);
                rf.sideOffset2 = Vector2F.Dot(rf.sideNormal2, rf.v2);

                // Clip incident edge against extruded edge1 side edges.
                int np;

                // Clip to box side 1
                np = ClipSegmentToLine(out FixedArray2<ClipVertex> clipPoints1, ref ie, rf.sideNormal1, rf.sideOffset1, rf.i1);

                if (np < SettingEnv.MaxManifoldPoints)
                {
                    return;
                }

                // Clip to negative box side 1
                np = ClipSegmentToLine(out FixedArray2<ClipVertex> clipPoints2, ref clipPoints1, rf.sideNormal2, rf.sideOffset2, rf.i2);

                if (np < SettingEnv.MaxManifoldPoints)
                {
                    return;
                }

                // Now clipPoints2 contains the clipped points.
                if (primaryAxis.Type == EPAxisType.EdgeA)
                {
                    manifold.LocalNormal = rf.normal;
                    manifold.LocalPoint = rf.v1;
                }
                else
                {
                    manifold.LocalNormal = polygonB.Normals[rf.i1];
                    manifold.LocalPoint = polygonB.Vertices[rf.i1];
                }

                int pointCount = 0;
                for (int i = 0; i < SettingEnv.MaxManifoldPoints; ++i)
                {
                    float separation = Vector2F.Dot(rf.normal, clipPoints2[i].V - rf.v1);

                    if (separation <= radius)
                    {
                        ManifoldPoint cp = manifold.Points[pointCount];

                        if (primaryAxis.Type == EPAxisType.EdgeA)
                        {
                            Transform.Divide(clipPoints2[i].V, ref xf, out cp.LocalPoint);
                            cp.Id = clipPoints2[i].ID;
                        }
                        else
                        {
                            cp.LocalPoint = clipPoints2[i].V;
                            cp.Id.Features.TypeA = clipPoints2[i].ID.Features.TypeB;
                            cp.Id.Features.TypeB = clipPoints2[i].ID.Features.TypeA;
                            cp.Id.Features.IndexA = clipPoints2[i].ID.Features.IndexB;
                            cp.Id.Features.IndexB = clipPoints2[i].ID.Features.IndexA;
                        }

                        manifold.Points[pointCount] = cp;
                        ++pointCount;
                    }
                }

                manifold.PointCount = pointCount;
            }

            /// <summary>
            ///     Computes the edge separation using the specified polygon b
            /// </summary>
            /// <param name="polygonB">The polygon</param>
            /// <param name="normal">The normal</param>
            /// <param name="v1">The </param>
            /// <param name="front">The front</param>
            /// <returns>The axis</returns>
            private static EPAxis ComputeEdgeSeparation(ref TempPolygon polygonB, ref Vector2F normal, ref Vector2F v1, bool front)
            {
                EPAxis axis;
                axis.Type = EPAxisType.EdgeA;
                axis.Index = front ? 0 : 1;
                axis.Separation = SettingEnv.MaxFloat;

                for (int i = 0; i < polygonB.Count; ++i)
                {
                    float s = Vector2F.Dot(normal, polygonB.Vertices[i] - v1);
                    if (s < axis.Separation)
                    {
                        axis.Separation = s;
                    }
                }

                return axis;
            }

            /// <summary>
            ///     Computes the polygon separation using the specified polygon b
            /// </summary>
            /// <param name="polygonB">The polygon</param>
            /// <param name="normal">The normal</param>
            /// <param name="v1">The </param>
            /// <param name="v2">The </param>
            /// <param name="lowerLimit">The lower limit</param>
            /// <param name="upperLimit">The upper limit</param>
            /// <param name="radius">The radius</param>
            /// <returns>The axis</returns>
            private static EPAxis ComputePolygonSeparation(ref TempPolygon polygonB, ref Vector2F normal, ref Vector2F v1, ref Vector2F v2, ref Vector2F lowerLimit, ref Vector2F upperLimit, float radius)
            {
                EPAxis axis;
                axis.Type = EPAxisType.Unknown;
                axis.Index = -1;
                axis.Separation = -SettingEnv.MaxFloat;

                Vector2F perp = new Vector2F(-normal.Y, normal.X);

                for (int i = 0; i < polygonB.Count; ++i)
                {
                    Vector2F n = -polygonB.Normals[i];

                    float s1 = Vector2F.Dot(n, polygonB.Vertices[i] - v1);
                    float s2 = Vector2F.Dot(n, polygonB.Vertices[i] - v2);
                    float s = Math.Min(s1, s2);

                    if (s > radius)
                    {
                        // No collision
                        axis.Type = EPAxisType.EdgeB;
                        axis.Index = i;
                        axis.Separation = s;
                        return axis;
                    }

                    // Adjacency
                    if (Vector2F.Dot(n, perp) >= 0.0f)
                    {
                        if (Vector2F.Dot(n - upperLimit, normal) < -SettingEnv.AngularSlop)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (Vector2F.Dot(n - lowerLimit, normal) < -SettingEnv.AngularSlop)
                        {
                            continue;
                        }
                    }

                    if (s > axis.Separation)
                    {
                        axis.Type = EPAxisType.EdgeB;
                        axis.Index = i;
                        axis.Separation = s;
                    }
                }

                return axis;
            }

            /// <summary>
            ///     This holds polygon B expressed in frame A.
            /// </summary>
            internal struct TempPolygon
            {
                /// <summary>
                ///     The vertices
                /// </summary>
                public readonly Vector2F[] Vertices;

                /// <summary>
                ///     The normals
                /// </summary>
                public readonly Vector2F[] Normals;

                /// <summary>
                ///     The count
                /// </summary>
                public int Count;

                /// <summary>
                ///     Initializes a new instance of the <see cref="TempPolygon" /> class
                /// </summary>
                /// <param name="maxPolygonVertices">The max polygon vertices</param>
                internal TempPolygon(int maxPolygonVertices)
                {
                    Vertices = new Vector2F[maxPolygonVertices];
                    Normals = new Vector2F[maxPolygonVertices];
                    Count = 0;
                }
            }
        }
    }
}