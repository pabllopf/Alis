// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BreakableBodyStateTest.cs
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

using Alis.Core.Physic.Common.Logic;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The breakable body state test class
    /// </summary>
    public class BreakableBodyStateTest
    {
        /// <summary>
        ///     Tests that unbroken enum value should be defined
        /// </summary>
        [Fact]
        public void UnbrokenEnumValue_ShouldBeDefined()
        {
            BreakableBodyState state = BreakableBodyState.Unbroken;
            
            Assert.Equal(BreakableBodyState.Unbroken, state);
        }

        /// <summary>
        ///     Tests that should break enum value should be defined
        /// </summary>
        [Fact]
        public void ShouldBreakEnumValue_ShouldBeDefined()
        {
            BreakableBodyState state = BreakableBodyState.ShouldBreak;
            
            Assert.Equal(BreakableBodyState.ShouldBreak, state);
        }

        /// <summary>
        ///     Tests that broken enum value should be defined
        /// </summary>
        [Fact]
        public void BrokenEnumValue_ShouldBeDefined()
        {
            BreakableBodyState state = BreakableBodyState.Broken;
            
            Assert.Equal(BreakableBodyState.Broken, state);
        }

        /// <summary>
        ///     Tests that breakable body state should have three values
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldHaveThreeValues()
        {
            var values = System.Enum.GetValues(typeof(BreakableBodyState));
            
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that breakable body state should be castable to int
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldBeCastableToInt()
        {
            int unbrokenValue = (int)BreakableBodyState.Unbroken;
            int shouldBreakValue = (int)BreakableBodyState.ShouldBreak;
            int brokenValue = (int)BreakableBodyState.Broken;
            
            Assert.Equal(0, unbrokenValue);
            Assert.Equal(1, shouldBreakValue);
            Assert.Equal(2, brokenValue);
        }

        /// <summary>
        ///     Tests that breakable body state should support equality comparison
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldSupportEqualityComparison()
        {
            BreakableBodyState state1 = BreakableBodyState.Unbroken;
            BreakableBodyState state2 = BreakableBodyState.Unbroken;
            
            Assert.Equal(state1, state2);
        }

        /// <summary>
        ///     Tests that breakable body state should support inequality comparison
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldSupportInequalityComparison()
        {
            BreakableBodyState state1 = BreakableBodyState.Unbroken;
            BreakableBodyState state2 = BreakableBodyState.Broken;
            
            Assert.NotEqual(state1, state2);
        }

        /// <summary>
        ///     Tests that breakable body state should transition from unbroken to should break
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldTransitionFromUnbrokenToShouldBreak()
        {
            BreakableBodyState state = BreakableBodyState.Unbroken;
            state = BreakableBodyState.ShouldBreak;
            
            Assert.Equal(BreakableBodyState.ShouldBreak, state);
        }

        /// <summary>
        ///     Tests that breakable body state should transition from should break to broken
        /// </summary>
        [Fact]
        public void BreakableBodyState_ShouldTransitionFromShouldBreakToBroken()
        {
            BreakableBodyState state = BreakableBodyState.ShouldBreak;
            state = BreakableBodyState.Broken;
            
            Assert.Equal(BreakableBodyState.Broken, state);
        }
    }
}

