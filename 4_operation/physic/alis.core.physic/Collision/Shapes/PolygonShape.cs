// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PolygonShape.cs
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

#define DEBUG

using Alis.Aspect.Logging;
using Alis.Aspect.Math;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     A convex polygon. It is assumed that the interior of the polygon is to the left of each edge.
    /// </summary>
    public class PolygonShape : Shape
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonShape" /> class
        /// </summary>
        public PolygonShape()
        {
            Type = ShapeType.PolygonShape;
            Radius = Settings.PolygonRadius;

            /*Box2DXDebug.Assert(def.Type == ShapeType.PolygonShape);
            _type = ShapeType.PolygonShape;
            PolygonDef poly = (PolygonDef)def;

            // Get the vertices transformed into the body frame.
            _vertexCount = poly.VertexCount;
            Box2DXDebug.Assert(3 <= _vertexCount && _vertexCount <= Settings.MaxPolygonVertices);

            // Copy vertices.
            for (int i = 0; i < _vertexCount; ++i)
            {
                _vertices[i] = poly.Vertices[i];
            }

            // Compute normals. Ensure the edges have non-zero length.
            for (int i = 0; i < _vertexCount; ++i)
            {
                int i1 = i;
                int i2 = i + 1 < _vertexCount ? i + 1 : 0;
                Vec2 edge = _vertices[i2] - _vertices[i1];
                Box2DXDebug.Assert(edge.LengthSquared() > Common.Settings.FLT_EPSILON * Common.Settings.FLT_EPSILON);
                _normals[i] = Vec2.Cross(edge, 1.0f);
                _normals[i].Normalize();
            }

#if DEBUG
            // Ensure the polygon is convex.
            for (int i = 0; i < _vertexCount; ++i)
            {
                for (int j = 0; j < _vertexCount; ++j)
                {
                    // Don't check vertices on the current edge.
                    if (j == i || j == (i + 1) % _vertexCount)
                    {
                        continue;
                    }

                    // Your polygon is non-convex (it has an indentation).
                    // Or your polygon is too skinny.
                    float s = Vec2.Dot(_normals[i], _vertices[j] - _vertices[i]);
                    Box2DXDebug.Assert(s < -Settings.LinearSlop);
                }
            }

            // Ensure the polygon is counter-clockwise.
            for (int i = 1; i < _vertexCount; ++i)
            {
                float cross = Vec2.Cross(_normals[i - 1], _normals[i]);

                // Keep asinf happy.
                cross = Common.Math.Clamp(cross, -1.0f, 1.0f);

                // You have consecutive edges that are almost parallel on your polygon.
                float angle = (float)System.Math.Asin(cross);
                Box2DXDebug.Assert(angle > Settings.AngularSlop);
            }
#endif

            // Compute the polygon centroid.
            _centroid = ComputeCentroid(poly.Vertices, poly.VertexCount);

            // Compute the oriented bounding box.
            ComputeOBB(out _obb, _vertices, _vertexCount);

            // Create core polygon shape by shifting edges inward.
            // Also compute the min/max radius for CCD.
            for (int i = 0; i < _vertexCount; ++i)
            {
                int i1 = i - 1 >= 0 ? i - 1 : _vertexCount - 1;
                int i2 = i;

                Vec2 n1 = _normals[i1];
                Vec2 n2 = _normals[i2];
                Vec2 v = _vertices[i] - _centroid; ;

                Vec2 d = new Vec2();
                d.X = Vec2.Dot(n1, v) - Settings.ToiSlop;
                d.Y = Vec2.Dot(n2, v) - Settings.ToiSlop;

                // Shifting the edge inward by b2_toiSlop should
                // not cause the plane to pass the centroid.

                // Your shape has a radius/extent less than b2_toiSlop.
                Box2DXDebug.Assert(d.X >= 0.0f);
                Box2DXDebug.Assert(d.Y >= 0.0f);
                Mat22 A = new Mat22();
                A.Col1.X = n1.X; A.Col2.X = n1.Y;
                A.Col1.Y = n2.X; A.Col2.Y = n2.Y;
                _coreVertices[i] = A.Solve(d) + _centroid;
            }*/
        }

        /// <summary>
        ///     The centroid
        /// </summary>
        internal Vector2 Centroid { get; set; }

        /// <summary>
        ///     The max polygon vertices
        /// </summary>
        internal Vector2[] Normals { get; } = new Vector2[Settings.MaxPolygonVertices];

        /// <summary>
        ///     Gets the value of the vertex count
        /// </summary>
        public int VertexCount { get; internal set; }

        /// <summary>
        ///     Gets the value of the vertices
        /// </summary>
        public Vector2[] Vertices { get; } = new Vector2[Settings.MaxPolygonVertices];

        /// <summary>
        ///     Copy vertices. This assumes the vertices define a convex polygon.
        ///     It is assumed that the exterior is the the right of each edge.
        /// </summary>
        public void Set(Vector2[] vertices, int count)
        {
            Box2DxDebug.Assert(3 <= count && count <= Settings.MaxPolygonVertices);
            VertexCount = count;

            int i;
            // Copy vertices.
            for (i = 0; i < VertexCount; ++i)
            {
                Vertices[i] = vertices[i];
            }

            // Compute normals. Ensure the edges have non-zero length.
            for (i = 0; i < VertexCount; ++i)
            {
                int i1 = i;
                int i2 = i + 1 < count ? i + 1 : 0;
                Vector2 edge = Vertices[i2] - Vertices[i1];
                Box2DxDebug.Assert(edge.LengthSquared() > Settings.FltEpsilonSquared);
                Normals[i] = Vector2.Cross(edge, 1.0f);
                Normals[i].Normalize();
            }

#if DEBUG
            // Ensure the polygon is convex and the interior
            // is to the left of each edge.
            for (i = 0; i < VertexCount; ++i)
            {
                int i1 = i;
                int i2 = i + 1 < count ? i + 1 : 0;
                Vector2 edge = Vertices[i2] - Vertices[i1];

                for (int j = 0; j < VertexCount; ++j)
                {
                    // Don't check vertices on the current edge.
                    if (j == i1 || j == i2)
                    {
                        continue;
                    }

                    Vector2 r = Vertices[j] - Vertices[i1];

                    // Your polygon is non-convex (it has an indentation) or
                    // has colinear edges.
                    float s = Vector2.Cross(edge, r);
                    Box2DxDebug.Assert(s > 0.0f);
                }
            }
#endif

            // Compute the polygon centroid.
            Centroid = ComputeCentroid(Vertices, VertexCount);
        }

        /// <summary>
        ///     Build vertices to represent an axis-aligned box.
        /// </summary>
        /// <param name="hx">The half-width</param>
        /// <param name="hy">The half-height.</param>
        public void SetAsBox(float hx, float hy)
        {
            VertexCount = 4;
            Vertices[0].Set(-hx, -hy);
            Vertices[1].Set(hx, -hy);
            Vertices[2].Set(hx, hy);
            Vertices[3].Set(-hx, hy);
            Normals[0].Set(0.0f, -1.0f);
            Normals[1].Set(1.0f, 0.0f);
            Normals[2].Set(0.0f, 1.0f);
            Normals[3].Set(-1.0f, 0.0f);
            Centroid = new Vector2(0);
        }


        /// <summary>
        ///     Build vertices to represent an oriented box.
        /// </summary>
        /// <param name="hx">The half-width</param>
        /// <param name="hy">The half-height.</param>
        /// <param name="center">The center of the box in local coordinates.</param>
        /// <param name="angle">The rotation of the box in local coordinates.</param>
        public void SetAsBox(float hx, float hy, Vector2 center, float angle)
        {
            SetAsBox(hx, hy);

            XForm xf = new XForm();
            xf.Position = center;
            xf.R.Set(angle);

            // Transform vertices and normals.
            for (int i = 0; i < VertexCount; ++i)
            {
                Vertices[i] = Math.Mul(xf, Vertices[i]);
                Normals[i] = Math.Mul(xf.R, Normals[i]);
            }
        }

        /// <summary>
        ///     Sets the as edge using the specified v 1
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        public void SetAsEdge(Vector2 v1, Vector2 v2)
        {
            VertexCount = 2;
            Vertices[0] = v1;
            Vertices[1] = v2;
            Centroid = 0.5f * (v1 + v2);
            Normals[0] = Vector2.Cross(v2 - v1, 1.0f);
            Normals[0].Normalize();
            Normals[1] = -Normals[0];
        }

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="xf">The xf</param>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public override bool TestPoint(XForm xf, Vector2 p)
        {
            Vector2 pLocal = Math.MulT(xf.R, p - xf.Position);

            int vc = VertexCount;
            for (int i = 0; i < vc; ++i)
            {
                float dot = Vector2.Dot(Normals[i], pLocal - Vertices[i]);
                if (dot > 0.0f)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Tests the segment using the specified xf
        /// </summary>
        /// <param name="xf">The xf</param>
        /// <param name="lambda">The lambda</param>
        /// <param name="normal">The normal</param>
        /// <param name="segment">The segment</param>
        /// <param name="maxLambda">The max lambda</param>
        /// <returns>The segment collide</returns>
        public override SegmentCollide TestSegment(XForm xf, out float lambda, out Vector2 normal, Segment segment,
            float maxLambda)
        {
            lambda = 0f;
            normal = Vector2.Zero;

            float lower = 0.0f, upper = maxLambda;

            Vector2 p1 = Math.MulT(xf.R, segment.P1 - xf.Position);
            Vector2 p2 = Math.MulT(xf.R, segment.P2 - xf.Position);
            Vector2 d = p2 - p1;
            int index = -1;

            for (int i = 0; i < VertexCount; ++i)
            {
                // p = p1 + a * d
                // dot(normal, p - v) = 0
                // dot(normal, p1 - v) + a * dot(normal, d) = 0
                float numerator = Vector2.Dot(Normals[i], Vertices[i] - p1);
                float denominator = Vector2.Dot(Normals[i], d);

                if (denominator == 0.0f)
                {
                    if (numerator < 0.0f)
                    {
                        return SegmentCollide.MissCollide;
                    }
                }
                else
                {
                    // Note: we want this predicate without division:
                    // lower < numerator / denominator, where denominator < 0
                    // Since denominator < 0, we have to flip the inequality:
                    // lower < numerator / denominator <==> denominator * lower > numerator.
                    if (denominator < 0.0f && numerator < lower * denominator)
                    {
                        // Increase lower.
                        // The segment enters this half-space.
                        lower = numerator / denominator;
                        index = i;
                    }
                    else if (denominator > 0.0f && numerator < upper * denominator)
                    {
                        // Decrease upper.
                        // The segment exits this half-space.
                        upper = numerator / denominator;
                    }
                }

                if (upper < lower)
                {
                    return SegmentCollide.MissCollide;
                }
            }

            Box2DxDebug.Assert(0.0f <= lower && lower <= maxLambda);

            if (index >= 0)
            {
                lambda = lower;
                normal = Math.Mul(xf.R, Normals[index]);
                return SegmentCollide.HitCollide;
            }

            lambda = 0f;
            return SegmentCollide.StartInsideCollide;
        }

        /// <summary>
        ///     Computes the aabb using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="xf">The xf</param>
        public override void ComputeAabb(out Aabb aabb, XForm xf)
        {
            Vector2 lower = Math.Mul(xf, Vertices[0]);
            Vector2 upper = lower;

            for (int i = 1; i < VertexCount; ++i)
            {
                Vector2 v = Math.Mul(xf, Vertices[i]);
                lower = Math.Min(lower, v);
                upper = Math.Max(upper, v);
            }

            Vector2 r = new Vector2(Radius);
            aabb.LowerBound = lower - r;
            aabb.UpperBound = upper + r;
        }

        /// <summary>
        ///     Computes the mass using the specified mass data
        /// </summary>
        /// <param name="massData">The mass data</param>
        /// <param name="denstity">The denstity</param>
        public override void ComputeMass(out MassData massData, float denstity)
        {
            // Polygon mass, centroid, and inertia.
            // Let rho be the polygon density in mass per unit area.
            // Then:
            // mass = rho * int(dA)
            // centroid.x = (1/mass) * rho * int(x * dA)
            // centroid.y = (1/mass) * rho * int(y * dA)
            // I = rho * int((x*x + y*y) * dA)
            //
            // We can compute these integrals by summing all the integrals
            // for each triangle of the polygon. To evaluate the integral
            // for a single triangle, we make a change of variables to
            // the (u,v) coordinates of the triangle:
            // x = x0 + e1x * u + e2x * v
            // y = y0 + e1y * u + e2y * v
            // where 0 <= u && 0 <= v && u + v <= 1.
            //
            // We integrate u from [0,1-v] and then v from [0,1].
            // We also need to use the Jacobian of the transformation:
            // D = cross(e1, e2)
            //
            // Simplification: triangle centroid = (1/3) * (p1 + p2 + p3)
            //
            // The rest of the derivation is handled by computer algebra.

            Box2DxDebug.Assert(VertexCount >= 3);

            Vector2 center = new Vector2(0);
            float area = 0.0f;
            float I = 0.0f;

            // pRef is the reference point for forming triangles.
            // It's location doesn't change the result (except for rounding error).
            Vector2 pRef = new Vector2(0);

#if O
			// This code would put the reference point inside the polygon.
			for (int i = 0; i < vCount; ++i)
			{
				pRef += _vertices[i];
			}
			pRef *= 1.0f / count;
#endif

            const float kInv3 = 1.0f / 3.0f;

            for (int i = 0; i < VertexCount; ++i)
            {
                // Triangle vertices.
                Vector2 p1 = pRef;
                Vector2 p2 = Vertices[i];
                Vector2 p3 = i + 1 < VertexCount ? Vertices[i + 1] : Vertices[0];

                Vector2 e1 = p2 - p1;
                Vector2 e2 = p3 - p1;

                float d = Vector2.Cross(e1, e2);

                float triangleArea = 0.5f * d;
                area += triangleArea;

                // Area weighted centroid
                center += triangleArea * kInv3 * (p1 + p2 + p3);

                float px = p1.X, py = p1.Y;
                float ex1 = e1.X, ey1 = e1.Y;
                float ex2 = e2.X, ey2 = e2.Y;

                float intx2 = kInv3 * (0.25f * (ex1 * ex1 + ex2 * ex1 + ex2 * ex2) + (px * ex1 + px * ex2)) +
                              0.5f * px * px;
                float inty2 = kInv3 * (0.25f * (ey1 * ey1 + ey2 * ey1 + ey2 * ey2) + (py * ey1 + py * ey2)) +
                              0.5f * py * py;

                I += d * (intx2 + inty2);
            }

            // Total mass
            massData.Mass = denstity * area;

            // Center of mass
            Box2DxDebug.Assert(area > Settings.FltEpsilon);
            center *= 1.0f / area;
            massData.Center = center;

            // Inertia tensor relative to the local origin.
            massData.I = denstity * I;
        }

        /// <summary>
        ///     Computes the submerged area using the specified normal
        /// </summary>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <param name="xf">The xf</param>
        /// <param name="c">The </param>
        /// <returns>The area</returns>
        public override float ComputeSubmergedArea(Vector2 normal, float offset, XForm xf, out Vector2 c)
        {
            //Transform plane into shape co-ordinates
            Vector2 normalL = Math.MulT(xf.R, normal);
            float offsetL = offset - Vector2.Dot(normal, xf.Position);

            float[] depths = new float[Settings.MaxPolygonVertices];
            int diveCount = 0;
            int intoIndex = -1;
            int outoIndex = -1;

            bool lastSubmerged = false;
            int i;
            for (i = 0; i < VertexCount; i++)
            {
                depths[i] = Vector2.Dot(normalL, Vertices[i]) - offsetL;
                bool isSubmerged = depths[i] < -Settings.FltEpsilon;
                if (i > 0)
                {
                    if (isSubmerged)
                    {
                        if (!lastSubmerged)
                        {
                            intoIndex = i - 1;
                            diveCount++;
                        }
                    }
                    else
                    {
                        if (lastSubmerged)
                        {
                            outoIndex = i - 1;
                            diveCount++;
                        }
                    }
                }

                lastSubmerged = isSubmerged;
            }

            switch (diveCount)
            {
                case 0:
                    if (lastSubmerged)
                    {
                        //Completely submerged
                        MassData md;
                        ComputeMass(out md, 1f);
                        c = Math.Mul(xf, md.Center);
                        return md.Mass;
                    }

                    // Completely dry
                    c = new Vector2();
                    return 0;
                case 1:
                    if (intoIndex == -1)
                    {
                        intoIndex = VertexCount - 1;
                    }
                    else
                    {
                        outoIndex = VertexCount - 1;
                    }

                    break;
            }

            int intoIndex2 = (intoIndex + 1) % VertexCount;
            int outoIndex2 = (outoIndex + 1) % VertexCount;

            float intoLambda = (0 - depths[intoIndex]) / (depths[intoIndex2] - depths[intoIndex]);
            float outoLambda = (0 - depths[outoIndex]) / (depths[outoIndex2] - depths[outoIndex]);

            Vector2 intoVec = new Vector2(Vertices[intoIndex].X * (1 - intoLambda) + Vertices[intoIndex2].X * intoLambda,
                Vertices[intoIndex].Y * (1 - intoLambda) + Vertices[intoIndex2].Y * intoLambda);
            Vector2 outoVec = new Vector2(Vertices[outoIndex].X * (1 - outoLambda) + Vertices[outoIndex2].X * outoLambda,
                Vertices[outoIndex].Y * (1 - outoLambda) + Vertices[outoIndex2].Y * outoLambda);

            //Initialize accumulator
            float area = 0;
            Vector2 center = new Vector2(0);
            Vector2 p2 = Vertices[intoIndex2];
            Vector2 p3;

            const float kInv3 = 1.0f / 3.0f;

            //An awkward loop from intoIndex2+1 to outIndex2
            i = intoIndex2;
            while (i != outoIndex2)
            {
                i = (i + 1) % VertexCount;
                if (i == outoIndex2)
                {
                    p3 = outoVec;
                }
                else
                {
                    p3 = Vertices[i];
                }

                //Add the triangle formed by intoVec,p2,p3
                {
                    Vector2 e1 = p2 - intoVec;
                    Vector2 e2 = p3 - intoVec;

                    float d = Vector2.Cross(e1, e2);

                    float triangleArea = 0.5f * d;

                    area += triangleArea;

                    // Area weighted centroid
                    center += triangleArea * kInv3 * (intoVec + p2 + p3);
                }
                //
                p2 = p3;
            }

            //Normalize and transform centroid
            center *= 1.0f / area;

            c = Math.Mul(xf, center);

            return area;
        }

        /// <summary>
        ///     Computes the sweep radius using the specified pivot
        /// </summary>
        /// <param name="pivot">The pivot</param>
        /// <returns>The float</returns>
        public override float ComputeSweepRadius(Vector2 pivot)
        {
            int vCount = VertexCount;
            Box2DxDebug.Assert(vCount > 0);
            float sr = Vector2.DistanceSquared(Vertices[0], pivot);
            for (int i = 1; i < vCount; ++i)
            {
                sr = Math.Max(sr, Vector2.DistanceSquared(Vertices[i], pivot));
            }

            return Math.Sqrt(sr);
        }

        /// <summary>
        ///     Get the supporting vertex index in the given direction.
        /// </summary>
        public override int GetSupport(Vector2 d)
        {
            int bestIndex = 0;
            float bestValue = Vector2.Dot(Vertices[0], d);
            for (int i = 1; i < VertexCount; ++i)
            {
                float value = Vector2.Dot(Vertices[i], d);
                if (value > bestValue)
                {
                    bestIndex = i;
                    bestValue = value;
                }
            }

            return bestIndex;
        }

        /// <summary>
        ///     Gets the support vertex using the specified d
        /// </summary>
        /// <param name="d">The </param>
        /// <returns>The vec</returns>
        public override Vector2 GetSupportVertex(Vector2 d)
        {
            int bestIndex = 0;
            float bestValue = Vector2.Dot(Vertices[0], d);
            for (int i = 1; i < VertexCount; ++i)
            {
                float value = Vector2.Dot(Vertices[i], d);
                if (value > bestValue)
                {
                    bestIndex = i;
                    bestValue = value;
                }
            }

            return Vertices[bestIndex];
        }

        /// <summary>
        ///     Gets the vertex using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The vec</returns>
        public override Vector2 GetVertex(int index)
        {
            Box2DxDebug.Assert(0 <= index && index < VertexCount);
            return Vertices[index];
        }

        /// <summary>
        ///     Computes the centroid using the specified vs
        /// </summary>
        /// <param name="vs">The vs</param>
        /// <param name="count">The count</param>
        /// <returns>The </returns>
        public static Vector2 ComputeCentroid(Vector2[] vs, int count)
        {
            Box2DxDebug.Assert(count >= 3);

            Vector2 c = new Vector2(0f);
            float area = 0f;

            // pRef is the reference point for forming triangles.
            // It's location doesn't change the result (except for rounding error).
            Vector2 pRef = new Vector2(0f);
#if O
			// This code would put the reference point inside the polygon.
			for (int i = 0; i < count; ++i)
			{
				pRef += vs[i];
			}
			pRef *= 1.0f / count;
#endif

            const float inv3 = 1.0f / 3.0f;

            for (int i = 0; i < count; ++i)
            {
                // Triangle vertices.
                Vector2 p1 = pRef;
                Vector2 p2 = vs[i];
                Vector2 p3 = i + 1 < count ? vs[i + 1] : vs[0];

                Vector2 e1 = p2 - p1;
                Vector2 e2 = p3 - p1;

                float d = Vector2.Cross(e1, e2);

                float triangleArea = 0.5f * d;
                area += triangleArea;

                // Area weighted centroid
                c += triangleArea * inv3 * (p1 + p2 + p3);
            }

            // Centroid
            Box2DxDebug.Assert(area > Settings.FltEpsilon);
            c *= 1.0f / area;
            return c;
        }

        /*// http://www.geometrictools.com/Documentation/MinimumAreaRectangle.pdf
        public static void ComputeOBB(out OBB obb, Vec2[] vs, int count)
        {
            obb = new OBB();

            Box2DXDebug.Assert(count <= Settings.MaxPolygonVertices);
            Vec2[] p = new Vec2[Settings.MaxPolygonVertices + 1];
            for (int i = 0; i < count; ++i)
            {
                p[i] = vs[i];
            }
            p[count] = p[0];

            float minArea = Common.Settings.FLT_MAX;

            for (int i = 1; i <= count; ++i)
            {
                Vec2 root = p[i - 1];
                Vec2 ux = p[i] - root;
                float length = ux.Normalize();
                Box2DXDebug.Assert(length > Common.Settings.FLT_EPSILON);
                Vec2 uy = new Vec2(-ux.Y, ux.X);
                Vec2 lower = new Vec2(Common.Settings.FLT_MAX, Common.Settings.FLT_MAX);
                Vec2 upper = new Vec2(-Common.Settings.FLT_MAX, -Common.Settings.FLT_MAX);

                for (int j = 0; j < count; ++j)
                {
                    Vec2 d = p[j] - root;
                    Vec2 r = new Vec2();
                    r.X = Vec2.Dot(ux, d);
                    r.Y = Vec2.Dot(uy, d);
                    lower = Common.Math.Min(lower, r);
                    upper = Common.Math.Max(upper, r);
                }

                float area = (upper.X - lower.X) * (upper.Y - lower.Y);
                if (area < 0.95f * minArea)
                {
                    minArea = area;
                    obb.R.Col1 = ux;
                    obb.R.Col2 = uy;
                    Vec2 center = 0.5f * (lower + upper);
                    obb.Center = root + Common.Math.Mul(obb.R, center);
                    obb.Extents = 0.5f * (upper - lower);
                }
            }

            Box2DXDebug.Assert(minArea < Common.Settings.FLT_MAX);
        }*/
    }
}