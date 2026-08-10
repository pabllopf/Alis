// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConstantRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    ///     The constant remaining coverage tests class
    /// </summary>
    public class ConstantRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that epsilon has expected value
        /// </summary>
        [Fact]
        public void Epsilon_HasExpectedValue()
        {
            Assert.Equal(1.192092896e-07f, Constant.Epsilon);
        }

        /// <summary>
        ///     Tests that euler has expected value
        /// </summary>
        [Fact]
        public void Euler_HasExpectedValue()
        {
            Assert.Equal(2.71828175f, Constant.Euler, 5);
        }

        /// <summary>
        ///     Tests that e matches math e
        /// </summary>
        [Fact]
        public void E_MatchesMathE()
        {
            Assert.Equal((float) System.Math.E, Constant.E, 5);
        }

        /// <summary>
        ///     Tests that log 10 e has expected value
        /// </summary>
        [Fact]
        public void Log10E_HasExpectedValue()
        {
            Assert.Equal(0.4342945f, Constant.Log10E, 5);
        }

        /// <summary>
        ///     Tests that log 2 e has expected value
        /// </summary>
        [Fact]
        public void Log2E_HasExpectedValue()
        {
            Assert.Equal(1.442695f, Constant.Log2E, 5);
        }

        /// <summary>
        ///     Tests that pi matches math pi
        /// </summary>
        [Fact]
        public void Pi_MatchesMathPi()
        {
            Assert.Equal((float) System.Math.PI, Constant.Pi, 5);
        }

        /// <summary>
        ///     Tests that pi over two matches math pi divided by two
        /// </summary>
        [Fact]
        public void PiOver2_MatchesMathPiDividedByTwo()
        {
            Assert.Equal((float) (System.Math.PI / 2.0), Constant.PiOver2, 5);
        }

        /// <summary>
        ///     Tests that pi over four matches math pi divided by four
        /// </summary>
        [Fact]
        public void PiOver4_MatchesMathPiDividedByFour()
        {
            Assert.Equal((float) (System.Math.PI / 4.0), Constant.PiOver4, 5);
        }

        /// <summary>
        ///     Tests that two pi matches math pi times two
        /// </summary>
        [Fact]
        public void TwoPi_MatchesMathPiTimesTwo()
        {
            Assert.Equal((float) (System.Math.PI * 2.0), Constant.TwoPi, 5);
        }

        /// <summary>
        ///     Tests that tau is alias of two pi
        /// </summary>
        [Fact]
        public void Tau_IsAliasOfTwoPi()
        {
            Assert.Equal(Constant.TwoPi, Constant.Tau, 5);
        }
    }
}
