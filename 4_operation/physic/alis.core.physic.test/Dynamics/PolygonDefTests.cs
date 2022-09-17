// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonDefTests.cs
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
using Alis.Core.Physic.Dynamics.Fixtures;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The polygon def tests class
    /// </summary>
    public class PolygonDefTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonDefTests" /> class
        /// </summary>
        public PolygonDefTests() => mockRepository = new MockRepository(MockBehavior.Strict);

        /// <summary>
        ///     Creates the polygon def
        /// </summary>
        /// <returns>The polygon def</returns>
        private PolygonDef CreatePolygonDef() => new PolygonDef();

        /// <summary>
        ///     Tests that set as box state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAsBox_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PolygonDef polygonDef = CreatePolygonDef();
            float hx = 0;
            float hy = 0;

            // Act
            polygonDef.SetAsBox(
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
            PolygonDef polygonDef = CreatePolygonDef();
            float hx = 0;
            float hy = 0;
            Vector2 center = default(Vector2);
            float angle = 0;

            // Act
            polygonDef.SetAsBox(
                hx,
                hy,
                center,
                angle);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}