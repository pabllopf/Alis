// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EdgeAndPolygonCollider.cs
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

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.Collision.Shapes;
using Alis.Core.Physics2D.Common;
using Math = Alis.Core.Physics2D.Common.Math;

namespace Alis.Core.Physics2D.Collision.Colliders
{
    /// <summary>
    /// The edge and polygon collider class
    /// </summary>
    /// <seealso cref="Collider{EdgeShape, PolygonShape}"/>
    internal class EdgeAndPolygonCollider : Collider<EdgeShape, PolygonShape>
    {
        /// <summary>
        /// Collides the manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="edgeA">The edge</param>
        /// <param name="xfA">The xf</param>
        /// <param name="polygonB">The polygon</param>
        /// <param name="xfB">The xf</param>
        internal override void Collide(
            out Manifold manifold,
            in EdgeShape edgeA,
            in Transform xfA,
            in PolygonShape polygonB,
            in Transform xfB)
        {
            Transform xf = Math.MulT(xfA, xfB);
            Vector2 centroidB = Math.Mul(xf, polygonB.m_centroid);

            Vector2? v0 = edgeA.m_vertex0;
            Vector2 v1 = edgeA.m_vertex1;
            Vector2 v2 = edgeA.m_vertex2;
            Vector2? v3 = edgeA.m_vertex3;

            Vector2 edge1 = Vector2.Normalize(v2 - v1);
            Vector2 normal1 = new Vector2(edge1.Y, -edge1.X), normal0 = Vector2.Zero, normal2 = Vector2.Zero;
            float offset1 = Vector2.Dot(normal1, centroidB - v1);
            float offset0 = 0.0f, offset2 = 0.0f;

            bool convex1 = false, convex2 = false;

            // Is there a preceding edge?
            if (v0.HasValue)
            {
                Vector2 edge0 = Vector2.Normalize(v1 - v0.Value);
                normal0 = new Vector2(edge0.Y, -edge0.X);
                convex1 = Vectex.Cross(edge0, edge1) >= 0.0f;
                offset0 = Vector2.Dot(normal0, centroidB - v0.Value);
            }

            // Is there a following edge?
            if (v3.HasValue)
            {
                Vector2 edge2 = Vector2.Normalize(v3.Value - v2);
                normal2 = new Vector2(edge2.Y, -edge2.X);
                convex2 = Vectex.Cross(edge1, edge2) > 0.0f;
                offset2 = Vector2.Dot(normal2, centroidB - v2);
            }

            Vector2 normal, lowerLimit, upperLimit;

            bool front;

            // Determine front or back collision. Determine collision normal limits.
            if (v0.HasValue && v3.HasValue)
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
                    front = offset0 >= 0.0f || offset1 >= 0.0f && offset2 >= 0.0f;
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
                    front = offset2 >= 0.0f || offset0 >= 0.0f && offset1 >= 0.0f;
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
                    front = offset0 >= 0.0f && offset1 >= 0.0f && offset2 >= 0.0f;
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
            else if (v0.HasValue)
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
                    front = offset0 >= 0.0f && offset1 >= 0.0f;
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

            else if (v3.HasValue)
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
                    front = offset1 >= 0.0f && offset2 >= 0.0f;
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
            TempPolygon m_polygonB = new TempPolygon();
            m_polygonB.count = polygonB.m_count;
            for (int i = 0; i < polygonB.m_count; ++i)
            {
                m_polygonB.vertices[i] = Math.Mul(xf, polygonB.m_vertices[i]);
                m_polygonB.normals[i] = Vector2.Transform(polygonB.m_normals[i], xf.q);
            }

            float m_radius = polygonB.m_radius + edgeA.m_radius;
            manifold = new Manifold();
            manifold.pointCount = 0;

            EPAxis edgeAxis = ComputeEdgeSeparation(front, m_polygonB, normal, v1);

            // If no valid normal can be found than this edge should not collide.
            if (edgeAxis.type == EPAxis.AxisType.Unknown || edgeAxis.separation > m_radius)
            {
                return;
            }

            EPAxis polygonAxis = ComputePolygonSeparation(normal, m_polygonB, v1, v2, m_radius, upperLimit, lowerLimit);

            if (polygonAxis.type != EPAxis.AxisType.Unknown && polygonAxis.separation > m_radius)
            {
                return;
            }

            // Use hysteresis for jitter reduction.
            const float k_relativeTol = 0.98f;
            const float k_absoluteTol = 0.001f;

            EPAxis primaryAxis;
            if (polygonAxis.type == EPAxis.AxisType.Unknown)
            {
                primaryAxis = edgeAxis;
            }
            else if (polygonAxis.separation > k_relativeTol * edgeAxis.separation + k_absoluteTol)
            {
                primaryAxis = polygonAxis;
            }
            else
            {
                primaryAxis = edgeAxis;
            }

            ClipVertex[] ie = new ClipVertex[2];

            ReferenceFace rf;
            if (primaryAxis.type == EPAxis.AxisType.EdgeA)
            {
                manifold.type = ManifoldType.FaceA;

                // Search for the polygon normal that is most anti-parallel to the edge normal.
                int bestIndex = 0;
                float bestValue = Vector2.Dot(normal, m_polygonB.normals[0]);
                for (int i = 1; i < m_polygonB.count; ++i)
                {
                    float value = Vector2.Dot(normal, m_polygonB.normals[i]);
                    if (value < bestValue)
                    {
                        bestValue = value;
                        bestIndex = i;
                    }
                }

                int i1 = bestIndex;
                int i2 = i1 + 1 < m_polygonB.count ? i1 + 1 : 0;

                ie[0].v = m_polygonB.vertices[i1];
                ie[0].id.cf.indexA = 0;
                ie[0].id.cf.indexB = (byte) i1;
                ie[0].id.cf.typeA = (byte) ContactFeatureType.Face;
                ie[0].id.cf.typeB = (byte) ContactFeatureType.Vertex;

                ie[1].v = m_polygonB.vertices[i2];
                ie[1].id.cf.indexA = 0;
                ie[1].id.cf.indexB = (byte) i2;
                ie[1].id.cf.typeA = (byte) ContactFeatureType.Face;
                ie[1].id.cf.typeB = (byte) ContactFeatureType.Vertex;

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
                manifold.type = ManifoldType.FaceB;

                ie[0].v = v1;
                ie[0].id.cf.indexA = 0;
                ie[0].id.cf.indexB = (byte) primaryAxis.index;
                ie[0].id.cf.typeA = (byte) ContactFeatureType.Vertex;
                ie[0].id.cf.typeB = (byte) ContactFeatureType.Face;

                ie[1].v = v2;
                ie[1].id.cf.indexA = 0;
                ie[1].id.cf.indexB = (byte) primaryAxis.index;
                ie[1].id.cf.typeA = (byte) ContactFeatureType.Vertex;
                ie[1].id.cf.typeB = (byte) ContactFeatureType.Face;

                rf.i1 = primaryAxis.index;
                rf.i2 = rf.i1 + 1 < m_polygonB.count ? rf.i1 + 1 : 0;
                rf.v1 = m_polygonB.vertices[rf.i1];
                rf.v2 = m_polygonB.vertices[rf.i2];
                rf.normal = m_polygonB.normals[rf.i1];
            }

            rf.sideNormal1 = new Vector2(rf.normal.Y, -rf.normal.X);
            rf.sideNormal2 = -rf.sideNormal1;
            rf.sideOffset1 = Vector2.Dot(rf.sideNormal1, rf.v1);
            rf.sideOffset2 = Vector2.Dot(rf.sideNormal2, rf.v2);

            // Clip incident edge against extruded edge1 side edges.
            int np;

            // Clip to box side 1
            np = Collision.ClipSegmentToLine(out ClipVertex[] clipPoints1, ie, rf.sideNormal1, rf.sideOffset1, rf.i1);
            if (np < Settings.MaxManifoldPoints)
            {
                return;
            }

            // Clip to negative box side 1
            np = Collision.ClipSegmentToLine(out ClipVertex[] clipPoints2, clipPoints1, rf.sideNormal2, rf.sideOffset2,
                rf.i2);
            if (np < Settings.MaxManifoldPoints)
            {
                return;
            }

            // Now clipPoints2 contains the clipped points.
            if (primaryAxis.type == EPAxis.AxisType.EdgeA)
            {
                manifold.localNormal = rf.normal;
                manifold.localPoint = rf.v1;
            }
            else
            {
                manifold.localNormal = polygonB.m_normals[rf.i1];
                manifold.localPoint = polygonB.m_vertices[rf.i1];
            }

            int pointCount = 0;
            for (int i = 0; i < Settings.MaxManifoldPoints; ++i)
            {
                float separation = Vector2.Dot(rf.normal, clipPoints2[i].v - rf.v1);

                if (separation <= m_radius)
                {
                    ManifoldPoint cp = new ManifoldPoint();

                    if (primaryAxis.type == EPAxis.AxisType.EdgeA)
                    {
                        cp.localPoint = Math.MulT(xf, clipPoints2[i].v);
                        cp.id = clipPoints2[i].id;
                    }
                    else
                    {
                        cp.localPoint = clipPoints2[i].v;
                        cp.id.cf.typeA = clipPoints2[i].id.cf.typeB;
                        cp.id.cf.typeB = clipPoints2[i].id.cf.typeA;
                        cp.id.cf.indexA = clipPoints2[i].id.cf.indexB;
                        cp.id.cf.indexB = clipPoints2[i].id.cf.indexA;
                    }

                    manifold.points[pointCount] = cp;
                    ++pointCount;
                }
            }

            manifold.pointCount = pointCount;
        }

        /// <summary>
        /// Computes the edge separation using the specified front
        /// </summary>
        /// <param name="front">The front</param>
        /// <param name="polygonB">The polygon</param>
        /// <param name="normal">The normal</param>
        /// <param name="v1">The </param>
        /// <returns>The axis</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EPAxis ComputeEdgeSeparation(bool front, in TempPolygon polygonB, in Vector2 normal,
            in Vector2 v1)
        {
            EPAxis axis;
            axis.type = EPAxis.AxisType.EdgeA;
            axis.index = front ? 0 : 1;
            axis.separation = float.MaxValue;
            for (int i = 0; i < polygonB.count; ++i)
            {
                float s = Vector2.Dot(normal, polygonB.vertices[i] - v1);
                if (s < axis.separation)
                {
                    axis.separation = s;
                }
            }

            return axis;
        }

        /// <summary>
        /// Computes the polygon separation using the specified normal
        /// </summary>
        /// <param name="normal">The normal</param>
        /// <param name="polygonB">The polygon</param>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="upperLimit">The upper limit</param>
        /// <param name="lowerLimit">The lower limit</param>
        /// <returns>The axis</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EPAxis ComputePolygonSeparation(in Vector2 normal, in TempPolygon polygonB, in Vector2 v1,
            in Vector2 v2, in float radius, in Vector2 upperLimit, in Vector2 lowerLimit)
        {
            EPAxis axis;
            axis.type = EPAxis.AxisType.Unknown;
            axis.index = -1;
            axis.separation = float.MinValue;
            Vector2 perp = new Vector2(-normal.Y, normal.X);
            for (int i = 0; i < polygonB.count; ++i)
            {
                Vector2 n = -polygonB.normals[i];

                float s1 = Vector2.Dot(n, polygonB.vertices[i] - v1);
                float s2 = Vector2.Dot(n, polygonB.vertices[i] - v2);
                float s = MathF.Min(s1, s2);

                if (s > radius)
                {
                    // No collision
                    axis.type = EPAxis.AxisType.EdgeB;
                    axis.index = i;
                    axis.separation = s;
                    return axis;
                }

                // Adjacency
                if (Vector2.Dot(n, perp) >= 0.0f)
                {
                    if (Vector2.Dot(n - upperLimit, normal) < -Settings.AngularSlop)
                    {
                        continue;
                    }
                }
                else
                {
                    if (Vector2.Dot(n - lowerLimit, normal) < -Settings.AngularSlop)
                    {
                        continue;
                    }
                }

                if (s > axis.separation)
                {
                    axis.type = EPAxis.AxisType.EdgeB;
                    axis.index = i;
                    axis.separation = s;
                }
            }

            return axis;
        }

        /// <summary>
        /// The temp polygon class
        /// </summary>
        private class TempPolygon
        {
            /// <summary>
            /// The max polygon vertices
            /// </summary>
            internal readonly Vector2[] normals = new Vector2[Settings.MaxPolygonVertices];
            /// <summary>
            /// The max polygon vertices
            /// </summary>
            internal readonly Vector2[] vertices = new Vector2[Settings.MaxPolygonVertices];
            /// <summary>
            /// The count
            /// </summary>
            internal int count;
        }

        // This structure is used to keep track of the best separating axis.
        /// <summary>
        /// The ep axis
        /// </summary>
        private struct EPAxis
        {
            /// <summary>
            /// The axis type enum
            /// </summary>
            internal enum AxisType
            {
                /// <summary>
                /// The unknown axis type
                /// </summary>
                Unknown,
                /// <summary>
                /// The edge axis type
                /// </summary>
                EdgeA,
                /// <summary>
                /// The edge axis type
                /// </summary>
                EdgeB
            }

            /// <summary>
            /// The type
            /// </summary>
            internal AxisType type;
            /// <summary>
            /// The index
            /// </summary>
            internal int index;
            /// <summary>
            /// The separation
            /// </summary>
            internal float separation;
        }

        /// <summary>
        /// The reference face
        /// </summary>
        private struct ReferenceFace
        {
            /// <summary>
            /// The 
            /// </summary>
            internal int i1;
            /// <summary>
            /// The 
            /// </summary>
            internal int i2;

            /// <summary>
            /// The 
            /// </summary>
            internal Vector2 v1;
            /// <summary>
            /// The 
            /// </summary>
            internal Vector2 v2;

            /// <summary>
            /// The normal
            /// </summary>
            internal Vector2 normal;

            /// <summary>
            /// The side normal
            /// </summary>
            internal Vector2 sideNormal1;
            /// <summary>
            /// The side offset
            /// </summary>
            internal float sideOffset1;

            /// <summary>
            /// The side normal
            /// </summary>
            internal Vector2 sideNormal2;
            /// <summary>
            /// The side offset
            /// </summary>
            internal float sideOffset2;
        }
    }
}