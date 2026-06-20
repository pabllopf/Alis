// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendModeTest.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the BlendMode struct.
    /// </summary>
    public class BlendModeTest
    {
        /// <summary>
        ///     Tests the default constructor creates a zero-initialized blend mode.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesZeroInitialized()
        {
            BlendMode mode = new BlendMode();

            Assert.Equal(BlendMode.Factor.Zero, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.Zero, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests the two-parameter constructor initializes color and alpha factors.
        /// </summary>
        [Fact]
        public void TwoParamConstructor_SetsColorAndAlphaFactors()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);

            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests the three-parameter constructor with custom equation.
        /// </summary>
        [Fact]
        public void ThreeParamConstructor_SetsCustomEquation()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.DstColor, BlendMode.Factor.Zero, BlendMode.Equation.Subtract);

            Assert.Equal(BlendMode.Factor.DstColor, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Subtract, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.DstColor, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Subtract, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests the six-parameter constructor with separate color and alpha configs.
        /// </summary>
        [Fact]
        public void SixParamConstructor_SetsSeparateColorAndAlpha()
        {
            BlendMode mode = new BlendMode(
                BlendMode.Factor.SrcColor, BlendMode.Factor.OneMinusDstColor, BlendMode.Equation.Add,
                BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusDstAlpha, BlendMode.Equation.ReverseSubtract);

            Assert.Equal(BlendMode.Factor.SrcColor, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusDstColor, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusDstAlpha, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.ReverseSubtract, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that predefined blend modes have expected values.
        /// </summary>
        [Fact]
        public void PredefinedModes_HaveExpectedValues()
        {
            Assert.Equal(new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Equation.Add,
                BlendMode.Factor.One, BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Equation.Add), BlendMode.Alpha);

            Assert.Equal(new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.One, BlendMode.Equation.Add,
                BlendMode.Factor.One, BlendMode.Factor.One, BlendMode.Equation.Add), BlendMode.Add);

            Assert.Equal(new BlendMode(BlendMode.Factor.DstColor, BlendMode.Factor.Zero), BlendMode.Multiply);

            Assert.Equal(new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero), BlendMode.None);
        }

        /// <summary>
        ///     Tests equality operators and Equals methods.
        /// </summary>
        [Fact]
        public void Equality_WorksCorrectly()
        {
            BlendMode a = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);
            BlendMode b = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);
            BlendMode c = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.True(a.Equals(b));
            Assert.True(a.Equals((object)b));
            Assert.False(a.Equals(c));
            Assert.False(a.Equals((object)c));
            Assert.True(a == b);
            Assert.True(a != c);
        }

        /// <summary>
        ///     Tests that GetHashCode is consistent for equal blend modes.
        /// </summary>
        [Fact]
        public void GetHashCode_ConsistentForEqualModes()
        {
            BlendMode a = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);
            BlendMode b = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);

            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }

        /// <summary>
        ///     Tests that Equals returns false for different types.
        /// </summary>
        [Fact]
        public void Equals_WithDifferentType_ReturnsFalse()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.Zero, BlendMode.Factor.Zero);

            Assert.False(mode.Equals(null));
        }
    }
}
