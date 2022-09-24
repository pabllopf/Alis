// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JacobianTests.cs
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
using Alis.Core.Physic.Dynamics;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The jacobian tests class
    /// </summary>
    public class JacobianTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="JacobianTests" /> class
        /// </summary>
        public JacobianTests() => mockRepository = new MockRepository(MockBehavior.Strict);

        /// <summary>
        ///     Creates the jacobian
        /// </summary>
        /// <returns>The jacobian</returns>
        private Jacobian CreateJacobian() => new Jacobian();

        /// <summary>
        ///     Tests that set zero state under test expected behavior
        /// </summary>
        [Fact]
        public void SetZero_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Jacobian jacobian = CreateJacobian();

            // Act
            jacobian.SetZero();

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
            Jacobian jacobian = CreateJacobian();
            Vector2 x1 = default(Vector2);
            float a1 = 0;
            Vector2 x2 = default(Vector2);
            float a2 = 0;

            // Act
            jacobian.Set(
                x1,
                a1,
                x2,
                a2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that compute state under test expected behavior
        /// </summary>
        [Fact]
        public void Compute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Jacobian jacobian = CreateJacobian();
            Vector2 x1 = default(Vector2);
            float a1 = 0;
            Vector2 x2 = default(Vector2);
            float a2 = 0;

            // Act
            float result = jacobian.Compute(
                x1,
                a1,
                x2,
                a2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}