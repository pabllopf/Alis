

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.ConvexHull;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions.Shapes
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

                if (SettingEnv.UseConvexHullPolygons)
                {
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

                for (int i = 0; i < _vertices.Count; ++i)
                {
                    int next = i + 1 < _vertices.Count ? i + 1 : 0;
                    Vector2F edge = _vertices[next] - _vertices[i];
                    Vector2F temp = new Vector2F(edge.Y, -edge.X);
                    temp.Normalize();
                    Normals.Add(temp);
                }

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
            // The rest of the derivation is handled by computer algebra.

            if (Density <= 0)
            {
                return;
            }

            Vector2F center = Vector2F.Zero;
            float area = 0.0f;
            float inv3 = 0.0f;

            Vector2F s = Vector2F.Zero;

            for (int i = 0; i < Vertices.Count; ++i)
            {
                s += Vertices[i];
            }

            s *= 1.0f / Vertices.Count;

            const float kInv3 = 1.0f / 3.0f;

            for (int i = 0; i < Vertices.Count; ++i)
            {
                Vector2F e1 = Vertices[i] - s;
                Vector2F e2 = i + 1 < Vertices.Count ? Vertices[i + 1] - s : Vertices[0] - s;

                float d = MathUtils.Cross(ref e1, ref e2);

                float triangleArea = 0.5f * d;
                area += triangleArea;

                center += triangleArea * kInv3 * (e1 + e2);

                float ex1 = e1.X, ey1 = e1.Y;
                float ex2 = e2.X, ey2 = e2.Y;

                float intx2 = ex1 * ex1 + ex2 * ex1 + ex2 * ex2;
                float inty2 = ey1 * ey1 + ey2 * ey1 + ey2 * ey2;

                inv3 += 0.25f * kInv3 * d * (intx2 + inty2);
            }

            MassData.Area = area;

            MassData.Mass = Density * area;

            center *= 1.0f / area;
            MassData.Centroid = center + s;

            MassData.Inertia = Density * inv3;

            MassData.Inertia += MassData.Mass * (Vector2F.Dot(MassData.Centroid, MassData.Centroid) - Vector2F.Dot(center, center));
        }

        /// <summary>
        ///     Describes whether this instance test point
        /// </summary>
        /// <param name="controllerTransform">The transform</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public override bool TestPoint(ref ControllerTransform controllerTransform, ref Vector2F point)
        {
            Vector2F pLocal = Complex.Divide(point - controllerTransform.Position, ref controllerTransform.Rotation);

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
        /// <param name="controllerTransform">The transform</param>
        /// <param name="childIndex">The child index</param>
        /// <returns>The bool</returns>
        public override bool RayCast(out RayCastOutput output, ref RayCastInput input, ref ControllerTransform controllerTransform, int childIndex)
        {
            output = new RayCastOutput();

            Vector2F p1 = Complex.Divide(input.Point1 - controllerTransform.Position, ref controllerTransform.Rotation);
            Vector2F p2 = Complex.Divide(input.Point2 - controllerTransform.Position, ref controllerTransform.Rotation);
            Vector2F d = p2 - p1;

            float lower = 0.0f, upper = input.MaxFraction;
            int index = -1;

            for (int i = 0; i < Vertices.Count; ++i)
            {
                if (!ProcessHalfSpace(ref p1, ref d, i, ref lower, ref upper, ref index))
                {
                    return false;
                }

                if (upper < lower)
                {
                    return false;
                }
            }

            if (index >= 0)
            {
                output.Fraction = lower;
                output.Normal = Complex.Multiply(Normals[index], ref controllerTransform.Rotation);
                return true;
            }

            return false;
        }

        private bool ProcessHalfSpace(ref Vector2F p1, ref Vector2F d, int i, ref float lower, ref float upper, ref int index)
        {
            float numerator = Vector2F.Dot(Normals[i], Vertices[i] - p1);
            float denominator = Vector2F.Dot(Normals[i], d);

            if (Math.Abs(denominator) < SettingEnv.Epsilon)
            {
                return numerator >= 0.0f;
            }

            if ((denominator < 0.0f) && (numerator < lower * denominator))
            {
                lower = numerator / denominator;
                index = i;
            }
            else if ((denominator > 0.0f) && (numerator < upper * denominator))
            {
                upper = numerator / denominator;
            }

            return true;
        }

        /// <summary>
        ///     Given a transform, compute the associated axis aligned bounding box for a child shape.
        /// </summary>
        /// <param name="aabb">The aabb results.</param>
        /// <param name="controllerTransform">The world transform of the shape.</param>
        /// <param name="childIndex">The child shape index.</param>
        public override void ComputeAabb(out Aabb aabb, ref ControllerTransform controllerTransform, int childIndex)
        {
            aabb = new Aabb();

            Vector2F vert = Vertices[0];
            aabb.LowerBound.X = vert.X * controllerTransform.Rotation.R - vert.Y * controllerTransform.Rotation.I + controllerTransform.Position.X;
            aabb.LowerBound.Y = vert.Y * controllerTransform.Rotation.R + vert.X * controllerTransform.Rotation.I + controllerTransform.Position.Y;
            aabb.UpperBound = aabb.LowerBound;

            for (int i = 1; i < Vertices.Count; ++i)
            {
                vert = Vertices[i];
                float vX = vert.X * controllerTransform.Rotation.R - vert.Y * controllerTransform.Rotation.I + controllerTransform.Position.X;
                float vY = vert.Y * controllerTransform.Rotation.R + vert.X * controllerTransform.Rotation.I + controllerTransform.Position.Y;

                if (vX < aabb.LowerBound.X)
                {
                    aabb.LowerBound.X = vX;
                }
                else if (vX > aabb.UpperBound.X)
                {
                    aabb.UpperBound.X = vX;
                }

                if (vY < aabb.LowerBound.Y)
                {
                    aabb.LowerBound.Y = vY;
                }
                else if (vY > aabb.UpperBound.Y)
                {
                    aabb.UpperBound.Y = vY;
                }
            }

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
        public override float ComputeSubmergedArea(ref Vector2F normal, float offset, ref ControllerTransform xf, out Vector2F sc)
        {
            sc = Vector2F.Zero;

            Vector2F normalL = Complex.Divide(ref normal, ref xf.Rotation);
            float offsetL = offset - Vector2F.Dot(normal, xf.Position);

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
                        sc = ControllerTransform.Multiply(MassData.Centroid, ref xf);
                        return MassData.Mass / GetDensity;
                    }

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

            float area = 0;
            Vector2F center = new Vector2F(0, 0);
            Vector2F p2 = Vertices[intoIndex2];

            const float kInv3 = 1.0f / 3.0f;

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

                {
                    Vector2F e1 = p2 - intoVec;
                    Vector2F e2 = p3 - intoVec;

                    float d = MathUtils.Cross(ref e1, ref e2);

                    float triangleArea = 0.5f * d;

                    area += triangleArea;

                    center += triangleArea * kInv3 * (intoVec + p2 + p3);
                }

                p2 = p3;
            }

            center *= 1.0f / area;

            sc = ControllerTransform.Multiply(ref center, ref xf);

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