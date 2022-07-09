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

using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
	/// <summary>
	/// The edge and circle contact class
	/// </summary>
	/// <seealso cref="Contact"/>
	public class EdgeAndCircleContact : Contact
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EdgeAndCircleContact"/> class
		/// </summary>
		/// <param name="fixtureA">The fixture</param>
		/// <param name="fixtureB">The fixture</param>
		public EdgeAndCircleContact(Fixture fixtureA, Fixture fixtureB)
			: base(fixtureA, fixtureB)
		{
			Box2DXDebug.Assert(fixtureA.ShapeType == ShapeType.EdgeShape);
			Box2DXDebug.Assert(fixtureB.ShapeType == ShapeType.CircleShape);
			_manifold.PointCount = 0;
			_manifold.Points[0].NormalImpulse = 0.0f;
			_manifold.Points[0].TangentImpulse = 0.0f;
			CollideShapeFunction = CollideEdgeAndCircle;
		}

		/// <summary>
		/// Collides the edge and circle using the specified manifold
		/// </summary>
		/// <param name="manifold">The manifold</param>
		/// <param name="shape1">The shape</param>
		/// <param name="xf1">The xf</param>
		/// <param name="shape2">The shape</param>
		/// <param name="xf2">The xf</param>
		private static void CollideEdgeAndCircle(ref Manifold manifold, Shape shape1, XForm xf1, Shape shape2, XForm xf2)
		{
			Collision.Collision.CollideEdgeAndCircle(ref manifold, (EdgeShape)shape1, xf1, (CircleShape)shape2, xf2);
		}

		/// <summary>
		/// Creates the fixture a
		/// </summary>
		/// <param name="fixtureA">The fixture</param>
		/// <param name="fixtureB">The fixture</param>
		/// <returns>The contact</returns>
		new public static Contact Create(Fixture fixtureA, Fixture fixtureB)
		{
			return new EdgeAndCircleContact(fixtureA, fixtureB);
		}

		/// <summary>
		/// Destroys the contact
		/// </summary>
		/// <param name="contact">The contact</param>
		new public static void Destroy(ref Contact contact)
		{
			contact = null;
		}
	}
}