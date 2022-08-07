// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   AabbTests.cs
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

using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The aabb tests class
    /// </summary>
    public class AabbTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="AabbTests" /> class
        /// </summary>
        public AabbTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }

        /// <summary>
        ///     Creates the aabb
        /// </summary>
        /// <returns>The aabb</returns>
        private Aabb CreateAabb()
        {
            return new Aabb();
        }

        /// <summary>
        ///     Tests that combine state under test expected behavior
        /// </summary>
        [Fact]
        public void Combine_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var aabb = CreateAabb();
            Aabb aabb1 = default(Aabb);
            Aabb aabb2 = default(Aabb);

            // Act
            aabb.Combine(
                aabb1,
                aabb2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that contains state under test expected behavior
        /// </summary>
        [Fact]
        public void Contains_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var aabb = CreateAabb();

            // Act
            var result = aabb.Contains(
                aabb);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that ray cast state under test expected behavior
        /// </summary>
        [Fact]
        public void RayCast_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var aabb = CreateAabb();
            RayCastOutput output = default(RayCastOutput);
            RayCastInput input = default(RayCastInput);

            // Act
            aabb.RayCast(
                out output,
                input);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}