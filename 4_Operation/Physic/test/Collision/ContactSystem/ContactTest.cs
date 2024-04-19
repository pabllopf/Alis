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

using System;
using Alis.Core.Physic.Collision.BroadPhase;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.ContactSystem
{
    /// <summary>
    /// The contact test class
    /// </summary>
    public class ContactTest
    {
        /// <summary>
        /// Tests that test reset
        /// </summary>
        [Fact]
        public void TestReset()
        {
            Shape shape = new CircleShape(1.0f); 
            Filter filter = new Filter(); 
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 1, fixtureB, 2);
            contact.Reset(fixtureA, 1, fixtureB, 2);
            Assert.Equal(fixtureA, contact.FixtureA);
            Assert.Equal(fixtureB, contact.FixtureB);
        }
       /// <summary>
       /// Tests that test update
       /// </summary>
       [Fact]
        public void TestUpdate()
        {
            IBroadPhase broadPhase = new DynamicTreeBroadPhase(); 
            ContactManager contactManager = new ContactManager(broadPhase);
            Shape shape = new CircleShape(1.0f);
            Filter filter = new Filter(); 
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = Contact.Create(fixtureA, 1, fixtureB, 2);
            Assert.Throws<NullReferenceException>(() => contact.Update(contactManager));
        }
       
        /// <summary>
        /// Tests that test destroy
        /// </summary>
        [Fact]
        public void TestDestroy()
        {
            Shape shape = new CircleShape(1.0f); 
            Filter filter = new Filter(); 
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 1, fixtureB, 2);
            Assert.NotNull(contact.FixtureA);
            Assert.NotNull(contact.FixtureB);
        }
        
        /// <summary>
        /// Tests that test clear flags
        /// </summary>
        [Fact]
        public void TestClearFlags()
        {
            Shape shape = new CircleShape(1.0f); 
            Filter filter = new Filter(); 
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 1, fixtureB, 2);
            contact.ClearFlags();
            Assert.False(contact.FilterFlag);
        }
        
        /// <summary>
        /// Tests that test invalidate toi
        /// </summary>
        [Fact]
        public void TestInvalidateToi()
        {
            Shape shape = new CircleShape(1.0f);
            Filter filter = new Filter(); 
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 1, fixtureB, 2);
            contact.InvalidateToi();
            Assert.False(contact.ToiFlag);
            Assert.False(contact.IslandFlag);
            Assert.Equal(0, contact.ToiCount);
            Assert.Equal(1.0f, contact.Toi);
        }
    }
}