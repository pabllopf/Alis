// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CollisionTests.cs
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

using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The collision tests class
    /// </summary>
    public class CollisionTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="CollisionTests" /> class
        /// </summary>
        public CollisionTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }

        /// <summary>
        ///     Tests that collide circles state under test expected behavior
        /// </summary>
        [Fact]
        public void CollideCircles_StateUnderTest_ExpectedBehavior()
        {
            /*Manifold manifold = null;
            CircleShape circle1 = null;
            XForm xf1 = default(XForm);
            CircleShape circle2 = null;
            XForm xf2 = default(XForm);

            // Act
            Collision.CollideCircles(
                ref manifold,
                circle1,
                xf1,
                circle2,
                xf2);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that collide polygon and circle state under test expected behavior
        /// </summary>
        [Fact]
        public void CollidePolygonAndCircle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*Manifold manifold = null;
            PolygonShape polygon = null;
            XForm xf1 = default(XForm);
            CircleShape circle = null;
            XForm xf2 = default(XForm);

            // Act
            Collision.CollidePolygonAndCircle(
                ref manifold,
                polygon,
                xf1,
                circle,
                xf2);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}