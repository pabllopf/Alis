// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConstantCoverageTests.cs
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
    ///     The constant coverage tests class
    /// </summary>
    public class ConstantCoverageTests
    {
        /// <summary>
        ///     Tests that pi equals float math pi exactly
        /// </summary>
        [Fact]
        public void Pi_EqualsFloatMathPi()
        {
            float expected = (float) Math.PI;
            Assert.Equal(expected, Constant.Pi);
        }

        /// <summary>
        ///     Tests that tau equals float two math pi exactly
        /// </summary>
        [Fact]
        public void Tau_EqualsFloatTwoMathPi()
        {
            float expected = (float) (Math.PI * 2.0);
            Assert.Equal(expected, Constant.Tau);
        }

        /// <summary>
        ///     Tests that tau equals two times pi constant
        /// </summary>
        [Fact]
        public void Tau_EqualsTwoTimesPiConstant()
        {
            Assert.Equal(Constant.Pi * 2.0f, Constant.Tau);
        }

        /// <summary>
        ///     Tests that constants are positive
        /// </summary>
        [Fact]
        public void Constants_ArePositive()
        {
            Assert.True(Constant.Pi > 0.0f);
            Assert.True(Constant.Tau > 0.0f);
            Assert.True(Constant.Tau > Constant.Pi);
        }
    }
}
