// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollidePolygon.cs
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

using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Shared.Optimization;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Collision.NarrowPhase
{
    /// <summary>
    ///     The collide polygon class
    /// </summary>
    public static class CollidePolygon
    {
        /// <summary>Compute the collision manifold between two polygons.</summary>
        public static void CollidePolygons(ref Manifold manifold, PolygonShape polyA, ref Transform xfA,
            PolygonShape polyB, ref Transform xfB)
        {
            // Find edge normal of max separation on A - return if separating axis is found
            // Find edge normal of max separation on B - return if separation axis is found
            // Choose reference edge as min(minA, minB)
            // Find incident edge
            // Clip

            manifold.PointCount = 0;
            float totalRadius = polyA.RadiusPrivate + polyB.RadiusPrivate;

            float separationA = FindMaxSeparation(out int edgeA, polyA, ref xfA, polyB, ref xfB);
            if (separationA > totalRadius)
            {
                return;
            }

            float separationB = FindMaxSeparation(out int edgeB, polyB, ref xfB, polyA, ref xfA);
            if (separationB > totalRadius)
            {
                return;
            }

            PolygonShape poly1; // reference polygon
            PolygonShape poly2; // incident polygon
            Transform xf1, xf2;
            int edge1; // reference edge
            bool flip;
            float kTol = 0.1f * Settings.LinearSlop;

            if (separationB > separationA + kTol)
            {
                poly1 = polyB;
                poly2 = polyA;
                xf1 = xfB;
                xf2 = xfA;
                edge1 = edgeB;
                manifold.Type = ManifoldType.FaceB;
                flip = true;
            }
            else
            {
                poly1 = polyA;
                poly2 = polyB;
                xf1 = xfA;
                xf2 = xfB;
                edge1 = edgeA;
                manifold.Type = ManifoldType.FaceA;
                flip = false;
            }

            FindIncidentEdge(out FixedArray2<ClipVertex> incidentEdge, poly1, ref xf1, edge1, poly2, ref xf2);

            int count1 = poly1.VerticesPrivate.Count;
            Vertices vertices1 = poly1.VerticesPrivate;

            int iv1 = edge1;
            int iv2 = edge1 + 1 < count1 ? edge1 + 1 : 0;

            Vector2 v11 = vertices1[iv1];
            Vector2 v12 = vertices1[iv2];

            Vector2 localTangent = v12 - v11;
            localTangent = Vector2.Normalize(localTangent);

            Vector2 localNormal = MathUtils.Cross(localTangent, 1.0f);
            Vector2 planePoint = 0.5f * (v11 + v12);

            Vector2 tangent = MathUtils.Mul(ref xf1.Rotation, localTangent);
            Vector2 normal = MathUtils.Cross(tangent, 1.0f);

            v11 = MathUtils.Mul(ref xf1, v11);
            v12 = MathUtils.Mul(ref xf1, v12);

            // Face offset.
            float frontOffset = Vector2.Dot(normal, v11);

            // Side offsets, extended by polytope skin thickness.
            float sideOffset1 = -Vector2.Dot(tangent, v11) + totalRadius;
            float sideOffset2 = Vector2.Dot(tangent, v12) + totalRadius;

            // Clip incident edge against extruded edge1 side edges.

            // Clip to box side 1
            int np = Collision.ClipSegmentToLine(out FixedArray2<ClipVertex> clipPoints1, ref incidentEdge, -tangent,
                sideOffset1, iv1);

            if (np < 2)
            {
                return;
            }

            // Clip to negative box side 1
            np = Collision.ClipSegmentToLine(out FixedArray2<ClipVertex> clipPoints2, ref clipPoints1, tangent,
                sideOffset2, iv2);

            if (np < 2)
            {
                return;
            }

            // Now clipPoints2 contains the clipped points.
            manifold.LocalNormal = localNormal;
            manifold.LocalPoint = planePoint;

            int pointCount = 0;
            for (int i = 0; i < Settings.ManifoldPoints; ++i)
            {
                float separation = Vector2.Dot(normal, clipPoints2[i].V) - frontOffset;

                if (separation <= totalRadius)
                {
                    ManifoldPoint cp = manifold.Points[pointCount];
                    cp.LocalPoint = MathUtils.MulT(ref xf2, clipPoints2[i].V);
                    cp.Id = clipPoints2[i].Id;

                    if (flip)
                    {
                        // Swap features
                        ContactFeature cf = cp.Id.ContactFeature;
                        cp.Id.ContactFeature.IndexA = cf.IndexB;
                        cp.Id.ContactFeature.IndexB = cf.IndexA;
                        cp.Id.ContactFeature.TypeA = cf.TypeB;
                        cp.Id.ContactFeature.TypeB = cf.TypeA;
                    }

                    manifold.Points[pointCount] = cp;

                    ++pointCount;
                }
            }

            manifold.PointCount = pointCount;
        }

        /// <summary>Find the max separation between poly1 and poly2 using edge normals from poly1.</summary>
        private static float FindMaxSeparation(out int edgeIndex, PolygonShape poly1, ref Transform xf1,
            PolygonShape poly2, ref Transform xf2)
        {
            int count1 = poly1.VerticesPrivate.Count;
            int count2 = poly2.VerticesPrivate.Count;
            Vertices n1S = poly1.NormalsPrivate;
            Vertices v1S = poly1.VerticesPrivate;
            Vertices v2S = poly2.VerticesPrivate;
            Transform xf = MathUtils.MulT(xf2, xf1);

            int bestIndex = 0;
            float maxSeparation = -float.MaxValue;
            for (int i = 0; i < count1; ++i)
            {
                // Get poly1 normal in frame2.
                Vector2 n = MathUtils.Mul(ref xf.Rotation, n1S[i]);
                Vector2 v1 = MathUtils.Mul(ref xf, v1S[i]);

                // Find deepest point for normal i.
                float si = float.MaxValue;
                for (int j = 0; j < count2; ++j)
                {
                    float sij = Vector2.Dot(n, v2S[j] - v1);
                    if (sij < si)
                    {
                        si = sij;
                    }
                }

                if (si > maxSeparation)
                {
                    maxSeparation = si;
                    bestIndex = i;
                }
            }

            edgeIndex = bestIndex;
            return maxSeparation;
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
        private static void FindIncidentEdge(out FixedArray2<ClipVertex> c, PolygonShape poly1, ref Transform xf1,
            int edge1, PolygonShape poly2, ref Transform xf2)
        {
            Vertices normals1 = poly1.NormalsPrivate;

            int count2 = poly2.VerticesPrivate.Count;
            Vertices vertices2 = poly2.VerticesPrivate;
            Vertices normals2 = poly2.NormalsPrivate;

            Debug.Assert((0 <= edge1) && (edge1 < poly1.VerticesPrivate.Count));

            // Get the normal of the reference edge in poly2's frame.
            Vector2 normal1 = MathUtils.MulT(ref xf2.Rotation, MathUtils.Mul(ref xf1.Rotation, normals1[edge1]));

            // Find the incident edge on poly2.
            int index = 0;
            float minDot = float.MaxValue;
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

            c = new FixedArray2<ClipVertex>();
            c.Value0.V = MathUtils.Mul(ref xf2, vertices2[i1]);
            c.Value0.Id.ContactFeature.IndexA = (byte) edge1;
            c.Value0.Id.ContactFeature.IndexB = (byte) i1;
            c.Value0.Id.ContactFeature.TypeA = ContactFeatureType.Face;
            c.Value0.Id.ContactFeature.TypeB = ContactFeatureType.Vertex;

            c.Value1.V = MathUtils.Mul(ref xf2, vertices2[i2]);
            c.Value1.Id.ContactFeature.IndexA = (byte) edge1;
            c.Value1.Id.ContactFeature.IndexB = (byte) i2;
            c.Value1.Id.ContactFeature.TypeA = ContactFeatureType.Face;
            c.Value1.Id.ContactFeature.TypeB = ContactFeatureType.Vertex;
        }
    }
}