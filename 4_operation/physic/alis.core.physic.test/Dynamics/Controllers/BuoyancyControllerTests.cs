// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BuoyancyControllerTests.cs
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

using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    ///     The buoyancy controller tests class
    /// </summary>
    public class BuoyancyControllerTests
    {
        /// <summary>
        ///     The mock buoyancy controller def
        /// </summary>
        private Mock<BuoyancyControllerDef> mockBuoyancyControllerDef;

        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BuoyancyControllerTests" /> class
        /// </summary>
        public BuoyancyControllerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockBuoyancyControllerDef = mockRepository.Create<BuoyancyControllerDef>();
        }

        /// <summary>
        ///     Creates the buoyancy controller
        /// </summary>
        /// <returns>The buoyancy controller</returns>
        private BuoyancyController CreateBuoyancyController() => new BuoyancyController(
            mockBuoyancyControllerDef.Object);

        /// <summary>
        ///     Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            BuoyancyController buoyancyController = CreateBuoyancyController();
            TimeStep step = default(TimeStep);

            // Act
            buoyancyController.Step(
                step);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that draw state under test expected behavior
        /// </summary>
        [Fact]
        public void Draw_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var buoyancyController = CreateBuoyancyController();
            //DebugDraw debugDraw = null;

            // Act
            //buoyancyController.Draw(debugDraw);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}