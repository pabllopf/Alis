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

using Box2D.NetStandard.Collision;
using Box2D.NetStandard.Collision.Shapes;
using Box2D.NetStandard.Common;

namespace Box2D.NetStandard.Dynamics.Contacts
{
	/// <summary>
	/// The null contact class
	/// </summary>
	/// <seealso cref="Contact"/>
	public class NullContact : Contact
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NullContact"/> class
		/// </summary>
		public NullContact()
		{
			CollideShapeFunction = Collide;
		}
		/// <summary>
		/// Collides the manifold
		/// </summary>
		/// <param name="manifold">The manifold</param>
		/// <param name="shape1">The shape</param>
		/// <param name="xf1">The xf</param>
		/// <param name="shape2">The shape</param>
		/// <param name="xf2">The xf</param>
		private static void Collide(ref Manifold manifold, Shape shape1, XForm xf1, Shape shape2, XForm xf2) { }
	}
}