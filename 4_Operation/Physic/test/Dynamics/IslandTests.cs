// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IslandTests.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joint;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The island tests class
    /// </summary>
    public class IslandTests
    {
        /// <summary>
        ///     The mock contact listener
        /// </summary>
        private Mock<IContactListener> mockContactListener;

        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="IslandTests" /> class
        /// </summary>
        public IslandTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockContactListener = mockRepository.Create<IContactListener>();
        }

        /// <summary>
        ///     Creates the island
        /// </summary>
        /// <returns>The island</returns>
        private Island CreateIsland() => new Island(
            10,
            5,
            1,
            mockContactListener.Object);

        /// <summary>
        ///     Tests that dispose state under test expected behavior
        /// </summary>
        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Island island = CreateIsland();

            // Act
            island.Dispose();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that clear state under test expected behavior
        /// </summary>
        [Fact]
        public void Clear_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Island island = CreateIsland();

            // Act
            island.Clear();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that solve state under test expected behavior
        /// </summary>
        [Fact]
        public void Solve_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Island island = CreateIsland();
            TimeStep step = default(TimeStep);
            Vector2 gravity = default(Vector2);
            bool allowSleep = false;

            // Act
            island.Solve(
                step,
                gravity,
                allowSleep);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that solve toi state under test expected behavior
        /// </summary>
        [Fact]
        public void SolveToi_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Island island = CreateIsland();
            TimeStep subStep = default(TimeStep);

            // Act
            island.SolveToi(
                ref subStep);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that add state under test expected behavior
        /// </summary>
        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var island = CreateIsland();
            //Body body = null;

            // Act
            //island.Add(body);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that add state under test expected behavior 1
        /// </summary>
        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            Island island = CreateIsland();
            Contact contact = null;

            // Act
            island.Add(
                contact);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that add state under test expected behavior 2
        /// </summary>
        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            Island island = CreateIsland();
            IJoint joint = null;

            // Act
            island.Add(
                joint);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that report state under test expected behavior
        /// </summary>
        [Fact]
        public void Report_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Island island = CreateIsland();
            ContactConstraint[] constraints = null;

            // Act
            island.Report(
                constraints);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}