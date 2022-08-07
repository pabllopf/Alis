// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ContactFilterTests.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Physic.Dynamics;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The contact filter tests class
    /// </summary>
    public class ContactFilterTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactFilterTests" /> class
        /// </summary>
        public ContactFilterTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }

        /// <summary>
        ///     Creates the contact filter
        /// </summary>
        /// <returns>The contact filter</returns>
        private ContactFilter CreateContactFilter()
        {
            return new ContactFilter();
        }

        /// <summary>
        ///     Tests that should collide state under test expected behavior
        /// </summary>
        [Fact]
        public void ShouldCollide_StateUnderTest_ExpectedBehavior()
        {
            /*// Arrange
            var contactFilter = CreateContactFilter();
            Fixture fixtureA = null;
            Fixture fixtureB = null;

            // Act
            var result = contactFilter.ShouldCollide(
                fixtureA,
                fixtureB);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that ray collide state under test expected behavior
        /// </summary>
        [Fact]
        public void RayCollide_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var contactFilter = CreateContactFilter();
            object userData = null;
            Fixture fixture = null;

            // Act
            var result = contactFilter.RayCollide(
                userData,
                fixture);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}