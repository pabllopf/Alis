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

using System;
using System.Diagnostics;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Collision.RayCast;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Collision.Shapes
{
    /// <summary>Represents a simple non-self intersecting convex polygon. Create a convex hull from the given array of points.</summary>
    public class PolygonShape : Shape
    {
        /// <summary>
        ///     The normals
        /// </summary>
        internal Vertices NormalsPrivate;

        /// <summary>
        ///     The vertices
        /// </summary>
        internal Vertices VerticesPrivate;

        /// <summary>Initializes a new instance of the <see cref="PolygonShape" /> class.</summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="density">The density.</param>
        public PolygonShape(Vertices vertices, float density) : base(ShapeType.Polygon, Settings.PolygonRadius, density)
        {
            SetVertices(vertices);
        }

        /// <summary>Initializes a new instance of the <see cref="PolygonShape" /> class.</summary>
        /// <param name="density">The density.</param>
        public PolygonShape(float density) : base(ShapeType.Polygon, Settings.PolygonRadius, density)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonShape" /> class
        /// </summary>
        private PolygonShape() : base(ShapeType.Polygon, Settings.PolygonRadius)
        {
        }

        /// <summary>
        ///     Create a convex hull from the given array of local points. The number of vertices must be in the range [3,
        ///     Settings.MaxPolygonVertices]. Warning: the points may be re-ordered, even if they form a convex polygon Warning:
        ///     collinear points are handled but not removed. Collinear points may lead to poor stacking behavior.
        /// </summary>
        public Vertices Vertices
        {
            get => VerticesPrivate;
            set => SetVertices(value);
        }

        /// <summary>
        ///     Gets the value of the normals
        /// </summary>
        public Vertices Normals => NormalsPrivate;

        /// <summary>
        ///     Gets the value of the child count
        /// </summary>
        public override int ChildCount => 1;

        /// <summary>
        ///     Sets the vertices using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <exception cref="InvalidOperationException">Polygon is degenerate</exception>
        /// <exception cref="InvalidOperationException">Polygon is degenerate</exception>
        /// <exception cref="InvalidOperationException">You can't create a polygon with less than 3 vertices</exception>
        private void SetVertices(Vertices vertices)
        {
            Debug.Assert(vertices.Count >= 3 && vertices.Count <= Settings.MaxPolygonVertices);

            //Velcro: We throw an exception instead of setting the polygon to a box for safety reasons
            if (vertices.Count < 3)
            {
                throw new InvalidOperationException("You can't create a polygon with less than 3 vertices");
            }

            int n = MathUtils.Min(vertices.Count, Settings.MaxPolygonVertices);

            // Perform welding and copy vertices into local buffer.
            Vector2[] ps = new Vector2[n]; //Velcro: The temp buffer is n long instead of Settings.MaxPolygonVertices
            int tempCount = 0;
            for (int i = 0; i < n; ++i)
            {
                Vector2 v = vertices[i];

                bool unique = true;
                for (int j = 0; j < tempCount; ++j)
                {
                    Vector2 temp = ps[j];
                    if (MathUtils.DistanceSquared(ref v, ref temp) <
                        0.5f * Settings.LinearSlop * (0.5f * Settings.LinearSlop))
                    {
                        unique = false;
                        break;
                    }
                }

                if (unique)
                {
                    ps[tempCount++] = v;
                }
            }

            n = tempCount;
            if (n < 3)
            {
                // Polygon is degenerate.
                throw
                    new InvalidOperationException(
                        "Polygon is degenerate"); //Velcro: We throw exception here because we had invalid input
            }

            // Create the convex hull using the Gift wrapping algorithm
            // http://en.wikipedia.org/wiki/Gift_wrapping_algorithm

            // Find the right most point on the hull
            int i0 = 0;
            float x0 = ps[0].X;
            for (int i = 1; i < n; ++i)
            {
                float x = ps[i].X;
                if (x > x0 || x == x0 && ps[i].Y < ps[i0].Y)
                {
                    i0 = i;
                    x0 = x;
                }
            }

            int[] hull = new int[Settings.MaxPolygonVertices];
            int m = 0;
            int ih = i0;

            for (;;)
            {
                Debug.Assert(m < Settings.MaxPolygonVertices);
                hull[m] = ih;

                int ie = 0;
                for (int j = 1; j < n; ++j)
                {
                    if (ie == ih)
                    {
                        ie = j;
                        continue;
                    }

                    Vector2 r = ps[ie] - ps[hull[m]];
                    Vector2 v = ps[j] - ps[hull[m]];
                    float c = MathUtils.Cross(r, v);
                    if (c < 0.0f)
                    {
                        ie = j;
                    }

                    // Collinearity check
                    if (c == 0.0f && v.LengthSquared() > r.LengthSquared())
                    {
                        ie = j;
                    }
                }

                ++m;
                ih = ie;

                if (ie == i0)
                {
                    break;
                }
            }

            if (m < 3)
            {
                // Polygon is degenerate.
                throw
                    new InvalidOperationException(
                        "Polygon is degenerate"); //Velcro: We throw exception here because we had invalid input
            }

            VerticesPrivate = new Vertices(m);

            // Copy vertices.
            for (int i = 0; i < m; ++i)
            {
                VerticesPrivate.Add(ps[hull[i]]);
            }

            NormalsPrivate = new Vertices(m);

            // Compute normals. Ensure the edges have non-zero length.
            for (int i = 0; i < m; ++i)
            {
                int i1 = i;
                int i2 = i + 1 < VerticesPrivate.Count ? i + 1 : 0;
                Vector2 edge = VerticesPrivate[i2] - VerticesPrivate[i1];
                Debug.Assert(edge.LengthSquared() > MathConstants.Epsilon * MathConstants.Epsilon);
                Vector2 temp = MathUtils.Cross(edge, 1.0f);
                temp = Vector2.Normalize(temp);
                NormalsPrivate.Add(temp);
            }

            //Velcro: We compute all the mass data properties up front
            ComputeProperties();
        }

        /// <summary>
        ///     Sets the as box using the specified hx
        /// </summary>
        /// <param name="hx">The hx</param>
        /// <param name="hy">The hy</param>
        public void SetAsBox(float hx, float hy)
        {
            VerticesPrivate = PolygonUtils.CreateRectangle(hx, hy);

            NormalsPrivate = new Vertices(4)
            {
                new Vector2(0.0f, -1.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(0.0f, 1.0f),
                new Vector2(-1.0f, 0.0f)
            };

            ComputeProperties();
        }

        /// <summary>
        ///     Sets the as box using the specified hx
        /// </summary>
        /// <param name="hx">The hx</param>
        /// <param name="hy">The hy</param>
        /// <param name="center">The center</param>
        /// <param name="angle">The angle</param>
        public void SetAsBox(float hx, float hy, Vector2 center, float angle)
        {
            VerticesPrivate = PolygonUtils.CreateRectangle(hx, hy);

            NormalsPrivate = new Vertices(4)
            {
                new Vector2(0.0f, -1.0f),
                new Vector2(1.0f, 0.0f),
                new Vector2(0.0f, 1.0f),
                new Vector2(-1.0f, 0.0f)
            };

            MassDataPrivate.Centroid = center;

            Transform xf = new Transform
            {
                P = center
            };
            xf.Q.Set(angle);

            // Transform vertices and normals.
            for (int i = 0; i < 4; ++i)
            {
                VerticesPrivate[i] = MathUtils.Mul(ref xf, VerticesPrivate[i]);
                NormalsPrivate[i] = MathUtils.Mul(ref xf.Q, NormalsPrivate[i]);
            }

            ComputeProperties();
        }

        /// <summary>
        ///     Computes the properties
        /// </summary>
        protected sealed override void ComputeProperties()
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

            Debug.Assert(VerticesPrivate.Count >= 3);

            //Velcro: Early exit as polygons with 0 density does not have any properties.
            if (DensityPrivate <= 0)
            {
                return;
            }

            //Velcro: Consolidated the calculate centroid and mass code to a single method.
            Vector2 center = Vector2.Zero;
            float area = 0.0f;
            float I = 0.0f;

            // Get a reference point for forming triangles.
            // Use the first vertex to reduce round-off errors.
            Vector2 s = VerticesPrivate[0];

            const float inv3 = 1.0f / 3.0f;

            int count = VerticesPrivate.Count;

            for (int i = 0; i < count; ++i)
            {
                // Triangle vertices.
                Vector2 e1 = VerticesPrivate[i] - s;
                Vector2 e2 = i + 1 < count ? VerticesPrivate[i + 1] - s : VerticesPrivate[0] - s;

                float d = MathUtils.Cross(e1, e2);

                float triangleArea = 0.5f * d;
                area += triangleArea;

                // Area weighted centroid
                center += triangleArea * inv3 * (e1 + e2);

                float ex1 = e1.X, ey1 = e1.Y;
                float ex2 = e2.X, ey2 = e2.Y;

                float intx2 = ex1 * ex1 + ex2 * ex1 + ex2 * ex2;
                float inty2 = ey1 * ey1 + ey2 * ey1 + ey2 * ey2;

                I += 0.25f * inv3 * d * (intx2 + inty2);
            }

            //The area is too small for the engine to handle.
            Debug.Assert(area > MathConstants.Epsilon);

            // We save the area
            MassDataPrivate.Area = area;

            // Total mass
            MassDataPrivate.Mass = DensityPrivate * area;

            // Center of mass
            center *= 1.0f / area;
            MassDataPrivate.Centroid = center + s;

            // Inertia tensor relative to the local origin (point s).
            MassDataPrivate.Inertia = DensityPrivate * I;

            // Shift to center of mass then to original body origin.
            MassDataPrivate.Inertia += MassDataPrivate.Mass *
                                       (MathUtils.Dot(MassDataPrivate.Centroid, MassDataPrivate.Centroid) -
                                        MathUtils.Dot(center, center));
        }

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public override bool TestPoint(ref Transform transform, ref Vector2 point) =>
            TestPointHelper.TestPointPolygon(VerticesPrivate, NormalsPrivate, ref point, ref transform);

        /// <summary>
        ///     Describes whether this instance ray cast
        /// </summary>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <param name="output">The output</param>
        /// <returns>The bool</returns>
        public override bool RayCast(ref RayCastInput input, ref Transform transform, int childIndex,
            out RayCastOutput output) =>
            RayCastHelper.RayCastPolygon(VerticesPrivate, NormalsPrivate, ref input, ref transform, out output);

        /// <summary>Given a transform, compute the associated axis aligned bounding box for a child shape.</summary>
        /// <param name="transform">The world transform of the shape.</param>
        /// <param name="childIndex">The child shape index.</param>
        /// <param name="aabb">The AABB results.</param>
        public override void ComputeAabb(ref Transform transform, int childIndex, out Aabb aabb)
        {
            AabbHelper.ComputePolygonAabb(VerticesPrivate, ref transform, out aabb);
        }

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The clone</returns>
        public override Shape Clone()
        {
            PolygonShape clone = new PolygonShape
            {
                ShapeTypePrivate = ShapeTypePrivate,
                RadiusPrivate = RadiusPrivate,
                DensityPrivate = DensityPrivate,
                VerticesPrivate = new Vertices(VerticesPrivate),
                NormalsPrivate = new Vertices(NormalsPrivate),
                MassDataPrivate = MassDataPrivate
            };
            return clone;
        }
    }
}