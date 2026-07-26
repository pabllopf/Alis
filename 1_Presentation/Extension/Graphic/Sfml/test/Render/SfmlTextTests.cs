// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlTextTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Moq;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class SfmlTextTests
    {
        [Fact]
        public void Constructor_Default_SetsEmptyStringNullFontSize30()
        {
            using SfmlText text = new SfmlText();
            Assert.Equal("", text.DisplayedString);
            Assert.Null(text.Font);
            Assert.Equal(30u, text.CharacterSize);
        }

        [Fact]
        public void Constructor_StringAndFont_SetsDisplayedStringAndFontAndSize30()
        {
            using SfmlText text = new SfmlText("Hello", null);
            Assert.Equal("Hello", text.DisplayedString);
            Assert.Null(text.Font);
            Assert.Equal(30u, text.CharacterSize);
        }

        [Fact]
        public void Constructor_StringFontSize_SetsAllProperties()
        {
            using SfmlText text = new SfmlText("Test", null, 42);
            Assert.Equal("Test", text.DisplayedString);
            Assert.Null(text.Font);
            Assert.Equal(42u, text.CharacterSize);
        }

        [Fact]
        public void Constructor_Copy_CopiesAllProperties()
        {
            using SfmlText original = new SfmlText("Copy", null, 20);
            using SfmlText copy = new SfmlText(original);
            Assert.Equal(original.DisplayedString, copy.DisplayedString);
            Assert.Equal(original.CharacterSize, copy.CharacterSize);
            Assert.Equal(original.Font, copy.Font);
        }

        [Fact]
        public void FillColor_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            Color color = new Color(255, 128, 64, 32);
            text.FillColor = color;
            Assert.Equal(color, text.FillColor);
        }

        [Fact]
        public void OutlineColor_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            Color color = new Color(10, 20, 30, 40);
            text.OutlineColor = color;
            Assert.Equal(color, text.OutlineColor);
        }

        [Fact]
        public void OutlineThickness_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.OutlineThickness = 2.5f;
            Assert.Equal(2.5f, text.OutlineThickness);
        }

        [Fact]
        public void DisplayedString_GetSet_Roundtrips()
        {
            using SfmlText text = new SfmlText();
            text.DisplayedString = "Hello World";
            Assert.Equal("Hello World", text.DisplayedString);
        }

        [Fact]
        public void DisplayedString_GetSet_WithUnicodeChars()
        {
            using SfmlText text = new SfmlText();
            text.DisplayedString = "äöüñçé";
            Assert.Equal("äöüñçé", text.DisplayedString);
        }

        [Fact]
        public void DisplayedString_GetSet_EmptyString()
        {
            using SfmlText text = new SfmlText();
            text.DisplayedString = "";
            Assert.Equal("", text.DisplayedString);
        }

        [Fact]
        public void Font_GetSet_Roundtrips()
        {
            using SfmlText text = new SfmlText();
            Assert.Null(text.Font);
            text.Font = null;
            Assert.Null(text.Font);
        }

        [Fact]
        public void CharacterSize_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.CharacterSize = 64;
            Assert.Equal(64u, text.CharacterSize);
        }

        [Fact]
        public void CharacterSize_GetSet_Zero()
        {
            using SfmlText text = new SfmlText();
            text.CharacterSize = 0;
            Assert.Equal(0u, text.CharacterSize);
        }

        [Fact]
        public void LetterSpacing_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.LetterSpacing = 1.5f;
            Assert.Equal(1.5f, text.LetterSpacing);
        }

        [Fact]
        public void LetterSpacing_GetSet_Default()
        {
            using SfmlText text = new SfmlText();
            Assert.Equal(1.0f, text.LetterSpacing);
        }

        [Fact]
        public void LineSpacing_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.LineSpacing = 2.0f;
            Assert.Equal(2.0f, text.LineSpacing);
        }

        [Fact]
        public void LineSpacing_GetSet_Default()
        {
            using SfmlText text = new SfmlText();
            Assert.Equal(1.0f, text.LineSpacing);
        }

        [Fact]
        public void Style_GetSet_ReturnsExpected()
        {
            using SfmlText text = new SfmlText();
            text.Style = Styles.Bold | Styles.Italic;
            Assert.Equal(Styles.Bold | Styles.Italic, text.Style);
        }

        [Fact]
        public void Style_GetSet_None()
        {
            using SfmlText text = new SfmlText();
            text.Style = Styles.None;
            Assert.Equal(Styles.None, text.Style);
        }

        [Fact]
        public void Style_GetSet_AllFlags()
        {
            using SfmlText text = new SfmlText();
            Styles all = Styles.Bold | Styles.Italic | Styles.Underlined | Styles.StrikeThrough;
            text.Style = all;
            Assert.Equal(all, text.Style);
        }

        [Fact]
        public void ToString_ContainsAllComponents()
        {
            using SfmlText text = new SfmlText();
            string str = text.ToString();
            Assert.StartsWith("[Text]", str);
            Assert.Contains("FillColor", str);
            Assert.Contains("OutlineColor", str);
            Assert.Contains("String", str);
            Assert.Contains("Font", str);
            Assert.Contains("CharacterSize", str);
            Assert.Contains("OutlineThickness", str);
            Assert.Contains("Style", str);
        }

        [Fact]
        public void Draw_WithMockTarget_DoesNotThrow()
        {
            using SfmlText text = new SfmlText("Draw", null);
            Mock<IRenderTarget> mockTarget = new Mock<IRenderTarget>();
            RenderStates states = new RenderStates();
            text.Draw(mockTarget.Object, states);
        }

        [Fact]
        public void Draw_UpdatesTransform()
        {
            using SfmlText text = new SfmlText("Draw", null);
            text.Position = new Vector2F(10, 20);
            Mock<IRenderTarget> mockTarget = new Mock<IRenderTarget>();
            RenderStates states = new RenderStates();
            text.Draw(mockTarget.Object, states);
        }

        [Fact]
        public void Destroy_SetsCPointerToZero()
        {
            SfmlText text = new SfmlText();
            Assert.NotEqual(System.IntPtr.Zero, text.CPointer);
            text.Destroy(true);
            Assert.Equal(System.IntPtr.Zero, text.CPointer);
        }

        [Fact]
        public void Dispose_CallsDestroy()
        {
            SfmlText text = new SfmlText();
            text.Dispose();
            Assert.Equal(System.IntPtr.Zero, text.CPointer);
        }

        [Fact]
        public void Constructor_Default_Dispose_DoesNotThrow()
        {
            SfmlText text = new SfmlText();
            text.Dispose();
        }

        [Fact]
        public void Position_AndRotation_AffectsTransform()
        {
            using SfmlText text = new SfmlText("Test", null);
            text.Position = new Vector2F(100, 200);
            text.Rotation = 45;
            Vector2F pos = text.Position;
            Assert.Equal(100, pos.X);
            Assert.Equal(200, pos.Y);
            Assert.Equal(45, text.Rotation);
        }
    }
}
