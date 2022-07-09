/*
  Box2DX Copyright (c) 2009 Ihar Kalasouski http://code.google.com/p/box2dx
  Box2D original C++ version Copyright (c) 2006-2009 Erin Catto http://www.gphysics.com

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.
*/

using System;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
	/// A fixture is used to attach a shape to a body for collision detection. A fixture
	/// inherits its transform from its parent. Fixtures hold additional non-geometric data
	/// such as friction, collision filters, etc.
	/// Fixtures are created via Body.CreateFixture.
	/// @warning you cannot reuse fixtures.
	/// </summary>
	public class Fixture
	{
		/// <summary>
		/// The type
		/// </summary>
		protected ShapeType _type;
		/// <summary>
		/// The is sensor
		/// </summary>
		protected bool _isSensor;
		/// <summary>
		/// The proxy id
		/// </summary>
		protected UInt16 _proxyId;

		/// <summary>
		/// The body
		/// </summary>
		internal Body _body;
		/// <summary>
		/// The shape
		/// </summary>
		protected Shape _shape;
		/// <summary>
		/// The next
		/// </summary>
		internal Fixture _next;

		/// <summary>
		/// Contact filtering data. You must call b2World::Refilter to correct
		/// existing contacts/non-contacts.
		/// </summary>
		public FilterData Filter;

		/// <summary>
		/// Is this fixture a sensor (non-solid)?
		/// </summary>
		public bool IsSensor { get { return _isSensor; } }

		/// <summary>
		/// Get the child shape. You can modify the child shape, however you should not change the
		/// number of vertices because this will crash some collision caching mechanisms.
		/// </summary>
		public Shape Shape { get { return _shape; } }

		/// <summary>
		/// Get the type of this shape. You can use this to down cast to the concrete shape.
		/// </summary>
		public ShapeType ShapeType { get { return _type; } }

		/// <summary>
		/// Get the next fixture in the parent body's fixture list.
		/// </summary>
		public Fixture Next { get { return _next; } }

		/// <summary>
		/// Get the parent body of this fixture. This is NULL if the fixture is not attached.
		/// </summary>
		public Body Body { get { return _body; } }

		/// <summary>
		/// User data that was assigned in the fixture definition. Use this to
		/// store your application specific data.
		/// </summary>
		public object UserData;

		/// <summary>
		/// Friction coefficient, usually in the range [0,1].
		/// </summary>
		public float Friction;

		/// <summary>
		/// Restitution (elasticity) usually in the range [0,1].
		/// </summary>
		public float Restitution;

		/// <summary>
		/// Density, usually in kg/m^2.
		/// </summary>
		public float Density;

		/// <summary>
		/// Initializes a new instance of the <see cref="Fixture"/> class
		/// </summary>
		public Fixture()
		{
			_proxyId = PairManager.NullProxy;
		}

		/// <summary>
		/// Creates the broad phase
		/// </summary>
		/// <param name="broadPhase">The broad phase</param>
		/// <param name="body">The body</param>
		/// <param name="xf">The xf</param>
		/// <param name="def">The def</param>
		public void Create(BroadPhase broadPhase, Body body, XForm xf, FixtureDef def)
		{
			UserData = def.UserData;
			Friction = def.Friction;
			Restitution = def.Restitution;
			Density = def.Density;

			_body = body;
			_next = null;

			Filter = def.Filter;

			_isSensor = def.IsSensor;

			_type = def.Type;

			// Allocate and initialize the child shape.
			switch (_type)
			{
				case ShapeType.CircleShape:
					{
						CircleShape circle = new CircleShape();
						CircleDef circleDef = (CircleDef)def;
						circle.Position = circleDef.LocalPosition;
						circle.Radius = circleDef.Radius;
						_shape = circle;
					}
					break;

				case ShapeType.PolygonShape:
					{
						PolygonShape polygon = new PolygonShape();
						PolygonDef polygonDef = (PolygonDef)def;
						polygon.Set(polygonDef.Vertices, polygonDef.VertexCount);
						_shape = polygon;
					}
					break;

				case ShapeType.EdgeShape:
					{
						EdgeShape edge = new EdgeShape();
						EdgeDef edgeDef = (EdgeDef)def;
						edge.Set(edgeDef.Vertex1, edgeDef.Vertex2);
						_shape = edge;
					}
					break;

				default:
					Box2DXDebug.Assert(false);
					break;
			}

			// Create proxy in the broad-phase.
			AABB aabb;
			_shape.ComputeAabb(out aabb, xf);

			bool inRange = broadPhase.InRange(aabb);

			// You are creating a shape outside the world box.
			Box2DXDebug.Assert(inRange);

			if (inRange)
			{
				_proxyId = broadPhase.CreateProxy(aabb, this);
			}
			else
			{
				_proxyId = PairManager.NullProxy;
			}
		}

		/// <summary>
		/// Destroys the broad phase
		/// </summary>
		/// <param name="broadPhase">The broad phase</param>
		public void Destroy(BroadPhase broadPhase)
		{
			// Remove proxy from the broad-phase.
			if (_proxyId != PairManager.NullProxy)
			{
				broadPhase.DestroyProxy(_proxyId);
				_proxyId = PairManager.NullProxy;
			}

			// Free the child shape.
			_shape.Dispose();
			_shape = null;
		}

		/// <summary>
		/// Describes whether this instance synchronize
		/// </summary>
		/// <param name="broadPhase">The broad phase</param>
		/// <param name="transform1">The transform</param>
		/// <param name="transform2">The transform</param>
		/// <returns>The bool</returns>
		internal bool Synchronize(BroadPhase broadPhase, XForm transform1, XForm transform2)
		{
			if (_proxyId == PairManager.NullProxy)
			{
				return false;
			}

			// Compute an AABB that covers the swept shape (may miss some rotation effect).
			AABB aabb1, aabb2;
			_shape.ComputeAabb(out aabb1, transform1);
			_shape.ComputeAabb(out aabb2, transform2);

			AABB aabb = new AABB();
			aabb.Combine(aabb1, aabb2);

			if (broadPhase.InRange(aabb))
			{
				broadPhase.MoveProxy(_proxyId, aabb);
				return true;
			}

            return false;
        }

		/// <summary>
		/// Refilters the proxy using the specified broad phase
		/// </summary>
		/// <param name="broadPhase">The broad phase</param>
		/// <param name="transform">The transform</param>
		internal void RefilterProxy(BroadPhase broadPhase, XForm transform)
		{
			if (_proxyId == PairManager.NullProxy)
			{
				return;
			}

			broadPhase.DestroyProxy(_proxyId);

			AABB aabb;
			_shape.ComputeAabb(out aabb, transform);

			bool inRange = broadPhase.InRange(aabb);

			if (inRange)
			{
				_proxyId = broadPhase.CreateProxy(aabb, this);
			}
			else
			{
				_proxyId = PairManager.NullProxy;
			}
		}

		/// <summary>
		/// Disposes this instance
		/// </summary>
		public virtual void Dispose()
		{
			Box2DXDebug.Assert(_proxyId == PairManager.NullProxy);
			Box2DXDebug.Assert(_shape == null);
		}

		/// <summary>
		/// Compute the mass properties of this shape using its dimensions and density.
		/// The inertia tensor is computed about the local origin, not the centroid.
		/// </summary>
		/// <param name="massData">Returns the mass data for this shape.</param>
		public void ComputeMass(out MassData massData)
		{
			_shape.ComputeMass(out massData, Density);
		}

		/// <summary>
		/// Compute the volume and centroid of this fixture intersected with a half plane.
		/// </summary>
		/// <param name="normal">Normal the surface normal.</param>
		/// <param name="offset">Offset the surface offset along normal.</param>
		/// <param name="c">Returns the centroid.</param>
		/// <returns>The total volume less than offset along normal.</returns>
		public float ComputeSubmergedArea(Vec2 normal, float offset, out Vec2 c)
		{
			return _shape.ComputeSubmergedArea(normal, offset, _body.GetXForm(), out c);
		}

		/// <summary>
		/// Test a point for containment in this fixture. This only works for convex shapes.
		/// </summary>
		/// <param name="p">A point in world coordinates.</param>
		public bool TestPoint(Vec2 p)
		{
			return _shape.TestPoint(_body.GetXForm(), p);
		}

		/// <summary>
		/// Perform a ray cast against this shape.
		/// </summary>
		/// <param name="lambda">Returns the hit fraction. You can use this to compute the contact point
		/// p = (1 - lambda) * segment.p1 + lambda * segment.p2.</param>
		/// <param name="normal">Returns the normal at the contact point. If there is no intersection, the normal
		/// is not set.</param>
		/// <param name="segment">Defines the begin and end point of the ray cast.</param>
		/// <param name="maxLambda">A number typically in the range [0,1].</param>
		public SegmentCollide TestSegment(out float lambda, out Vec2 normal, Segment segment, float maxLambda)
		{
			return _shape.TestSegment(_body.GetXForm(), out lambda, out normal, segment, maxLambda);
		}

		/// <summary>
		/// Get the maximum radius about the parent body's center of mass.
		/// </summary>
		public float ComputeSweepRadius(Vec2 pivot)
		{
			return _shape.ComputeSweepRadius(pivot);
		}
	}
}
