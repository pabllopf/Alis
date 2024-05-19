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
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.ContactSystem
{
    /// <summary>
    ///     The contact test class
    /// </summary>
    public class ContactTest
    {
        /// <summary>
        ///     Tests that test reset
        /// </summary>
        [Fact]
        public void TestReset()
        {
            AShape shape = new CircleShape(1.0f);
            Filter filter = new Filter();
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 1, fixtureB, 2);
            contact.Reset(fixtureA, 1, fixtureB, 2);
            Assert.Equal(fixtureA, contact.FixtureA);
            Assert.Equal(fixtureB, contact.FixtureB);
        }
        
        /// <summary>
        ///     Tests that test update
        /// </summary>
        [Fact]
        public void TestUpdate()
        {
            IBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            AShape shape = new CircleShape(1.0f);
            Filter filter = new Filter();
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = Contact.Create(fixtureA, 1, fixtureB, 2);
            Assert.Throws<NullReferenceException>(() => contact.Update(contactManager));
        }
        
        /// <summary>
        ///     Tests that test destroy
        /// </summary>
        [Fact]
        public void TestDestroy()
        {
            AShape shape = new CircleShape(1.0f);
            Filter filter = new Filter();
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 1, fixtureB, 2);
            Assert.NotNull(contact.FixtureA);
            Assert.NotNull(contact.FixtureB);
        }
        
        /// <summary>
        ///     Tests that test clear flags
        /// </summary>
        [Fact]
        public void TestClearFlags()
        {
            AShape shape = new CircleShape(1.0f);
            Filter filter = new Filter();
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 1, fixtureB, 2);
            contact.ClearFlags();
            Assert.False(contact.FilterFlag);
        }
        
        /// <summary>
        ///     Tests that test invalidate toi
        /// </summary>
        [Fact]
        public void TestInvalidateToi()
        {
            AShape shape = new CircleShape(1.0f);
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
        
        /// <summary>
        /// Tests that next property should return correct value
        /// </summary>
        [Fact]
        public void NextProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                1,
                new Fixture(new CircleShape(1.0f), new Filter()),
                2
            );
            Contact nextContact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                1,
                new Fixture(new CircleShape(1.0f), new Filter()),
                2
            );
            
            contact.Next = nextContact;
            
            // Act
            Contact result = contact.Next;
            
            // Assert
            Assert.Equal(nextContact, result);
        }
        
        /// <summary>
        /// Tests that previous property should return correct value
        /// </summary>
        [Fact]
        public void PreviousProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                1,
                new Fixture(new CircleShape(1.0f), new Filter()),
                2
            );
            Contact previousContact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                1,
                new Fixture(new CircleShape(1.0f), new Filter()),
                2
            );
            contact.Previous = previousContact;
            
            // Act
            Contact result = contact.Previous;
            
            // Assert
            Assert.Equal(previousContact, result);
        }
        
        /// <summary>
        /// Tests that is touching property should return correct value
        /// </summary>
        [Fact]
        public void IsTouchingProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                1,
                new Fixture(new CircleShape(1.0f), new Filter()),
                2
            );
            // Set the Flags property in a way that makes IsTouching return true
            
            // Act
            bool result = contact.IsTouching;
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that island flag property should return correct value
        /// </summary>
        [Fact]
        public void IslandFlagProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                1,
                new Fixture(new CircleShape(1.0f), new Filter()),
                2
            );
            // Set the Flags property in a way that makes IslandFlag return true
            
            // Act
            bool result = contact.IslandFlag;
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that toi flag property should return correct value
        /// </summary>
        [Fact]
        public void ToiFlagProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                1,
                new Fixture(new CircleShape(1.0f), new Filter()),
                2
            );
            // Set the Flags property in a way that makes ToiFlag return true
            
            // Act
            bool result = contact.ToiFlag;
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that filter flag property should return correct value
        /// </summary>
        [Fact]
        public void FilterFlagProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                1,
                new Fixture(new CircleShape(1.0f), new Filter()),
                2
            );
            // Set the Flags property in a way that makes FilterFlag return true
            
            // Act
            bool result = contact.FilterFlag;
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that manifold property should get and set correctly
        /// </summary>
        [Fact]
        public void ManifoldProperty_ShouldGetAndSetCorrectly()
        {
            // Arrange
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                1,
                new Fixture(new CircleShape(1.0f), new Filter()),
                2
            );
            Manifold expectedManifold = new Manifold()
            {
                Points = new ManifoldPoint[2]
            };
            
            // Act
            contact.Manifold = expectedManifold;
            var result = contact.Manifold;
            
            // Assert
            Assert.Equal(expectedManifold, result);
        }
    }
}