// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EpAxisTest.cs
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
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    /// The ep axis test class
    /// </summary>
    public class EpAxisTest
    {
        /// <summary>
        /// Tests that test normal property
        /// </summary>
        [Fact]
        public void Test_NormalProperty()
        {
            // Arrange
            EpAxis epAxis = new EpAxis();
            Vector2 expectedValue = new Vector2(1, 1);
            
            // Act
            epAxis.Normal = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, epAxis.Normal);
        }
        
        /// <summary>
        /// Tests that test index property
        /// </summary>
        [Fact]
        public void Test_IndexProperty()
        {
            // Arrange
            EpAxis epAxis = new EpAxis();
            int expectedValue = 5;
            
            // Act
            epAxis.Index = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, epAxis.Index);
        }
        
        /// <summary>
        /// Tests that test separation property
        /// </summary>
        [Fact]
        public void Test_SeparationProperty()
        {
            // Arrange
            EpAxis epAxis = new EpAxis();
            float expectedValue = 1.5f;
            
            // Act
            epAxis.Separation = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, epAxis.Separation);
        }
        
        /// <summary>
        /// Tests that test type property
        /// </summary>
        [Fact]
        public void Test_TypeProperty()
        {
            // Arrange
            EpAxis epAxis = new EpAxis();
            EpAxisType expectedValue = EpAxisType.EdgeA; // Assuming EpAxisType is an enum and FaceA is one of its values
            
            // Act
            epAxis.Type = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, epAxis.Type);
        }
        
        /// <summary>
        /// Tests that test contact constructor
        /// </summary>
        [Fact]
        public void Test_Contact_Constructor()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            Assert.NotNull(contact);
            Assert.Equal(fixtureA, contact.FixtureA);
            Assert.Equal(fixtureB, contact.FixtureB);
        }
        
        /// <summary>
        /// Tests that test contact reset
        /// </summary>
        [Fact]
        public void Test_Contact_Reset()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            Fixture fixtureC = new Fixture(new CircleShape(2), new Filter());
            Fixture fixtureD = new Fixture(new CircleShape(2), new Filter());
            contact.Reset(fixtureC, 1, fixtureD, 1);
            
            Assert.Equal(fixtureC, contact.FixtureA);
            Assert.Equal(fixtureD, contact.FixtureB);
        }
        
        /// <summary>
        /// Tests that test contact reset restitution
        /// </summary>
        [Fact]
        public void Test_Contact_ResetRestitution()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            fixtureA.Restitution = 0.5f;
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            fixtureB.Restitution = 0.5f;
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            contact.ResetRestitution();
            
            Assert.Equal(Settings.MixRestitution(fixtureA.Restitution, fixtureB.Restitution), contact.Restitution);
        }
        
        /// <summary>
        /// Tests that test contact reset restitution threshold
        /// </summary>
        [Fact]
        public void Test_Contact_ResetRestitutionThreshold()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            contact.ResetRestitutionThreshold();
            
            Assert.Equal(0, contact.RestitutionThreshold);
        }
        
        /// <summary>
        /// Tests that test contact reset friction
        /// </summary>
        [Fact]
        public void Test_Contact_ResetFriction()
        {
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            fixtureA.Friction = 0.5f;
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            fixtureB.Friction = 0.5f;
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            contact.ResetFriction();
            
            Assert.Equal(Settings.MixFriction(fixtureA.Friction, fixtureB.Friction), contact.Friction);
        }
        
        /// <summary>
        /// Tests that test fixture constructor
        /// </summary>
        [Fact]
        public void Test_Fixture_Constructor()
        {
            CircleShape shape = new CircleShape(1);
            Filter filter = new Filter();
            Fixture fixture = new Fixture(shape, filter);
            
            Assert.NotNull(fixture);
            Assert.Equal(shape.RadiusPrivate, fixture.Shape.RadiusPrivate);
            Assert.Equal(filter.Category, fixture.Filter.Category);
        }
    }
}