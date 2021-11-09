// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BuoyancyController.cs
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
using System.Collections.Generic;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Collision.Shapes;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Extensions.Controllers.ControllerBase;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Extensions.Controllers.Buoyancy
{
    /// <summary>
    ///     The buoyancy controller class
    /// </summary>
    /// <seealso cref="Controller" />
    public sealed class BuoyancyController : Controller
    {
        /// <summary>
        ///     The gravity
        /// </summary>
        private readonly Vector2 _gravity;

        /// <summary>
        ///     The body
        /// </summary>
        private readonly HashSet<Body> _uniqueBodies = new HashSet<Body>();

        /// <summary>
        ///     The container
        /// </summary>
        private AABB _container;

        /// <summary>
        ///     The normal
        /// </summary>
        private Vector2 _normal;

        /// <summary>
        ///     The offset
        /// </summary>
        private float _offset;

        /// <summary>
        ///     Controls the rotational drag that the fluid exerts on the bodies within it. Use higher values will simulate
        ///     thick fluid, like honey, lower values to simulate water-like fluids.
        /// </summary>
        public float AngularDragCoefficient;

        /// <summary>Density of the fluid. Higher values will make things more buoyant, lower values will cause things to sink.</summary>
        public float Density;

        /// <summary>
        ///     Controls the linear drag that the fluid exerts on the bodies within it.  Use higher values will simulate thick
        ///     fluid, like honey, lower values to simulate water-like fluids.
        /// </summary>
        public float LinearDragCoefficient;

        /// <summary>Acts like waterflow. Defaults to 0,0.</summary>
        public Vector2 Velocity;

        /// <summary>Initializes a new instance of the <see cref="BuoyancyController" /> class.</summary>
        /// <param name="container">Only bodies inside this AABB will be influenced by the controller</param>
        /// <param name="density">Density of the fluid</param>
        /// <param name="linearDragCoefficient">Linear drag coefficient of the fluid</param>
        /// <param name="rotationalDragCoefficient">Rotational drag coefficient of the fluid</param>
        /// <param name="gravity">The direction gravity acts. Buoyancy force will act in opposite direction of gravity.</param>
        public BuoyancyController(AABB container, float density, float linearDragCoefficient,
            float rotationalDragCoefficient, Vector2 gravity)
            : base(ControllerType.BuoyancyController)
        {
            Container = container;
            _normal = new Vector2(0, 1);
            Density = density;
            LinearDragCoefficient = linearDragCoefficient;
            AngularDragCoefficient = rotationalDragCoefficient;
            _gravity = gravity;
        }

        /// <summary>
        ///     Gets or sets the value of the container
        /// </summary>
        public AABB Container
        {
            get => _container;
            set
            {
                _container = value;
                _offset = _container.UpperBound.Y;
            }
        }

        /// <summary>
        ///     Updates the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        public override void Update(float dt)
        {
            _uniqueBodies.Clear();
            World.QueryAABB(fixture =>
            {
                if (fixture.Body.IsStatic || !fixture.Body.Awake)
                {
                    return true;
                }

                if (!_uniqueBodies.Contains(fixture.Body))
                {
                    _uniqueBodies.Add(fixture.Body);
                }

                return true;
            }, ref _container);

            foreach (Body body in _uniqueBodies)
            {
                Vector2 areac = Vector2.Zero;
                Vector2 massc = Vector2.Zero;
                float area = 0;
                float mass = 0;

                for (int j = 0; j < body.FixtureList.Count; j++)
                {
                    Fixture fixture = body.FixtureList[j];

                    if (fixture.Shape.ShapeType != ShapeType.Polygon && fixture.Shape.ShapeType != ShapeType.Circle)
                    {
                        continue;
                    }

                    Shape shape = fixture.Shape;

                    float sarea = ComputeSubmergedArea(shape, ref _normal, _offset, ref body._xf, out Vector2 sc);
                    area += sarea;
                    areac.X += sarea * sc.X;
                    areac.Y += sarea * sc.Y;

                    mass += sarea * shape._densityPrivate;
                    massc.X += sarea * sc.X * shape._densityPrivate;
                    massc.Y += sarea * sc.Y * shape._densityPrivate;
                }

                areac.X /= area;
                areac.Y /= area;
                massc.X /= mass;
                massc.Y /= mass;

                if (area < MathConstants.Epsilon)
                {
                    continue;
                }

                //Buoyancy
                Vector2 buoyancyForce = -Density * area * _gravity;
                body.ApplyForce(buoyancyForce, massc);

                //Linear drag
                Vector2 dragForce = body.GetLinearVelocityFromWorldPoint(areac) - Velocity;
                dragForce *= -LinearDragCoefficient * area;
                body.ApplyForce(dragForce, areac);

                //Angular drag
                body.ApplyTorque(-body.Inertia / body.Mass * area * body.AngularVelocity * AngularDragCoefficient);
            }
        }

        /// <summary>
        ///     Computes the submerged area using the specified shape
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <param name="normal">The normal</param>
        /// <param name="offset">The offset</param>
        /// <param name="xf">The xf</param>
        /// <param name="sc">The sc</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <returns>The float</returns>
        private float ComputeSubmergedArea(Shape shape, ref Vector2 normal, float offset, ref Transform xf,
            out Vector2 sc)
        {
            switch (shape.ShapeType)
            {
                case ShapeType.Circle:
                {
                    CircleShape circleShape = (CircleShape) shape;

                    sc = Vector2.Zero;

                    float radius2 = circleShape._radiusPrivate * circleShape._radiusPrivate;

                    Vector2 p = MathUtils.Mul(ref xf, circleShape.Position);
                    float l = -(Vector2.Dot(normal, p) - offset);
                    if (l < -circleShape._radiusPrivate + MathConstants.Epsilon)

                        //Completely dry
                    {
                        return 0;
                    }

                    if (l > circleShape._radiusPrivate)
                    {
                        //Completely wet
                        sc = p;
                        return MathConstants.Pi * radius2;
                    }

                    //Magic
                    float l2 = l * l;
                    float area = radius2 * (float) (Math.Asin(l / circleShape._radiusPrivate) + MathConstants.Pi / 2 +
                                                    l * Math.Sqrt(radius2 - l2));
                    float com = -2.0f / 3.0f * (float) Math.Pow(radius2 - l2, 1.5f) / area;

                    sc.X = p.X + normal.X * com;
                    sc.Y = p.Y + normal.Y * com;

                    return area;
                }
                case ShapeType.Edge:
                    sc = Vector2.Zero;
                    return 0;
                case ShapeType.Polygon:
                {
                    sc = Vector2.Zero;

                    PolygonShape polygonShape = (PolygonShape) shape;

                    //Transform plane into shape co-ordinates
                    Vector2 normalL = MathUtils.MulT(xf.q, normal);
                    float offsetL = offset - Vector2.Dot(normal, xf.p);

                    float[] depths = new float[Settings.MaxPolygonVertices];
                    int diveCount = 0;
                    int intoIndex = -1;
                    int outoIndex = -1;

                    bool lastSubmerged = false;
                    int i;
                    for (i = 0; i < polygonShape._verticesPrivate.Count; i++)
                    {
                        depths[i] = Vector2.Dot(normalL, polygonShape._verticesPrivate[i]) - offsetL;
                        bool isSubmerged = depths[i] < -MathConstants.Epsilon;
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
                                sc = MathUtils.Mul(ref xf, polygonShape._massDataPrivate.Centroid);
                                return polygonShape._massDataPrivate.Mass / Density;
                            }

                            //Completely dry
                            return 0;
                        case 1:
                            if (intoIndex == -1)
                            {
                                intoIndex = polygonShape._verticesPrivate.Count - 1;
                            }
                            else
                            {
                                outoIndex = polygonShape._verticesPrivate.Count - 1;
                            }

                            break;
                    }

                    int intoIndex2 = (intoIndex + 1) % polygonShape._verticesPrivate.Count;
                    int outoIndex2 = (outoIndex + 1) % polygonShape._verticesPrivate.Count;

                    float intoLambda = (0 - depths[intoIndex]) / (depths[intoIndex2] - depths[intoIndex]);
                    float outoLambda = (0 - depths[outoIndex]) / (depths[outoIndex2] - depths[outoIndex]);

                    Vector2 intoVec = new Vector2(
                        polygonShape._verticesPrivate[intoIndex].X * (1 - intoLambda) +
                        polygonShape._verticesPrivate[intoIndex2].X * intoLambda,
                        polygonShape._verticesPrivate[intoIndex].Y * (1 - intoLambda) +
                        polygonShape._verticesPrivate[intoIndex2].Y * intoLambda);
                    Vector2 outoVec = new Vector2(
                        polygonShape._verticesPrivate[outoIndex].X * (1 - outoLambda) +
                        polygonShape._verticesPrivate[outoIndex2].X * outoLambda,
                        polygonShape._verticesPrivate[outoIndex].Y * (1 - outoLambda) +
                        polygonShape._verticesPrivate[outoIndex2].Y * outoLambda);

                    //Initialize accumulator
                    float area = 0;
                    Vector2 center = new Vector2(0, 0);
                    Vector2 p2 = polygonShape._verticesPrivate[intoIndex2];

                    const float k_inv3 = 1.0f / 3.0f;

                    //An awkward loop from intoIndex2+1 to outIndex2
                    i = intoIndex2;
                    while (i != outoIndex2)
                    {
                        i = (i + 1) % polygonShape._verticesPrivate.Count;
                        Vector2 p3;
                        if (i == outoIndex2)
                        {
                            p3 = outoVec;
                        }
                        else
                        {
                            p3 = polygonShape._verticesPrivate[i];
                        }

                        //Add the triangle formed by intoVec,p2,p3
                        {
                            Vector2 e1 = p2 - intoVec;
                            Vector2 e2 = p3 - intoVec;

                            float D = MathUtils.Cross(e1, e2);

                            float triangleArea = 0.5f * D;

                            area += triangleArea;

                            // Area weighted centroid
                            center += triangleArea * k_inv3 * (intoVec + p2 + p3);
                        }

                        p2 = p3;
                    }

                    //Normalize and transform centroid
                    center *= 1.0f / area;

                    sc = MathUtils.Mul(ref xf, center);

                    return area;
                }
                case ShapeType.Chain:
                    sc = Vector2.Zero;
                    return 0;
                case ShapeType.Unknown:
                case ShapeType.TypeCount:
                    throw new NotSupportedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}