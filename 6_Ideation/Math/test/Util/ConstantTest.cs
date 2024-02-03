// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Constant.cs
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
    /// The constant test class
    /// </summary>
    public class ConstantTest
    {
        /// <summary>
        /// Tests that constant epsilon should be correct
        /// </summary>
        [Fact]
        public void Constant_Epsilon_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal(1.192092896e-07f, Constant.Epsilon);
        }

        /// <summary>
        /// Tests that constant euler should be correct
        /// </summary>
        [Fact]
        public void Constant_Euler_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal(2.7182818284590452354f, Constant.Euler);
        }

        /// <summary>
        /// Tests that constant e should be correct
        /// </summary>
        [Fact]
        public void Constant_E_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal((float) System.Math.E, Constant.E);
        }

        /// <summary>
        /// Tests that constant log 10 e should be correct
        /// </summary>
        [Fact]
        public void Constant_Log10E_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal(0.4342945f, Constant.Log10E);
        }

        /// <summary>
        /// Tests that constant log 2 e should be correct
        /// </summary>
        [Fact]
        public void Constant_Log2E_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal(1.442695f, Constant.Log2E);
        }

        /// <summary>
        /// Tests that constant pi should be correct
        /// </summary>
        [Fact]
        public void Constant_Pi_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal((float) System.Math.PI, Constant.Pi);
        }

        /// <summary>
        /// Tests that constant pi over 2 should be correct
        /// </summary>
        [Fact]
        public void Constant_PiOver2_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal((float) (System.Math.PI / 2.0), Constant.PiOver2);
        }

        /// <summary>
        /// Tests that constant pi over 4 should be correct
        /// </summary>
        [Fact]
        public void Constant_PiOver4_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal((float) (System.Math.PI / 4.0), Constant.PiOver4);
        }

        /// <summary>
        /// Tests that constant two pi should be correct
        /// </summary>
        [Fact]
        public void Constant_TwoPi_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal((float) (System.Math.PI * 2.0), Constant.TwoPi);
        }

        /// <summary>
        /// Tests that constant tau should be correct
        /// </summary>
        [Fact]
        public void Constant_Tau_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal(Constant.TwoPi, Constant.Tau);
        }
    }
}