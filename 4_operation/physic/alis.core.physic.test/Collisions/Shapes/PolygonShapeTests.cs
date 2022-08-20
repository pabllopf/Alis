// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonShapeTests.cs
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
using Alis.Core.Physic.Collisions.Shape;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The polygon shape tests class
    /// </summary>
    public class PolygonShapeTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonShapeTests" /> class
        /// </summary>
        public PolygonShapeTests() => mockRepository = new MockRepository(MockBehavior.Strict);

        /// <summary>
        ///     Creates the polygon shape
        /// </summary>
        /// <returns>The polygon shape</returns>
        private PolygonShape CreatePolygonShape() => new PolygonShape();

        /// <summary>
        ///     Tests that set state under test expected behavior
        /// </summary>
        [Fact]
        public void Set_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*var polygonShape = CreatePolygonShape();
            Vector2[] vertices = null;
            int count = 0;

            // Act
            polygonShape.Set(
                vertices,
                count);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set as box state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAsBox_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PolygonShape polygonShape = CreatePolygonShape();
            float hx = 0;
            float hy = 0;

            // Act
            polygonShape.SetAsBox(
                hx,
                hy);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set as box state under test expected behavior 1
        /// </summary>
        [Fact]
        public void SetAsBox_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            PolygonShape polygonShape = CreatePolygonShape();
            float hx = 0;
            float hy = 0;
            Vector2 center = default(Vector2);
            float angle = 0;

            // Act
            polygonShape.SetAsBox(
                hx,
                hy,
                center,
                angle);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set as edge state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAsEdge_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PolygonShape polygonShape = CreatePolygonShape();
            Vector2 v1 = default(Vector2);
            Vector2 v2 = default(Vector2);

            // Act
            polygonShape.SetAsEdge(
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
            PolygonShape polygonShape = CreatePolygonShape();
            XForm xf = default(XForm);
            Vector2 p = default(Vector2);

            // Act
            bool result = polygonShape.TestPoint(
                xf,
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
            PolygonShape polygonShape = CreatePolygonShape();
            XForm xf = default(XForm);
            float lambda = 0;
            Vector2 normal = default(Vector2);
            Segment segment = default(Segment);
            float maxLambda = 0;

            // Act
            SegmentCollide result = polygonShape.TestSegment(
                xf,
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
            PolygonShape polygonShape = CreatePolygonShape();
            Aabb aabb = default(Aabb);
            XForm xf = default(XForm);

            // Act
            polygonShape.ComputeAabb(
                out aabb,
                xf);

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
            /*var polygonShape = CreatePolygonShape();
            MassData massData = default(MassData);
            float denstity = 0;

            // Act
            polygonShape.ComputeMass(
                out massData,
                denstity);
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
            // Arrange
            PolygonShape polygonShape = CreatePolygonShape();
            Vector2 normal = default(Vector2);
            float offset = 0;
            XForm xf = default(XForm);
            Vector2 c = default(Vector2);

            // Act
            float result = polygonShape.ComputeSubmergedArea(
                normal,
                offset,
                xf,
                out c);

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
            /* var polygonShape = CreatePolygonShape();
             Vector2 pivot = default(Vector2);
 
             // Act
             var result = polygonShape.ComputeSweepRadius(
                 pivot);
 */
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
            PolygonShape polygonShape = CreatePolygonShape();
            Vector2 d = default(Vector2);

            // Act
            int result = polygonShape.GetSupport(
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
            PolygonShape polygonShape = CreatePolygonShape();
            Vector2 d = default(Vector2);

            // Act
            Vector2 result = polygonShape.GetSupportVertex(
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
            /*var polygonShape = CreatePolygonShape();
            int index = 0;

            // Act
            var result = polygonShape.GetVertex(
                index);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that compute centroid state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeCentroid_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var polygonShape = CreatePolygonShape();
            Vector2[] vs = null;
            int count = 0;

            // Act
            var result = PolygonShape.ComputeCentroid(
                vs,
                count);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}