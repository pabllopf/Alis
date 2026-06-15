// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlAdditionalTests.cs
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
using System.Linq;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;
using RenderStyles = Alis.Extension.Graphic.Sfml.Render.Styles;
using WindowStyles = Alis.Extension.Graphic.Sfml.Windows.Styles;

namespace Alis.Extension.Graphic.Sfml.Test
{
    /// <summary>
    ///     Additional tests for Sfml module covering enums, BlendMode, Vertex, and utility types
    /// </summary>
    public class SfmlAdditionalTests
    {
        #region PrimitiveType Enum Tests

        /// <summary>
        ///     Tests that PrimitiveType has all expected values
        /// </summary>
        [Fact]
        public void PrimitiveType_HasExpectedValues()
        {
            Assert.Equal(0, (int) PrimitiveType.Points);
            Assert.Equal(1, (int) PrimitiveType.Lines);
            Assert.Equal(2, (int) PrimitiveType.LineStrip);
            Assert.Equal(3, (int) PrimitiveType.Triangles);
            Assert.Equal(4, (int) PrimitiveType.TriangleStrip);
            Assert.Equal(5, (int) PrimitiveType.TriangleFan);
            Assert.Equal(6, (int) PrimitiveType.Quads);
        }

        /// <summary>
        ///     Tests that PrimitiveType aliases match their source values
        /// </summary>
        [Fact]
        public void PrimitiveType_AliasesMatchSourceValues()
        {
            Assert.Equal(PrimitiveType.LineStrip, PrimitiveType.LinesStrip);
            Assert.Equal(PrimitiveType.TriangleStrip, PrimitiveType.TrianglesStrip);
            Assert.Equal(PrimitiveType.TriangleFan, PrimitiveType.TrianglesFan);
        }

        /// <summary>
        ///     Tests that PrimitiveType has 10 distinct values (including aliases)
        /// </summary>
        [Fact]
        public void PrimitiveType_HasCorrectNumberOfDistinctValues()
        {
            // 7 unique values + 3 aliases = 10 enum members but only 7 distinct integer values
            Array allValues = Enum.GetValues(typeof(PrimitiveType));
            Assert.Equal(10, allValues.Length);

            int distinctValues = Enum.GetValues(typeof(PrimitiveType)).Cast<int>().Distinct().Count();
            Assert.Equal(7, distinctValues);
        }

        #endregion

        #region SoundStatus Enum Tests

        /// <summary>
        ///     Tests that SoundStatus has all expected values
        /// </summary>
        [Fact]
        public void SoundStatus_HasExpectedValues()
        {
            Assert.Equal(0, (int) SoundStatus.Stopped);
            Assert.Equal(1, (int) SoundStatus.Paused);
            Assert.Equal(2, (int) SoundStatus.Playing);
        }

        /// <summary>
        ///     Tests that SoundStatus has exactly 3 values
        /// </summary>
        [Fact]
        public void SoundStatus_HasCorrectNumberOfValues()
        {
            Array values = Enum.GetValues(typeof(SoundStatus));
            Assert.Equal(3, values.Length);
        }

        #endregion

        #region Windows Styles Enum Tests

        /// <summary>
        ///     Tests that Windows Styles has correct flag values
        /// </summary>
        [Fact]
        public void WindowsStyles_HasCorrectFlagValues()
        {
            Assert.Equal(0, (int) WindowStyles.None);
            Assert.Equal(1, (int) WindowStyles.Titlebar);
            Assert.Equal(2, (int) WindowStyles.Resize);
            Assert.Equal(4, (int) WindowStyles.Close);
            Assert.Equal(8, (int) WindowStyles.Fullscreen);
        }

        /// <summary>
        ///     Tests that Windows Styles.Default is the correct combination
        /// </summary>
        [Fact]
        public void WindowsStyles_Default_IsCorrectCombination()
        {
            Assert.Equal(WindowStyles.Titlebar | WindowStyles.Resize | WindowStyles.Close, WindowStyles.Default);
            Assert.Equal(7, (int) WindowStyles.Default);
        }

        /// <summary>
        ///     Tests that Windows Styles flags are powers of 2
        /// </summary>
        
        [InlineData(WindowStyles.Titlebar, 0)]
        [InlineData(WindowStyles.Resize, 1)]
        [InlineData(WindowStyles.Close, 2)]
        [InlineData(WindowStyles.Fullscreen, 3)]
        public void WindowsStyles_FlagsArePowersOfTwo(WindowStyles style, int shift)
        {
            Assert.Equal(1 << shift, (int) style);
        }

        /// <summary>
        ///     Tests that Windows Styles can be combined with bitwise OR
        /// </summary>
        [Fact]
        public void WindowsStyles_CanBeCombined()
        {
            WindowStyles combined = WindowStyles.Titlebar | WindowStyles.Resize;
            Assert.Equal(3, (int) combined);

            WindowStyles full = WindowStyles.Titlebar | WindowStyles.Resize | WindowStyles.Close;
            Assert.Equal(7, (int) full);
        }

        #endregion

        #region Render Styles Enum Tests

        /// <summary>
        ///     Tests that Render Styles has correct flag values
        /// </summary>
        [Fact]
        public void RenderStyles_HasCorrectFlagValues()
        {
            Assert.Equal(0, (int) RenderStyles.None);
            Assert.Equal(1, (int) RenderStyles.Bold);
            Assert.Equal(2, (int) RenderStyles.Italic);
            Assert.Equal(4, (int) RenderStyles.Underlined);
            Assert.Equal(8, (int) RenderStyles.StrikeThrough);
        }

        /// <summary>
        ///     Tests that Render Styles flags are powers of 2
        /// </summary>
        
        [InlineData(RenderStyles.Bold, 0)]
        [InlineData(RenderStyles.Italic, 1)]
        [InlineData(RenderStyles.Underlined, 2)]
        [InlineData(RenderStyles.StrikeThrough, 3)]
        public void RenderStyles_FlagsArePowersOfTwo(RenderStyles style, int shift)
        {
            Assert.Equal(1 << shift, (int) style);
        }

        /// <summary>
        ///     Tests that Render Styles can be combined with bitwise OR
        /// </summary>
        [Fact]
        public void RenderStyles_CanBeCombined()
        {
            RenderStyles boldItalic = RenderStyles.Bold | RenderStyles.Italic;
            Assert.Equal(3, (int) boldItalic);

            RenderStyles all = RenderStyles.Bold | RenderStyles.Italic | RenderStyles.Underlined | RenderStyles.StrikeThrough;
            Assert.Equal(15, (int) all);
        }

        #endregion

        #region BlendMode Nested Enum Tests

        /// <summary>
        ///     Tests that BlendMode.Factor has all expected values
        /// </summary>
        [Fact]
        public void BlendMode_Factor_HasExpectedValues()
        {
            Array values = Enum.GetValues(typeof(BlendMode.Factor));
            Assert.Equal(10, values.Length);

            Assert.Equal(0, (int) BlendMode.Factor.Zero);
            Assert.Equal(1, (int) BlendMode.Factor.One);
            Assert.Equal(2, (int) BlendMode.Factor.SrcColor);
            Assert.Equal(3, (int) BlendMode.Factor.OneMinusSrcColor);
            Assert.Equal(4, (int) BlendMode.Factor.DstColor);
            Assert.Equal(5, (int) BlendMode.Factor.OneMinusDstColor);
            Assert.Equal(6, (int) BlendMode.Factor.SrcAlpha);
            Assert.Equal(7, (int) BlendMode.Factor.OneMinusSrcAlpha);
            Assert.Equal(8, (int) BlendMode.Factor.DstAlpha);
            Assert.Equal(9, (int) BlendMode.Factor.OneMinusDstAlpha);
        }

        /// <summary>
        ///     Tests that BlendMode.Equation has all expected values
        /// </summary>
        [Fact]
        public void BlendMode_Equation_HasExpectedValues()
        {
            Array values = Enum.GetValues(typeof(BlendMode.Equation));
            Assert.Equal(3, values.Length);

            Assert.Equal(0, (int) BlendMode.Equation.Add);
            Assert.Equal(1, (int) BlendMode.Equation.Subtract);
            Assert.Equal(2, (int) BlendMode.Equation.ReverseSubtract);
        }

        #endregion

        #region BlendMode Static Readonly Field Tests

        /// <summary>
        ///     Tests that BlendMode.Alpha has the expected factor values
        /// </summary>
        [Fact]
        public void BlendMode_Alpha_HasExpectedFactors()
        {
            Assert.Equal(BlendMode.Factor.SrcAlpha, BlendMode.Alpha.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Alpha.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Alpha.ColorEquation);
            Assert.Equal(BlendMode.Factor.One, BlendMode.Alpha.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Alpha.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Alpha.AlphaEquation);
        }

        /// <summary>
        ///     Tests that BlendMode.Add has the expected factor values
        /// </summary>
        [Fact]
        public void BlendMode_Add_HasExpectedFactors()
        {
            Assert.Equal(BlendMode.Factor.SrcAlpha, BlendMode.Add.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.One, BlendMode.Add.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Add.ColorEquation);
            // Static Add uses 6-factor constructor: alpha factors are One, One, Add
            Assert.Equal(BlendMode.Factor.One, BlendMode.Add.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.One, BlendMode.Add.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Add.AlphaEquation);
        }

        /// <summary>
        ///     Tests that BlendMode.Multiply has the expected factor values (2-factor ctor propagates to alpha)
        /// </summary>
        [Fact]
        public void BlendMode_Multiply_HasExpectedFactors()
        {
            Assert.Equal(BlendMode.Factor.DstColor, BlendMode.Multiply.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, BlendMode.Multiply.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Multiply.ColorEquation);
            // 2-factor constructor propagates same factors to alpha channel
            Assert.Equal(BlendMode.Factor.DstColor, BlendMode.Multiply.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, BlendMode.Multiply.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.Multiply.AlphaEquation);
        }

        /// <summary>
        ///     Tests that BlendMode.None has the expected factor values (2-factor ctor propagates to alpha)
        /// </summary>
        [Fact]
        public void BlendMode_None_HasExpectedFactors()
        {
            Assert.Equal(BlendMode.Factor.One, BlendMode.None.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, BlendMode.None.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.None.ColorEquation);
            // 2-factor constructor propagates same factors to alpha channel
            Assert.Equal(BlendMode.Factor.One, BlendMode.None.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, BlendMode.None.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, BlendMode.None.AlphaEquation);
        }

        /// <summary>
        ///     Tests that all BlendMode static readonly fields are distinct instances
        /// </summary>
        [Fact]
        public void BlendMode_StaticFields_AreDistinct()
        {
            Assert.NotEqual(BlendMode.Alpha, BlendMode.Add);
            Assert.NotEqual(BlendMode.Alpha, BlendMode.Multiply);
            Assert.NotEqual(BlendMode.Alpha, BlendMode.None);
            Assert.NotEqual(BlendMode.Add, BlendMode.Multiply);
            Assert.NotEqual(BlendMode.Add, BlendMode.None);
            Assert.NotEqual(BlendMode.Multiply, BlendMode.None);
        }

        /// <summary>
        ///     Tests that BlendMode equality works correctly
        /// </summary>
        [Fact]
        public void BlendMode_Equality_WorksCorrectly()
        {
            BlendMode mode1 = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);
            BlendMode mode2 = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);
            BlendMode mode3 = new BlendMode(BlendMode.Factor.One, BlendMode.Factor.Zero);

            Assert.Equal(mode1, mode2);
            Assert.NotEqual(mode1, mode3);
            Assert.True(mode1 == mode2);
            Assert.True(mode1 != mode3);
        }

        /// <summary>
        ///     Tests that BlendMode GetHashCode is consistent with Equals
        /// </summary>
        [Fact]
        public void BlendMode_GetHashCode_IsConsistentWithEquals()
        {
            BlendMode mode1 = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);
            BlendMode mode2 = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha);

            Assert.Equal(mode1.GetHashCode(), mode2.GetHashCode());
        }

        #endregion

        #region BlendMode Constructor Tests

        /// <summary>
        ///     Tests that BlendMode 2-factor constructor sets correct defaults
        /// </summary>
        [Fact]
        public void BlendMode_TwoFactorConstructor_SetsCorrectDefaults()
        {
            BlendMode mode = new BlendMode(BlendMode.Factor.SrcAlpha, BlendMode.Factor.One);

            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.One, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.One, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.AlphaEquation);
        }

        /// <summary>
        ///     Tests that BlendMode 3-factor constructor sets correct values
        /// </summary>
        [Fact]
        public void BlendMode_ThreeFactorConstructor_SetsCorrectValues()
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
        ///     Tests that BlendMode 6-factor constructor sets all values independently
        /// </summary>
        [Fact]
        public void BlendMode_SixFactorConstructor_SetsAllValuesIndependently()
        {
            BlendMode mode = new BlendMode(
                BlendMode.Factor.One, BlendMode.Factor.Zero, BlendMode.Equation.Add,
                BlendMode.Factor.SrcAlpha, BlendMode.Factor.OneMinusSrcAlpha, BlendMode.Equation.Subtract);

            Assert.Equal(BlendMode.Factor.One, mode.ColorSrcFactor);
            Assert.Equal(BlendMode.Factor.Zero, mode.ColorDstFactor);
            Assert.Equal(BlendMode.Equation.Add, mode.ColorEquation);
            Assert.Equal(BlendMode.Factor.SrcAlpha, mode.AlphaSrcFactor);
            Assert.Equal(BlendMode.Factor.OneMinusSrcAlpha, mode.AlphaDstFactor);
            Assert.Equal(BlendMode.Equation.Subtract, mode.AlphaEquation);
        }

        #endregion

        #region Vertex Tests

        /// <summary>
        ///     Tests that Vertex position-only constructor sets default color and tex coords
        /// </summary>
        [Fact]
        public void Vertex_PositionOnlyConstructor_SetsDefaults()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            Vertex vertex = new Vertex(position);

            Assert.Equal(position, vertex.Position);
            Assert.Equal(Color.White, vertex.Color);
            Assert.Equal(new Vector2F(0, 0), vertex.TexCoords);
        }

        /// <summary>
        ///     Tests that Vertex position+color constructor sets default tex coords
        /// </summary>
        [Fact]
        public void Vertex_PositionColorConstructor_SetsDefaultTexCoords()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            Color color = Color.Red;
            Vertex vertex = new Vertex(position, color);

            Assert.Equal(position, vertex.Position);
            Assert.Equal(color, vertex.Color);
            Assert.Equal(new Vector2F(0, 0), vertex.TexCoords);
        }

        /// <summary>
        ///     Tests that Vertex position+texCoords constructor sets default color
        /// </summary>
        [Fact]
        public void Vertex_PositionTexCoordsConstructor_SetsDefaultColor()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            Vector2F texCoords = new Vector2F(0.5f, 0.75f);
            Vertex vertex = new Vertex(position, texCoords);

            Assert.Equal(position, vertex.Position);
            Assert.Equal(Color.White, vertex.Color);
            Assert.Equal(texCoords, vertex.TexCoords);
        }

        /// <summary>
        ///     Tests that Vertex full constructor sets all values
        /// </summary>
        [Fact]
        public void Vertex_FullConstructor_SetsAllValues()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            Color color = Color.Blue;
            Vector2F texCoords = new Vector2F(0.5f, 0.75f);
            Vertex vertex = new Vertex(position, color, texCoords);

            Assert.Equal(position, vertex.Position);
            Assert.Equal(color, vertex.Color);
            Assert.Equal(texCoords, vertex.TexCoords);
        }

        /// <summary>
        ///     Tests that Vertex.ToString includes all components
        /// </summary>
        [Fact]
        public void Vertex_ToString_IncludesAllComponents()
        {
            Vector2F position = new Vector2F(1.0f, 2.0f);
            Vertex vertex = new Vertex(position);

            string str = vertex.ToString();

            Assert.StartsWith("[Vertex]", str);
            Assert.Contains("Position", str);
            Assert.Contains("Color", str);
            Assert.Contains("TexCoords", str);
        }

        #endregion
    }
}
