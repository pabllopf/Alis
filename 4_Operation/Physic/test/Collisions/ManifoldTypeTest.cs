// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ManifoldTypeTest.cs
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
    ///     The manifold type test class
    /// </summary>
    public class ManifoldTypeTest
    {
        /// <summary>
        ///     Tests that circles should have value zero
        /// </summary>
        [Fact]
        public void Circles_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int)ManifoldType.Circles);
        }

        /// <summary>
        ///     Tests that face a should have value one
        /// </summary>
        [Fact]
        public void FaceA_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int)ManifoldType.FaceA);
        }

        /// <summary>
        ///     Tests that face b should have value two
        /// </summary>
        [Fact]
        public void FaceB_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int)ManifoldType.FaceB);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            ManifoldType[] values = new[]
            {
                ManifoldType.Circles,
                ManifoldType.FaceA,
                ManifoldType.FaceB
            };
            
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    Assert.NotEqual(values[i], values[j]);
                }
            }
        }
    }
}

