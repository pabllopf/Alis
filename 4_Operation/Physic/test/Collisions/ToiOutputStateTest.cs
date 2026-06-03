// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ToiOutputStateTest.cs
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

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The toi output state test class
    /// </summary>
    public class ToiOutputStateTest
    {
        /// <summary>
        ///     Tests that unknown should have value zero
        /// </summary>
        [Fact]
        public void Unknown_ShouldHaveValueZero()
        {
            byte value = 0;
            Assert.Equal(value, (byte) ToiOutputState.Unknown);
        }

        /// <summary>
        ///     Tests that failed should have value one
        /// </summary>
        [Fact]
        public void Failed_ShouldHaveValueOne()
        {
            byte value = 1;
            Assert.Equal(value, (byte) ToiOutputState.Failed);
        }

        /// <summary>
        ///     Tests that overlapped should have value two
        /// </summary>
        [Fact]
        public void Overlapped_ShouldHaveValueTwo()
        {
            byte value = 2;
            Assert.Equal(value, (byte) ToiOutputState.Overlapped);
        }

        /// <summary>
        ///     Tests that touching should have value three
        /// </summary>
        [Fact]
        public void Touching_ShouldHaveValueThree()
        {
            byte value = 3;
            Assert.Equal(value, (byte) ToiOutputState.Touching);
        }

        /// <summary>
        ///     Tests that seperated should have value four
        /// </summary>
        [Fact]
        public void Seperated_ShouldHaveValueFour()
        {
            byte value = 4;
            Assert.Equal(value, (byte) ToiOutputState.Seperated);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            Assert.NotEqual(ToiOutputState.Unknown, ToiOutputState.Failed);
            Assert.NotEqual(ToiOutputState.Unknown, ToiOutputState.Overlapped);
            Assert.NotEqual(ToiOutputState.Unknown, ToiOutputState.Touching);
            Assert.NotEqual(ToiOutputState.Unknown, ToiOutputState.Seperated);
            Assert.NotEqual(ToiOutputState.Failed, ToiOutputState.Overlapped);
            Assert.NotEqual(ToiOutputState.Failed, ToiOutputState.Touching);
            Assert.NotEqual(ToiOutputState.Failed, ToiOutputState.Seperated);
            Assert.NotEqual(ToiOutputState.Overlapped, ToiOutputState.Touching);
            Assert.NotEqual(ToiOutputState.Overlapped, ToiOutputState.Seperated);
            Assert.NotEqual(ToiOutputState.Touching, ToiOutputState.Seperated);
        }
    }
}
