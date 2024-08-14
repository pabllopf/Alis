// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactEdgeTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.ContactSystem
{
    /// <summary>
    ///     The contact edge test class
    /// </summary>
    public class ContactEdgeTest
    {
        /// <summary>
        ///     Tests that test contact property
        /// </summary>
        [Fact]
        public void TestContactProperty()
        {
            // Arrange
            ContactEdge contactEdge = new ContactEdge();
            
            // Create necessary objects for Contact constructor
            AShape shape = new CircleShape(1); // Or any other shape
            Filter filter = new Filter();
            
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            // Act
            contactEdge.Contact = contact;
            
            // Assert
            Assert.Equal(contact, contactEdge.Contact);
        }
        
        /// <summary>
        ///     Tests that test next property
        /// </summary>
        [Fact]
        public void TestNextProperty()
        {
            // Arrange
            ContactEdge contactEdge = new ContactEdge();
            ContactEdge nextContactEdge = new ContactEdge();
            
            // Act
            contactEdge.Next = nextContactEdge;
            
            // Assert
            Assert.Equal(nextContactEdge, contactEdge.Next);
        }
        
        /// <summary>
        ///     Tests that test other property
        /// </summary>
        [Fact]
        public void TestOtherProperty()
        {
            // Arrange
            ContactEdge contactEdge = new ContactEdge();
            Vector2 position = new Vector2(0, 0);
            Vector2 linearVelocity = new Vector2(0, 0);
            Body otherBody = new Body(
                position,
                linearVelocity
            );
            
            // Act
            contactEdge.Other = otherBody;
            
            // Assert
            Assert.Equal(otherBody, contactEdge.Other);
        }
        
        /// <summary>
        ///     Tests that test prev property
        /// </summary>
        [Fact]
        public void TestPrevProperty()
        {
            // Arrange
            ContactEdge contactEdge = new ContactEdge();
            ContactEdge prevContactEdge = new ContactEdge();
            
            // Act
            contactEdge.Prev = prevContactEdge;
            
            // Assert
            Assert.Equal(prevContactEdge, contactEdge.Prev);
        }
    }
}