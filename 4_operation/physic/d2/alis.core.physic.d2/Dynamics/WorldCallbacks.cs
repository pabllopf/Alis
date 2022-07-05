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
using Box2D.NetStandard.Collision;
using Box2D.NetStandard.Common;
using Box2D.NetStandard.Dynamics.Contacts;
using Box2D.NetStandard.Dynamics.Joints;

namespace Box2D.NetStandard.Dynamics
{
	/// <summary>
	/// Joints and shapes are destroyed when their associated
	/// body is destroyed. Implement this listener so that you
	/// may nullify references to these joints and shapes.
	/// </summary>
	public abstract class DestructionListener
	{
		/// <summary>
		/// Called when any joint is about to be destroyed due
		/// to the destruction of one of its attached bodies.
		/// </summary>
		public abstract void SayGoodbye(Joint joint);

		/// <summary>
		/// Called when any shape is about to be destroyed due
		/// to the destruction of its parent body.
		/// </summary>
		public abstract void SayGoodbye(Fixture fixture);
	}

	/// <summary>
	/// This is called when a body's shape passes outside of the world boundary.
	/// </summary>
	public abstract class BoundaryListener
	{
		/// <summary>
		/// This is called for each body that leaves the world boundary.
		/// @warning you can't modify the world inside this callback.
		/// </summary>
		public abstract void Violation(Body body);
	}

	/// <summary>
	/// Implement this class to provide collision filtering. In other words, you can implement
	/// this class if you want finer control over contact creation.
	/// </summary>
	public class ContactFilter
	{
		/// <summary>
		/// Return true if contact calculations should be performed between these two shapes.
		/// If you implement your own collision filter you may want to build from this implementation.
		/// @warning for performance reasons this is only called when the AABBs begin to overlap.
		/// </summary>
		public virtual bool ShouldCollide(Fixture fixtureA, Fixture fixtureB)
		{
			FilterData filterA = fixtureA.Filter;
			FilterData filterB = fixtureB.Filter;

			if (filterA.GroupIndex == filterB.GroupIndex && filterA.GroupIndex != 0)
			{
				return filterA.GroupIndex > 0;
			}

			bool collide = (filterA.MaskBits & filterB.CategoryBits) != 0 && (filterA.CategoryBits & filterB.MaskBits) != 0;
			return collide;
		}

		/// <summary>
		/// Return true if the given shape should be considered for ray intersection.
		/// </summary>
		public bool RayCollide(object userData, Fixture fixture)
		{
			//By default, cast userData as a shape, and then collide if the shapes would collide
			if (userData == null)
			{
				return true;
			}

			return ShouldCollide((Fixture)userData, fixture);
		}
	}

	/// Contact impulses for reporting. Impulses are used instead of forces because
	/// sub-step forces may approach infinity for rigid body collisions. These
	/// match up one-to-one with the contact points in b2Manifold.
	public class ContactImpulse
	{
		/// <summary>
		/// The max manifold points
		/// </summary>
		public float[] normalImpulses = new float[Settings.MaxManifoldPoints];
		/// <summary>
		/// The max manifold points
		/// </summary>
		public float[] tangentImpulses = new float[Settings.MaxManifoldPoints];
	}

	/// Implement this class to get contact information. You can use these results for
	/// things like sounds and game logic. You can also get contact results by
	/// traversing the contact lists after the time step. However, you might miss
	/// some contacts because continuous physics leads to sub-stepping.
	/// Additionally you may receive multiple callbacks for the same contact in a
	/// single time step.
	/// You should strive to make your callbacks efficient because there may be
	/// many callbacks per time step.
	/// @warning You cannot create/destroy Box2DX entities inside these callbacks.
	public interface ContactListener
	{
		/// Called when two fixtures begin to touch.
		void BeginContact(Contact contact);

		/// Called when two fixtures cease to touch.
		void EndContact(Contact contact);

		/// This is called after a contact is updated. This allows you to inspect a
		/// contact before it goes to the solver. If you are careful, you can modify the
		/// contact manifold (e.g. disable contact).
		/// A copy of the old manifold is provided so that you can detect changes.
		/// Note: this is called only for awake bodies.
		/// Note: this is called even when the number of contact points is zero.
		/// Note: this is not called for sensors.
		/// Note: if you set the number of contact points to zero, you will not
		/// get an EndContact callback. However, you may get a BeginContact callback
		/// the next step.
		void PreSolve(Contact contact, Manifold oldManifold);

		/// This lets you inspect a contact after the solver is finished. This is useful
		/// for inspecting impulses.
		/// Note: the contact manifold does not include time of impact impulses, which can be
		/// arbitrarily large if the sub-step is small. Hence the impulse is provided explicitly
		/// in a separate data structure.
		/// Note: this is only called for contacts that are touching, solid, and awake.
		void PostSolve(Contact contact, ContactImpulse impulse);
	}

	/// <summary>
	/// Color for debug drawing. Each value has the range [0,1].
	/// </summary>
	public struct Color
	{
		/// <summary>
		/// The 
		/// </summary>
		public float R, G, B;

		/// <summary>
		/// Initializes a new instance of the <see cref="Color"/> class
		/// </summary>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		public Color(float r, float g, float b)
		{
			R = r; G = g; B = b;
		}
		/// <summary>
		/// Sets the r
		/// </summary>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		public void Set(float r, float g, float b)
		{
			R = r; G = g; B = b;
		}
	}

	/// <summary>
	/// Implement and register this class with a b2World to provide debug drawing of physics
	/// entities in your game.
	/// </summary>
	public abstract class DebugDraw
	{
		/// <summary>
		/// The draw flags enum
		/// </summary>
		[Flags]
		public enum DrawFlags
		{
			/// <summary>
			/// The shape draw flags
			/// </summary>
			Shape = 0x0001, // draw shapes
			/// <summary>
			/// The joint draw flags
			/// </summary>
			Joint = 0x0002, // draw joint connections
			/// <summary>
			/// The core shape draw flags
			/// </summary>
			CoreShape = 0x0004, // draw core (TOI) shapes       // should be removed in this revision?
			/// <summary>
			/// The aabb draw flags
			/// </summary>
			Aabb = 0x0008, // draw axis aligned bounding boxes
			/// <summary>
			/// The obb draw flags
			/// </summary>
			Obb = 0x0010, // draw oriented bounding boxes       // should be removed in this revision?
			/// <summary>
			/// The pair draw flags
			/// </summary>
			Pair = 0x0020, // draw broad-phase pairs
			/// <summary>
			/// The center of mass draw flags
			/// </summary>
			CenterOfMass = 0x0040, // draw center of mass frame
			/// <summary>
			/// The controller draw flags
			/// </summary>
			Controller = 0x0080 // draw center of mass frame
		};

		/// <summary>
		/// The draw flags
		/// </summary>
		protected DrawFlags _drawFlags;

		/// <summary>
		/// Initializes a new instance of the <see cref="DebugDraw"/> class
		/// </summary>
		public DebugDraw()
		{
			_drawFlags = 0;
		}

		/// <summary>
		/// Gets or sets the value of the flags
		/// </summary>
		public DrawFlags Flags { get { return _drawFlags; } set { _drawFlags = value; } }

		/// <summary>
		/// Append flags to the current flags.
		/// </summary>
		public void AppendFlags(DrawFlags flags)
		{
			_drawFlags |= flags;
		}

		/// <summary>
		/// Clear flags from the current flags.
		/// </summary>
		public void ClearFlags(DrawFlags flags)
		{
			_drawFlags &= ~flags;
		}

		/// <summary>
		/// Draw a closed polygon provided in CCW order.
		/// </summary>
		public abstract void DrawPolygon(Vec2[] vertices, int vertexCount, Color color);

		/// <summary>
		/// Draw a solid closed polygon provided in CCW order.
		/// </summary>
		public abstract void DrawSolidPolygon(Vec2[] vertices, int vertexCount, Color color);

		/// <summary>
		/// Draw a circle.
		/// </summary>
		public abstract void DrawCircle(Vec2 center, float radius, Color color);

		/// <summary>
		/// Draw a solid circle.
		/// </summary>
		public abstract void DrawSolidCircle(Vec2 center, float radius, Vec2 axis, Color color);

		/// <summary>
		/// Draw a line segment.
		/// </summary>
		public abstract void DrawSegment(Vec2 p1, Vec2 p2, Color color);

		/// <summary>
		/// Draw a transform. Choose your own length scale.
		/// </summary>
		/// <param name="xf">A transform.</param>
		public abstract void DrawXForm(XForm xf);
	}
}
