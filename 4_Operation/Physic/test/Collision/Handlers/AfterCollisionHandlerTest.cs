// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AfterCollisionHandlerTest.cs
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

using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Handlers;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Solver;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Handlers
{
    /// <summary>
    ///     The after collision handler test class
    /// </summary>
    public class AfterCollisionHandlerTest
    {
        /// <summary>
        ///     Tests that after collision handler invocation test
        /// </summary>
        [Fact]
        public void AfterCollisionHandlerInvocationTest()
        {
            // Arrange
            bool isHandlerInvoked = false;
            AfterCollisionHandler handler = (fixtureA, fixtureB, contact, impulse) => { isHandlerInvoked = true; };
            
            Fixture fixtureA = new Fixture(new CircleShape(1, 1), new Filter(), 0.3f, 0.1f, 1.5f, true);
            Fixture fixtureB = new Fixture(new CircleShape(1, 1), new Filter(), 0.3f, 0.1f, 1.5f, true);
            Contact contact = new Contact(fixtureA, 1, fixtureB, 1);
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            
            // Act
            handler.Invoke(fixtureA, fixtureB, contact, impulse);
            
            // Assert
            Assert.True(isHandlerInvoked);
        }
        
        /// <summary>
        ///     Tests that after collision handler parameters test
        /// </summary>
        [Fact]
        public void AfterCollisionHandlerParametersTest()
        {
            // Arrange
            Fixture expectedFixtureA = new Fixture(new CircleShape(1, 1), new Filter(), 0.3f, 0.1f, 1.5f, true);
            Fixture expectedFixtureB = new Fixture(new CircleShape(1, 1), new Filter(), 0.3f, 0.1f, 1.5f, true);
            Contact expectedContact = new Contact(expectedFixtureA, 1, expectedFixtureB, 1);
            ContactVelocityConstraint expectedImpulse = new ContactVelocityConstraint();
            
            AfterCollisionHandler handler = (fixtureA, fixtureB, contact, impulse) =>
            {
                // Assert
                Assert.Equal(expectedFixtureA, fixtureA);
                Assert.Equal(expectedFixtureB, fixtureB);
                Assert.Equal(expectedContact, contact);
                Assert.Equal(expectedImpulse, impulse);
            };
            
            // Act
            handler.Invoke(expectedFixtureA, expectedFixtureB, expectedContact, expectedImpulse);
        }
    }
}