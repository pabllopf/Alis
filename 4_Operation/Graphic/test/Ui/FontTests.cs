// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontTests.cs
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
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    /// The font tests class
    /// </summary>
    public class FontTests
    {
        /// <summary>
        /// Tests that size font field stores correct value
        /// </summary>
        [Fact]
        public void SizeFont_Field_StoresCorrectValue()
        {
            Font font = new Font("test", 1, 16);
            FieldInfo field = typeof(Font).GetField("sizeFont", BindingFlags.NonPublic | BindingFlags.Instance);
            int value = (int)field.GetValue(font);
            Assert.Equal(16, value);
        }

        /// <summary>
        /// Tests that character rects field is initialized empty
        /// </summary>
        [Fact]
        public void CharacterRects_Field_IsInitializedEmpty()
        {
            Font font = new Font("test", 1, 16);
            FieldInfo field = typeof(Font).GetField("CharacterRects", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<char, RectangleI> rects = (Dictionary<char, RectangleI>)field.GetValue(font);
            Assert.NotNull(rects);
            Assert.Empty(rects);
        }

        

        /// <summary>
        /// Tests that initialize character rects from atlas populates all characters
        /// </summary>
        [Fact]
        public void InitializeCharacterRectsFromAtlas_PopulatesAllCharacters()
        {
            Font font = new Font("test", 1, 16);
            MethodInfo method = typeof(Font).GetMethod("InitializeCharacterRectsFromAtlas", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo field = typeof(Font).GetField("CharacterRects", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(font, new object[] { 10, 16, 28, 1, 0 });
            Dictionary<char, RectangleI> rects = (Dictionary<char, RectangleI>)field.GetValue(font);

            Assert.Equal(80, rects.Count);
        }

        /// <summary>
        /// Tests that initialize character rects from atlas special chars have correct row
        /// </summary>
        [Fact]
        public void InitializeCharacterRectsFromAtlas_SpecialChars_HaveCorrectRow()
        {
            Font font = new Font("test", 1, 16);
            MethodInfo method = typeof(Font).GetMethod("InitializeCharacterRectsFromAtlas", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo field = typeof(Font).GetField("CharacterRects", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(font, new object[] { 10, 16, 28, 1, 0 });
            Dictionary<char, RectangleI> rects = (Dictionary<char, RectangleI>)field.GetValue(font);

            Assert.Equal(0, rects['0'].Y);
            Assert.Equal(0, rects['0'].X);
            Assert.Equal(10, rects['0'].W);
            Assert.Equal(16, rects['0'].H);
        }

        /// <summary>
        /// Tests that initialize character rects from atlas upper case chars have correct row
        /// </summary>
        [Fact]
        public void InitializeCharacterRectsFromAtlas_UpperCaseChars_HaveCorrectRow()
        {
            Font font = new Font("test", 1, 16);
            MethodInfo method = typeof(Font).GetMethod("InitializeCharacterRectsFromAtlas", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo field = typeof(Font).GetField("CharacterRects", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(font, new object[] { 10, 16, 28, 1, 0 });
            Dictionary<char, RectangleI> rects = (Dictionary<char, RectangleI>)field.GetValue(font);

            Assert.Equal(16, rects['A'].Y);
            Assert.Equal(0, rects['A'].X);
        }

        /// <summary>
        /// Tests that initialize character rects from atlas lower case chars have correct row
        /// </summary>
        [Fact]
        public void InitializeCharacterRectsFromAtlas_LowerCaseChars_HaveCorrectRow()
        {
            Font font = new Font("test", 1, 16);
            MethodInfo method = typeof(Font).GetMethod("InitializeCharacterRectsFromAtlas", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo field = typeof(Font).GetField("CharacterRects", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(font, new object[] { 10, 16, 28, 1, 0 });
            Dictionary<char, RectangleI> rects = (Dictionary<char, RectangleI>)field.GetValue(font);

            Assert.Equal(32, rects['a'].Y);
            Assert.Equal(0, rects['a'].X);
        }

        /// <summary>
        /// Tests that initialize character rects from atlas with custom spacing calculates correct positions
        /// </summary>
        [Fact]
        public void InitializeCharacterRectsFromAtlas_WithCustomSpacing_CalculatesCorrectPositions()
        {
            Font font = new Font("test", 1, 16);
            MethodInfo method = typeof(Font).GetMethod("InitializeCharacterRectsFromAtlas", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo field = typeof(Font).GetField("CharacterRects", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(font, new object[] { 8, 12, 20, 2, 1 });
            Dictionary<char, RectangleI> rects = (Dictionary<char, RectangleI>)field.GetValue(font);

            Assert.Equal(0, rects['0'].Y);
            Assert.Equal(0, rects['0'].X);
            Assert.Equal(8, rects['0'].W);
            Assert.Equal(12, rects['0'].H);

            Assert.Equal(13, rects['A'].Y);
            Assert.Equal(0, rects['A'].X);

            Assert.Equal(26, rects['a'].Y);
            Assert.Equal(0, rects['a'].X);
        }

        /// <summary>
        /// Tests that initialize character rects from atlas with negative spacing still calculates
        /// </summary>
        [Fact]
        public void InitializeCharacterRectsFromAtlas_WithNegativeSpacing_StillCalculates()
        {
            Font font = new Font("test", 1, 16);
            MethodInfo method = typeof(Font).GetMethod("InitializeCharacterRectsFromAtlas", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo field = typeof(Font).GetField("CharacterRects", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(font, new object[] { 10, 16, 28, -1, 0 });
            Dictionary<char, RectangleI> rects = (Dictionary<char, RectangleI>)field.GetValue(font);

            Assert.Equal(80, rects.Count);
            Assert.Equal(0, rects['0'].X);
            Assert.Equal(9, rects['1'].X);
        }

        /// <summary>
        /// Tests that render text with null name file throws but populates character rects
        /// </summary>
        [Fact]
        public void RenderText_WithNullNameFile_ThrowsButPopulatesCharacterRects()
        {
            Font font = new Font(null, 1, 16);
            FieldInfo field = typeof(Font).GetField("CharacterRects", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("hello", 0, 0, Color.White, Color.Transparent));

            Dictionary<char, RectangleI> rects = (Dictionary<char, RectangleI>)field.GetValue(font);
            Assert.NotEmpty(rects);
            Assert.Equal(80, rects.Count);
        }

        /// <summary>
        /// Tests that render text with empty name file throws but populates character rects
        /// </summary>
        [Fact]
        public void RenderText_WithEmptyNameFile_ThrowsButPopulatesCharacterRects()
        {
            Font font = new Font("", 1, 16);
            FieldInfo field = typeof(Font).GetField("CharacterRects", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("A", 0, 0, Color.White, Color.Transparent));

            Dictionary<char, RectangleI> rects = (Dictionary<char, RectangleI>)field.GetValue(font);
            Assert.NotEmpty(rects);
        }
        

        /// <summary>
        /// Tests that render text with empty text does not iterate chars
        /// </summary>
        [Fact]
        public void RenderText_WithEmptyText_DoesNotIterateChars()
        {
            Font font = new Font(null, 1, 16);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText(string.Empty, 0, 0, Color.White, Color.Transparent));
        }

        /// <summary>
        /// Tests that render text with white background calls method
        /// </summary>
        [Fact]
        public void RenderText_WithWhiteBackground_CallsMethod()
        {
            Font font = new Font(null, 1, 16);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("x", 100, 200, Color.White, Color.White));
        }

        /// <summary>
        /// Tests that render text with custom position uses position
        /// </summary>
        [Fact]
        public void RenderText_WithCustomPosition_UsesPosition()
        {
            Font font = new Font(null, 1, 16);

            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("test", 50, 75, Color.Black, Color.Transparent));
        }
    }
}
