// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Fixture.cs
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

using System.Diagnostics;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Collision.Broadphase;
using Alis.Core.Systems.Physics2D.Collision.ContactSystem;
using Alis.Core.Systems.Physics2D.Collision.Filtering;
using Alis.Core.Systems.Physics2D.Collision.Handlers;
using Alis.Core.Systems.Physics2D.Collision.RayCast;
using Alis.Core.Systems.Physics2D.Collision.Shapes;
using Alis.Core.Systems.Physics2D.Definitions;
using Alis.Core.Systems.Physics2D.Shared;

namespace Alis.Core.Systems.Physics2D.Dynamics
{
    /// <summary>
    ///     A fixture is used to attach a Shape to a body for collision detection. A fixture inherits its transform from
    ///     its parent. Fixtures hold additional non-geometric data such as friction, collision filters, etc. Fixtures are
    ///     created
    ///     via Body.CreateFixture. Warning: You cannot reuse fixtures.
    /// </summary>
    public class Fixture
    {
        /// <summary>
        ///     The body
        /// </summary>
        internal Body _bodyprivate;

        /// <summary>
        ///     The collides with
        /// </summary>
        internal Category _collidesWithprivate;

        /// <summary>
        ///     The collision categories
        /// </summary>
        internal Category _collisionCategoriesprivate;

        /// <summary>
        ///     The collision group
        /// </summary>
        internal short _collisionGroupPrivate;

        /// <summary>
        ///     The friction
        /// </summary>
        internal float _frictionprivate;

        /// <summary>
        ///     The ignore ccd with
        /// </summary>
        private Category _ignoreCcdWith;

        /// <summary>
        ///     The is sensor
        /// </summary>
        internal bool _isSensorPrivate;

        /// <summary>
        ///     The proxies
        /// </summary>
        private FixtureProxy[] _proxies;

        /// <summary>
        ///     The proxy count
        /// </summary>
        private int _proxyCount;

        /// <summary>
        ///     The restitution
        /// </summary>
        internal float _restitutionprivate;

        /// <summary>
        ///     The restitution threshold
        /// </summary>
        internal float _restitutionThresholdPrivate;

        /// <summary>
        ///     The shape
        /// </summary>
        internal Shape _shapePrivate;

        /// <summary>
        ///     The user data
        /// </summary>
        private object _userData;

        /// <summary>Fires after two shapes has collided and are solved. This gives you a chance to get the impact force.</summary>
        public AfterCollisionHandler AfterCollision;

        /// <summary>
        ///     Fires when two fixtures are close to each other. Due to how the broadphase works, this can be quite inaccurate
        ///     as shapes are approximated using AABBs.
        /// </summary>
        public BeforeCollisionHandler BeforeCollision;

        /// <summary>
        ///     Fires when two shapes collide and a contact is created between them. Note that the first fixture argument is
        ///     always the fixture that the delegate is subscribed to.
        /// </summary>
        public OnCollisionHandler OnCollision;

        /// <summary>
        ///     Fires when two shapes separate and a contact is removed between them. Note: This can in some cases be called
        ///     multiple times, as a fixture can have multiple contacts. Note The first fixture argument is always the fixture that
        ///     the
        ///     delegate is subscribed to.
        /// </summary>
        public OnSeparationHandler OnSeparation;


        /// <summary>
        ///     Initializes a new instance of the <see cref="Fixture" /> class
        /// </summary>
        /// <param name="def">The def</param>
        internal Fixture(FixtureDef def)
        {
            _userData = def.UserData;
            _frictionprivate = def.Friction;
            _restitutionprivate = def.Restitution;
            _restitutionThresholdPrivate = def.RestitutionThreshold;

            _collisionGroupPrivate = def.Filter.Group;
            _collisionCategoriesprivate = def.Filter.Category;
            _collidesWithprivate = def.Filter.CategoryMask;

            //Velcro: we have support for ignoring CCD with certain groups
            _ignoreCcdWith = Settings.DefaultFixtureIgnoreCcdWith;

            _isSensorPrivate = def.IsSensor;
            _shapePrivate = def.Shape.Clone();

            // Reserve proxy space
            int childCount = Shape.ChildCount;
            _proxies = new FixtureProxy[childCount];
            for (int i = 0; i < childCount; ++i)
            {
                _proxies[i].Fixture = null;
                _proxies[i].ProxyId = DynamicTreeBroadPhase.NullProxy;
            }

            _proxyCount = 0;

            //TODO:
            //m_density = def->density;
        }

        /// <summary>
        ///     Gets or sets the value of the ignore ccd with
        /// </summary>
        public Category IgnoreCcdWith
        {
            get => _ignoreCcdWith;
            set => _ignoreCcdWith = value;
        }

        /// <summary>
        ///     Gets the value of the proxies
        /// </summary>
        public FixtureProxy[] Proxies => _proxies;

        /// <summary>
        ///     Gets the value of the proxy count
        /// </summary>
        public int ProxyCount => _proxyCount;

        /// <summary>Get or set the restitution threshold. This will _not_ change the restitution threshold of existing contacts.</summary>
        public float RestitutionThreshold
        {
            get => _restitutionThresholdPrivate;
            set => _restitutionThresholdPrivate = value;
        }

        /// <summary>
        ///     Defaults to 0 If Settings.UseFPECollisionCategories is set to false: Collision groups allow a certain group of
        ///     objects to never collide (negative) or always collide (positive). Zero means no collision group. Non-zero group
        ///     filtering always wins against the mask bits. If Settings.UseFPECollisionCategories is set to true: If 2 fixtures
        ///     are in
        ///     the same collision group, they will not collide.
        /// </summary>
        public short CollisionGroup
        {
            set
            {
                if (_collisionGroupPrivate == value)
                {
                    return;
                }

                _collisionGroupPrivate = value;
                Refilter();
            }
            get => _collisionGroupPrivate;
        }

        /// <summary>
        ///     Defaults to Category.All The collision mask bits. This states the categories that this fixture would accept
        ///     for collision. Use Settings.UseFPECollisionCategories to change the behavior.
        /// </summary>
        public Category CollidesWith
        {
            get => _collidesWithprivate;

            set
            {
                if (_collidesWithprivate == value)
                {
                    return;
                }

                _collidesWithprivate = value;
                Refilter();
            }
        }

        /// <summary>
        ///     The collision categories this fixture is a part of. If Settings.UseFPECollisionCategories is set to false:
        ///     Defaults to Category.Cat1 If Settings.UseFPECollisionCategories is set to true: Defaults to Category.All
        /// </summary>
        public Category CollisionCategories
        {
            get => _collisionCategoriesprivate;

            set
            {
                if (_collisionCategoriesprivate == value)
                {
                    return;
                }

                _collisionCategoriesprivate = value;
                Refilter();
            }
        }

        /// <summary>
        ///     Get the child Shape. You can modify the child Shape, however you should not change the number of vertices
        ///     because this will crash some collision caching mechanisms.
        /// </summary>
        /// <value>The shape.</value>
        public Shape Shape => _shapePrivate;

        /// <summary>Gets or sets a value indicating whether this fixture is a sensor.</summary>
        /// <value><c>true</c> if this instance is a sensor; otherwise, <c>false</c>.</value>
        public bool IsSensor
        {
            get => _isSensorPrivate;
            set
            {
                if (_bodyprivate != null)
                {
                    _bodyprivate.Awake = true;
                }

                _isSensorPrivate = value;
            }
        }

        /// <summary>Get the parent body of this fixture. This is null if the fixture is not attached.</summary>
        /// <value>The body.</value>
        public Body Body => _bodyprivate;

        /// <summary>Set the user data. Use this to store your application specific data.</summary>
        /// <value>The user data.</value>
        public object UserData
        {
            get => _userData;
            set => _userData = value;
        }

        /// <summary>Set the coefficient of friction. This will _not_ change the friction of existing contacts.</summary>
        /// <value>The friction.</value>
        public float Friction
        {
            get => _frictionprivate;
            set
            {
                Debug.Assert(!float.IsNaN(value));

                _frictionprivate = value;
            }
        }

        /// <summary>Set the coefficient of restitution. This will not change the restitution of existing contacts.</summary>
        /// <value>The restitution.</value>
        public float Restitution
        {
            get => _restitutionprivate;
            set
            {
                Debug.Assert(!float.IsNaN(value));

                _restitutionprivate = value;
            }
        }

        /// <summary>
        ///     Contacts are persistent and will keep being persistent unless they are flagged for filtering. This methods
        ///     flags all contacts associated with the body for filtering.
        /// </summary>
        private void Refilter()
        {
            // Flag associated contacts for filtering.
            ContactEdge edge = _bodyprivate.ContactList;
            while (edge != null)
            {
                Contact contact = edge.Contact;
                Fixture fixtureA = contact.FixtureA;
                Fixture fixtureB = contact.FixtureB;
                if (fixtureA == this || fixtureB == this)
                {
                    contact.Flags |= ContactFlags.FilterFlag;
                }

                edge = edge.Next;
            }

            World world = _bodyprivate._world;

            if (world == null)
            {
                return;
            }

            // Touch each proxy so that new pairs may be created
            IBroadPhase broadPhase = world.ContactManager.BroadPhase;
            for (int i = 0; i < _proxyCount; ++i)
            {
                broadPhase.TouchProxy(_proxies[i].ProxyId);
            }
        }

        /// <summary>Test a point for containment in this fixture.</summary>
        /// <param name="point">A point in world coordinates.</param>
        public bool TestPoint(ref Vector2 point) => Shape.TestPoint(ref _bodyprivate._xf, ref point);

        /// <summary>Cast a ray against this Shape.</summary>
        /// <param name="output">The ray-cast results.</param>
        /// <param name="input">The ray-cast input parameters.</param>
        /// <param name="childIndex">Index of the child.</param>
        public bool RayCast(out RayCastOutput output, ref RayCastInput input, int childIndex) =>
            Shape.RayCast(ref input, ref _bodyprivate._xf, childIndex, out output);

        /// <summary>
        ///     Get the fixture's AABB. This AABB may be enlarge and/or stale. If you need a more accurate AABB, compute it
        ///     using the Shape and the body transform.
        /// </summary>
        /// <param name="aabb">The AABB.</param>
        /// <param name="childIndex">Index of the child.</param>
        public void GetAABB(out AABB aabb, int childIndex)
        {
            Debug.Assert(0 <= childIndex && childIndex < _proxyCount);
            aabb = _proxies[childIndex].AABB;
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        internal void Destroy()
        {
            // The proxies must be destroyed before calling this.
            Debug.Assert(_proxyCount == 0);

            // Free the proxy array.
            _proxies = null;
            _shapePrivate = null;

            //Velcro: We set the userdata to null here to help prevent bugs related to stale references in GC
            _userData = null;

            BeforeCollision = null;
            OnCollision = null;
            OnSeparation = null;
            AfterCollision = null;
        }

        // These support body activation/deactivation.
        /// <summary>
        ///     Creates the proxies using the specified broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="xf">The xf</param>
        internal void CreateProxies(IBroadPhase broadPhase, ref Transform xf)
        {
            Debug.Assert(_proxyCount == 0);

            // Create proxies in the broad-phase.
            _proxyCount = _shapePrivate.ChildCount;

            for (int i = 0; i < _proxyCount; ++i)
            {
                FixtureProxy proxy = new FixtureProxy();
                _shapePrivate.ComputeAABB(ref xf, i, out proxy.AABB);
                proxy.Fixture = this;
                proxy.ChildIndex = i;

                //Velcro note: This line needs to be after the previous two because FixtureProxy is a struct
                proxy.ProxyId = broadPhase.AddProxy(ref proxy);

                _proxies[i] = proxy;
            }
        }

        /// <summary>
        ///     Destroys the proxies using the specified broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        internal void DestroyProxies(IBroadPhase broadPhase)
        {
            // Destroy proxies in the broad-phase.
            for (int i = 0; i < _proxyCount; ++i)
            {
                FixtureProxy proxy = _proxies[i];
                broadPhase.RemoveProxy(proxy.ProxyId);
                proxy.ProxyId = DynamicTreeBroadPhase.NullProxy;
            }

            _proxyCount = 0;
        }

        /// <summary>
        ///     Synchronizes the broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="transform1">The transform</param>
        /// <param name="transform2">The transform</param>
        internal void Synchronize(IBroadPhase broadPhase, ref Transform transform1, ref Transform transform2)
        {
            if (_proxyCount == 0)
            {
                return;
            }

            for (int i = 0; i < _proxyCount; ++i)
            {
                FixtureProxy proxy = _proxies[i];

                // Compute an AABB that covers the swept Shape (may miss some rotation effect).
                Shape.ComputeAABB(ref transform1, proxy.ChildIndex, out AABB aabb1);
                Shape.ComputeAABB(ref transform2, proxy.ChildIndex, out AABB aabb2);

                proxy.AABB.Combine(ref aabb1, ref aabb2);

                Vector2 displacement = aabb2.Center - aabb1.Center;

                broadPhase.MoveProxy(proxy.ProxyId, ref proxy.AABB, displacement);
            }
        }
    }
}