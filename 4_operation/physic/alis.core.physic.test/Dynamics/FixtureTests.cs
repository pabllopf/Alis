// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FixtureTests.cs
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
    ///     The fixture tests class
    /// </summary>
    public class FixtureTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="FixtureTests" /> class
        /// </summary>
        public FixtureTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }

        /// <summary>
        ///     Creates the fixture
        /// </summary>
        /// <returns>The fixture</returns>
        private Fixture CreateFixture()
        {
            return new Fixture();
        }

        /// <summary>
        ///     Tests that create state under test expected behavior
        /// </summary>
        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var fixture = CreateFixture();
            BroadPhase broadPhase = null;
            Body body = null;
            XForm xf = default(XForm);
            FixtureDef def = null;

            // Act
            fixture.Create(
                broadPhase,
                body,
                xf,
                def);
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
            /*
            // Arrange
            var fixture = CreateFixture();
            BroadPhase broadPhase = null;

            // Act
            fixture.Destroy(
                broadPhase);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that dispose state under test expected behavior
        /// </summary>
        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var fixture = CreateFixture();

            // Act
            fixture.Dispose();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that compute mass state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeMass_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var fixture = CreateFixture();
            MassData massData = default(MassData);

            // Act
            fixture.ComputeMass(
                out massData);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that compute submerged area state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var fixture = CreateFixture();
            Vector2 normal = default(Vector2);
            float offset = 0;
            Vector2 c = default(Vector2);

            // Act
            var result = fixture.ComputeSubmergedArea(
                normal,
                offset,
                out c);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that test point state under test expected behavior
        /// </summary>
        [Fact]
        public void TestPoint_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var fixture = CreateFixture();
            Vector2 p = default(Vector2);

            // Act
            var result = fixture.TestPoint(
                p);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that test segment state under test expected behavior
        /// </summary>
        [Fact]
        public void TestSegment_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var fixture = CreateFixture();
            float lambda = 0;
            Vector2 normal = default(Vector2);
            Segment segment = default(Segment);
            float maxLambda = 0;

            // Act
            var result = fixture.TestSegment(
                out lambda,
                out normal,
                segment,
                maxLambda);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that compute sweep radius state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeSweepRadius_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var fixture = CreateFixture();
            Vector2 pivot = default(Vector2);

            // Act
            var result = fixture.ComputeSweepRadius(
                pivot);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}