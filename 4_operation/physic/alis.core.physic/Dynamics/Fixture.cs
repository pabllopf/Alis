// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Fixture.cs
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

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     A fixture is used to attach a shape to a body for collision detection. A fixture
    ///     inherits its transform from its parent. Fixtures hold additional non-geometric data
    ///     such as friction, collision filters, etc.
    ///     Fixtures are created via Body.CreateFixture.
    ///     @warning you cannot reuse fixtures.
    /// </summary>
    public class Fixture
    {
        /// <summary>
        ///     Density, usually in kg/m^2.
        /// </summary>
        public float Density;

        /// <summary>
        ///     Contact filtering data. You must call b2World::Refilter to correct
        ///     existing contacts/non-contacts.
        /// </summary>
        public FilterData Filter;

        /// <summary>
        ///     fixture
        /// </summary>
        public FixtureDef fixtureDef;

        /// <summary>
        ///     Friction coefficient, usually in the range [0,1].
        /// </summary>
        public float Friction;

        /// <summary>
        ///     Restitution (elasticity) usually in the range [0,1].
        /// </summary>
        public float Restitution;

        /// <summary>
        ///     User data that was assigned in the fixture definition. Use this to
        ///     store your application specific data.
        /// </summary>
        public object UserData;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Fixture" /> class
        /// </summary>
        public Fixture() => ProxyId = PairManager.NullProxy;

        /// <summary>
        ///     The proxy id
        /// </summary>
        protected ushort ProxyId { get; set; }

        /// <summary>
        ///     Is this fixture a sensor (non-solid)?
        /// </summary>
        public bool IsSensor { get; protected set; }

        /// <summary>
        ///     Get the child shape. You can modify the child shape, however you should not change the
        ///     number of vertices because this will crash some collision caching mechanisms.
        /// </summary>
        public Shape Shape { get; protected set; }

        /// <summary>
        ///     Get the type of this shape. You can use this to down cast to the concrete shape.
        /// </summary>
        public ShapeType ShapeType { get; protected set; }

        /// <summary>
        ///     Get the next fixture in the parent body's fixture list.
        /// </summary>
        public Fixture Next { get; internal set; }

        /// <summary>
        ///     Get the parent body of this fixture. This is NULL if the fixture is not attached.
        /// </summary>
        public Body Body { get; internal set; }

        /// <summary>
        ///     Creates the broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="body">The body</param>
        /// <param name="xf">The xf</param>
        /// <param name="def">The def</param>
        public void Create(BroadPhase broadPhase, Body body, XForm xf, FixtureDef def)
        {
            fixtureDef = def;
            UserData = def.UserData;
            Friction = def.Friction;
            Restitution = def.Restitution;
            Density = def.Density;

            Body = body;
            Next = null;

            Filter = def.Filter;

            IsSensor = def.IsSensor;

            ShapeType = def.Type;

            // Allocate and initialize the child shape.
            switch (ShapeType)
            {
                case ShapeType.CircleShape:
                {
                    CircleShape circle = new CircleShape();
                    CircleDef circleDef = (CircleDef) def;
                    circle.Position = circleDef.LocalPosition;
                    circle.Radius = circleDef.Radius;
                    Shape = circle;
                }
                    break;

                case ShapeType.PolygonShape:
                {
                    PolygonShape polygon = new PolygonShape();
                    PolygonDef polygonDef = (PolygonDef) def;
                    polygon.Set(polygonDef.Vertices, polygonDef.VertexCount);
                    Shape = polygon;
                }
                    break;

                case ShapeType.EdgeShape:
                {
                    EdgeShape edge = new EdgeShape();
                    EdgeDef edgeDef = (EdgeDef) def;
                    edge.Set(edgeDef.Vertex1, edgeDef.Vertex2);
                    Shape = edge;
                }
                    break;

                default:
                    Box2DxDebug.Assert(false);
                    break;
            }

            // Create proxy in the broad-phase.
            Aabb aabb;
            Shape.ComputeAabb(out aabb, xf);

            bool inRange = broadPhase.InRange(aabb);

            // You are creating a shape outside the world box.
            Box2DxDebug.Assert(inRange);

            if (inRange)
            {
                ProxyId = broadPhase.CreateProxy(aabb, this);
            }
            else
            {
                ProxyId = PairManager.NullProxy;
            }
        }

        /// <summary>
        ///     Destroys the broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        public void Destroy(BroadPhase broadPhase)
        {
            // Remove proxy from the broad-phase.
            if (ProxyId != PairManager.NullProxy)
            {
                broadPhase.DestroyProxy(ProxyId);
                ProxyId = PairManager.NullProxy;
            }

            // Free the child shape.
            Shape.Dispose();
            Shape = null;
        }

        /// <summary>
        ///     Describes whether this instance synchronize
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="transform1">The transform</param>
        /// <param name="transform2">The transform</param>
        /// <returns>The bool</returns>
        internal bool Synchronize(BroadPhase broadPhase, XForm transform1, XForm transform2)
        {
            if (ProxyId == PairManager.NullProxy)
            {
                return false;
            }

            // Compute an AABB that covers the swept shape (may miss some rotation effect).
            Aabb aabb1, aabb2;
            Shape.ComputeAabb(out aabb1, transform1);
            Shape.ComputeAabb(out aabb2, transform2);

            Aabb aabb = new Aabb();
            aabb.Combine(aabb1, aabb2);

            if (broadPhase.InRange(aabb))
            {
                broadPhase.MoveProxy(ProxyId, aabb);
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Refilters the proxy using the specified broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="transform">The transform</param>
        internal void RefilterProxy(BroadPhase broadPhase, XForm transform)
        {
            if (ProxyId == PairManager.NullProxy)
            {
                return;
            }

            broadPhase.DestroyProxy(ProxyId);

            Aabb aabb;
            Shape.ComputeAabb(out aabb, transform);

            bool inRange = broadPhase.InRange(aabb);

            if (inRange)
            {
                ProxyId = broadPhase.CreateProxy(aabb, this);
            }
            else
            {
                ProxyId = PairManager.NullProxy;
            }
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            Box2DxDebug.Assert(ProxyId == PairManager.NullProxy);
            Box2DxDebug.Assert(Shape == null);
        }

        /// <summary>
        ///     Compute the mass properties of this shape using its dimensions and density.
        ///     The inertia tensor is computed about the local origin, not the centroid.
        /// </summary>
        /// <param name="massData">Returns the mass data for this shape.</param>
        public void ComputeMass(out MassData massData)
        {
            Shape.ComputeMass(out massData, Density);
        }

        /// <summary>
        ///     Compute the volume and centroid of this fixture intersected with a half plane.
        /// </summary>
        /// <param name="normal">Normal the surface normal.</param>
        /// <param name="offset">Offset the surface offset along normal.</param>
        /// <param name="c">Returns the centroid.</param>
        /// <returns>The total volume less than offset along normal.</returns>
        public float ComputeSubmergedArea(Vector2 normal, float offset, out Vector2 c) => Shape.ComputeSubmergedArea(normal, offset, Body.GetXForm(), out c);

        /// <summary>
        ///     Test a point for containment in this fixture. This only works for convex shapes.
        /// </summary>
        /// <param name="p">A point in world coordinates.</param>
        public bool TestPoint(Vector2 p) => Shape.TestPoint(Body.GetXForm(), p);

        /// <summary>
        ///     Perform a ray cast against this shape.
        /// </summary>
        /// <param name="lambda">
        ///     Returns the hit fraction. You can use this to compute the contact point
        ///     p = (1 - lambda) * segment.p1 + lambda * segment.p2.
        /// </param>
        /// <param name="normal">
        ///     Returns the normal at the contact point. If there is no intersection, the normal
        ///     is not set.
        /// </param>
        /// <param name="segment">Defines the begin and end point of the ray cast.</param>
        /// <param name="maxLambda">A number typically in the range [0,1].</param>
        public SegmentCollide TestSegment(out float lambda, out Vector2 normal, Segment segment, float maxLambda) => Shape.TestSegment(Body.GetXForm(), out lambda, out normal, segment, maxLambda);

        /// <summary>
        ///     Get the maximum radius about the parent body's center of mass.
        /// </summary>
        public float ComputeSweepRadius(Vector2 pivot) => Shape.ComputeSweepRadius(pivot);
    }
}