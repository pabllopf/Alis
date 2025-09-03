// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendModeTests.cs
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
    ///     The blend mode tests class
    /// </summary>
    public class BlendModeTests
    {
        /// <summary>
        ///     Tests that constructor sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsFieldsCorrectly()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Equation.Add,
                BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Subtract);
            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.One, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Subtract, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that predefined modes are correct
        /// </summary>
        [Fact]
        public void PredefinedModes_AreCorrect()
        {
            BlendMode alpha = BlendMode.Alpha;
            Assert.Equal(BlendMode.Factor.SrcAlpha, alpha.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, alpha.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, alpha.ColorEquation);
            Assert.Equal(BlendMode.Factor.One, alpha.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, alpha.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, alpha.AlphaEquation);
        }

        /// <summary>
        ///     Tests that equality operators work
        /// </summary>
        [Fact]
        public void Equality_Operators_Work()
        {
            BlendMode a = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode b = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode c = new BlendMode(BlendMode.Factor.Zero, BlendMode.Factor.One);
            Assert.True(a == b);
            Assert.False(a != b);
            Assert.False(a == c);
            Assert.True(a != c);
        }

        /// <summary>
        ///     Tests that get hash code is consistent
        /// </summary>
        [Fact]
        public void GetHashCode_IsConsistent()
        {
            BlendMode a = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            BlendMode b = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }
    }
}