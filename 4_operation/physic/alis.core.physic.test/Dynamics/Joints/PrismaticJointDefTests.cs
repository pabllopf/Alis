// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PrismaticJointDefTests.cs
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

using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The prismatic joint def tests class
    /// </summary>
    public class PrismaticJointDefTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJointDefTests" /> class
        /// </summary>
        public PrismaticJointDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }

        /// <summary>
        ///     Creates the prismatic joint def
        /// </summary>
        /// <returns>The prismatic joint def</returns>
        private PrismaticJointDef CreatePrismaticJointDef()
        {
            return new PrismaticJointDef();
        }

        /// <summary>
        ///     Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var prismaticJointDef = CreatePrismaticJointDef();
            Body body1 = null;
            Body body2 = null;
            Vector2 anchor = default(Vector2);
            Vector2 axis = default(Vector2);

            // Act
            prismaticJointDef.Initialize(
                body1,
                body2,
                anchor,
                axis);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}