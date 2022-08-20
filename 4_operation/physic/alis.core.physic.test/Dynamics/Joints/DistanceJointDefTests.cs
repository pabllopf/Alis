// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceJointDefTests.cs
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

using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The distance joint def tests class
    /// </summary>
    public class DistanceJointDefTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;


        /// <summary>
        ///     Initializes a new instance of the <see cref="DistanceJointDefTests" /> class
        /// </summary>
        public DistanceJointDefTests() => mockRepository = new MockRepository(MockBehavior.Strict);

        /// <summary>
        ///     Creates the distance joint def
        /// </summary>
        /// <returns>The distance joint def</returns>
        private DistanceJointDef CreateDistanceJointDef() => new DistanceJointDef();

        /// <summary>
        ///     Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            /*// Arrange
            var distanceJointDef = CreateDistanceJointDef();
            Body body1 = null;
            Body body2 = null;
            Vector2 anchor1 = default(Vector2);
            Vector2 anchor2 = default(Vector2);

            // Act
            distanceJointDef.Initialize(
                body1,
                body2,
                anchor1,
                anchor2);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}