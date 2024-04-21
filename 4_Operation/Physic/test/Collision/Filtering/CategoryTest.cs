// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CategoryTest.cs
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
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Filtering
{
    /// <summary>
    ///     The category test class
    /// </summary>
    public class CategoryTest
    {
        /// <summary>
        ///     Tests that destroy should enqueue contact
        /// </summary>
        [Fact]
        public void Destroy_ShouldEnqueueContact()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = Contact.Create(fixtureA, 0, fixtureB, 0);
            
            // Act
            contact.Destroy();
            
            // Assert
            Assert.Contains(contact, ContactManager.Current.ContactPool);
        }
        
        /// <summary>
        ///     Tests that clear flags should clear flags
        /// </summary>
        [Fact]
        public void ClearFlags_ShouldClearFlags()
        {
            // Arrange
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = Contact.Create(fixtureA, 0, fixtureB, 0);
            contact.Flags = ContactSetting.FilterFlag;
            
            // Act
            contact.ClearFlags();
            
            // Assert
            Assert.True(contact.Flags == 0);
        }
        
        /// <summary>
        ///     Tests that invalidate toi should reset toi values
        /// </summary>
        [Fact]
        public void InvalidateToi_ShouldResetToiValues()
        {
            // Arrange
            Fixture fixtureA = new Fixture(new CircleShape(1), new Filter());
            Fixture fixtureB = new Fixture(new CircleShape(1), new Filter());
            Contact contact = Contact.Create(fixtureA, 0, fixtureB, 0);
            contact.Flags = ContactSetting.ToiFlag | ContactSetting.IslandFlag;
            contact.ToiCount = 5;
            contact.Toi = 0.5f;
            
            // Act
            contact.InvalidateToi();
            
            // Assert
            Assert.Equal(0, contact.ToiCount);
            Assert.Equal(1.0f, contact.Toi);
        }
    }
}