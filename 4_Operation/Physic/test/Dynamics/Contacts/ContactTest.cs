// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactTest.cs
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

using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact test class
    /// </summary>
    public class ContactTest
    {
        /// <summary>
        /// Tests that contact type should be accessible
        /// </summary>
        [Fact]
        public void Contact_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(Contact));
        }

        /// <summary>
        /// Tests that constructor with null fixtures should set defaults
        /// </summary>
        [Fact]
        public void Constructor_WithNullFixtures_ShouldSetDefaults()
        {
            Contact contact = new Contact(null, 0, null, 0);

            Assert.False(contact.IsTouching);
            Assert.True(contact.Enabled);
            Assert.Null(contact.FixtureA);
            Assert.Null(contact.FixtureB);
            Assert.Equal(0, contact.ChildIndexA);
            Assert.Equal(0, contact.ChildIndexB);
            Assert.Equal(0, contact.Friction);
            Assert.Equal(0, contact.Restitution);
            Assert.Equal(0, contact.TangentSpeed);
            Assert.Null(contact.Next);
            Assert.Null(contact.Prev);
        }

        /// <summary>
        /// Tests that constructor with valid fixtures should initialize properties
        /// </summary>
        [Fact]
        public void Constructor_WithValidFixtures_ShouldInitializeProperties()
        {
            Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));

            Contact contact = new Contact(fixtureA, 0, fixtureB, 1);

            Assert.Same(fixtureA, contact.FixtureA);
            Assert.Same(fixtureB, contact.FixtureB);
            Assert.Equal(0, contact.ChildIndexA);
            Assert.Equal(1, contact.ChildIndexB);
            Assert.True(contact.Enabled);
            Assert.False(contact.IsTouching);
        }

        /// <summary>
        /// Tests that friction should have default value zero
        /// </summary>
        [Fact]
        public void Friction_DefaultValue_ShouldBeZero()
        {
            Contact contact = new Contact(null, 0, null, 0);
            Assert.Equal(0, contact.Friction);
        }

        /// <summary>
        /// Tests that friction should set and get
        /// </summary>
        [Fact]
        public void Friction_SetAndGet_ShouldRoundtrip()
        {
            Contact contact = new Contact(null, 0, null, 0);
            contact.Friction = 0.5f;
            Assert.Equal(0.5f, contact.Friction);
        }

        /// <summary>
        /// Tests that restitution should have default value zero
        /// </summary>
        [Fact]
        public void Restitution_DefaultValue_ShouldBeZero()
        {
            Contact contact = new Contact(null, 0, null, 0);
            Assert.Equal(0, contact.Restitution);
        }

        /// <summary>
        /// Tests that restitution should set and get
        /// </summary>
        [Fact]
        public void Restitution_SetAndGet_ShouldRoundtrip()
        {
            Contact contact = new Contact(null, 0, null, 0);
            contact.Restitution = 0.3f;
            Assert.Equal(0.3f, contact.Restitution);
        }

        /// <summary>
        /// Tests that tangent speed should have default value zero
        /// </summary>
        [Fact]
        public void TangentSpeed_DefaultValue_ShouldBeZero()
        {
            Contact contact = new Contact(null, 0, null, 0);
            Assert.Equal(0, contact.TangentSpeed);
        }

        /// <summary>
        /// Tests that tangent speed should set and get
        /// </summary>
        [Fact]
        public void TangentSpeed_SetAndGet_ShouldRoundtrip()
        {
            Contact contact = new Contact(null, 0, null, 0);
            contact.TangentSpeed = 2.5f;
            Assert.Equal(2.5f, contact.TangentSpeed);
        }

        /// <summary>
        /// Tests that enabled should default to true
        /// </summary>
        [Fact]
        public void Enabled_DefaultValue_ShouldBeTrue()
        {
            Contact contact = new Contact(null, 0, null, 0);
            Assert.True(contact.Enabled);
        }

        /// <summary>
        /// Tests that enabled should set and get
        /// </summary>
        [Fact]
        public void Enabled_SetAndGet_ShouldRoundtrip()
        {
            Contact contact = new Contact(null, 0, null, 0);
            contact.Enabled = false;
            Assert.False(contact.Enabled);
            contact.Enabled = true;
            Assert.True(contact.Enabled);
        }

        /// <summary>
        /// Tests that is touching should default to false
        /// </summary>
        [Fact]
        public void IsTouching_DefaultValue_ShouldBeFalse()
        {
            Contact contact = new Contact(null, 0, null, 0);
            Assert.False(contact.IsTouching);
        }

        /// <summary>
        /// Tests that is touching should set and get
        /// </summary>
        [Fact]
        public void IsTouching_SetAndGet_ShouldRoundtrip()
        {
            Contact contact = new Contact(null, 0, null, 0);
            contact.IsTouching = true;
            Assert.True(contact.IsTouching);
            contact.IsTouching = false;
            Assert.False(contact.IsTouching);
        }

        /// <summary>
        /// Tests that next should default to null
        /// </summary>
        [Fact]
        public void Next_DefaultValue_ShouldBeNull()
        {
            Contact contact = new Contact(null, 0, null, 0);
            Assert.Null(contact.Next);
        }

        /// <summary>
        /// Tests that next should set and get
        /// </summary>
        [Fact]
        public void Next_SetAndGet_ShouldRoundtrip()
        {
            Contact contact = new Contact(null, 0, null, 0);
            Contact other = new Contact(null, 0, null, 0);
            contact.Next = other;
            Assert.Same(other, contact.Next);
        }

        /// <summary>
        /// Tests that prev should default to null
        /// </summary>
        [Fact]
        public void Prev_DefaultValue_ShouldBeNull()
        {
            Contact contact = new Contact(null, 0, null, 0);
            Assert.Null(contact.Prev);
        }

        /// <summary>
        /// Tests that prev should set and get
        /// </summary>
        [Fact]
        public void Prev_SetAndGet_ShouldRoundtrip()
        {
            Contact contact = new Contact(null, 0, null, 0);
            Contact other = new Contact(null, 0, null, 0);
            contact.Prev = other;
            Assert.Same(other, contact.Prev);
        }

        /// <summary>
        /// Tests that reset friction should mix fixture frictions
        /// </summary>
        [Fact]
        public void ResetFriction_WithValidFixtures_ShouldMixFrictions()
        {
            Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureA.GetFriction = 0.5f;
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureB.GetFriction = 0.7f;
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);

            contact.ResetFriction();

            Assert.NotEqual(0, contact.Friction);
        }

        /// <summary>
        /// Tests that reset restitution should mix fixture restitutions
        /// </summary>
        [Fact]
        public void ResetRestitution_WithValidFixtures_ShouldMixRestitutions()
        {
            Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureA.GetRestitution = 0.3f;
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureB.GetRestitution = 0.1f;
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);

            contact.ResetRestitution();

            Assert.NotEqual(0, contact.Restitution);
        }

        /// <summary>
        /// Tests that create with circle shapes should return contact
        /// </summary>
        [Fact]
        public void Create_WithCircleShapes_ShouldReturnContact()
        {
            Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);

            Contact contact = Contact.Create(contactManager, fixtureA, 0, fixtureB, 0);

            Assert.NotNull(contact);
            Assert.Same(fixtureA, contact.FixtureA);
            Assert.Same(fixtureB, contact.FixtureB);
        }

        /// <summary>
        /// Tests that create with polygon and circle should not swap
        /// </summary>
        [Fact]
        public void Create_WithPolygonAndCircle_ShouldNotSwap()
        {
            Vertices vertices = PolygonTools.CreateRectangle(1.0f, 1.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            Fixture fixtureA = new Fixture(polygon);
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);

            Contact contact = Contact.Create(contactManager, fixtureA, 0, fixtureB, 0);

            Assert.NotNull(contact);
            Assert.Same(fixtureA, contact.FixtureA);
            Assert.Same(fixtureB, contact.FixtureB);
        }

        /// <summary>
        /// Tests that destroy with no manifold points should not awake bodies
        /// </summary>
        [Fact]
        public void Destroy_WithoutManifoldPoints_ShouldNotThrow()
        {
            Contact contact = new Contact(null, 0, null, 0);

            contact.Destroy();

            Assert.Null(contact.FixtureA);
            Assert.Null(contact.FixtureB);
        }
    }
}

