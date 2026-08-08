// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConstantTests.cs
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

using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    /// The constant tests class
    /// </summary>
    public class ConstantTests
    {
        /// <summary>
        /// Tests that epsilon should be correct
        /// </summary>
        [Fact]
        public void Epsilon_ShouldBeCorrect()
        {
            Assert.Equal(1.192092896e-07f, Constant.Epsilon, 5);
        }

        /// <summary>
        /// Tests that euler should be correct
        /// </summary>
        [Fact]
        public void Euler_ShouldBeCorrect()
        {
            Assert.Equal(2.7182818284590452354f, Constant.Euler, 5);
        }

        /// <summary>
        /// Tests that e should be correct
        /// </summary>
        [Fact]
        public void E_ShouldBeCorrect()
        {
            Assert.Equal((float) System.Math.E, Constant.E, 5);
        }

        /// <summary>
        /// Tests that log 10 e should be correct
        /// </summary>
        [Fact]
        public void Log10E_ShouldBeCorrect()
        {
            Assert.Equal(0.4342945f, Constant.Log10E, 5);
        }

        /// <summary>
        /// Tests that log 2 e should be correct
        /// </summary>
        [Fact]
        public void Log2E_ShouldBeCorrect()
        {
            Assert.Equal(1.442695f, Constant.Log2E, 5);
        }

        /// <summary>
        /// Tests that pi should be correct
        /// </summary>
        [Fact]
        public void Pi_ShouldBeCorrect()
        {
            Assert.Equal((float) System.Math.PI, Constant.Pi, 5);
        }

        /// <summary>
        /// Tests that pi over 2 should be correct
        /// </summary>
        [Fact]
        public void PiOver2_ShouldBeCorrect()
        {
            Assert.Equal((float) (System.Math.PI / 2.0), Constant.PiOver2, 5);
        }

        /// <summary>
        /// Tests that pi over 4 should be correct
        /// </summary>
        [Fact]
        public void PiOver4_ShouldBeCorrect()
        {
            Assert.Equal((float) (System.Math.PI / 4.0), Constant.PiOver4, 5);
        }

        /// <summary>
        /// Tests that two pi should be correct
        /// </summary>
        [Fact]
        public void TwoPi_ShouldBeCorrect()
        {
            Assert.Equal((float) (System.Math.PI * 2.0), Constant.TwoPi, 5);
        }

        /// <summary>
        /// Tests that tau should be correct
        /// </summary>
        [Fact]
        public void Tau_ShouldBeCorrect()
        {
            Assert.Equal(Constant.TwoPi, Constant.Tau, 5);
        }
    }
}
