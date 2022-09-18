// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConstantAccelControllerTests.cs
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
    ///     The constant accel controller tests class
    /// </summary>
    public class ConstantAccelControllerTests
    {
        /// <summary>
        ///     The mock constant accel controller def
        /// </summary>
        private Mock<ConstantAccelControllerDef> mockConstantAccelControllerDef;

        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstantAccelControllerTests" /> class
        /// </summary>
        public ConstantAccelControllerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockConstantAccelControllerDef = mockRepository.Create<ConstantAccelControllerDef>();
        }

        /// <summary>
        ///     Creates the constant accel controller
        /// </summary>
        /// <returns>The constant accel controller</returns>
        private ConstantAccelController CreateConstantAccelController() => new ConstantAccelController(
            mockConstantAccelControllerDef.Object);

        /// <summary>
        ///     Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ConstantAccelController constantAccelController = CreateConstantAccelController();
            TimeStep step = default(TimeStep);

            // Act
            constantAccelController.Step(
                step);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}