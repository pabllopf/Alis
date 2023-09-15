// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonShape.cs
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
using System.Linq;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Collision.Shapes
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
        /// Sets the vertices using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <exception cref="InvalidOperationException">Thrown when polygon is degenerate or has less than 3 vertices</exception>
        private void SetVertices(Vertices vertices)
        {
            CheckVerticesValidity(vertices);

            Vector2[] cleanedVertices = RemoveDuplicateVertices(vertices);
            int numberOfVertices = cleanedVertices.Length;

            int rightmostVertexIndex = FindRightmostVertex(cleanedVertices, numberOfVertices);

            int[] hull = ComputeConvexHull(cleanedVertices, numberOfVertices, rightmostVertexIndex);

            if (hull.Length < 3)
            {
                throw new InvalidOperationException("Polygon is degenerate");
            }

            CopyVerticesAndComputeNormals(cleanedVertices, hull);
            ComputeProperties();
        }

        private void CheckVerticesValidity(Vertices vertices)
        {
            if (vertices.Count < 3)
            {
                throw new InvalidOperationException("You can't create a polygon with less than 3 vertices");
            }
        }

        private Vector2[] RemoveDuplicateVertices(Vertices vertices)
        {
            List<Vector2> cleanedVertices = new List<Vector2>();
            for (int i =0; i < vertices.Count; i++)
            {
                Vector2 vector2 = vertices[i];
                bool unique = !cleanedVertices.Any(v => MathUtils.DistanceSquared(ref vector2, ref v) <
                                                        0.5f * Settings.LinearSlop * (0.5f * Settings.LinearSlop));

                if (unique)
                {
                    cleanedVertices.Add(vector2);
                }
            }

            return cleanedVertices.ToArray();
        }

        private int FindRightmostVertex(Vector2[] vertices, int numberOfVertices)
        {
            int rightmostVertexIndex = 0;
            float maxX = vertices[0].X;

            for (int i = 1; i < numberOfVertices; ++i)
            {
                float x = vertices[i].X;
                if (x > maxX || ((x == maxX) && (vertices[i].Y < vertices[rightmostVertexIndex].Y)))
                {
                    rightmostVertexIndex = i;
                    maxX = x;
                }
            }

            return rightmostVertexIndex;
        }

        private int[] ComputeConvexHull(Vector2[] vertices, int numberOfVertices, int rightmostVertexIndex)
        {
            List<int> hull = new List<int>();
            int currentIndex = rightmostVertexIndex;

            do
            {
                hull.Add(currentIndex);

                int nextIndex = 0;
                for (int j = 1; j < numberOfVertices; ++j)
                {
                    if (nextIndex == currentIndex)
                    {
                        nextIndex = j;
                        continue;
                    }

                    Vector2 r = vertices[nextIndex] - vertices[hull.Last()];
                    Vector2 v = vertices[j] - vertices[hull.Last()];
                    float c = MathUtils.Cross(r, v);

                    if (c < 0.0f)
                    {
                        nextIndex = j;
                    }

                    if ((c == 0.0f) && (v.LengthSquared() > r.LengthSquared()))
                    {
                        nextIndex = j;
                    }
                }

                currentIndex = nextIndex;

            } while (currentIndex != rightmostVertexIndex);

            return hull.ToArray();
        }

        private void CopyVerticesAndComputeNormals(Vector2[] vertices, int[] hull)
        {
            int numberOfVertices = hull.Length;

            VerticesPrivate = new Vertices(numberOfVertices);
            NormalsPrivate = new Vertices(numberOfVertices);

            for (int i = 0; i < numberOfVertices; ++i)
            {
                VerticesPrivate.Add(vertices[hull[i]]);
            }

            for (int i = 0; i < numberOfVertices; ++i)
            {
                int i1 = i;
                int i2 = i + 1 < numberOfVertices ? i + 1 : 0;
                Vector2 edge = VerticesPrivate[i2] - VerticesPrivate[i1];
                Debug.Assert(edge.LengthSquared() > Constant.Epsilon * Constant.Epsilon);
                Vector2 temp = MathUtils.Cross(edge, 1.0f);
                temp = Vector2.Normalize(temp);
                NormalsPrivate.Add(temp);
            }
        }


        /// <summary>
        ///     Sets the as box using the specified hx
        /// </summary>
        /// <param name="hx">The hx</param>
        /// <param name="hy">The hy</param>
        public void SetAsBox(float hx, float hy)
        {
            VerticesPrivate = Polygon.CreateRectangle(hx, hy);

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
            VerticesPrivate = Polygon.CreateRectangle(hx, hy);

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
                Position = center
            };
            xf.Rotation.Set(angle);

            // Transform vertices and normals.
            for (int i = 0; i < 4; ++i)
            {
                VerticesPrivate[i] = MathUtils.Mul(ref xf, VerticesPrivate[i]);
                NormalsPrivate[i] = MathUtils.Mul(ref xf.Rotation, NormalsPrivate[i]);
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
            Debug.Assert(area > Constant.Epsilon);

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