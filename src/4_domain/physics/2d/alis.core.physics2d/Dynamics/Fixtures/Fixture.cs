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

using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.Collision;
using Alis.Core.Physics2D.Collision.Shapes;
using Alis.Core.Physics2D.Common;
using Alis.Core.Physics2D.Dynamics.Bodies;
using Alis.Core.Physics2D.Dynamics.Contacts;

namespace Alis.Core.Physics2D.Dynamics.Fixtures
{
    /// <summary>
    ///     A fixture is used to attach a shape to a body for collision detection. A fixture
    ///     inherits its transform from its parent. Fixtures hold additional non-geometric data
    ///     such as friction, collision filters, etc.
    ///     Fixtures are created via Body.CreateFixture.
    ///     @warning you cannot reuse fixtures.
    /// </summary>
    [DebuggerDisplay("Fixture of {m_body.UserData}")]
    public class Fixture
    {
        /// <summary>
        /// The body
        /// </summary>
        internal Body m_body;

        /// <summary>
        /// The density
        /// </summary>
        internal float m_density;
        /// <summary>
        /// The filter
        /// </summary>
        internal Filter m_filter;
        /// <summary>
        /// The friction
        /// </summary>
        public float m_friction;

        /// <summary>
        /// The next
        /// </summary>
        internal Fixture m_next;
        /// <summary>
        /// The proxies
        /// </summary>
        internal FixtureProxy[] m_proxies;
        /// <summary>
        /// The proxycount
        /// </summary>
        internal int m_proxyCount;
        /// <summary>
        /// The restitution
        /// </summary>
        internal float m_restitution;

        // non-public default constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Fixture"/> class
        /// </summary>
        internal Fixture()
        {
            UserData = null;
            m_proxyCount = 0;
            m_density = 0f;
        }

        /// <summary>
        /// Gets or sets the value of the shape
        /// </summary>
        public Shape Shape
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the value of the sensor
        /// </summary>
        private bool Sensor
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of the filter data
        /// </summary>
        public Filter FilterData
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_filter;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                m_filter = value;
                Refilter();
            }
        }

        /// <summary>
        /// Gets the value of the body
        /// </summary>
        public Body Body
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_body;
        }

        /// <summary>
        /// Gets the value of the next
        /// </summary>
        public Fixture Next
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_next;
        }

        /// <summary>
        /// Gets or sets the value of the density
        /// </summary>
        public float Density
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_density;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => m_density = value;
        }

        /// <summary>
        /// Gets or sets the value of the restitution
        /// </summary>
        public float Restitution
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => m_restitution;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => m_restitution = value;
        }

        /// <summary>
        /// Gets or sets the value of the user data
        /// </summary>
        public object UserData
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            private set;
        }

        /// <summary>
        /// Creates the body
        /// </summary>
        /// <param name="body">The body</param>
        /// <param name="def">The def</param>
        /// <exception cref="ArgumentNullException">def.shape</exception>
        public void Create(Body body, FixtureDef def)
        {
            if (def.shape == null)
            {
                throw new ArgumentNullException("def.shape");
            }

            UserData = def.userData;
            m_friction = def.friction;
            m_restitution = def.restitution;

            m_body = body;
            m_next = null;

            m_filter = def.filter;

            Sensor = def.isSensor;

            Shape = def.shape.Clone();

            // Reserve proxy space
            int childCount = Shape.GetChildCount();
            m_proxies = new FixtureProxy[childCount];
            for (int i = 0; i < childCount; ++i)
            {
                m_proxies[i] = new FixtureProxy();
            }

            m_proxyCount = 0;

            m_density = def.density;
        }

        /// <summary>
        /// Creates the proxies using the specified broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="xf">The xf</param>
        internal void CreateProxies(BroadPhase broadPhase, in Transform xf)
        {
            //Debug.Assert(m_proxyCount == 0);

            // Create proxies in the broad-phase.
            m_proxyCount = Shape.GetChildCount();

            for (int i = 0; i < m_proxyCount; ++i)
            {
                FixtureProxy proxy = m_proxies[i];
                Shape.ComputeAABB(out proxy.aabb, in xf, i);
                proxy.proxyId = broadPhase.CreateProxy(proxy.aabb, proxy);
                proxy.fixture = this;
                proxy.childIndex = i;
            }
        }

        /// <summary>
        /// Destroys the proxies using the specified broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        internal void DestroyProxies(BroadPhase broadPhase)
        {
            // Destroy proxies in the broad-phase.
            for (int i = 0; i < m_proxyCount; ++i)
            {
                FixtureProxy proxy = m_proxies[i];
                broadPhase.DestroyProxy(proxy.proxyId);
                proxy.proxyId = -1;
            }

            m_proxyCount = 0;
        }

        /// <summary>
        /// Synchronizes the broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="transform1">The transform</param>
        /// <param name="transform2">The transform</param>
        internal void Synchronize(BroadPhase broadPhase, in Transform transform1, in Transform transform2)
        {
            if (m_proxyCount == 0)
            {
                return;
            }

            for (int i = 0; i < m_proxyCount; ++i)
            {
                FixtureProxy proxy = m_proxies[i];

                // Compute an AABB that covers the swept shape (may miss some rotation effect).
                Shape.ComputeAABB(out AABB aabb1, in transform1, proxy.childIndex);
                Shape.ComputeAABB(out AABB aabb2, in transform2, proxy.childIndex);

                proxy.aabb = AABB.Combine(aabb1, aabb2);

                Vector2 displacement = aabb2.GetCenter() - aabb1.GetCenter();

                broadPhase.MoveProxy(proxy.proxyId, proxy.aabb, displacement);
            }
        }

        /// <summary>
        /// Sets the filter data using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        private void SetFilterData(in Filter filter)
        {
            m_filter = filter;

            Refilter();
        }

        /// <summary>
        /// Refilters this instance
        /// </summary>
        public void Refilter()
        {
            if (m_body == null)
            {
                return;
            }

            // Flag associated contacts for filtering.
            ContactEdge edge = m_body.GetContactList();
            while (edge != null)
            {
                Contact contact = edge.contact;
                Fixture fixtureA = contact.GetFixtureA();
                Fixture fixtureB = contact.GetFixtureB();
                if (fixtureA == this || fixtureB == this)
                {
                    contact.FlagForFiltering();
                }

                edge = edge.next;
            }

            World.World world = m_body.GetWorld();

            if (world == null)
            {
                return;
            }

            // Touch each proxy so that new pairs may be created
            BroadPhase broadPhase = world.m_contactManager.m_broadPhase;
            for (int i = 0; i < m_proxyCount; ++i)
            {
                broadPhase.TouchProxy(m_proxies[i].proxyId);
            }
        }

        /// <summary>
        /// Describes whether this instance is sensor
        /// </summary>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSensor() => Sensor;

        /// <summary>
        /// Gets the filter data
        /// </summary>
        /// <returns>The filter</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Filter GetFilterData() => m_filter;

        /// <summary>
        /// Gets the body
        /// </summary>
        /// <returns>The body</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Body GetBody() => Body;

        /// <summary>
        /// Gets the next
        /// </summary>
        /// <returns>The fixture</returns>
        public Fixture GetNext() => m_next;

        /// <summary>
        /// Describes whether this instance test point
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TestPoint(in Vector2 p) => Shape.TestPoint(m_body.GetTransform(), p);

        /// <summary>
        /// Describes whether this instance ray cast
        /// </summary>
        /// <param name="output">The output</param>
        /// <param name="input">The input</param>
        /// <param name="childIndex">The child index</param>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool RayCast(out RayCastOutput output, in RayCastInput input, int childIndex) =>
            Shape.RayCast(out output, in input, m_body.GetTransform(), childIndex);

        /// <summary>
        /// Gets the mass data using the specified mass data
        /// </summary>
        /// <param name="massData">The mass data</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetMassData(out MassData massData)
        {
            Shape.ComputeMass(out massData, m_density);
        }

        /// <summary>
        /// Gets the aabb using the specified child index
        /// </summary>
        /// <param name="childIndex">The child index</param>
        /// <returns>The aabb</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AABB GetAABB(int childIndex) => m_proxies[childIndex].aabb;
    }
}