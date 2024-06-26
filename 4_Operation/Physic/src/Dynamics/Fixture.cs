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

using System;
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.BroadPhase;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Handlers;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     A fixture is used to attach a Shape to a body for collision detection. A fixture inherits its transform from
    ///     its parent. Fixtures hold additional non-geometric data such as friction, collision filters, etc. Fixtures are
    ///     created
    ///     via Body.CreateFixture. Warning: You cannot reuse fixtures.
    /// </summary>
    public class Fixture
    {
        /// <summary>Fires after two shapes has collided and are solved. This gives you a chance to get the impact force.</summary>
        public AfterCollisionHandler AfterCollision;
        
        /// <summary>
        ///     Fires when two fixtures are close to each other. Due to how the broadphase works, this can be quite inaccurate
        ///     as shapes are approximated using AABBs.
        /// </summary>
        public BeforeCollisionHandler BeforeCollision;
        
        /// <summary>
        ///     The collides with
        /// </summary>
        internal Category CollidesWithprivate;
        
        /// <summary>
        ///     The collision categories
        /// </summary>
        internal Category CollisionCategoriesprivate;
        
        /// <summary>
        ///     The collision group
        /// </summary>
        internal short CollisionGroupPrivate;
        
        /// <summary>
        ///     The is sensor
        /// </summary>
        internal bool IsSensorPrivate;
        
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
        /// <param name="shape">The shape</param>
        /// <param name="filter">The filter</param>
        /// <param name="friction">The friction</param>
        /// <param name="restitution">The restitution</param>
        /// <param name="restitutionThreshold">The restitution threshold</param>
        /// <param name="isSensor">The is sensor</param>
        [ExcludeFromCodeCoverage]
        public Fixture(
            AShape shape,
            Filter filter,
            float friction = 0.2f,
            float restitution = 0.0f,
            float restitutionThreshold = 1.0f,
            bool isSensor = false
        )
        {
            if (shape == null)
            {
                throw new ArgumentNullException(nameof(shape));
            }
            
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }
            
            Friction = friction;
            Restitution = restitution;
            RestitutionThreshold = restitutionThreshold;
            
            CollisionGroupPrivate = filter.Group;
            CollisionCategoriesprivate = filter.Category;
            CollidesWithprivate = filter.CategoryMask;
            
            IgnoreCcdWith = Settings.DefaultFixtureIgnoreCcdWith;
            
            IsSensorPrivate = isSensor;
            Shape = shape.Clone();
            
            int childCount = Shape.ChildCount;
            Proxies = new FixtureProxy[childCount];
            for (int i = 0; i < childCount; ++i)
            {
                Proxies[i].Fixture = null;
                Proxies[i].ProxyId = DynamicTreeBroadPhase.NullProxy;
            }
            
            ProxyCount = 0;
        }
        
        /// <summary>Contact filtering data.</summary>
        [ExcludeFromCodeCoverage]
        public Filter Filter { get; set; } = new Filter();
        
        /// <summary>
        ///     Gets or sets the value of the ignore ccd with
        /// </summary>
        [ExcludeFromCodeCoverage]
        public Category IgnoreCcdWith { get; set; }
        
        /// <summary>
        ///     Gets the value of the proxies
        /// </summary>
        public FixtureProxy[] Proxies { get; private set; }
        
        /// <summary>
        ///     Gets the value of the proxy count
        /// </summary>
        public int ProxyCount { get; private set; }
        
        /// <summary>Get or set the restitution threshold. This will _not_ change the restitution threshold of existing contacts.</summary>
        public float RestitutionThreshold { get; }
        
        /// <summary>
        ///     Defaults to 0 If Settings.UseFPECollisionCategories is set to false: Collision groups allow a certain group of
        ///     objects to never collide (negative) or always collide (positive). Zero means no collision group. Non-zero group
        ///     filtering always wins against the mask bits. If Settings.UseFPECollisionCategories is set to true: If 2 fixtures
        ///     are in
        ///     the same collision group, they will not collide.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public short CollisionGroup
        {
            set
            {
                if (CollisionGroupPrivate == value)
                {
                    return;
                }
                
                CollisionGroupPrivate = value;
                Refilter();
            }
            get => CollisionGroupPrivate;
        }
        
        /// <summary>
        ///     Defaults to Category.All The collision mask bits. This states the categories that this fixture would accept
        ///     for collision. Use Settings.UseFPECollisionCategories to change the behavior.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public Category CollidesWith
        {
            get => CollidesWithprivate;
            
            set
            {
                if (CollidesWithprivate == value)
                {
                    return;
                }
                
                CollidesWithprivate = value;
                Refilter();
            }
        }
        
        /// <summary>
        ///     The collision categories this fixture is a part of. If Settings.UseFPECollisionCategories is set to false:
        ///     Defaults to Category.Cat1 If Settings.UseFPECollisionCategories is set to true: Defaults to Category.All
        /// </summary>
        [ExcludeFromCodeCoverage]
        public Category CollisionCategories
        {
            get => CollisionCategoriesprivate;
            
            set
            {
                if (CollisionCategoriesprivate == value)
                {
                    return;
                }
                
                CollisionCategoriesprivate = value;
                Refilter();
            }
        }
        
        /// <summary>
        ///     Get the child Shape. You can modify the child Shape, however you should not change the number of vertices
        ///     because this will crash some collision caching mechanisms.
        /// </summary>
        /// <value>The shape.</value>
        public AShape Shape { get; internal set; }
        
        /// <summary>Gets or sets a value indicating whether this fixture is a sensor.</summary>
        /// <value><c>true</c> if this instance is a sensor; otherwise, <c>false</c>.</value>
        [ExcludeFromCodeCoverage]
        public bool IsSensor
        {
            get => IsSensorPrivate;
            set
            {
                if (Body != null)
                {
                    Body.Awake = true;
                }
                
                IsSensorPrivate = value;
            }
        }
        
        /// <summary>Get the parent body of this fixture. This is null if the fixture is not attached.</summary>
        /// <value>The body.</value>
        public Body Body { get; internal set; }
        
        /// <summary>Set the coefficient of friction. This will _not_ change the friction of existing contacts.</summary>
        /// <value>The friction.</value>
        public float Friction { get; set; }
        
        /// <summary>Set the coefficient of restitution. This will not change the restitution of existing contacts.</summary>
        /// <value>The restitution.</value>
        public float Restitution { get; set; }
        
        /// <summary>
        ///     Contacts are persistent and will keep being persistent unless they are flagged for filtering. This methods
        ///     flags all contacts associated with the body for filtering.
        /// </summary>
        [ExcludeFromCodeCoverage]
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
                    contact.Flags |= ContactSetting.FilterFlag;
                }
                
                edge = edge.Next;
            }
            
            // Touch each proxy so that new pairs may be created
            IBroadPhase broadPhase = ContactManager.Current.BroadPhase;
            for (int i = 0; i < ProxyCount; ++i)
            {
                broadPhase.TouchProxy(Proxies[i].ProxyId);
            }
        }
        
        /// <summary>Test a point for containment in this fixture.</summary>
        /// <param name="point">A point in world coordinates.</param>
        public bool TestPoint(ref Vector2 point) => Shape.TestPoint(ref Body.Xf, ref point);
        
        /// <summary>Cast a ray against this Shape.</summary>
        /// <param name="output">The ray-cast results.</param>
        /// <param name="input">The ray-cast input parameters.</param>
        /// <param name="childIndex">Index of the child.</param>
        public bool RayCast(out RayCastOutput output, ref RayCastInput input, int childIndex) =>
            Shape.RayCast(ref input, ref Body.Xf, childIndex, out output);
        
        /// <summary>
        ///     Get the fixture's AABB. This AABB may be enlarge and/or stale. If you need a more accurate AABB, compute it
        ///     using the Shape and the body transform.
        /// </summary>
        /// <param name="aabb">The AABB.</param>
        /// <param name="childIndex">Index of the child.</param>
        public void GetAabb(out Aabb aabb, int childIndex)
        {
            aabb = Proxies[childIndex].Aabb;
        }
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        internal void Destroy()
        {
            // Free the proxy array.
            Proxies = null;
            Shape = null;
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
            // Create proxies in the broad-phase.
            ProxyCount = Shape.ChildCount;
            
            for (int i = 0; i < ProxyCount; ++i)
            {
                FixtureProxy proxy = new FixtureProxy();
                Shape.ComputeAabb(ref xf, i, out proxy.Aabb);
                proxy.Fixture = this;
                proxy.ChildIndex = i;
                
                //Velcro note: This line needs to be after the previous two because FixtureProxy is a struct
                proxy.ProxyId = broadPhase.AddProxy(ref proxy);
                
                Proxies[i] = proxy;
            }
        }
        
        /// <summary>
        ///     Destroys the proxies using the specified broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        [ExcludeFromCodeCoverage]
        internal void DestroyProxies(IBroadPhase broadPhase)
        {
            // Destroy proxies in the broad-phase.
            for (int i = 0; i < ProxyCount; ++i)
            {
                FixtureProxy proxy = Proxies[i];
                broadPhase.RemoveProxy(proxy.ProxyId);
                proxy.ProxyId = DynamicTreeBroadPhase.NullProxy;
            }
            
            ProxyCount = 0;
        }
        
        /// <summary>
        ///     Synchronizes the broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="transform1">The transform</param>
        /// <param name="transform2">The transform</param>
        [ExcludeFromCodeCoverage]
        internal void Synchronize(IBroadPhase broadPhase, ref Transform transform1, ref Transform transform2)
        {
            if (ProxyCount == 0)
            {
                return;
            }
            
            for (int i = 0; i < ProxyCount; ++i)
            {
                FixtureProxy proxy = Proxies[i];
                
                // Compute an AABB that covers the swept Shape (may miss some rotation effect).
                Shape.ComputeAabb(ref transform1, proxy.ChildIndex, out Aabb aabb1);
                Shape.ComputeAabb(ref transform2, proxy.ChildIndex, out Aabb aabb2);
                
                proxy.Aabb.Combine(ref aabb1, ref aabb2);
                
                
                Vector2 displacement = aabb2.Center - aabb1.Center;
                
                broadPhase.MoveProxy(proxy.ProxyId, ref proxy.Aabb, displacement);
            }
        }
    }
}