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
using Box2D.NetStandard.Dynamics.Contacts;

namespace Box2D.NetStandard.Dynamics
{

	/// <summary>
	/// The contact manager class
	/// </summary>
	/// <seealso cref="PairCallback"/>
	public class ContactManager : PairCallback
	{
		/// <summary>
		/// The world
		/// </summary>
		public World _world;

		// This lets us provide broadphase proxy pair user data for
		// contacts that shouldn't exist.
		/// <summary>
		/// The null contact
		/// </summary>
		public NullContact _nullContact;

		/// <summary>
		/// The destroy immediate
		/// </summary>
		public bool _destroyImmediate;

		/// <summary>
		/// Initializes a new instance of the <see cref="ContactManager"/> class
		/// </summary>
		public ContactManager() { }

		// This is a callback from the broadphase when two AABB proxies begin
		// to overlap. We create a Contact to manage the narrow phase.
		/// <summary>
		/// Pairs the added using the specified proxy user data a
		/// </summary>
		/// <param name="proxyUserDataA">The proxy user data</param>
		/// <param name="proxyUserDataB">The proxy user data</param>
		/// <returns>The </returns>
		public override object PairAdded(object proxyUserDataA, object proxyUserDataB)
		{
			Fixture fixtureA = proxyUserDataA as Fixture;
			Fixture fixtureB = proxyUserDataB as Fixture;

			Body bodyA = fixtureA.Body;
			Body bodyB = fixtureB.Body;

			if (bodyA.IsStatic() && bodyB.IsStatic())
			{
				return _nullContact;
			}

			if (fixtureA.Body == fixtureB.Body)
			{
				return _nullContact;
			}

			if (bodyB.IsConnected(bodyA))
			{
				return _nullContact;
			}

			if (_world._contactFilter != null && _world._contactFilter.ShouldCollide(fixtureA, fixtureB) == false)
			{
				return _nullContact;
			}

			// Call the factory.
			Contact c = Contact.Create(fixtureA, fixtureB);

			if (c == null)
			{
				return _nullContact;
			}

			// Contact creation may swap shapes.
			fixtureA = c.FixtureA;
			fixtureB = c.FixtureB;
			bodyA = fixtureA.Body;
			bodyB = fixtureB.Body;

			// Insert into the world.
			c._prev = null;
			c._next = _world._contactList;
			if (_world._contactList != null)
			{
				_world._contactList._prev = c;
			}
			_world._contactList = c;

			// Connect to island graph.

			// Connect to body 1
			c._nodeA.Contact = c;
			c._nodeA.Other = bodyB;

			c._nodeA.Prev = null;
			c._nodeA.Next = bodyA._contactList;
			if (bodyA._contactList != null)
			{
				bodyA._contactList.Prev = c._nodeA;
			}
			bodyA._contactList = c._nodeA;

			// Connect to body 2
			c._nodeB.Contact = c;
			c._nodeB.Other = bodyA;

			c._nodeB.Prev = null;
			c._nodeB.Next = bodyB._contactList;
			if (bodyB._contactList != null)
			{
				bodyB._contactList.Prev = c._nodeB;
			}
			bodyB._contactList = c._nodeB;

			++_world._contactCount;
			return c;
		}

		// This is a callback from the broadphase when two AABB proxies cease
		// to overlap. We retire the Contact.
		/// <summary>
		/// Pairs the removed using the specified proxy user data 1
		/// </summary>
		/// <param name="proxyUserData1">The proxy user data</param>
		/// <param name="proxyUserData2">The proxy user data</param>
		/// <param name="pairUserData">The pair user data</param>
		public override void PairRemoved(object proxyUserData1, object proxyUserData2, object pairUserData)
		{
			//B2_NOT_USED(proxyUserData1);
			//B2_NOT_USED(proxyUserData2);

			if (pairUserData == null)
			{
				return;
			}

			Contact c = pairUserData as Contact;
			if (c == _nullContact)
			{
				return;
			}

			// An attached body is being destroyed, we must destroy this contact
			// immediately to avoid orphaned shape pointers.
			Destroy(c);
		}

		/// <summary>
		/// Destroys the c
		/// </summary>
		/// <param name="c">The </param>
		public void Destroy(Contact c)
		{
			Fixture fixtureA = c.FixtureA;
			Fixture fixtureB = c.FixtureB;
			Body bodyA = fixtureA.Body;
			Body bodyB = fixtureB.Body;

			if (c.Manifold.PointCount > 0)
			{
				if(_world._contactListener!=null)
					_world._contactListener.EndContact(c);
			}

			// Remove from the world.
			if (c._prev != null)
			{
				c._prev._next = c._next;
			}

			if (c._next != null)
			{
				c._next._prev = c._prev;
			}

			if (c == _world._contactList)
			{
				_world._contactList = c._next;
			}

			// Remove from body 1
			if (c._nodeA.Prev != null)
			{
				c._nodeA.Prev.Next = c._nodeA.Next;
			}

			if (c._nodeA.Next != null)
			{
				c._nodeA.Next.Prev = c._nodeA.Prev;
			}

			if (c._nodeA == bodyA._contactList)
			{
				bodyA._contactList = c._nodeA.Next;
			}

			// Remove from body 2
			if (c._nodeB.Prev != null)
			{
				c._nodeB.Prev.Next = c._nodeB.Next;
			}

			if (c._nodeB.Next != null)
			{
				c._nodeB.Next.Prev = c._nodeB.Prev;
			}

			if (c._nodeB == bodyB._contactList)
			{
				bodyB._contactList = c._nodeB.Next;
			}

			// Call the factory.
			Contact.Destroy(ref c);
			--_world._contactCount;
		}

		// This is the top level collision call for the time step. Here
		// all the narrow phase collision is processed for the world
		// contact list.
		/// <summary>
		/// Collides this instance
		/// </summary>
		public void Collide()
		{
			// Update awake contacts.
			for (Contact c = _world._contactList; c != null; c = c.GetNext())
			{
				Body bodyA = c._fixtureA.Body;
				Body bodyB = c._fixtureB.Body;
				if (bodyA.IsSleeping() && bodyB.IsSleeping())
				{
					continue;
				}

				c.Update(_world._contactListener);
			}
		}
	}
}
