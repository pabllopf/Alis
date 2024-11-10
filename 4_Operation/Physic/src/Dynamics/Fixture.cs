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

/* Original source Farseer Physics Engine:
 * Copyright (c) 2014 Ian Qvist, http://farseerphysics.codeplex.com
 * Microsoft Permissive License (Ms-PL) v1.1
 */

/*
 * Farseer Physics Engine:
 * Copyright (c) 2012 Ian Qvist
 *
 * Original source Box2D:
 * Copyright (c) 2006-2011 Erin Catto http://www.box2d.org
 *
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software
 * in a product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System;
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics.Contacts;
#if XNAAPI
using Vector2 = Microsoft.Xna.Framework.Vector2;
#endif

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     A fixture is used to attach a Shape to a body for collision detection. A fixture
    ///     inherits its transform from its parent. Fixtures hold additional non-geometric data
    ///     such as friction, collision filters, etc.
    /// </summary>
    public class Fixture
    {
        /// <summary>
        /// The collides with
        /// </summary>
        internal Category _collidesWith;
        /// <summary>
        /// The collision categories
        /// </summary>
        internal Category _collisionCategories;
        /// <summary>
        /// The collision group
        /// </summary>
        internal short _collisionGroup;
        /// <summary>
        /// The friction
        /// </summary>
        private float _friction;
        /// <summary>
        /// The is sensor
        /// </summary>
        private bool _isSensor;
        /// <summary>
        /// The restitution
        /// </summary>
        private float _restitution;

        /// <summary>
        ///     Fires after two shapes has collided and are solved. This gives you a chance to get the impact force.
        /// </summary>
        public AfterCollisionEventHandler AfterCollision;

        /// <summary>
        ///     Fires when two fixtures are close to each other.
        ///     Due to how the broadphase works, this can be quite inaccurate as shapes are approximated using AABBs.
        /// </summary>
        public BeforeCollisionEventHandler BeforeCollision;

        /// <summary>
        ///     Fires when two shapes collide and a contact is created between them.
        ///     Note that the first fixture argument is always the fixture that the delegate is subscribed to.
        /// </summary>
        public OnCollisionEventHandler OnCollision;

        /// <summary>
        ///     Fires when two shapes separate and a contact is removed between them.
        ///     Note: This can in some cases be called multiple times, as a fixture can have multiple contacts.
        ///     Note The first fixture argument is always the fixture that the delegate is subscribed to.
        /// </summary>
        public OnSeparationEventHandler OnSeparation;

        /// <summary>
        ///     Set the user data. Use this to store your application specific data.
        /// </summary>
        /// <value>The user data.</value>
        public object Tag;

        /// <summary>
        /// Initializes a new instance of the <see cref="Fixture"/> class
        /// </summary>
        internal Fixture() // Note: This is internal because it's used by Deserialization.
        {
            _collisionCategories = Category.Cat1;
            _collidesWith = Category.All;
            _collisionGroup = 0;

            //Fixture defaults
            Friction = 0.2f;
            Restitution = 0f;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fixture"/> class
        /// </summary>
        /// <param name="shape">The shape</param>
        public Fixture(Shape shape) : this()
        {
            Shape = shape.Clone();

            // Reserve proxy space
            Proxies = new FixtureProxy[Shape.ChildCount];
            ProxyCount = 0;
        }

        /// <summary>
        /// Gets the value of the proxies
        /// </summary>
        public FixtureProxy[] Proxies { get; }
        /// <summary>
        /// Gets or sets the value of the proxy count
        /// </summary>
        public int ProxyCount { get; private set; }

        /// <summary>
        ///     Defaults to 0
        ///     Collision groups allow a certain group of objects to never collide (negative)
        ///     or always collide (positive). Zero means no collision group. Non-zero group
        ///     filtering always wins against the mask bits.
        /// </summary>
        public short CollisionGroup
        {
            set
            {
                if (_collisionGroup == value)
                    return;

                _collisionGroup = value;
                Refilter();
            }
            get => _collisionGroup;
        }

        /// <summary>
        ///     Defaults to Category.All
        ///     The collision mask bits. This states the categories that this
        ///     fixture would accept for collision.
        /// </summary>
        public Category CollidesWith
        {
            get => _collidesWith;

            set
            {
                if (_collidesWith == value)
                    return;

                _collidesWith = value;
                Refilter();
            }
        }

        /// <summary>
        ///     The collision categories this fixture is a part of.
        ///     Defaults to Category.Cat1
        /// </summary>
        public Category CollisionCategories
        {
            get => _collisionCategories;

            set
            {
                if (_collisionCategories == value)
                    return;

                _collisionCategories = value;
                Refilter();
            }
        }

        /// <summary>
        ///     Get the child Shape.
        /// </summary>
        /// <value>The shape.</value>
        public Shape Shape { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether this fixture is a sensor.
        /// </summary>
        /// <value><c>true</c> if this instance is a sensor; otherwise, <c>false</c>.</value>
        public bool IsSensor
        {
            get => _isSensor;
            set
            {
                if (Body != null)
                    Body.Awake = true;

                _isSensor = value;
            }
        }

        /// <summary>
        ///     Get the parent body of this fixture. This is null if the fixture is not attached.
        /// </summary>
        /// <value>The body.</value>
        public Body Body { get; internal set; }

        /// <summary>
        ///     Set the coefficient of friction. This will _not_ change the friction of
        ///     existing contacts.
        /// </summary>
        /// <value>The friction.</value>
        public float Friction
        {
            get => _friction;
            set
            {
                Debug.Assert(!float.IsNaN(value));
                _friction = value;
            }
        }

        /// <summary>
        ///     Set the coefficient of restitution. This will not change the restitution of
        ///     existing contacts.
        /// </summary>
        /// <value>The restitution.</value>
        public float Restitution
        {
            get => _restitution;
            set
            {
                Debug.Assert(!float.IsNaN(value));
                _restitution = value;
            }
        }


        /// <summary>
        ///     Contacts are persistant and will keep being persistant unless they are
        ///     flagged for filtering.
        ///     This methods flags all contacts associated with the body for filtering.
        /// </summary>
        private void Refilter()
        {
            // Flag associated contacts for filtering.
            ContactEdge edge = Body.ContactList;
            while (edge != null)
            {
                Contact contact = edge.Contact;
                Fixture fixtureA = contact.FixtureA;
                Fixture fixtureB = contact.FixtureB;
                if (fixtureA == this || fixtureB == this)
                {
                    contact.FilterFlag = true;
                }

                edge = edge.Next;
            }

            World world = Body.World;

            if (world == null)
                return;

            // Touch each proxy so that new pairs may be created
            IBroadPhase broadPhase = world.ContactManager.BroadPhase;
            TouchProxies(broadPhase);
        }

        /// <summary>
        ///     Touch each proxy so that new pairs may be created
        /// </summary>
        /// <param name="broadPhase"></param>
        internal void TouchProxies(IBroadPhase broadPhase)
        {
            for (int i = 0; i < ProxyCount; ++i)
                broadPhase.TouchProxy(Proxies[i].ProxyId);
        }

        /// <summary>
        ///     Test a point for containment in this fixture.
        /// </summary>
        /// <param name="point">A point in world coordinates.</param>
        /// <returns></returns>
        public bool TestPoint(ref Vector2 point) => Shape.TestPoint(ref Body._xf, ref point);

        /// <summary>
        ///     Cast a ray against this Shape.
        /// </summary>
        /// <param name="output">The ray-cast results.</param>
        /// <param name="input">The ray-cast input parameters.</param>
        /// <param name="childIndex">Index of the child.</param>
        /// <returns></returns>
        public bool RayCast(out RayCastOutput output, ref RayCastInput input, int childIndex) => Shape.RayCast(out output, ref input, ref Body._xf, childIndex);

        /// <summary>
        ///     Get the fixture's AABB. This AABB may be enlarge and/or stale.
        ///     If you need a more accurate AABB, compute it using the Shape and
        ///     the body transform.
        /// </summary>
        /// <param name="aabb">The aabb.</param>
        /// <param name="childIndex">Index of the child.</param>
        public void GetAABB(out AABB aabb, int childIndex)
        {
            Debug.Assert((0 <= childIndex) && (childIndex < ProxyCount));
            aabb = Proxies[childIndex].AABB;
        }

        // These support body activation/deactivation.
        /// <summary>
        /// Creates the proxies using the specified broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="xf">The xf</param>
        /// <exception cref="InvalidOperationException">Proxies allready created for this Fixture.</exception>
        internal void CreateProxies(IBroadPhase broadPhase, ref Transform xf)
        {
            if (ProxyCount != 0)
                throw new InvalidOperationException("Proxies allready created for this Fixture.");

            // Create proxies in the broad-phase.
            ProxyCount = Shape.ChildCount;

            for (int i = 0; i < ProxyCount; ++i)
            {
                FixtureProxy proxy = new FixtureProxy();
                proxy.Fixture = this;
                proxy.ChildIndex = i;
                Shape.ComputeAABB(out proxy.AABB, ref xf, i);
                proxy.ProxyId = broadPhase.AddProxy(ref proxy.AABB);
                broadPhase.SetProxy(proxy.ProxyId, ref proxy);

                Proxies[i] = proxy;
            }
        }

        /// <summary>
        /// Destroys the proxies using the specified broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        internal void DestroyProxies(IBroadPhase broadPhase)
        {
            // Destroy proxies in the broad-phase.
            for (int i = 0; i < ProxyCount; ++i)
            {
                broadPhase.RemoveProxy(Proxies[i].ProxyId);
                Proxies[i].ProxyId = -1;
            }

            ProxyCount = 0;
        }

        /// <summary>
        /// Synchronizes the broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="transform1">The transform</param>
        /// <param name="transform2">The transform</param>
        internal void Synchronize(IBroadPhase broadPhase, ref Transform transform1, ref Transform transform2)
        {
            for (int i = 0; i < ProxyCount; ++i)
            {
                FixtureProxy proxy = Proxies[i];

                // Compute an AABB that covers the swept Shape (may miss some rotation effect).
                AABB aabb1, aabb2;
                Shape.ComputeAABB(out aabb1, ref transform1, proxy.ChildIndex);
                Shape.ComputeAABB(out aabb2, ref transform2, proxy.ChildIndex);

                proxy.AABB.Combine(ref aabb1, ref aabb2);

                Vector2 displacement = transform2.p - transform1.p;

                broadPhase.MoveProxy(proxy.ProxyId, ref proxy.AABB, displacement);
            }
        }

        /// <summary>
        ///     Clones the fixture onto the specified body.
        /// </summary>
        /// <param name="body">The body you wish to clone the fixture onto.</param>
        /// <returns>The cloned fixture.</returns>
        public Fixture CloneOnto(Body body) => CloneOnto(body, Shape);

        /// <summary>
        ///     Clones the fixture and attached shape onto the specified body.
        ///     Note: This is used only by Deserialization.
        /// </summary>
        /// <param name="body">The body you wish to clone the fixture onto.</param>
        /// <returns>The cloned fixture.</returns>
        internal Fixture CloneOnto(Body body, Shape shape)
        {
            Fixture fixture = new Fixture(shape.Clone());
            fixture.Tag = Tag;
            fixture.Restitution = Restitution;
            fixture.Friction = Friction;
            fixture.IsSensor = IsSensor;
            fixture._collisionGroup = _collisionGroup;
            fixture._collisionCategories = _collisionCategories;
            fixture._collidesWith = _collidesWith;

            body.Add(fixture);
            return fixture;
        }
    }
}