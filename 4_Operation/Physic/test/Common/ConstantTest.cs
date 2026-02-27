// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConstantTest.cs
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
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The constant test class
    /// </summary>
    public class ConstantTest
    {
        /// <summary>
        ///     Tests that pi should have correct value
        /// </summary>
        [Fact]
        public void Pi_ShouldHaveCorrectValue()
        {
            Assert.Equal((float)Math.PI, Constant.Pi, 5);
        }

        /// <summary>
        ///     Tests that tau should be two times pi
        /// </summary>
        [Fact]
        public void Tau_ShouldBeTwoTimesPi()
        {
            Assert.Equal((float)(Math.PI * 2.0), Constant.Tau, 5);
        }

        /// <summary>
        ///     Tests that tau should be approximately six point two eight
        /// </summary>
        [Fact]
        public void Tau_ShouldBeApproximatelySixPointTwoEight()
        {
            Assert.True(Constant.Tau > 6.28f && Constant.Tau < 6.29f);
        }

        /// <summary>
        ///     Tests that pi should be approximately three point one four
        /// </summary>
        [Fact]
        public void Pi_ShouldBeApproximatelyThreePointOneFour()
        {
            Assert.True(Constant.Pi > 3.14f && Constant.Pi < 3.15f);
        }
    }
}

