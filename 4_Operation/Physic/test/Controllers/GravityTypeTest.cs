// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GravityTypeTest.cs
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

using Alis.Core.Physic.Controllers;
using Xunit;

namespace Alis.Core.Physic.Test.Controllers
{
    /// <summary>
    ///     The gravity type test class
    /// </summary>
    public class GravityTypeTest
    {
        /// <summary>
        ///     Tests that linear should have value zero
        /// </summary>
        [Fact]
        public void Linear_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int)GravityType.Linear);
        }

        /// <summary>
        ///     Tests that distance squared should have value one
        /// </summary>
        [Fact]
        public void DistanceSquared_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int)GravityType.DistanceSquared);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            Assert.NotEqual(GravityType.Linear, GravityType.DistanceSquared);
        }

        /// <summary>
        ///     Tests that values should be sequential
        /// </summary>
        [Fact]
        public void Values_ShouldBeSequential()
        {
            Assert.Equal(0, (int)GravityType.Linear);
            Assert.Equal(1, (int)GravityType.DistanceSquared);
        }
    }
}

