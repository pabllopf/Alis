// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PairManagerTests.cs
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
    ///     The pair manager tests class
    /// </summary>
    public class PairManagerTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="PairManagerTests" /> class
        /// </summary>
        public PairManagerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }

        /// <summary>
        ///     Creates the manager
        /// </summary>
        /// <returns>The pair manager</returns>
        private PairManager CreateManager()
        {
            return new PairManager();
        }

        /// <summary>
        ///     Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            BroadPhase broadPhase = null;
            PairCallback callback = null;

            // Act
            manager.Initialize(
                broadPhase,
                callback);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that add buffered pair state under test expected behavior
        /// </summary>
        [Fact]
        public void AddBufferedPair_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            int id1 = 0;
            int id2 = 0;

            // Act
            manager.AddBufferedPair(
                id1,
                id2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that remove buffered pair state under test expected behavior
        /// </summary>
        [Fact]
        public void RemoveBufferedPair_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            int id1 = 0;
            int id2 = 0;

            // Act
            manager.RemoveBufferedPair(
                id1,
                id2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that commit state under test expected behavior
        /// </summary>
        [Fact]
        public void Commit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var manager = CreateManager();

            // Act
            //manager.Commit();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that buffered pair sort predicate state under test expected behavior
        /// </summary>
        [Fact]
        public void BufferedPairSortPredicate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            BufferedPair pair1 = default(BufferedPair);
            BufferedPair pair2 = default(BufferedPair);

            // Act
            var result = PairManager.BufferedPairSortPredicate(
                pair1,
                pair2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}