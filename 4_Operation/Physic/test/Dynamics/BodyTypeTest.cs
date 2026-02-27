// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyTypeTest.cs
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

using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The body type test class
    /// </summary>
    public class BodyTypeTest
    {
        /// <summary>
        ///     Tests that static should have value zero
        /// </summary>
        [Fact]
        public void Static_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int)BodyType.Static);
        }

        /// <summary>
        ///     Tests that kinematic should have value one
        /// </summary>
        [Fact]
        public void Kinematic_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int)BodyType.Kinematic);
        }

        /// <summary>
        ///     Tests that dynamic should have value two
        /// </summary>
        [Fact]
        public void Dynamic_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int)BodyType.Dynamic);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            BodyType[] values = new[]
            {
                BodyType.Static,
                BodyType.Kinematic,
                BodyType.Dynamic
            };
            
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    Assert.NotEqual(values[i], values[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that values should be in order
        /// </summary>
        [Fact]
        public void Values_ShouldBeInOrder()
        {
            Assert.True((int)BodyType.Static < (int)BodyType.Kinematic);
            Assert.True((int)BodyType.Kinematic < (int)BodyType.Dynamic);
        }
    }
}

