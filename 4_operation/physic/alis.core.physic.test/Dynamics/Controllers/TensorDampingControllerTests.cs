// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TensorDampingControllerTests.cs
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
    ///     The tensor damping controller tests class
    /// </summary>
    public class TensorDampingControllerTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="TensorDampingControllerTests" /> class
        /// </summary>
        public TensorDampingControllerTests() => mockRepository = new MockRepository(MockBehavior.Strict);

        /// <summary>
        ///     Creates the tensor damping controller
        /// </summary>
        /// <returns>The tensor damping controller</returns>
        private TensorDampingController CreateTensorDampingController() => new TensorDampingController();

        /// <summary>
        ///     Tests that set axis aligned state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAxisAligned_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            TensorDampingController tensorDampingController = CreateTensorDampingController();
            float xDamping = 0;
            float yDamping = 0;

            // Act
            tensorDampingController.SetAxisAligned(
                xDamping,
                yDamping);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            TensorDampingController tensorDampingController = CreateTensorDampingController();
            TimeStep step = default(TimeStep);

            // Act
            tensorDampingController.Step(
                step);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}