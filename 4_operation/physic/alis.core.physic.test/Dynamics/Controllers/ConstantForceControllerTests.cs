// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConstantForceControllerTests.cs
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

using Alis.Aspect.Time;
using Alis.Core.Physic.Dynamics.Controllers;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Controllers
{
    /// <summary>
    ///     The constant force controller tests class
    /// </summary>
    public class ConstantForceControllerTests
    {
        /// <summary>
        ///     The mock constant force controller def
        /// </summary>
        private Mock<ConstantForceControllerDef> mockConstantForceControllerDef;

        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstantForceControllerTests" /> class
        /// </summary>
        public ConstantForceControllerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockConstantForceControllerDef = mockRepository.Create<ConstantForceControllerDef>();
        }

        /// <summary>
        ///     Creates the constant force controller
        /// </summary>
        /// <returns>The constant force controller</returns>
        private ConstantForceController CreateConstantForceController() => new ConstantForceController(
            mockConstantForceControllerDef.Object);

        /// <summary>
        ///     Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ConstantForceController constantForceController = CreateConstantForceController();
            TimeStep step = default(TimeStep);

            // Act
            constantForceController.Step(
                step);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}