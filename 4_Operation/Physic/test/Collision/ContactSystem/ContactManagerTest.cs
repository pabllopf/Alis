// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactManagerTest.cs
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
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Collision.TOI;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.ContactSystem
{
    /// <summary>
    ///     The contact manager test class
    /// </summary>
    public class ContactManagerTest
    {
        /// <summary>
        ///     Tests that test contact reset
        /// </summary>
        [Fact]
        public void TestContactReset()
        {
            // Arrange
            CircleShape shape = new CircleShape(1.0f);
            Filter filter = new Filter();
            
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            // Act
            contact.Reset(fixtureA, 1, fixtureB, 1);
            
            // Assert
            Assert.Equal(1, contact.ChildIndexA);
            Assert.Equal(1, contact.ChildIndexB);
        }
        
        /// <summary>
        /// Tests that add pair should add pair correctly
        /// </summary>
        [Fact]
        public void AddPair_ShouldAddPairCorrectly()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            FixtureProxy proxyA = new FixtureProxy();
            FixtureProxy proxyB = new FixtureProxy();
            
            // Act
            contactManager.AddPair(ref proxyA, ref proxyB);
            
            // Assert
            // Here you would assert that the properties of contactManager have been set correctly.
        }
        
        /// <summary>
        /// Tests that remove should remove contact correctly
        /// </summary>
        [Fact]
        public void Remove_ShouldRemoveContactCorrectly()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                0,
                new Fixture(new CircleShape(1.0f), new Filter()),
                0
            );
            
            // Act
            Assert.Throws<NullReferenceException>(() => contactManager.Remove(contact));
            
            // Assert
            // Here you would assert that the properties of contactManager have been set correctly.
        }
        
        /// <summary>
        /// Tests that find new contacts should find new contacts correctly
        /// </summary>
        [Fact]
        public void FindNewContacts_ShouldFindNewContactsCorrectly()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            
            // Act
            contactManager.FindNewContacts();
            
            // Assert
            // Here you would assert that the properties of contactManager have been set correctly.
        }
        
        /// <summary>
        /// Tests that collide should collide correctly
        /// </summary>
        [Fact]
        public void Collide_ShouldCollideCorrectly()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            
            // Act
            contactManager.Collide();
            
            // Assert
            // Here you would assert that the properties of contactManager have been set correctly.
        }
        
        /// <summary>
        /// Tests that get the min contact should return correct contact
        /// </summary>
        [Fact]
        public void GetTheMinContact_ShouldReturnCorrectContact()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            float minAlpha = 0.5f;
            
            // Act
            Contact result = contactManager.GetTheMinContact(minAlpha);
            
            // Assert
            // Here you would assert that the properties of contactManager have been set correctly.
        }
        
        /// <summary>
        /// Tests that clear flags should clear flags correctly
        /// </summary>
        [Fact]
        public void ClearFlags_ShouldClearFlagsCorrectly()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            
            // Act
            contactManager.ClearFlags();
            
            // Assert
            // Here you would assert that the properties of contactManager have been set correctly.
        }
        
        /// <summary>
        /// Tests that invalidate toi should invalidate toi correctly
        /// </summary>
        [Fact]
        public void InvalidateToi_ShouldInvalidateToiCorrectly()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            
            // Act
            contactManager.InvalidateToi();
            
            // Assert
            // Here you would assert that the properties of contactManager have been set correctly.
        }
        
        /// <summary>
        /// Tests that calculate min alpha should return correct alpha
        /// </summary>
        [Fact]
        public void CalculateMinAlpha_ShouldReturnCorrectAlpha()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            
            // Act
            float result = contactManager.CalculateMinAlpha();
            
            // Assert
            // Here you would assert that the properties of contactManager have been set correctly.
        }
        
        /// <summary>
        /// Tests that is active contact should return correct value
        /// </summary>
        [Fact]
        public void IsActiveContact_ShouldReturnCorrectValue()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                0,
                new Fixture(new CircleShape(1.0f), new Filter()),
                0
            );
            
            // Act
            Assert.Throws<NullReferenceException>(() => contactManager.IsActiveContact(contact));
        }
        
        /// <summary>
        /// Tests that is collidable contact should return correct value
        /// </summary>
        [Fact]
        public void IsCollidableContact_ShouldReturnCorrectValue()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                0,
                new Fixture(new CircleShape(1.0f), new Filter()),
                0
            );
            
            // Act
            Assert.Throws<NullReferenceException>(() => contactManager.IsCollidableContact(contact));
        }
        
        /// <summary>
        /// Tests that adjust sweeps should not throw exception
        /// </summary>
        [Fact]
        public void AdjustSweeps_ShouldNotThrowException()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                0,
                new Fixture(new CircleShape(1.0f), new Filter()),
                0
            );
            
            // Act
            Action act = () => contactManager.AdjustSweeps(contact);
        }
        
        /// <summary>
        /// Tests that compute time of impact should return correct output
        /// </summary>
        [Fact]
        public void ComputeTimeOfImpact_ShouldReturnCorrectOutput()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                0,
                new Fixture(new CircleShape(1.0f), new Filter()),
                0
            );
            
            // Act
            Assert.Throws<NullReferenceException>(() => contactManager.ComputeTimeOfImpact(contact));
        }
        
        /// <summary>
        /// Tests that update contact toi should not throw exception
        /// </summary>
        [Fact]
        public void UpdateContactToi_ShouldNotThrowException()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                0,
                new Fixture(new CircleShape(1.0f), new Filter()),
                0
            );
            ToiOutput output = new ToiOutput();
            
            // Act
            Action act = () => contactManager.UpdateContactToi(contact, output);
        }
        
        /// <summary>
        /// Tests that should collide should return correct value
        /// </summary>
        [Fact]
        public void ShouldCollide_ShouldReturnCorrectValue()
        {
            // Arrange
            Fixture fixtureA = new Fixture(
                new CircleShape(1.0f),
                new Filter()
            );
            Fixture fixtureB = new Fixture(
                new CircleShape(1.0f),
                new Filter()
            );
            
            // Act
            bool result = ContactManager.ShouldCollide(fixtureA, fixtureB);
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that update contact toi should update correctly
        /// </summary>
        [Fact]
        public void UpdateContactToi_ShouldUpdateCorrectly()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            Contact contact = new Contact(
                new Fixture(new CircleShape(1.0f), new Filter()),
                0,
                new Fixture(new CircleShape(1.0f), new Filter()),
                0
            );
            ToiOutput output = new ToiOutput
            {
                Property = 0.5f,
                State = ToiOutputState.Touching
            };
            
            // Act
            Assert.Throws<NullReferenceException>(() => contactManager.UpdateContactToi(contact, output));
        }
        
        /// <summary>
        /// Tests that contact filter property should return correct value
        /// </summary>
        [Fact]
        public void ContactFilterProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());

            // Act
            var result = contactManager.ContactFilter;
        }
    }
}