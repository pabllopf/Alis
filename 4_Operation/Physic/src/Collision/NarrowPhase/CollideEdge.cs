// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollideEdge.cs
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
using Alis.Core.Physic.Shared.Optimization;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Collision.NarrowPhase
{
    /// <summary>
    ///     The collide edge class
    /// </summary>
    public static class CollideEdge
    {
        /// <summary>
        ///     Collides the edge and circle using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="edgeA">The edge</param>
        /// <param name="transformA">The transform</param>
        /// <param name="circleB">The circle</param>
        /// <param name="transformB">The transform</param>
        public static void CollideEdgeAndCircle(ref Manifold manifold, EdgeShape edgeA, ref Transform transformA,
            CircleShape circleB, ref Transform transformB)
        {
            manifold.PointCount = 0;

            Vector2 circleBPosition = circleB.Position;
            Vector2 q = ComputeCirclePositionInEdgeFrame(ref transformA, ref transformB, ref circleBPosition);

            Vector2 edgeStart = edgeA.Vertex1;
            Vector2 edgeEnd = edgeA.Vertex2;
            Vector2 edgeDirection = edgeEnd - edgeStart;
            Vector2 edgeNormal = new Vector2(edgeDirection.Y, -edgeDirection.X);
            float offset = MathUtils.Dot(edgeNormal, q - edgeStart);

            if (edgeA.OneSided && (offset < 0.0f))
            {
                return;
            }

            float u = Vector2.Dot(edgeDirection, edgeEnd - q);
            float v = Vector2.Dot(edgeDirection, q - edgeStart);

            float radiusSum = edgeA.RadiusPrivate + circleB.RadiusPrivate;

            if (v <= 0.0f)
            {
                HandleRegionA(ref manifold, edgeA, edgeStart, q, radiusSum, circleBPosition);
            }
            else if (u <= 0.0f)
            {
                HandleRegionB(ref manifold, edgeA, edgeEnd, q, radiusSum, circleBPosition);
            }
            else
            {
                HandleRegionAb(ref manifold, edgeA, edgeStart, edgeEnd, q, radiusSum, offset, circleBPosition, edgeNormal);
            }
        }

        /// <summary>
        ///     Handles the region ab using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="edgeA">The edge</param>
        /// <param name="edgeStart">The edge start</param>
        /// <param name="edgeEnd">The edge end</param>
        /// <param name="q">The </param>
        /// <param name="radiusSum">The radius sum</param>
        /// <param name="offset">The offset</param>
        /// <param name="circlePosition">The circle position</param>
        /// <param name="edgeNormal">The edge normal</param>
        private static void HandleRegionAb(ref Manifold manifold, EdgeShape edgeA, Vector2 edgeStart, Vector2 edgeEnd, Vector2 q, float radiusSum, float offset, Vector2 circlePosition, Vector2 edgeNormal)
        {
            float den = Vector2.Dot(edgeEnd - edgeStart, edgeEnd - edgeStart);
            Debug.Assert(den > 0.0f);

            Vector2 p = 1.0f / den * (Vector2.Dot(q - edgeStart, edgeEnd - edgeStart) * edgeStart + Vector2.Dot(q - edgeEnd, edgeStart - edgeEnd) * edgeEnd);
            Vector2 d = q - p;
            float dd = Vector2.Dot(d, d);

            if (dd > radiusSum * radiusSum)
            {
                return;
            }

            if (offset < 0.0f)
            {
                edgeNormal = new Vector2(-edgeNormal.X, -edgeNormal.Y);
            }

            edgeNormal = Vector2.Normalize(edgeNormal);
            SetManifoldForEdge(ref manifold, edgeA, edgeStart, edgeNormal, circlePosition);
        }

        /// <summary>
        ///     Computes the circle position in edge frame using the specified transform a
        /// </summary>
        /// <param name="transformA">The transform</param>
        /// <param name="transformB">The transform</param>
        /// <param name="circlePosition">The circle position</param>
        /// <returns>The vector</returns>
        private static Vector2 ComputeCirclePositionInEdgeFrame(ref Transform transformA, ref Transform transformB, ref Vector2 circlePosition) => MathUtils.MulT(ref transformA, MathUtils.Mul(ref transformB, ref circlePosition));

        /// <summary>
        ///     Handles the region a using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="edgeA">The edge</param>
        /// <param name="edgeStart">The edge start</param>
        /// <param name="q">The </param>
        /// <param name="radiusSum">The radius sum</param>
        /// <param name="circlePosition">The circle position</param>
        private static void HandleRegionA(ref Manifold manifold, EdgeShape edgeA, Vector2 edgeStart, Vector2 q, float radiusSum, Vector2 circlePosition)
        {
            Vector2 p1 = edgeStart;
            Vector2 d1 = q - p1;
            float dd1 = Vector2.Dot(d1, d1);

            if (dd1 > radiusSum * radiusSum)
            {
                return;
            }

            if (edgeA.OneSided)
            {
                Vector2 a1 = edgeA.Vertex0;
                Vector2 b1 = edgeStart;
                Vector2 e1 = b1 - a1;
                float u1 = Vector2.Dot(e1, b1 - q);

                if (u1 > 0.0f)
                {
                    return;
                }
            }

            SetManifoldForCircle(ref manifold, p1, circlePosition);
        }

        /// <summary>
        ///     Handles the region b using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="edgeA">The edge</param>
        /// <param name="edgeEnd">The edge end</param>
        /// <param name="q">The </param>
        /// <param name="radiusSum">The radius sum</param>
        /// <param name="circlePosition">The circle position</param>
        private static void HandleRegionB(ref Manifold manifold, EdgeShape edgeA, Vector2 edgeEnd, Vector2 q, float radiusSum, Vector2 circlePosition)
        {
            Vector2 p2 = edgeEnd;
            Vector2 d2 = q - p2;
            float dd2 = Vector2.Dot(d2, d2);

            if (dd2 > radiusSum * radiusSum)
            {
                return;
            }

            if (edgeA.OneSided)
            {
                Vector2 b2 = edgeA.Vertex3;
                Vector2 a2 = edgeEnd;
                Vector2 e2 = b2 - a2;
                float v2 = Vector2.Dot(e2, q - a2);

                if (v2 > 0.0f)
                {
                    return;
                }
            }

            SetManifoldForCircle(ref manifold, p2, circlePosition);
        }

        /// <summary>
        ///     Sets the manifold for circle using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="contactPoint">The contact point</param>
        /// <param name="circlePosition">The circle position</param>
        private static void SetManifoldForCircle(ref Manifold manifold, Vector2 contactPoint, Vector2 circlePosition)
        {
            ContactFeature cf = default(ContactFeature);
            cf.IndexA = 0;
            cf.TypeA = ContactFeatureType.Vertex;
            manifold.PointCount = 1;
            manifold.Type = ManifoldType.Circles;
            manifold.LocalNormal = Vector2.Zero;
            manifold.LocalPoint = contactPoint;
            manifold.Points.Value0.Id.Key = 0;
            manifold.Points.Value0.Id.ContactFeature = cf;
            manifold.Points.Value0.LocalPoint = circlePosition;
        }

        /// <summary>
        ///     Sets the manifold for edge using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="edgeA">The edge</param>
        /// <param name="edgeStart">The edge start</param>
        /// <param name="edgeNormal">The edge normal</param>
        /// <param name="circlePosition">The circle position</param>
        private static void SetManifoldForEdge(ref Manifold manifold, EdgeShape edgeA, Vector2 edgeStart, Vector2 edgeNormal, Vector2 circlePosition)
        {
            ContactFeature cf;
            cf.IndexA = 0;
            cf.TypeA = ContactFeatureType.Face;
            manifold.PointCount = 1;
            manifold.Type = ManifoldType.FaceA;
            manifold.LocalNormal = edgeNormal;
            manifold.LocalPoint = edgeStart;
            manifold.Points.Value0.Id.Key = 0;
            cf.IndexB = 0;
            cf.TypeB = ContactFeatureType.Vertex;
            manifold.Points.Value0.Id.ContactFeature = cf;
            manifold.Points.Value0.LocalPoint = circlePosition;
        }

        /// <summary>
        /// Collides the edge and polygon using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="edgeA">The edge</param>
        /// <param name="xfA">The xf</param>
        /// <param name="polygonB">The polygon</param>
        /// <param name="xfB">The xf</param>
        public static void CollideEdgeAndPolygon(ref Manifold manifold, EdgeShape edgeA, ref Transform xfA,
            PolygonShape polygonB, ref Transform xfB)
        {
            manifold.PointCount = 0;

            Transform xf = MathUtils.MulT(xfA, xfB);

            Vector2 centroidB = MathUtils.Mul(ref xf, polygonB.MassDataPrivate.Centroid);

            Vector2 v1 = edgeA.Vertex1;
            Vector2 v2 = edgeA.Vertex2;

            Vector2 edge1 = v2 - v1;
            edge1 = Vector2.Normalize(edge1);

            // Normal points to the right for a CCW winding
            Vector2 normal1 = new Vector2(edge1.Y, -edge1.X);
            float offset1 = MathUtils.Dot(normal1, centroidB - v1);

            bool oneSided = edgeA.OneSided;
            if (oneSided && (offset1 < 0.0f))
            {
                return;
            }

            TempPolygon tempPolygonB = GetPolygonInFrameA(polygonB, xf);

            float radius = polygonB.RadiusPrivate + edgeA.RadiusPrivate;

            EpAxis edgeAxis = ComputeEdgeSeparation(ref tempPolygonB, v1, normal1);
            if (edgeAxis.Separation > radius)
            {
                return;
            }

            EpAxis polygonAxis = ComputePolygonSeparation(ref tempPolygonB, v1, v2);
            if (polygonAxis.Separation > radius)
            {
                return;
            }

            EpAxis primaryAxis = GetPrimaryAxis(polygonAxis, edgeAxis, radius);

            if (oneSided)
            {
                primaryAxis = HandleOneSidedEdge(primaryAxis, edgeAxis, v1, v2, edge1, edgeA);
            }

            if (primaryAxis.Type == EpAxisType.Unknown)
            {
                return;
            }

            ReferenceFace ref1 = GetReferenceFace(primaryAxis, tempPolygonB, v1, v2, edge1, polygonB, edgeA, ref manifold);

            // Clip incident edge against reference face side planes
            FixedArray2<ClipVertex> clipPoints1;
            FixedArray2<ClipVertex> clipPoints2;
            int np;

            // Define clipPoints before using it
            FixedArray2<ClipVertex> clipPoints = new FixedArray2<ClipVertex>();

            // Clip to side 1
            np = Collision.ClipSegmentToLine(out clipPoints1, ref clipPoints, ref1.SideNormal1, ref1.SideOffset1,
                ref1.I1);

            if (np < Settings.ManifoldPoints)
            {
                return;
            }

            // Clip to side 2
            np = Collision.ClipSegmentToLine(out clipPoints2, ref clipPoints1, ref1.SideNormal2, ref1.SideOffset2,
                ref1.I2);

            if (np < Settings.ManifoldPoints)
            {
                return;
            }

            SetManifoldPoints(ref manifold, primaryAxis, ref1, clipPoints2, radius, xf, polygonB);
        }

        /// <summary>
        /// Gets the polygon in frame a using the specified polygon b
        /// </summary>
        /// <param name="polygonB">The polygon</param>
        /// <param name="xf">The xf</param>
        /// <returns>The temp polygon</returns>
        private static TempPolygon GetPolygonInFrameA(PolygonShape polygonB, Transform xf)
        {
            TempPolygon tempPolygonB = new TempPolygon(polygonB.VerticesPrivate.Count);
            for (int i = 0; i < polygonB.VerticesPrivate.Count; ++i)
            {
                tempPolygonB.Vertices[i] = MathUtils.Mul(ref xf, polygonB.VerticesPrivate[i]);
                tempPolygonB.Normals[i] = MathUtils.Mul(xf.Rotation, polygonB.NormalsPrivate[i]);
            }

            return tempPolygonB;
        }

        /// <summary>
        /// Gets the primary axis using the specified polygon axis
        /// </summary>
        /// <param name="polygonAxis">The polygon axis</param>
        /// <param name="edgeAxis">The edge axis</param>
        /// <param name="radius">The radius</param>
        /// <returns>The primary axis</returns>
        private static EpAxis GetPrimaryAxis(EpAxis polygonAxis, EpAxis edgeAxis, float radius)
        {
            // Use hysteresis for jitter reduction.
            const float kRelativeTol = 0.98f;
            const float kAbsoluteTol = 0.001f;

            EpAxis primaryAxis;
            if (polygonAxis.Separation - radius > kRelativeTol * (edgeAxis.Separation - radius) + kAbsoluteTol)
            {
                primaryAxis = polygonAxis;
            }
            else
            {
                primaryAxis = edgeAxis;
            }

            return primaryAxis;
        }

        /// <summary>
        /// Handles the one sided edge using the specified primary axis
        /// </summary>
        /// <param name="primaryAxis">The primary axis</param>
        /// <param name="edgeAxis">The edge axis</param>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="edge1">The edge</param>
        /// <param name="edgeA">The edge</param>
        /// <returns>The primary axis</returns>
        private static EpAxis HandleOneSidedEdge(EpAxis primaryAxis, EpAxis edgeAxis, Vector2 v1, Vector2 v2, Vector2 edge1, EdgeShape edgeA)
        {
            Vector2 edge0 = v1 - edgeA.Vertex0;
            edge0 = Vector2.Normalize(edge0);
            Vector2 normal0 = new Vector2(edge0.Y, -edge0.X);
            bool convex1 = MathUtils.Cross(edge0, edge1) >= 0.0f;

            Vector2 edge2 = edgeA.Vertex3 - v2;
            edge2 = Vector2.Normalize(edge2);
            Vector2 normal2 = new Vector2(edge2.Y, -edge2.X);
            bool convex2 = MathUtils.Cross(edge1, edge2) >= 0.0f;

            const float sinTol = 0.1f;
            bool side1 = MathUtils.Dot(primaryAxis.Normal, edge1) <= 0.0f;

            // Check Gauss Map
            if (side1)
            {
                if (convex1)
                {
                    if (MathUtils.Cross(primaryAxis.Normal, normal0) > sinTol)
                    {
                        // Skip region
                        primaryAxis.Type = EpAxisType.Unknown;
                        return primaryAxis;
                    }

                    // Admit region
                }
                else
                {
                    // Snap region
                    primaryAxis = edgeAxis;
                }
            }
            else
            {
                if (convex2)
                {
                    if (MathUtils.Cross(normal2, primaryAxis.Normal) > sinTol)
                    {
                        // Skip region
                        primaryAxis.Type = EpAxisType.Unknown;
                        return primaryAxis;
                    }

                    // Admit region
                }
                else
                {
                    // Snap region
                    primaryAxis = edgeAxis;
                }
            }

            return primaryAxis;
        }

        /// <summary>
        /// Gets the reference face using the specified primary axis
        /// </summary>
        /// <param name="primaryAxis">The primary axis</param>
        /// <param name="tempPolygonB">The temp polygon</param>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="edge1">The edge</param>
        /// <param name="polygonB">The polygon</param>
        /// <param name="edgeA">The edge</param>
        /// <param name="manifold">The manifold</param>
        /// <returns>The ref</returns>
        private static ReferenceFace GetReferenceFace(EpAxis primaryAxis, TempPolygon tempPolygonB, Vector2 v1, Vector2 v2, Vector2 edge1, PolygonShape polygonB, EdgeShape edgeA, ref Manifold manifold)
        {
            FixedArray2<ClipVertex> clipPoints = new FixedArray2<ClipVertex>();
            ReferenceFace ref1;
            if (primaryAxis.Type == EpAxisType.EdgeA)
            {
                manifold.Type = ManifoldType.FaceA;

                // Search for the polygon normal that is most anti-parallel to the edge normal.
                int bestIndex = 0;
                float bestValue = MathUtils.Dot(primaryAxis.Normal, tempPolygonB.Normals[0]);
                for (int i = 1; i < tempPolygonB.Count; ++i)
                {
                    float value = MathUtils.Dot(primaryAxis.Normal, tempPolygonB.Normals[i]);
                    if (value < bestValue)
                    {
                        bestValue = value;
                        bestIndex = i;
                    }
                }

                int i1 = bestIndex;
                int i2 = i1 + 1 < tempPolygonB.Count ? i1 + 1 : 0;

                clipPoints.Value0.V = tempPolygonB.Vertices[i1];
                clipPoints.Value0.Id.ContactFeature.IndexA = 0;
                clipPoints.Value0.Id.ContactFeature.IndexB = (byte) i1;
                clipPoints.Value0.Id.ContactFeature.TypeA = ContactFeatureType.Face;
                clipPoints.Value0.Id.ContactFeature.TypeB = ContactFeatureType.Vertex;

                clipPoints.Value1.V = tempPolygonB.Vertices[i2];
                clipPoints.Value1.Id.ContactFeature.IndexA = 0;
                clipPoints.Value1.Id.ContactFeature.IndexB = (byte) i2;
                clipPoints.Value1.Id.ContactFeature.TypeA = ContactFeatureType.Face;
                clipPoints.Value1.Id.ContactFeature.TypeB = ContactFeatureType.Vertex;

                ref1.I1 = 0;
                ref1.I2 = 1;
                ref1.V1 = v1;
                ref1.V2 = v2;
                ref1.Normal = primaryAxis.Normal;
                ref1.SideNormal1 = -edge1;
                ref1.SideNormal2 = edge1;
            }
            else
            {
                manifold.Type = ManifoldType.FaceB;

                clipPoints.Value0.V = v2;
                clipPoints.Value0.Id.ContactFeature.IndexA = 1;
                clipPoints.Value0.Id.ContactFeature.IndexB = (byte) primaryAxis.Index;
                clipPoints.Value0.Id.ContactFeature.TypeA = ContactFeatureType.Vertex;
                clipPoints.Value0.Id.ContactFeature.TypeB = ContactFeatureType.Face;

                clipPoints.Value1.V = v1;
                clipPoints.Value1.Id.ContactFeature.IndexA = 0;
                clipPoints.Value1.Id.ContactFeature.IndexB = (byte) primaryAxis.Index;
                clipPoints.Value1.Id.ContactFeature.TypeA = ContactFeatureType.Vertex;
                clipPoints.Value1.Id.ContactFeature.TypeB = ContactFeatureType.Face;

                ref1.I1 = primaryAxis.Index;
                ref1.I2 = ref1.I1 + 1 < tempPolygonB.Count ? ref1.I1 + 1 : 0;
                ref1.V1 = tempPolygonB.Vertices[ref1.I1];
                ref1.V2 = tempPolygonB.Vertices[ref1.I2];
                ref1.Normal = tempPolygonB.Normals[ref1.I1];

                // CCW winding
                ref1.SideNormal1 = new Vector2(ref1.Normal.Y, -ref1.Normal.X);
                ref1.SideNormal2 = -ref1.SideNormal1;
            }

            ref1.SideOffset1 = MathUtils.Dot(ref1.SideNormal1, ref1.V1);
            ref1.SideOffset2 = MathUtils.Dot(ref1.SideNormal2, ref1.V2);

            return ref1;
        }

        /// <summary>
        /// Sets the manifold points using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="primaryAxis">The primary axis</param>
        /// <param name="ref1">The ref</param>
        /// <param name="clipPoints2">The clip points</param>
        /// <param name="radius">The radius</param>
        /// <param name="xf">The xf</param>
        /// <param name="polygonB">The polygon</param>
        private static void SetManifoldPoints(ref Manifold manifold, EpAxis primaryAxis, ReferenceFace ref1, FixedArray2<ClipVertex> clipPoints2, float radius, Transform xf, PolygonShape polygonB)
        {
            // Now clipPoints2 contains the clipped points.
            if (primaryAxis.Type == EpAxisType.EdgeA)
            {
                manifold.LocalNormal = ref1.Normal;
                manifold.LocalPoint = ref1.V1;
            }
            else
            {
                manifold.LocalNormal = polygonB.NormalsPrivate[ref1.I1];
                manifold.LocalPoint = polygonB.VerticesPrivate[ref1.I1];
            }

            int pointCount = 0;
            for (int i = 0; i < Settings.ManifoldPoints; ++i)
            {
                float separation = MathUtils.Dot(ref1.Normal, clipPoints2[i].V - ref1.V1);

                if (separation <= radius)
                {
                    ManifoldPoint cp = manifold.Points[pointCount];

                    if (primaryAxis.Type == EpAxisType.EdgeA)
                    {
                        cp.LocalPoint = MathUtils.MulT(xf, clipPoints2[i].V);
                        cp.Id = clipPoints2[i].Id;
                    }
                    else
                    {
                        cp.LocalPoint = clipPoints2[i].V;
                        cp.Id.ContactFeature.TypeA = clipPoints2[i].Id.ContactFeature.TypeB;
                        cp.Id.ContactFeature.TypeB = clipPoints2[i].Id.ContactFeature.TypeA;
                        cp.Id.ContactFeature.IndexA = clipPoints2[i].Id.ContactFeature.IndexB;
                        cp.Id.ContactFeature.IndexB = clipPoints2[i].Id.ContactFeature.IndexA;
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
        /// <param name="v1">The </param>
        /// <param name="normal1">The normal</param>
        /// <returns>The axis</returns>
        private static EpAxis ComputeEdgeSeparation(ref TempPolygon polygonB, Vector2 v1, Vector2 normal1)
        {
            EpAxis axis;
            axis.Type = EpAxisType.EdgeA;
            axis.Index = -1;
            axis.Separation = -float.MaxValue;
            axis.Normal = Vector2.Zero;

            Vector2[] axes = {normal1, -normal1};

            // Find axis with least overlap (min-max problem)
            for (int j = 0; j < 2; ++j)
            {
                float sj = float.MaxValue;

                // Find deepest polygon vertex along axis j
                for (int i = 0; i < polygonB.Count; ++i)
                {
                    float si = MathUtils.Dot(axes[j], polygonB.Vertices[i] - v1);
                    if (si < sj)
                    {
                        sj = si;
                    }
                }

                if (sj > axis.Separation)
                {
                    axis.Index = j;
                    axis.Separation = sj;
                    axis.Normal = axes[j];
                }
            }

            return axis;
        }

        /// <summary>
        ///     Computes the polygon separation using the specified polygon b
        /// </summary>
        /// <param name="polygonB">The polygon</param>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <returns>The axis</returns>
        private static EpAxis ComputePolygonSeparation(ref TempPolygon polygonB, Vector2 v1, Vector2 v2)
        {
            EpAxis axis;
            axis.Type = EpAxisType.Unknown;
            axis.Index = -1;
            axis.Separation = -float.MaxValue;
            axis.Normal = Vector2.Zero;

            for (int i = 0; i < polygonB.Count; ++i)
            {
                Vector2 n = -polygonB.Normals[i];

                float s1 = MathUtils.Dot(n, polygonB.Vertices[i] - v1);
                float s2 = MathUtils.Dot(n, polygonB.Vertices[i] - v2);
                float s = MathUtils.Min(s1, s2);

                if (s > axis.Separation)
                {
                    axis.Type = EpAxisType.EdgeB;
                    axis.Index = i;
                    axis.Separation = s;
                    axis.Normal = n;
                }
            }

            return axis;
        }

        /// <summary>
        ///     The temp polygon
        /// </summary>
        private struct TempPolygon
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TempPolygon" /> class
            /// </summary>
            /// <param name="count">The count</param>
            public TempPolygon(int count)
            {
                Count = count;
                Vertices = new Vector2[count];
                Normals = new Vector2[count];
            }

            /// <summary>
            ///     The vertices
            /// </summary>
            public readonly Vector2[] Vertices;

            /// <summary>
            ///     The normals
            /// </summary>
            public readonly Vector2[] Normals;

            /// <summary>
            ///     The count
            /// </summary>
            public readonly int Count;
        }
    }
}