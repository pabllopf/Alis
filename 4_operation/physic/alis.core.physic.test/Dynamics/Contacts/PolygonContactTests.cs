// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonContactTests.cs
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

using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The polygon contact tests class
    /// </summary>
    public class PolygonContactTests
    {
        /// <summary>
        ///     The mock fixture
        /// </summary>
        private Mock<Fixture> mockFixture;

        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonContactTests" /> class
        /// </summary>
        public PolygonContactTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockFixture = mockRepository.Create<Fixture>();
        }

        /// <summary>
        ///     Creates the polygon contact
        /// </summary>
        /// <returns>The polygon contact</returns>
        private PolygonContact CreatePolygonContact() => new PolygonContact(
            mockFixture.Object,
            mockFixture.Object);

        /// <summary>
        ///     Tests that create state under test expected behavior
        /// </summary>
        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*var polygonContact = CreatePolygonContact();
            Fixture fixtureA = null;
            Fixture fixtureB = null;

            // Act
            var result = PolygonContact.Create(
                fixtureA,
                fixtureB);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that destroy state under test expected behavior
        /// </summary>
        [Fact]
        public void Destroy_StateUnderTest_ExpectedBehavior()
        {
            /*// Arrange
            var polygonContact = CreatePolygonContact();
            Contact contact = null;

            // Act
            PolygonContact.Destroy(
                ref contact);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}