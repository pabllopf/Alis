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
        
        /// <summary>
        /// Tests that epsilon should have expected value
        /// </summary>
        [Fact]
        public void Epsilon_ShouldHaveExpectedValue()
        {
            Assert.Equal(1.192092896e-07f, Constant.Epsilon);
        }

        /// <summary>
        /// Tests that euler should have expected value
        /// </summary>
        [Fact]
        public void Euler_ShouldHaveExpectedValue()
        {
            Assert.Equal(2.7182818284590452354f, Constant.Euler);
        }

        /// <summary>
        /// Tests that e should be equal to system math e
        /// </summary>
        [Fact]
        public void E_ShouldBeEqualToSystemMathE()
        {
            Assert.Equal((float)System.Math.E, Constant.E);
        }

        /// <summary>
        /// Tests that e should be equal to euler within float precision
        /// </summary>
        [Fact]
        public void E_ShouldBeEqualToEulerWithinFloatPrecision()
        {
            Assert.Equal(Constant.Euler, Constant.E, 5);
        }

        /// <summary>
        /// Tests that log 10 e should have expected value
        /// </summary>
        [Fact]
        public void Log10E_ShouldHaveExpectedValue()
        {
            Assert.Equal(0.4342945f, Constant.Log10E);
        }

        /// <summary>
        /// Tests that log 2 e should have expected value
        /// </summary>
        [Fact]
        public void Log2E_ShouldHaveExpectedValue()
        {
            Assert.Equal(1.442695f, Constant.Log2E);
        }

        /// <summary>
        /// Tests that pi should be equal to system math pi
        /// </summary>
        [Fact]
        public void Pi_ShouldBeEqualToSystemMathPi()
        {
            Assert.Equal((float)System.Math.PI, Constant.Pi);
        }

        /// <summary>
        /// Tests that pi over 2 should be equal to pi divided by two
        /// </summary>
        [Fact]
        public void PiOver2_ShouldBeEqualToPiDividedByTwo()
        {
            Assert.Equal(
                (float)(System.Math.PI / 2.0),
                Constant.PiOver2);
        }

        /// <summary>
        /// Tests that pi over 4 should be equal to pi divided by four
        /// </summary>
        [Fact]
        public void PiOver4_ShouldBeEqualToPiDividedByFour()
        {
            Assert.Equal(
                (float)(System.Math.PI / 4.0),
                Constant.PiOver4);
        }

        /// <summary>
        /// Tests that two pi should be equal to pi times two
        /// </summary>
        [Fact]
        public void TwoPi_ShouldBeEqualToPiTimesTwo()
        {
            Assert.Equal(
                (float)(System.Math.PI * 2.0),
                Constant.TwoPi);
        }

        /// <summary>
        /// Tests that tau should be equal to two pi
        /// </summary>
        [Fact]
        public void Tau_ShouldBeEqualToTwoPi()
        {
            Assert.Equal(Constant.TwoPi, Constant.Tau);
        }

        /// <summary>
        /// Tests that pi over 2 should be half of pi
        /// </summary>
        [Fact]
        public void PiOver2_ShouldBeHalfOfPi()
        {
            Assert.Equal(Constant.Pi / 2.0f, Constant.PiOver2);
        }

        /// <summary>
        /// Tests that pi over 4 should be quarter of pi
        /// </summary>
        [Fact]
        public void PiOver4_ShouldBeQuarterOfPi()
        {
            Assert.Equal(Constant.Pi / 4.0f, Constant.PiOver4);
        }

        /// <summary>
        /// Tests that two pi should be twice pi
        /// </summary>
        [Fact]
        public void TwoPi_ShouldBeTwicePi()
        {
            Assert.Equal(Constant.Pi * 2.0f, Constant.TwoPi);
        }

        /// <summary>
        /// Tests that two pi should be four times pi over 2
        /// </summary>
        [Fact]
        public void TwoPi_ShouldBeFourTimesPiOver2()
        {
            Assert.Equal(Constant.PiOver2 * 4.0f, Constant.TwoPi);
        }

        /// <summary>
        /// Tests that two pi should be eight times pi over 4
        /// </summary>
        [Fact]
        public void TwoPi_ShouldBeEightTimesPiOver4()
        {
            Assert.Equal(Constant.PiOver4 * 8.0f, Constant.TwoPi);
        }

        /// <summary>
        /// Tests that pi should be twice pi over 2
        /// </summary>
        [Fact]
        public void Pi_ShouldBeTwicePiOver2()
        {
            Assert.Equal(Constant.PiOver2 * 2.0f, Constant.Pi);
        }

        /// <summary>
        /// Tests that pi should be four times pi over 4
        /// </summary>
        [Fact]
        public void Pi_ShouldBeFourTimesPiOver4()
        {
            Assert.Equal(Constant.PiOver4 * 4.0f, Constant.Pi);
        }

        /// <summary>
        /// Tests that pi over 2 should be twice pi over 4
        /// </summary>
        [Fact]
        public void PiOver2_ShouldBeTwicePiOver4()
        {
            Assert.Equal(Constant.PiOver4 * 2.0f, Constant.PiOver2);
        }
        
        /// <summary>
        /// Tests that euler should be greater than two
        /// </summary>
        [Fact]
        public void Euler_ShouldBeGreaterThanTwo()
        {
            Assert.True(Constant.Euler > 2.0f);
        }

        /// <summary>
        /// Tests that euler should be less than three
        /// </summary>
        [Fact]
        public void Euler_ShouldBeLessThanThree()
        {
            Assert.True(Constant.Euler < 3.0f);
        }

        /// <summary>
        /// Tests that epsilon should be positive
        /// </summary>
        [Fact]
        public void Epsilon_ShouldBePositive()
        {
            Assert.True(Constant.Epsilon > 0.0f);
        }

        /// <summary>
        /// Tests that epsilon should be less than one
        /// </summary>
        [Fact]
        public void Epsilon_ShouldBeLessThanOne()
        {
            Assert.True(Constant.Epsilon < 1.0f);
        }

        /// <summary>
        /// Tests that pi should be positive
        /// </summary>
        [Fact]
        public void Pi_ShouldBePositive()
        {
            Assert.True(Constant.Pi > 0.0f);
        }

        /// <summary>
        /// Tests that pi should be between three and four
        /// </summary>
        [Fact]
        public void Pi_ShouldBeBetweenThreeAndFour()
        {
            Assert.InRange(Constant.Pi, 3.0f, 4.0f);
        }

        /// <summary>
        /// Tests that pi over 2 should be between one and two
        /// </summary>
        [Fact]
        public void PiOver2_ShouldBeBetweenOneAndTwo()
        {
            Assert.InRange(Constant.PiOver2, 1.0f, 2.0f);
        }

        /// <summary>
        /// Tests that pi over 4 should be between zero and one
        /// </summary>
        [Fact]
        public void PiOver4_ShouldBeBetweenZeroAndOne()
        {
            Assert.InRange(Constant.PiOver4, 0.0f, 1.0f);
        }

        /// <summary>
        /// Tests that two pi should be between six and seven
        /// </summary>
        [Fact]
        public void TwoPi_ShouldBeBetweenSixAndSeven()
        {
            Assert.InRange(Constant.TwoPi, 6.0f, 7.0f);
        }

        /// <summary>
        /// Tests that tau should be positive
        /// </summary>
        [Fact]
        public void Tau_ShouldBePositive()
        {
            Assert.True(Constant.Tau > 0.0f);
        }

        /// <summary>
        /// Tests that tau should be between six and seven
        /// </summary>
        [Fact]
        public void Tau_ShouldBeBetweenSixAndSeven()
        {
            Assert.InRange(Constant.Tau, 6.0f, 7.0f);
        }

        /// <summary>
        /// Tests that log 10 e should be positive
        /// </summary>
        [Fact]
        public void Log10E_ShouldBePositive()
        {
            Assert.True(Constant.Log10E > 0.0f);
        }

        /// <summary>
        /// Tests that log 2 e should be positive
        /// </summary>
        [Fact]
        public void Log2E_ShouldBePositive()
        {
            Assert.True(Constant.Log2E > 0.0f);
        }

        /// <summary>
        /// Tests that log 2 e should be greater than log 10 e
        /// </summary>
        [Fact]
        public void Log2E_ShouldBeGreaterThanLog10E()
        {
            Assert.True(Constant.Log2E > Constant.Log10E);
        }

        /// <summary>
        /// Tests that e should be positive
        /// </summary>
        [Fact]
        public void E_ShouldBePositive()
        {
            Assert.True(Constant.E > 0.0f);
        }

        /// <summary>
        /// Tests that e should be between two and three
        /// </summary>
        [Fact]
        public void E_ShouldBeBetweenTwoAndThree()
        {
            Assert.InRange(Constant.E, 2.0f, 3.0f);
        }

        /// <summary>
        /// Tests that euler and e should have same float value
        /// </summary>
        [Fact]
        public void EulerAndE_ShouldHaveSameFloatValue()
        {
            Assert.Equal(Constant.Euler, Constant.E);
        }

        /// <summary>
        /// Tests that tau and two pi should have same float value
        /// </summary>
        [Fact]
        public void TauAndTwoPi_ShouldHaveSameFloatValue()
        {
            Assert.Equal(Constant.TwoPi, Constant.Tau);
        }

        /// <summary>
        /// Tests that all constants should be finite
        /// </summary>
        [Fact]
        public void AllConstants_ShouldBeFinite()
        {
            Assert.True(float.IsNaN(Constant.Epsilon) == false);
            Assert.True(float.IsInfinity(Constant.Epsilon) == false);

            Assert.True(float.IsNaN(Constant.Euler) == false);
            Assert.True(float.IsInfinity(Constant.Euler) == false);

            Assert.True(float.IsNaN(Constant.E) == false);
            Assert.True(float.IsInfinity(Constant.E) == false);

            Assert.True(float.IsNaN(Constant.Log10E) == false);
            Assert.True(float.IsInfinity(Constant.Log10E) == false);

            Assert.True(float.IsNaN(Constant.Log2E) == false);
            Assert.True(float.IsInfinity(Constant.Log2E) == false);

            Assert.True(float.IsNaN(Constant.Pi) == false);
            Assert.True(float.IsInfinity(Constant.Pi) == false);

            Assert.True(float.IsNaN(Constant.PiOver2) == false);
            Assert.True(float.IsInfinity(Constant.PiOver2) == false);

            Assert.True(float.IsNaN(Constant.PiOver4) == false);
            Assert.True(float.IsInfinity(Constant.PiOver4) == false);

            Assert.True(float.IsNaN(Constant.TwoPi) == false);
            Assert.True(float.IsInfinity(Constant.TwoPi) == false);

            Assert.True(float.IsNaN(Constant.Tau) == false);
            Assert.True(float.IsInfinity(Constant.Tau) == false);
        }
    }
}
