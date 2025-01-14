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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.ConvexHull;
using Alis.Core.Physic.Dynamics;
using Transform = Alis.Core.Physic.Common.Transform;


namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     Represents a simple non-selfintersecting convex polygon.
    ///     Create a convex hull from the given array of points.
    /// </summary>
    public class PolygonShape : Shape
    {
        /// <summary>
        ///     The vertices
        /// </summary>
        private Vertices _vertices;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonShape" /> class.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="density">The density.</param>
        public PolygonShape(Vertices vertices, float density)
            : base(density)
        {
            ShapeType = ShapeType.Polygon;
            Radius = SettingEnv.PolygonRadius;

            Vertices = vertices;
        }

        /// <summary>
        ///     Create a new PolygonShape with the specified density.
        /// </summary>
        /// <param name="density">The density.</param>
        public PolygonShape(float density)
            : base(density)
        {
            Debug.Assert(density >= 0f);

            ShapeType = ShapeType.Polygon;
            Radius = SettingEnv.PolygonRadius;
            _vertices = new Vertices(SettingEnv.MaxPolygonVertices);
            Normals = new Vertices(SettingEnv.MaxPolygonVertices);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonShape" /> class
        /// </summary>
        internal PolygonShape()
            : base(0)
        {
            ShapeType = ShapeType.Polygon;
            Radius = SettingEnv.PolygonRadius;
            _vertices = new Vertices(SettingEnv.MaxPolygonVertices);
            Normals = new Vertices(SettingEnv.MaxPolygonVertices);
        }

        /// <summary>
        ///     Create a convex hull from the given array of local points.
        ///     The number of vertices must be in the range [3, Settings.MaxPolygonVertices].
        ///     Warning: the points may be re-ordered, even if they form a convex polygon
        ///     Warning: collinear points are handled but not removed. Collinear points may lead to poor stacking behavior.
        /// </summary>
        public Vertices Vertices
        {
            get => _vertices;
            set
            {
                _vertices = new Vertices(value);

                Debug.Assert((_vertices.Count >= 3) && (_vertices.Count <= SettingEnv.MaxPolygonVertices));

                if (SettingEnv.UseConvexHullPolygons)
                {
                    //FPE note: This check is required as the GiftWrap algorithm early exits on triangles
                    //So instead of giftwrapping a triangle, we just force it to be clock wise.
                    if (_vertices.Count <= 3)
                    {
                        _vertices.ForceCounterClockWise();
                    }
                    else
                    {
                        _vertices = GiftWrap.GetConvexHull(_vertices);
                    }
                }

                Normals = new Vertices(_vertices.Count);

                // Compute normals. Ensure the edges have non-zero length.
                for (int i = 0; i < _vertices.Count; ++i)
                {
                    int next = i + 1 < _vertices.Count ? i + 1 : 0;
                    Vector2F edge = _vertices[next] - _vertices[i];
                    Debug.Assert(edge.LengthSquared() > SettingEnv.Epsilon * SettingEnv.Epsilon);

                    //FPE optimization: Normals.Add(MathUtils.Cross(edge, 1.0f));
                    Vector2F temp = new Vector2F(edge.Y, -edge.X);
                    temp.Normalize();
                    Normals.Add(temp);
                }

                // Compute the polygon mass data
                ComputeProperties();
            }
        }

        /// <summary>
        ///     Gets or sets the value of the normals
        /// </summary>
        public Vertices Normals { get; private set; }

        /// <summary>
        ///     Gets the value of the child count
        /// </summary>
        public override int ChildCount => 1;

        /// <summary>
        ///     Computes the properties
        /// </summary>
        protected override void ComputeProperties()
        {
            // Polygon mass, centroid, and inertia.
            // Let rho be the polygon density in mass per unit area.
            // Then:
            // mass = rho * int(dA)
            // centroid.X = (1/mass) * rho * int(x * dA)
            // centroid.Y = (1/mass) * rho * int(y * dA)
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

            Debug.Assert(Vertices.Count >= 3);

            //FPE optimization: Early exit as polygons with 0 density does not have any properties.
            if (Density <= 0)
            {
                return;
            }

            //FPE optimization: Consolidated the calculate centroid and mass code to a single method.
            Vector2F center = Vector2F.Zero;
            float area = 0.0f;
            float inv3 = 0.0f;

            // pRef is the reference point for forming triangles.
            // It's location doesn't change the result (except for rounding error).
            Vector2F s = Vector2F.Zero;

            // This code would put the reference point inside the polygon.
            for (int i = 0; i < Vertices.Count; ++i)
            {
                s += Vertices[i];
            }

            s *= 1.0f / Vertices.Count;

            const float kInv3 = 1.0f / 3.0f;

            for (int i = 0; i < Vertices.Count; ++i)
            {
                // Triangle vertices.
                Vector2F e1 = Vertices[i] - s;
                Vector2F e2 = i + 1 < Vertices.Count ? Vertices[i + 1] - s : Vertices[0] - s;

                float d = MathUtils.Cross(ref e1, ref e2);

                float triangleArea = 0.5f * d;
                area += triangleArea;

                // Area weighted centroid
                center += triangleArea * kInv3 * (e1 + e2);

                float ex1 = e1.X, ey1 = e1.Y;
                float ex2 = e2.X, ey2 = e2.Y;

                float intx2 = ex1 * ex1 + ex2 * ex1 + ex2 * ex2;
                float inty2 = ey1 * ey1 + ey2 * ey1 + ey2 * ey2;

                inv3 += 0.25f * kInv3 * d * (intx2 + inty2);
            }

            //The area is too small for the engine to handle.
            Debug.Assert(area > SettingEnv.Epsilon);

            // We save the area
            MassData.Area = area;

            // Total mass
            MassData.Mass = Density * area;

            // Center of mass
            center *= 1.0f / area;
            MassData.Centroid = center + s;

            // Inertia tensor relative to the local origin (point s).
            MassData.Inertia = Density * inv3;

            // Shift to center of mass then to original body origin.
            MassData.Inertia += MassData.Mass * (Vector2F.Dot(MassData.Centroid, MassData.Centroid) - Vector2F.Dot(center, center));
        }

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public override bool TestPoint(ref Transform transform, ref Vector2F point)
        {
            Vector2F pLocal = Complex.Divide(point - transform.p, ref transform.q);

            for (int i = 0; i < Vertices.Count; ++i)
            {
                float dot = Vector2F.Dot(Normals[i], pLocal - Vertices[i]);
                if (dot > 0.0f)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Describes whether this instance ray cast
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        /// <param name="transform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <returns>The bool</returns>
        public override bool RayCast(out RayCastOutput output, ref RayCastInput input, ref Transform transform, int childIndex)
        {
            output = new RayCastOutput();

            // Put the ray into the polygon's frame of reference.
            Vector2F p1 = Complex.Divide(input.Point1 - transform.p, ref transform.q);
            Vector2F p2 = Complex.Divide(input.Point2 - transform.p, ref transform.q);
            Vector2F d = p2 - p1;

            float lower = 0.0f, upper = input.MaxFraction;

            int index = -1;

            for (int i = 0; i < Vertices.Count; ++i)
            {
                // p = p1 + a * d
                // dot(normal, p - v) = 0
                // dot(normal, p1 - v) + a * dot(normal, d) = 0
                float numerator = Vector2F.Dot(Normals[i], Vertices[i] - p1);
                float denominator = Vector2F.Dot(Normals[i], d);

                if (Math.Abs(denominator) < SettingEnv.Epsilon)
                {
                    if (numerator < 0.0f)
                    {
                        return false;
                    }
                }
                else
                {
                    // Note: we want this predicate without division:
                    // lower < numerator / denominator, where denominator < 0
                    // Since denominator < 0, we have to flip the inequality:
                    // lower < numerator / denominator <==> denominator * lower > numerator.
                    if ((denominator < 0.0f) && (numerator < lower * denominator))
                    {
                        // Increase lower.
                        // The segment enters this half-space.
                        lower = numerator / denominator;
                        index = i;
                    }
                    else if ((denominator > 0.0f) && (numerator < upper * denominator))
                    {
                        // Decrease upper.
                        // The segment exits this half-space.
                        upper = numerator / denominator;
                    }
                }

                // The use of epsilon here causes the assert on lower to trip
                // in some cases. Apparently the use of epsilon was to make edge
                // shapes work, but now those are handled separately.
                //if (upper < lower - b2_epsilon)
                if (upper < lower)
                {
                    return false;
                }
            }

            Debug.Assert((0.0f <= lower) && (lower <= input.MaxFraction));

            if (index >= 0)
            {
                output.Fraction = lower;
                output.Normal = Complex.Multiply(Normals[index], ref transform.q);
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Given a transform, compute the associated axis aligned bounding box for a child shape.
        /// </summary>
        /// <param name="aabb">The aabb results.</param>
        /// <param name="transform">The world transform of the shape.</param>
        /// <param name="childIndex">The child shape index.</param>
        public override void ComputeAabb(out Aabb aabb, ref Transform transform, int childIndex)
        {
            aabb = new Aabb();

            // OPT: aabb.LowerBound = Transform.Multiply(Vertices[0], ref transform);
            Vector2F vert = Vertices[0];
            aabb.LowerBound.X = vert.X * transform.q.R - vert.Y * transform.q.I + transform.p.X;
            aabb.LowerBound.Y = vert.Y * transform.q.R + vert.X * transform.q.I + transform.p.Y;
            aabb.UpperBound = aabb.LowerBound;

            for (int i = 1; i < Vertices.Count; ++i)
            {
                // OPT: Vector2F v = Transform.Multiply(Vertices[i], ref transform);
                vert = Vertices[i];
                float vX = vert.X * transform.q.R - vert.Y * transform.q.I + transform.p.X;
                float vY = vert.Y * transform.q.R + vert.X * transform.q.I + transform.p.Y;

                // OPT: Vector2F.Min(ref aabb.LowerBound, ref v, out aabb.LowerBound);
                // OPT: Vector2F.Max(ref aabb.UpperBound, ref v, out aabb.UpperBound);
                Debug.Assert(aabb.LowerBound.X <= aabb.UpperBound.X);
                if (vX < aabb.LowerBound.X)
                {
                    aabb.LowerBound.X = vX;
                }
                else if (vX > aabb.UpperBound.X)
                {
                    aabb.UpperBound.X = vX;
                }

                Debug.Assert(aabb.LowerBound.Y <= aabb.UpperBound.Y);
                if (vY < aabb.LowerBound.Y)
                {
                    aabb.LowerBound.Y = vY;
                }
                else if (vY > aabb.UpperBound.Y)
                {
                    aabb.UpperBound.Y = vY;
                }
            }

            // OPT: Vector2F r = new Vector2F(Radius, Radius);
            // OPT: aabb.LowerBound = aabb.LowerBound - r;
            // OPT: aabb.UpperBound = aabb.UpperBound + r;
            aabb.LowerBound.X -= GetRadius;
            aabb.LowerBound.Y -= GetRadius;
            aabb.UpperBound.X += GetRadius;
            aabb.UpperBound.Y += GetRadius;
        }

        /// <summary>
        ///     Computes the submerged area using the specified normal
        /// </summary>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <param name="xf">The xf</param>
        /// <param name="sc">The sc</param>
        /// <returns>The area</returns>
        public override float ComputeSubmergedArea(ref Vector2F normal, float offset, ref Transform xf, out Vector2F sc)
        {
            sc = Vector2F.Zero;

            //Transform plane into shape co-ordinates
            Vector2F normalL = Complex.Divide(ref normal, ref xf.q);
            float offsetL = offset - Vector2F.Dot(normal, xf.p);

            float[] depths = new float[SettingEnv.MaxPolygonVertices];
            int diveCount = 0;
            int intoIndex = -1;
            int outoIndex = -1;

            bool lastSubmerged = false;
            int i;
            for (i = 0; i < Vertices.Count; i++)
            {
                depths[i] = Vector2F.Dot(normalL, Vertices[i]) - offsetL;
                bool isSubmerged = depths[i] < -SettingEnv.Epsilon;
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
                        sc = Transform.Multiply(MassData.Centroid, ref xf);
                        return MassData.Mass / GetDensity;
                    }

                    //Completely dry
                    return 0;
                case 1:
                    if (intoIndex == -1)
                    {
                        intoIndex = Vertices.Count - 1;
                    }
                    else
                    {
                        outoIndex = Vertices.Count - 1;
                    }

                    break;
            }

            int intoIndex2 = (intoIndex + 1) % Vertices.Count;
            int outoIndex2 = (outoIndex + 1) % Vertices.Count;

            float intoLambda = (0 - depths[intoIndex]) / (depths[intoIndex2] - depths[intoIndex]);
            float outoLambda = (0 - depths[outoIndex]) / (depths[outoIndex2] - depths[outoIndex]);

            Vector2F intoVec = new Vector2F(Vertices[intoIndex].X * (1 - intoLambda) + Vertices[intoIndex2].X * intoLambda, Vertices[intoIndex].Y * (1 - intoLambda) + Vertices[intoIndex2].Y * intoLambda);
            Vector2F outoVec = new Vector2F(Vertices[outoIndex].X * (1 - outoLambda) + Vertices[outoIndex2].X * outoLambda, Vertices[outoIndex].Y * (1 - outoLambda) + Vertices[outoIndex2].Y * outoLambda);

            //Initialize accumulator
            float area = 0;
            Vector2F center = new Vector2F(0, 0);
            Vector2F p2 = Vertices[intoIndex2];

            const float kInv3 = 1.0f / 3.0f;

            //An awkward loop from intoIndex2+1 to outIndex2
            i = intoIndex2;
            while (i != outoIndex2)
            {
                i = (i + 1) % Vertices.Count;
                Vector2F p3;
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
                    Vector2F e1 = p2 - intoVec;
                    Vector2F e2 = p3 - intoVec;

                    float d = MathUtils.Cross(ref e1, ref e2);

                    float triangleArea = 0.5f * d;

                    area += triangleArea;

                    // Area weighted centroid
                    center += triangleArea * kInv3 * (intoVec + p2 + p3);
                }

                p2 = p3;
            }

            //Normalize and transform centroid
            center *= 1.0f / area;

            sc = Transform.Multiply(ref center, ref xf);

            return area;
        }

        /// <summary>
        ///     Describes whether this instance compare to
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <returns>The bool</returns>
        public bool CompareTo(PolygonShape shape)
        {
            if (Vertices.Count != shape.Vertices.Count)
            {
                return false;
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i] != shape.Vertices[i])
                {
                    return false;
                }
            }

            return (Math.Abs(GetRadius - shape.GetRadius) < SettingEnv.Epsilon) && (MassData == shape.MassData);
        }

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The clone</returns>
        public override Shape Clone()
        {
            PolygonShape clone = new PolygonShape();
            clone.ShapeType = ShapeType;
            clone.Radius = Radius;
            clone.Density = Density;
            clone._vertices = new Vertices(_vertices);
            clone.Normals = new Vertices(Normals);
            clone.MassData = MassData;
            return clone;
        }
    }
}