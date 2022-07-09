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
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
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
		public World World;

		// This lets us provide broadphase proxy pair user data for
		// contacts that shouldn't exist.
		/// <summary>
		/// The null contact
		/// </summary>
		public NullContact NullContact;

		/// <summary>
		/// The destroy immediate
		/// </summary>
		public bool DestroyImmediate;

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
				return NullContact;
			}

			if (fixtureA.Body == fixtureB.Body)
			{
				return NullContact;
			}

			if (bodyB.IsConnected(bodyA))
			{
				return NullContact;
			}

			if (World._contactFilter != null && World._contactFilter.ShouldCollide(fixtureA, fixtureB) == false)
			{
				return NullContact;
			}

			// Call the factory.
			Contact c = Contact.Create(fixtureA, fixtureB);

			if (c == null)
			{
				return NullContact;
			}

			// Contact creation may swap shapes.
			fixtureA = c.FixtureA;
			fixtureB = c.FixtureB;
			bodyA = fixtureA.Body;
			bodyB = fixtureB.Body;

			// Insert into the world.
			c.Prev = null;
			c.Next = World._contactList;
			if (World._contactList != null)
			{
				World._contactList.Prev = c;
			}
			World._contactList = c;

			// Connect to island graph.

			// Connect to body 1
			c.NodeA.Contact = c;
			c.NodeA.Other = bodyB;

			c.NodeA.Prev = null;
			c.NodeA.Next = bodyA._contactList;
			if (bodyA._contactList != null)
			{
				bodyA._contactList.Prev = c.NodeA;
			}
			bodyA._contactList = c.NodeA;

			// Connect to body 2
			c.NodeB.Contact = c;
			c.NodeB.Other = bodyA;

			c.NodeB.Prev = null;
			c.NodeB.Next = bodyB._contactList;
			if (bodyB._contactList != null)
			{
				bodyB._contactList.Prev = c.NodeB;
			}
			bodyB._contactList = c.NodeB;

			++World._contactCount;
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
			if (c == NullContact)
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
				if(World._contactListener!=null)
					World._contactListener.EndContact(c);
			}

			// Remove from the world.
			if (c.Prev != null)
			{
				c.Prev.Next = c.Next;
			}

			if (c.Next != null)
			{
				c.Next.Prev = c.Prev;
			}

			if (c == World._contactList)
			{
				World._contactList = c.Next;
			}

			// Remove from body 1
			if (c.NodeA.Prev != null)
			{
				c.NodeA.Prev.Next = c.NodeA.Next;
			}

			if (c.NodeA.Next != null)
			{
				c.NodeA.Next.Prev = c.NodeA.Prev;
			}

			if (c.NodeA == bodyA._contactList)
			{
				bodyA._contactList = c.NodeA.Next;
			}

			// Remove from body 2
			if (c.NodeB.Prev != null)
			{
				c.NodeB.Prev.Next = c.NodeB.Next;
			}

			if (c.NodeB.Next != null)
			{
				c.NodeB.Next.Prev = c.NodeB.Prev;
			}

			if (c.NodeB == bodyB._contactList)
			{
				bodyB._contactList = c.NodeB.Next;
			}

			// Call the factory.
			Contact.Destroy(ref c);
			--World._contactCount;
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
			for (Contact c = World._contactList; c != null; c = c.GetNext())
			{
				Body bodyA = c.FixtureA.Body;
				Body bodyB = c.FixtureB.Body;
				if (bodyA.IsSleeping() && bodyB.IsSleeping())
				{
					continue;
				}

				c.Update(World._contactListener);
			}
		}
	}
}
