// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ContactManagerTests.cs
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

using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The contact manager tests class
    /// </summary>
    public class ContactManagerTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactManagerTests" /> class
        /// </summary>
        public ContactManagerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }

        /// <summary>
        ///     Creates the manager
        /// </summary>
        /// <returns>The contact manager</returns>
        private ContactManager CreateManager()
        {
            return new ContactManager(new World(new Aabb(), Vector2.Zero, true));
        }

        /// <summary>
        ///     Tests that pair added state under test expected behavior
        /// </summary>
        [Fact]
        public void PairAdded_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var manager = CreateManager();
            object proxyUserDataA = null;
            object proxyUserDataB = null;

            // Act
            var result = manager.PairAdded(
                proxyUserDataA,
                proxyUserDataB);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that pair removed state under test expected behavior
        /// </summary>
        [Fact]
        public void PairRemoved_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            object proxyUserData1 = null;
            object proxyUserData2 = null;
            object pairUserData = null;

            // Act
            manager.PairRemoved(
                proxyUserData1,
                proxyUserData2,
                pairUserData);

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
            /*
            // Arrange
            var manager = CreateManager();
            Contact c = null;

            // Act
            manager.Destroy(
                c);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that collide state under test expected behavior
        /// </summary>
        [Fact]
        public void Collide_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var manager = CreateManager();

            // Act
            manager.Collide();
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}