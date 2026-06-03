// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LimitStateTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The limit state test class
    /// </summary>
    public class LimitStateTest
    {
        /// <summary>
        ///     Tests that inactive should have value zero
        /// </summary>
        [Fact]
        public void Inactive_ShouldHaveValueZero()
        {
            byte value = 0;
            Assert.Equal(value, (byte) LimitState.Inactive);
        }

        /// <summary>
        ///     Tests that atLower should have value one
        /// </summary>
        [Fact]
        public void AtLower_ShouldHaveValueOne()
        {
            byte value = 1;
            Assert.Equal(value, (byte) LimitState.AtLower);
        }

        /// <summary>
        ///     Tests that atUpper should have value two
        /// </summary>
        [Fact]
        public void AtUpper_ShouldHaveValueTwo()
        {
            byte value = 2;
            Assert.Equal(value, (byte) LimitState.AtUpper);
        }

        /// <summary>
        ///     Tests that equal should have value three
        /// </summary>
        [Fact]
        public void Equal_ShouldHaveValueThree()
        {
            byte value = 3;
            Assert.Equal(value, (byte) LimitState.Equal);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            Assert.NotEqual(LimitState.Inactive, LimitState.AtLower);
            Assert.NotEqual(LimitState.Inactive, LimitState.AtUpper);
            Assert.NotEqual(LimitState.Inactive, LimitState.Equal);
            Assert.NotEqual(LimitState.AtLower, LimitState.AtUpper);
            Assert.NotEqual(LimitState.AtLower, LimitState.Equal);
            Assert.NotEqual(LimitState.AtUpper, LimitState.Equal);
        }
    }
}
