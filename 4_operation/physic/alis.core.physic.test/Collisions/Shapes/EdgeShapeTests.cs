// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EdgeShapeTests.cs
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

using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The edge shape tests class
    /// </summary>
    public class EdgeShapeTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="EdgeShapeTests" /> class
        /// </summary>
        public EdgeShapeTests() => mockRepository = new MockRepository(MockBehavior.Strict);

        /// <summary>
        ///     Creates the edge shape
        /// </summary>
        /// <returns>The edge shape</returns>
        private EdgeShape CreateEdgeShape() => new EdgeShape();

        /// <summary>
        ///     Tests that dispose state under test expected behavior
        /// </summary>
        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();

            // Act
            edgeShape.Dispose();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set state under test expected behavior
        /// </summary>
        [Fact]
        public void Set_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            Vector2 v1 = default(Vector2);
            Vector2 v2 = default(Vector2);

            // Act
            edgeShape.Set(
                v1,
                v2);

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
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            XForm transform = default(XForm);
            Vector2 p = default(Vector2);

            // Act
            bool result = edgeShape.TestPoint(
                transform,
                p);

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
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            XForm transform = default(XForm);
            float lambda = 0;
            Vector2 normal = default(Vector2);
            Segment segment = default(Segment);
            float maxLambda = 0;

            // Act
            SegmentCollide result = edgeShape.TestSegment(
                transform,
                out lambda,
                out normal,
                segment,
                maxLambda);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that compute aabb state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeAabb_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            Aabb aabb = default(Aabb);
            XForm transform = default(XForm);

            // Act
            edgeShape.ComputeAabb(
                out aabb,
                transform);

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
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            MassData massData = default(MassData);
            float density = 0;

            // Act
            edgeShape.ComputeMass(
                out massData,
                density);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set prev edge state under test expected behavior
        /// </summary>
        [Fact]
        public void SetPrevEdge_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            EdgeShape edge = null;
            Vector2 cornerDir = default(Vector2);
            bool convex = false;

            // Act
            edgeShape.SetPrevEdge(
                edge,
                cornerDir,
                convex);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set next edge state under test expected behavior
        /// </summary>
        [Fact]
        public void SetNextEdge_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            EdgeShape edge = null;
            Vector2 cornerDir = default(Vector2);
            bool convex = false;

            // Act
            edgeShape.SetNextEdge(
                edge,
                cornerDir,
                convex);

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
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            Vector2 normal = default(Vector2);
            float offset = 0;
            XForm xf = default(XForm);
            Vector2 c = default(Vector2);

            // Act
            float result = edgeShape.ComputeSubmergedArea(
                normal,
                offset,
                xf,
                out c);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get support state under test expected behavior
        /// </summary>
        [Fact]
        public void GetSupport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            Vector2 d = default(Vector2);

            // Act
            int result = edgeShape.GetSupport(
                d);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get support vertex state under test expected behavior
        /// </summary>
        [Fact]
        public void GetSupportVertex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            Vector2 d = default(Vector2);

            // Act
            Vector2 result = edgeShape.GetSupportVertex(
                d);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get vertex state under test expected behavior
        /// </summary>
        [Fact]
        public void GetVertex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            int index = 0;

            // Act
            Vector2 result = edgeShape.GetVertex(
                index);

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
            // Arrange
            EdgeShape edgeShape = CreateEdgeShape();
            Vector2 pivot = default(Vector2);

            // Act
            float result = edgeShape.ComputeSweepRadius(
                pivot);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}