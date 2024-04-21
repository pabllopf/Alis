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

using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
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
    }
}