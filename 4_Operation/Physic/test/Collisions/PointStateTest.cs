// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointStateTest.cs
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
    ///     The point state test class
    /// </summary>
    public class PointStateTest
    {
        /// <summary>
        ///     Tests that null should have value zero
        /// </summary>
        [Fact]
        public void Null_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int)PointState.Null);
        }

        /// <summary>
        ///     Tests that add should have value one
        /// </summary>
        [Fact]
        public void Add_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int)PointState.Add);
        }

        /// <summary>
        ///     Tests that persist should have value two
        /// </summary>
        [Fact]
        public void Persist_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int)PointState.Persist);
        }

        /// <summary>
        ///     Tests that remove should have value three
        /// </summary>
        [Fact]
        public void Remove_ShouldHaveValueThree()
        {
            Assert.Equal(3, (int)PointState.Remove);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            PointState[] values = new[]
            {
                PointState.Null,
                PointState.Add,
                PointState.Persist,
                PointState.Remove
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
        ///     Tests that values should be sequential
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            Assert.Equal(0, (int)PointState.Null);
            Assert.Equal(1, (int)PointState.Add);
            Assert.Equal(2, (int)PointState.Persist);
            Assert.Equal(3, (int)PointState.Remove);
        }
    }
}

