// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EpAxisTypeTest.cs
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

using System;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The ep axis type test class
    /// </summary>
    public class EpAxisTypeTest
    {
        /// <summary>
        ///     Tests that unknown should have value zero
        /// </summary>
        [Fact]
        public void Unknown_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int)EpAxisType.Unknown);
        }

        /// <summary>
        ///     Tests that edge a should have value one
        /// </summary>
        [Fact]
        public void EdgeA_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int)EpAxisType.EdgeA);
        }

        /// <summary>
        ///     Tests that edge b should have value two
        /// </summary>
        [Fact]
        public void EdgeB_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int)EpAxisType.EdgeB);
        }

        /// <summary>
        ///     Tests that values should be sequential
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            Assert.True((int)EpAxisType.EdgeA == (int)EpAxisType.Unknown + 1);
            Assert.True((int)EpAxisType.EdgeB == (int)EpAxisType.EdgeA + 1);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            EpAxisType[] values = (EpAxisType[])Enum.GetValues(typeof(EpAxisType));

            Assert.Equal(3, values.Length);
            Assert.Equal(EpAxisType.Unknown, values[0]);
            Assert.Equal(EpAxisType.EdgeA, values[1]);
            Assert.Equal(EpAxisType.EdgeB, values[2]);
        }
    }
}
